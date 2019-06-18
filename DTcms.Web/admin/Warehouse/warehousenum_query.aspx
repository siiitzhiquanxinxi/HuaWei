<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="warehousenum_query.aspx.cs" Inherits="DTcms.Web.admin.Warehouse.warehousenum_query" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>仓库量查询</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //图片延迟加载
            $(".pic img").lazyload({ effect: "fadeIn" });
            //点击图片链接
            $(".pic img").click(function () {
                var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
                if (linkUrl != "") {
                    location.href = linkUrl; //跳转到修改页面
                }
            });
        });
    </script>
    <style type="text/css">
        .textarea {
            width: 99%;
            min-height: 20px;
            _height: 120px;
            margin-left: auto;
            margin-right: auto;
            padding: 3px;
            outline: 0;
            border: 1px solid #a0b3d6;
            font-size: 12px;
            line-height: 24px;
            padding: 2px;
            word-wrap: break-word;
            overflow-x: hidden;
            overflow-y: auto;
            border: none;
            BORDER-BOTTOM: 0px solid;
            BORDER-LEFT: 0px solid;
            BORDER-RIGHT: 0px solid;
            BORDER-TOP: 0px solid;
        }
    </style>
    <script type="text/javascript">
        var observe;
        if (window.attachEvent) {
            observe = function (element, event, handler) {
                element.attachEvent('on' + event, handler);
            };
        }
        else {
            observe = function (element, event, handler) {
                element.addEventListener(event, handler, false);
            };
        }
        function init() {
            var text = document.getElementById('text');
            function resize() {
                text.style.width = '350px';
                text.style.height = 'auto';
                var vHeight = text.scrollHeight + 2;
                text.style.height = vHeight + 'px';
                text.readOnly = true;

            }
            /* 0-timeout to get the already changed text */
            function delayedResize() {
                window.setTimeout(resize, 0);
            }
            observe(text, 'change', resize);
            observe(text, 'cut', delayedResize);
            observe(text, 'paste', delayedResize);
            observe(text, 'drop', delayedResize);
            observe(text, 'keydown', delayedResize);

            text.focus();
            text.select();
            resize();
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>仓库量查询</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <%--<li><a class="add" href='MaterialEdit.aspx?action=Add'><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                            <li>--%>

                        </ul>
                    </div>
                    <div style="margin:0 0px">
                        
                        <asp:Label ID="Label1" runat="server" Text="刀具编号" style="padding-right:10px;padding-left:10px;vertical-align:middle;"></asp:Label>
                        <asp:TextBox ID="txtMaterialID" runat="server"  />
                        <asp:Label ID="Label2" runat="server" Text="刀具名称" style="padding-right:10px;padding-left:10px;vertical-align:middle;"></asp:Label>
                        <asp:TextBox ID="txtMaterialName" runat="server"  />
                        <asp:Label ID="Label3" runat="server" Text="所在柜子" style="padding-right:10px;padding-left:10px;vertical-align:middle;"></asp:Label>
                        <asp:TextBox ID="txtCabinetNo" runat="server"  />
                        <asp:Label ID="Label4" runat="server" Text="所在抽屉" style="padding-right:10px;padding-left:10px;vertical-align:middle;"></asp:Label>
                        <asp:TextBox ID="txtBoxNo" runat="server"  />
                        <asp:Label ID="Label5" runat="server" Text="刀具等级" style="padding-right:10px;padding-left:10px;vertical-align:middle;"></asp:Label>
                        <asp:DropDownList ID="ddlToolLevel" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="X">新刀</asp:ListItem>
                            <asp:ListItem Value="N">旧刀</asp:ListItem>
                            <asp:ListItem Value="R">返磨</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label6" runat="server" Text="状态" style="padding-right:10px;padding-left:10px;"></asp:Label>
                        <asp:DropDownList ID="ddlState" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="0">待入库</asp:ListItem>
                            <asp:ListItem Value="1">在库</asp:ListItem>
                            <asp:ListItem Value="2">出库</asp:ListItem>
                            <asp:ListItem Value="3">修磨中</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" style="padding-right:25px;padding-left:25px; margin-left:10px;"/>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <!--文字列表-->
            <asp:Repeater ID="rptList1" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="center"width="8%">刀具条码</th>
                            <th align="center"width="8%">批号</th>
                            <th align="center" width="8%">刀具编号</th>
                            <th align="center" width="8%">刀具名称</th>
                            <th align="center" width="8%">刀具分类</th>
                            <th align="center" width="5%">品牌</th>
                            <th align="center" width="10%">规格</th>
                            <th align="center" width="3%">单位</th>
                            <th align="center" width="5%">数量</th>
                            <th align="center" width="5%">所在柜子</th>
                            <th align="center" width="5%">所在抽屉</th>
                            <th align="center" width="5%">所在九宫格</th>
                            <th align="center" width="5%">剩余使用寿命</th>
                            <th align="center" width="5%">刀具等级</th>
                            <th align="center" width="5%">状态</th>
                            <%--<th width="10%">操作</th>--%>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr height="80">
                        <%--<td align="center">
                            <asp:HiddenField ID="hfdId" runat="server" Value='<%#Eval("ID") %>' />
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        </td>--%>
                        <td  align="center"><%#Eval("BarCode") %></td>
                        <td  align="center"><%#Eval("BatchNumber") %></td>
                        <td  align="center"><%# Eval("MaterialID") %></td>
                        <td  align="center"><%# Eval("MaterialName") %></td>
                        <td  align="center"><%# Eval("MaterialType") %></td>
                        <td  align="center"><%# Eval("Brand") %></td>
                        <td  align="center"><%# Eval("Spec") %></td>
                        <td  align="center"><%# Eval("Unit") %></td>
                        <td  align="center"><%# Eval("Num") %></td>
                        <td  align="center"><%# Eval("FK_CabinetNo") %></td>
                        <td  align="center"><%# Eval("BoxNo") %></td>
                        <td  align="center"><%# Eval("XY") %></td>
                        <td  align="center"><%# Eval("RemainTime") %></td>
                        <td  align="center"><%# Eval("ToolLevel") %></td>
                        <td  align="center"><%#Eval("State").ToString() == "0" ? "待入库" : Eval("State").ToString() == "1"?"在库":Eval("State").ToString() == "2"?"出库":"修磨中"%></td>
                        <%--<td align="center">
                            <a href='MaterialEdit.aspx?action=Edit&id=<%#Eval("ID") %>'>编辑</a>
                        </td>--%>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"17\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
            <!--/文字列表-->
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="当前页:%CurrentPageIndex%/%PageCount% 共有%RecordCount%条记录 %PageCount%/页"
            FirstPageText="首页" HorizontalAlign="Center" InvalidPageIndexErrorMessage="页索引不是有效的数值！"
            LastPageText="末页" NextPageText="下一页" PageIndexOutOfRangeErrorMessage="页索引超出范围！"
            PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always"
            Width="100%" OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="5">
        </webdiyer:AspNetPager>
        <!--/内容底部-->

    </form>
</body>
</html>

