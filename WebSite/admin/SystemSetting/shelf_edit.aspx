<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shelf_edit.aspx.cs" Inherits="DTcms.Web.admin.SystemSetting.shelf_edit" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑智能柜柜门</title>
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
  <span>编辑智能柜柜门</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">智能柜柜门信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">

  <dl>
    <dt>智能柜编号</dt>
    <dd><asp:Label ID="txtFK_CabinetNo" runat="server" Text="Label"></asp:Label><span class="Validform_checktip">*</span></dd>
  </dl> 
  <dl>
    <dt>柜门编号</dt>
    <dd><asp:TextBox ID="txtBoxNo" runat="server" CssClass="input normal"     sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>对应锁地址</dt>
    <dd><asp:TextBox ID="txtBoxAddr" runat="server" CssClass="input normal"   sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>长（深度）</dt>
    <dd><asp:TextBox ID="txtDeep" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
 <%--<dl>
    <dt>宽</dt>
    <dd><asp:TextBox ID="txtWide" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>--%>
  <dl>
    <dt>直径<%--（高）--%></dt>
    <dd><asp:TextBox ID="txtHigh" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>横向九宫格数量</dt>
    <dd><asp:TextBox ID="txtX" runat="server" CssClass="input normal"></asp:TextBox></dd>
    </dl>
    <dl>
    <dt>纵向九宫格数量</dt>
    <dd><asp:TextBox ID="txtY" runat="server" CssClass="input normal"></asp:TextBox></dd>
    </dl>
    <dl>
    <dt>柜子类型</dt>
    <dd><asp:DropDownList id="ddlType" runat="server" >
        <asp:ListItem Value="0">九宫格</asp:ListItem>
        <asp:ListItem Value="1">普通柜</asp:ListItem>
        </asp:DropDownList></dd>
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
                            柜门编号
                        </th>
                        <th align="left" >
                            对应锁地址
                        </th>
                        <th align="left">
                            长（深度）
                        </th>
                        <th align="left" >
                            直径
                        </th>
                        <th align="left" >
                            横向九宫格数量
                        </th>
                        <th align="left">
                            纵向九宫格数量
                        </th>
                        <th align="left">
                            柜子类型
                        </th>
                        <th >
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <%--<td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                    </td>--%>
                    <td>
               <%--         <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />--%>
                        <%# Eval("BoxNo")%>
                    </td>
                    <td>
                        <%# Eval("BoxAddr")%>
                    </td>
                    <td>
                        <%# Eval("Deep")%>
                    </td>
                    <td>
                        <%# Eval("High")%>
                    </td>
                    <td>
                        <%# Eval("X")%>
                    </td>
                    <td>
                        <%# Eval("Y")%>
                    </td>
                    <td>
                        <%# Eval("Type").ToString()=="0"?"九宫格":"普通柜" %>
                    </td>
                    <td align="center">
                        <%--<a href='meetingedit.aspx?id=<%#Eval("id") %>'>修改</a>--%>
                        <asp:LinkButton ID="lbtnEdit" runat="server" 
                             CommandArgument='<%#Eval("id") %>' OnClick="lbtnEdit_Click">修改</asp:LinkButton>
                        <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm('确认删除？')"
                             CommandArgument='<%#Eval("id") %>' OnClick="lbtnDel_Click">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</form>
</body>
</html>
