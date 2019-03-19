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

public partial class booking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text="Name";
        Label2.Text="Email Id";
        Label3.Text="Phone NO";
        Label4.Text="Address";
        Label5.Text="Name of Theater";
        Label6.Text="Type of seat";
        Label7.Text="No of seats";
        Label8.Text="Your credit card no";
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label9.Visible = true;
        Label9.Text = "Your tickets are booked successfully";
        
        
    }
}
