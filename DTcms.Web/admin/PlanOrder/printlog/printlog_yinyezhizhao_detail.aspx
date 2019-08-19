<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printlog_yinyezhizhao_detail.aspx.cs" Inherits="DTcms.Web.admin.printlog.printlog_yinyezhizhao_detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>日志明细</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>

</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>系统分类</span></a>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <asp:HiddenField ID="hidId" runat="server" Value="0" />

        <%--<div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">
                            <asp:Literal ID="litNowPosition2" runat="server" Text="商品分类"></asp:Literal></a></li>
                    </ul>
                </div>
            </div>
        </div>--%>
        <div class="tab-content">
            <dl>
                <dt>经办人：</dt>
                <dd>
                    <asp:Label ID="lblagentName" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>经办人身份证：</dt>
                <dd>
                    <asp:Label ID="lblagentIdCardNum" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>法定代表人：</dt>
                <dd>
                    <asp:Label ID="lbllegalpersonName" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>法定代表人身份证：</dt>
                <dd>
                    <asp:Label ID="lbllegalpersonIdCardNum" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>企业名称：</dt>
                <dd>
                    <asp:Label ID="lblcompanyName" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>社会统一编码：</dt>
                <dd>
                    <asp:Label ID="lblsocialNum" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>正本打印时间：</dt>
                <dd>
                    <asp:Label ID="lblprintZhengbendate" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>副本打印时间：</dt>
                <dd>
                    <asp:Label ID="lblprintFubenDate" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>RGB活体检测分值：</dt>
                <dd>
                    <asp:Label ID="lblRGBScore" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>红外活体检测分值：</dt>
                <dd>
                    <asp:Label ID="lblIRScore" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>人证对比检测分值：</dt>
                <dd>
                    <asp:Label ID="lblCompareScore" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>业务类型：</dt>
                <dd>
                    <asp:Label ID="lblBussinessType" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>打印人类型：</dt>
                <dd>
                    <asp:Label ID="lblPrinterType" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>备注：</dt>
                <dd>
                    <asp:Label ID="lblRemark" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>设备编号：</dt>
                <dd>
                    <asp:Label ID="lblMachineId" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>SessionId：</dt>
                <dd>
                    <asp:Label ID="lblSessionId" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>操作日期：</dt>
                <dd>
                    <asp:Label ID="lblCreateSessionDate" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>正本TCPIP反馈结果：</dt>
                <dd>
                    <asp:Label ID="lblIsZhengbenTCPIP" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>正本光感检测结果：</dt>
                <dd>
                    <asp:Label ID="lblIsZhengbenLightCheck" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>正本打印机检测结果：</dt>
                <dd>
                    <asp:Label ID="lblIsZhengbenPrintCheck" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>正本打印结果：</dt>
                <dd>
                    <asp:Label ID="lblIsZhengbenSuccessed" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>副本TCPIP反馈结果：</dt>
                <dd>
                    <asp:Label ID="lblIsFubenTCPIP" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>副本光感检测结果：</dt>
                <dd>
                    <asp:Label ID="lblIsFubenLightCheck" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>副本打印机检测结果：</dt>
                <dd>
                    <asp:Label ID="lblIsFubenPrintCheck" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>副本打印结果：</dt>
                <dd>
                    <asp:Label ID="lblIsFubenSuccessed" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>副本数量：</dt>
                <dd>
                    <asp:Label ID="lblFubenCount" runat="server" Text="Label"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>身份证头像：</dt>
                <dd>
                    <asp:Image ID="imgPicIDcardFace" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>指纹图像：</dt>
                <dd>
                    <asp:Image ID="imgPicFinger" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>RGB摄像头图像：</dt>
                <dd>
                    <asp:Image ID="imgPicFaceRGB" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>红外摄像头图像：</dt>
                <dd>
                    <asp:Image ID="imgPicFaceIR" runat="server" />
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <div class="page-footer" runat="server" id="div_gongju">
            <div class="btn-list">
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
                <asp:Label ID="lblError" runat="server" Text="" Style="color: Red;"></asp:Label>
            </div>
            <div class="clear">
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>

