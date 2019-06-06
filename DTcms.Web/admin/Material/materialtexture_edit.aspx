<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="materialtexture_edit.aspx.cs" Inherits="DTcms.Web.admin.Material.materialtexture_edit" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>加工材质参数设置</title>
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
  <a href="material_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="material_list.aspx"><span>刀具列表</span></a>
  <i class="arrow"></i>
  <span>加工材质参数设置</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">加工材质参数</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">

  <dl>
    <dt>刀具编号</dt>
    <dd><asp:Label ID="txtMaterialID" runat="server" Text="Label"></asp:Label><span class="Validform_checktip">*</span></dd>
  </dl> 
  <dl>
    <dt>刀具名称</dt>
    <dd><asp:Label ID="txtMaterialName" runat="server" Text="Label"></asp:Label></dd>
  </dl>
  <dl>
    <dt>刀具规格</dt>
    <dd><asp:Label ID="txtSpec" runat="server" Text="Label"></asp:Label></dd>
  </dl>
  <dl>
    <dt>加工材质</dt>
    <dd><asp:DropDownList id="ddlTexture" runat="server" ></asp:DropDownList> <span class="Validform_checktip">*</span></dd>
  </dl>
    <dl>
    <dt>系数</dt>
    <dd><asp:TextBox ID="txtCoefficient" runat="server" CssClass="input normal"></asp:TextBox> <span class="Validform_checktip">*</span></dd>
    </dl>
    
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
      <asp:HiddenField ID="hidId" Value='' runat="server" />
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->
    <div class="table-container">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th align="left">
                            刀具编号
                        </th>
                        <th align="left" >
                            加工材质
                        </th>
                        <th align="left">
                            系数
                        </th>
                        <th >
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("MaterialID")%>
                    </td>
                    <td>
                        <%# Eval("Texture")%>
                    </td>
                    <td>
                        <%# Eval("Coefficient")%>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnEdit" runat="server" 
                             CommandArgument='<%#Eval("id") %>' OnClick="lbtnEdit_Click">修改</asp:LinkButton>
                        <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm('确认删除？')"
                             CommandArgument='<%#Eval("id") %>' OnClick="lbtnDel_Click">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</form>
</body>
</html>

