using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;


public partial class CreatWeb_Home_Carsouel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    protected void filePhoto_FileSelected(object sender, EventArgs e)
    {
        if (filePhoto.HasFile)
        {
            string WebDir = Server.MapPath("~/upload/" + DB.getObject().WebID);
            
            try
            {
                System.IO.Directory.CreateDirectory(WebDir);//创建
            }
            catch { }
           
            string fileName = filePhoto.ShortFileName;

            fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
            fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

            filePhoto.SaveAs(Server.MapPath("~/upload/" + DB.getObject().WebID + "/" + fileName));

            string strSQL = @"Declare @i int =isNull((Select Top 1 DisplayOrder From tblCarousel Where WebID='" + DB.getObject().WebID + @"' Order by DisplayOrder Desc),0) + 1
                              Insert Into tblCarousel (WebID ,ImageUrl ,DisplayOrder) Values('" + DB.getObject().WebID + "','" + fileName + "',@i)";
            DB.getObject().Execute(strSQL, null, false);
            filePhoto.Reset();
            FillGrid();
            
        }

    }

    protected void FillGrid()
    {
        string strSQL = @"  Declare @i int = (Select Top 1 DisplayOrder  From tblCarousel Where WebID='" + DB.getObject().WebID + @"' Order by DisplayOrder )
                            Select WebID ,Case
		                    when DisplayOrder = @i then 'active'
		                    else ''
	                    End as Status,ImageUrl='" + DB.getObject().WebID + "/' + ImageUrl ,DisplayOrder,ImageID,IsUse  From  tblCarousel Order by DisplayOrder";
        DataTable dt =  DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        this.Grid1.DataSource = dt;
        this.Grid1.DataBind();
        this.Repeater1.DataSource = dt;
        this.Repeater1.DataBind();
    }

    protected void Grid1_RowCommand(object sender, FineUIPro.GridCommandEventArgs e)
    {
        object[] keys = Grid1.DataKeys[e.RowIndex];
        if (e.CommandName == "Action1")
        {
            string strSQL = @"Update  tblCarousel Set DisplayOrder = DisplayOrder - 1  Where ImageID = '" + keys[1].ToString() + "'";
            DB.getObject().Execute(strSQL, null, false);
            FillGrid();
            //FineUIPro.Alert.Show(strSQL);
        }
        if (e.CommandName == "Action2")
        {

            string strSQL = @"Update  tblCarousel Set DisplayOrder = DisplayOrder + 1  Where ImageID = '" + keys[1].ToString() + "'";
            DB.getObject().Execute(strSQL, null, false);
            FillGrid();
        }
        if (e.CommandName == "Action3")
        {
            string IsUse = keys[4].ToString();
            if (IsUse == "True") { IsUse = "False"; }
            else { IsUse = "True"; }
            string strSQL = @"Update   tblCarousel Set IsUse = '" + IsUse + "'  Where ImageID = '" + keys[1].ToString() + "'";
            DB.getObject().Execute(strSQL, null, false);
            FillGrid();
            //FineUIPro.Alert.Show(strSQL);

        }
    }

    protected void Btnreload_Click(object sender, EventArgs e)
    {
        FineUIPro.PageContext.Redirect("Carsouel.aspx");
    }
}