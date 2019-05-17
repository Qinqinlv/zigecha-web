using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QueryMore : System.Web.UI.Page
{
    public string queryValue;
    public string total;
    public string queryType;

    DataAccess dataAccess = new DataAccess();
    List<BasicInformation> basicInformations;
    static int frontBasicId;
    static int lastBasicId;
    string currentQueryType;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        basicInformations = new List<BasicInformation>();

        //zhengshu
        //contral visibility
        dlistChaZhengShu.Visible = false;
        lblWuZhengShu.Visible = false;
        linkbtnUpZhengShu.Visible = false;
        linkbtnNextZhengShu.Visible = false;
        linkbtnChaZhengShu.Visible = false;
        //contral enable
        linkbtnUpZhengShu.Enabled = false;
        linkbtnNextZhengShu.Enabled = false;

        //zizhi
        //contral visibility
        dlistChaZiZhi.Visible = false;
        lblWuZiZhi.Visible = false;
        linkbtnUpZiZhi.Visible = false;
        linkbtnNextZiZhi.Visible = false;
        linkbtnChaZiZhi.Visible = false;
        //contral enable
        linkbtnUpZiZhi.Enabled = false;
        linkbtnNextZiZhi.Enabled = false;


        if (currentQueryType != queryType)
        {
            lastBasicId = 0;
        }

        if (!Page.IsPostBack)
        {
            lastBasicId = 0;

            queryValue = Request.QueryString["queryValue"];
            queryValue = Des.DesDecrypt(queryValue, Des.desKey);

            total = Request.QueryString["total"];
            total = Des.DesDecrypt(total, Des.desKey);

            queryType = Request.QueryString["queryType"];
            //init data


            initBasicInformation(queryValue, 20, lastBasicId);
        }

        Page.DataBind();

    }


    private void initBasicInformation(string queryCondition, int limitLine, int afterBasicId)
    {
        if (queryType == "zhengshu")
        {
            currentQueryType = queryType;
            initPersonalBasicInformation(queryCondition, limitLine, afterBasicId);
        }
        else if (queryType == "zizhi")
        {
            currentQueryType = queryType;
            initCompanyBasicInformation(queryCondition, limitLine, afterBasicId);
        }
    }

    private void initPersonalBasicInformation(string queryCondition, int limitLine, int afterBasicId)
    {
        List<int> basicIds = new List<int>();
        if (afterBasicId == 0)
        {
            basicIds = dataAccess.GetBasicIdsByCertificateType(queryCondition, limitLine);
        }
        else {
            basicIds = dataAccess.GetBasicIdsByCertificateTypeAndAfterBasicId(queryCondition, limitLine, afterBasicId);
        }
        
        
        if (basicIds != null && basicIds.Count > 0)
        {
            frontBasicId = basicIds[0];
            lastBasicId = basicIds[basicIds.Count-1];
            basicInformations = dataAccess.GetPersonBasicInformationByBasicIds(basicIds);

            if (basicInformations != null && basicInformations.Count > 0)
            {
                List<BasicInformation> basicInformationDetails = dataAccess.GetBasicInformationByBasicIds(basicIds);
                foreach (BasicInformation basicInformation in basicInformations)
                {
                    string registeredMajor = "";
                    string newFullName = "";
                    foreach (BasicInformation basicInformationDetail in basicInformationDetails)
                    {

                        if (basicInformation.BasicId.Equals(basicInformationDetail.BasicId))
                        {
                            if (String.IsNullOrEmpty(basicInformationDetail.RegisteredMajor))
                            {
                                continue;
                            }
                            registeredMajor = registeredMajor + basicInformationDetail.RegisteredMajor + "\\";

                        }
                    }
                    if (registeredMajor.Length > 0)
                    {
                        registeredMajor = registeredMajor.Substring(0, registeredMajor.Length - 1);
                    }
                    basicInformation.RegisteredMajor = registeredMajor;
                    newFullName = getNewFullName(basicInformation.FullName);
                    basicInformation.FullName = newFullName;
                }
                
                linkbtnUpZhengShu.Visible = true;
                linkbtnNextZhengShu.Visible = true;
                linkbtnChaZhengShu.Visible = true;
                dlistChaZhengShu.Visible = true;
                lblWuZhengShu.Visible = false;
                dlistChaZhengShu.DataSource = basicInformations;
                dlistChaZhengShu.DataBind();
                if (basicInformations.Count == limitLine)
                {
                    linkbtnNextZhengShu.Enabled = true;
                }
                else
                {
                    linkbtnNextZhengShu.Enabled = false;
                }

            }
            else
            {
                lblWuZhengShu.Visible = true;
            }
        }
        else
        {
            lblWuZhengShu.Visible = true;
        }
    }


    private string getNewFullName(string fullName)
    {
        string newFullName = "";

        if (string.IsNullOrEmpty(fullName))
        {
            return newFullName;
        }

        if (fullName.Length == 1)
        {
            return fullName;
        }
        else if (fullName.Length == 2)
        {
            string str1 = fullName.Substring(0, 1);
            string str2 = fullName.Substring(0, 1);
            newFullName = str1 + "*";
        }
        else if (fullName.Length >= 3)
        {
            string str1 = fullName.Substring(0, 1);
            string str2 = fullName.Substring(1, 1);
            string str3 = fullName.Substring(2, fullName.Length - 2);
            newFullName = str1 + "*" + str3;
        }
        return newFullName;
    }


    private void initCompanyBasicInformation(string queryCondition, int limitLine, int afterBasicId)
    {
        if (afterBasicId == 0)
        {
            basicInformations = dataAccess.GetBasicInformationsByCompanyName(queryCondition, limitLine);
        }
        else {
            basicInformations = dataAccess.GetBasicInformationsByCompanyNameAndAfterBasicId(queryCondition, limitLine, afterBasicId);
        }

        if (basicInformations != null && basicInformations.Count > 0)
        {
            lastBasicId = basicInformations[basicInformations.Count - 1].BasicId;
            linkbtnUpZiZhi.Visible = true;
            linkbtnNextZiZhi.Visible = true;
            linkbtnChaZiZhi.Visible = true;
            dlistChaZiZhi.Visible = true;
            lblWuZiZhi.Visible = false;
            dlistChaZiZhi.DataSource = basicInformations;
            dlistChaZiZhi.DataBind();
            if (basicInformations.Count == limitLine)
            {
                linkbtnNextZiZhi.Enabled = true;
            }
            else {
                linkbtnNextZiZhi.Enabled = false;
            }
        }
        else
        {
            lblWuZiZhi.Visible = true;
        }
    }

    private void UpZhengShu(string queryCondition, int limitLine, int beforeBasicId) {
        List<int> basicIds = new List<int>();
        if (beforeBasicId == 0)
        {
            linkbtnUpZhengShu.Enabled = false;
        }
        else
        {
            basicIds = dataAccess.GetBasicIdsByCertificateTypeAndBeforeBasicId(queryCondition, limitLine, beforeBasicId);
        }

        if (basicIds != null && basicIds.Count > 0)
        {
            frontBasicId = basicIds[0];
            lastBasicId = basicIds[basicIds.Count - 1];
            basicInformations = dataAccess.GetPersonBasicInformationByBasicIds(basicIds);

            if (basicInformations != null && basicInformations.Count > 0)
            {
                List<BasicInformation> basicInformationDetails = dataAccess.GetBasicInformationByBasicIds(basicIds);
                foreach (BasicInformation basicInformation in basicInformations)
                {
                    string registeredMajor = "";
                    foreach (BasicInformation basicInformationDetail in basicInformationDetails)
                    {

                        if (basicInformation.BasicId.Equals(basicInformationDetail.BasicId))
                        {
                            if (String.IsNullOrEmpty(basicInformationDetail.RegisteredMajor))
                            {
                                continue;
                            }
                            registeredMajor = registeredMajor + basicInformationDetail.RegisteredMajor + "\\";

                        }
                    }
                    if (registeredMajor.Length > 0)
                    {
                        registeredMajor = registeredMajor.Substring(0, registeredMajor.Length - 1);
                    }
                    basicInformation.RegisteredMajor = registeredMajor;
                }

                linkbtnUpZhengShu.Visible = true;
                linkbtnNextZhengShu.Visible = true;
                linkbtnChaZhengShu.Visible = true;
                dlistChaZhengShu.Visible = true;
                lblWuZhengShu.Visible = false;
                dlistChaZhengShu.DataSource = basicInformations;
                dlistChaZhengShu.DataBind();
                if (basicInformations.Count == limitLine)
                {
                    linkbtnNextZhengShu.Enabled = true;
                }
                else
                {
                    linkbtnNextZhengShu.Enabled = false;
                }
                
            }
            else
            {
                lblWuZhengShu.Visible = true;
            }
        }
        else
        {
            lblWuZhengShu.Visible = true;
        }
    }


    private void upZiZhi(string queryCondition, int limitLine, int beforeBasicId)
    {
        if (beforeBasicId == 0)
        {
            linkbtnUpZiZhi.Enabled = false;
        }
        else
        {
            basicInformations = dataAccess.GetBasicInformationsByCompanyNameAndBeforeBasicId(queryCondition, limitLine, beforeBasicId);
        }

        if (basicInformations != null && basicInformations.Count > 0)
        {
            lastBasicId = basicInformations[basicInformations.Count - 1].BasicId;
            linkbtnUpZiZhi.Visible = true;
            linkbtnNextZiZhi.Visible = true;
            linkbtnChaZiZhi.Visible = true;
            dlistChaZiZhi.Visible = true;
            lblWuZiZhi.Visible = false;
            dlistChaZiZhi.DataSource = basicInformations;
            dlistChaZiZhi.DataBind();
            if (basicInformations.Count == limitLine)
            {
                linkbtnNextZiZhi.Enabled = true;
            }
            else
            {
                linkbtnNextZiZhi.Enabled = false;
            }
        }
        else
        {
            lblWuZiZhi.Visible = true;
        }
    }


    protected void linkbtnUpZhengShu_Click(object sender, EventArgs e)
    {
        UpZhengShu(queryValue, 20, frontBasicId);
    }

    protected void linkbtnNextZhengShu_Click(object sender, EventArgs e)
    {
        linkbtnUpZhengShu.Enabled = true;
        int limitLine = 20;
        initPersonalBasicInformation(queryValue, limitLine, lastBasicId);
    }

    protected void linkbtnChaZhengShu_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryCertificate");
    }

    protected void linkbtnUpZiZhi_Click(object sender, EventArgs e)
    {
        upZiZhi(queryValue, 20, frontBasicId);
    }

    protected void linkbtnNextZiZhi_Click(object sender, EventArgs e)
    {
        linkbtnUpZiZhi.Enabled = true;
        int limitLine = 20;
        initCompanyBasicInformation(queryValue, limitLine, lastBasicId);
    }

    protected void linkbtnChaZiZhi_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryCompany");
    }
}