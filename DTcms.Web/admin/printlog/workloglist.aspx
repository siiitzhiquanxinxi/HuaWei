<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workloglist.aspx.cs" Inherits="DTcms.Web.admin.printlog.workloglist" %>

<%@ OutputCache Duration="1" VaryByParam="none" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>系统日志</title>
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
            <span>系统日志</span>
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
                        <div>
                            &nbsp;&nbsp;日期：<asp:TextBox ID="txtDate1" runat="server" onfocus="WdatePicker({skin:'default',dateFmt:'yyyy-MM-dd'})" Width="100" CssClass="input"></asp:TextBox>&nbsp;-&nbsp;
                    <asp:TextBox ID="txtDate2" runat="server" onfocus="WdatePicker({skin:'default',dateFmt:'yyyy-MM-dd'})" Width="100" CssClass="input"></asp:TextBox>
                            &nbsp;&nbsp;设备编号：<asp:TextBox ID="txtMachineId" runat="server" Width="120" CssClass="input"></asp:TextBox>
                            &nbsp;&nbsp;SessionID：<asp:TextBox ID="txtSessionId" runat="server" Width="120" CssClass="input"></asp:TextBox>
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
                            <th align="left">SessionID
                            </th>
                            <th align="left">客户端类型
                            </th>
                            <th align="left">日志摘要
                            </th>
                            <th align="left">操作人
                            </th>
                            <th align="left">发生日期
                            </th>
                            <th align="left">设备编号
                            </th>
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
                            <%#Eval("SessionID")%>
                        </td>
                        <td>
                            <%#Eval("ClientType")%>
                        </td>
                        <td>
                            <%#Eval("Type")%>
                        </td>
                        <td>
                            <%#Eval("agentName")%>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("OpTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                        </td>
                        <td>
                            <%#Eval("MachineID")%>
                        </td>
                        <td align="center"><a href="worklogdetail.aspx?id='<%#Eval("Id") %>'">详细</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
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
