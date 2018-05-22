using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;
using System.Data;
using thesis.common;
using thesis.idal;

namespace thesis.dal
{
    public class ICS_TREEDal : IICS_TREEDal
    {
        public ICS_TREEDal()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return DbHelperSQL.GetMaxID("INDEX_", "ICS_TREE");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int INDEX_)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ICS_TREE");
            strSql.Append(" where INDEX_=" + INDEX_ + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ICS_Node model)
        {
            model.INDEX_ = GetMaxID() + 1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ICS_TREE(");
            strSql.Append("NAME,INDEX_,PINDEX,SPECIES,SPECIES_ID,CS,BH,BH2_,CREATETIME,");
            if (!model.BH.Equals(""))
            {
                strSql.Append("CLICKTIMES,LASTCLICKTIME,");
            }

            strSql.Append("UPDATETIME)");
            strSql.Append(" values (");
            strSql.Append("'" + model.NAME + "',");
            strSql.Append("" + model.INDEX_ + ",");
            strSql.Append("" + model.PINDEX + ",");
            strSql.Append("" + model.SPECIES + ",");
            strSql.Append("" + model.SPECIES_ID + ",");
            strSql.Append("" + model.CS + ",");
            strSql.Append("'" + model.BH + "',");
            strSql.Append("'" + model.BH2_ + "',");
            strSql.Append(DbHelperSQL.GetDbTimeFunctionName() + ",");
            if (!model.BH.Equals(""))
            {
                strSql.Append("'0',");
                strSql.Append("'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',");
            }


            strSql.Append(DbHelperSQL.GetDbTimeFunctionName() + " ");

            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ICS_Node model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ICS_TREE set ");
            strSql.Append("NAME='" + model.NAME + "',");
            strSql.Append("PINDEX=" + model.PINDEX + ",");
            strSql.Append("SPECIES=" + model.SPECIES + ",");
            strSql.Append("SPECIES_ID=" + model.SPECIES_ID + ",");
            strSql.Append("CS=" + model.CS + ",");
            strSql.Append("BH='" + model.BH + "',");
            strSql.Append("CREATETIME=" + DbHelperSQL.GetDateTimeSQL(model.CREATETIME) + ",");
            strSql.Append("UPDATETIME=" + DbHelperSQL.GetDbTimeFunctionName() + ", ");
            strSql.Append("BH2_='" + model.BH2_ + "' ");
            strSql.Append(" where INDEX_=" + model.INDEX_ + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void Update2(ICS_Node model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ICS_TREE set ");
            int clicktime = 1;
            if (!model.CLICKTIMES.Equals(""))
            {
                clicktime = int.Parse(model.CLICKTIMES) + 1;
            }
            strSql.Append("CLICKTIMES='" + clicktime + "',");

            strSql.Append("LASTCLICKTIME='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            strSql.Append(" where INDEX_=" + model.INDEX_ + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int INDEX_)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete ICS_TREE ");
            strSql.Append(" where INDEX_=" + INDEX_ + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private ICS_Node GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NAME,INDEX_,PINDEX,SPECIES,SPECIES_ID,CS,BH,CREATETIME,UPDATETIME,CLICKTIMES,LASTCLICKTIME,BH2_ ");
            strSql.Append(" FROM ICS_TREE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CS,SPECIES,NAME");
            ICS_Node model = new ICS_Node();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                if (ds.Tables[0].Rows[0]["INDEX_"].ToString() != "")
                {
                    model.INDEX_ = int.Parse(ds.Tables[0].Rows[0]["INDEX_"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PINDEX"].ToString() != "")
                {
                    model.PINDEX = int.Parse(ds.Tables[0].Rows[0]["PINDEX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPECIES"].ToString() != "")
                {
                    model.SPECIES = int.Parse(ds.Tables[0].Rows[0]["SPECIES"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPECIES_ID"].ToString() != "")
                {
                    model.SPECIES_ID = int.Parse(ds.Tables[0].Rows[0]["SPECIES_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CS"].ToString() != "")
                {
                    model.CS = int.Parse(ds.Tables[0].Rows[0]["CS"].ToString());
                }
                model.BH = ds.Tables[0].Rows[0]["BH"].ToString();
                if (ds.Tables[0].Rows[0]["CREATETIME"].ToString() != "")
                {
                    model.CREATETIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATETIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UPDATETIME"].ToString() != "")
                {
                    model.UPDATETIME = DateTime.Parse(ds.Tables[0].Rows[0]["UPDATETIME"].ToString());
                }

                model.CLICKTIMES = ds.Tables[0].Rows[0]["CLICKTIMES"].ToString();
                model.LASTCLICKTIME = ds.Tables[0].Rows[0]["LASTCLICKTIME"].ToString();
                model.BH2_ = ds.Tables[0].Rows[0]["BH2_"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ICS_Node GetModel(int INDEX_)
        {
            string strWhere = " INDEX_=" + INDEX_ + " ";
            return GetModel(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_Node> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NAME,INDEX_,PINDEX,SPECIES,SPECIES_ID,CS,BH,CREATETIME,UPDATETIME,CLICKTIMES,LASTCLICKTIME,BH2_ ");
            strSql.Append(" FROM ICS_TREE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CS,SPECIES,SPECIES_ID ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ICS_Node> list = new List<ICS_Node>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ICS_Node model = new ICS_Node();
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                if (ds.Tables[0].Rows[i]["INDEX_"].ToString() != "")
                {
                    model.INDEX_ = int.Parse(ds.Tables[0].Rows[i]["INDEX_"].ToString());
                }
                if (ds.Tables[0].Rows[i]["PINDEX"].ToString() != "")
                {
                    model.PINDEX = int.Parse(ds.Tables[0].Rows[i]["PINDEX"].ToString());
                }
                if (ds.Tables[0].Rows[i]["SPECIES"].ToString() != "")
                {
                    model.SPECIES = int.Parse(ds.Tables[0].Rows[i]["SPECIES"].ToString());
                }
                if (ds.Tables[0].Rows[i]["SPECIES_ID"].ToString() != "")
                {
                    model.SPECIES_ID = int.Parse(ds.Tables[0].Rows[i]["SPECIES_ID"].ToString());
                }
                if (ds.Tables[0].Rows[i]["CS"].ToString() != "")
                {
                    model.CS = int.Parse(ds.Tables[0].Rows[i]["CS"].ToString());
                }
                model.BH = ds.Tables[0].Rows[i]["BH"].ToString();
                if (ds.Tables[0].Rows[i]["CREATETIME"].ToString() != "")
                {
                    model.CREATETIME = DateTime.Parse(ds.Tables[0].Rows[i]["CREATETIME"].ToString());
                }
                if (ds.Tables[0].Rows[i]["UPDATETIME"].ToString() != "")
                {
                    model.UPDATETIME = DateTime.Parse(ds.Tables[0].Rows[i]["UPDATETIME"].ToString());
                }
                model.CLICKTIMES = ds.Tables[0].Rows[i]["CLICKTIMES"].ToString();
                model.LASTCLICKTIME = ds.Tables[0].Rows[i]["LASTCLICKTIME"].ToString();
                model.BH2_ = ds.Tables[0].Rows[i]["BH2_"].ToString();
                list.Add(model);
            }
            return list;
        }
        public ICS_Node GetModel(int Species_type, int SpeciesID)  //获得对象在树中的节点信息
        {
            string strWhere = " SPECIES=" + Species_type + " AND SPECIES_ID=" + SpeciesID;
            return GetModel(strWhere);
        }
        /// <summary>
        /// 获得父节点下满足类型范围的所有节点
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <param name="FromSpecies"></param>
        /// <param name="EndSpecies"></param>
        /// <returns></returns>
        private List<ICS_Node> GetNodesByParent(int ParentIndex, int FromSpecies, int EndSpecies, int[] ExceptSpecies)
        {
            List<ICS_Node> descendants = new List<ICS_Node>();
            ICS_Node ParentNode = GetModel(ParentIndex);
            int FromFloor = ParentNode.CS + 1;
            //查询可能的子孙节点
            string strWhere = "SPECIES>=" + FromSpecies + " AND SPECIES<=" + EndSpecies + " AND CS>=" + FromFloor;
            List<ICS_Node> probably = GetList(strWhere);
            //寻找子节点
            foreach (ICS_Node node in probably)
            {
                if (node.CS == FromFloor && node.PINDEX == ParentNode.INDEX_)
                {
                    //过滤掉特殊类型
                    if (ExceptSpecies != null)
                    {
                        bool bExists = false;
                        foreach (int n in ExceptSpecies)
                        {
                            if (n == node.SPECIES)
                            {
                                bExists = true;
                                break;
                            }
                        }
                        if (bExists) continue;
                    }
                    descendants.Add(node);
                }
                else
                {
                    for (int i = descendants.Count - 1; i >= 0; i--)
                    {
                        if (node.PINDEX == descendants[i].INDEX_)
                        {
                            descendants.Add(node);
                            break;
                        }
                    }
                }
            }
            return descendants;
        }

        /// <summary>
        /// 获得父节点下满足类型范围的所有节点(包括父节点)
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <param name="FromSpecies"></param>
        /// <param name="EndSpecies"></param>
        /// <returns></returns>
        private List<ICS_Node> GetAllNodesByParent(int ParentIndex, int FromSpecies, int EndSpecies, int[] ExceptSpecies)
        {
            List<ICS_Node> descendants = new List<ICS_Node>();
            ICS_Node ParentNode = GetModel(ParentIndex);
            int FromFloor = ParentNode.CS;
            //查询可能的子孙节点
            string strWhere = "SPECIES>=" + FromSpecies + " AND SPECIES<=" + EndSpecies + " AND CS>=" + FromFloor;
            List<ICS_Node> probably = GetList(strWhere);
            //寻找子节点
            foreach (ICS_Node node in probably)
            {
                //if (node.CS == FromFloor )
                if (node.CS == FromFloor && node.INDEX_ == ParentNode.INDEX_)
                {
                    //过滤掉特殊类型
                    if (ExceptSpecies != null)
                    {
                        bool bExists = false;
                        foreach (int n in ExceptSpecies)
                        {
                            if (n == node.SPECIES)
                            {
                                bExists = true;
                                break;
                            }
                        }
                        if (bExists) continue;
                    }
                    descendants.Add(node);
                }
                else
                {
                    for (int i = descendants.Count - 1; i >= 0; i--)
                    {
                        if (node.PINDEX == descendants[i].INDEX_)
                        {
                            descendants.Add(node);
                            break;
                        }
                    }
                }
            }
            return descendants;
        }


        public List<ICS_Node> GetNodesByParent(int ParentIndex, bool Recursive)  //获得父节点下的所有节点
        {
            //Recursive=false时仅返回儿子节点
            if (!Recursive) return GetList("PINDEX=" + ParentIndex);
            //下面完成查询所有子孙节点
            List<ICS_Node> descendants = new List<ICS_Node>();
            //计算子孙数据的筛选范围
            ICS_Node ParentNode = GetModel(ParentIndex);
            int FromSpecies = 0;
            int EndSpecies = ICS_Node.SPECIES_MAX;
            switch (ParentNode.SPECIES)
            {
                case ICS_Node.SPECIES_ROOT_NODE: break;
                case ICS_Node.SPECIES_CHARA_FOLDER:
                    FromSpecies = ICS_Node.SPECIES_CHARA_FOLDER;
                    EndSpecies = ICS_Node.SPECIES_TAG;
                    break;
                case ICS_Node.SPECIES_CHARA_FILE:
                    FromSpecies = ICS_Node.SPECIES_CHARA_FILE;
                    EndSpecies = ICS_Node.SPECIES_TAG;
                    break;
                case ICS_Node.SPECIES_WFNAME:
                    FromSpecies = ICS_Node.SPECIES_WFNAME;
                    EndSpecies = ICS_Node.SPECIES_WFACTIVITY;
                    break;
                case ICS_Node.SPECIES_WEB_FOLDER:
                    FromSpecies = ICS_Node.SPECIES_WEB_FOLDER;
                    EndSpecies = ICS_Node.SPECIES_WEB;
                    break;
                case ICS_Node.SPECIES_ROLE:
                    FromSpecies = ICS_Node.SPECIES_ROLE;
                    EndSpecies = ICS_Node.SPECIES_USER;
                    break;
                case ICS_Node.SPECIES_DEVICE_FOLDER:
                    FromSpecies = ICS_Node.SPECIES_DEVICE_FOLDER;
                    EndSpecies = ICS_Node.SPECIES_DEVICE;
                    break;
                case ICS_Node.SPECIES_CHARA_VARIABLE:
                case ICS_Node.SPECIES_CHARA_ARRTIBUTE:
                case ICS_Node.SPECIES_TAG:
                case ICS_Node.SPECIES_WFACTIVITY:
                case ICS_Node.SPECIES_WEB:
                case ICS_Node.SPECIES_STATION:
                case ICS_Node.SPECIES_USER:
                case ICS_Node.SPECIES_DEVICE:
                    return descendants;
            }
            //查询结果
            return GetNodesByParent(ParentIndex, FromSpecies, EndSpecies, null);
        }
        public List<ICS_Node> GetNodesByFloor(int Floor)  //获得指定层的所有节点
        {
            string strWhere = "CS=" + Floor;
            return GetList(strWhere);
        }
        public List<ICS_Node> GetNodesByPlan(int PlanID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NAME,INDEX_,PINDEX,SPECIES,SPECIES_ID,CS,BH,CREATETIME,UPDATETIME ");
            strSql.Append(" FROM ICS_TREE , CJJHLB");
            strSql.Append(" where SPECIES=LX and SPECIES_ID= SPECIES34_ID and SPECIES7_ID=" + PlanID);
            strSql.Append(" order by CS,SPECIES,SPECIES_ID ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ICS_Node> list = new List<ICS_Node>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ICS_Node model = new ICS_Node();
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                if (ds.Tables[0].Rows[i]["INDEX_"].ToString() != "")
                {
                    model.INDEX_ = int.Parse(ds.Tables[0].Rows[i]["INDEX_"].ToString());
                }
                if (ds.Tables[0].Rows[i]["PINDEX"].ToString() != "")
                {
                    model.PINDEX = int.Parse(ds.Tables[0].Rows[i]["PINDEX"].ToString());
                }
                if (ds.Tables[0].Rows[i]["SPECIES"].ToString() != "")
                {
                    model.SPECIES = int.Parse(ds.Tables[0].Rows[i]["SPECIES"].ToString());
                }
                if (ds.Tables[0].Rows[i]["SPECIES_ID"].ToString() != "")
                {
                    model.SPECIES_ID = int.Parse(ds.Tables[0].Rows[i]["SPECIES_ID"].ToString());
                }
                if (ds.Tables[0].Rows[i]["CS"].ToString() != "")
                {
                    model.CS = int.Parse(ds.Tables[0].Rows[i]["CS"].ToString());
                }
                model.BH = ds.Tables[0].Rows[i]["BH"].ToString();
                if (ds.Tables[0].Rows[i]["CREATETIME"].ToString() != "")
                {
                    model.CREATETIME = DateTime.Parse(ds.Tables[0].Rows[i]["CREATETIME"].ToString());
                }
                if (ds.Tables[0].Rows[i]["UPDATETIME"].ToString() != "")
                {
                    model.UPDATETIME = DateTime.Parse(ds.Tables[0].Rows[i]["UPDATETIME"].ToString());
                }
                list.Add(model);
            }
            return list;

        }
        public List<ICS_Node> GetUserRootNodes(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NAME,INDEX_,PINDEX,SPECIES,a.SPECIES_ID,CS,BH,CREATETIME,UPDATETIME ");
            strSql.Append(" FROM ICS_TREE a,OBQX_WEB b ");
            strSql.Append(" where SPECIES=LX and a.SPECIES_ID=b.SPECIES_ID and YHLX=" + ICS_Node.SPECIES_ROLE +
                " and YHID in ( select distinct ROLE_ID from ROLEGL where YHID =" + UserID + ")");
            strSql.Append(" order by CS,SPECIES,NAME ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ICS_Node> list = new List<ICS_Node>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ICS_Node model = new ICS_Node();
                model.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                if (ds.Tables[0].Rows[i]["INDEX_"].ToString() != "")
                {
                    model.INDEX_ = int.Parse(ds.Tables[0].Rows[i]["INDEX_"].ToString());
                }
                if (ds.Tables[0].Rows[i]["PINDEX"].ToString() != "")
                {
                    model.PINDEX = int.Parse(ds.Tables[0].Rows[i]["PINDEX"].ToString());
                }
                if (ds.Tables[0].Rows[i]["SPECIES"].ToString() != "")
                {
                    model.SPECIES = int.Parse(ds.Tables[0].Rows[i]["SPECIES"].ToString());
                }
                if (ds.Tables[0].Rows[i]["SPECIES_ID"].ToString() != "")
                {
                    model.SPECIES_ID = int.Parse(ds.Tables[0].Rows[i]["SPECIES_ID"].ToString());
                }
                if (ds.Tables[0].Rows[i]["CS"].ToString() != "")
                {
                    model.CS = int.Parse(ds.Tables[0].Rows[i]["CS"].ToString());
                }
                model.BH = ds.Tables[0].Rows[i]["BH"].ToString();
                if (ds.Tables[0].Rows[i]["CREATETIME"].ToString() != "")
                {
                    model.CREATETIME = DateTime.Parse(ds.Tables[0].Rows[i]["CREATETIME"].ToString());
                }
                if (ds.Tables[0].Rows[i]["UPDATETIME"].ToString() != "")
                {
                    model.UPDATETIME = DateTime.Parse(ds.Tables[0].Rows[i]["UPDATETIME"].ToString());
                }
                list.Add(model);
            }
            return list;
        }
        private List<ICS_Node> GetUserTree(int UserID, int FromSpecies, int EndSpecies, int[] ExceptSpecies)
        {
            List<ICS_Node> RootNodes = GetUserRootNodes(UserID);
            List<ICS_Node> UserNodes = new List<ICS_Node>();
            foreach (ICS_Node node in RootNodes)
            {
                if (node.SPECIES < FromSpecies || node.SPECIES > EndSpecies) continue;
                //过滤掉特殊类型
                bool bExists = false;
                if (ExceptSpecies != null)
                {
                    foreach (int n in ExceptSpecies)
                    {
                        if (n == node.SPECIES)
                        {
                            bExists = true;
                            break;
                        }
                    }
                    if (bExists) continue;
                }
                //判断是否添加过
                bExists = false;
                foreach (ICS_Node node2 in UserNodes)
                {
                    if (node.INDEX_ == node2.INDEX_)
                    {
                        bExists = true;
                        break;
                    }
                }
                if (bExists) continue;
                //添加根节点
                UserNodes.Add(node);
                //添加该节点的所有子节点
                UserNodes.AddRange(GetNodesByParent(node.INDEX_, true));
            }
            //排序
            UserNodes.Sort(new System.Comparison<ICS_Node>(ICS_Node.Compare));
            //返回结果
            return UserNodes;
        }
        public List<ICS_Node> GetCharaTreeByUser(int UserID)  //获得用户的质量参数树
        {
            return GetUserTree(UserID, 0, ICS_Node.SPECIES_CHARA_ARRTIBUTE, null);
        }
        public List<ICS_Node> GetVariableTreeByUser(int UserID)  //获得用户计量参数树
        {
            return GetUserTree(UserID, 0, ICS_Node.SPECIES_CHARA_VARIABLE, null);
        }
        public List<ICS_Node> GetAttributeTreeByUser(int UserID)  //获得用户计数参数树
        {
            return GetUserTree(UserID, 0, ICS_Node.SPECIES_CHARA_VARIABLE, new int[] { ICS_Node.SPECIES_CHARA_VARIABLE });
        }

        public List<ICS_Node> GetWebTreeByUser(int UserID)  //获得用户Web树
        {
            return GetUserTree(UserID, ICS_Node.SPECIES_WEB_FOLDER, ICS_Node.SPECIES_WEB, null);
        }
        public String GetObjectPath(int index)  //获得索引节点的路径
        {
            ICS_Node node = GetModel(index);
            if (node == null) return null;
            string path = node.NAME;
            while (node.PINDEX > 0)
            {
                node = GetModel(node.PINDEX);
                path = node.NAME + "\\" + path;
            }
            return path;
        }
        public String GetObjectPath(int species_type, int SpeciesID)  //获得索引节点的路径
        {
            ICS_Node node = GetModel(species_type, SpeciesID);
            if (node == null) return null;
            string path = node.NAME;
            while (node.PINDEX > 0)
            {
                node = GetModel(node.PINDEX);
                path = node.NAME + "\\" + path;
            }
            return path;
        }
        public int GetMaxFloor()  //获得最大层数
        {
            string sql = "select max(CS) from tree ";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        public List<ICS_Node> GetNodesMatchName(String name, params int[] SpeciesType) //获得匹配
        {
            string instr = "";
            for (int i = 0; SpeciesType != null && i < SpeciesType.Length; i++)
            {
                if (instr != "") instr = instr + ",";
                instr = instr + SpeciesType[i];
            }
            string strWhere = "NAME LIKE '%" + name + "%'";
            if (instr != "") strWhere = strWhere + " AND SPECIES IN (" + instr + ")";
            return GetList(strWhere);
        }
        public List<ICS_Node> GetNodesMatchCode(String code, params int[] SpeciesType) //获得匹配
        {
            string instr = "";
            for (int i = 0; SpeciesType != null && i < SpeciesType.Length; i++)
            {
                if (instr != "") instr = instr + ",";
                instr = instr + SpeciesType[i];
            }
            string strWhere = "BH LIKE '%" + code + "%'";
            if (instr != "") strWhere = strWhere + " AND SPECIES IN (" + instr + ")";
            return GetList(strWhere);
        }
        public List<ICS_Node> GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 判断一个节点是否为另一个节点的子孙节点
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <param name="ChildIndex"></param>
        /// <returns></returns>

        public bool IsDescendant(int ParentIndex, int ChildIndex)
        {
            ICS_Node child = GetModel(ChildIndex);
            if (child == null) return false;
            while (true)
            {
                if (child.PINDEX == ParentIndex) return true;
                if (child.PINDEX <= 0) break; ;
                child = GetModel(child.PINDEX);
            }
            return false;
        }
        /// <summary>
        /// 判断一个节点是否为另一个节点的子孙节点
        /// </summary>
        /// <param name="ParentType"></param>
        /// <param name="ParentID"></param>
        /// <param name="ChildType"></param>
        /// <param name="ChildID"></param>
        /// <returns></returns>
        public bool IsDescendant(int ParentType, int ParentID, int ChildType, int ChildID)
        {
            ICS_Node child = GetModel(ChildType, ChildID);
            if (child == null) return false;
            ICS_Node parent = GetModel(ParentType, ParentID);
            if (parent == null) return false;
            while (true)
            {
                if (child.PINDEX == parent.INDEX_) return true;
                if (child.PINDEX <= 0) break; ;
                child = GetModel(child.PINDEX);
            }
            return false;
        }
        /*
		*/


        /// <summary>
        /// 根据父节点获得网页树
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <returns></returns>
        public List<ICS_Node> GetWebTreeByParent(int ParentIndex)
        {
            return GetNodesByParent(ParentIndex, ICS_Node.SPECIES_WEB_FOLDER, ICS_Node.SPECIES_WEB, null);
        }

        public List<ICS_Node> GetAllWebTreeByParent(int ParentIndex)
        {
            return GetAllNodesByParent(ParentIndex, ICS_Node.SPECIES_WEB_FOLDER, ICS_Node.SPECIES_WEB, null);
        }

        public List<ICS_Node> GetAttributeTreeByParent(int ParentIndex)
        {
            return GetNodesByParent(ParentIndex, 0, ICS_Node.SPECIES_CHARA_ARRTIBUTE, new int[] { ICS_Node.SPECIES_CHARA_VARIABLE });
        }

        public List<ICS_Node> GetCharaTreeByParent(int ParentIndex)
        {
            return GetNodesByParent(ParentIndex, 0, ICS_Node.SPECIES_CHARA_ARRTIBUTE, null);
        }

        public List<ICS_Node> GetVariableTreeByParent(int ParentIndex)
        {
            return GetNodesByParent(ParentIndex, 0, ICS_Node.SPECIES_CHARA_VARIABLE, null);
        }


        public List<ICS_Node> GetPlanTreeByUser(int UserID)
        {
            throw new NotImplementedException();
        }

        public List<ICS_Node> GetPlanTreeByParent(int ParentIndex)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
