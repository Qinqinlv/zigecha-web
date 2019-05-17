using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QueryResult : System.Web.UI.Page
{
    public string queryValue;
    DataAccess dataAccess = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        queryValue = Request.QueryString["queryValue"];
        queryValue = Des.DesDecrypt(queryValue, Des.desKey);
        txtQueryCondition.Text = queryValue;
        Page.DataBind();
        //contral visibility
        dlistChaZhengShu.Visible = false;
        lblWuZhengShu.Visible = false;
        dlistChaZiZhi.Visible = false;
        lblWuZiZhi.Visible = false;


        //init data
        initBasicInformation(queryValue);
    }

    private void initBasicInformation(string queryCondition) {
        initPersonalBasicInformation(queryCondition,2);

        initCompanyBasicInformation(queryCondition, 2);
    }

    private void initPersonalBasicInformation(string queryCondition,int limitLine) {

        List<int> basicIds = dataAccess.GetBasicIdsByCertificateType(queryCondition, limitLine);

        if (basicIds != null && basicIds.Count > 0)
        {
            List<BasicInformation> basicInformations = dataAccess.GetPersonBasicInformationByBasicIds(basicIds);

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
                linkbtnChaZhengShu.Text = dataAccess.GetCountByCertificateType(queryCondition).ToString();

                dlistChaZhengShu.Visible = true;
                dlistChaZhengShu.DataSource = basicInformations;
                dlistChaZhengShu.DataBind();

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


    private string getNewFullName(string fullName) {
        string newFullName = "";

        if (string.IsNullOrEmpty(fullName)) {
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


    private void initCompanyBasicInformation(string queryCondition, int limitLine)
    {

        List<BasicInformation> basicInformations = dataAccess.GetBasicInformationsByCompanyName(queryCondition, limitLine);

        if (basicInformations != null && basicInformations.Count > 0)
        {
            linkbtnChaZiZhi.Text = dataAccess.GetCountByCompanyName(queryCondition).ToString();

            dlistChaZiZhi.Visible = true;
            dlistChaZiZhi.DataSource = basicInformations;
            dlistChaZiZhi.DataBind();

        }
        else
        {
            lblWuZiZhi.Visible = true;
        }
    }

    protected void linkbtnChaZhengShu_Click(object sender, EventArgs e)
    {
        
        queryValue = Des.DesEncrypt(queryValue, Des.desKey);
        queryValue = HttpUtility.UrlEncode(queryValue, System.Text.Encoding.UTF8);

        string total = linkbtnChaZhengShu.Text;
        total = Des.DesEncrypt(total, Des.desKey);
        total = HttpUtility.UrlEncode(total, System.Text.Encoding.UTF8);

        Response.Redirect("QueryMore?queryValue=" + queryValue+ "&total="+ total+ "&queryType=zhengshu");
    }

    protected void linkbtnChaZiZhi_Click(object sender, EventArgs e)
    {
        queryValue = Des.DesEncrypt(queryValue, Des.desKey);
        queryValue = HttpUtility.UrlEncode(queryValue, System.Text.Encoding.UTF8);

        string total = linkbtnChaZiZhi.Text;
        total = Des.DesEncrypt(total, Des.desKey);
        total = HttpUtility.UrlEncode(total, System.Text.Encoding.UTF8);

        Response.Redirect("QueryMore?queryValue=" + queryValue + "&total=" + total + "&queryType=zizhi");
    }
}