using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using FineUI;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Data;
using thesis.model;
using thesis.bll;
using System.Configuration;
using thesis.common;
using System.Web.Security;
namespace Thesis
{
    public partial class Default : PageBase
    {
        #region Page_Init
        public string systemname = "";
        public string weblist = "";

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["UserName2"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                string username = Session["UserName2"] as String;
                string menuType = "accordion";
                HttpCookie menuCookie = Request.Cookies["MenuStyle"];
                HttpCookie ThemeCookie = Request.Cookies["Theme"];

                if (ThemeCookie != null)
                {
                    switch (ThemeCookie.Value)
                    {
                        case "blue":
                            PageManager.Instance.Theme = FineUI.Theme.Neptune;
                            break;
                        case "gray":
                            PageManager.Instance.Theme = FineUI.Theme.Gray;
                            break;
                        case "access":
                            PageManager.Instance.Theme = FineUI.Theme.Access;
                            break;
                    }
                }
                else
                {
                    PageManager.Instance.Theme = FineUI.Theme.Blue;
                }

                if (menuCookie != null)
                {
                    menuType = menuCookie.Value;
                }
                else
                {
                    SaveToCookieAndRefresh("MenuStyle", menuType);
                }

                // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
                JObject ids = GetClientIDS(btnExpandAll, btnCollapseAll, mainTabStrip);

                if (menuType == "accordion")
                {
                    Accordion accordionMenu = InitAccordionMenu();
                    ids.Add("mainMenu", accordionMenu.ClientID);
                    ids.Add("menuType", "accordion");

                    //Tree treeMenu = InitTreeMenu();
                    //ids.Add("mainMenu", treeMenu.ClientID);
                    //ids.Add("menuType", "menu");
                }
                else
                {
                    Tree treeMenu = InitTreeMenu();
                    ids.Add("mainMenu", treeMenu.ClientID);
                    ids.Add("menuType", "menu");
                }

                // 只在页面第一次加载时注册客户端用到的脚本
                if (!Page.IsPostBack)
                {
                    string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
                    PageContext.RegisterStartupScript(idsScriptStr);
                }
                this.Region2.Title = username.ToLower() + ",您好！";
            }
        }

        private Accordion InitAccordionMenu()
        {
            int UserID = int.Parse(Session["UserID"].ToString());

            Accordion accordionMenu = new Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = false;
            accordionMenu.ShowHeader = false;
            Region2.Items.Add(accordionMenu);

            int user_id = int.Parse(Session["UserID"].ToString());

            Web_Node node1 = new Web_Node();
            node1.NAME = "Web";
            node1.INDEX_ = 2;
            node1.PINDEX = 1;
            node1.SPECIES = 8;
            node1.SPECIES_ID = 1;
            node1.CS = 1;
            FineUI.TreeNode tnode = new FineUI.TreeNode();
            tnode.Text = node1.NAME;
            tnode.NodeID = node1.INDEX_.ToString();
            tnode.NavigateUrl = "javascript:void(0)";

            TreeHelper_Web.BuildUserWebTree(user_id, tnode, accordionMenu);
            return accordionMenu;
        }

