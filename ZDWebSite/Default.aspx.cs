using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtSouSuo.Attributes.Add("Value", "输入资格证\\姓名\\公司");
        //txtSouSuo.Attributes.Add("OnFocus", "if(this.value=='输入资格证\\\\姓名\\\\公司') {this.value=''}");
        //txtSouSuo.Attributes.Add("OnBlur", "if(this.value==''){this.value='输入资格证\\\\姓名\\\\公司'}");
    }

    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {
        string queryValue = txtSouSuo.Text;
        queryValue = Des.DesEncrypt(queryValue, Des.desKey);
        queryValue = HttpUtility.UrlEncode(queryValue, System.Text.Encoding.UTF8);
        Response.Redirect("QueryResult?queryValue=" + queryValue);
    }

    protected void imgbtnWoDe_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["isLogin"] == null)
        {
            Response.Redirect("Login");
        }
        else {
            Response.Redirect("Manage");
        }
    }

    protected void linkBtnChaZhengShu_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryMore.aspx");
    }

    protected void linkBtnChaZiZi_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryMore.aspx");
    }
}