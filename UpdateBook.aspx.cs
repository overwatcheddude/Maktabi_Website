using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UpdateBook : System.Web.UI.Page
{
    private void DisplaySelectedBook()
    {
        int bookid = int.Parse(Request.QueryString["bookid"]);
        DataTable bookTable = Book.GetBookByID(bookid);

        if (bookTable.Rows.Count == 0)
        {
            lblMessage.Text = "Book Not Found";
            pnlDetails.Visible = false;
        }
        else
        {
            lblMessage.Text = "";
            pnlDetails.Visible = true;

            //Display data from 1st row (Rows[0]) of bookTable, each column value is displayed in appropriate control
            lblBookID.Text = bookTable.Rows[0]["BookID"].ToString();
            txtTitle.Text = bookTable.Rows[0]["Title"].ToString();
            txtYear.Text = bookTable.Rows[0]["Year"].ToString();
            txtDescription.Text = bookTable.Rows[0]["Description"].ToString();
            txtAuthor.Text = bookTable.Rows[0]["Author"].ToString();

            ddlCategory.SelectedValue = bookTable.Rows[0]["categoryid"].ToString();
            imgCoverPhoto.ImageUrl = "images/" + bookTable.Rows[0]["coverphoto"].ToString();
            imgCoverPhoto.DescriptionUrl = bookTable.Rows[0]["coverphoto"].ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //display all categories from category table only the first time page is loaded
        if (!Page.IsPostBack)
        {
            DataTable dt = Category.GetAllCategories();
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();

            DisplaySelectedBook();
        }
    }
  
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
            {
                if (Page.IsValid)
                {
                    //Create a new book object
                    Book book = new Book();

                    //Read all required values from the controls
                    book.BookID = int.Parse(lblBookID.Text);
                    book.Title = txtTitle.Text;
                    book.CategoryID = int.Parse(ddlCategory.SelectedValue);
                    book.Description = txtDescription.Text;
                    book.Author = txtAuthor.Text;

                    if (String.IsNullOrEmpty(txtYear.Text))
                    {
                        book.Year = null;
                    }
                    else
                    {
                        book.Year = int.Parse(txtYear.Text);
                    }
                    //Check if file has been selected
                    if (upCoverPhoto.HasFile)
                    {
                        //call method to upload picture, method returns the new file name
                        book.CoverPhoto = UploadPicture();
                    }
                    else
                    {
                        //Take existing image name
                        book.CoverPhoto = imgCoverPhoto.DescriptionUrl;
                    }
                    //Call the method that will run the update SQL command and save changes in the database
                    book.UpdateBook();

                    //Hide form and display success message
                    pnlDetails.Visible = false;
                    lblMessage.Text = "Book Record Updated";
                    lblBookID.Text = "";
                }
            }
            catch (Exception err)
            {
                lblMessage.Text = "An Error has occured " + err.Message;
            }
        }
        
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
    }

    private string UploadPicture()
    {
        string fileName = upCoverPhoto.PostedFile.FileName;
        string fileExtension = System.IO.Path.GetExtension(fileName);

        //CHECK THIS
        string newFileName = lblBookID.Text + fileExtension;
        upCoverPhoto.SaveAs(Server.MapPath("~/images/" + newFileName));
        upCoverPhoto.SaveAs(Server.MapPath("~/images/thumb/") + newFileName);

        return newFileName;
    }
}