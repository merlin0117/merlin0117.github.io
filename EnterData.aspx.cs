using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Data.OleDb;
//using Excel = Microsoft.Office.Interop.Excel;
//using System.Reflection;

public partial class EnterData : System.Web.UI.Page
{
    //单价
    public  double unitTube, unitFastener, unitJacking, unitSleeve;
    public static DateTime deadlineTime;

    //赔偿单价
    public static double mTube, mFastener, mJacking, mSleeve;

    //钢管、扣件等租金单和
    public static double sumTube, sumFastener, sumJacking, sumSleeve;


    //当前计算参数
    public static double fees, sDay;
    public static DateTime sumTime;

    //上一次存储参数
    public  double tTube, tFastener, tJacking, tSleeve, tDay;
    public static DateTime tTime;

    //用来计算最后结果
    public double[] sum = new double[10];
    public double[] s = new double[10];
    public double footerCount;

    public double[] result = new double[10];
    public static double[] result2 = new double[10];
    public static double[] result3 = new double[10];

    public static int cid;
    public static int pid;
    public static int fid;
    public static int mid;

 double[] iSum = new double[10];
    double iSumTube = 0;
    double iSumFastener = 0;
    double iSumJacking = 0;
    double iSumSleeve = 0;
    double totalfei = 0;

    double[] rSum = new double[10];
    double rSumTube = 0;
    double rSumFastener = 0;
    double rSumJacking = 0;
    double rSumSleeve = 0;
    double totalfei1 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        sumTube = 0; sumFastener = 0; sumJacking = 0; sumSleeve = 0;
        tTube = 0; tFastener = 0; tJacking = 0; tSleeve = 0;
        mTube = 0; mFastener = 0; mJacking = 0; mSleeve = 0;

       

         iSumTube = 0;
         iSumFastener = 0;
         iSumJacking = 0;
         iSumSleeve = 0;
         totalfei = 0;

         rSumTube = 0;
         rSumFastener = 0;
         rSumJacking = 0;
         rSumSleeve = 0;
         totalfei1 = 0;

        tbDateTime.Focus();
        tbDateTime.Attributes.Add("onfocus", "this.select()");
        if (!IsPostBack)
        {
            if (Request.QueryString["cid"] != null)
            {
                cid = Convert.ToInt32(Request.QueryString["cid"]);

                //查询日租金

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 pid,cid,ptube,pfastener,pjacking,psleeve from unitprice ");
                strSql.Append(" where cid=@cid");
                strSql.Append(" order by pid desc");
                SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)			};
                parameters[0].Value = cid;

