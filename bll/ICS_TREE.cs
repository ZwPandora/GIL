using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;
using thesis.dal;

namespace thesis.bll
{
    public class ICS_TREEBll
    {
        ICS_TREEDal dal = new ICS_TREEDal();
        public ICS_TREEBll()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxID()
        {
            return dal.GetMaxID();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int INDEX_)
        {
            return dal.Exists(INDEX_);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ICS_Node model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ICS_Node model)
        {
            dal.Update(model);
        }

        public void Update2(ICS_Node model)
        {
            dal.Update2(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int INDEX_)
        {
            dal.Delete(INDEX_);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ICS_Node GetModel(int INDEX_)
        {
            return dal.GetModel(INDEX_);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ICS_Node> GetAllList()
        {
            return dal.GetAllList();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<ICS_Node> GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        /// <summary>
        /// 获得对象在树中的节点信息
        /// </summary>
        /// <param name="Species_Type"></param>
        /// <param name="SpeciesID"></param>
        /// <returns></returns>
        public ICS_Node GetModel(int Species_Type, int SpeciesID)
        {
            return dal.GetModel(Species_Type, SpeciesID);
        }
        /// <summary>
        /// /获得父节点下的所有节点
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <param name="Recursive">是否递归</param>
        /// <returns></returns>
        public List<ICS_Node> GetNodesByParent(int ParentIndex, bool Recursive)
        {
            return dal.GetNodesByParent(ParentIndex, Recursive);
        }
        /// <summary>
        /// 获得指定层的所有节点
        /// </summary>
        /// <param name="Floor"></param>
        /// <returns></returns>
        public List<ICS_Node> GetNodesByFloor(int Floor)
        {
            return dal.GetNodesByFloor(Floor);
        }
        /// <summary>
        /// 获得监控计划下的节点
        /// </summary>
        /// <param name="PlanID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetNodesByPlan(int PlanID)
        {
            return dal.GetNodesByPlan(PlanID);
        }
        /// <summary>
        /// 获得用户权限树的根节点
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetUserRootNodes(int UserID)
        {
            return dal.GetUserRootNodes(UserID);
        }
        /// <summary>
        /// 根据父节点获得质量参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetCharaTreeByParent(int ParentIndex)
        {
            return dal.GetCharaTreeByParent(ParentIndex);
        }
        /// <summary>
        /// 根据父节点获得计量参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetVariableTreeByParent(int ParentIndex)
        {
            return dal.GetVariableTreeByParent(ParentIndex);
        }
        /// <summary>
        /// 根据父节点获得计数参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetAttributeTreeByParent(int ParentIndex)
        {
            return dal.GetAttributeTreeByParent(ParentIndex);
        }
        /// <summary>
        /// 根据父节点获得监控计划树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetPlanTreeByParent(int ParentIndex)
        {
            return dal.GetPlanTreeByParent(ParentIndex);
        }
        /// <summary>
        /// 获得用户的质量参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetCharaTreeByUser(int UserID)
        {
            return dal.GetCharaTreeByUser(UserID);
        }
        /// <summary>
        /// 获得用户计量参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetVariableTreeByUser(int UserID)
        {
            return dal.GetVariableTreeByUser(UserID);
        }
        /// <summary>
        /// 获得用户计数参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetAttributeTreeByUser(int UserID)
        {
            return dal.GetAttributeTreeByUser(UserID);
        }
        /// <summary>
        /// 获得用户监控计划树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetPlanTreeByUser(int UserID)
        {
            return dal.GetPlanTreeByUser(UserID);
        }
        /// <summary>
        /// 获得索引节点的路径
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public String GetObjectPath(int index)
        {
            return dal.GetObjectPath(index);
        }
        /// <summary>
        /// 获得索引节点的路径
        /// </summary>
        /// <param name="species_type"></param>
        /// <param name="SpeciesID"></param>
        /// <returns></returns>
        public String GetObjectPath(int species_type, int SpeciesID)
        {
            return dal.GetObjectPath(species_type, SpeciesID);
        }
        /// <summary>
        /// 获得最大层数
        /// </summary>
        /// <returns></returns>
        public int GetMaxFloor()
        {
            return dal.GetMaxFloor();
        }
        /// <summary>
        /// 获得匹配名称的节点 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="SpeciesType"></param>
        /// <returns></returns>
        public List<ICS_Node> GetNodesMatchName(string name, params int[] SpeciesType)
        {
            return dal.GetNodesMatchName(name, SpeciesType);
        }
        /// <summary>
        /// 获得匹配编码的节点 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="SpeciesType"></param>
        /// <returns></returns>
        public List<ICS_Node> GetICS_NodesMatchCode(string code, params int[] SpeciesType)
        {
            return dal.GetNodesMatchCode(code, SpeciesType);
        }
        /// <summary>
        /// 判断一个节点是否为另一个节点的子孙节点
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <param name="ChildIndex"></param>
        /// <returns></returns>
        public bool IsDescendant(int ParentIndex, int ChildIndex)
        {
            return dal.IsDescendant(ParentIndex, ChildIndex);
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
            return dal.IsDescendant(ParentType, ParentID, ChildType, ChildID);
        }

        /// <summary>
        /// 根据父节点获得网页树
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <returns></returns>
        public List<ICS_Node> GetWebTreeByParent(int ParentIndex)
        {
            return dal.GetWebTreeByParent(ParentIndex);
        }

        /// <summary>
        /// 获得用户的网页树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<ICS_Node> GetWebTreeByUser(int UserID)
        {
            return dal.GetWebTreeByUser(UserID);
        }

        /// <summary>
        /// 根据父节点获得网页树(包括父节点)
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <returns></returns>
        public List<ICS_Node> GetAllWebTreeByParent(int ParentIndex)
        {
            return dal.GetAllWebTreeByParent(ParentIndex);
        }
        #endregion  成员方法
    }
}
