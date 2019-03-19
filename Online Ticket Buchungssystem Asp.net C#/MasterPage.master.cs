using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Home_Click(object sender, EventArgs e)
    {

        Response.Redirect("home.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        Response.Redirect("listofth.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        Response.Redirect("listofph.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        Response.Redirect("contactus.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        Response.Redirect("photogallary.aspx");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {

        Response.Redirect("booking.aspx");
    }
}
