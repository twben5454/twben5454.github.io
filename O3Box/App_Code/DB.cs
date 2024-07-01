
using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using Microsoft.VisualBasic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB
{
    private static DB dao;
    //public   string connectionString = "Data Source=127.0.0.1;Initial Catalog=ERPSystem;Integrated Security=True";
    private string connectionString = "Data Source=127.0.0.1;Initial Catalog=O3BoxDB;User ID=ben;Password=gpnili54";
    //public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security = True;";
    public string WebSiteName = "大岞資訊有限公司";

    public static DB getObject()
    {
        if (dao == null)
        {
            dao = new DB();
        }
        return dao;
    }
    public DBResult Execute(string StrSQL, ArrayList paramlist, bool IsStoredProcedure)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(StrSQL, conn);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        if (paramlist != null)
        {
            for (int i = 0; i < paramlist.Count; i++)
            {
                if (paramlist[i] != null)
                {
                    cmd.Parameters.Add(paramlist[i]);
                }
            }
        }
        if (IsStoredProcedure)
            cmd.CommandType = CommandType.StoredProcedure;
        else
            cmd.CommandType = CommandType.Text;
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        DBResult DBResult = new DBResult();
        try
        {
            DBResult.ReturnCode = cmd.ExecuteNonQuery();
            DBResult.ExceptionMessage = "";
            DBResult.ReturnDataTable = null;
            DBResult.Success = true;
            return DBResult;
        }
        catch (Exception E)
        {
            DBResult.ExceptionMessage = E.Message;
            DBResult.ReturnCode = -1;
            DBResult.Success = false;
            DBResult.ReturnDataTable = null;
            return DBResult;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DBResult GetData(string strSQL)
    {
        return GetData(strSQL, null, false);
    }
    public DBResult GetData(string StrSQL, ArrayList paramlist, bool IsStoredProcedure)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(StrSQL, conn);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        if (paramlist != null)
        {
            for (int i = 0; i < paramlist.Count; i++)
            {
                if (paramlist[i] != null)
                {
                    cmd.Parameters.Add(paramlist[i]);
                }
            }
        }
        if (IsStoredProcedure)
            cmd.CommandType = CommandType.StoredProcedure;
        else
            cmd.CommandType = CommandType.Text;
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        DBResult DBResult = new DBResult();
        try
        {
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt == null)
            {
                DBResult.ReturnCode = -1;
                DBResult.ExceptionMessage = "Data Table is nothing.";
                DBResult.ReturnDataTable = null;
                DBResult.Success = false;
                DBResult.ReturnRecordCount = -1;
            }
            else
            {
                DBResult.ReturnCode = dt.Rows.Count;
                DBResult.ExceptionMessage = "";
                DBResult.ReturnDataTable = dt;
                DBResult.Success = true;
                DBResult.ReturnRecordCount = dt.Rows.Count;
            }
            return DBResult;
        }
        catch (Exception E)
        {
            //如果發生錯誤
            DBResult.ExceptionMessage = E.Message;
            DBResult.ReturnCode = -1;
            DBResult.Success = false;
            DBResult.ReturnDataTable = null;
            DBResult.ReturnRecordCount = -1;
            return DBResult;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public DBResultUseDataSet GetDataUseDataSet(string StrSQL, ArrayList paramlist, bool IsStoredProcedure)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(StrSQL, conn);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        if (paramlist != null)
        {
            for (int i = 0; i < paramlist.Count; i++)
            {
                if (paramlist[i] != null)
                {
                    cmd.Parameters.Add(paramlist[i]);
                }
            }
        }
        if (IsStoredProcedure)
            cmd.CommandType = CommandType.StoredProcedure;
        else
            cmd.CommandType = CommandType.Text;
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        DBResultUseDataSet DBResult = new DBResultUseDataSet();
        try
        {
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds == null)
            {
                DBResult.ReturnCode = -1;
                DBResult.ExceptionMessage = "Data Table is nothing.";
                DBResult.ReturnDataSet = null;
                DBResult.Success = false;
                DBResult.ReturnRecordCount = -1;
            }
            else
            {
                DBResult.ReturnCode = ds.Tables.Count;
                DBResult.ExceptionMessage = "";
                DBResult.ReturnDataSet = ds;
                DBResult.Success = true;
                DBResult.ReturnRecordCount = ds.Tables.Count;
            }
            return DBResult;
        }
        catch (Exception E)
        {
            //如果發生錯誤
            DBResult.ExceptionMessage = E.Message;
            DBResult.ReturnCode = -1;
            DBResult.Success = false;
            DBResult.ReturnDataSet = null;
            DBResult.ReturnRecordCount = -1;
            return DBResult;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    public string GetNewID(Page xPage)
    {
        string[] RIP = GetClientIP(xPage).Split('.');
        return DateDiff(DateInterval.Day, new DateTime(1965, 5, 4), DateTime.Today).ToString() + ("000" + RIP[3]).Substring(("000" + RIP[3]).Length - 3) + DateTime.Now.ToString("HHmmssffff");
    }
    public string GetClientIP(Page xPage)
    {
        
        string strIPAddr;
        System.Web.HttpRequest request = xPage.Request;
        if (request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null || request.ServerVariables["HTTP_X_FORWARDED_FOR"] == "" || request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf("unknown") > 0)
            strIPAddr = request.ServerVariables["REMOTE_ADDR"];
        else if (request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") > 0)
            strIPAddr = request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(0, request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") - 1);
        else if (request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") > 0)
            strIPAddr = request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(0, request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") - 1);
        else
            strIPAddr = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIPAddr.Length > 30)
            strIPAddr = strIPAddr.Substring(0, 30);
        return strIPAddr;
    }
    public string GetDMLRecord(string UserName, Page xPage)
    {
        return UserName + "/" + GetClientIP(xPage) + "/" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
    public string NullSafeString(object arg)
    {
        string ReturnValue = "";
        if (arg == null || string.IsNullOrEmpty(arg.ToString()))
        {
            ReturnValue = "";
        }
        else
        {
            try
            {
                ReturnValue = arg.ToString().Trim();
            }
            catch
            {
                ReturnValue = arg.ToString();
            }
        }
        return ReturnValue;
    }




    //public string getMD5(string strmd5)
    //{
    //    Byte[] data = System.Text.Encoding.Unicode.GetBytes(strmd5.ToCharArray());
    //    System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
    //    Byte[] result = md5.ComputeHash(data);
    //    string newMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strmd5.ToString(), "MD5");
    //    return newMD5;
    //}
    //結構體
    public enum DateInterval
    {
        Second, Minute, Hour, Day, Week, Month, Quarter, Year
    }
    //多型1，傳入字串
    public long DateDiff(string Interval, DateTime arg_StartDate, DateTime arg_EndDate)
    {
        DateInterval objDateInterval;
        switch (Interval)
        {
            case "s":
                objDateInterval = DateInterval.Second;
                break;
            case "n":
                objDateInterval = DateInterval.Minute;
                break;
            case "h":
                objDateInterval = DateInterval.Hour;
                break;
            case "d":
                objDateInterval = DateInterval.Day;
                break;
            case "w":
                objDateInterval = DateInterval.Week;
                break;
            case "m":
                objDateInterval = DateInterval.Month;
                break;
            case "q":
                objDateInterval = DateInterval.Quarter;
                break;
            case "y":
                objDateInterval = DateInterval.Year;
                break;
            default:
                objDateInterval = DateInterval.Second;
                break;
        }
        return this.DateDiff(objDateInterval, arg_StartDate, arg_EndDate);
    }
    //多型2，傳入結構體
    public long DateDiff(DateInterval arg_Interval, DateTime arg_StartDate, DateTime arg_EndDate)
    {
        long lngDateDiffValue = 0;
        System.TimeSpan objTimeSpan = new System.TimeSpan(arg_EndDate.Ticks - arg_StartDate.Ticks);
        switch (arg_Interval)
        {
            case DateInterval.Second:
                lngDateDiffValue = (long)objTimeSpan.TotalSeconds;
                break;
            case DateInterval.Minute:
                lngDateDiffValue = (long)objTimeSpan.TotalMinutes;
                break;
            case DateInterval.Hour:
                lngDateDiffValue = (long)objTimeSpan.TotalHours;
                break;
            case DateInterval.Day:
                lngDateDiffValue = (long)objTimeSpan.TotalDays;
                break;
            case DateInterval.Week:
                lngDateDiffValue = (long)(objTimeSpan.TotalSeconds / (7 * 24 * 60 * 60)); //一個星期7天
                break;
            case DateInterval.Month:
                lngDateDiffValue = (long)(objTimeSpan.TotalSeconds / (30 * 24 * 60 * 60)); //一個月計30天
                break;
            case DateInterval.Quarter:
                lngDateDiffValue = (long)(objTimeSpan.TotalSeconds / (90 * 24 * 60 * 60)); //一季計3月
                break;
            case DateInterval.Year:
                lngDateDiffValue = (long)(objTimeSpan.TotalSeconds / (365 * 24 * 60 * 60));   //一年計365天
                break;
        }
        return (lngDateDiffValue);
    }



    /// <summary>
    /// 彈出提示訊息。
    /// </summary>
    /// <param name="Message">訊息文字。</param>
    public static void MsgBox(Page xpage, string Message, string RedirectURL)
    {
        string sScript;
        string sMessage;

        sMessage = Message.Replace("'", "\'");
        //處理單引號
        // sMessage = Strings.Replace(sMessage, vbNewLine, "\\n");
        //處理換行
        sScript = string.Format("alert('{0}');", sMessage);
        if (RedirectURL.Length > 0)
        {
            sScript = sScript + "window.location.href=\"" + RedirectURL + "\";";
        }
        ScriptManager.RegisterStartupScript(xpage, xpage.GetType(), "alert", sScript, true);
    }


    public static string GetCheckBoxValue(CheckBox aaa)
    {
        string args = "N";
        if (aaa.Checked == true) {
            args = "Y";
        }
        return args;
    }

 
    public static bool CheckEmailRegular(string Email)
    {
        Regex reg = new Regex("^(?(\")(\".+?\"@)|(([0-9a-zA-Z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-zA-Z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,6}))$");
        return reg.IsMatch(Email);
    }

    public static bool IsDate(string inputDate)
    {
        DateTime dt;
        return DateTime.TryParse(inputDate, out dt);
    }

    public static bool IsNumeric(object Expression)
    {
        // Variable to collect the Return value of the TryParse method.
        bool isNum;
        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
        double retNum;
        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

        return isNum;
    }

    public static string ImageUrlConvert(string strSource ,Page xpage)
    {
        string args = string.Empty;
        string sben  = "http://" + xpage.Request.Url.Host + "/" + xpage.Request.Url.Segments[1];
        args = strSource.Replace(sben, "");
        return args;
    }

   

    public static void FillFineUIDropDownList(FineUIPro.DropDownList obj, string strSQL, string DefaultVlue)
    {
        obj.Items.Clear();
        DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        obj.Items.Add("請選擇", "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            obj.Items.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
        }
        if (DefaultVlue != "")
        {
            obj.SelectedValue = DefaultVlue;
        }
        else
        {
            obj.SelectedValue = "";
        }
       
    }

    public static void FillFineUIRadioButtonList(FineUIPro.RadioButtonList obj, string strSQL, string DefaultVlue)
    {
        obj.Items.Clear();
        DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
        //obj.Items.Add("請選擇", "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            obj.Items.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
        }
        if (DefaultVlue != "")
        {
            obj.SelectedValue = DefaultVlue;
        }
        else
        {
            obj.SelectedValue = "";
        }
    }

    public string GetCreated(Page xpage)
    {
        string args = string.Empty;
        string UserID = string.Empty;
        if (HttpUtility.UrlDecode(xpage.Request.Cookies["UserID"].Value) != null)
        {
            //Retrieving UserName from Session
            UserID = HttpUtility.UrlDecode(xpage.Request.Cookies["UserID"].Value);
        }
        args = UserID + "/" + GetClientIP(xpage) + "/" + GetNowString();
        return args;
    }
    public string GetNowString()
    {
        return DateTime.Now.ToString("yyyyMMddhhmmssfff");
    }
        public static void FillFineUICheckBoxList(FineUIPro.CheckBoxList obj, string strSQL, string DefaultVlue)
        {
            obj.Items.Clear();
            DataTable dt = DB.getObject().GetData(strSQL).ReturnDataTable;
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                obj.Items.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                if (DefaultVlue != "")
                {
                    string[] SelectValue = DefaultVlue.Split(',');
                    foreach (string x in SelectValue)
                    {
                        if (x == dt.Rows[i][0].ToString())
                        {
                            obj.Items[i].Selected = true;
                        }
                    }
                }
            }
        if (DefaultVlue != "")
        {
            for (int i = 0; i < obj.Items.Count; i++)
            {
                string[] SelectValue = DefaultVlue.Split(',');
                foreach (string x in SelectValue)
                {
                    if (x == obj.Items[i].Value )
                    {
                        obj.Items[i].Selected = true;
                    }
                }
                    
            }
        }
        }
    public  DataTable GetPagedDataTable(DataTable dt, int pageIndex, int pageSize)
    {


        DataTable paged = dt.Clone();

        int rowbegin = pageIndex * pageSize;
        int rowend = (pageIndex + 1) * pageSize;
        if (rowend > dt.Rows.Count)
        {
            rowend = dt.Rows.Count;
        }

        for (int i = rowbegin; i < rowend; i++)
        {
            paged.ImportRow(dt.Rows[i]);
        }

        return paged;
    }
    //取得會員編號
    public static  string GetMemberNo()
    {
        string args = string.Empty;
        string strSQL = @"Select top 1 MemberID From tblMember Where Left(MemberID,2) = 'TW' order by MemberID Desc";
        DataTable dt = DB.getObject().GetData(strSQL, null, false).ReturnDataTable;

        if (dt.Rows.Count > 0)
        {
            string strLast = dt.Rows[0][0].ToString();
            int NewNo = Convert.ToInt32(strLast.Substring(2, 6)) + 1;
            strLast = ("000000" + NewNo.ToString());
            args = "TW" + strLast.Substring(strLast.Length - 6, 6);
        }
        else
        {
            args = "TW" + "000001";
        }
        return args;
    }
    public static string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }
    public static string GetNo(string NoType)
    {
        string strSQL = "";
        string args = "";
        if (NoType == "EmpNo")
        {
            strSQL = "Select NowNum From tblGiveNo Where NoType ='EmpNo'";
            string xNo = DB.getObject().GetData(strSQL, null, false).ReturnDataTable.Rows[0][0].ToString();
            int xNum = Convert.ToInt32(xNo) + 1;
            args = xNum.ToString();
        }
        if (NoType == "OrderNo")
        {
            strSQL = "Select NowNum From tblGiveNo Where NoType ='OrderNo'";
            string xNo = DB.getObject().GetData(strSQL, null, false).ReturnDataTable.Rows[0][0].ToString();
            string xDate = xNo.Substring(0, 4) ;
            args = DateTime.Now.ToString("yyyy") + "00001";
            if (DateTime.Today.ToString("yyyy") == xDate)
            {
                int xNum = Convert.ToInt16(xNo.Substring(4, 5));
                string sString = "00000" + (xNum + 1).ToString();
                args = DateTime.Now.ToString("yyyy") + sString.Substring(sString.Length - 5, 5);
            }
        }
        strSQL = "Update tblGiveNo Set NowNum ='" + args + "' Where Notype='" + NoType + "'";
        DB.getObject().Execute(strSQL, null, false);
        return args;
    }

    /// 发送请求  
    /// </summary>  
    /// <param name="url">请求地址</param>  
    /// <param name="sendData">参数格式 “name=王武&pass=123456”</param>  
    /// <returns></returns>  
    public static string RequestWebAPI(string url, string sendData)
    {
        string backMsg = "";
        try
        {
            System.Net.WebRequest httpRquest = System.Net.HttpWebRequest.Create(url);
            httpRquest.Method = "POST";
            //这行代码很关键，不设置ContentType将导致后台参数获取不到值  
            httpRquest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            httpRquest.Headers.Add("","");
            byte[] dataArray = System.Text.Encoding.UTF8.GetBytes(sendData);
            //httpRquest.ContentLength = dataArray.Length;  
            System.IO.Stream requestStream = null;
            if (string.IsNullOrWhiteSpace(sendData) == false)
            {
                requestStream = httpRquest.GetRequestStream();
                requestStream.Write(dataArray, 0, dataArray.Length);
                requestStream.Close();
            }
            System.Net.WebResponse response = httpRquest.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);
            backMsg = reader.ReadToEnd();


            reader.Close();
            reader.Dispose();


            requestStream.Dispose();
            responseStream.Close();
            responseStream.Dispose();
        }
        catch (Exception)
        {
            throw;
        }
        return backMsg;
    }

    public string GetRandomAmimate()
    {
        string args = string.Empty;
        ArrayList Amimates = new ArrayList();
        Amimates.Add("bounce");
        Amimates.Add("flash");
        Amimates.Add("pulse");
        Amimates.Add("rubberBand");
        Amimates.Add("shake");
        Amimates.Add("headShake");
        Amimates.Add("swing");
        Amimates.Add("tada");
        Amimates.Add("wobble");
        Amimates.Add("jello");
        Amimates.Add("bounceIn");
        Amimates.Add("bounceInDown");
        Amimates.Add("bounceInLeft");
        Amimates.Add("bounceInRight");
        Amimates.Add("bounceInUp");
        Amimates.Add("fadeIn");
        Amimates.Add("fadeInDown");
        Amimates.Add("fadeInDownBig");
        Amimates.Add("fadeInLeft");
        Amimates.Add("fadeInLeftBig");
        Amimates.Add("fadeInRight");
        Amimates.Add("fadeInRightBig");
        Amimates.Add("fadeInUp");
        Amimates.Add("fadeInUpBig");
        Amimates.Add("flip");
        Amimates.Add("flipInX");
        Amimates.Add("flipInY");
        Amimates.Add("rotateIn");
        Amimates.Add("rotateInDownLeft");
        Amimates.Add("rotateInDownRight");
        Amimates.Add("rotateInUpLeft");
        Amimates.Add("rotateInUpRight");
        Amimates.Add("slideInDown");
        Amimates.Add("slideInLeft");
        Amimates.Add("slideInRight");
        Amimates.Add("slideInUp");
        Amimates.Add("zoomIn");
        Amimates.Add("zoomInDown");
        Amimates.Add("zoomInLeft");
        Amimates.Add("zoomInRight");
        Amimates.Add("zoomInUp");
        Amimates.Add("rollIn");
        Amimates.Add("lightSpeedIn");

        Random ro = new Random(unchecked((int)DateTime.Now.Ticks));

        // 方法1：指定随机数上下限，产生上下限中的随机整数
        int RoInt = ro.Next(1, Amimates.Count);
        
        args = "animated " + Amimates[RoInt].ToString();
        return args;
    }

    public string GetRandomAmimate1()
    {
        string args = "bounce";
        ArrayList Amimates = new ArrayList();
        Amimates.Add("bounce");
        Amimates.Add("flash");
        Amimates.Add("pulse");
        Amimates.Add("rubberBand");
        Amimates.Add("shake");
        Amimates.Add("headShake");
        Amimates.Add("swing");
        Amimates.Add("tada");
        Amimates.Add("wobble");
        Amimates.Add("jello");
        Amimates.Add("bounceIn");
        Amimates.Add("bounceInDown");
        Amimates.Add("bounceInLeft");
        Amimates.Add("bounceInRight");
        Amimates.Add("bounceInUp");
        Amimates.Add("fadeIn");
        Amimates.Add("fadeInDown");
        Amimates.Add("fadeInDownBig");
        Amimates.Add("fadeInLeft");
        Amimates.Add("fadeInLeftBig");
        Amimates.Add("fadeInRight");
        Amimates.Add("fadeInRightBig");
        Amimates.Add("fadeInUp");
        Amimates.Add("fadeInUpBig");
        Amimates.Add("flip");
        Amimates.Add("flipInX");
        Amimates.Add("flipInY");
        Amimates.Add("rotateIn");
        Amimates.Add("rotateInDownLeft");
        Amimates.Add("rotateInDownRight");
        Amimates.Add("rotateInUpLeft");
        Amimates.Add("rotateInUpRight");
        Amimates.Add("slideInDown");
        Amimates.Add("slideInLeft");
        Amimates.Add("slideInRight");
        Amimates.Add("slideInUp");
        Amimates.Add("zoomIn");
        Amimates.Add("zoomInDown");
        Amimates.Add("zoomInLeft");
        Amimates.Add("zoomInRight");
        Amimates.Add("zoomInUp");
        Amimates.Add("rollIn");
        Amimates.Add("lightSpeedIn");

        Random ro = new Random(unchecked((int)DateTime.Now.Ticks));
        try
        {
            // 方法1：指定随机数上下限，产生上下限中的随机整数
            int RoInt = ro.Next(1, Amimates.Count);

            args = "animated " + Amimates[RoInt+5].ToString();
        }
        catch { }
        
        return args;
    }

    /**/
    //// <summary> 
    /**/
    /// 生成缩略图 
    /**/
    /// </summary> 
    /**/
    /// <param name="originalImagePath">源图路径（物理路径）</param> 
    /**/
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param> 
    /**/
    /// <param name="width">缩略图宽度</param> 
    /**/
    /// <param name="height">缩略图高度</param> 
    public void MakeThumbnail(string originalImagePath, string thumbnailPath)
    {
        //获取原始图片 
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
        //缩略图画布宽高 
        int width = originalImage.Width;
        int height = originalImage.Height;
        int towidth = width;
        int toheight = height;
        //原始图片写入画布坐标和宽高(用来设置裁减溢出部分) 
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        //原始图片画布,设置写入缩略图画布坐标和宽高(用来原始图片整体宽高缩放) 
        int bg_x = 0;
        int bg_y = 0;
        int bg_w = towidth;
        int bg_h = toheight;
        //倍数变量 
        double multiple = 0;
        //获取宽长的或是高长与缩略图的倍数 
        if (originalImage.Width >= originalImage.Height) multiple = (double)originalImage.Width / (double)width;
        else multiple = (double)originalImage.Height / (double)height;
        //上传的图片的宽和高小等于缩略图 
        if (ow <= width && oh <= height)
        {
            //缩略图按原始宽高 
            bg_w = originalImage.Width;
            bg_h = originalImage.Height;
            //空白部分用背景色填充 
            bg_x = Convert.ToInt32(((double)towidth - (double)ow) / 2);
            bg_y = Convert.ToInt32(((double)toheight - (double)oh) / 2);
        }
        //上传的图片的宽和高大于缩略图 
        else
        {
            //宽高按比例缩放 
            bg_w = Convert.ToInt32((double)originalImage.Width / multiple);
            bg_h = Convert.ToInt32((double)originalImage.Height / multiple);
            //空白部分用背景色填充 
            bg_y = Convert.ToInt32(((double)height - (double)bg_h) / 2);
            bg_x = Convert.ToInt32(((double)width - (double)bg_w) / 2);
        }
        //新建一个bmp图片,并设置缩略图大小. 
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
        //新建一个画板 
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法 
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        //设置高质量,低速度呈现平滑程度 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //清空画布并设置背景色 
        g.Clear(System.Drawing.ColorTranslator.FromHtml("#F2F2F2"));
        //在指定位置并且按指定大小绘制原图片的指定部分 
        //第一个System.Drawing.Rectangle是原图片的画布坐标和宽高,第二个是原图片写在画布上的坐标和宽高,最后一个参数是指定数值单位为像素 
        g.DrawImage(originalImage, new System.Drawing.Rectangle(bg_x, bg_y, bg_w, bg_h), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);
        try
        {
            //获取图片类型 
            string fileExtension = System.IO.Path.GetExtension(originalImagePath).ToLower();
            //按原图片类型保存缩略图片,不按原格式图片会出现模糊,锯齿等问题. 
            switch (fileExtension)
            {
                case ".gif": bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Gif); break;
                case ".jpg": bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                case ".bmp": bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Bmp); break;
                case ".png": bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png); break;
            }
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }


    public  System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, int width ,int height)
    {
        //获取图片宽度
        int sourceWidth = imgToResize.Width;
        //获取图片高度
        int sourceHeight = imgToResize.Height;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;
        //计算宽度的缩放比例
        nPercentW = ((float)width / (float)sourceWidth);
        //计算高度的缩放比例
        nPercentH = ((float)height / (float)sourceHeight);

        if (nPercentH < nPercentW)
            nPercent = nPercentH;
        else
            nPercent = nPercentW;
        //期望的宽度
        int destWidth = (int)(sourceWidth * nPercent);
        //期望的高度
        int destHeight = (int)(sourceHeight * nPercent);

        System.Drawing.Bitmap b = new System.Drawing.Bitmap(destWidth, destHeight);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage((System.Drawing.Image)b);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //绘制图像
        g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        g.Dispose();
        return (System.Drawing.Image)b;
    }

    public ArrayList GetIndustry()
    {
        ArrayList args = new ArrayList();
        args.Add("机构组织");
        args.Add("农林牧渔");
        args.Add("医药卫生");
        args.Add("建筑建材");
        args.Add("冶金矿产");
        args.Add("石油化工");
        args.Add("水利水电");
        args.Add("交通运输");
        args.Add("信息产业");
        args.Add("机械机电");
        args.Add("轻工食品");
        args.Add("服装纺织");
        args.Add("专业服务");
        args.Add("安全防护");
        args.Add("环保绿化");
        args.Add("旅游休闲");
        args.Add("办公文教");
        args.Add("电子电工");
        args.Add("玩具礼品");
        args.Add("家居用品");
        args.Add("物资");
        args.Add("包装");
        args.Add("体育");
        args.Add("办公");
        return args;
    }

    //增加控件 cssclass 属性，是往上加
    
}





//回傳執行結果
public class DBResult
{
    //是否成功
    public Boolean Success;
    //回傳碼(被影響的筆數)
    public int ReturnCode;
    //資料表(或view
    public System.Data.DataTable ReturnDataTable;
    //錯誤訊息
    public string ExceptionMessage;
    //回傳筆數
    public int ReturnRecordCount;
}
public class DBResultUseDataSet
{
    //是否成功
    public Boolean Success;
    //回傳碼(被影響的筆數)
    public int ReturnCode;
    //資料表(或view
    public System.Data.DataSet ReturnDataSet;
    //錯誤訊息
    public string ExceptionMessage;
    //回傳筆數
    public int ReturnRecordCount;
}

public class HowManyGridSelect
{
    public int SelectCount;
    public ArrayList SelectID;
}

public class OracleDB
{
   
    private string OracleConnectionString = "Provider=msdaora;Data Source=HDAPP;User Id=hd40;Password=hd40";

}

