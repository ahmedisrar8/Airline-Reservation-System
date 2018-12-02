using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apptrive"].ConnectionString);
    SqlDataReader dr;
    protected static string bal = "" , stat= "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            f_bal();
        }
        catch
        {
            Response.Redirect("default.aspx");
        }
    }
    private void f_bal()
    {
        SqlCommand cmd = new SqlCommand("select * from wallet where uname = '"+Session["id"].ToString()+"'",con);
        con.Open();
        dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            if(dr["balance"].ToString() == "0")
            {
                bal = "0";
            }
            else
            {
                bal = dr["balance"].ToString();
                
            }
            stat = "A";
        }
        else
        {
            bal = "0";
            stat = "D";
        }
        con.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Random rnd = new Random();
        int total = Convert.ToInt32(bal) + Convert.ToInt32(t.Text);
        bal = total.ToString();
        if (stat == "D")
        {
            SqlCommand cmd = new SqlCommand("insert into wallet values('BAWAlLET" + rnd.Next(100, 1000) + "','" + Session["id"] + "','" + total + "','" + cardn.Text + "','" + cvc.Text + "','" + ex.Text + "','A');", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            SqlCommand cmd = new SqlCommand("update wallet set balance = balance +"+t.Text+" where uname = '"+Session["id"]+"'", con);
            t.Text = "";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
           
        }
    }
}