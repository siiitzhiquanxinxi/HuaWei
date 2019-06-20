<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="barcode_edit.aspx.cs" Inherits="DTcms.Web.admin.Warehouse.barcode_edit" %>

<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>生成条码</title>
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
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        function ChooseMaterial() {
            $.dialog({ title: '选择刀具', width: '800px', heght: '600px',
                content: 'url:Warehouse/choosematerial.aspx?txtTarget=txtMaterialName&txtTarget1=txtMaterialType&txtTarget2=hdfMaterialTypeID&txtTarget3=txtBrand&txtTarget4=txtSpec&txtTarget5=txtDeep&txtTarget6=txtHigh&txtTarget7=txtUnit&txtTarget8=txtTotalTime&txtTarget9=txtCode&idTarget=txtMaterialID',
                lock: true
            });
        }
    </script>
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
  <a href="barcode_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="barcode_list.aspx"><span>条码列表</span></a>
  <i class="arrow"></i>
  <span>生成条码</span>
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
    <dd><asp:TextBox ID="txtMaterialID" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span>
        <input id="btnMaterial" type="button" value="..." style="width: 25px; cursor: pointer;"
            onclick="ChooseMaterial()" />
    </dd>
  </dl> 
    <dl>
    <dt>条码前缀</dt>
    <dd><asp:TextBox ID="txtCode" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>刀具名称</dt>
    <dd><asp:TextBox ID="txtMaterialName" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>刀具分类</dt>
    <dd><asp:TextBox ID="txtMaterialType" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
        <asp:HiddenField ID="hdfMaterialTypeID" runat="server" />
    </dd>
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
    <dd><asp:TextBox ID="txtDeep" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>直径</dt>
    <dd><asp:TextBox ID="txtHigh" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>单位</dt>
    <dd><asp:TextBox ID="txtUnit" runat="server" CssClass="input normal"></asp:TextBox>
    </dd>
  </dl>
    <dl>
    <dt>新刀使用寿命</dt>
    <dd><asp:TextBox ID="txtTotalTime" runat="server" CssClass="input normal"></asp:TextBox>
    </dd>
  </dl>
    <dl>
    <dt>总数量</dt>
    <dd><asp:TextBox ID="txtNum" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>最小包装数</dt>
    <dd><asp:TextBox ID="txtMinimum" runat="server" CssClass="input normal">1</asp:TextBox></dd>
  </dl>
    <dl>
    <dt>批号</dt>
    <dd><asp:TextBox ID="txtBatchNumber" runat="server" CssClass="input normal"></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
</div>
<!--/内容-->
    <div class="table-container">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th align="left">
                            刀具条码
                        </th>
                        <th align="left">
                            刀具编号
                        </th>
                        <th align="left" >
                            刀具名称
                        </th>
                        <th align="left">
                            批次
                        </th>
                        <th align="left">
                            数量
                        </th>
                        <th align="left">
                            柜号
                        </th>
                        <th align="left">
                            抽屉号
                        </th>
                        <%--<th >
                            操作
                        </th>--%>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("BarCode")%>
                    </td>
                    <td>
                        <%# Eval("MaterialID")%>
                    </td>
                    <td>
                        <%# Eval("MaterialName")%>
                    </td>
                    <td>
                        <%# Eval("BatchNumber")%>
                    </td>
                    <td>
                        <%# Eval("Num")%>
                    </td>
                    <td>
                        <%# Eval("FK_CabinetNo")%>
                    </td>
                    <td>
                        <%# Eval("BoxNo")%>
                    </td>
                    <%--<td align="center">
                        <asp:LinkButton ID="lbtnEdit" runat="server" 
                             CommandArgument='<%#Eval("BarCode") %>' OnClick="lbtnEdit_Click">修改</asp:LinkButton>
                        <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm('确认删除？')"
                             CommandArgument='<%#Eval("BarCode") %>' OnClick="lbtnDel_Click">删除</asp:LinkButton>
                    </td>--%>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSet" runat="server" Text="生成条码" CssClass="btn" OnClick="btnSet_Click"  />
    <asp:Button ID="btnSubmit" runat="server" Text="保存并导出" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
    
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
