    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Member
/// </summary>
public class Member
{
    public string UserName {get;set;}
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Gender { get; set; }
    public DateTime? DateofBirth { get; set; }

	public Member()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void AddMember()
    {
        //Open DB connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();

        //Prepare SQL command with parameter
        string sql = "INSERT INTO Member values(@username, @pwd, @role, @fname, @lname, @gender, @email, @dob)";
        SqlCommand cmd = new SqlCommand(sql, conn);

        //Replace parameter values with object values set in the form
        cmd.Parameters.AddWithValue("username", this.UserName);
        cmd.Parameters.AddWithValue("pwd", this.Password);
        cmd.Parameters.AddWithValue("role", this.Role);
        cmd.Parameters.AddWithValue("fname", this.FirstName);
        cmd.Parameters.AddWithValue("lname", this.LastName);
        cmd.Parameters.AddWithValue("email", this.Email);
        cmd.Parameters.AddWithValue("gender", this.Gender);

        //Checking if DOB has value to add null value in database.
        if (this.DateofBirth.HasValue)
        {
            cmd.Parameters.AddWithValue("dob", this.DateofBirth);
        }
        else
        {
            cmd.Parameters.AddWithValue("dob", DBNull.Value);
        }

        //Execute command
        cmd.ExecuteNonQuery();
    }
}