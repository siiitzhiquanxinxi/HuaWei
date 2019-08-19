using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.printlog
{
    public partial class printlog_yinyezhizhao_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    GetData();
                }
            }
        }

        private void GetData()
        {
            string id = Request.QueryString["id"].ToString();
            DTcms.Model.u_printlog printlog = new BLL.u_printlog().GetModel(Convert.ToInt32(id));
            if (printlog != null)
            {
                lblagentName.Text = printlog.agentName;
                lblagentIdCardNum.Text = printlog.agentIdCardNum;
                lbllegalpersonName.Text = printlog.legalpersonName;
                lbllegalpersonIdCardNum.Text = printlog.legalpersonIdCardNum;
                lblcompanyName.Text = printlog.companyName;
                lblsocialNum.Text = printlog.socialNum;
                lblprintZhengbendate.Text = printlog.printZhengbendate.ToString();
                lblprintFubenDate.Text = printlog.printFubenDate.ToString();

                if (printlog.PicIDcardFace != null)
                {
                    imgPicIDcardFace.ImageUrl = "GetImg.ashx?id=" + id + "&type=face";
                }
                if (printlog.PicFinger != null)
                {
                    imgPicFinger.ImageUrl = "GetImg.ashx?id=" + id + "&type=finger";
                }
                if (printlog.PicFaceRGB != null)
                {
                    imgPicFaceRGB.ImageUrl = "GetImg.ashx?id=" + id + "&type=rgb";
                }
                if (printlog.PicFaceIR != null)
                {
                    imgPicFaceIR.ImageUrl = "GetImg.ashx?id=" + id + "&type=ir";
                }
                lblRGBScore.Text = printlog.RGBScore;
                lblIRScore.Text = printlog.IRScore;
                lblCompareScore.Text = printlog.CompareScore;
                lblBussinessType.Text = printlog.BussinessType.ToString() == "0" ? "新办" : "变更";
                lblPrinterType.Text = printlog.PrinterType.ToString() == "0" ? "法人" : "经办人";
                lblRemark.Text = printlog.Remark;
                lblMachineId.Text = printlog.MachineId;
                lblSessionId.Text = printlog.SessionId;
                lblCreateSessionDate.Text = printlog.CreateSessionDate.ToString();
                lblIsZhengbenLightCheck.Text = printlog.IsZhengbenLightCheck == 1 ? "通过" : "未通过";
                lblIsFubenLightCheck.Text = printlog.IsFubenLightCheck == 1 ? "通过" : "未通过";
                lblIsZhengbenTCPIP.Text = printlog.IsZhengbenTCPIP == 1 ? "通过" : "未通过";
                lblIsFubenTCPIP.Text = printlog.IsFubenTCPIP == 1 ? "通过" : "未通过";
                lblIsZhengbenPrintCheck.Text = printlog.IsZhengbenPrintCheck == 1 ? "通过" : "未通过";
                lblIsFubenPrintCheck.Text = printlog.IsFubenPrintCheck == 1 ? "通过" : "未通过";
                lblFubenCount.Text = printlog.FubenCount >= 0 ? printlog.FubenCount.ToString() : "N/A";
                lblIsZhengbenSuccessed.Text = printlog.IsZhengbenSuccessed == 1 ? "成功" : printlog.IsZhengbenSuccessed == 2 ? "正本已打印" : "未成功";
                lblIsFubenSuccessed.Text = printlog.IsFubenSuccessed == 1 ? "成功" : printlog.IsFubenSuccessed == 2 ? "正本已打印" : "未成功";
            }
        }

    }
}