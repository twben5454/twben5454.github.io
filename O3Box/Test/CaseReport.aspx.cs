using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;
using System.Data;

public partial class Pages_Case_CaseReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PrintPDF();
        }
    }

    protected void PrintPDF()
    {
        string strSQL = @"Select 
	                            a.* ,b.*
                            From tblOrderD a 
                            Join tblOrderM b on a.OrderID = b.OrderID 
                            Where a.OrderID='202109090006'";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;
        var Doc1 = new Document(PageSize.A4, 50, 50, 80, 50);
        MemoryStream Memory = new MemoryStream();

        string path = Server.MapPath("pdf");
        PdfWriter PdfWriter = PdfWriter.GetInstance(Doc1, Memory);

        // 字型
        // Dim FontPath As String = Environment.GetEnvironmentVariable("Windows" & "\Fonts\kaiu.ttf")
        // Dim FontPath As String = Server.MapPath("/test/pdf/kaiu.ttf")
        BaseFont bfChinese = BaseFont.CreateFont(@"C:\Windows\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

        Font chFont = new Font(bfChinese, 10);
        Font chFont1 = new Font(bfChinese, 20);
        Font chFont2 = new Font(bfChinese, 6);
        Font chFont3 = new Font(bfChinese, 8, Font.NORMAL, BaseColor.RED);
        Font chFont4 = new Font(bfChinese, 8);
        Font chFont5 = new Font(bfChinese, 9);
        Font ChFont_red = new Font(bfChinese, 12, Font.NORMAL, BaseColor.RED);
        Font ChFont_red1 = new Font(bfChinese, 16, Font.NORMAL, BaseColor.RED);

        Doc1.Open();
        //*************Header
        PdfPTable H1 = new PdfPTable(new float[] { 2, 1 });
        H1.TotalWidth = 500.0F;
        H1.LockedWidth = true;

        PdfPCell H11 = new PdfPCell(new Phrase("彤鑫國際美容股份有限公司", chFont1));
        H11.Colspan = 1;
        H11.VerticalAlignment = Element.ALIGN_LEFT;
        H11.HorizontalAlignment = Element.ALIGN_LEFT;
        H11.DisableBorderSide(Rectangle.TOP_BORDER);
        H11.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H11.DisableBorderSide(Rectangle.LEFT_BORDER);
        H11.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H1.AddCell(H11);
        PdfPCell H12 = new PdfPCell(new Phrase("出貨單", chFont1));
        H11.Colspan = 2;
        H12.VerticalAlignment = Element.ALIGN_RIGHT;
        H12.HorizontalAlignment = Element.ALIGN_RIGHT;
        H12.DisableBorderSide(Rectangle.TOP_BORDER);
        H12.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H12.DisableBorderSide(Rectangle.LEFT_BORDER);
        H12.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H1.AddCell(H12);
        PdfPCell H111 = new PdfPCell(new Phrase(" ", chFont));
        H111.Colspan = 1;
        H111.VerticalAlignment = Element.ALIGN_LEFT;
        H111.HorizontalAlignment = Element.ALIGN_LEFT;
        H111.DisableBorderSide(Rectangle.TOP_BORDER);
        H111.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H111.DisableBorderSide(Rectangle.LEFT_BORDER);
        H111.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H1.AddCell(H111);
        PdfPCell H112 = new PdfPCell(new Phrase("", chFont));
        H11.Colspan = 2;
        H112.VerticalAlignment = Element.ALIGN_RIGHT;
        H112.HorizontalAlignment = Element.ALIGN_RIGHT;
        H112.DisableBorderSide(Rectangle.TOP_BORDER);
        H112.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H112.DisableBorderSide(Rectangle.LEFT_BORDER);
        H112.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H1.AddCell(H112);

        PdfPCell H21 = new PdfPCell(new Phrase("110台北市信義區基隆路一段163號14樓 02 37655199", chFont));
        H21.Colspan = 1;
        H21.VerticalAlignment = Element.ALIGN_LEFT;
        H21.HorizontalAlignment = Element.ALIGN_LEFT;
        H21.DisableBorderSide(Rectangle.TOP_BORDER);
        H21.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H21.DisableBorderSide(Rectangle.LEFT_BORDER);
        H21.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H1.AddCell(H21);
        PdfPCell H22 = new PdfPCell(new Phrase("第1頁", chFont));
        H21.Colspan = 2;
        H22.VerticalAlignment = Element.ALIGN_RIGHT;
        H22.HorizontalAlignment = Element.ALIGN_RIGHT;
        H22.DisableBorderSide(Rectangle.TOP_BORDER);
        H22.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H22.DisableBorderSide(Rectangle.LEFT_BORDER);
        H22.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H1.AddCell(H22);

        Doc1.Add(H1);

        PdfPTable H2 = new PdfPTable(new float[] { 1, 1  ,1});
        H2.TotalWidth = 500.0F;
        H2.LockedWidth = true;

        PdfPCell H201 = new PdfPCell(new Phrase("\n客戶名稱：" , chFont));
        H201.Colspan = 1;
        H201.VerticalAlignment = Element.ALIGN_LEFT;
        H201.HorizontalAlignment = Element.ALIGN_LEFT;
        //H201.DisableBorderSide(Rectangle.TOP_BORDER);
        H201.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H201.DisableBorderSide(Rectangle.LEFT_BORDER);
        H201.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H201);
        PdfPCell H202 = new PdfPCell(new Phrase("\n經銷商編號：" + dt.Rows[0]["MemberID"].ToString(), chFont));
        H202.Colspan = 1;
        H202.VerticalAlignment = Element.ALIGN_LEFT;
        H202.HorizontalAlignment = Element.ALIGN_LEFT;
        //H202.DisableBorderSide(Rectangle.TOP_BORDER);
        H202.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H202.DisableBorderSide(Rectangle.LEFT_BORDER);
        H202.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H202);
        PdfPCell H203 = new PdfPCell(new Phrase("\n訂單日期：" + Convert.ToDateTime(dt.Rows[0]["OrderDate"].ToString()).ToString("yyyy-MM-dd"), chFont));
        H203.Colspan = 1;
        H203.VerticalAlignment = Element.ALIGN_LEFT;
        H203.HorizontalAlignment = Element.ALIGN_LEFT;
        //H203.DisableBorderSide(Rectangle.TOP_BORDER);
        H203.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H203.DisableBorderSide(Rectangle.LEFT_BORDER);
        H203.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H203);

        PdfPCell H301 = new PdfPCell(new Phrase("統一編號：", chFont));
        H301.Colspan = 1;
        H301.VerticalAlignment = Element.ALIGN_LEFT;
        H301.HorizontalAlignment = Element.ALIGN_LEFT;
        H301.DisableBorderSide(Rectangle.TOP_BORDER);
        H301.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H301.DisableBorderSide(Rectangle.LEFT_BORDER);
        H301.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H301);
        PdfPCell H302 = new PdfPCell(new Phrase("電話：", chFont));
        H302.Colspan = 2;
        H302.VerticalAlignment = Element.ALIGN_LEFT;
        H302.HorizontalAlignment = Element.ALIGN_LEFT;
        H302.DisableBorderSide(Rectangle.TOP_BORDER);
        H302.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H302.DisableBorderSide(Rectangle.LEFT_BORDER);
        H302.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H302);

        PdfPCell H401 = new PdfPCell(new Phrase("聯絡地址：", chFont));
        H401.Colspan = 2;
        H401.VerticalAlignment = Element.ALIGN_LEFT;
        H401.HorizontalAlignment = Element.ALIGN_LEFT;
        H401.DisableBorderSide(Rectangle.TOP_BORDER);
        H401.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H401.DisableBorderSide(Rectangle.LEFT_BORDER);
        H401.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H401);
        PdfPCell H402 = new PdfPCell(new Phrase("出貨單號：" + dt.Rows[0]["OrderID"].ToString(), chFont));
        H402.Colspan = 1;
        H402.VerticalAlignment = Element.ALIGN_LEFT;
        H402.HorizontalAlignment = Element.ALIGN_LEFT;
        H402.DisableBorderSide(Rectangle.TOP_BORDER);
        H402.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H402.DisableBorderSide(Rectangle.LEFT_BORDER);
        H402.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H402);

        PdfPCell H501 = new PdfPCell(new Phrase("送貨地址：", chFont));
        H501.Colspan = 2;
        H501.VerticalAlignment = Element.ALIGN_LEFT;
        H501.HorizontalAlignment = Element.ALIGN_LEFT;
        H501.DisableBorderSide(Rectangle.TOP_BORDER);
        //H501.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H501.DisableBorderSide(Rectangle.LEFT_BORDER);
        H501.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H501);
        PdfPCell H502 = new PdfPCell(new Phrase("發票號碼：\n\n", chFont));
        H502.Colspan = 1;
        H502.VerticalAlignment = Element.ALIGN_LEFT;
        H502.HorizontalAlignment = Element.ALIGN_LEFT;
        H502.DisableBorderSide(Rectangle.TOP_BORDER);
        //H502.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H502.DisableBorderSide(Rectangle.LEFT_BORDER);
        H502.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H2.AddCell(H502);

        Doc1.Add(H2);

        PdfPTable H3 = new PdfPTable(new float[] { 1,3,1,1,1, 1, 1 });
        H3.TotalWidth = 500.0F;
        H3.LockedWidth = true;

        PdfPCell H601 = new PdfPCell(new Phrase("產品編號\n\n", chFont));
        H601.Colspan = 1;
        H601.VerticalAlignment = Element.ALIGN_LEFT;
        H601.HorizontalAlignment = Element.ALIGN_LEFT;
        H601.DisableBorderSide(Rectangle.TOP_BORDER);
        //H601.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H601.DisableBorderSide(Rectangle.LEFT_BORDER);
        H601.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H3.AddCell(H601);
        PdfPCell H602 = new PdfPCell(new Phrase("品名", chFont));
        H602.Colspan = 1;
        H602.VerticalAlignment = Element.ALIGN_LEFT;
        H602.HorizontalAlignment = Element.ALIGN_LEFT;
        H602.DisableBorderSide(Rectangle.TOP_BORDER);
        //H602.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H602.DisableBorderSide(Rectangle.LEFT_BORDER);
        H602.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H3.AddCell(H602);
        PdfPCell H603 = new PdfPCell(new Phrase("數量", chFont));
        H603.Colspan = 1;
        H603.VerticalAlignment = Element.ALIGN_LEFT;
        H603.HorizontalAlignment = Element.ALIGN_LEFT;
        H603.DisableBorderSide(Rectangle.TOP_BORDER);
        //H603.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H603.DisableBorderSide(Rectangle.LEFT_BORDER);
        H603.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H3.AddCell(H603);
        PdfPCell H604 = new PdfPCell(new Phrase("單位", chFont));
        H604.Colspan = 1;
        H604.VerticalAlignment = Element.ALIGN_LEFT;
        H604.HorizontalAlignment = Element.ALIGN_LEFT;
        H604.DisableBorderSide(Rectangle.TOP_BORDER);
        //H604.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H604.DisableBorderSide(Rectangle.LEFT_BORDER);
        H604.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H3.AddCell(H604);
        PdfPCell H605 = new PdfPCell(new Phrase("單價", chFont));
        H605.Colspan = 1;
        H605.VerticalAlignment = Element.ALIGN_LEFT;
        H605.HorizontalAlignment = Element.ALIGN_LEFT;
        H605.DisableBorderSide(Rectangle.TOP_BORDER);
        //H605.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H605.DisableBorderSide(Rectangle.LEFT_BORDER);
        H605.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H3.AddCell(H605);
        PdfPCell H606 = new PdfPCell(new Phrase("小計", chFont));
        H606.Colspan = 1;
        H606.VerticalAlignment = Element.ALIGN_LEFT;
        H606.HorizontalAlignment = Element.ALIGN_LEFT;
        H606.DisableBorderSide(Rectangle.TOP_BORDER);
        //H606.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H606.DisableBorderSide(Rectangle.LEFT_BORDER);
        H606.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H3.AddCell(H606);
        PdfPCell H607 = new PdfPCell(new Phrase("備註", chFont));
        H607.Colspan = 1;
        H607.VerticalAlignment = Element.ALIGN_LEFT;
        H607.HorizontalAlignment = Element.ALIGN_LEFT;
        H607.DisableBorderSide(Rectangle.TOP_BORDER);
        //H607.DisableBorderSide(Rectangle.BOTTOM_BORDER);
        H607.DisableBorderSide(Rectangle.LEFT_BORDER);
        H607.DisableBorderSide(Rectangle.RIGHT_BORDER);
        H3.AddCell(H607);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            PdfPCell TH601 = new PdfPCell(new Phrase(dt.Rows[i]["PID"].ToString() + "\n\n", chFont));
            TH601.Colspan = 1;
            TH601.VerticalAlignment = Element.ALIGN_LEFT;
            TH601.HorizontalAlignment = Element.ALIGN_LEFT;
            TH601.DisableBorderSide(Rectangle.TOP_BORDER);
            TH601.DisableBorderSide(Rectangle.BOTTOM_BORDER);
            TH601.DisableBorderSide(Rectangle.LEFT_BORDER);
            TH601.DisableBorderSide(Rectangle.RIGHT_BORDER);
            H3.AddCell(TH601);
            PdfPCell TH602 = new PdfPCell(new Phrase("品名", chFont));
            TH602.Colspan = 1;
            TH602.VerticalAlignment = Element.ALIGN_LEFT;
            TH602.HorizontalAlignment = Element.ALIGN_LEFT;
            TH602.DisableBorderSide(Rectangle.TOP_BORDER);
            TH602.DisableBorderSide(Rectangle.BOTTOM_BORDER);
            TH602.DisableBorderSide(Rectangle.LEFT_BORDER);
            TH602.DisableBorderSide(Rectangle.RIGHT_BORDER);
            H3.AddCell(TH602);
            PdfPCell TH603 = new PdfPCell(new Phrase(dt.Rows[i]["Num"].ToString(), chFont));
            TH603.Colspan = 1;
            TH603.VerticalAlignment = Element.ALIGN_LEFT;
            TH603.HorizontalAlignment = Element.ALIGN_LEFT;
            TH603.DisableBorderSide(Rectangle.TOP_BORDER);
            TH603.DisableBorderSide(Rectangle.BOTTOM_BORDER);
            TH603.DisableBorderSide(Rectangle.LEFT_BORDER);
            TH603.DisableBorderSide(Rectangle.RIGHT_BORDER);
            H3.AddCell(TH603);
            PdfPCell TH604 = new PdfPCell(new Phrase("單位", chFont));
            TH604.Colspan = 1;
            TH604.VerticalAlignment = Element.ALIGN_LEFT;
            TH604.HorizontalAlignment = Element.ALIGN_LEFT;
            TH604.DisableBorderSide(Rectangle.TOP_BORDER);
            TH604.DisableBorderSide(Rectangle.BOTTOM_BORDER);
            TH604.DisableBorderSide(Rectangle.LEFT_BORDER);
            TH604.DisableBorderSide(Rectangle.RIGHT_BORDER);
            H3.AddCell(TH604);
            PdfPCell TH605 = new PdfPCell(new Phrase(Convert.ToInt32(dt.Rows[i]["Price"].ToString()).ToString("N0"), chFont));
            TH605.Colspan = 1;
            TH605.VerticalAlignment = Element.ALIGN_LEFT;
            TH605.HorizontalAlignment = Element.ALIGN_LEFT;
            TH605.DisableBorderSide(Rectangle.TOP_BORDER);
            TH605.DisableBorderSide(Rectangle.BOTTOM_BORDER);
            TH605.DisableBorderSide(Rectangle.LEFT_BORDER);
            TH605.DisableBorderSide(Rectangle.RIGHT_BORDER);
            H3.AddCell(TH605);
            PdfPCell TH606 = new PdfPCell(new Phrase((Convert.ToInt32(dt.Rows[i]["Price"].ToString()) * Convert.ToInt32(dt.Rows[i]["Num"].ToString())).ToString("N0"), chFont));
            TH606.Colspan = 1;
            TH606.VerticalAlignment = Element.ALIGN_LEFT;
            TH606.HorizontalAlignment = Element.ALIGN_LEFT;
            TH606.DisableBorderSide(Rectangle.TOP_BORDER);
            TH606.DisableBorderSide(Rectangle.BOTTOM_BORDER);
            TH606.DisableBorderSide(Rectangle.LEFT_BORDER);
            TH606.DisableBorderSide(Rectangle.RIGHT_BORDER);
            H3.AddCell(TH606);
            PdfPCell TH607 = new PdfPCell(new Phrase("", chFont));
            TH607.Colspan = 1;
            TH607.VerticalAlignment = Element.ALIGN_LEFT;
            TH607.HorizontalAlignment = Element.ALIGN_LEFT;
            TH607.DisableBorderSide(Rectangle.TOP_BORDER);
            TH607.DisableBorderSide(Rectangle.BOTTOM_BORDER);
            TH607.DisableBorderSide(Rectangle.LEFT_BORDER);
            TH607.DisableBorderSide(Rectangle.RIGHT_BORDER);
            H3.AddCell(TH607);

        }

        Doc1.Add(H3);
        //Paragraph p3 = new Paragraph(new Chunk("110台北市信義區基隆路一段163號14樓 02 37655199", chFont));
        //p3.Alignment = 3; //居中
        //Doc1.Add(p3);
        //**************************
        Doc1.Add(new Paragraph(new Phrase("印表日期:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), chFont)));

        //***************************
        Doc1.Close();

        Response.Clear();

        Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");

        Response.ContentType = "application/octet-stream";



        Response.OutputStream.Write(Memory.GetBuffer(), 0, Memory.GetBuffer().Length);

        Response.OutputStream.Flush();

        Response.OutputStream.Close();

        Response.Flush();

        Response.End();
    }

    protected void FillRowData(PdfPTable pt, string strNo, string strTitle, string strMemo)
    {
        BaseFont bfChinese = BaseFont.CreateFont(@"C:\Windows\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font chFont = new Font(bfChinese, 10);
        PdfPCell item01 = new PdfPCell(new Phrase(strNo, chFont));
        item01.Colspan = 1;
        item01.VerticalAlignment = Element.ALIGN_MIDDLE;
        item01.HorizontalAlignment = Element.ALIGN_CENTER;
        pt.AddCell(item01);

        PdfPCell item02 = new PdfPCell(new Phrase(strTitle, chFont));
        item02.Colspan = 1;
        item02.VerticalAlignment = Element.ALIGN_MIDDLE;
        item02.HorizontalAlignment = Element.ALIGN_LEFT;
        pt.AddCell(item02);


        PdfPCell item03 = new PdfPCell(new Phrase(strMemo, chFont));
        item03.Colspan = 1;
        item03.VerticalAlignment = Element.ALIGN_MIDDLE;
        item03.HorizontalAlignment = Element.ALIGN_LEFT;
        pt.AddCell(item03);
    }
}