<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printweekrpt_yinyezhizhao.aspx.cs" Inherits="DTcms.Web.admin.printlog.printweekrpt_yinyezhizhao" %>

<%@ OutputCache Duration="1" VaryByParam="none" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>周报统计</title>
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
                            &nbsp;&nbsp;<asp:Button ID="btnLastWeek" runat="server" Text="向上一个星期" CssClass="btn green" OnClick="btnLastWeek_Click" />
                        </div>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSelect_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <table class="ltable" id="top" style="margin-top: 10px">
                <tr>
                    <td style="width: 400px;">&nbsp;
                    </td>
                    <td>周一
                    </td>
                    <td>周二
                    </td>
                    <td>周三
                    </td>
                    <td>周四
                    </td>
                    <td>周五
                    </td>
                    <td>周六
                    </td>
                    <td>周日
                    </td>
                    <td>合计
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 20px;">工作时间（9：00至17：00）
                    </td>
                    <td>
                        <asp:Label ID="lblWork1" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWork2" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWork3" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWork4" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWork5" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWork6" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWork7" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWorkSum" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 20px;">非工作时间（00：00至9：00，17：00至24：00）
                    </td>
                    <td>
                        <asp:Label ID="lblUnwork1" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUnwork2" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUnwork3" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUnwork4" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUnwork5" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUnwork6" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUnwork7" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUnworkSum" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 20px;">合计
                    </td>
                    <td>
                        <asp:Label ID="lblSum1" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSum2" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSum3" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSum4" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSum5" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSum6" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSum7" runat="server" Text="0"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSumTotal" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="9" style="padding-left: 20px; font-size: 14px;">本周合计打证：<asp:Label ID="lblWeekTotal" runat="server" Text="0"></asp:Label><br />
                        本周非工作时间打证：<asp:Label ID="lblWeekUnworkTotal" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>

        <!--/内容底部-->

    </form>
</body>
</html>
