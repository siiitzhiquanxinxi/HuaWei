<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cabinet_edit.aspx.cs" Inherits="DTcms.Web.admin.SystemSetting.cabinet_edit" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑智能柜</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="cabinet_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="cabinet_list.aspx"><span>智能柜列表</span></a>
  <i class="arrow"></i>
  <span>编辑智能柜</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">智能柜信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">

  <dl>
    <dt>智能柜编号</dt>
    <dd><asp:TextBox ID="txtCabinetNo" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*不可修改</span></dd>
  </dl> 
  <dl>
    <dt>对应控制端IP</dt>
    <dd><asp:TextBox ID="txtIP" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>对应控制端端口</dt>
    <dd><asp:TextBox ID="txtPort" runat="server" CssClass="input normal" recheck="txtPassword"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>板卡地址</dt>
    <dd><asp:TextBox ID="txtCardAddr" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>所在位置</dt>
    <dd><asp:TextBox ID="txtLocation" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
  <dl>
    <dt>所属管理员</dt>
    <dd><asp:DropDownList id="ddlManager" runat="server"  OnSelectedIndexChanged="ddlManager_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></dd>
  </dl>
    <dl>
    <dt>电话</dt>
    <dd><asp:TextBox ID="txtPhone" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
   <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
    <asp:Button ID="btnShelf" runat="server" Text="智能柜柜门设置" CssClass="btn" OnClick="btnShelf_Click"  />
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>

