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

    protected void Page_Load(object sender, EventArgs e)
    {
        cancel();
        try
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

        }

        validate();

    }
    private void validate()
    {
        con.Close();
        SqlCommand cmd = new SqlCommand("select * from ars_flights where d_date = '"+ date + "'", con);
        con.Open();
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            //Response.Redirect("find_flight.aspx?date=" + date);
        }
        else
        {
            Response.Redirect("gen.aspx?date="+ date + "&page=find_flight");
        }
        con.Close();
    }


 
    public string getdata()
    {
        string ddloc = "", aaloc = "", no ="" , cabin = "" ;
        con.Close();
        SqlCommand cmd1 = new SqlCommand("select * from ars_ticket where ticket_num = '" + Session["ticket_num"].ToString() + "'", con);
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

        try
        {
            data = "" ;
        string dloc = "", aloc = "" , dur = "1 Hour and 45 Minutes", clas = "";
      
            SqlCommand cmd = new SqlCommand("select * from ars_flights where d_date = '"+ Request.QueryString["date"].ToString() + "' and airport_code = '"+ ddloc + "' and   d_airport_code = '" + aaloc + "' and status != 'Took Off' order by sno asc", con);
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
            
                    data += "<tr><td>" + dr["flight_num"].ToString() + "</td><td>" + dr["d_time"].ToString() + "</td> <td>From '" + dloc + "' To '" + aloc + "'&nbsp;<span class='label label-table label-" + clas + "'>" + dr["status"].ToString() + "</span></td><td> " + dr["a_time"].ToString() + " </td><td>" + dur + "</td><td>Rs " + dr["price"].ToString() + " </td><td><span class='label label-table label-" + clas + "'>" + dr["status"].ToString() + "</span></td><td><a href='t_info.aspx?fn=" + dr["flight_num"].ToString() + "'><span class='label label-table label-success'>Continue</span></a></td></tr>";
             
            }
            
            con.Close();
            //return v1; return v2; return v3; return v4;// ,v2 ,v3 ,v4;   return v1;
        }
        catch
        {
        }
        return data;
    }
    private void cancel()
    {
        try
        {
            if (Request.QueryString["fn"].ToString() == "")
            {

            }
            else
            {
                string fn = Request.QueryString["fn"].ToString();
                con.Close();
                SqlCommand cmd = new SqlCommand("update ars_flights set status = 'Cancelled'  where flight_num = '" + fn + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch
        {

        }
    }
   
}