using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }

    public static DataTable GetAllCategories()
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr(); // this is the method you created in step 2.1
        conn.Open();

        //Prepare SQL Command
        string sql = "Select * from Category";
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

    public static DataTable GetCountofBooks()
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr(); // this is the method you created in step 2.1
        conn.Open();

        //Prepare SQL Command
        string sql = "Select * from vwCountsOfBooks";
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
    public Category()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}