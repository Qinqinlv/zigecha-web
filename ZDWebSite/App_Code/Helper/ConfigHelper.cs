using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConfigHelper
/// </summary>
public class ConfigHelper
{
    public ConfigHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetConfigString(string key) {
        //根据Key读取元素的Value
        string value = ConfigurationManager.AppSettings[key].ToString();
        return value;
    }
}