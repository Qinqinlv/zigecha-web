using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int userId;
    private string userName;
    private string password;
    private string userLevel;
    private DateTime registerDate;
    private int accessCount;
    private DateTime lastAccessDate;
    private string active;
    private string isOauth2;

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

    public string UserName
    {
        get
        {
            return userName;
        }

        set
        {
            userName = value;
        }
    }

    public string Password
    {
        get
        {
            return Password1;
        }

        set
        {
            Password1 = value;
        }
    }

    public string Password1
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public string UserLevel
    {
        get
        {
            return userLevel;
        }

        set
        {
            userLevel = value;
        }
    }

    public DateTime RegisterDate
    {
        get
        {
            return registerDate;
        }

        set
        {
            registerDate = value;
        }
    }

    public int AccessCount
    {
        get
        {
            return accessCount;
        }

        set
        {
            accessCount = value;
        }
    }

    public DateTime LastAccessDate
    {
        get
        {
            return lastAccessDate;
        }

        set
        {
            lastAccessDate = value;
        }
    }

    public string Active
    {
        get
        {
            return active;
        }

        set
        {
            active = value;
        }
    }

    public string IsOauth2
    {
        get
        {
            return isOauth2;
        }

        set
        {
            isOauth2 = value;
        }
    }
}