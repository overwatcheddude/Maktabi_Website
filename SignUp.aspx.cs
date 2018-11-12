using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid) //Assuming you have done validations using validation controls
            {
                //Create a new object of type Member and set all it's properties to value from controls
                Member user = new Member();

                //Reading required values
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.UserName = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.Email = txtEmail.Text;
                user.Gender = rdoGender.SelectedValue;
                user.Role = "M"; // M stands for Member

                //Reading values that allow NULL in the database (date of birth)
                if (!string.IsNullOrEmpty(txtDOB.Text))
                {
                    user.DateofBirth = DateTime.Parse(txtDOB.Text);
                }

                //Call the AddMember method
                user.AddMember();

                //Redirect the user to home page
                Response.Redirect("default.aspx");
            }
        }
        catch (Exception error)
        {
            lblExceptionMessage.Text = "An error has occured! <br>" + error.Message;
        }
    }
}