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
    protected static string data = "" , date = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        cancel();
        try
        {
            //validate();
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
        


    }
    private void validate()
    {
        con.Close();
        SqlCommand cmd = new SqlCommand("select * from ars_flights where d_date = '"+ date1.Text + "'", con);
        con.Open();
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.Redirect("view_schedule.aspx?date=" + date1.Text);
        }
        else
        {
            Response.Redirect("gen.aspx?date="+ date1.Text+ "&page=view_schedule");
        }
        con.Close();
    }


    protected void date1_TextChanged(object sender, EventArgs e)
    {
       validate();

    }
    public string getdata()
    {


        try
        {
            data = "" ;
        string dloc = "", aloc = "" , dur = "1 Hour and 45 Minutes", clas = "";
        con.Close();
            SqlCommand cmd = new SqlCommand("select * from ars_flights where d_date = '"+ Request.QueryString["date"].ToString() + "' order by sno asc", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
            if(dr["airport_code"].ToString() == "AR-KHI-001" && dr["d_airport_code"].ToString() == "AR-ISL-001")
            {
                dloc = "Karachi";
                aloc = "Islamabad";
            }
            else if(dr["airport_code"].ToString() == "AR-ISL-001" && dr["d_airport_code"].ToString() == "AR-KHI-001")
            {
                dloc = "Islamabad";
                aloc = "Karachi";
            }
            else if (dr["airport_code"].ToString() == "AR-KHI-001" && dr["d_airport_code"].ToString() == "AR-LHR-001")
            {
                dloc = "Karachi";
                aloc = "Lahore";
            }
            else if (dr["airport_code"].ToString() == "AR-LHR-001" && dr["d_airport_code"].ToString() == "AR-KHI-001")
            {
                dloc = "Lahore";
                aloc = "Karachi";
            }
            else if (dr["airport_code"].ToString() == "AR-ISL-001" && dr["d_airport_code"].ToString() == "AR-LHR-001")
            {
                dloc = "Islamabad";
                aloc = "Lahore";
                dur = "1 Hour";
            }
            else if (dr["airport_code"].ToString() == "AR-LHR-001" && dr["d_airport_code"].ToString() == "AR-ISL-001")
            {
                dloc = "Lahore";
                aloc = "Islamabad";
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
                data += "<tr><td>"+dr["flight_num"].ToString() + "</td><td>" + dr["d_time"].ToString() + "</td> <td>From '" + dloc+"' To '"+aloc+ "'&nbsp;<span class='label label-table label-" + clas + "'>" + dr["status"].ToString() + "</span></td><td> " + dr["a_time"].ToString()+" </td><td>"+dur+"</td><td>Rs "+dr["price"].ToString()+" </td><td><span class='label label-table label-"+clas+"'>"+dr["status"].ToString()+"</span></td><td><a href='edit_flight.aspx?fn="+dr["flight_num"].ToString()+ "'><span class='label label-table label-success'>Edit</span></a><a href='view_schedule.aspx?fn=" + dr["flight_num"].ToString() + "&date="+ Request.QueryString["date"].ToString() + "'>&nbsp;<span class='label label-table label-danger'>Cancel Flight</span></a>&nbsp;<a href='booking.aspx?fn=" + dr["flight_num"].ToString() + "&price=" + dr["price"].ToString() + "'><span class='label label-table label-warning'>View Bookings</span></a>&nbsp;<a href='tickets.aspx?fn=" + dr["flight_num"].ToString() + "&price=" + dr["price"].ToString() + "'><span class='label label-table label-success'>View Confirmed Tickets</span></a></td></tr>";
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
