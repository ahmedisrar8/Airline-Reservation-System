using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
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
        login();
        }
    private void login()
    {
      
        try
        {
            SqlCommand cmd = new SqlCommand("Select * from ars_users where (email = '" + email.Value + "' or uname = '" + email.Value + "' ) and  pass = '" + pass.Value + "' ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["id"] = dr["uname"].ToString();
                Session["Name"] = dr["name"].ToString();
                Session["desg"] = dr["desg"].ToString();
                Response.Redirect("home.aspx");
            }
            else
            {
                error.InnerHtml = "Invalid Username Or Password!";
                con.Close();
            }
        }
        catch
        {
         
        }
     }
    }