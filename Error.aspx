<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Thesis.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server">
    </ext:PageManager>
    <br />
    <br />
    <br />
    <br />
    <div style="margin-top: 50px; text-align: center; vertical-align: bottom; border-style: dotted;
        border-width: 1px; border-color: Silver; width: 900px; margin-left: auto; margin-right: auto">
        <img src="../../images/error.jpg" alt="" />
        <p>
            <span style="font-size: large; font-weight: bold; color: Blue">您看到这个页面说明页面出错了，您可以返回或者联系管理员！<br/><br/><span style="font-size:small">该异常记录已被系统记录.</span></span></p>
        <div style="text-align: center">
            <br />
            <br />
            <ext:LinkButton ID="LinkButton1" runat="server" Label="" Text="点击查看详情" OnClick="ShowError">
            </ext:LinkButton>
            <br />
            <br />
        </div>
    </div>
    <ext:Window ID="Window1" runat="server" BodyPadding="5px" Height="350px" IsModal="true"
        Title="错误详情" Width="800px" AutoScroll="true" Hidden="true">
        <Items>
            <ext:ContentPanel ID="ContentPanel1" Title="ContentPanel" BodyPadding="5px" ShowHeader="false"
                ShowBorder="true" runat="server">
               <%--<%= Application["error"].ToString()%>--%>
            </ext:ContentPanel>
        </Items>
    </ext:Window>
    </form>
</body>
</html>
