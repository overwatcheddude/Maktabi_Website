using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BookDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["id"]!=null)
        {
            int bookid = int.Parse(Request.QueryString["id"]);
           
            dlBooks.DataSource = Book.GetBookByID(bookid);
            dlBooks.DataBind();

            DataTable dr = BookReview.GetReviewsByBook(bookid);
            if (dr.Rows.Count > 0)
            {
                dlReviews.DataSource = BookReview.GetReviewsByBook(bookid);
                dlReviews.DataBind();
            }
            else
            {
                lblExceptionMessage.Text = "There are no reviews for this book";
            }
        }
        else
        {
            Response.Redirect("SearchBook.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Rating2.CurrentRating == 0)
            {
                lblExceptionMessage.Text = "You must enter a rating";
            }
            else
            {
                lblExceptionMessage.Text = "";

                //Get the book id from the query string
                int bookid = int.Parse(Request.QueryString["id"]);

                //Create a new object of type BookReview and set its value
                BookReview review = new BookReview();
                review.BookID = bookid; // querystring value
                review.UserName = "anonymous";  //this will be changed later to the logged in user
                review.Rating = Rating2.CurrentRating; //value from the ajax control

                //comment is not required
                if (String.IsNullOrEmpty(txtComment.Text))
                {
                    review.Comment = "No comment";
                }
                else
                {
                    review.Comment = txtComment.Text;
                }

                //Call the AddReview method
                review.AddReview();

                //Refresh both the datalist to show the latest votes and latest reviews
                dlBooks.DataSource = Book.GetBookByID(bookid);
                dlBooks.DataBind();
                dlReviews.DataSource = BookReview.GetReviewsByBook(bookid);
                dlReviews.DataBind();

                //Clear the inputs
                txtComment.Text = "";
                Rating2.CurrentRating = 0;
            }
        }
        catch (Exception error)
        {
            lblExceptionMessage.Text = "An error has occured! <br>" + error.Message; 
        }
    }
}