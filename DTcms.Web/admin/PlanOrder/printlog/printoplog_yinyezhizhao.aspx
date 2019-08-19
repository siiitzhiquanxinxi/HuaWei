<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printoplog_yinyezhizhao.aspx.cs" Inherits="DTcms.Web.admin.printlog.printoplog_yinyezhizhao" %>

<%@ OutputCache Duration="1" VaryByParam="none" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>营业执照操作日志</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script src="../../DatePicker/WdatePicker.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>营业执照打证日志</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlCounty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlArea" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlPoint" runat="server">
                                    <asp:ListItem>全部点位</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlBussinessType" runat="server">
                                    <asp:ListItem Value="-1">全部业务</asp:ListItem>
                                    <asp:ListItem Value="0">新办</asp:ListItem>
                                    <asp:ListItem Value="1">变更</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            &nbsp;&nbsp;日期：<asp:TextBox ID="txtDate1" runat="server" onfocus="WdatePicker({skin:'default',dateFmt:'yyyy-MM-dd'})" Width="100" CssClass="input"></asp:TextBox>&nbsp;-&nbsp;
                    <asp:TextBox ID="txtDate2" runat="server" onfocus="WdatePicker({skin:'default',dateFmt:'yyyy-MM-dd'})" Width="100" CssClass="input"></asp:TextBox>
                            &nbsp;&nbsp;企业名称：<asp:TextBox ID="txtCompanyName" runat="server" Width="120" CssClass="input"></asp:TextBox>
                            &nbsp;&nbsp;打印人：<asp:TextBox ID="txtPrinterName" runat="server" Width="120" CssClass="input"></asp:TextBox>
                        </div>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="lbtnSearch_Click">查询</asp:LinkButton>
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
                            <th width="8%">选择</th>
                            <th align="left">打印人姓名
                            </th>
                            <th align="left">打印人身份证
                            </th>
                            <th align="left">打印人类型
                            </th>
                            <th align="left">企业名称
                            </th>
                            <th align="left">企业法人
                            </th>
                            <th align="left">打印日期
                            </th>
                            <th align="left">业务类型
                            </th>
                            <th>正本</th>
                            <th>副本</th>
                            <th width="8%" align="center">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td>
                            <%#Eval("agentName")%>
                        </td>
                        <td>
                            <%#Eval("agentIdCardNum")%>
                        </td>
                        <td>
                            <%#Eval("PrinterType").ToString() == "0" ? "法定代表人" : Eval("PrinterType").ToString()=="1"?"经办人":""%>
                        </td>
                        <td>
                            <%#Eval("companyName")%>
                        </td>
                        <td>
                            <%#Eval("legalpersonName")%>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("CreateSessionDate")).ToString("yyyy-MM-dd HH:mm:ss")%>
                        </td>
                        <td>
                            <%#Eval("BussinessType").ToString() == "0" ? "新设立" : Eval("BussinessType").ToString() == "1" ? "变更" : ""%>
                        </td>
                        <td align="center">
                            <div class=<%#Eval("IsZhengbenSuccessed").ToString()=="1"?"Validform_right":"Validform_wrong" %> style="width: 20px; height: 20px; padding-left: 0px;"></div>
                        </td>
                        <td align="center">
                            <div class=<%#Eval("IsFubenSuccessed").ToString()=="1"?"Validform_right":"Validform_wrong" %> style="width: 20px; height: 20px; padding-left: 0px;"></div>
                        </td>
                        <td align="center"><a href="printlog_yinyezhizhao_detail.aspx?id=<%#Eval("Id") %>">详细</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="padding-top: 5px;">
            <asp:Label ID="lblTotalCount" runat="server" Text="" Visible="false" Style="color: #666;"></asp:Label>
        </div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="当前页:%CurrentPageIndex%/%PageCount% 共有%RecordCount%条记录 %PageCount%/页"
            FirstPageText="首页" HorizontalAlign="Center" InvalidPageIndexErrorMessage="页索引不是有效的数值！"
            LastPageText="末页" NextPageText="下一页" PageIndexOutOfRangeErrorMessage="页索引超出范围！"
            PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always"
            Width="100%" OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="5">
        </webdiyer:AspNetPager>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>

        <!--/内容底部-->

    </form>
</body>
</html>
