using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.printlog
{
    public partial class printweekrpt_yinyezhizhao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate1.Text = GetMondayDate(DateTime.Now).ToString("yyyy-MM-dd");
                txtDate2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BindDDL();
            }
        }

        private void BindDDL()
        {
            string sql = "select * from s_county where 1=1";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            ddlCounty.DataSource = dt;
            ddlCounty.DataTextField = "CountyName";
            ddlCounty.DataValueField = "CountyNum";
            ddlCounty.DataBind();

            sql = "select * from s_area where ParentId = '" + ddlCounty.SelectedItem.Value + "'";
            dt = DbHelperMySql.Query(sql).Tables[0];
            ddlArea.DataSource = dt;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AreaNum";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("--全部--", "0"));
        }

        protected void ddlCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from s_area where ParentId = '" + ddlCounty.SelectedItem.Value + "'";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            ddlArea.DataSource = dt;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AreaNum";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("--全部--", "0"));
        }

        private void BindData()
        {
            if (txtDate1.Text != "" && txtDate2.Text != "")
            {
                string where = " and 1=1";
                if (ddlCounty.SelectedItem != null)
                {
                    where += " and County = '" + ddlCounty.SelectedItem.Value + "'";
                }
                if (ddlArea.SelectedItem != null && ddlArea.SelectedItem.Value != "0")
                {
                    where += " and Area = '" + ddlArea.SelectedItem.Text + "'";
                }
                if (ddlPoint.SelectedItem != null && ddlPoint.SelectedItem.Text != "全部点位")
                {
                    where += " and Point = '" + ddlPoint.SelectedItem.Text + "'";
                }
                DateTime startdate = Convert.ToDateTime(txtDate1.Text);
                string sql = "";
                DataTable dt = null;
                //周一
                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and ((CreateSessionDate between '" + startdate.ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.ToString("yyyy-MM-dd") + " 8:59:59" + "') or (CreateSessionDate between '" + startdate.ToString("yyyy-MM-dd") + " 17:00:00" + "' and '" + startdate.ToString("yyyy-MM-dd") + " 23:59:59" + "')) ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblUnwork1.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.ToString("yyyy-MM-dd") + " 9:00:00" + "' and '" + startdate.ToString("yyyy-MM-dd") + " 16:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblWork1.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.ToString("yyyy-MM-dd") + " 23:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblSum1.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";
                //周二
                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and ((CreateSessionDate between '" + startdate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(1).ToString("yyyy-MM-dd") + " 8:59:59" + "') or (CreateSessionDate between '" + startdate.AddDays(1).ToString("yyyy-MM-dd") + " 17:00:00" + "' and '" + startdate.AddDays(1).ToString("yyyy-MM-dd") + " 23:59:59" + "')) ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblUnwork2.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(1).ToString("yyyy-MM-dd") + " 9:00:00" + "' and '" + startdate.AddDays(1).ToString("yyyy-MM-dd") + " 16:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblWork2.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(1).ToString("yyyy-MM-dd") + " 23:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblSum2.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";
                //周三
                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and ((CreateSessionDate between '" + startdate.AddDays(2).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(2).ToString("yyyy-MM-dd") + " 8:59:59" + "') or (CreateSessionDate between '" + startdate.AddDays(2).ToString("yyyy-MM-dd") + " 17:00:00" + "' and '" + startdate.AddDays(2).ToString("yyyy-MM-dd") + " 23:59:59" + "')) ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblUnwork3.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(2).ToString("yyyy-MM-dd") + " 9:00:00" + "' and '" + startdate.AddDays(2).ToString("yyyy-MM-dd") + " 16:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblWork3.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(2).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(2).ToString("yyyy-MM-dd") + " 23:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblSum3.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";
                //周四
                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and  ((CreateSessionDate between '" + startdate.AddDays(3).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(3).ToString("yyyy-MM-dd") + " 8:59:59" + "') or (CreateSessionDate between '" + startdate.AddDays(3).ToString("yyyy-MM-dd") + " 17:00:00" + "' and '" + startdate.AddDays(3).ToString("yyyy-MM-dd") + " 23:59:59" + "')) ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblUnwork4.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(3).ToString("yyyy-MM-dd") + " 9:00:00" + "' and '" + startdate.AddDays(3).ToString("yyyy-MM-dd") + " 16:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblWork4.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(3).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(3).ToString("yyyy-MM-dd") + " 23:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblSum4.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";
                //周五
                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and ((CreateSessionDate between '" + startdate.AddDays(4).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(4).ToString("yyyy-MM-dd") + " 8:59:59" + "') or (CreateSessionDate between '" + startdate.AddDays(4).ToString("yyyy-MM-dd") + " 17:00:00" + "' and '" + startdate.AddDays(4).ToString("yyyy-MM-dd") + " 23:59:59" + "')) ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblUnwork5.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(4).ToString("yyyy-MM-dd") + " 9:00:00" + "' and '" + startdate.AddDays(4).ToString("yyyy-MM-dd") + " 16:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblWork5.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(4).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(4).ToString("yyyy-MM-dd") + " 23:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblSum5.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";
                //周六
                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and ((CreateSessionDate between '" + startdate.AddDays(5).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(5).ToString("yyyy-MM-dd") + " 8:59:59" + "') or (CreateSessionDate between '" + startdate.AddDays(5).ToString("yyyy-MM-dd") + " 17:00:00" + "' and '" + startdate.AddDays(5).ToString("yyyy-MM-dd") + " 23:59:59" + "')) ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblUnwork6.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(5).ToString("yyyy-MM-dd") + " 9:00:00" + "' and '" + startdate.AddDays(5).ToString("yyyy-MM-dd") + " 16:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblWork6.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(5).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(5).ToString("yyyy-MM-dd") + " 23:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblSum6.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";
                //周日
                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and ((CreateSessionDate between '" + startdate.AddDays(6).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(6).ToString("yyyy-MM-dd") + " 8:59:59" + "') or (CreateSessionDate between '" + startdate.AddDays(6).ToString("yyyy-MM-dd") + " 17:00:00" + "' and '" + startdate.AddDays(6).ToString("yyyy-MM-dd") + " 23:59:59" + "')) ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblUnwork7.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(6).ToString("yyyy-MM-dd") + " 9:00:00" + "' and '" + startdate.AddDays(6).ToString("yyyy-MM-dd") + " 16:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblWork7.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                sql = "select count(*) from u_printlog where IsZhengbenSuccessed = 1 and IsFubenSuccessed = 1 and (CreateSessionDate between '" + startdate.AddDays(6).ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + startdate.AddDays(6).ToString("yyyy-MM-dd") + " 23:59:59" + "') ";
                sql += where;
                dt = DbHelperMySql.Query(sql).Tables[0];
                lblSum7.Text = dt.Rows[0][0].ToString() != "" ? dt.Rows[0][0].ToString() : "0";

                lblWorkSum.Text = (Convert.ToInt16(lblWork1.Text) + Convert.ToInt16(lblWork2.Text) + Convert.ToInt16(lblWork3.Text) + Convert.ToInt16(lblWork4.Text) + Convert.ToInt16(lblWork5.Text) + Convert.ToInt16(lblWork6.Text) + Convert.ToInt16(lblWork7.Text)).ToString();
                lblUnworkSum.Text = (Convert.ToInt16(lblUnwork1.Text) + Convert.ToInt16(lblUnwork2.Text) + Convert.ToInt16(lblUnwork3.Text) + Convert.ToInt16(lblUnwork4.Text) + Convert.ToInt16(lblUnwork5.Text) + Convert.ToInt16(lblUnwork6.Text) + Convert.ToInt16(lblUnwork7.Text)).ToString();
                lblWeekTotal.Text = lblSumTotal.Text = (Convert.ToInt16(lblWorkSum.Text) + Convert.ToInt16(lblUnworkSum.Text)).ToString();
                lblWeekUnworkTotal.Text = (Convert.ToInt16(lblUnwork1.Text) + Convert.ToInt16(lblUnwork2.Text) + Convert.ToInt16(lblUnwork3.Text) + Convert.ToInt16(lblUnwork4.Text) + Convert.ToInt16(lblUnwork5.Text) + Convert.ToInt16(lblSum6.Text) + Convert.ToInt16(lblSum7.Text)).ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('请输入起始日期')", true);
                return;
            }

        }


        /// <summary> 
        /// 计算本周周日的日期 
        /// </summary> 
        /// <returns></returns> 
        public static DateTime GetSundayDate()
        {
            return GetSundayDate(DateTime.Now);
        }
        /// <summary> 
        /// 计算某日起始日期（礼拜一的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }
        /// <summary> 
        /// 计算某日结束日期（礼拜日的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetSundayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Add(ts);
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnLastWeek_Click(object sender, EventArgs e)
        {
            if (txtDate2.Text != "")
            {
                DateTime thistime = Convert.ToDateTime(txtDate2.Text);
                txtDate1.Text = GetMondayDate(thistime.AddDays(-7)).ToString("yyyy-MM-dd");
                txtDate2.Text = GetSundayDate(thistime.AddDays(-7)).ToString("yyyy-MM-dd");
            }
        }
    }
}