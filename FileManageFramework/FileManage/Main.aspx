<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="FileManageFramework.FileManage.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文件管理框架</title>
</head>
<frameset cols="265, *">
    <frame name="menu" src="Left.aspx" frameBorder="0" noResize>
    <frame name="center" src="Center.aspx" frameBorder="0" noResize scrolling="yes">
</frameset>
<noframes>
     <p align="center"><font color="#FF0000">此浏览器不支持框架显示！请更换其它浏览器。</font></p>
</noframes>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
    </form>
</body>
</html>
