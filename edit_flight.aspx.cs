using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
public partial class edit : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apptrive"].ConnectionString);
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //time1.Text
        string times = time1.Text.ToString();
        DateTime date = Convert.ToDateTime(times);
        TimeSpan time = new TimeSpan(0, 0, 105, 0);
        DateTime combined = date.Add(time);
        string atime = combined.ToString("hh:mm tt");
        string dtime = date.ToString("hh:mm tt");
       string fn = Request.QueryString["fn"].ToString();
        con.Close();
        SqlCommand cmd = new SqlCommand("update ars_flights set status = 'Delayed' , d_time='"+dtime+"' , a_time = '"+atime+"'  where flight_num = '" + fn + "'", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    } 
}