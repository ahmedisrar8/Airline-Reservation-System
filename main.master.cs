using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"].ToString() == "")
            {
                Response.Redirect("default.aspx");
            }
        }
        catch
        {
            Response.Redirect("default.aspx");
        }
    }

}
