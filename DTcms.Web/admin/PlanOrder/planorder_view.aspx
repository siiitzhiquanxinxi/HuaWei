<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="planorder_view.aspx.cs" Inherits="DTcms.Web.admin.PlanOrder.planorder_view" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>排产零件计划用刀明细</title>
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
   
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="planorder.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="planorder.aspx"><span>排产计划查询列表</span></a>
  <i class="arrow"></i>
  <span>排产零件计划用刀明细</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">刀具明细信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>零件号</dt>
    <dd><asp:TextBox ID="txtPartNum" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
      
  </dl> 
  <dl>
    <dt>零件名称</dt>
    <dd><asp:TextBox ID="txtPartName" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl> 
   <dl>
    <dt>材质</dt>
    <dd><asp:TextBox ID="txtMaterialTexture" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox>
    </dd>
  </dl>
    <dl>
    <dt>计划开工时间</dt>
    <dd><asp:TextBox ID="txtPlanWorkTime" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>备刀时间延期至</dt>
    <dd><asp:TextBox ID="txtDelayWorkTime" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>机台</dt>
    <dd><asp:TextBox ID="txtMachineLathe" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl> 
    <dl>
    <dt>创建日期</dt>
    <dd><asp:TextBox ID="txtCreateDate" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox></dd>
  </dl> 
     <dl>
  <dl>
    <dt>备刀状态</dt>
    <dd><asp:Label ID="txtOrderReadyState" runat="server" Text="Label"></asp:Label></dd>
      
  </dl>
</div>
<!--/内容-->
    <div class="table-container">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th align="left">
                            刀具名称
                        </th>
                        <th align="left" >
                            加工时间
                        </th>
                        <th align="left">
                            刀具等级
                        </th>
                        <th align="left">
                            所备刀条码
                        </th>
                        <th align="left">
                            刀具直径
                        </th>
                        <th align="left">
                            刀柄
                        </th>
                        <th align="left">
                            装刀长
                        </th>
                        <th align="left">
                            备注
                        </th>
                        <th align="left">
                            备刀状态
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("ToolName")%>
                    </td>
                    <td>
                        <%# Eval("WorkTime")%>
                    </td>
                    <td>
                        <%# Eval("ToolLevel")%>
                    </td>
                    <td>
                        <%# Eval("ToolBarCode")%>
                    </td>
                    <td>
                        <%# Eval("ToolDiam")%>
                    </td>
                    <td>
                        <%# Eval("ToolHandle")%>
                    </td>
                    <td>
                        <%# Eval("ToolLong")%>
                    </td>
                    <td>
                        <%# Eval("Remark")%>
                    </td>
                    <td>
                        <%# Eval("ToolReadyState").ToString()=="0"?"待备刀" : Eval("ToolReadyState").ToString()=="1"?"备刀中" : Eval("ToolReadyState").ToString()=="2"?"已完成": "异常" %>
                    </td>
                   <%-- <td align="center">
                        <asp:LinkButton ID="lbtnEdit" runat="server" 
                             CommandArgument='<%#Eval("id") %>' OnClick="lbtnEdit_Click">修改</asp:LinkButton>
                        <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm('确认删除？')"
                             CommandArgument='<%#Eval("id") %>' OnClick="lbtnDel_Click">删除</asp:LinkButton>
                    </td>--%>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>

