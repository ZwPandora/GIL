<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Thesis.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>长距离特高压GIL可靠性分析平台</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <!--[if IE 6]>
<SCRIPT type=text/javascript src="js/DD_belatedPNG_0.0.8a.js"></SCRIPT>

<SCRIPT>
            DD_belatedPNG.fix('.logo,img');;
            DD_belatedPNG.fix('.login-main,background');
        </SCRIPT>
<![endif]-->

    <script type="text/javascript" language="javascript">
        javascript: window.history.forward(1);
        if (window != parent) {
            parent.location.href = location.href;
        }
        //onbeforeunload="history.go(0)"
    </script>

    <script type="text/javascript">
        window.onload = function () { var oInput = document.getElementById("tbUserName"); oInput.focus(); } 
    </script>

    <script type="text/javascript">
        function srcMarquee() {
            this.ID = document.getElementById(arguments[0]);
            if (!this.ID) { this.ID = -1; return; }
            this.Direction = this.Width = this.Height = this.DelayTime = this.WaitTime = this.Correct = this.CTL = this.StartID = this.Stop = this.MouseOver = 0;
            this.Step = 1;
            this.Timer = 30;
            this.DirectionArray = { "top": 0, "bottom": 1, "left": 2, "right": 3 };
            if (typeof arguments[1] == "number") this.Direction = arguments[1];
            if (typeof arguments[2] == "number") this.Step = arguments[2];
            if (typeof arguments[3] == "number") this.Width = arguments[3];
            if (typeof arguments[4] == "number") this.Height = arguments[4];
            if (typeof arguments[5] == "number") this.Timer = arguments[5];
            if (typeof arguments[6] == "number") this.DelayTime = arguments[6];
            if (typeof arguments[7] == "number") this.WaitTime = arguments[7];
            if (typeof arguments[8] == "number") this.ScrollStep = arguments[8]
            this.ID.style.overflow = this.ID.style.overflowX = this.ID.style.overflowY = "hidden";
            this.ID.noWrap = true;
            this.IsNotOpera = (navigator.userAgent.toLowerCase().indexOf("opera") == -1);
            if (arguments.length >= 7) this.Start();
        }
        srcMarquee.prototype.Start = function () {
            if (this.ID == -1) return;
            if (this.WaitTime < 800) this.WaitTime = 800;
            if (this.Timer < 20) this.Timer = 20;
            if (this.Width == 0) this.Width = parseInt(this.ID.style.width);
            if (this.Height == 0) this.Height = parseInt(this.ID.style.height);
            if (typeof this.Direction == "string") this.Direction = this.DirectionArray[this.Direction.toString().toLowerCase()];
            this.HalfWidth = Math.round(this.Width / 2);
            this.BakStep = this.Step;
            this.ID.style.width = this.Width;
            this.ID.style.height = this.Height;
            if (typeof this.ScrollStep != "number") this.ScrollStep = this.Direction > 1 ? this.Width : this.Height;
            var msobj = this;
            var timer = this.Timer;
            var delaytime = this.DelayTime;
            var waittime = this.WaitTime;
            msobj.StartID = function () { msobj.Scroll() }
            msobj.Continue = function () {
                if (msobj.MouseOver == 1) {
                    setTimeout(msobj.Continue, delaytime);
                }
                else {
                    clearInterval(msobj.TimerID);
                    msobj.CTL = msobj.Stop = 0;
                    msobj.TimerID = setInterval(msobj.StartID, timer);
                }
            }
            msobj.Pause = function () {
                msobj.Stop = 1;
                clearInterval(msobj.TimerID);
                setTimeout(msobj.Continue, delaytime);
            }
            msobj.Begin = function () {
                msobj.ClientScroll = msobj.Direction > 1 ? msobj.ID.scrollWidth : msobj.ID.scrollHeight;
                if ((msobj.Direction <= 1 && msobj.ClientScroll < msobj.Height) || (msobj.Direction > 1 && msobj.ClientScroll < msobj.Width)) return;
                msobj.ID.innerHTML += msobj.ID.innerHTML;
                msobj.TimerID = setInterval(msobj.StartID, timer);
                if (msobj.ScrollStep < 0) return;
                msobj.ID.onmousemove = function (event) {
                    if (msobj.ScrollStep == 0 && msobj.Direction > 1) {
                        var event = event || window.event;
                        if (window.event) {
                            if (msobj.IsNotOpera) { msobj.EventLeft = event.srcElement.id == msobj.ID.id ? event.offsetX - msobj.ID.scrollLeft : event.srcElement.offsetLeft - msobj.ID.scrollLeft + event.offsetX; }
                            else { msobj.ScrollStep = null; return; }
                        }
                        else { msobj.EventLeft = event.layerX - msobj.ID.scrollLeft; }
                        msobj.Direction = msobj.EventLeft > msobj.HalfWidth ? 3 : 2;
                        msobj.AbsCenter = Math.abs(msobj.HalfWidth - msobj.EventLeft);
                        msobj.Step = Math.round(msobj.AbsCenter * (msobj.BakStep * 2) / msobj.HalfWidth);
                    }
                }
                msobj.ID.onmouseover = function () {
                    if (msobj.ScrollStep == 0) return;
                    msobj.MouseOver = 1;
                    clearInterval(msobj.TimerID);
                }
                msobj.ID.onmouseout = function () {
                    if (msobj.ScrollStep == 0) {
                        if (msobj.Step == 0) msobj.Step = 1;
                        return;
                    }
                    msobj.MouseOver = 0;
                    if (msobj.Stop == 0) {
                        clearInterval(msobj.TimerID);
                        msobj.TimerID = setInterval(msobj.StartID, timer);
                    }
                }
            }
            setTimeout(msobj.Begin, waittime);
        }
        srcMarquee.prototype.Scroll = function () {
            switch (this.Direction) {
                case 0:
                    this.CTL += this.Step;
                    if (this.CTL >= this.ScrollStep && this.DelayTime > 0) {
                        this.ID.scrollTop += this.ScrollStep + this.Step - this.CTL;
                        this.Pause();
                        return;
                    }
                    else {
                        if (this.ID.scrollTop >= this.ClientScroll) { this.ID.scrollTop -= this.ClientScroll; }
                        this.ID.scrollTop += this.Step;
                    }
                    break;
                case 1:
                    this.CTL += this.Step;
                    if (this.CTL >= this.ScrollStep && this.DelayTime > 0) {
                        this.ID.scrollTop -= this.ScrollStep + this.Step - this.CTL;
                        this.Pause();
                        return;
                    }
                    else {
                        if (this.ID.scrollTop <= 0) { this.ID.scrollTop += this.ClientScroll; }
                        this.ID.scrollTop -= this.Step;
                    }
                    break;
                case 2:
                    this.CTL += this.Step;
                    if (this.CTL >= this.ScrollStep && this.DelayTime > 0) {
                        this.ID.scrollLeft += this.ScrollStep + this.Step - this.CTL;
                        this.Pause();
                        return;
                    }
                    else {
                        if (this.ID.scrollLeft >= this.ClientScroll) { this.ID.scrollLeft -= this.ClientScroll; }
                        this.ID.scrollLeft += this.Step;
                    }
                    break;
                case 3:
                    this.CTL += this.Step;
                    if (this.CTL >= this.ScrollStep && this.DelayTime > 0) {
                        this.ID.scrollLeft -= this.ScrollStep + this.Step - this.CTL;
                        this.Pause();
                        return;
                    }
                    else {
                        if (this.ID.scrollLeft <= 0) { this.ID.scrollLeft += this.ClientScroll; }
                        this.ID.scrollLeft -= this.Step;
                    }
                    break;
            }
        } 
    </script>

