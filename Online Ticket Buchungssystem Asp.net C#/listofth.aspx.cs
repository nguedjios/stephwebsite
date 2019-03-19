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

public partial class listofth : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "GALAXY";
        Label2.Text = "GIRNAR";
        Label3.Text = "RAJASHRI";
        Label4.Text = "COSMOPLEX";
        Label5.Text = "CINEMAX";
        Label6.Text = "BIGCINEMA";
    }
}
