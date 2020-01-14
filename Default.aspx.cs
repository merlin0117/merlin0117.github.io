using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public static int cid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["cid"] != null)
            {
                cid = Convert.ToInt32(Request.QueryString["cid"]);

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
                        tbName.Text = row1["cname"].ToString();
                    }
                    if (row1["ctele"] != null && row1["ctele"].ToString() != "")
                    {
                        tbTel.Text = row1["ctele"].ToString();
                    }
                    if (row1["isrentout"] != null && row1["isrentout"].ToString() != "")
                    {
                        DropDownList1.SelectedValue = row1["isrentout"].ToString();
                    }
                }

                //查询日租金
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select  top 1 pid,cid,ptube,pfastener,pjacking,psleeve from unitprice ");
                strSql2.Append(" where cid=@cid");
                strSql2.Append(" order by pid desc");
                SqlParameter[] parameters2 = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
                parameters2[0].Value = cid;

                DataSet ds2 = dbSql.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds2.Tables[0].Rows[0];
                    if (row != null)
                    {
                        if (row["ptube"] != null && row["ptube"].ToString() != "")
                        {
                            tbTubeUnitPrice.Text = row["ptube"].ToString();
                        }
                        if (row["pfastener"] != null && row["pfastener"].ToString() != "")
                        {
                            tbFastenerUnitPrice.Text = row["pfastener"].ToString();
                        }
                        if (row["pjacking"] != null && row["pjacking"].ToString() != "")
                        {
                            tbJackingUnitPrice.Text = row["pjacking"].ToString();
                        }
                        if (row["psleeve"] != null && row["psleeve"].ToString() != "")
                        {
                            tbSleeveUnitPrice.Text = row["psleeve"].ToString();
                        }
                    }
                }


                //查询运费单价
                StringBuilder strSql3 = new StringBuilder();
                strSql3.Append("select  top 1 fid,cid,ftube,ffastener,fjacking,fsleeve from freight  ");
                strSql3.Append(" where cid=@cid");
                strSql3.Append(" order by fid desc");
                SqlParameter[] parameters3 = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
                parameters3[0].Value = cid;

                DataSet ds3 = dbSql.Query(strSql3.ToString(), parameters3);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds3.Tables[0].Rows[0];
                    if (row != null)
                    {
                        if (row["ftube"] != null && row["ftube"].ToString() != "")
                        {
                            tbTubeFright.Text = row["ftube"].ToString();
                        }
                        if (row["ffastener"] != null && row["ffastener"].ToString() != "")
                        {
                            tbFastenerFright.Text = row["ffastener"].ToString();
                        }
                        if (row["fjacking"] != null && row["fjacking"].ToString() != "")
                        {
                            tbJackingFright.Text = row["fjacking"].ToString();
                        }
                        if (row["fsleeve"] != null && row["fsleeve"].ToString() != "")
                        {
                            tbSleeveFright.Text = row["fsleeve"].ToString();
                        }
                    }
                }

                //查询赔偿单价
                StringBuilder strSql4 = new StringBuilder();
                strSql4.Append("select  top 1 mid,cid,mtube,mfastener,mjacking,msleeve from compensation  ");
                strSql4.Append(" where cid=@cid");
                strSql4.Append(" order by mid desc");
                SqlParameter[] parameters4 = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
                parameters4[0].Value = cid;

                DataSet ds4 = dbSql.Query(strSql4.ToString(), parameters4);
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds4.Tables[0].Rows[0];
                    if (row != null)
                    {
                        if (row["mtube"] != null && row["mtube"].ToString() != "")
                        {
                            tbMtube.Text = row["mtube"].ToString();
                        }
                        if (row["mfastener"] != null && row["mfastener"].ToString() != "")
                        {
                            tbMfastener.Text = row["mfastener"].ToString();
                        }
                        if (row["mjacking"] != null && row["mjacking"].ToString() != "")
                        {
                            tbMjacking.Text = row["mjacking"].ToString();
                        }
                        if (row["msleeve"] != null && row["msleeve"].ToString() != "")
                        {
                            tbMsleeve.Text = row["msleeve"].ToString();
                        }
                    }
                }


            }
        }
    }

    protected void btnName_Click(object sender, EventArgs e)
    {
        if (tbName.Text.Trim().Length == 0) { lblMsg.Text = "工地名称不能为空"; }
        else
        {
            string isRentOut = DropDownList1.SelectedItem.Text;

            StringBuilder str = new StringBuilder();

            str.Append("INSERT INTO [tubeCal].[dbo].[customer] ([cname]   ,[ctele] ,[isRentOut]  )  VALUES   (@cname,    @ctele,@isRentOut);select @@IDENTITY");
            SqlParameter[] para = { new SqlParameter("@cname", SqlDbType.VarChar, 50), new SqlParameter("@ctele", SqlDbType.VarChar, 12), new SqlParameter("@isRentOut", SqlDbType.VarChar, 10) };
            para[0].Value = tbName.Text.Trim();

            if (tbTel.Text.Trim().Length == 0) para[1].Value = 0;
            else para[1].Value = tbTel.Text.Trim();

            para[2].Value = isRentOut;

            DataSet ds = dbSql.Query(str.ToString(), para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "基本信息保存成功";
                cid = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                hlNext.NavigateUrl = "~/EnterData.aspx?cid=" + cid;
            }
            else lblMsg.Text = "未提交，请稍后再试";


        }
    }

    protected void btnAlter_Click(object sender, EventArgs e)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update customer set ");
        strSql.Append("cname=@cname,");
        strSql.Append("ctele=@ctele,");
        strSql.Append("isRentOut=@isRentOut");
        strSql.Append(" where cid=@cid");
        SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.VarChar,50),
					new SqlParameter("@ctele", SqlDbType.VarChar,12),
                    new SqlParameter("@isRentOut", SqlDbType.VarChar, 10),
					new SqlParameter("@cid", SqlDbType.Int,4)};

        if (tbName.Text.Trim().Length == 0) { lblMsg.Text = "工地名称不能为空"; }
        else
        {

            string isRentOut = DropDownList1.SelectedItem.Text;
            parameters[0].Value = tbName.Text.Trim();

            if (tbTel.Text.Trim().Length == 0) parameters[1].Value = 0;
            else parameters[1].Value = tbTel.Text.Trim();
            parameters[2].Value = isRentOut;
            parameters[3].Value = cid;


            if (dbSql.boolSql(strSql.ToString(), parameters)) lblMsg.Text = "工地名称信息更新成功";
            else lblMsg.Text = "工地名称信息更新失败";
        }


    }
    protected void btnUnit_Click(object sender, EventArgs e)
    {
        decimal ptube = decimal.Parse(this.tbTubeUnitPrice.Text);
        decimal pfastener = decimal.Parse(this.tbFastenerUnitPrice.Text);
        decimal pjacking = decimal.Parse(this.tbJackingUnitPrice.Text);
        decimal psleeve = decimal.Parse(this.tbSleeveUnitPrice.Text);

        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into unitprice(");
        strSql.Append("cid,ptube,pfastener,pjacking,psleeve)");
        strSql.Append(" values (");
        strSql.Append("@cid,@ptube,@pfastener,@pjacking,@psleeve)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@ptube", SqlDbType.Float,8),
					new SqlParameter("@pfastener", SqlDbType.Float,8),
					new SqlParameter("@pjacking", SqlDbType.Float,8),
					new SqlParameter("@psleeve", SqlDbType.Float,8)};
        parameters[0].Value = cid;
        parameters[1].Value = ptube;
        parameters[2].Value = pfastener;
        parameters[3].Value = pjacking;
        parameters[4].Value = psleeve;


        if (dbSql.boolSql(strSql.ToString(), parameters))
        {
            lblMsg.Text = "日租金率保存成功";
            Image2.Visible = true;

        }
        else lblMsg.Text = "未提交，请稍后再试";

    }
    protected void btnAlter2_Click(object sender, EventArgs e)
    {
        decimal ptube = decimal.Parse(this.tbTubeUnitPrice.Text);
        decimal pfastener = decimal.Parse(this.tbFastenerUnitPrice.Text);
        decimal pjacking = decimal.Parse(this.tbJackingUnitPrice.Text);
        decimal psleeve = decimal.Parse(this.tbSleeveUnitPrice.Text);


        StringBuilder strSql = new StringBuilder();
        strSql.Append("update unitprice set ");
        strSql.Append("ptube=@ptube,");
        strSql.Append("pfastener=@pfastener,");
        strSql.Append("pjacking=@pjacking,");
        strSql.Append("psleeve=@psleeve");
        strSql.Append(" where cid=@cid");
        SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@ptube", SqlDbType.Float,8),
					new SqlParameter("@pfastener", SqlDbType.Float,8),
					new SqlParameter("@pjacking", SqlDbType.Float,8),
					new SqlParameter("@psleeve", SqlDbType.Float,8)};
        parameters[0].Value =cid;
        parameters[1].Value = ptube;
        parameters[2].Value = pfastener;
        parameters[3].Value = pjacking;
        parameters[4].Value = psleeve;

            if (dbSql.boolSql(strSql.ToString(), parameters)) lblMsg.Text = "日租金率更新成功";
            else lblMsg.Text = "日租金率更新失败";
       
    }
    protected void btnFreight_Click(object sender, EventArgs e)
    {
        decimal ftube = decimal.Parse(this.tbTubeFright.Text);
        decimal ffastener = decimal.Parse(this.tbFastenerFright.Text);
        decimal fjacking = decimal.Parse(this.tbJackingFright.Text);
        decimal fsleeve = decimal.Parse(this.tbSleeveFright.Text);


        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into freight(");
        strSql.Append("cid,ftube,ffastener,fjacking,fsleeve)");
        strSql.Append(" values (");
        strSql.Append("@cid,@ftube,@ffastener,@fjacking,@fsleeve)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@ftube", SqlDbType.Float,8),
					new SqlParameter("@ffastener", SqlDbType.Float,8),
					new SqlParameter("@fjacking", SqlDbType.Float,8),
					new SqlParameter("@fsleeve", SqlDbType.Float,8)};
        parameters[0].Value = cid;
        parameters[1].Value = ftube;
        parameters[2].Value = ffastener;
        parameters[3].Value = fjacking;
        parameters[4].Value = fsleeve;

        if (dbSql.boolSql(strSql.ToString(), parameters))
        {
            lblMsg.Text = "运费单价保存成功"; Image2.Visible = true;

        }
        else lblMsg.Text = "未提交，请稍后再试";


    }
    protected void btnAlter3_Click(object sender, EventArgs e)
    {
        decimal ftube = decimal.Parse(this.tbTubeFright.Text);
        decimal ffastener = decimal.Parse(this.tbFastenerFright.Text);
        decimal fjacking = decimal.Parse(this.tbJackingFright.Text);
        decimal fsleeve = decimal.Parse(this.tbSleeveFright.Text);

       StringBuilder strSql=new StringBuilder();
			strSql.Append("update freight set ");
			strSql.Append("ftube=@ftube,");
			strSql.Append("ffastener=@ffastener,");
			strSql.Append("fjacking=@fjacking,");
			strSql.Append("fsleeve=@fsleeve");
			strSql.Append(" where cid=@cid");
            SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@ftube", SqlDbType.Float,8),
					new SqlParameter("@ffastener", SqlDbType.Float,8),
					new SqlParameter("@fjacking", SqlDbType.Float,8),
					new SqlParameter("@fsleeve", SqlDbType.Float,8)};
			parameters[0].Value = cid;
			parameters[1].Value = ftube;
			parameters[2].Value = ffastener;
			parameters[3].Value = fjacking;
			parameters[4].Value = fsleeve;


            if (dbSql.boolSql(strSql.ToString(), parameters))
                lblMsg.Text = "运费单价更新成功";
            else lblMsg.Text = "运费单价信息更新失败";
        
    }
    protected void btnCompensate_Click(object sender, EventArgs e)
    {
        decimal ftube = decimal.Parse(this.tbMtube.Text);
        decimal ffastener = decimal.Parse(this.tbMfastener.Text);
        decimal fjacking = decimal.Parse(this.tbMjacking.Text);
        decimal fsleeve = decimal.Parse(this.tbMsleeve.Text);


        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into compensation(");
        strSql.Append("cid,mtube,mfastener,mjacking,msleeve)");
        strSql.Append(" values (");
        strSql.Append("@cid,@ftube,@ffastener,@fjacking,@fsleeve)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@ftube", SqlDbType.Float,8),
					new SqlParameter("@ffastener", SqlDbType.Float,8),
					new SqlParameter("@fjacking", SqlDbType.Float,8),
					new SqlParameter("@fsleeve", SqlDbType.Float,8)};
        parameters[0].Value = cid;
        parameters[1].Value = ftube;
        parameters[2].Value = ffastener;
        parameters[3].Value = fjacking;
        parameters[4].Value = fsleeve;

        if (dbSql.boolSql(strSql.ToString(), parameters))
        {
            lblMsg.Text = "赔偿单价保存成功"; Image2.Visible = true;

        }
        else lblMsg.Text = "未提交，请稍后再试";

    }
    protected void btnAlter4_Click(object sender, EventArgs e)
    {
        decimal ftube = decimal.Parse(this.tbMtube.Text);
        decimal ffastener = decimal.Parse(this.tbMfastener.Text);
        decimal fjacking = decimal.Parse(this.tbMjacking.Text);
        decimal fsleeve = decimal.Parse(this.tbMsleeve.Text);

        StringBuilder strSql = new StringBuilder();
        strSql.Append("update compensation set ");
        strSql.Append("mtube=@ftube,");
        strSql.Append("mfastener=@ffastener,");
        strSql.Append("mjacking=@fjacking,");
        strSql.Append("msleeve=@fsleeve");
        strSql.Append(" where cid=@cid");
        SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@ftube", SqlDbType.Float,8),
					new SqlParameter("@ffastener", SqlDbType.Float,8),
					new SqlParameter("@fjacking", SqlDbType.Float,8),
					new SqlParameter("@fsleeve", SqlDbType.Float,8)};
        parameters[0].Value = cid;
        parameters[1].Value = ftube;
        parameters[2].Value = ffastener;
        parameters[3].Value = fjacking;
        parameters[4].Value = fsleeve;


        if (dbSql.boolSql(strSql.ToString(), parameters))
            lblMsg.Text = "赔偿单价更新成功";
        else lblMsg.Text = "赔偿单价信息更新失败";
    }
}