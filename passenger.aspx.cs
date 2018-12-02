using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
public partial class view_schedule : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apptrive"].ConnectionString);
    SqlDataReader dr;
    public static string data2 = "" , date = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        data2 = "";
        //cancel();
        try
        {
         
            if (Request.QueryString["fn"].ToString() == "")
            {
                date = Request.QueryString["fn"].ToString();
            }
            
            else
            {
               date = Request.QueryString["fn"].ToString();
               
            }
        }
        catch
        {

        }
        getdata(Request.QueryString["fn"].ToString(), Request.QueryString["price"].ToString());

    }



 
    public string getdata(string fn, string price)
    {
      
            SqlCommand cmd1 = new SqlCommand("select * from ars_flight_passenger where ticket_num = '" + Request.QueryString["fn"].ToString() + "'", con);
        con.Open();
        dr = cmd1.ExecuteReader();
            int i = 1;
            while (dr.Read())
            {
                int afare = Convert.ToInt32(price);
                if (dr["type"].ToString() == "Child")
                {
                    afare = afare - 1000;
                }
                else if (dr["type"].ToString() == "Infant")
                {
                    afare = afare / 2;
                }
            //    Response.Write("<script>alert()</script>");
                data2 += "<tr><td>"+i+"</td><td>"+dr["pass_name"].ToString()+ "</td><td>" + dr["pass_mob"].ToString() + "</td><td>PKR " + afare + "</td><td>" + dr["seats"].ToString() + "</td></tr>";
                i++;
            }
        
            
            con.Close();
        //return v1; return v2; return v3; return v4;// ,v2 ,v3 ,v4;   return v1;

        return data2;
    }
  
   
}