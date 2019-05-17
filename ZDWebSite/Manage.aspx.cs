using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage : System.Web.UI.Page
{
    UserOauth2 userOauth2 = new UserOauth2();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isLogin"] == null)
        {
            Response.Redirect("Login");
        }
        else {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                lblUserLevel.Text = getUserLevelDesc(user.UserLevel);
                lblUserName.Text = user.UserName;
                if (user.IsOauth2 == "Y")
                {
                    if (Session["user_oauth2"] != null)
                    {
                        userOauth2 = (UserOauth2)Session["user_oauth2"];
                        imgHeadImage.ImageUrl = userOauth2.HeadImgUrl;
                        lblNickName.Text = userOauth2.NickName;
                        
                    }
                }
                else {
                    //get user profile information
                }
            }
            
        }

    }

    private string getUserLevelDesc(string userLevel) {

        string userLevelDesc = "";
        if (userLevel == "0") {
            userLevelDesc = "普通用户";
        }
        else if (userLevel == "1")
        {
            userLevelDesc = "系统管理员";
        }
        else if (userLevel == "2")
        {
            userLevelDesc = "合作伙伴";
        }

        return userLevelDesc;
    }

    private void intUserBasicInformation() {


    }

    protected void imgBtnCheckIn_Click(object sender, ImageClickEventArgs e)
    {
        if (!string.IsNullOrEmpty(userOauth2.OpenId)) {
            Response.Redirect("CheckInAmount?openId=" + userOauth2.OpenId);
        }
    }
}