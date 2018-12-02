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
    protected static string data1 = "" , date = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
        //cancel();
        //data1 = "";
        data1 = "";
        try
        {
         
            if (Request.QueryString["fn"].ToString() == "")
            {
                date = Request.QueryString["fn"].ToString();
            }
            
            else
            {
               date = Request.QueryString["fn"].ToString();
                //getdata(Request.QueryString["fn"].ToString(), Request.QueryString["price"].ToString());
            }
        }
        catch
        {

        }
        getdata(Request.QueryString["fn"].ToString(), Request.QueryString["price"].ToString());
    }



 
    public string getdata(string fn , string price)
    {
       
        string ddloc = "", aaloc = "", no ="" , cabin = "" ;
        con.Close();
        SqlCommand cmd1 = new SqlCommand("select * from ars_ticket where flight_num = '" + fn + "' and status = 'Confirmed'", con);
        con.Open();
        dr = cmd1.ExecuteReader();
        while (dr.Read())
        {
            string data = dr["route"].ToString();
            string[] output = data.Split(':');
            ddloc = output[0];
            aaloc = output[1];
            no = dr["Total_passengers"].ToString();
            cabin = dr["class"].ToString();
            int afare = Convert.ToInt32(price);



            data = "";
            string dloc = "", aloc = "", clas = "";


            if (ddloc == "AR-KHI-001" && aaloc == "AR-ISL-001")
            {
                dloc = "Karachi KHI";
                aloc = "Islamabad ISB";
            }
            else if (ddloc == "AR-ISL-001" && aaloc == "AR-KHI-001")
            {
                dloc = "Islamabad ISB";
                aloc = "Karachi KHI";
            }
            else if (ddloc == "AR-KHI-001" && aaloc == "AR-LHR-001")
            {
                dloc = "Karachi KHI";
                aloc = "Lahore LHR";
            }
            else if (ddloc == "AR-LHR-001" && aaloc == "AR-KHI-001")
            {
                dloc = "Lahore LHR";
                aloc = "Karachi KHI";
            }
            else if (ddloc == "AR-ISL-001" && aaloc == "AR-LHR-001")
            {
                dloc = "Islamabad ISB";
                aloc = "Lahore LHR";
              
            }
            else if (ddloc == "AR-LHR-001" && aaloc == "AR-ISL-001")
            {
                dloc = "Lahore";
                aloc = "Islamabad";
            }
            else
            {


                data = "<td>No Flight Available For " + Request.QueryString["date"].ToString() + "</td>";

                
            }

            if (dr["status"].ToString() == "Confirmed")
            {
                clas = "success";
            }

            data1 += "<tr><td>" + dr["ticket_num"].ToString() + "</td><td>From '" + dloc + "' To '" + aloc + "' </td><td>" + no + "&nbsp;&nbsp;&nbsp;<span class='label label-table label-" + clas + "'>" + dr["status"].ToString() + "</span></td><td><a href='passenger.aspx?fn=" + dr["ticket_num"].ToString() + "&price="+afare+"'><span class='label label-table label-success'>View Passenger List</span></a></td></tr>";
          
     
        }
            
            con.Close();
        //return v1; return v2; return v3; return v4;// ,v2 ,v3 ,v4;   return v1;

        return data1;
    }
   
   
}