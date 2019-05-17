using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for HttpHelper
/// </summary>
public class HttpHelper
{
    public HttpHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetHttp(string url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        var response = (HttpWebResponse)request.GetResponse();
        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

        return responseString;
    }

}