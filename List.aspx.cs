using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class List : System.Web.UI.Page
{
    double mysum1 = 0; 


    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }


    public void bind()
    {
        DataSet ds = dbSql.Query("select * from customer ");

        //排序
        DataView tableview = ds.Tables[0].DefaultView;
        tableview.Sort="cid desc";




        GridView1.DataSource = tableview;
        GridView1.DataBind();
       

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView myrows = (DataRowView)e.Row.DataItem;
           
            if (myrows[3].ToString() != "")
            {
              if(e.Row.Cells[1].Text=="租出")               
                
                mysum1 += Convert.ToDouble(myrows[3].ToString());
              else if(e.Row.Cells[1].Text=="租入")
                  mysum1 -= Convert.ToDouble(myrows[3].ToString());
            
            }          
            
            else
                mysum1 += 0;
        }
        // 合计
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计";
            e.Row.Cells[3].Text = mysum1.ToString();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlstr = "delete from customer where cid='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";

        DataSet ds = dbSql.Query(sqlstr);

        
        bind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }
}