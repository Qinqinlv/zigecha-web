using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StringHelper
/// </summary>
public class StringHelper
{
    public StringHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string ConvertIntListToSqlString(List<int> ids)
    {
        string str = "";
        for (int i = 0; i < ids.Count; i++)
        {
            str = str + ids[i] + ",";
        }
        str = str.Substring(0, str.Length - 1);
        return str;
    }
}