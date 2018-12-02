using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ticket : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apptrive"].ConnectionString);
    SqlDataReader dr;
        
    protected static string f_no, b_date, b_e_date, dloc,aloc,dtime,atime,ddate,data,t_no = "",msg = "";
    public static int total;
    string bal = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        data = "";
        try
        {
            if(Request.QueryString["tn"] != "" )
            {
            t_no = Request.QueryString["tn"].ToString();
           // Response.Write("<script>alert('"+t_no+"')</script>");
            if (Request.QueryString["msg"] == "yes")
                {
                    
                    msg = "yes";
                    ticket_info(Request.QueryString["tn"]);
                    Button1.Visible = false;
                }
                else
                {
                    ticket_info(Request.QueryString["tn"]);
                }
            }
        }
        catch
        {
            t_no = Session["ticket_num"].ToString();
            ticket_info(Session["ticket_num"].ToString());
        }
        
        f_bal();
    }
    private void ticket_info(string tn)
    {
        int fare = 0;
        SqlCommand cmd = new SqlCommand("SELECT *,CONVERT(VARCHAR(30), date, 	100) as b_date,CONVERT(VARCHAR(30), DATEADD(hour, 2, date), 100) as b_e_date from ars_ticket where ticket_num = '" + tn+"'",con);
        con.Open();
        dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            f_no = dr["flight_num"].ToString();
            b_date = dr["b_date"].ToString();
            b_e_date = dr["b_e_date"].ToString();
        }
        con.Close();
        SqlCommand cmd1 = new SqlCommand("Select * from ars_flights where flight_num = '"+f_no+"'",con);
        con.Open();
        dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            dtime = dr["d_time"].ToString();
            atime = dr["a_time"].ToString();
            ddate = dr["d_date"].ToString();
            fare = Convert.ToInt32(dr["price"].ToString());
            if (dr["airport_code"].ToString() == "AR-KHI-001" && dr["d_airport_code"].ToString() == "AR-ISL-001")
            {
                dloc = "Karachi KHI";
                aloc = "Islamabad ISB";

            }
            else if (dr["airport_code"].ToString() == "AR-ISL-001" && dr["d_airport_code"].ToString() == "AR-KHI-001")
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
                dloc = "Lahore LHR";
                aloc = "Karachi KHI";
            }
            else if (dr["airport_code"].ToString() == "AR-ISL-001" && dr["d_airport_code"].ToString() == "AR-LHR-001")
            {
                dloc = "Islamabad ISB";
                aloc = "Lahore LHR";
            }
            else if (dr["airport_code"].ToString() == "AR-LHR-001" && dr["d_airport_code"].ToString() == "AR-ISL-001")
            {
                dloc = "Lahore LHR";
                aloc = "Islamabad ISB";
            }
        }
        con.Close();

        SqlCommand cmd2 = new SqlCommand("SELECT * from ars_flight_passenger where ticket_num = '" + tn + "'", con);
        con.Open();
        dr = cmd2.ExecuteReader();
        int i = 1;
        total = 0;
        Random rnd = new Random();
        string[] seats = { "A", "B", "C", "D", "E", "F", "G", "H" };
        while (dr.Read())
        {  
            int afare = fare;
            if(dr["type"].ToString() == "Child")
            {
                afare = afare - 1000;
            }
            else if(dr["type"].ToString() == "Infant")
            {
                afare = afare / 2;
            }
            data += "    <tr><td class='text-center'>"+i+"</td><td>"+dr["pass_name"].ToString()+"</td><td class='text-right'>"+ dr["pass_mob"].ToString() + "</td><td class='text-right'>"+dr["seats"].ToString()+"</td><td class='text-right'>Rs "+afare.ToString()+"</td></tr>";
            total = total + afare;
            i++;
        }
        con.Close();
        SqlCommand update = new SqlCommand("update ars_ticket set total = '"+total+"' where ticket_num = '"+ tn + "'",con);
        con.Open();
        update.ExecuteNonQuery();
        con.Close();
    }

    private void f_bal()
    {
        SqlCommand cmd = new SqlCommand("select * from wallet where uname = '" + Session["id"].ToString() + "'", con);
        con.Open();
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["balance"].ToString() == "0")
            {
                bal = "0";
            }
            else
            {
                bal = dr["balance"].ToString();

            }
            
        }
        else
        {
        
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int bal1 = Convert.ToInt32(bal);
        if(bal1 < total)
        {
            Response.Write("<script>alert('Balance is not enough in wallet')</script>");
        }
        else
        {
            SqlCommand cmd = new SqlCommand("update wallet set balance = balance -" + total + " where uname = '" + Session["id"] + "' ; update ars_ticket set status = 'Confirmed' where ticket_num = '"+ Session["ticket_num"].ToString() + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Button1.Visible = false;
            Response.Write("<script>alert('Payment Successfully Paid')</script>");
//Response.Redirect("my_flight.aspx");

        }
    }
}