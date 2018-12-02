using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
public partial class t_info : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["apptrive"].ConnectionString);
    SqlDataReader dr;
    public static string aform = "";
    int a, b, c;

   
    protected void Page_load(object sender, EventArgs e)
    {


        u_ticket(Request.QueryString["fn"].ToString(), Session["ticket_num"].ToString());
        reader();
    }
    private void u_ticket(string fn, string tn)
    {
        try
        {
            
            SqlCommand cmd = new SqlCommand("update ars_ticket set flight_num = '" + fn + "' where ticket_num = '" + tn + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            fetch(tn);
        }
        catch
        {

        }
    }
    private void fetch(string tn)
    {
        SqlCommand cmd = new SqlCommand("select * from ars_ticket where ticket_num = '" + tn + "'", con);
        con.Open();
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            a = Convert.ToInt32(dr["adults"].ToString());
            b = Convert.ToInt32(dr["child"].ToString());
            c = Convert.ToInt32(dr["infant"].ToString());
            cal_adult(a);
            cal_child(b);
            cal_infant(c);
        }
        con.Close();

    }
    string[] names = { "title", "fname", "lname", "dob", "mob", "amob" };
    string[] size = { "1", "2", "2", "2", "2", "3" };
    string[] type = { "ddl", "2", "2", "2", "2", "3" };
    string[] title = { "Title", "First Name*", "Surname", "Date Of Birth*", "Mobile Number*", "Alternate Mobile Number" };
    string[] css = { "form-control", "form-control", "form-control", "form-control mydatepicker", "form-control", "form-control" };
    private void cal_adult(int n)
    {
       
        for (int i = 1; i <= n; i++)
        {
            pnlTextBoxes.Controls.Add(new LiteralControl(" <div class='form-group'><h4><b> Adult " + i + " </b></h4><hr/>"));
            for (int x = 0; x < 4; x++)
            {
                CreateTextBox(names[x], names[x] + i.ToString(), (i + 1).ToString(), css[x], type[x], size[x], title[x]);
            }


            pnlTextBoxes.Controls.Add(new LiteralControl("</div><div class='form-group'>"));
            for (int y = 4; y < 6; y++)
            {
                TextBox txt = new TextBox();
                txt.ID = names[y] + i.ToString();
                txt.CssClass = css[y];

                pnlTextBoxes.Controls.Add(new LiteralControl("<div class='col-md-" + size[y] + "'><b>" + title[y] + "</b>"));
                pnlTextBoxes.Controls.Add(txt);
                pnlTextBoxes.Controls.Add(new LiteralControl("</div>"));
            }
            pnlTextBoxes.Controls.Add(new LiteralControl("</div>"));
        }
    }
    private void cal_child(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            pnlTextBoxes.Controls.Add(new LiteralControl(" <div class='form-group'><h4><b> Child " + i + " </b></h4><hr/>"));
            for (int x = 0; x < 4; x++)
            {
                CreateTextBox(names[x], "c"+names[x] + i.ToString(), (i + 1).ToString(), css[x], type[x], size[x], title[x]);
            }


            pnlTextBoxes.Controls.Add(new LiteralControl("</div><div class='form-group'>"));
            pnlTextBoxes.Controls.Add(new LiteralControl("</div>"));
        }
    }
    private void cal_infant(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            pnlTextBoxes.Controls.Add(new LiteralControl(" <div class='form-group'><h4><b> Infant " + i + " </b></h4><hr/>"));
            for (int x = 0; x < 4; x++)
            {
                CreateTextBox(names[x], "i" + names[x] + i.ToString(), (i + 1).ToString(), css[x], type[x], size[x], title[x]);
            }


            pnlTextBoxes.Controls.Add(new LiteralControl("</div><div class='form-group'>"));
            pnlTextBoxes.Controls.Add(new LiteralControl("</div>"));
        }
    }
   private void reader()
    {
        foreach (CheckBox chk in pnlTextBoxes.Controls.OfType<CheckBox>())
        {
            if (chk.Checked == true)
            {
                SqlCommand read = new SqlCommand("select * from customer where uname = '" + Session["id"] + "'", con);
                con.Open();
                dr = read.ExecuteReader();
                if (dr.Read())
                {
                    TextBox fname = pnlTextBoxes.FindControl("fname1") as TextBox;
                    TextBox lname = pnlTextBoxes.FindControl("lname1") as TextBox;
                    TextBox dob = pnlTextBoxes.FindControl("dob1") as TextBox;
                    TextBox mob = pnlTextBoxes.FindControl("mob1") as TextBox;
                    TextBox amob = pnlTextBoxes.FindControl("amob1") as TextBox;

                    fname.Text = dr["fname"].ToString();
                    lname.Text = dr["lname"].ToString();
                    dob.Text = dr["dob"].ToString();
                    mob.Text = dr["mob"].ToString();
                    amob.Text = dr["amob"].ToString();
                    
                }
                con.Close();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        foreach (CheckBox chk in pnlTextBoxes.Controls.OfType<CheckBox>())
        {
            if (chk.Checked == true)
            {
                SqlCommand cmd1 = new SqlCommand("update ars_ticket set status = 'Booking Confirmed' where ticket_num = '" + Session["ticket_num"] + "' ", con);
                SqlCommand read = new SqlCommand("select * from customer where uname = '"+ Session["id"] + "'",con);
                con.Open();
                cmd1.ExecuteNonQuery();
                dr = read.ExecuteReader();
                if (dr.Read())
                {
                    TextBox fname = pnlTextBoxes.FindControl("fname1") as TextBox;
                    TextBox lname = pnlTextBoxes.FindControl("lname1") as TextBox;
                    TextBox dob = pnlTextBoxes.FindControl("dob1") as TextBox;
                    TextBox mob = pnlTextBoxes.FindControl("mob1") as TextBox;
                    TextBox amob = pnlTextBoxes.FindControl("amob1") as TextBox;

                    fname.Text = dr["fname"].ToString();
                    lname.Text = dr["lname"].ToString();
                    dob.Text = dr["dob"].ToString();
                    mob.Text = dr["mob"].ToString();
                    amob.Text = dr["amob"].ToString();
                    con.Close();
                }
                else
                {
                    dr.Close();
                    DropDownList title = pnlTextBoxes.FindControl("title1") as DropDownList;
                    TextBox fname = pnlTextBoxes.FindControl("fname1") as TextBox;
                    TextBox lname = pnlTextBoxes.FindControl("lname1") as TextBox;
                    TextBox dob = pnlTextBoxes.FindControl("dob1") as TextBox;
                    TextBox mob = pnlTextBoxes.FindControl("mob1") as TextBox;
                    TextBox amob = pnlTextBoxes.FindControl("amob1") as TextBox;
                    SqlCommand cmd = new SqlCommand("insert into customer values('" + Session["id"] + "','" + fname.Text + "','" + lname.Text + "','" + dob.Text + "','" + mob.Text + "','" + amob.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        Random rnd = new Random();
        string[] seats = { "A", "B", "C", "D", "E", "F", "G", "H" };
        for (int i = 1; i<=a; i++)
        {
            DropDownList title = pnlTextBoxes.FindControl("title" + i) as DropDownList;
            TextBox fname = pnlTextBoxes.FindControl("fname" + i) as TextBox;
            TextBox lname = pnlTextBoxes.FindControl("lname" + i) as TextBox;
            TextBox dob = pnlTextBoxes.FindControl("dob" + i) as TextBox;
            TextBox mob = pnlTextBoxes.FindControl("mob" + i) as TextBox;
            TextBox amob = pnlTextBoxes.FindControl("amob" + i) as TextBox;
            string f_name = title.Text + ". " + fname.Text + " " + lname.Text;
            SqlCommand cmd = new SqlCommand("insert into ars_flight_passenger values('"+Session["ticket_num"] + "','"+ f_name + "','"+dob.Text+"','"+mob.Text+"','"+amob.Text+"','Adult','"+ seats[i] + rnd.Next(1, 40).ToString() + "')",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        for (int i = 1; i <= b; i++)
        {
            DropDownList title = pnlTextBoxes.FindControl("ctitle" + i) as DropDownList;
            TextBox fname = pnlTextBoxes.FindControl("cfname" + i) as TextBox;
            TextBox lname = pnlTextBoxes.FindControl("clname" + i) as TextBox;
            TextBox dob = pnlTextBoxes.FindControl("cdob" + i) as TextBox;
            string f_name = title.Text + ". " + fname.Text + " " + lname.Text;
            SqlCommand cmd = new SqlCommand("insert into ars_flight_passenger values('" + Session["ticket_num"] + "','" + f_name + "','" + dob.Text + "','','','Child','" + seats[i+1] + rnd.Next(1, 40).ToString() + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        for (int i = 1; i <= c; i++)
        {
            DropDownList title = pnlTextBoxes.FindControl("ititle" + i) as DropDownList;
            TextBox fname = pnlTextBoxes.FindControl("ifname" + i) as TextBox;
            TextBox lname = pnlTextBoxes.FindControl("ilname" + i) as TextBox;
            TextBox dob = pnlTextBoxes.FindControl("idob" + i) as TextBox;
            string f_name = title.Text + ". " + fname.Text + " " + lname.Text;
            SqlCommand cmd = new SqlCommand("insert into ars_flight_passenger values('" + Session["ticket_num"] + "','" + f_name + "','" + dob.Text + "','','','Infant','Lap Seat')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        Response.Redirect("ticket.aspx");
    }
    protected void GetTextBoxValues(object sender, EventArgs e)
    {
        string[] title = { "" };
        string[] name = { "" };
        int i = 0;
        foreach (DropDownList ddl in pnlTextBoxes.Controls.OfType<DropDownList>())
        {
            title[i] = ddl.Text;
        }
        i = 0;
        for(;i<a;i++)
        {
            TextBox fname = pnlTextBoxes.FindControl("fname" + (i + 1).ToString()) as TextBox;
            TextBox lname = pnlTextBoxes.FindControl("fname" + (i + 1).ToString()) as TextBox;
            TextBox dob = pnlTextBoxes.FindControl("fname" + (i + 1).ToString()) as TextBox;
        }
       /* foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
        {
            if(textBox.ID == "fname"+(i+1))
            {
                name[i] = textBox.Text;
                Response.Write("fname" + (i + 1) + "<br>"); 
            }
           
            i++;
        }*/
       
      /*  foreach(CheckBox chk in pnlTextBoxes.Controls.OfType<CheckBox>())
        {
            if(chk.Checked == true)
            {
                message += chk.ID + ": " + chk.Text + "\\n";
            }
        }*/
        Response.Write("<script>alert('" + name[0] + "');</script>");
    }
    private void CreateTextBox(string acc, string id, string i, string css, string type, string size, string title)
    {
        if(id == "title1")
        {
            CheckBox chk = new CheckBox();
            chk.ID = "q";
            chk.Text = "Is this is you?";
            
            chk.Checked = true;
            pnlTextBoxes.Controls.Add(new LiteralControl("<div class='checkbox checkbox - primary' style='margin-left:5px'>"));
            pnlTextBoxes.Controls.Add(chk);
pnlTextBoxes.Controls.Add(new LiteralControl("</div><br>"));
        }
        if (type == "ddl")
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = id;
            ddl.Items.Add("Mr");
            ddl.Items.Add("Mrs");
            ddl.Items.Add("Ms");
            ddl.CssClass = css;

            pnlTextBoxes.Controls.Add(new LiteralControl("<div class='col-md-" + size + "'><b>" + title + "</b>"));
            pnlTextBoxes.Controls.Add(ddl);
            pnlTextBoxes.Controls.Add(new LiteralControl("</div>"));

        }
        else
        {

            TextBox txt = new TextBox();
            txt.ID = id;
            txt.CssClass = css;


           
           
            pnlTextBoxes.Controls.Add(new LiteralControl("<div class='col-md-" + size + "'><b>" + title + "</b>"));
            pnlTextBoxes.Controls.Add(txt);
            pnlTextBoxes.Controls.Add(new LiteralControl("</div>"));
        }
          //  Response.Write("<script>alert('"+css+"');</script>");

    }
}