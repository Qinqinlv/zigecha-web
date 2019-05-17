using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckInAmount : System.Web.UI.Page
{
    private string openId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        openId = Request.QueryString["openId"];
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string total_fee = "1";
        openId = "oiTft5wtEpIuohCVdUkOJKNQoe40";//Request.QueryString["openId"];
        if (!string.IsNullOrEmpty(openId))
        {
            string url = "JsApiWeiXinPay?openid=" + openId + "&total_fee=" + total_fee;
            Response.Redirect(url);
        }
        else
        {
            Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面缺少参数，请返回重试" + "</span>");
            Button1.Visible = false;
            Button2.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}