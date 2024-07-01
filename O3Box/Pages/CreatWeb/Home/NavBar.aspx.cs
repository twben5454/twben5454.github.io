using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreatWeb_Home_NavBar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnprimary_Click(object sender, EventArgs e)
    {
        string strClass = "navbar navbar-expand-lg  ";
        strClass += "navbar-dark  bg-primary";
        this.NarBar.Attributes["class"] = strClass;
    }
    protected void btnsecondary_Click(object sender, EventArgs e)
    {
        string strClass = "navbar navbar-expand-lg  navbar-dark  bg-secondary";
        this.NarBar.Attributes["class"] = strClass;
    }
    protected void btnsuccess_Click(object sender, EventArgs e)
    {
        string strClass = "navbar navbar-expand-lg  navbar-dark  bg-success";
        this.NarBar.Attributes["class"] = strClass;
    }
    protected void btninfo_Click(object sender, EventArgs e)
    {
        string strClass = "navbar navbar-expand-lg  navbar-dark  bg-info";
        this.NarBar.Attributes["class"] = strClass;
    }

    protected void btnwarning_Click(object sender, EventArgs e)
    {
        string strClass = "navbar navbar-expand-lg  navbar-dark  bg-warning";
        this.NarBar.Attributes["class"] = strClass;
    }

    protected void btndanger_Click(object sender, EventArgs e)
    {
        string strClass = "navbar navbar-expand-lg  navbar-dark  bg-danger";
        this.NarBar.Attributes["class"] = strClass;
    }

    protected void btnlight_Click(object sender, EventArgs e)
    {
        string strClass = "navbar navbar-expand-lg  navbar-light  bg-light";
        this.NarBar.Attributes["class"] = strClass;
    }

    protected void btndark_Click(object sender, EventArgs e)
    {
        string strClass = "navbar navbar-expand-lg  navbar-dark  bg-dark";
        this.NarBar.Attributes["class"] = strClass;
    }
}