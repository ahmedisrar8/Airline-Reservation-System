using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pixeladmin_lite_html_b_flight : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apptrive"].ConnectionString);
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if(dept.Value == arri.Value)
        {
            error.InnerText = "Departure city cannot be the same as arrival city";
        }
        else
        { string date = date1.Text;
        string cabin = Cabin.Value;
        string adult = Adult.Value;
        string child = Child.Value;
        string infant = Infant.Value;
        Random rnd = new Random();
        string num = "tk-" + rnd.Next(100, 1000).ToString();
        Session["ticket_num"] = num;
            if (child == "none" && infant == "none")
            {
                child = "0";
                infant = "0";
              //  Response.Write(infant + child);
            }

     else if (child == "none" )
        {
            child = "0";

        }
        else if(infant == "none")
            {
                infant = "0";
            }
       
        
        int total = Convert.ToInt32(adult) + Convert.ToInt32(child) + Convert.ToInt32(infant);
        SqlCommand cmd = new SqlCommand("insert into ars_ticket(ticket_num,Total_passengers,adults,child,infant,class,status,route,date,d_date,uname) values ('" + num + "'," + total + "," + adult + "," + child + "," + infant + ",'" + cabin + "','Incomplete Booking','"+ dept.Value + ":"+ arri.Value + "',getdate(),'"+ date + "','"+Session["id"]+"')", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("find_flight.aspx?date=" + date); }
    }
}