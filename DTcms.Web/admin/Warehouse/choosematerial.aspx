<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="choosematerial.aspx.cs" Inherits="DTcms.Web.admin.Warehouse.choosematerial" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        function ok(txtMaterialName, txtMaterialType, hdfMaterialTypeID, txtBrand, txtSpec, txtDeep, txtHigh, txtUnit, txtTotalTime,txtCode, txtMaterialID) {
            var api = frameElement.api, W = api.opener;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget"] %>').value = txtMaterialName;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget1"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget1"] %>').value = txtMaterialType;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget2"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget2"] %>').value = hdfMaterialTypeID;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget3"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget3"] %>').value = txtBrand;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget4"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget4"] %>').value = txtSpec;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget5"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget5"] %>').value = txtDeep;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget6"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget6"] %>').value = txtHigh;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget7"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget7"] %>').value = txtUnit;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget8"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget8"] %>').value = txtTotalTime;
            if (W.document.getElementById('<%=Request.QueryString["txtTarget9"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["txtTarget9"] %>').value = txtCode;
            if (W.document.getElementById('<%=Request.QueryString["idTarget"] %>') || false)
                W.document.getElementById('<%=Request.QueryString["idTarget"] %>').value = txtMaterialID;
            api.close();
        }
    </script>
    <script type="text/javascript">
        function selectSingleRadio(rbtn1, GroupName) {

            $("input[type=radio]").each(function (i) {

                if (this.name.substring(this.name.length - GroupName.length) == GroupName) {

                    this.checked = false;
                }
            })
            rbtn1.checked = true;
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="floatHead" class="toolbar-wrap">
        <div class="toolbar">
            <div class="box-wrap">
                <a class="menu-btn"></a>
                <div class="r-list" style="padding-right: 20px;">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" placeholder="按刀具名称模糊查询" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="lbtnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div class="table-container">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="5%">
                            选择
                        </th>
                        <%--<th align="left" width="20%">
                            刀具编号
                        </th>--%>
                        <th align="left" width="20%">
                            刀具名称
                        </th>
                        <th align="left" width="10%">
                            品牌
                        </th>
                        <th align="left" width="10%">
                            规格
                        </th>
                        <th align="left" width="10%">
                            长度
                        </th>
                        <th align="left" width="10%">
                            直径
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%--<asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />--%>
                        <input type="radio" id="Radio1" name ="FlowCode" runat="server" onclick="selectSingleRadio(this,'FlowCode');" />
                        <asp:HiddenField ID="hfdMaterialID" Value='<%#Eval("MaterialID")%>' runat="server" />
                    </td>
                    <%--<td>
                        <%# Eval("MaterialID")%>
                    </td>--%>
                    <td>
                        <%# Eval("MaterialName")%>
                    </td>
                    <td>
                        <%# Eval("Brand")%>
                    </td>
                    <td>
                        <%# Eval("Spec")%>
                    </td>
                    <td>
                        <%# Eval("Deep")%>
                    </td>
                    <td>
                        <%# Eval("High")%>
                    </td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <!--/列表-->
    <!--内容底部-->
    <div class="line20">
    </div>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="当前页:%CurrentPageIndex%/%PageCount% 共有%RecordCount%条记录 %PageCount%/页"
            FirstPageText="首页" HorizontalAlign="Center" InvalidPageIndexErrorMessage="页索引不是有效的数值！"
            LastPageText="末页" NextPageText="下一页" PageIndexOutOfRangeErrorMessage="页索引超出范围！"
            PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always"
            Width="100%" OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="5">
        </webdiyer:AspNetPager>
    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="确认" CssClass="btn" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