                DataSet ds = dbSql.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];


                    if (row["pid"] != null && row["pid"].ToString() != "")
                    {
                        pid = int.Parse(row["pid"].ToString());
                    }

                    if (row["ptube"] != null && row["ptube"].ToString() != "")
                    {
                        unitTube = double.Parse(row["ptube"].ToString());
                        lblTubeFright.Text = unitTube.ToString("F3");
                    }
                    if (row["pfastener"] != null && row["pfastener"].ToString() != "")
                    {
                        unitFastener = double.Parse(row["pfastener"].ToString());
                        lblFastenerFright.Text = unitFastener.ToString("F3");
                    }
                    if (row["pjacking"] != null && row["pjacking"].ToString() != "")
                    {
                        unitJacking = double.Parse(row["pjacking"].ToString());
                        lblJackingFright.Text = unitJacking.ToString("F3");
                    }
                    if (row["psleeve"] != null && row["psleeve"].ToString() != "")
                    {
                        unitSleeve = double.Parse(row["psleeve"].ToString());
                        lblSleeveFright.Text = unitSleeve.ToString("F3");
                    }

                }

                //查询工地名称
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("select  top 1 * from customer ");
                strSql1.Append(" where cid=@cid");
                SqlParameter[] parameters1 = {
					new SqlParameter("@cid", SqlDbType.Int,4)			};
                parameters1[0].Value = cid;
                DataSet ds1 = dbSql.Query(strSql1.ToString(), parameters1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DataRow row1 = ds1.Tables[0].Rows[0];
                    if (row1["cname"] != null && row1["cname"].ToString() != "")
                    {
                        lblName.Text = row1["cname"].ToString();
                        lblMsg.Text = row1["cname"].ToString();
                        Label26.Text = row1["ctele"].ToString();

                    }
                }

                //查询赔偿金

                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select  top 1 mid,cid,mtube,mfastener,mjacking,msleeve from compensation ");
                strSql2.Append(" where cid=@cid");
                strSql2.Append(" order by mid desc");
                SqlParameter[] parameters2 = {
					new SqlParameter("@cid", SqlDbType.Int,4)			};
                parameters2[0].Value = cid;

                DataSet ds2 = dbSql.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds2.Tables[0].Rows[0];


                    if (row["mid"] != null && row["mid"].ToString() != "")
                    {
                        mid = int.Parse(row["mid"].ToString());

                    }

                    if (row["mtube"] != null && row["mtube"].ToString() != "")
                    {
                        mTube = double.Parse(row["mtube"].ToString());
                        lblTubeFright2.Text = mTube.ToString("F2");

                    }
                    else mTube = 0;
                    if (row["mfastener"] != null && row["mfastener"].ToString() != "")
                    {
                        mFastener = double.Parse(row["mfastener"].ToString());
                        lblFastenerFright2.Text = mFastener.ToString("F2");
                    }
                    else mFastener = 0;
                    if (row["mjacking"] != null && row["mjacking"].ToString() != "")
                    {
                        mJacking = double.Parse(row["mjacking"].ToString());
                        lblJackingFright2.Text = mJacking.ToString("F2");
                    }
                    else mJacking = 0;
                    if (row["msleeve"] != null && row["msleeve"].ToString() != "")
                    {
                        mSleeve = double.Parse(row["msleeve"].ToString());
                        lblSleeveFright2.Text = mSleeve.ToString("F2");
                    }
                    else mSleeve = 0;

                }



            }
            else lblMsg.Text = "请选择工地，输入数据";


            //查询运费单价
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("select  top 1 fid,cid,ftube,ffastener,fjacking,fsleeve from freight  ");
            strSql3.Append(" where cid=@cid");
            SqlParameter[] parameters3 = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
            parameters3[0].Value = cid;

            DataSet ds3 = dbSql.Query(strSql3.ToString(), parameters3);
            if (ds3.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds3.Tables[0].Rows[0];
                // if (row != null)
                // {
                if (row["ftube"] != null && row["ftube"].ToString() != "")
                {

                    tTube = Convert.ToDouble(row["ftube"].ToString());
                    lblTubeFright1.Text = row["ftube"].ToString();
                }
                else tTube = 0;
                if (row["ffastener"] != null && row["ffastener"].ToString() != "")
                {
                    tFastener = Convert.ToDouble(row["ffastener"].ToString());
                    lblFastenerFright1.Text = row["ffastener"].ToString();
                }
                else tFastener = 0;
                if (row["fjacking"] != null && row["fjacking"].ToString() != "")
                {
                    tJacking = Convert.ToDouble(row["fjacking"].ToString());
                    lblJackingFright1.Text = row["fjacking"].ToString();
                }
                else tJacking = 0;
                if (row["fsleeve"] != null && row["fsleeve"].ToString() != "")
                {
                    tSleeve = Convert.ToDouble(row["fsleeve"].ToString());
                    lblSleeveFright1.Text = row["fsleeve"].ToString();
                }
                else tSleeve = 0;
                //}
                // else { tTube = 0; tFastener = 0; tJacking = 0; tSleeve = 0; }
            }


            btnResult.Enabled = false;

            //排序
            this.GridView1.Attributes.Add("SortExpression", "rtime");
            this.GridView1.Attributes.Add("SortDirection", "ASC");

            bind();

        }
        else
        {
            if (Request.QueryString["cid"] != null)
            {
                cid = Convert.ToInt32(Request.QueryString["cid"]);
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        ClearControl(this.Controls);

        try
        {
            DateTime rtime = getDate(this.tbDateTime.Text);
            decimal rtube = decimal.Parse(this.tbTube.Text);
            decimal rfastener = decimal.Parse(this.tbFastener.Text);
            decimal rjacking = decimal.Parse(this.tbJacking.Text);
            decimal rsleeve = decimal.Parse(this.tbSleeve.Text);
            string isout = "出库";

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into rentData(");
            strSql.Append("rtime,rtube,rfastener,rjacking,rsleeve,isout,cid)");
            strSql.Append(" values (");
            strSql.Append("@rtime,@rtube,@rfastener,@rjacking,@rsleeve,@isout,@cid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@rtime", SqlDbType.DateTime),
					new SqlParameter("@rtube", SqlDbType.Float,8),
					new SqlParameter("@rfastener", SqlDbType.Float,8),
					new SqlParameter("@rjacking", SqlDbType.Float,8),
					new SqlParameter("@rsleeve", SqlDbType.Float,8),
					new SqlParameter("@isout", SqlDbType.VarChar,4),
					new SqlParameter("@cid", SqlDbType.Int,4)};
            parameters[0].Value = rtime;
            parameters[1].Value = rtube;
            parameters[2].Value = rfastener;
            parameters[3].Value = rjacking;
            parameters[4].Value = rsleeve;
            parameters[5].Value = isout;
            parameters[6].Value = cid;

            if (dbSql.boolSql(strSql.ToString(), parameters))
            {
                lblMsg.Text = "出库记录保存成功";
                // bind();
            }
            else lblMsg.Text = "未提交，请稍后再试";


            bind();
        }
        catch
        {
            lblMsg.Text = "未提交，请输入正确数据再试";
        }
        ClearControl2();

    }

    protected void btnAddIn_Click(object sender, EventArgs e)
    {
        ClearControl(this.Controls);

        try
        {

            DateTime rtime = getDate(this.tbDateTime.Text);
            decimal rtube = decimal.Parse(this.tbTube.Text);
            decimal rfastener = decimal.Parse(this.tbFastener.Text);
            decimal rjacking = decimal.Parse(this.tbJacking.Text);
            decimal rsleeve = decimal.Parse(this.tbSleeve.Text);
            string isout = "入库";

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into rentData(");
            strSql.Append("rtime,rtube,rfastener,rjacking,rsleeve,isout,cid)");
            strSql.Append(" values (");
            strSql.Append("@rtime,@rtube,@rfastener,@rjacking,@rsleeve,@isout,@cid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@rtime", SqlDbType.DateTime),
					new SqlParameter("@rtube", SqlDbType.Float,8),
					new SqlParameter("@rfastener", SqlDbType.Float,8),
					new SqlParameter("@rjacking", SqlDbType.Float,8),
					new SqlParameter("@rsleeve", SqlDbType.Float,8),
					new SqlParameter("@isout", SqlDbType.VarChar,4),
					new SqlParameter("@cid", SqlDbType.Int,4)};
            parameters[0].Value = rtime;
            parameters[1].Value = rtube;
            parameters[2].Value = rfastener;
            parameters[3].Value = rjacking;
            parameters[4].Value = rsleeve;
            parameters[5].Value = isout;
            parameters[6].Value = cid;

            if (dbSql.boolSql(strSql.ToString(), parameters))
            {
                lblMsg.Text = "入库记录保存成功";
                //bind();
            }
            else lblMsg.Text = "未提交，请稍后再试";



            bind();
        }
        catch
        {
            lblMsg.Text = "未提交，请输入正确数据再试";
        }
        ClearControl2();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DateTime dt = System.DateTime.Now;
        string str = dt.ToString("yyyyMMddhhmmss");


        str += lblName.Text.Trim().ToString();
        str = str + ".xls";

        GridView1.AllowPaging = false;

        GridViewToExcel(divExport, "application/ms-excel", str);


    }

    protected void btnResult_Click(object sender, EventArgs e)
    {
        DateTime dt = System.DateTime.Now;
        string str = dt.ToString("yyyyMMddhhmmss");

        StringBuilder strSql = new StringBuilder();
        strSql.Append("update customer set ");
        strSql.Append("crentfees=@crentfees,");
        strSql.Append("cfright=@cfright,");
        strSql.Append("ctime=@ctime");
        strSql.Append(" where cid=@cid");
        SqlParameter[] parameters = {
					new SqlParameter("@crentfees", SqlDbType.Float,8),
					new SqlParameter("@cfright", SqlDbType.Float,8),
					new SqlParameter("@ctime", SqlDbType.DateTime,8),
        new SqlParameter("@cid", SqlDbType.Int,4)};
        parameters[0].Value = Convert.ToDouble(lblRentFees.Text.ToString().Trim());
        parameters[1].Value = Convert.ToDouble(lblTransmitFees.Text.ToString().Trim());
        parameters[2].Value = dt;
        parameters[3].Value = cid;

        if (dbSql.boolSql(strSql.ToString(), parameters)) lblMsg.Text = "数据更新成功";
        else lblMsg.Text = "未提交，请稍后再试";
        bind();
    }

    public DateTime getDate(string date)
    {
        string syear = "";
        string smonth = "";
        string sday = "";
        try
        {
            return Convert.ToDateTime(date);
        }
        catch
        {

            switch (date.Length)
            {
                case 1:
                    syear = DateTime.Now.ToString("yyyy");
                    smonth = DateTime.Now.ToString("MM");
                    sday = "0" + date;
                    break;

                case 2:
                    syear = DateTime.Now.ToString("yyyy");
                    smonth = DateTime.Now.ToString("MM");
                    sday = date;
                    break;
                case 3:
                    syear = DateTime.Now.ToString("yyyy");
                    smonth = "0" + date.Substring(0, 1);
                    sday = date.Substring(1, 2);
                    break;
                case 4:
                    syear = DateTime.Now.ToString("yyyy");
                    smonth = date.Substring(0, 2);
                    sday = date.Substring(2, 2);
                    break;

                case 6:
                    syear = "20" + date.Substring(0, 2);
                    smonth = date.Substring(2, 2);
                    sday = date.Substring(4, 2);
                    break;
                case 8:
                    syear = date.Substring(0, 4);
                    smonth = date.Substring(4, 2);
                    sday = date.Substring(6, 2);
                    break;
                default:
                    syear = DateTime.Now.ToString("yyyy");
                    smonth = DateTime.Now.ToString("MM");
                    sday = DateTime.Now.ToString("dd");
                    break;
            }

            return DateTime.ParseExact(syear + smonth + sday, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
        }


    }

    public void GridViewToExcel(Control ctrl, string FileType, string FileName)
    {

        //FileName = Server.MapPath(".\\" + FileName);

        HttpContext.Current.Response.Charset = "GB2312";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;//注意编码

        HttpContext.Current.Response.AppendHeader("Content-Disposition",
       "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
        HttpContext.Current.Response.ContentType = FileType;//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword 
        ctrl.Page.EnableViewState = false;

        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);

        ClearControls3(GridView1);
        ctrl.RenderControl(hw);

        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();


        //Excel.ApplicationClass oExcel;
        //oExcel = new Excel.ApplicationClass();
        //oExcel.UserControl = false;
        //Excel.WorkbookClass wb = (Excel.WorkbookClass)oExcel.Workbooks.Open(FileName,System.Reflection.Missing.Value);
        //wb.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
        //wb.Close();        
        //oExcel.Quit();
        //System.GC.Collect();


    }

    /// <summary>
    /// 防止导出excel出错
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    /// <summary>
    /// 清除控件中的所有控件，以便导出Excel
    /// </summary>
    /// <param name="control"></param>
    public void ClearControls3(Control control)
    {
        for (int i = control.Controls.Count - 1; i >= 0; i--)
        {
            ClearControls3(control.Controls[i]);
        }

        if (!(control is TableCell))
        {
            if (control.GetType().GetProperty("SelectedItem") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                }
                catch
                {
                }
                control.Parent.Controls.Remove(control);
            }
            else if (control.GetType().GetProperty("Text") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                control.Parent.Controls.Remove(control);
            }
        }
        GridView1.Columns[12].Visible = false;
        GridView1.Columns[13].Visible = false;

        return;
    }

    //费用计算
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if ((e.Row.RowState & DataControlRowState.Edit) == 0)
            {
                if (e.Row.RowIndex == 0)
                {

                    e.Row.Cells[5].Text = "0";
                    e.Row.Cells[6].Text = "0";
                    e.Row.Cells[7].Text = "0";
                    e.Row.Cells[8].Text = "0";

                    e.Row.Cells[9].Text = "0";
                    e.Row.Cells[10].Text = "0";

                    if (e.Row.Cells[11].Text == "出库")
                    {

                        sum[0] += Convert.ToDouble(e.Row.Cells[1].Text);
                        sum[1] += Convert.ToDouble(e.Row.Cells[2].Text);
                        sum[2] += Convert.ToDouble(e.Row.Cells[3].Text);
                        sum[3] += Convert.ToDouble(e.Row.Cells[4].Text);

                        s[0] += Convert.ToDouble(e.Row.Cells[1].Text);
                        s[1] += Convert.ToDouble(e.Row.Cells[2].Text);
                        s[2] += Convert.ToDouble(e.Row.Cells[3].Text);
                        s[3] += Convert.ToDouble(e.Row.Cells[4].Text);

                    }
                    else
                    {
                        sum[0] -= Convert.ToDouble(e.Row.Cells[1].Text);
                        sum[1] -= Convert.ToDouble(e.Row.Cells[2].Text);
                        sum[2] -= Convert.ToDouble(e.Row.Cells[3].Text);
                        sum[3] -= Convert.ToDouble(e.Row.Cells[4].Text);

                        s[4] += Convert.ToDouble(e.Row.Cells[1].Text);
                        s[5] += Convert.ToDouble(e.Row.Cells[2].Text);
                        s[6] += Convert.ToDouble(e.Row.Cells[3].Text);
                        s[7] += Convert.ToDouble(e.Row.Cells[4].Text);


                    }
                    //租金和
                    sum[4] += Convert.ToDouble(e.Row.Cells[10].Text);


                    //求运费result[0]

                }
                else if (e.Row.RowIndex > 0)
                {

                    e.Row.Cells[5].Text = sum[0].ToString("f2");
                    e.Row.Cells[6].Text = sum[1].ToString("f2");
                    e.Row.Cells[7].Text = sum[2].ToString("f2");
                    e.Row.Cells[8].Text = sum[3].ToString("f2");

                    string r = GridView1.DataKeys[e.Row.RowIndex - 1]["rtime"].ToString();

                    sDay = (Convert.ToDateTime(e.Row.Cells[0].Text) - Convert.ToDateTime(r)).TotalDays;

                    //  (sumTube * unitTube + sumFastener * unitFastener + sumJacking * unitJacking) * sday;
                    e.Row.Cells[9].Text = sDay.ToString("0");

                    e.Row.Cells[10].Text = ((sum[0] * Convert.ToDouble(lblTubeFright.Text) + sum[1] * Convert.ToDouble(lblFastenerFright.Text) + sum[2] * Convert.ToDouble(lblJackingFright.Text) + Convert.ToDouble(lblSleeveFright.Text) * sum[3]) * sDay).ToString("f2");

                    sumTube += sum[0] * Convert.ToDouble(lblTubeFright.Text) * sDay;
                    sumFastener += sum[1] * Convert.ToDouble(lblFastenerFright.Text) * sDay;
                    sumJacking += sum[2] * Convert.ToDouble(lblJackingFright.Text) * sDay;
                    sumSleeve += sum[3] * Convert.ToDouble(lblSleeveFright.Text) * sDay;

                    if (e.Row.Cells[11].Text == "出库")
                    {
                        //租金数量计算
                        sum[0] += Convert.ToDouble(e.Row.Cells[1].Text);
                        sum[1] += Convert.ToDouble(e.Row.Cells[2].Text);
                        sum[2] += Convert.ToDouble(e.Row.Cells[3].Text);
                        sum[3] += Convert.ToDouble(e.Row.Cells[4].Text);
                        //运费数量计算
                        s[0] += Convert.ToDouble(e.Row.Cells[1].Text);
                        s[1] += Convert.ToDouble(e.Row.Cells[2].Text);
                        s[2] += Convert.ToDouble(e.Row.Cells[3].Text);
                        s[3] += Convert.ToDouble(e.Row.Cells[4].Text);
                    }
                    else
                    {
                        sum[0] -= Convert.ToDouble(e.Row.Cells[1].Text);
                        sum[1] -= Convert.ToDouble(e.Row.Cells[2].Text);
                        sum[2] -= Convert.ToDouble(e.Row.Cells[3].Text);
                        sum[3] -= Convert.ToDouble(e.Row.Cells[4].Text);

                        s[4] += Convert.ToDouble(e.Row.Cells[1].Text);
                        s[5] += Convert.ToDouble(e.Row.Cells[2].Text);
                        s[6] += Convert.ToDouble(e.Row.Cells[3].Text);
                        s[7] += Convert.ToDouble(e.Row.Cells[4].Text);
                    }
                    //租金和
                    sum[4] += Convert.ToDouble(e.Row.Cells[10].Text);

                    //未入库数量
                    Label1.Text = sum[0].ToString("F2");
                    Label2.Text = sum[1].ToString("F2");
                    Label3.Text = sum[2].ToString("F2");
                    Label4.Text = sum[3].ToString("F2");


                    lblRentFees.Text = sum[4].ToString("F2");

                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            footerCount++;

            e.Row.Cells[0].Text = "出|入合计：";
            e.Row.Cells[1].Text = s[0].ToString() + "<br />" + s[4].ToString();
            e.Row.Cells[2].Text = s[1].ToString() + "<br />" + s[5].ToString();
            e.Row.Cells[3].Text = s[2].ToString() + "<br />" + s[6].ToString();
            e.Row.Cells[4].Text = s[3].ToString() + "<br />" + s[7].ToString();


            e.Row.Cells[5].Text = sumTube.ToString("F2");
            e.Row.Cells[6].Text = sumFastener.ToString("F2");
            e.Row.Cells[7].Text = sumJacking.ToString("F2");
            e.Row.Cells[8].Text = sumSleeve.ToString("F2");

            e.Row.Cells[10].Text = sum[4].ToString();

            //"出合计："
            Label14.Text = s[0].ToString("F2");
            Label15.Text = s[1].ToString("F2");
            Label16.Text = s[2].ToString("F2");
            Label17.Text = s[3].ToString("F2");
            //"入合计："
            Label18.Text = s[4].ToString("F2");
            Label19.Text = s[5].ToString("F2");
            Label20.Text = s[6].ToString("F2");
            Label21.Text = s[7].ToString("F2");

            //租金
            Label6.Text = sumTube.ToString("F2");
            Label7.Text = sumFastener.ToString("F2");
            Label8.Text = sumJacking.ToString("F2");
            Label9.Text = sumSleeve.ToString("F2");



            //租金+运费+赔偿费
            // lblTotal.Text = (Convert.ToDouble(lblTransmitFees.Text.ToString().Trim()) + Convert.ToDouble(lblRentFees.Text.ToString().Trim()) + Convert.ToDouble(Label5.Text.ToString().Trim())).ToString("F2");


        }
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列
        string sortExpression = e.SortExpression.ToString();
        // 假定为排序方向为“顺序”
        string sortDirection = "ASC";
        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改
        if (sortExpression == this.GridView1.Attributes["SortExpression"])
        {
            //获得下一次的排序状态
            sortDirection = (this.GridView1.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }
        // 重新设定GridView排序数据列及排序方向
        this.GridView1.Attributes["SortExpression"] = sortExpression;
        this.GridView1.Attributes["SortDirection"] = sortDirection;
        bind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {


        GridView1.Columns[5].Visible = false;
        GridView1.Columns[6].Visible = false;
        GridView1.Columns[7].Visible = false;
        GridView1.Columns[8].Visible = false;
        GridView1.Columns[9].Visible = false;
        GridView1.Columns[10].Visible = false;
        GridView1.EditIndex = e.NewEditIndex;

        bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.Columns[5].Visible = true;
        GridView1.Columns[6].Visible = true;
        GridView1.Columns[7].Visible = true;
        GridView1.Columns[8].Visible = true;
        GridView1.Columns[9].Visible = true;
        GridView1.Columns[10].Visible = true;
        GridView1.EditIndex = -1;
        bind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete from rentData ");
        strSql.Append(" where rid=@rid");
        SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4)
			};
        parameters[0].Value = GridView1.DataKeys[e.RowIndex]["rid"].ToString();

        if (dbSql.boolSql(strSql.ToString(), parameters)) lblMsg.Text = "数据删除成功！";
        else lblMsg.Text = "未提交，请稍后再试";

        bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("update rentData set ");
        strSql.Append("rtime=@rtime,");
        strSql.Append("rtube=@rtube,");
        strSql.Append("rfastener=@rfastener,");
        strSql.Append("rjacking=@rjacking,");
        strSql.Append("rsleeve=@rsleeve,");
        strSql.Append("isout=@isout,");
        strSql.Append("cid=@cid");
        strSql.Append(" where rid=@rid");

        SqlParameter[] parameters = {
					new SqlParameter("@rtime", SqlDbType.DateTime),
					new SqlParameter("@rtube", SqlDbType.Float,8),
					new SqlParameter("@rfastener", SqlDbType.Float,8),
					new SqlParameter("@rjacking", SqlDbType.Float,8),
					new SqlParameter("@rsleeve", SqlDbType.Float,8),
					new SqlParameter("@isout", SqlDbType.VarChar,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@rid", SqlDbType.Int,4)};
        parameters[0].Value = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim();
        parameters[1].Value = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
        parameters[2].Value = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        parameters[3].Value = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
        parameters[4].Value = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();

        string isout = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[11].Controls[0])).Text.ToString().Trim();
        parameters[6].Value = cid;
        parameters[7].Value = GridView1.DataKeys[e.RowIndex]["rid"].ToString();
        if (isout == "出库" || isout == "入库")
        {
            parameters[5].Value = isout;

            if (dbSql.boolSql(strSql.ToString(), parameters)) lblMsg.Text = "数据更新成功";
            else lblMsg.Text = "未提交，请稍后再试";

        }
        else lblMsg.Text = "请输入出库或者入库！";





        GridView1.Columns[5].Visible = true;
        GridView1.Columns[6].Visible = true;
        GridView1.Columns[7].Visible = true;
        GridView1.Columns[8].Visible = true;
        GridView1.Columns[9].Visible = true;
        GridView1.Columns[10].Visible = true;

        GridView1.EditIndex = -1;

        bind();
    }

    public void bind()
    {
        DataSet ds = dbSql.Query("select * from rentdata where cid =" + cid);

        string sortExpression = this.GridView1.Attributes["SortExpression"];
        string sortDirection = this.GridView1.Attributes["SortDirection"];
        // 调用业务数据获取方法

        // 根据GridView排序数据列及排序方向设置显示的默认数据视图
        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        {
            ds.Tables[0].DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        }


        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        btnResult.Enabled = true;

        bind1();
        bind2();

        //运费
        Label10.Text = (Convert.ToDouble(lblTubeFright1.Text) * (Convert.ToDouble(Label14.Text) + Convert.ToDouble(Label18.Text))).ToString("F2");
        Label11.Text = (Convert.ToDouble(lblFastenerFright1.Text) * (Convert.ToDouble(Label15.Text) + Convert.ToDouble(Label19.Text))).ToString("F2");
        Label12.Text = (Convert.ToDouble(lblJackingFright1.Text) * (Convert.ToDouble(Label16.Text) + Convert.ToDouble(Label20.Text))).ToString("F2");
        Label13.Text = (Convert.ToDouble(lblSleeveFright1.Text) * (Convert.ToDouble(Label17.Text) + Convert.ToDouble(Label21.Text))).ToString("F2");


        lblTransmitFees.Text = (Convert.ToDouble(Label11.Text) + Convert.ToDouble(Label12.Text) + Convert.ToDouble(Label13.Text) + Convert.ToDouble(Label10.Text)).ToString("F2");

        //赔偿
        Label22.Text = (Convert.ToDouble(lblTubeFright2.Text) * (Convert.ToDouble(Label1.Text))).ToString("F2");
        Label23.Text = (Convert.ToDouble(lblFastenerFright2.Text) * (Convert.ToDouble(Label2.Text))).ToString("F2");
        Label24.Text = (Convert.ToDouble(lblJackingFright2.Text) * (Convert.ToDouble(Label3.Text))).ToString("F2");
        Label25.Text = (Convert.ToDouble(lblSleeveFright2.Text) * (Convert.ToDouble(Label4.Text))).ToString("F2");

        Label5.Text = (Convert.ToDouble(Label22.Text) + Convert.ToDouble(Label23.Text) + Convert.ToDouble(Label24.Text) + Convert.ToDouble(Label25.Text)).ToString("F2");


        //租金+运费+赔偿费
        lblTotal.Text = (Convert.ToDouble(lblTransmitFees.Text.ToString().Trim()) + Convert.ToDouble(lblRentFees.Text.ToString().Trim()) + Convert.ToDouble(Label5.Text.ToString().Trim())).ToString("F2");

        lblWeiruku.Text = (Convert.ToDouble(lblChuku.Text) - Convert.ToDouble(lblRuku.Text)).ToString("f2");


        lblTotIsout.Text = (Convert.ToDouble(lblTransmitFees.Text.ToString().Trim()) + Convert.ToDouble(lblWeiruku.Text.ToString().Trim()) + Convert.ToDouble(Label5.Text.ToString().Trim())).ToString("F2");
    
    }


    public void bind1()
    {
        DataSet ds = dbSql.Query("select * from rentdata where cid =" + cid +" and isout='出库'");

        string sortExpression = this.GridView1.Attributes["SortExpression"];
        string sortDirection = this.GridView1.Attributes["SortDirection"];
        // 调用业务数据获取方法

        // 根据GridView排序数据列及排序方向设置显示的默认数据视图
        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        {
            ds.Tables[0].DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        }


        GridView2.DataSource = ds.Tables[0];
        GridView2.DataBind();
        btnResult.Enabled = true;

        //运费
        Label10.Text = (Convert.ToDouble(lblTubeFright1.Text) * (Convert.ToDouble(Label14.Text) + Convert.ToDouble(Label18.Text))).ToString("F2");
        Label11.Text = (Convert.ToDouble(lblFastenerFright1.Text) * (Convert.ToDouble(Label15.Text) + Convert.ToDouble(Label19.Text))).ToString("F2");
        Label12.Text = (Convert.ToDouble(lblJackingFright1.Text) * (Convert.ToDouble(Label16.Text) + Convert.ToDouble(Label20.Text))).ToString("F2");
        Label13.Text = (Convert.ToDouble(lblSleeveFright1.Text) * (Convert.ToDouble(Label17.Text) + Convert.ToDouble(Label21.Text))).ToString("F2");


        lblTransmitFees.Text = (Convert.ToDouble(Label11.Text) + Convert.ToDouble(Label12.Text) + Convert.ToDouble(Label13.Text) + Convert.ToDouble(Label10.Text)).ToString("F2");

        //赔偿
        Label22.Text = (Convert.ToDouble(lblTubeFright2.Text) * (Convert.ToDouble(Label1.Text))).ToString("F2");
        Label23.Text = (Convert.ToDouble(lblFastenerFright2.Text) * (Convert.ToDouble(Label2.Text))).ToString("F2");
        Label24.Text = (Convert.ToDouble(lblJackingFright2.Text) * (Convert.ToDouble(Label3.Text))).ToString("F2");
        Label25.Text = (Convert.ToDouble(lblSleeveFright2.Text) * (Convert.ToDouble(Label4.Text))).ToString("F2");

        Label5.Text = (Convert.ToDouble(Label22.Text) + Convert.ToDouble(Label23.Text) + Convert.ToDouble(Label24.Text) + Convert.ToDouble(Label25.Text)).ToString("F2");


        //租金+运费+赔偿费
        lblTotal.Text = (Convert.ToDouble(lblTransmitFees.Text.ToString().Trim()) + Convert.ToDouble(lblRentFees.Text.ToString().Trim()) + Convert.ToDouble(Label5.Text.ToString().Trim())).ToString("F2");


    }

    public void bind2()
    {
        DataSet ds = dbSql.Query("select * from rentdata where cid =" + cid + " and isout='入库'");

        string sortExpression = this.GridView1.Attributes["SortExpression"];
        string sortDirection = this.GridView1.Attributes["SortDirection"];
        // 调用业务数据获取方法

        // 根据GridView排序数据列及排序方向设置显示的默认数据视图
        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        {
            ds.Tables[0].DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        }


        GridView3.DataSource = ds.Tables[0];
        GridView3.DataBind();
        btnResult.Enabled = true;

        //运费
        Label10.Text = (Convert.ToDouble(lblTubeFright1.Text) * (Convert.ToDouble(Label14.Text) + Convert.ToDouble(Label18.Text))).ToString("F2");
        Label11.Text = (Convert.ToDouble(lblFastenerFright1.Text) * (Convert.ToDouble(Label15.Text) + Convert.ToDouble(Label19.Text))).ToString("F2");
        Label12.Text = (Convert.ToDouble(lblJackingFright1.Text) * (Convert.ToDouble(Label16.Text) + Convert.ToDouble(Label20.Text))).ToString("F2");
        Label13.Text = (Convert.ToDouble(lblSleeveFright1.Text) * (Convert.ToDouble(Label17.Text) + Convert.ToDouble(Label21.Text))).ToString("F2");


        lblTransmitFees.Text = (Convert.ToDouble(Label11.Text) + Convert.ToDouble(Label12.Text) + Convert.ToDouble(Label13.Text) + Convert.ToDouble(Label10.Text)).ToString("F2");

        //赔偿
        Label22.Text = (Convert.ToDouble(lblTubeFright2.Text) * (Convert.ToDouble(Label1.Text))).ToString("F2");
        Label23.Text = (Convert.ToDouble(lblFastenerFright2.Text) * (Convert.ToDouble(Label2.Text))).ToString("F2");
        Label24.Text = (Convert.ToDouble(lblJackingFright2.Text) * (Convert.ToDouble(Label3.Text))).ToString("F2");
        Label25.Text = (Convert.ToDouble(lblSleeveFright2.Text) * (Convert.ToDouble(Label4.Text))).ToString("F2");

        Label5.Text = (Convert.ToDouble(Label22.Text) + Convert.ToDouble(Label23.Text) + Convert.ToDouble(Label24.Text) + Convert.ToDouble(Label25.Text)).ToString("F2");


        //租金+运费+赔偿费
        lblTotal.Text = (Convert.ToDouble(lblTransmitFees.Text.ToString().Trim()) + Convert.ToDouble(lblRentFees.Text.ToString().Trim()) + Convert.ToDouble(Label5.Text.ToString().Trim())).ToString("F2");


    }

    /// <summary>
    /// 空则为0
    /// </summary>
    /// <param name="ct"></param>
    protected void ClearControl(ControlCollection ct)
    {

        foreach (Control ctl in ct)
        {
            if (ctl is TextBox)
            {
                TextBox t = (TextBox)ctl;
                if (t.Text == string.Empty) t.Text = "0";
            }
            if (ctl.HasControls())
            {
                ClearControl(ctl.Controls);
            }
        }
    }

    /// <summary>
    /// 清除输入数据
    /// </summary>
    /// <param name="ct"></param>
    protected void ClearControl2()
    {
        tbTube.Text = "";
        tbSleeve.Text = "";
        tbJacking.Text = "";
        tbFastener.Text = "";

    }

    /// <summary>
    /// 导入excel数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Click(object sender, EventArgs e)
    {

        dbSql sd = new dbSql();

        string strpath = "";  //获取Execle文件路径
        string filename = "";          //获取Execle文件名
        //上传excel文件
        #region

        try
        {
            if (fld.HasFile)
            {

                string IsXls = System.IO.Path.GetExtension(fld.FileName).ToString().ToLower();
                if (IsXls != ".xls" && IsXls != ".xlsx") //
                {
                    Response.Write("<script>alert('只可以选择Excel文件')</script>");
                    return;//当选择的不是Excel文件时,返回
                }


                filename = this.fld.FileName;//获取上传文件的文件名,包括后缀
                string ExtenName = System.IO.Path.GetExtension(filename);//获取扩展名
                //string dirstr = Request.PhysicalApplicationPath;

                string uploadTime = DateTime.Now.ToString("yyyyMMddhhmm");
                string SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath("Upload/"), uploadTime + ExtenName);//合并两个路径为上传到服务器上的全路径

                fld.SaveAs(SaveFileName);
                strpath = "Upload/" + uploadTime + ExtenName;  //文件保存的路径
                //float FileSize = (float)System.Math.Round((float)AttachFile.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M

                System.IO.FileInfo file_s = new System.IO.FileInfo(SaveFileName);
                if (file_s.Exists)
                {

                    lblMsg.Text = "文件上传成功！！";
                    DataSet ds = ExecleDs(strpath, filename);//查询xls数据

                    DataRow[] dr = ds.Tables[0].Select();                        //定义一个DataRow数组
                    int rowsnum = ds.Tables[0].Rows.Count;
                    if (rowsnum == 0)
                    {
                        Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
                    }
                    else
                    {

                        lblMsg.Text = "即将插入" + rowsnum + "条数据——";

                        for (int i = 0; i < dr.Length; i++)
                        {

                            decimal rtube, rfastener, rjacking, rsleeve;

                            //插入数据

                            DateTime rtime = getDate(ds.Tables[0].Rows[i]["日期"].ToString());


                            if (ds.Tables[0].Columns.Contains("钢管") && (ds.Tables[0].Rows[i]["钢管"].ToString() != ""))
                                rtube = decimal.Parse(ds.Tables[0].Rows[i]["钢管"].ToString());
                            else rtube = 0;
                            if (ds.Tables[0].Columns.Contains("扣件") && (ds.Tables[0].Rows[i]["扣件"].ToString() != ""))
                                rfastener = decimal.Parse(ds.Tables[0].Rows[i]["扣件"].ToString());
                            else rfastener = 0;
                            if (ds.Tables[0].Columns.Contains("顶托") && (ds.Tables[0].Rows[i]["顶托"].ToString() != ""))
                                rjacking = decimal.Parse(ds.Tables[0].Rows[i]["顶托"].ToString());
                            else rjacking = 0;
                            if (ds.Tables[0].Columns.Contains("套筒") && (ds.Tables[0].Rows[i]["套筒"].ToString() != ""))
                                rsleeve = decimal.Parse(ds.Tables[0].Rows[i]["套筒"].ToString());
                            else rsleeve = 0;

                            string isout = ds.Tables[0].Rows[i]["出入"].ToString();

                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("insert into rentData(");
                            strSql.Append("rtime,rtube,rfastener,rjacking,rsleeve,isout,cid)");
                            strSql.Append(" values (");
                            strSql.Append("@rtime,@rtube,@rfastener,@rjacking,@rsleeve,@isout,@cid)");
                            strSql.Append(";select @@IDENTITY");
                            SqlParameter[] parameters = {
					new SqlParameter("@rtime", SqlDbType.DateTime),
					new SqlParameter("@rtube", SqlDbType.Float,8),
					new SqlParameter("@rfastener", SqlDbType.Float,8),
					new SqlParameter("@rjacking", SqlDbType.Float,8),
					new SqlParameter("@rsleeve", SqlDbType.Float,8),
					new SqlParameter("@isout", SqlDbType.VarChar,4),
					new SqlParameter("@cid", SqlDbType.Int,4)};
                            parameters[0].Value = rtime;
                            parameters[1].Value = rtube;
                            parameters[2].Value = rfastener;
                            parameters[3].Value = rjacking;
                            parameters[4].Value = rsleeve;
                            parameters[5].Value = isout;
                            parameters[6].Value = cid;

                            if (dbSql.boolSql(strSql.ToString(), parameters))
                            {
                                lblMsg.Text = "入库记录保存成功";
                                bind();
                            }
                            else lblMsg.Text += "第" + i + "行数据，" + rtime.ToString() + "提交失败";
                            bind();

                        }

                        lblMsg.Text += "Excle表导入成功!";



                        bind();

                    }
                }

            }
            else
            {
                lblMsg.Text = "请上传正确文件然后进行操作";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text += "\n" + ex.StackTrace;
        }
        #endregion



    }

    public DataSet ExecleDs(string filenameurl, string table)
    {
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "data source=" + Server.MapPath(filenameurl) + ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'";//可操作07，10

        //只能操作xls  string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + Server.MapPath(filenameurl) + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";


        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string tableName = dt.Rows[0][2].ToString().Trim();


        OleDbDataAdapter odda = new OleDbDataAdapter("select * from [" + tableName + "]", conn);
        DataSet ds = new DataSet();
        odda.Fill(ds, table);

        return ds;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Panel2.Visible == true)
            Panel2.Visible = false;
        else
            Panel2.Visible = true;
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
        {
            // 使用<TH>替换<TD>
            GridView1.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            // FooterRow将被<tfoot>包裹
            //GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
        }

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int days = 0;
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Text = (DateTime.Today - Convert.ToDateTime(e.Row.Cells[0].Text)).TotalDays.ToString ();

            days = Convert.ToInt32(e.Row.Cells[5].Text);

            iSum[0] = Convert.ToDouble(e.Row.Cells[1].Text);
            iSum[1] = Convert.ToDouble(e.Row.Cells[2].Text);
            iSum[2] = Convert.ToDouble(e.Row.Cells[3].Text);
            iSum[3] = Convert.ToDouble(e.Row.Cells[4].Text);

            e.Row.Cells[6].Text = ((iSum[0] * Convert.ToDouble(lblTubeFright.Text) + iSum[1] * Convert.ToDouble(lblFastenerFright.Text) + iSum[2] * Convert.ToDouble(lblJackingFright.Text) + Convert.ToDouble(lblSleeveFright.Text) * iSum[3]) * days).ToString("f2");

            iSumTube += iSum[0] ;
            iSumFastener += iSum[1] ;
            iSumJacking += iSum[2] ;
            iSumSleeve += iSum[3];
            totalfei += Convert.ToDouble(e.Row.Cells[6].Text);


            
        }

        else if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[0].Text = "出库合计：";
            e.Row.Cells[1].Text = iSumTube.ToString("f2");
            e.Row.Cells[2].Text = iSumFastener.ToString("f2");
            e.Row.Cells[3].Text = iSumJacking.ToString("f2");
            e.Row.Cells[4].Text = iSumSleeve.ToString("f2");
            e.Row.Cells[6].Text = totalfei.ToString("f2");

            lblChuku.Text = totalfei.ToString("f2");
        
        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int days = 0;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Text = (DateTime.Today - Convert.ToDateTime(e.Row.Cells[0].Text)).TotalDays.ToString();

            days = Convert.ToInt32(e.Row.Cells[5].Text);

            rSum[0] = Convert.ToDouble(e.Row.Cells[1].Text);
            rSum[1] = Convert.ToDouble(e.Row.Cells[2].Text);
            rSum[2] = Convert.ToDouble(e.Row.Cells[3].Text);
            rSum[3] = Convert.ToDouble(e.Row.Cells[4].Text);

            e.Row.Cells[6].Text = ((rSum[0] * Convert.ToDouble(lblTubeFright.Text) + rSum[1] * Convert.ToDouble(lblFastenerFright.Text) + rSum[2] * Convert.ToDouble(lblJackingFright.Text) + Convert.ToDouble(lblSleeveFright.Text) * rSum[3]) * days).ToString("f2");

            rSumTube += rSum[0];
            rSumFastener += rSum[1];
            rSumJacking += rSum[2];
            rSumSleeve += rSum[3];
            totalfei1 += Convert.ToDouble(e.Row.Cells[6].Text);



        }

        else if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[0].Text = "入库合计：";
            e.Row.Cells[1].Text = rSumTube.ToString("f2");
            e.Row.Cells[2].Text = rSumFastener.ToString("f2");
            e.Row.Cells[3].Text = rSumJacking.ToString("f2");
            e.Row.Cells[4].Text = rSumSleeve.ToString("f2");
            e.Row.Cells[6].Text = totalfei1.ToString("f2");
            lblRuku.Text = totalfei1.ToString("f2");
        }
    }
    protected void GridView3_PreRender(object sender, EventArgs e)
    {
        if (GridView3.Rows.Count > 0)
        {
            // 使用<TH>替换<TD>
            GridView3.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
            GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;

            // FooterRow将被<tfoot>包裹
            //GridView3.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void GridView2_PreRender(object sender, EventArgs e)
    {
        if (GridView2.Rows.Count > 0)
        {
            // 使用<TH>替换<TD>
            GridView2.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            //HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
            GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;

            // FooterRow将被<tfoot>包裹
            //GridView2.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}