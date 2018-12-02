using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
public partial class ticket : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apptrive"].ConnectionString);
    SqlDataReader dr;
    Random rnd = new Random();
    string[] plane_num = new string[10];
    string[] airport_code = new string[10];
    protected void Page_Load(object sender, EventArgs e)
    {
        get_num();
        gen();
        Response.Redirect(Request.QueryString["page"].ToString()+".aspx?date="+ Request.QueryString["date"].ToString());
    }
    private void gen()
    {
        //  string sYear = DateTime.Now.Year.ToString();

        // string sMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');

        // string sDay = DateTime.Now.Day.ToString().PadLeft(2, '0');

        //string x = sYear +"-"+ sMonth + "-" + sDay;
        string x = Request.QueryString["date"]; ;
        string[,] dtime = {
            { "9:00 AM", "3:00 PM", "7:00 PM" }, //KHI TO ISL
            {"11:00 AM","5:00 PM","9:00 PM"}, //ISL TO KHI
            {"9:00 AM", "3:00 PM", "7:00 PM"}, //KHI TO LHR  
            {"11:00 AM","5:00 PM","9:00 PM"},// LHR TO KHI
            {"9:00 AM","5:00 PM",""},//ISL TO LHR
            {"11:00 AM","7:00 PM",""}, // LHR TO ISL
        };
        string[,] atime = {
            {"10:45 AM", "4:45 PM", "8:45 PM"}, //KHI TO ISL
            {"12:45 AM","6:45 PM","10:45 PM"}, //ISL TO KHI
            {"10:45 AM", "4:45 PM", "8:45 PM"}, //KHI TO LHR  
            {"12:45 AM","6:45 PM","10:45 PM"}, // LHR TO KHI
            {"10:00 AM","6:00 PM",""},//ISL TO LHR
            {"12:00 PM","8:00 PM",""}, // LHR TO ISL
        };
       // int count = DateTime.DaysInMonth(Convert.ToInt32(DateTime.Now.ToString("yyyy")), Convert.ToInt32(DateTime.Now.ToString("MM")));
        //From KHI TO ISL
      
             for (int khi = 0; khi < 3; khi++)
             {
            insertkhitoisl( x, dtime[0, khi], atime[0, khi], khi);
             }

        //FROM ISL TO KHI
           int i = 3;

           for (int isl = 0; isl < 3; isl++)
           {
               insertisltokhi(x, dtime[1, isl], atime[1, isl], isl);
           }
          
       //FROM KHI TO LHR


           for (int khi = 0; khi < 3; khi++)
           {
               Response.Write(i + "<br>");
               insertkhitolhr(x, dtime[2, khi], atime[2, khi], i);
               i++;

           }



           i = 3;
          for (int khi = 0; khi < 3; khi++)
          {
              Response.Write(i + "<br>");
              insertlhrtokhi(x, dtime[3, khi], atime[3, khi], i);
              i++;

          }



           i = 6;
          for (int khi = 0; khi < 2; khi++)
          {
              Response.Write(i + "<br>");
              insertisltolhr(x, dtime[4, khi], atime[4, khi], i);
              i++;

          }



           i = 6;
          for (int khi = 0; khi < 2; khi++)
          {
              Response.Write(i + "<br>");
              insertlhrtoisl(x, dtime[5, khi], atime[5, khi], i);
              i++;

          }

    }
    x
    private void insertisltokhi(string d, string dtime, string atime, int i)
    {
        string fn = fng();
        string ddate = d;

        SqlCommand cmd = new SqlCommand("insert into ars_flights values ('" + fn + "','" + ddate + "','" + dtime + "','" + ddate + "','" + atime + "',(select price from ars_prices where distance = 'KHIISL'),'"+ airport_code[i] + "','AR-ISL-001','" + plane_num[i] + "','Active')", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    private void insertkhitolhr(string d, string dtime, string atime, int i)
    {
        string fn = fng();
        string ddate = d;

        SqlCommand cmd = new SqlCommand("insert into ars_flights values ('" + fn + "','" + ddate + "','" + dtime + "','" + ddate + "','" + atime + "',(select price from ars_prices where distance = 'KHIISL'),'AR-LHR-001','" + airport_code[3] + "','" + plane_num[i] + "','Active')", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    private void insertlhrtokhi(string d, string dtime, string atime, int i)
    {
        string fn = fng();
        string ddate = d;

        SqlCommand cmd = new SqlCommand("insert into ars_flights values ('" + fn + "','" + ddate + "','" + dtime + "','" + ddate + "','" + atime + "',(select price from ars_prices where distance = 'KHIISL'),'" + airport_code[3] + "','AR-LHR-001','" + plane_num[i] + "','Active')", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    private void insertisltolhr(string d, string dtime, string atime, int i)
    {
        string fn = fng();
        string ddate = d;

        SqlCommand cmd = new SqlCommand("insert into ars_flights values ('" + fn + "','" + ddate + "','" + dtime + "','" + ddate + "','" + atime + "',(select price from ars_prices where distance = 'ISLLHR'),'AR-LHR-001','" + airport_code[7] + "','" + plane_num[i] + "','Active')", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    private void insertlhrtoisl(string d, string dtime, string atime, int i)
    {
        string fn = fng();
        string ddate = d;

        SqlCommand cmd = new SqlCommand("insert into ars_flights values ('" + fn + "','" + ddate + "','" + dtime + "','" + ddate + "','" + atime + "',(select price from ars_prices where distance = 'ISLLHR'),'" + airport_code[7] + "','AR-LHR-001','" + plane_num[i] + "','Active')", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    private string fng()
    {
        string fn = "";
        SqlCommand cmd1 = new SqlCommand("select count(flight_num)+1 as fn from ars_flights", con);
        con.Open();
        dr = cmd1.ExecuteReader();
        if (dr.Read()) { fn = "BA-00" + dr["fn"].ToString(); }
        con.Close();
        return fn;
    }
}