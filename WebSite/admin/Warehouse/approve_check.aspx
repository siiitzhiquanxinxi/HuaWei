<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="approve_check.aspx.cs" Inherits="DTcms.Web.admin.Warehouse.approve_check" %>

<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>零星领料申请审核</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
 <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
 <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        function ChooseMaterial() {
            var MaterialName = document.getElementById("txtApplyToolName").value;
            var ApplyWorkTime = document.getElementById("txtApplyWorkTime").value;
            var ApplyToolLevel = document.getElementById("txtApplyToolLevel").value;
            var Texture = document.getElementById("txtTexture").value;
            $.dialog({ title: '选择刀具条码', width: '800px', heght: '600px',
                content: 'url:Warehouse/choosebarcode.aspx?txtTarget=txtApproveNewToolBarCode&ApplyWorkTime=' + ApplyWorkTime + '&ApplyToolLevel=' + ApplyToolLevel + '&Texture=' + Texture,
                lock: true
            });
        }
    </script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="approve_chek_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="approve_chek_list.aspx"><span>零星领料待审核列表</span></a>
  <i class="arrow"></i>
  <span>零星领料申请审核</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">申请单信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>申请单号</dt>
    <dd><asp:TextBox ID="txtApproveNum" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
      
  </dl> 
  <dl>
    <dt>提出申请时间</dt>
    <dd><asp:TextBox ID="txtCreateDate" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl> 
   <dl>
    <dt>申请人姓名</dt>
    <dd><asp:TextBox ID="txtCreateByName" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox>
        <asp:HiddenField ID="hfdCreateById" runat="server" />
    </dd>
  </dl>
    <dl>
    <dt>零件号(计划内零星领料)</dt>
    <dd><asp:TextBox ID="txtApplyPartNum" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>加工零件材质</dt>
    <dd><asp:TextBox ID="txtTexture" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>申请的刀具名称</dt>
    <dd><asp:TextBox ID="txtApplyToolName" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl> 
    <dl>
    <dt>申请刀具的加工时间</dt>
    <dd><asp:TextBox ID="txtApplyWorkTime" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl> 
     <dl>
    <dt>申请刀具的等级</dt>
    <dd><asp:TextBox ID="txtApplyToolLevel" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl> 
    <dl>
    <dt>原分配刀具条码<br />(计划领料)</dt>
    <dd><asp:TextBox ID="txtApplyOldToolBarCode" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl> 
   <dl>
    <dt>申请备注</dt>
    <dd><asp:TextBox ID="txtApplyRemark" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>新分配条码</dt>
    <dd><asp:TextBox ID="txtApproveNewToolBarCode" runat="server" CssClass="input normal" ></asp:TextBox>
        <input id="btnMaterial" type="button" value="..." style="width: 25px; cursor: pointer;"
            onclick="ChooseMaterial()" />
    </dd>
    </dl>
     <dl>
    <dt>审核意见</dt>
    <dd><asp:TextBox ID="txtApproveRemark" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl>
  
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnYes" runat="server" Text="审核通过" CssClass="btn green" onclick="btnYes_Click" />
    <asp:Button ID="btnNo" runat="server" Text="审核不通过" CssClass="btn violet" onclick="btnNo_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>

