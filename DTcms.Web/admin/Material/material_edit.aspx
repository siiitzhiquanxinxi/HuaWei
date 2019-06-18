<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="material_edit.aspx.cs" Inherits="DTcms.Web.admin.Material.material_edit" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑刀具</title>
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
     <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "200", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });
        });
        
    </script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="material_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="material_list.aspx"><span>刀具列表</span></a>
  <i class="arrow"></i>
  <span>编辑刀具</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">刀具信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>刀具编号</dt>
    <dd><asp:TextBox ID="txtMaterialID" runat="server" CssClass="input normal"  sucmsg=" " Enabled="False"></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl> 
    <dl>
    <dt>条码生成前缀</dt>
    <dd><asp:TextBox ID="txtCode" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl> 
  <dl>
    <dt>刀具名称</dt>
    <dd><asp:TextBox ID="txtMaterialName" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>刀具分类</dt>
    <dd><asp:DropDownList id="ddlMaterialType" runat="server" ></asp:DropDownList> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>品牌</dt>
    <dd><asp:TextBox ID="txtBrand" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>规格</dt>
    <dd><asp:TextBox ID="txtSpec" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>长度</dt>
    <dd><asp:TextBox ID="txtDeep" runat="server" CssClass="input normal"></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
    <dl>
    <dt>直径</dt>
    <dd><asp:TextBox ID="txtHigh" runat="server" CssClass="input normal"></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
    <dl>
    <dt>单位</dt>
    <dd><asp:TextBox ID="txtUnit" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>供应商</dt>
    <dd><asp:TextBox ID="txtSupplier" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>最低库存量</dt>
    <dd><asp:TextBox ID="txtMinimum" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>新刀初始加工寿命</dt>
    <dd><asp:TextBox ID="txtTotalTime" runat="server" CssClass="input normal"></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
    <dl>
    <dt>备注</dt>
    <dd><asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" TextMode="MultiLine"></asp:TextBox></dd>
  </dl>
    <dl>
            <dt>图片：</dt>
            <dd>
            <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path"  
                        AutoPostBack="True"/>
            <div class="upload-box upload-img"></div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick"></asp:Timer>
                     <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 200px;" class="upload-path"/>
                </ContentTemplate>
                </asp:UpdatePanel>
           
            </dd>
        </dl>
    <dl>
    <dt>状态</dt>
    <dd>
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="state" Text="启用" Checked="True" /><asp:RadioButton ID="RadioButton2" runat="server" GroupName="state" Text="关闭" />
        </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
    <asp:Button ID="btnSet" runat="server" Text="加工材质参数设置" CssClass="btn" OnClick="btnSet_Click"  />
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
