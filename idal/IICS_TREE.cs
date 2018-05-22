using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thesis.modal;

namespace thesis.idal
{
    public interface IICS_TREEDal
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxID();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int INDEX_);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(ICS_Node model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ICS_Node model);
        void Update2(ICS_Node model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int INDEX_);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ICS_Node GetModel(int INDEX_);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		List<Node> GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        /// <summary>
        /// 获得对象在树中的节点信息
        /// </summary>
        /// <param name="Species_Type"></param>
        /// <param name="SpeciesID"></param>
        /// <returns></returns>
        ICS_Node GetModel(int Species_Type, int SpeciesID);
        /// <summary>
        /// 获得索引节点的路径
        /// </summary>
        /// <param name="species_type"></param>
        /// <param name="SpeciesID"></param>
        /// <returns></returns>
        string GetObjectPath(int species_type, int SpeciesID);
        /// <summary>
        /// 获得索引节点的路径
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        string GetObjectPath(int index);
        /// <summary>
        /// /获得匹配名称的节点
        /// </summary>
        /// <param name="name"></param>
        /// <param name="SpeciesType">允许的类型</param>
        /// <returns></returns>
        List<ICS_Node> GetNodesMatchName(string name, params int[] SpeciesType);
        /// <summary>
        /// /获得匹配编码的节点
        /// </summary>
        /// <param name="name"></param>
        /// <param name="SpeciesType">允许的类型</param>
        /// <returns></returns>
        List<ICS_Node> GetNodesMatchCode(string code, int[] SpeciesType);
        /// <summary>
        /// 获得用户的质量参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<ICS_Node> GetCharaTreeByUser(int UserID);
        /// <summary>
        /// 获得用户计量参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<ICS_Node> GetVariableTreeByUser(int UserID);
        /// <summary>
        /// 获得用户计数参数树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<ICS_Node> GetAttributeTreeByUser(int UserID);
        /// <summary>
        /// 获得用户监控计划树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<ICS_Node> GetPlanTreeByUser(int UserID);
        /// <summary>
        /// 获得监控计划下的节点
        /// </summary>
        /// <param name="PlanID"></param>
        /// <returns></returns>
        List<ICS_Node> GetNodesByPlan(int PlanID);
        /// <summary>
        /// 获得指定层的所有节点
        /// </summary>
        /// <param name="Floor"></param>
        /// <returns></returns>
        List<ICS_Node> GetNodesByFloor(int Floor);
        /// <summary>
        /// 获得父节点下的所有节点
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <param name="Recursive">是否递归</param>
        /// <returns></returns>
        List<ICS_Node> GetNodesByParent(int ParentIndex, bool Recursive);
        /// <summary>
        /// 所有节点
        /// </summary>
        /// <returns></returns>
        List<ICS_Node> GetAllList();
        /// <summary>
        /// 最大层数
        /// </summary>
        /// <returns></returns>
        int GetMaxFloor();

        /// <summary>
        /// 判断一个节点是否为另一个节点的子孙节点
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <param name="ChildIndex"></param>
        /// <returns></returns>

        bool IsDescendant(int ParentIndex, int ChildIndex);
        /// <summary>
        /// 判断一个节点是否为另一个节点的子孙节点
        /// </summary>
        /// <param name="ParentType"></param>
        /// <param name="ParentID"></param>
        /// <param name="ChildType"></param>
        /// <param name="ChildID"></param>
        /// <returns></returns>
        bool IsDescendant(int ParentType, int ParentID, int ChildType, int ChildID);
        /// <summary>
        ///  获得用户权限树的根节点
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<ICS_Node> GetUserRootNodes(int UserID);

        List<ICS_Node> GetPlanTreeByParent(int ParentIndex);

        List<ICS_Node> GetAttributeTreeByParent(int ParentIndex);

        List<ICS_Node> GetCharaTreeByParent(int ParentIndex);

        List<ICS_Node> GetVariableTreeByParent(int ParentIndex);

        /// <summary>
        /// 根据父节点获得网页树
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <returns></returns>
        List<ICS_Node> GetWebTreeByParent(int ParentIndex);

        /// <summary>
        /// 获得用户的网页树
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<ICS_Node> GetWebTreeByUser(int UserID);

        /// <summary>
        /// 根据父节点获得网页树(包括父节点)
        /// </summary>
        /// <param name="ParentIndex"></param>
        /// <returns></returns>
        List<ICS_Node> GetAllWebTreeByParent(int ParentIndex);
    }
}
