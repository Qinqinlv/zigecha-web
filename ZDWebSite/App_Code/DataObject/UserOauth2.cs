using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserOauth2
/// </summary>
public class UserOauth2
{
    public UserOauth2()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int userOauth2Id;
    private int userId;
    private string headImgUrl;
    private string nickName;
    private string sex;
    private string country;
    private string province;
    private string city;
    private string openId;
    private string oauth2From;
    private DateTime updateDate;

    public int UserOauth2Id
    {
        get
        {
            return userOauth2Id;
        }

        set
        {
            userOauth2Id = value;
        }
    }

    public int UserId
    {
        get
        {
            return userId;
        }

        set
        {
            userId = value;
        }
    }

    public string HeadImgUrl
    {
        get
        {
            return headImgUrl;
        }

        set
        {
            headImgUrl = value;
        }
    }

    public string NickName
    {
        get
        {
            return nickName;
        }

        set
        {
            nickName = value;
        }
    }

    public string Sex
    {
        get
        {
            return sex;
        }

        set
        {
            sex = value;
        }
    }

    public string Country
    {
        get
        {
            return country;
        }

        set
        {
            country = value;
        }
    }

    public string Province
    {
        get
        {
            return province;
        }

        set
        {
            province = value;
        }
    }

    public string City
    {
        get
        {
            return city;
        }

        set
        {
            city = value;
        }
    }

    public string OpenId
    {
        get
        {
            return openId;
        }

        set
        {
            openId = value;
        }
    }

    public string Oauth2From
    {
        get
        {
            return oauth2From;
        }

        set
        {
            oauth2From = value;
        }
    }

    public DateTime UpdateDate
    {
        get
        {
            return updateDate;
        }

        set
        {
            updateDate = value;
        }
    }
}