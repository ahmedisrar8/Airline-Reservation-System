using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apptrive"].ConnectionString);
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"].ToString() == "")
            {

            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }
        catch
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        reg();
    }
    private void reg()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("Select * from ars_users where (email = '" + email.Value + "')", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                error.InnerHtml = "Email Already Exists!";
                con.Close();
            }
            else
            {
                con.Close();
                string data = email.Value;
                string[] output = data.Split('@');
                SqlCommand cmd1 = new SqlCommand("insert into ars_users values ('" + output[0] + "','" + email.Value + "','" + name.Value + "','" + password.Value + "',getdate(),'A','C')", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                Session["id"] = output[0];
                Session["Name"] = name.Value;
                Session["desg"] ="C";
                Response.Redirect("home.aspx");
            }


        }
        catch (SqlException ex)
        {
          
        }
    }
    private void sendemail()
    { }

}