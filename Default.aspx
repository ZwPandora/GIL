<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Thesis.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>欢迎使用长距离特高压GIL可靠性分析平台</title>
    <link type="text/css" rel="stylesheet" href="~/res/css/default.css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/browserdetecter.js" type="text/javascript"></script>
    <script src="js/sysdetecter.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="RegionPanel1" />
    <ext:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <ext:Region ID="Region1" ShowBorder="false" ShowHeader="false" Position="Top" Layout="Fit"
                runat="server">
                <Content>
                    <div id="header">
                        <table>
                            <tr>
                                <td>
                                    <a href="#" title="长距离特高压GIL可靠性分析平台" class="logo">
                                        <img src="images/logo/logo2.gif" alt="" /></a>
                                </td>
                                <td>
                                    <a href="index.aspx" class="title" style="color: #fff;">
                                        <%=systemname%></a>
                                </td>
                                <td>
                                    <ext:Panel ID="Panel1" Width="1px" Height="1px" Hidden="true" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                                        Title="Panel"  EnableIFrame="true" IFrameUrl="webs/sysmanage/RefreshOnline.aspx">
                                        <Items>
                                        </Items>
                                    </ext:Panel>   
                                </td>
                            </tr>
                        </table>
                        <div class="themeroller">
                            <a href="webs/sysmanage/UserOperationHelp.aspx" target="_blank" style="color: #fff;">
                                操作手册</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="webs/sysmanage/VisionInfo.aspx"
                                    target="_blank" style="color: #fff;">版本历史</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="webs/sysmanage/BrowserInfo.aspx" style="color: #fff;" target="_blank">
                                浏览器检查</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="webs/sysmanage/Help.aspx"
                                    target="_blank" style="color: #fff;">关于我们</a> </a>
                        </div>
                    </div>
                </Content>
                <Items>
                    <ext:ContentPanel ShowBorder="false" CssClass="header" ShowHeader="false" ID="ContentPanel1"
                        runat="server">
                        <div class="title">
                            <a href="#" title="长距离特高压GIL可靠性分析平台" class="logo">
                                <img src="images/logo/logo2.gif" alt="" /></a> &nbsp;<a href="index.aspx" style="color: #fff;"><%=systemname%></a>
                        </div>
                        <div class="version">
                            <a href="webs/sysmanage/UserOperationHelp.aspx" target="_blank" style="color: #fff;">
                                操作手册</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="webs/sysmanage/VisionInfo.aspx"
                                    target="_blank" style="color: #fff;">版本历史</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="webs/sysmanage/BrowserInfo.aspx" target="_blank" style="color: #fff;">
                                浏览器检查</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="webs/sysmanage/Help.aspx"
                                    target="_blank" style="color: #fff;">关于我们</a>
                        </div>
                        <%-- <div class="ntes-nav">
        <div class="ntes-nav-main clearfix">
            <div class="logo">
                <img src="imgs/logo.png" /></div>
            <div class="c-fr f14px fB STYLE1">
               <span style=" font-size:xx-large"> 统计过程控制管理信息系统</span></div>
        </div>
    </div>--%>
                    </ext:ContentPanel>
                </Items>
            </ext:Region>
            <ext:Region ID="Region2" RegionSplit="true" Width="220px" ShowHeader="true" ShowBorder="true"
                Title="您好" EnableCollapse="true" Layout="Fit" Collapsed="false" RegionPosition="Left"
                runat="server" Icon="Outline">
            </ext:Region>
            <ext:Region ID="mainRegion" ShowHeader="false" Layout="Fit" ShowBorder="true" Position="Center"
                runat="server">
                <Items>
                    <ext:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="首页" Layout="Fit" Icon="House" runat="server" IFrameUrl="webs/FMEA/FaultCaseAnalysis.aspx" EnableIFrame=true>
                                <Toolbars>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:ToolbarFill runat="server">
                                            </ext:ToolbarFill>
                                            <ext:Button ID="ArrowInAndOutBtn" runat="server" Text="" Icon="ArrowOut" OnClick="ArrowInAndOut">
                                            </ext:Button>
                                            <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                            </ext:ToolbarSeparator>
                                            <ext:Button ID="Button3" runat="server" Text="返回主站" Icon="ArrowUndo" ToolTip="返回主站"
                                                OnClientClick="window.open('Reback.aspx', '_self');" EnablePostBack="false">
                                            </ext:Button>
                                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                            </ext:ToolbarSeparator>
                                            <ext:Button ID="Button1" runat="server" Icon="Delete" Text="注销" ToolTip="注销登录" OnClientClick="window.open('exit.aspx', '_self');"
                                                EnablePostBack="false">
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </Toolbars>
                                <Items>
                                    <%--<ext:ContentPanel ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                        CssClass="intro" runat="server">
                                        <p align="center">
                                            <span style="font-family: SimHei; font-size: 24px;"></span>&nbsp;
                                        </p>
                                        <p align="center">
                                            <br />
                                            <br />
                                            <span style="font-family: SimHei; font-size: 24px;">欢迎使用长距离特高压GIL可靠性分析平台(RAP_GIL)</span>
                                        </p>
                                        <hr style="filter: alpha(opacity=100,finishopacity=0,style=3)" width="800px" color="Gray"
                                            size="3" />
                                        <p align="center">
                                            <span style="font-family: SimHei; font-size: 24px;"></span>&nbsp;
                                        </p>
                                        <div style="margin-left: 50px">
                                            <br />
                                            <p>
                                                <span style="font-family: SimHei; font-size: 18px;">RAP_GIL围绕GIL设备的可靠性分析问题，面向长距离特高压GIL设备可靠性需求，综合利用各专业领域已有知识，从制造的角度形成可靠性设计分析基础理论和方法，建立自底向上的可靠性分析和自顶向下的可靠性配置体系，具有以下功能特点：</span>
                                            </p>
                                            <br />
                                            <ol>
                                                <li><span style="line-height: 2; font-family: FangSong_GB2312; font-size: 16px;">1、基于云服务的多源异构数据分析；</span>
                                                </li>
                                                <li><span style="line-height: 2; font-family: FangSong_GB2312; font-size: 16px;">2、多维度、多视图的动态精益看板；</span>
                                                </li>
                                                <li><span style="line-height: 2; font-family: FangSong_GB2312; font-size: 16px;">3、良好的数据一致性和安全性保证；</span>
                                                </li>
                                                <li><span style="line-height: 2; font-family: FangSong_GB2312; font-size: 16px;">4、灵活的多粒度授权管理；</span>
                                                </li>
                                                <li><span style="line-height: 2; font-family: FangSong_GB2312; font-size: 16px;">5、数据分析、特征提取、决策评估、状态预警全链条分析；</span>
                                                </li>
                                                <li><span style="line-height: 2; font-family: FangSong_GB2312; font-size: 16px;">6、友好的用户界面和良好的用户体验；</span>
                                                </li>
                                            </ol>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <hr style="filter: alpha(opacity=100,finishopacity=0,style=3);" width="800px" color="Gray" />
                                        <div style="text-align: center">
                                            系统最后更新日期：2017-07-25<br />-
                                            <br />
                                            </div>
                                        <div style="bottom: 0px; position: absolute; height: 70px; width: 400px; left: 30px">
                                            您当前的IP地址是：<span style="font-weight: bold"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></span><br />
                                            您当前的操作系统是：<span style="font-weight: bold"><script type="text/javascript">                                                                                          document.write(sysinfo());</script></span><br />
                                            您当前的浏览器是:<span style="font-weight: bold"><a href="javascript:openBrowserInfo();" target="_blank"><script
                                                type="text/javascript">                                                                                                                                                                 document.write($.browser.name + "-" + $.browser.engine + "-" + $.browser.version);</script></a></span>
                                        </div>
                                    </ext:ContentPanel>--%>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    <ext:Menu ID="menuSettings" runat="server">
        <ext:MenuButton ID="btnExpandAll" IconUrl="~/res/images/expand-all.gif" Text="展开菜单"
            EnablePostBack="false" runat="server">
        </ext:MenuButton>
        <ext:MenuButton ID="btnCollapseAll" IconUrl="~/res/images/collapse-all.gif" Text="折叠菜单"
            EnablePostBack="false" runat="server">
        </ext:MenuButton>
        <ext:MenuSeparator ID="MenuSeparator4" runat="server">
        </ext:MenuSeparator>
        <ext:MenuSeparator ID="MenuSeparator1" runat="server">
        </ext:MenuSeparator>
        <ext:MenuButton ID="MenuTheme" EnablePostBack="false" Text="主题" runat="server">
            <Menu ID="Menu4" runat="server">
                <ext:MenuCheckBox Text="Neptune" ID="MenuThemeNeptune" Checked="true" GroupName="MenuTheme"
                    runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="Blue" ID="MenuThemeBlue" GroupName="MenuTheme" runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="Gray" ID="MenuThemeGray" GroupName="MenuTheme" runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="Access" ID="MenuThemeAccess" GroupName="MenuTheme" runat="server">
                </ext:MenuCheckBox>
            </Menu>
        </ext:MenuButton>
        <ext:MenuButton EnablePostBack="false" Text="菜单样式" ID="MenuStyle" runat="server">
            <Menu ID="Menu1" runat="server">
                <ext:MenuCheckBox Text="树菜单" ID="MenuStyleTree" Checked="true" GroupName="MenuStyle"
                    runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="手风琴+树菜单" ID="MenuStyleAccordion" GroupName="MenuStyle" runat="server">
                </ext:MenuCheckBox>
            </Menu>
        </ext:MenuButton>
        <ext:MenuButton EnablePostBack="false" Text="语言" ID="MenuLang" runat="server">
            <Menu ID="Menu2" runat="server">
                <ext:MenuCheckBox Text="简体中文" ID="MenuLangZHCN" Checked="true" GroupName="MenuLang"
                    runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="繁體中文" ID="MenuLangZHTW" GroupName="MenuLang" runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="English" ID="MenuLangEN" GroupName="MenuLang" runat="server">
                </ext:MenuCheckBox>
            </Menu>
        </ext:MenuButton>
        
    </ext:Menu>
    <%-- <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/common/menu.xml"></asp:XmlDataSource>--%>
    </form>

    <script src="./res/js/jquery.min.js" type="text/javascript"></script>
    <script> 

        var btnExpandAllClientID = '<%= btnExpandAll.ClientID %>';
        var btnCollapseAllClientID = '<%= btnCollapseAll.ClientID %>';
        var leftPanelClientID = '<%= Region2.ClientID %>';
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var menuSettingsClientID = '<%= menuSettings.ClientID %>';

        var MenuStyleClientID = '<%= MenuStyle.ClientID %>';
        var MenuLangClientID = '<%= MenuLang.ClientID %>';
        var MenuThemeClientID = '<%= MenuTheme.ClientID %>';


        F.ready(function () {
            var btnExpandAll = F(btnExpandAllClientID);
            var btnCollapseAll = F(btnCollapseAllClientID);
            var leftPanel = F(leftPanelClientID);
            var mainTabStrip = F(mainTabStripClientID);

            var menuSettings = F(menuSettingsClientID);


            var MenuStyle = F(MenuStyleClientID);
            var MenuLang = F(MenuLangClientID);
            var MenuTheme = F(MenuThemeClientID);

            var mainMenu = leftPanel.items.getAt(0);
            var menuType = 'accordion';
            if (mainMenu.isXType('treepanel')) {
                menuType = 'menu';
            }

            // 当前展开的手风琴面板
            function getExpandedPanel() {
                var panel = null;
                mainMenu.items.each(function (item) {
                    if (!item.getCollapsed()) {
                        panel = item;
                    }
                });
                return panel;
            }

            // 点击展开菜单
            btnExpandAll.on('click', function () {
                if (menuType == 'menu') {
                    // 左侧为树控件
                    mainMenu.expandAll();
                } else {
                    // 左侧为树控件+手风琴控件
                    var expandedPanel = getExpandedPanel();
                    if (expandedPanel) {
                        expandedPanel.items.getAt(0).expandAll();
                    }
                }
            });

            // 点击折叠菜单
            btnCollapseAll.on('click', function () {
                if (menuType == 'menu') {
                    // 左侧为树控件
                    mainMenu.collapseAll();
                } else {
                    // 左侧为树控件+手风琴控件
                    var expandedPanel = getExpandedPanel();
                    if (expandedPanel) {
                        expandedPanel.items.getAt(0).collapseAll();
                    }
                }
            });



            // 点击菜单样式
            function MenuStyleItemCheckChange(cmp, checked) {
                if (checked) {
                    var menuStyle = 'accordion';
                    if (cmp.id.indexOf('MenuStyleTree') >= 0) {
                        menuStyle = 'tree';
                    }
                    F.cookie('MenuStyle_v4', menuStyle, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuStyle.menu.items.each(function (item, index) {
                item.on('checkchange', MenuStyleItemCheckChange);
            });


            // 切换语言
            function MenuLangItemCheckChange(cmp, checked) {
                if (checked) {
                    var lang = 'en';
                    if (cmp.id.indexOf('MenuLangZHCN') >= 0) {
                        lang = 'zh_CN';
                    } else if (cmp.id.indexOf('MenuLangZHTW') >= 0) {
                        lang = 'zh_TW';
                    }

                    F.cookie('Language_v4', lang, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuLang.menu.items.each(function (item, index) {
                item.on('checkchange', MenuLangItemCheckChange);
            });


            // 切换主题
            function MenuThemeItemCheckChange(cmp, checked) {
                if (checked) {
                    var lang = 'neptune';
                    if (cmp.id.indexOf('MenuThemeBlue') >= 0) {
                        lang = 'blue';
                    } else if (cmp.id.indexOf('MenuThemeGray') >= 0) {
                        lang = 'gray';
                    } else if (cmp.id.indexOf('MenuThemeAccess') >= 0) {
                        lang = 'access';
                    }

                    F.cookie('Theme_v4', lang, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuTheme.menu.items.each(function (item, index) {
                item.on('checkchange', MenuThemeItemCheckChange);
            });


            function createToolbar(tabConfig) {

                // 由工具栏上按钮获得当前标签页中的iframe节点
                function getCurrentIFrameNode(btn) {
                    return $('#' + btn.id).parents('.f-tab').find('iframe');
                }

                var loginoutButton = new Ext.Button({
                    text: '注销',
                    type: 'button',
                    icon: './res/icon/delete.png',
                    listeners: {
                        click: function () {
                            window.location.href = 'exit.aspx';
                            e.stopEvent();
                        }
                    }
                });

                var backButton = new Ext.Button({
                    text: '返回',
                    type: "button",
                    cls: "x-btn-text-icon",
                    icon: "./res.axd?icon=ArrowUndo",
                    listeners: {
                        click: function (button, e) {
                            window.location.href = 'javascript:history.go(-1)';
                            e.stopEvent();
                        }
                    }
                });

                var refreshButton = new Ext.Button({
                    text: '刷新',
                    type: 'button',
                    icon: './res/icon/reload.png',
                    listeners: {
                        click: function () {
                            var iframeNode = getCurrentIFrameNode(this);
                            iframeNode[0].contentWindow.location.reload();
                        }
                    }
                });

                var toolbar = new Ext.Toolbar({
                    items: ['->', backButton, '-', refreshButton, '-', loginoutButton]
                });

                tabConfig['tbar'] = toolbar;
            }



            // 此函数源代码定义在：extjs_builder\js\F\F.util.js
            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            F.initTreeTabStrip(mainMenu, mainTabStrip, createToolbar, true, false, false);



            // 添加示例标签页
            window.addExampleTab = function (id, url, text, icon, refreshWhenExist) {
                // 动态添加一个标签页
                // mainTabStrip： 选项卡实例
                // id： 选项卡ID
                // url: 选项卡IFrame地址 
                // text： 选项卡标题
                // icon： 选项卡图标
                // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
                // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
                F.util.addMainTab(mainTabStrip, id, url, text, icon, null, refreshWhenExist);
            };

           

            // 移除选中标签页
            window.removeActiveTab = function () {
                var activeTab = mainTabStrip.getActiveTab();
                mainTabStrip.removeTab(activeTab.id);
            };



            // 添加工具图标，并在点击时显示上下文菜单
            // 专业版提醒：请将 type:'gear' 改为 iconFont:'gear'
            leftPanel.addTool({
                type: 'gear',
                //tooltip: '系统设置',
                handler: function (event) {
                    menuSettings.showBy(this);
                }
            });

        });


    </script>

     <script type="text/javascript">

         var basePath = '<%= ResolveUrl("~/") %>';

         function openBrowserInfo() {
             parent.addExampleTab.apply(null, ['browserinfo', basePath + 'webs/sysmanage/BrowserInfo.aspx', '浏览器信息', basePath + 'res/images/filetype/vs_aspx.png', true]);
         }
    </script>
</body>
</html>
