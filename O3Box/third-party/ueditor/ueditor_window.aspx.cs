﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace FineUIPro.Examples.aspnet
{
    public partial class ueditor_window : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlEditor1.Text = "<p>FineUIPro<br>基于 jQuery 的专业 ASP.NET 控件库。<br><br>FineUI的使命<br>创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序。<br><br>支持的浏览器<br>Edge、Chrome、Firefox、Safari、IE 8.0+<br><br>相关链接<br>首页：http://fineui.com/pro/<br>示例：http://pro.fineui.com/<br>更新：http://fineui.com/pro/version/</p>";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(HtmlEditor1.Text))
            {
                ShowNotify("编辑器内容为空！");
            }
            else
            {
                ShowNotify(HttpUtility.HtmlEncode(HtmlEditor1.Text));
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string content = "<p><strong>FineUIPro</strong> - 基于 jQuery 的专业 ASP.NET 控件库。</p>";
            HtmlEditor1.Text = content;
        }





    }
}
