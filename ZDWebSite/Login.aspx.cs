using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    string loginFrom = "";
    DataAccess dataAccess = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        //第一次加载不满足条件，之后均满足（除Cookie到时间了），将Cookie数据输出到TextBox里
        if (Request.Cookies["username"] != null)
        {
            txtUserName.Text = Request.Cookies["username"].Value.ToString();
        }
        lblUserName.Visible = false;
        lblPassword.Visible = false;

        if (!Page.IsPostBack) {
            loginWechat();
        } 

    }

    protected void linkbtnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == "") {
            lblUserName.Visible = true;
        }
        else {
            lblUserName.Visible = false;
        }
        if (txtPassword.Text == "")
        {
            lblPassword.Visible = true;
        }
        else {
            lblPassword.Visible = false;
        }

        if (txtUserName.Text != "" && txtPassword.Text != "") {
            if (dataAccess.CheckUserExist(txtUserName.Text, txtPassword.Text))
            {
                if (chkRemenberMe.Checked)
                {
                    //创建Cookie对象，保存Cookie数据，设置Cookie保存时间
                    Response.Cookies["username"].Value = txtUserName.Text;
                    Response.Cookies["username"].Expires = DateTime.Now.AddSeconds(10);
                }
                Session["isLogin"] = "Y";
                Session["user"] = dataAccess.GetUser(txtUserName.Text);
                Response.Redirect("Manage.aspx");
            }
            else {
                lblPassword.Visible = true;
                lblPassword.Text = "请输入正确的用户名和密码！";
            }
        }

    }

    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {
        lblPassword.Visible = false;
    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        lblUserName.Visible = false;
    }

    protected void linkbtnWechat_Click(object sender, EventArgs e)
    {
        loginFrom = "Wechat";
        loginWechat();
    }

    private void loginWechat() {
        // 获取appId,appSecret的配置信息
        string appId = ConfigHelper.GetConfigString("appId");
        string appSecret = ConfigHelper.GetConfigString("appSecret");

        var weixinOAuth = new WeiXinOAuth();
        //微信第一次握手后得到的code 和state
        string code = Request.QueryString["code"];
        string state = Request.QueryString["state"];
        if (string.IsNullOrEmpty(code) || code == "authdeny")
        {
            if (string.IsNullOrEmpty(code) && loginFrom.Equals("Wechat"))
            {
                //发起授权(第一次微信握手)
                //string authUrl = weixinOAuth.GetWeiXinCode(appId, appSecret, Server.UrlEncode(Request.Url.ToString()), true);
                string authUrl = weixinOAuth.GetWeiXinCode(appId, appSecret, Server.UrlEncode("http://zigecha.com/zd/Login"), true);

                Response.Redirect(authUrl, true);
            }
            else
            {
                // 用户取消授权
                return;
            }
        }
        else
        {
            //获取微信的Access_Token（第二次微信握手）
            var modelResult = weixinOAuth.GetWeiXinAccessToken(appId, appSecret, code);
            //获取微信的用户信息(第三次微信握手)
            var userInfo = weixinOAuth.GetWeiXinUserInfo(modelResult.SuccessResult.access_token, modelResult.SuccessResult.openid);
            //用户信息（判断是否已经获取到用户的微信用户信息）
            if (userInfo.Result && userInfo.UserInfo.openid != "")
            {
                //根据OpenId判断数据库是否存在，如果存在，直接登录即可
                User user = dataAccess.GetUserByOpenId(userInfo.UserInfo.openid);
                if (user != null && user.UserId > 0)
                {
                    //直接登录即可  根据授权ID，查询用户信息
                    Session["isLogin"] = "Y";
                    Session["user"] = user;
                    Session["user_oauth2"] = dataAccess.GetUserOauth2ByOpenId(userInfo.UserInfo.openid);
                    Response.Redirect("Manage");
                }
                else
                {
                    DateTime date = DateTime.Today;
                    //注册操作
                    user = new User()
                    {
                        IsOauth2 = "Y",
                        Active = "Y",
                        RegisterDate = date,
                        AccessCount = 1,
                        UserLevel = "0",
                        LastAccessDate = date,
                        UserName = "oa2-" + Guid.NewGuid(),
                        Password = "88888888"
                    };
                    user = dataAccess.setUser(user);
                    if (user.UserId > 0)
                    {
                        // set user base profile
                        UserOauth2 userOauth2 = new UserOauth2()
                        {
                            UserId = user.UserId,
                            HeadImgUrl = userInfo.UserInfo.headimgurl,
                            NickName = userInfo.UserInfo.nickname,
                            Sex = userInfo.UserInfo.sex,
                            Country = userInfo.UserInfo.country,
                            City = userInfo.UserInfo.city,
                            Province = userInfo.UserInfo.province,
                            OpenId = userInfo.UserInfo.openid,
                            Oauth2From = "Wechat",
                            UpdateDate = date
                        };
                        int count = dataAccess.setUserOauth2(userOauth2);
                        if (count > 0)
                        {
                            //授权成功后，直接返回到Manage
                            Session["isLogin"] = "Y";
                            Session["user"] = user;
                            Session["user_oauth2"] = userOauth2;
                            Response.Redirect("Manage");
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Login", true);
            }
        }
    }

    protected void linkbtnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register", true);
    }
}