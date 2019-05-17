using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    DataAccess dataAccess = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUserName.Visible = false;
        lblPassword.Visible = false;
    }

    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {
        lblPassword.Visible = false;
    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        lblUserName.Visible = false;
    }

    protected void linkbtnRegister_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == "")
        {
            lblUserName.Visible = true;
        }
        else
        {
            lblUserName.Visible = false;
        }
        if (txtPassword.Text == "")
        {
            lblPassword.Visible = true;
        }
        else
        {
            lblPassword.Visible = false;
        }

        if (txtUserName.Text != "" && txtPassword.Text != "")
        {
            string pattern = "^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{8,16}$";
            User user = dataAccess.GetUser(txtUserName.Text);
            if (user!=null && !string.IsNullOrEmpty(user.UserName))
            {
                lblUserName.Visible = true;
                lblUserName.Text = "用户名已存在！";
            }
            else if (!Regex.IsMatch(txtPassword.Text, pattern)) {
                lblPassword.Visible = true;
                lblPassword.Text = "8-16位数字或字母";
                //^ 匹配一行的开头位置
                //(?![0 - 9] +$) 预测该位置后面不全是数字
                //(?![a - zA - Z] +$) 预测该位置后面不全是字母
                //[0 - 9A - Za - z] { 8,16}
                //由8 - 16位数字或这字母组成
                //$ 匹配行结尾位置
            }
            else
            {
                DateTime date = DateTime.Now;
                user = new User() {
                    UserName = txtUserName.Text,
                    Password=txtPassword.Text,
                    UserLevel="0",
                    RegisterDate = date,
                    LastAccessDate = date,
                    AccessCount=1,
                    Active="Y",
                    IsOauth2 = "N"
                };
                user = dataAccess.setUser(user);

                Session["isLogin"] = "Y";
                Session["user"] = user;
                Response.Redirect("Manage");
            }
        }

    }
}