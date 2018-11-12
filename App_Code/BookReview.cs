using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class BookReview
{
    public int BookID { get; set; }
    public string UserName { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
  
    public static DataTable GetReviewsByBook(int BookID)
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();

        //Prepare SQL Command with parameter
        string sql = "Select * from BookReview Where BookID = @id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id", BookID); // set the parameter value to the BookID that is sent to the method

        // Create data adapter
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //Create a DataTable that will store the result of the query
        DataTable dt = new DataTable();
        // this will query your database and return the result to your datatable
        da.Fill(dt);

        //Close connection and release the data adapter
        conn.Close();
        da.Dispose();

        //return the Datatable
        return dt;
    }
	public BookReview()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void AddReview()
    {
        //Open DB connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();

        //Prepare SQL command with parameter
        string sql = "INSERT INTO BookReview values(@username, @bookid, @comment, @rating)";
        SqlCommand cmd = new SqlCommand(sql, conn);

        //Replace parameter values with object values set in the form
        cmd.Parameters.AddWithValue("bookid", this.BookID);
        cmd.Parameters.AddWithValue("username", this.UserName);
        cmd.Parameters.AddWithValue("rating", this.Rating);
        cmd.Parameters.AddWithValue("comment", this.Comment);

        //Execute command
        cmd.ExecuteNonQuery();
    }
}