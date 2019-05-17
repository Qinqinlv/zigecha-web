using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BasicInformation
/// </summary>
public class BasicInformation
{
    public BasicInformation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int basicId;
    private string fullName;
    private string province;
    private string companyName;
    private string certificateType;
    private string registeredMajor;
    private string certificateLevel;
    private string sex;

    

    public string FullName
    {
        get
        {
            return fullName;
        }

        set
        {
            fullName = value;
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

    public string CompanyName
    {
        get
        {
            return companyName;
        }

        set
        {
            companyName = value;
        }
    }

    public string CertificateType
    {
        get
        {
            return certificateType;
        }

        set
        {
            certificateType = value;
        }
    }

    public string RegisteredMajor
    {
        get
        {
            return registeredMajor;
        }

        set
        {
            registeredMajor = value;
        }
    }

    public string CertificateLevel
    {
        get
        {
            return certificateLevel;
        }

        set
        {
            certificateLevel = value;
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

    public int BasicId
    {
        get
        {
            return basicId;
        }

        set
        {
            basicId = value;
        }
    }
}