        private Tree InitTreeMenu()
        {
            Tree treeMenu = new Tree();
            treeMenu.ID = "treeMenu";
            treeMenu.EnableArrows = true;
            treeMenu.ShowBorder = false;
            treeMenu.ShowHeader = false;
            treeMenu.EnableIcons = false;
            treeMenu.AutoScroll = true;
            Region2.Items.Add(treeMenu);

            int user_id = int.Parse(Session["UserID"].ToString());

            Web_Node node1 = new Web_Node();
            node1.NAME = "Web";
            node1.INDEX_ = 2;
            node1.PINDEX = 1;
            node1.SPECIES = 8;
            node1.SPECIES_ID = 1;
            node1.CS = 1;
            FineUI.TreeNode tnode = new FineUI.TreeNode();
            tnode.Text = node1.NAME;
            tnode.NodeID = node1.INDEX_.ToString();
            tnode.NavigateUrl = "javascript:void(0)";
            TreeHelper_Web.BuildUserWebTree(user_id, tnode, treeMenu);

            return treeMenu;
        }


        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }

            return jo;
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            systemname = ConfigurationManager.AppSettings["SystemName"];
            weblist = ConfigurationManager.AppSettings["SubSiteList"];
            if (!IsPostBack)
            {
                InitMenuStyleButton();
                InitLangMenuButton();
                InitThemeMenuButton();

                ArrowStyle();

                //this.Label1.Text = ClientIPAddress.getIPAddress();

                string LimitOnline = StringEncodeAndDecode.Decode(ConfigurationManager.AppSettings["LimitOnline"]);
                //if (!LimitOnline.ToUpper().Equals("XJTUCIMSSPC"))
                //{
                //    this.Panel1.IFrameUrl = "webs/sysmanage/RefreshOnline.aspx";
                //}
            }
        }

        public void ArrowStyle()
        {
            string BannerSwitch = ConfigurationManager.AppSettings["BannerSwitch"];

            if (BannerSwitch.Equals("0"))
            {
                this.Region1.Collapsed = false;
                this.Region2.Collapsed = false;
            }

            if (BannerSwitch.Equals("1"))
            {
                this.Region1.Collapsed = true;
                this.Region2.Collapsed = false;
            }

            if (BannerSwitch.Equals("2"))
            {
                this.Region1.Collapsed = false;
                this.Region2.Collapsed = true;
            }

            if (BannerSwitch.Equals("3"))
            {
                this.Region1.Collapsed = true;
                this.Region2.Collapsed = true;
            }
        }


        private void InitMenuStyleButton()
        {
            string menuStyleID = "MenuStyleTree";

            HttpCookie menuStyleCookie = Request.Cookies["MenuStyle"];
            if (menuStyleCookie != null)
            {
                switch (menuStyleCookie.Value)
                {
                    case "menu":
                        menuStyleID = "MenuStyleTree";
                        break;
                    case "accordion":
                        menuStyleID = "MenuStyleAccordion";
                        break;
                }
            }


            SetSelectedMenuID(MenuStyle, menuStyleID);
        }


        private void InitLangMenuButton()
        {
            string langMenuID = "MenuLangZHCN";

            string langValue = PageManager1.Language.ToString().ToLower();
            switch (langValue)
            {
                case "zh_cn":
                    langMenuID = "MenuLangZHCN";
                    break;
                case "zh_tw":
                    langMenuID = "MenuLangZHTW";
                    break;
                case "en":
                    langMenuID = "MenuLangEN";
                    break;
            }


            SetSelectedMenuID(MenuLang, langMenuID);
        }

        private void InitThemeMenuButton()
        {
            string themeMenuID = "MenuThemeBlue";

            string customThemeValue = PageManager1.CustomTheme.ToString().ToLower();

            if (!String.IsNullOrEmpty(customThemeValue))
            {
                switch (customThemeValue)
                {
                    case "blueen":
                        themeMenuID = "MenuThemeBlueen";
                        break;
                    case "first":
                        themeMenuID = "MenuThemeFirst";
                        break;
                    case "second":
                        themeMenuID = "MenuThemeSecond";
                        break;
                    case "fourth":
                        themeMenuID = "MenuThemeFourth";
                        break;
                }
            }
            else
            {
                string themeValue = PageManager1.Theme.ToString().ToLower();
                switch (themeValue)
                {
                    case "blue":
                        themeMenuID = "MenuThemeBlue";
                        break;
                    case "gray":
                        themeMenuID = "MenuThemeGray";
                        break;
                    case "access":
                        themeMenuID = "MenuThemeAccess";
                        break;
                }
            }


            SetSelectedMenuID(MenuTheme, themeMenuID);
        }

        #endregion

        #region Event

        protected void MenuLang_CheckedChanged(object sender, EventArgs e)
        {
            MenuCheckBox menuCheckBox = sender as MenuCheckBox;
            if (!menuCheckBox.Checked)
            {
                // CheckedChanged会触发两次，一次是取消选中的菜单项，另一次是选中的菜单项；
                // 这里不处理取消选中的菜单项的事件，从而防止此函数重复执行两次
                return;
            }

            string langValue = "zh_cn";
            string langID = GetSelectedMenuID(MenuLang);

            switch (langID)
            {
                case "MenuLangZHCN":
                    langValue = "zh_cn";
                    break;
                case "MenuLangZHTW":
                    langValue = "zh_tw";
                    break;
                case "MenuLangEN":
                    langValue = "en";
                    break;
            }

            SaveToCookieAndRefresh("Language", langValue);
        }

        protected void MenuTheme_CheckedChanged(object sender, EventArgs e)
        {
            MenuCheckBox menuCheckBox = sender as MenuCheckBox;
            if (!menuCheckBox.Checked)
            {
                // CheckedChanged会触发两次，一次是取消选中的菜单项，另一次是选中的菜单项；
                // 这里不处理取消选中的菜单项的事件，从而防止此函数重复执行两次
                return;
            }

            string themeValue = "Blue";
            string themeID = GetSelectedMenuID(MenuTheme);

            switch (themeID)
            {
                case "MenuThemeBlue":
                    themeValue = "blue";

                    break;
                case "MenuThemeGray":
                    themeValue = "gray";

                    break;
                case "MenuThemeAccess":
                    themeValue = "access";

                    break;
            }

            SaveToCookieAndRefresh("Theme", themeValue);
        }

        protected void MenuStyle_CheckedChanged(object sender, EventArgs e)
        {
            MenuCheckBox menuCheckBox = sender as MenuCheckBox;
            if (!menuCheckBox.Checked)
            {
                // CheckedChanged会触发两次，一次是取消选中的菜单项，另一次是选中的菜单项；
                // 这里不处理取消选中的菜单项的事件，从而防止此函数重复执行两次
                return;
            }

            string menuValue = "menu";
            string menuStyleID = GetSelectedMenuID(MenuStyle);

            switch (menuStyleID)
            {
                case "MenuStyleTree":
                    menuValue = "tree";
                    break;
                case "MenuStyleAccordion":
                    menuValue = "accordion";
                    break;

            }
            SaveToCookieAndRefresh("MenuStyle", menuValue);
        }

        private string GetSelectedMenuID(MenuButton menuButton)
        {
            foreach (MenuItem item in menuButton.Menu.Items)
            {
                if (item is MenuCheckBox && (item as MenuCheckBox).Checked)
                {
                    return item.ID;
                }
            }
            return null;
        }

        private void SetSelectedMenuID(MenuButton menuButton, string selectedMenuID)
        {
            foreach (MenuItem item in menuButton.Menu.Items)
            {
                MenuCheckBox menu = (item as MenuCheckBox);
                if (menu != null && menu.ID == selectedMenuID)
                {
                    menu.Checked = true;
                }
                else
                {
                    menu.Checked = false;
                }
            }
        }


        private void SaveToCookieAndRefresh(string cookieName, string cookieValue)
        {
            HttpCookie cookie = new HttpCookie(cookieName, cookieValue);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);

            PageContext.Refresh();
        }

        public void ArrowInAndOut(object sender, EventArgs e)
        {
            FineUI.Button btn = (FineUI.Button)sender;
            if (btn.Icon.ToString().Equals("ArrowOut"))//最大化
            {
                this.Region1.Collapsed = true;
                this.Region2.Collapsed = true;

                btn.ToolTip = "默认窗口大小";
                btn.Icon = Icon.ArrowIn;
            }
            else
            {
                this.Region1.Collapsed = false;
                this.Region2.Collapsed = false;

                btn.ToolTip = "最大化窗口";
                btn.Icon = Icon.ArrowOut;
            }
        }


        ///// <summary>
        ///// 修改样式
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    HttpCookie themeCookie = new HttpCookie("Theme", ddlTheme.SelectedValue);
        //    themeCookie.Expires = DateTime.Now.AddYears(1);
        //    Response.Cookies.Add(themeCookie);

        //    PageContext.Refresh();
        //}

        ///// <summary>
        ///// 修改语言
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    HttpCookie langCookie = new HttpCookie("Language", ddlLanguage.SelectedValue);
        //    langCookie.Expires = DateTime.Now.AddYears(1);
        //    Response.Cookies.Add(langCookie);

        //    PageContext.Refresh();
        //}


        ///// <summary>
        ///// 修改菜单类型
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    HttpCookie langCookie = new HttpCookie("Menu", ddlMenu.SelectedValue);
        //    langCookie.Expires = DateTime.Now.AddYears(1);
        //    Response.Cookies.Add(langCookie);

        //    PageContext.Refresh();
        //}


        #endregion

        #region Tree

        /// <summary>
        /// 重新设置每个节点的图标
        /// </summary>
        /// <param name="nodes"></param>
        private void ResolveTreeNode(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    if (!String.IsNullOrEmpty(node.NavigateUrl))
                    {
                        node.IconUrl = GetIconForTreeNode(node.NavigateUrl);
                    }
                    else
                    {
                        node.IconUrl = "~/images/filetype/vs_txt.png";
                    }
                }
            }
        }

        /// <summary>
        /// 根据链接地址返回相应的图标
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetIconForTreeNode(string url)
        {
            string iconUrl = "~/images/filetype/vs_unknow.png";
            url = url.ToLower();
            int lastDotIndex = url.LastIndexOf('.');
            string fileType = url.Substring(lastDotIndex + 1);
            if (fileType == "txt")
            {
                iconUrl = "~/images/filetype/vs_txt.png";
            }
            else if (fileType == "aspx")
            {
                iconUrl = "~/images/filetype/vs_aspx.png";
            }
            else if (fileType == "htm" || fileType == "html")
            {
                iconUrl = "~/images/filetype/vs_htm.png";
            }

            return iconUrl;
        }

        #endregion

        public void reback(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["SubSiteList"]);
        }

    }
}