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
    public static string data = "" , date = "";
    int afare;
    protected void Page_Load(object sender, EventArgs e)
    {
     
        cancel();
        data = "";
        /*try
        {
         
            if (Request.QueryString["date"].ToString() == "")
            {
                date = Request.QueryString["date"].ToString();
            }
            
            else
            {
                date = Request.QueryString["date"].ToString();
                getdata();
            }
        }
        catch
        {

        }*/
        getdata();
        // validate();

    }
   

 
    public string getdata()
    {
        string ddloc = "", aaloc = "", no ="" , cabin = "" ;
        con.Close();
       /* SqlCommand cmd1 = new SqlCommand("select * from ars_ticket where ticket_num = '" + Session["ticket_num"].ToString() + "'", con);
        con.Open();
        dr = cmd1.ExecuteReader();
        if(dr.Read())
        {
            string data = dr["route"].ToString();
            string[] output = data.Split(':');
            ddloc = output[0];
            aaloc = output[1];
            no = dr["Total_passengers"].ToString();
            cabin = dr["class"].ToString();
        }
        con.Close();
        */
       /* try
        {*/
            data = "" ;
        string dloc = "", aloc = "" , dur = "1 Hour and 45 Minutes", clas = "", clas1 = "";
      
            SqlCommand cmd = new SqlCommand("select * from v_ars_flight_ticket where uname = '" + Session["id"].ToString()+ "' and (ars_status != 'Incomplete Booking') and  (ars_status != 'Confirmed')  order by d_date asc", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["airport_code"].ToString() == "AR-KHI-001" && dr["d_airport_code"].ToString() == "AR-ISL-001")
            {
                dloc = "Karachi KHI";
                aloc = "Islamabad ISB";
            }
            else if(dr["airport_code"].ToString() == "AR-ISL-001" && dr["d_airport_code"].ToString() == "AR-KHI-001")
            {
                dloc = "Islamabad ISB";
                aloc = "Karachi KHI";
            }
            else if (dr["airport_code"].ToString() == "AR-KHI-001" && dr["d_airport_code"].ToString() == "AR-LHR-001")
            {
                dloc = "Karachi KHI";
                aloc = "Lahore LHR";
            }
            else if (dr["airport_code"].ToString() == "AR-LHR-001" && dr["d_airport_code"].ToString() == "AR-KHI-001")
            {
                dloc = "Lahore LHR" ;
                aloc = "Karachi KHI";
            }
            else if (dr["airport_code"].ToString() == "AR-ISL-001" && dr["d_airport_code"].ToString() == "AR-LHR-001")
            {
                dloc = "Islamabad ISB";
                aloc = "Lahore LHR";
                dur = "1 Hour";
            }
            else if (dr["airport_code"].ToString() == "AR-LHR-001" && dr["d_airport_code"].ToString() == "AR-ISL-001")
            {
                dloc = "Lahore";
                aloc = "Islamabad";
            }
                else
                {
                  
         
                data = "<td>No Flight Available For " + Request.QueryString["date"].ToString() + "</td>";
            
                }

            if(dr["status"].ToString() == "Active")
            {
                    clas = "success";    
            }
                else if (dr["status"].ToString() == "Delayed")
                {
                    clas = "warning";
                }
                else if (dr["status"].ToString() == "Cancelled")
                {
                    clas = "danger";
                }

                if (dr["ars_status"].ToString() == "Booking Confirmed")
                {
                    clas1 = "success";
                }
                else if (dr["ars_status"].ToString() == "Delayed")
                {
                    clas1 = "warning";
                }
                else if (dr["ars_status"].ToString() == "Cancelled")
                {
                    clas1 = "danger";
                }
                 afare = Convert.ToInt32(dr["total"].ToString());
                data += "<tr><td>" + dr["flight_num"].ToString() + "</td><td> "+ dr["d_date"].ToString() + " " + dr["d_time"].ToString() + "</td> <td>From '" + dloc + "' To '" + aloc + "'&nbsp;<span class='label label-table label-" + clas + "'>" + dr["status"].ToString() + "</span></td><td> " + dr["a_time"].ToString() + " </td><td>" + dur + "</td><td><span class='label label-table label-" + clas + "'>" + dr["status"].ToString() + "</span></td><td><span class='label label-table label-" + clas1 + "'>" + dr["ars_status"].ToString() + "</span></td><td><a href='passenger.aspx?fn=" + dr["ticket_num"].ToString() + "&price=" + afare + "'><span class='label label-table label-success'>View Passenger</span></a>&nbsp;<a href = 'my_flight.aspx?tn=" + dr["ticket_num"].ToString() + "' > &nbsp;<span class='label label-table label-danger'>Cancel Flight</span></a>&nbsp;<a href = 'ticket.aspx?tn=" + dr["ticket_num"].ToString() + "' > &nbsp;<span class='label label-table label-warning'>Make Payment</span></a></td></tr>";
             
            }
            
            con.Close();
            //return v1; return v2; return v3; return v4;// ,v2 ,v3 ,v4;   return v1;
/*}
        catch
        {
        }*/
        return data;
    }
    private void cancel()
    {
        try { 
        
            if (Request.QueryString["tn"].ToString() == "")
            {

            }
            else
            {
                string fn = Request.QueryString["tn"].ToString();
                con.Close();
                SqlCommand cmd = new SqlCommand("update ars_ticket set status = 'Cancelled'  where ticket_num = '" + fn + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                pay_cancel(fn);
                Response.Write("<script>alert('Flight Successfully Cancelled')</script>");
            }
        }
        catch
        {

        }
    }
   private void pay_cancel(string fn)
    {
        string sYear = DateTime.Now.Year.ToString();

         string sMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');

         string sDay = DateTime.Now.Day.ToString().PadLeft(2, '0');

        string x = sYear +"-"+ sMonth + "-" + sDay;
        int total = 0;
        SqlCommand cmd = new SqlCommand("select   DATEDIFF( hour,'"+x+"',d_date) as dif from ars_ticket where ticket_num = '" + fn + "'", con);
        con.Open();
        dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            if(Convert.ToInt32(dr["dif"].ToString()) <= 48)
            {
                total = afare - 2500;
            }
            else if(Convert.ToInt32(dr["dif"].ToString()) > 48)
            {
                total = afare - 1500;
            }
        }
        con.Close();
        SqlCommand cmd1 = new SqlCommand("update wallet set balance = balance +" + total + " where uname = '" + Session["id"] + "' ", con);
        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();
    }
}