using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BooksByCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     //if this is the first time page is requested
        if (!IsPostBack)
        {
            DataTable dtCategories = Category.GetAllCategories();
            ddlCategories.DataSource = dtCategories;
            ddlCategories.DataTextField = "CategoryName";
            ddlCategories.DataValueField = "CategoryID";
            ddlCategories.DataBind();
        }
       
            string id = ddlCategories.SelectedValue;
            string sortcolumn = rdoSort.SelectedValue;

            DataTable dt = Book.GetBookByCategoryID(id, sortcolumn);
            dlBooks.DataSource = dt;
            dlBooks.DataBind();
          
   
       
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}