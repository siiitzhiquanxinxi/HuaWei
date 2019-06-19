<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="w_inout_detail.aspx.cs" Inherits="DTcms.Web.admin.Warehouse.w_inout_detail" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>刀具柜操作日志</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="w_inout_operate.aspx"><span>刀具柜操作日志</span></a>
  <i class="arrow"></i>
  <span>刀具柜操作日志</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
        </ul>
      </div>
      <div class="r-list">
        <%--<asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>--%>
      </div>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<div class="table-container">
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
      <%--<th width="8%">选择</th>--%>
      <th align="center" width="8%">操作编号</th>
      <th align="center" width="10%">计划单号</th>
      <th align="center" width="10%">零星领料申请单号</th>
        <th align="center" width="10%">刀具条码</th>
        <th align="center" width="10%">刀具名称</th>
        <th align="center" width="5%">出入库类型</th>
        <th align="center" width="5%">柜号</th>
        <th align="center" width="5%">抽屉号</th>
        <th align="center" width="5%">九宫号</th>
        <th align="center" width="8%">使用寿命</th>
        <th align="center" width="8%">操作人</th>
        <th align="center" width="8%">操作时间</th>
        <th align="center" width="5%">出库/入库</th>
      <th align="center" >备注</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center"><%# Eval("FK_BillID") %></td>
      <td align="center"><%# Eval("FK_SendBillNum") %></td>
      <td align="center"><%# Eval("FK_ApproveNum") %></td>
        <td align="center"><%# Eval("BarCode") %></td>
      <td align="center"><%# Eval("MaterialName") %></td>
      <td align="center"><%# Eval("InOutType") %></td>
        <td align="center"><%# Eval("FK_CabinetNo") %></td>
        <td align="center"><%# Eval("BoxNo") %></td>
        <td align="center"><%# Eval("XY") %></td>
        <td align="center"><%# Eval("WorkTime") %></td>
        <td align="center"><%# Eval("OperatorName") %></td>
        <td align="center"><%# Eval("OperatorTime") %></td>
        <td align="center"><%# Eval("IOFlag").ToString() == "1" ? "入库" : "出库" %></td>
        <td align="center"><%# Eval("InOutRemark") %></td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
</div>
<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
<!--/内容底部-->
</form>
</body>
</html>