</head>
<body class="bg">
    <form id="form1" runat="server">
    <div class="ntes-nav">
        <div class="ntes-nav-main clearfix">
            <div class="logo">
                <img src="imgs/logo.png" alt="" /></div>
            <%--<div class="c-fr">
                <a href="#" title="设为首页" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage(location);">
                    设为首页</a>|<a href="<%=CompanyWebSite %>" target="_blank" title="公司网站">公司网站</a>|<a
                        href="<%=OASite %>" target="_blank" title="办公系统">办公系统</a>|<a href="<%=ServiceSite %>"
                            target="_blank" title="算法服务管理平台">算法平台</a>|<a href="webs/sysmanage/Help.aspx" target="_self"
                                title="关于我们">关于我们</a></div>--%>
        </div>
    </div>
    <div class="warp-index">
        <div class="login-main">
            <div class="ntes-loginframe clearfix">
                <div class="ntes-loginframe-blank">
                    <span class="f14px fB">用户名：</span><input name="" type="text" id="tbUserName" runat="server"
                        class="ntes-loginframe-label-username left" /></div>
                <div class="ntes-loginframe-blank">
                    <span class="f14px fB">密&nbsp;&nbsp;&nbsp;&nbsp;码：</span><input name="" id="tbPassword"
                        runat="server" type="password" class="ntes-loginframe-label-password left" /><asp:LinkButton
                            ID="LinkButton1" runat="server" CssClass="left" OnClick="PassWordRecovery">忘记密码</asp:LinkButton></div>
                <div class="ntes-loginframe-blank" style="margin-bottom: 0">
                    <asp:ImageButton ID="Button1" runat="server" CssClass="ntes-loginframe-btn" ImageUrl="~/imgs/ntes-login.png"
                        OnClick="Button1_Click" />
                    <asp:ImageButton ID="ImageButton2" CssClass="ntes-loginframe-btn" runat="server"
                        ImageUrl="~/imgs/ntes-reset.png" OnClick="resetcontent" />
                </div>
            </div>
            <div class="ntes-loginframe-qs">
                <span class="left fB">常见问题：</span>
                <div id="Scroll">
                    <div id="ScrollMe" style="overflow: hidden; height: 27px;">
                        <a href="webs/sysmanage/Help.aspx" target="_self">没有用户名怎么办？</a> <a href="webs/sysmanage/Help.aspx"
                            target="_self">为什么界面和别人的不一样？</a> <a href="webs/sysmanage/Help.aspx" target="_self">系统登录不正常怎么办？</a>
                        <a href="webs/sysmanage/Help.aspx" target="_self">数据显示不完整怎么办？</a>
                    </div>
                </div>

                <script type="text/javascript">                    new srcMarquee("ScrollMe", 0, 1, 360, 27, 30, 3000, 3000, 27)</script>

            </div>
        </div>
    </div>
    <div class="footer-warpp">
        <div class="footer">
            &copy; 2015-2020 西安交通大学 制造系统与质量工程研究所. All Rights Reserved.
        </div>
    </div>
    </form>
</body>
</html>
