using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WeiXinAccessTokenResult
/// </summary>
public class WeiXinAccessTokenResult
{
    public WeiXinAccessTokenResult()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public WeiXinAccessTokenModel SuccessResult { get; set; }
    public bool Result { get; set; }

    public WeiXinHelper.WeiXinErrorMsg ErrorResult { get; set; }
}