using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineUI;
using thesis.model;
using thesis.bll;

/// <summary>
///TreeHelper_Web 的摘要说明
/// </summary>
public class TreeHelper_Web
{
    public TreeHelper_Web()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 构建RootNode下用户有权限的Web树
    /// </summary>
    /// <param name="UserID">用户ID</param>
    /// <param name="RootNode">要建子树的根节点</param>
    public static void BuildUserWebTree(int UserID, TreeNode RootNode, Tree tview1)
    {
        if (RootNode == null) return;
        tview1.NodeCommand += tree_NodeCommand;
        Web_NodeBll node_bll = new Web_NodeBll();
        List<Web_Node> nodes = new List<Web_Node>();
        nodes = node_bll.GetWebTreeByUser(UserID);

        List<TreeNode> pnodelist = new List<TreeNode>();
        foreach (Web_Node node in nodes)
        {
            //找父节点
            TreeNode pnode = RootNode;
            for (int i = pnodelist.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(pnodelist[i].NodeID) == node.PINDEX)
                {
                    pnode = pnodelist[i];
                    break;
                }
            }
            //建节点
            if (node.PINDEX == 2)
            {
                //if (node.NAME.Equals(ConfigurationManager.AppSettings["SiteName"]) || node.NAME.Equals("系统管理") || node.NAME.Equals("我的信息中心"))
                //{
                TreeNode cnode = new TreeNode();
                cnode.Text = node.NAME;
                cnode.NodeID = node.INDEX_.ToString();
                cnode.EnableExpandEvent= true;
                tview1.Nodes.Add(cnode);
                pnodelist.Add(cnode);
                //}
            }
            else if (node.CS > 2 && pnode == RootNode)
            {
                Web_NodeBll nbll = new Web_NodeBll();
                List<Web_Node> templist = new List<Web_Node>();
                templist.Add(node);
                Web_Node t1 = node;
                while (t1.CS > 3)
                {
                    t1 = nbll.GetModel(t1.PINDEX);
                    if (t1.PINDEX == 2)
                    {
                        //if (t1.NAME.Equals(ConfigurationManager.AppSettings["SiteName"]) || t1.NAME.Equals("系统管理") || t1.NAME.Equals("我的信息中心"))
                        //{
                        templist.Add(t1);
                        //}
                    }
                    else
                    {
                        templist.Add(t1);
                    }
                }
                TreeNode cnode = new TreeNode();
                cnode.Text = t1.NAME;
                cnode.NodeID = t1.INDEX_.ToString();
                cnode.EnableExpandEvent = true;
                bool tep = false;
                for (int i = pnodelist.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(pnodelist[i].NodeID) == t1.INDEX_)
                    {
                        pnode = pnodelist[i];
                        tep = true;
                        break;
                    }
                }
                if (!tep)
                {
                    //if (cnode.Text.Equals(ConfigurationManager.AppSettings["SiteName"]) || cnode.Text.Equals("系统管理") || cnode.Text.Equals("我的信息中心"))
                    //{
                    tview1.Nodes.Add(cnode);
                    pnodelist.Add(cnode);
                    pnode = cnode;

                    //}


                }

                for (int i = templist.Count - 2; i >= 0; i--)
                {
                    TreeNode testnode = new TreeNode();
                    testnode.Text = templist[i].NAME;
                    testnode.NodeID = templist[i].INDEX_.ToString();
                    cnode.EnableExpandEvent = true;
                    if (templist[i].BH != "")
                    {
                        testnode.IconUrl = "~/images/filetype/vs_aspx.png";
                        testnode.NavigateUrl = templist[i].BH;
                        testnode.ToolTip = templist[i].NAME;
                        testnode.EnableExpandEvent = true;
                    }
                    //if (testnode.Text.Equals("生产监控") || testnode.Text.Equals("系统管理") || testnode.Text.Equals("我的信息中心"))
                    //{
                    pnode.Nodes.Add(testnode);
                    pnodelist.Add(testnode);
                    pnode = testnode;
                    //}
                }
            }
            else
            {
                TreeNode cnode = new TreeNode();
                cnode.Text = node.NAME;
                cnode.NodeID = node.INDEX_.ToString();
                cnode.EnableExpandEvent = true;
                if (node.BH != "")
                {
                    cnode.IconUrl = "~/images/filetype/vs_aspx.png";
                    cnode.NavigateUrl = node.BH;
                    cnode.ToolTip = node.NAME;
                    cnode.EnableExpandEvent = true;
                }
                //if (cnode.Text.Equals("生产监控") || cnode.Text.Equals("系统管理") || cnode.Text.Equals("我的信息中心"))
                //{
                pnode.Nodes.Add(cnode);
                pnodelist.Add(cnode);
                //}
            }
        }

    }

    public static void tree_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
    {
        if (!e.Node.NavigateUrl.ToString().Equals(""))
        {
            #region 向数据库中写入菜单的访问频次和最后一次访问时间
            Web_NodeBll bll = new Web_NodeBll();
            Web_Node model = bll.GetModel(int.Parse(e.NodeID));
            bll.Update2(model);
            #endregion
        }
    }

    public static void BuildUserWebTree(int UserID, TreeNode RootNode, Accordion acc)
    {
        if (RootNode == null) return;

        Tree tview1 = new Tree();
        tview1.NodeCommand += tree_NodeCommand;

        #region 获取用户所有的功能节点
        Web_NodeBll node_bll = new Web_NodeBll();
        List<Web_Node> nodes = new List<Web_Node>();
        nodes = node_bll.GetWebTreeByUser(UserID);

        List<TreeNode> pnodelist = new List<TreeNode>();
        foreach (Web_Node node in nodes)
        {
            //找父节点
            TreeNode pnode = RootNode;
            for (int i = pnodelist.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(pnodelist[i].NodeID) == node.PINDEX)
                {
                    pnode = pnodelist[i];
                    break;
                }
            }
            //建节点
            if (node.PINDEX == 2)
            {
                //if (node.NAME.Equals(ConfigurationManager.AppSettings["SiteName"]) || node.NAME.Equals("系统管理") || node.NAME.Equals("我的信息中心"))
                //{
                TreeNode cnode = new TreeNode();
                cnode.Text = node.NAME;
                cnode.NodeID = node.INDEX_.ToString();
                cnode.EnableExpandEvent = true;
                tview1.Nodes.Add(cnode);
                pnodelist.Add(cnode);
                //}
            }
            else if (node.CS > 2 && pnode == RootNode)
            {
                Web_NodeBll nbll = new Web_NodeBll();
                List<Web_Node> templist = new List<Web_Node>();
                templist.Add(node);
                Web_Node t1 = node;
                while (t1.CS > 3)
                {
                    t1 = nbll.GetModel(t1.PINDEX);
                    if (t1.PINDEX == 2)
                    {
                        //if (t1.NAME.Equals(ConfigurationManager.AppSettings["SiteName"]) || t1.NAME.Equals("系统管理") || t1.NAME.Equals("我的信息中心"))
                        //{
                        templist.Add(t1);
                        //}
                    }
                    else
                    {
                        templist.Add(t1);
                    }
                }
                TreeNode cnode = new TreeNode();
                cnode.Text = t1.NAME;
                cnode.NodeID = t1.INDEX_.ToString();
                cnode.EnableExpandEvent = true;
                bool tep = false;
                for (int i = pnodelist.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(pnodelist[i].NodeID) == t1.INDEX_)
                    {
                        pnode = pnodelist[i];
                        tep = true;
                        break;
                    }
                }
                if (!tep)
                {
                    //if (cnode.Text.Equals(ConfigurationManager.AppSettings["SiteName"]) || cnode.Text.Equals("系统管理") || cnode.Text.Equals("我的信息中心"))
                    //{
                    tview1.Nodes.Add(cnode);
                    pnodelist.Add(cnode);
                    pnode = cnode;

                    //}


                }

                for (int i = templist.Count - 2; i >= 0; i--)
                {
                    TreeNode testnode = new TreeNode();
                    testnode.Text = templist[i].NAME;
                    testnode.NodeID = templist[i].INDEX_.ToString();
                    cnode.EnableExpandEvent = true;
                    if (templist[i].BH != "")
                    {
                        testnode.NavigateUrl = templist[i].BH;
                        testnode.IconUrl = "~/images/filetype/vs_aspx.png";
                        testnode.EnableClickEvent= true;
                    }
                    //if (testnode.Text.Equals("生产监控") || testnode.Text.Equals("系统管理") || testnode.Text.Equals("我的信息中心"))
                    //{
                    pnode.Nodes.Add(testnode);
                    pnodelist.Add(testnode);
                    pnode = testnode;
                    //}
                }
            }
            else
            {
                TreeNode cnode = new TreeNode();
                cnode.Text = node.NAME;
                cnode.NodeID = node.INDEX_.ToString();
                cnode.EnableExpandEvent = true;
                if (node.BH != "")
                {
                    cnode.NavigateUrl = node.BH;
                    cnode.IconUrl = "~/images/filetype/vs_aspx.png";
                    cnode.EnableClickEvent= true;
                }
                //if (cnode.Text.Equals("生产监控") || cnode.Text.Equals("系统管理") || cnode.Text.Equals("我的信息中心"))
                //{
                pnode.Nodes.Add(cnode);
                pnodelist.Add(cnode);
                //}
            }
        }
        #endregion

        TreeNodeCollection tnc = tview1.Nodes;
        Web_NodeBll bll = new Web_NodeBll();

        UserBll userbll = new UserBll();

        User uu = userbll.GetModel(UserID);

        if (uu.NAME.ToUpper().Equals("ADMIN"))
        {
            for (int i = 0; i < tnc.Count; i++)
            {
                Web_Node wn = bll.GetModel(int.Parse(tnc[i].NodeID));

                if (wn.PINDEX == 2 && !wn.NAME.Equals("长距离特高压GIL可靠性分析"))
                {
                    AccordionPane pane = new AccordionPane();
                    pane.Title = wn.NAME;
                    pane.ID = wn.INDEX_.ToString();
                    Tree tree = new Tree();
                    tree.NodeCommand += tree_NodeCommand;
                    tree.Title = wn.NAME;
                    tree.ShowHeader = false;
                    tree.ShowBorder = false;

                    TreeNodeCollection tnc2 = tnc[i].Nodes;

                    foreach (TreeNode nn in tnc2)
                    {
                        if (nn.NavigateUrl.Equals(""))
                        {
                            nn.Icon = Icon.Folder;
                        }
                        else
                        {
                            nn.IconUrl = "~/images/filetype/vs_aspx.png";
                            nn.EnableClickEvent = true;
                        }
                        tree.Nodes.Add(nn);
                    }

                    pane.Items.Add(tree);
                    acc.Items.Add(pane);
                }
            }
        }
        else
        {
            for (int i = 0; i < tnc.Count; i++)
            {
                Web_Node wn = bll.GetModel(int.Parse(tnc[i].NodeID));

                if (wn.PINDEX == 2)
                {
                    AccordionPane pane = new AccordionPane();
                    pane.Title = wn.NAME;
                    pane.ID = wn.INDEX_.ToString();
                    Tree tree = new Tree();
                    tree.NodeCommand += tree_NodeCommand;
                    tree.Title = wn.NAME;
                    tree.ShowHeader = false;
                    tree.ShowBorder = false;

                    TreeNodeCollection tnc2 = tnc[i].Nodes;

                    foreach (TreeNode nn in tnc2)
                    {
                        if (nn.NavigateUrl.Equals(""))
                        {
                            nn.Icon = Icon.Folder;
                        }
                        else
                        {
                            nn.IconUrl = "~/images/filetype/vs_aspx.png";
                            nn.EnableClickEvent = true;
                        }
                        tree.Nodes.Add(nn);
                    }

                    pane.Items.Add(tree);
                    acc.Items.Add(pane);
                }
            }
        }
    }

}
