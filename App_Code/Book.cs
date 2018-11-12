using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class Book
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? Year { get; set; }
    public string Author { get; set; }
    public int CategoryID { get; set; }
    public string CoverPhoto { get; set; }
    public int AvgRating { get; set; }
    public int Votes { get; set; }

   
    public static DataTable GetAllBooks()
    { 
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr(); // this is the method you created in step 2.1
        conn.Open();

        //Prepare SQL Command
        string sql = "Select * from vwBookWithRating";
        SqlCommand cmd = new SqlCommand(sql, conn);

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

    public static DataTable GetBookByID(int BookID) 
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr(); 
        conn.Open();

        //Prepare SQL Command with parameter
        string sql = "Select * from vwBookWithRating Where BookID = @id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id",BookID); // set the parameter value to the BookID that is sent to the method

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

    public static DataTable GetBookByTitle(string Title)
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();

        //Prepare SQL Command with parameter
        string sql = "Select * from vwBookWithRating Where Title like @title";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("title", "%"+Title+"%"); // set the parameter value to the BookID that is sent to the method

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

    public static DataTable GetBookByCategoryID(int CategoryID)
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();

        //Prepare SQL Command with parameter
        string sql = "Select * from vwBookWithRating Where CategoryID = @catid";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("catid", CategoryID); 

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

    public static DataTable GetBookByCategoryID(string CategoryID, string sortColumn)
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();

        //Prepare SQL Command with parameter
        string sortOrder = "";
        if (sortColumn == "avgRating")
            sortOrder = "DESC";
        else
            sortOrder = "ASC";
        string sql = "Select * from vwBookWithRating Where CategoryID = @catid order by " + sortColumn + " " + sortOrder;
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("catid", CategoryID);

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

    public void UpdateBook()
    {
        //Open database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();

        //Prepare SQL command with parameter
        string sql = @"UPDATE book SET
                        title = @title,
                        year = @year,
                        author = @author,
                        description = @description,
                        categoryid = @category,
                        coverphoto = @coverphoto
                        WHERE bookid = @bookid";

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("title", this.Title);
        cmd.Parameters.AddWithValue("category", this.CategoryID);
        cmd.Parameters.AddWithValue("coverphoto", this.CoverPhoto);
        cmd.Parameters.AddWithValue("bookid", this.BookID);
        cmd.Parameters.AddWithValue("description", this.Description);
        cmd.Parameters.AddWithValue("author", this.Author);

        //Handling null values for columns that allow null values - Year
        if (this.Year != null)
        {
            cmd.Parameters.AddWithValue("year", this.Year);
        }
        else
        {
            cmd.Parameters.AddWithValue("year", DBNull.Value);
        }

        //Execute command
        cmd.ExecuteNonQuery();
    }

    public Book()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}