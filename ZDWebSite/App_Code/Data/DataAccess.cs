using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    public DataAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool CheckUserExist(string name, string password)
    {
        bool exist = false;
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select * from user where user_name=@name and password=@password and active='Y'; ";
        string updateCmd = "update user set access_count = @access_count,last_access_date = @last_access_date where user_name=@name and password=@password;";
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@name",
            Value = name
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@password",
            Value = password
        });
        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable userTable = dataSet.Tables[0];
        if (userTable != null && userTable.Rows.Count != 0)
        {

            DataRow dataRow = userTable.Rows[0];
            int accessCount = dataRow["access_count"] is DBNull ? 0 : Int32.Parse(dataRow["access_count"].ToString());
            accessCount++;
            DateTime lastAccessDate = DateTime.Now;
            mySqlParameters.Add(new MySqlParameter()
            {
                ParameterName = "@access_count",
                Value = accessCount
            });
            mySqlParameters.Add(new MySqlParameter()
            {
                ParameterName = "@last_access_date",
                Value = lastAccessDate
            });
            int count = MySqlAccessHelper.ExecuteNonQuery(connectionString, CommandType.Text, updateCmd, mySqlParameters.ToArray());
            if (count != 0)
            {
                exist = true;
            }
        }
        return exist;
    }

    public bool CheckUserExist(string openId)
    {
        bool exist = false;
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select uo.user_id from user_oauth2 uo inner join user u on uo.user_id = u.user_id where uo.open_id=@openId and u.active='Y'; ";
        string updateCmd = "update user set access_count = @access_count,last_access_date = @last_access_date where user_id=@user_id;";
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@openId",
            Value = openId
        });

        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable userTable = dataSet.Tables[0];
        if (userTable != null && userTable.Rows.Count != 0)
        {

            DataRow dataRow = userTable.Rows[0];
            int accessCount = dataRow["access_count"] is DBNull ? 0 : Int32.Parse(dataRow["access_count"].ToString());
            accessCount++;
            DateTime lastAccessDate = DateTime.Now;
            mySqlParameters.Add(new MySqlParameter()
            {
                ParameterName = "@access_count",
                Value = accessCount
            });
            mySqlParameters.Add(new MySqlParameter()
            {
                ParameterName = "@last_access_date",
                Value = lastAccessDate
            });
            int count = MySqlAccessHelper.ExecuteNonQuery(connectionString, CommandType.Text, updateCmd, mySqlParameters.ToArray());
            if (count != 0)
            {
                exist = true;
            }
        }
        return exist;
    }

    public User setUser(User user)
    {
        DateTime today = DateTime.Now;
        int count = 0;
        string connectionString = MySqlAccessHelper.getConnectingString();
        string insertCmd = "insert into user (user_name,password,user_level,register_date,access_count,last_access_date,active,is_oauth2) values " +
            "(@user_name,@password,@user_level,@register_date,@access_count,@last_access_date,@active,@is_oauth2);";
        //@serial_no, @full_name, @province,@company_name, @certificate_no,@expiry_date,@personnel_level
        if (CheckUserExist(user.UserName, user.Password))
        {
            return user;
        }

        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@user_name",
            Value = user.UserName
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@password",
            Value = user.Password
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@user_level",
            Value = user.UserLevel
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@register_date",
            Value = user.RegisterDate
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@access_count",
            Value = user.AccessCount
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@last_access_date",
            Value = user.LastAccessDate
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@active",
            Value = user.Active
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@is_oauth2",
            Value = user.IsOauth2
        });

        count = MySqlAccessHelper.ExecuteNonQuery(connectionString, CommandType.Text, insertCmd, mySqlParameters.ToArray());

        user = GetUser(user.UserName);

        return user;

    }

    public int setUserOauth2(UserOauth2 userOauth2)
    {
        DateTime today = DateTime.Now;
        int count = 0;
        string connectionString = MySqlAccessHelper.getConnectingString();
        string insertCmd = "insert into user_oauth2 (user_id,head_img_url,nick_name,sex,country,province,city,open_id,oauth2_from,update_date) values " +
            "(@user_id,@head_img_url,@nick_name,@sex,@country,@province,@city,@open_id,@oauth2_from,@update_date);";
        //@serial_no, @full_name, @province,@company_name, @certificate_no,@expiry_date,@personnel_level

        if (CheckUserExist(userOauth2.OpenId))
        {
            return count;
        }

        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@user_id",
            Value = userOauth2.UserId
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@head_img_url",
            Value = userOauth2.HeadImgUrl
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@nick_name",
            Value = userOauth2.NickName
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@sex",
            Value = userOauth2.Sex
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@country",
            Value = userOauth2.Country
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@province",
            Value = userOauth2.Province
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@city",
            Value = userOauth2.City
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@open_id",
            Value = userOauth2.OpenId
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@oauth2_from",
            Value = userOauth2.Oauth2From
        });
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@update_date",
            Value = userOauth2.UpdateDate
        });

        count = MySqlAccessHelper.ExecuteNonQuery(connectionString, CommandType.Text, insertCmd, mySqlParameters.ToArray());

        return count;

    }


    public User GetUser(string userName)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select * from user where user_name=@userName and active='Y'; ";
        User user = new User();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@userName",
            Value = userName
        });
        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable userTable = dataSet.Tables[0];
        if (userTable != null && userTable.Rows.Count != 0)
        {

            DataRow dataRow = userTable.Rows[0];
            int userId = dataRow["user_id"] is DBNull ? 0 : Int32.Parse(dataRow["user_id"].ToString());
            string password = dataRow["password"] is DBNull ? "" : dataRow["password"].ToString();
            string userLevel = dataRow["user_level"] is DBNull ? "" : dataRow["user_level"].ToString();
            string active = dataRow["active"] is DBNull ? "" : dataRow["active"].ToString();
            string isOauth2 = dataRow["is_oauth2"] is DBNull ? "" : dataRow["is_oauth2"].ToString();
            int accessCount = dataRow["access_count"] is DBNull ? 0 : Int32.Parse(dataRow["access_count"].ToString());

            string lastAccessDateString = dataRow["last_access_date"] is DBNull ? "" : dataRow["last_access_date"].ToString();
            DateTime lastAccessDate;
            DateTime.TryParse(lastAccessDateString, out lastAccessDate);

            string registerDateString = dataRow["register_date"] is DBNull ? "" : dataRow["register_date"].ToString();
            DateTime registerDate;
            DateTime.TryParse(registerDateString, out registerDate);
            user = new User()
            {
                UserName = userName,
                AccessCount = accessCount,
                Active = active,
                UserId = userId,
                Password = password,
                UserLevel = userLevel,
                LastAccessDate = lastAccessDate,
                RegisterDate = registerDate,
                IsOauth2 = isOauth2
            };
        }
        return user;
    }

    public User GetUserByOpenId(string openId)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select u.* from user u inner join user_oauth2 uo on u.user_id = uo.user_id where uo.open_id=@open_id and u.active='Y'; ";
        User user = new User();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@open_id",
            Value = openId
        });
        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable userTable = dataSet.Tables[0];
        if (userTable != null && userTable.Rows.Count != 0)
        {

            DataRow dataRow = userTable.Rows[0];
            int userId = dataRow["user_id"] is DBNull ? 0 : Int32.Parse(dataRow["user_id"].ToString());
            string password = dataRow["password"] is DBNull ? "" : dataRow["password"].ToString();
            string userLevel = dataRow["user_level"] is DBNull ? "" : dataRow["user_level"].ToString();
            string active = dataRow["active"] is DBNull ? "" : dataRow["active"].ToString();
            string userName = dataRow["user_name"] is DBNull ? "" : dataRow["user_name"].ToString();
            string isOauth2 = dataRow["is_oauth2"] is DBNull ? "" : dataRow["is_oauth2"].ToString();
            int accessCount = dataRow["access_count"] is DBNull ? 0 : Int32.Parse(dataRow["access_count"].ToString());

            string lastAccessDateString = dataRow["last_access_date"] is DBNull ? "" : dataRow["last_access_date"].ToString();
            DateTime lastAccessDate;
            DateTime.TryParse(lastAccessDateString, out lastAccessDate);

            string registerDateString = dataRow["register_date"] is DBNull ? "" : dataRow["register_date"].ToString();
            DateTime registerDate;
            DateTime.TryParse(registerDateString, out registerDate);
            user = new User()
            {
                UserName = userName,
                AccessCount = accessCount,
                Active = active,
                UserId = userId,
                Password = password,
                UserLevel = userLevel,
                LastAccessDate = lastAccessDate,
                RegisterDate = registerDate,
                IsOauth2 = isOauth2
            };
        }
        return user;
    }

    public UserOauth2 GetUserOauth2ByOpenId(string openId)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select * from user_oauth2 where open_id=@open_id; ";
        UserOauth2 user = new UserOauth2();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@open_id",
            Value = openId
        });
        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable userTable = dataSet.Tables[0];
        if (userTable != null && userTable.Rows.Count != 0)
        {

            DataRow dataRow = userTable.Rows[0];
            int userId = dataRow["user_id"] is DBNull ? 0 : Int32.Parse(dataRow["user_id"].ToString());
            string headImgUrl = dataRow["head_img_url"] is DBNull ? "" : dataRow["head_img_url"].ToString();
            string nickName = dataRow["nick_name"] is DBNull ? "" : dataRow["nick_name"].ToString();
            string country = dataRow["country"] is DBNull ? "" : dataRow["country"].ToString();
            string province = dataRow["province"] is DBNull ? "" : dataRow["province"].ToString();
            string city = dataRow["city"] is DBNull ? "" : dataRow["city"].ToString();
            string oauth2From = dataRow["oauth2_from"] is DBNull ? "" : dataRow["oauth2_from"].ToString();
            string sex = dataRow["sex"] is DBNull ? "" : dataRow["sex"].ToString();

            string updateDateString = dataRow["update_date"] is DBNull ? "" : dataRow["update_date"].ToString();
            DateTime updateDate;
            DateTime.TryParse(updateDateString, out updateDate);

            
            user = new UserOauth2()
            {
                UserId = userId,
                HeadImgUrl = headImgUrl,
                NickName = nickName,
                Country = country,
                Province = province,
                City = city,
                Oauth2From = oauth2From,
                Sex = sex,
                UpdateDate = updateDate,
                OpenId = openId
            };
        }
        return user;
    }

    public List<int> GetBasicIdsByCertificateType(string certificateType,int limit)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select distinct basic_id from personnel_certificate where certificate_type like @certificateType limit @limit; ";
        List<int> basicIds = new List<int>();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@certificateType",
            Value = "%"+certificateType+"%"
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@limit",
            Value = limit
        });

        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable basicIdTable = dataSet.Tables[0];
        if (basicIdTable != null && basicIdTable.Rows.Count != 0)
        {
            foreach (DataRow dataRow in basicIdTable.Rows) {
                if (dataRow["basic_id"] is DBNull) {
                    continue;
                }
                int basicId = Int32.Parse(dataRow["basic_id"].ToString());
                basicIds.Add(basicId);
            }
        }
        return basicIds;
    }

    public List<int> GetBasicIdsByCertificateTypeAndAfterBasicId(string certificateType , int limit, int afterBasicId)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select distinct basic_id from personnel_certificate where certificate_type like @certificateType and basic_id>@afterBasicId limit @limit; ";
        List<int> basicIds = new List<int>();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@certificateType",
            Value = "%" + certificateType + "%"
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@afterBasicId",
            Value = afterBasicId
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@limit",
            Value = limit
        });

        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable basicIdTable = dataSet.Tables[0];
        if (basicIdTable != null && basicIdTable.Rows.Count != 0)
        {
            foreach (DataRow dataRow in basicIdTable.Rows)
            {
                if (dataRow["basic_id"] is DBNull)
                {
                    continue;
                }
                int basicId = Int32.Parse(dataRow["basic_id"].ToString());
                basicIds.Add(basicId);
            }
        }
        return basicIds;
    }

    public List<int> GetBasicIdsByCertificateTypeAndBeforeBasicId(string certificateType, int limit, int beforeBasicId)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select distinct basic_id from personnel_certificate where certificate_type like @certificateType and basic_id<@beforeBasicId limit @limit; ";
        List<int> basicIds = new List<int>();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@certificateType",
            Value = "%" + certificateType + "%"
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@beforeBasicId",
            Value = beforeBasicId
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@limit",
            Value = limit
        });

        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable basicIdTable = dataSet.Tables[0];
        if (basicIdTable != null && basicIdTable.Rows.Count != 0)
        {
            foreach (DataRow dataRow in basicIdTable.Rows)
            {
                if (dataRow["basic_id"] is DBNull)
                {
                    continue;
                }
                int basicId = Int32.Parse(dataRow["basic_id"].ToString());
                basicIds.Add(basicId);
            }
        }
        return basicIds;
    }


    public int GetCountByCertificateType(string certificateType)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select count(distinct basic_id) from personnel_certificate where certificate_type like @certificateType ; ";
        List<int> basicIds = new List<int>();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@certificateType",
            Value = "%" + certificateType + "%"
        });

        int count = Int32.Parse(MySqlAccessHelper.ExecuteScalar(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray()).ToString());
        
        return count;
    }


    public List<BasicInformation> GetBasicInformationsByCompanyName(string companyName, int limit)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "SELECT basic_id,province,company_name FROM personnel_basic where company_name like @companyName limit @limit; ";
        List<BasicInformation> basicInformations = new List<BasicInformation>();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@companyName",
            Value = "%" + companyName + "%"
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@limit",
            Value = limit
        });

        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable basicIdTable = dataSet.Tables[0];
        if (basicIdTable != null && basicIdTable.Rows.Count != 0)
        {
            foreach (DataRow dataRow in basicIdTable.Rows)
            {
                if (dataRow["basic_id"] is DBNull)
                {
                    continue;
                }
                int basicId = Int32.Parse(dataRow["basic_id"].ToString());
                string province = dataRow["province"] is DBNull ? "" : dataRow["province"].ToString();
                string fullCompanyName = dataRow["company_name"] is DBNull ? "" : dataRow["company_name"].ToString();
                BasicInformation basicInformation = new BasicInformation()
                {
                    BasicId = basicId,
                    Province = province,
                    CompanyName = fullCompanyName
                };

                basicInformations.Add(basicInformation);
            }
        }
        return basicInformations;
    }

    public List<BasicInformation> GetBasicInformationsByCompanyNameAndAfterBasicId(string companyName, int limit, int afterBasicId)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "SELECT basic_id,province,company_name FROM personnel_basic where company_name like @companyName and basic_id>@afterBasicId limit @limit; ";
        List<BasicInformation> basicInformations = new List<BasicInformation>();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@companyName",
            Value = "%" + companyName + "%"
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@afterBasicId",
            Value = afterBasicId
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@limit",
            Value = limit
        });

        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable basicIdTable = dataSet.Tables[0];
        if (basicIdTable != null && basicIdTable.Rows.Count != 0)
        {
            foreach (DataRow dataRow in basicIdTable.Rows)
            {
                if (dataRow["basic_id"] is DBNull)
                {
                    continue;
                }
                int basicId = Int32.Parse(dataRow["basic_id"].ToString());
                string province = dataRow["province"] is DBNull ? "" : dataRow["province"].ToString();
                string fullCompanyName = dataRow["company_name"] is DBNull ? "" : dataRow["company_name"].ToString();

                BasicInformation basicInformation = new BasicInformation()
                {
                    BasicId = basicId,
                    Province = province,
                    CompanyName = fullCompanyName
                };

                basicInformations.Add(basicInformation);
            }
        }
        return basicInformations;
    }


    public List<BasicInformation> GetBasicInformationsByCompanyNameAndBeforeBasicId(string companyName, int limit, int beforeBasicId)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "SELECT basic_id,province,company_name FROM personnel_basic where company_name like @companyName and basic_id>@beforeBasicId limit @limit; ";
        List<BasicInformation> basicInformations = new List<BasicInformation>();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@companyName",
            Value = "%" + companyName + "%"
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@beforeBasicId",
            Value = beforeBasicId
        });

        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@limit",
            Value = limit
        });

        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray());
        DataTable basicIdTable = dataSet.Tables[0];
        if (basicIdTable != null && basicIdTable.Rows.Count != 0)
        {
            foreach (DataRow dataRow in basicIdTable.Rows)
            {
                if (dataRow["basic_id"] is DBNull)
                {
                    continue;
                }
                int basicId = Int32.Parse(dataRow["basic_id"].ToString());
                string province = dataRow["province"] is DBNull ? "" : dataRow["province"].ToString();
                string fullCompanyName = dataRow["company_name"] is DBNull ? "" : dataRow["company_name"].ToString();

                BasicInformation basicInformation = new BasicInformation()
                {
                    BasicId = basicId,
                    Province = province,
                    CompanyName = fullCompanyName
                };

                basicInformations.Add(basicInformation);
            }
        }
        return basicInformations;
    }


    public int GetCountByCompanyName(string companyName)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string selectCmd = "select count(distinct basic_id) from personnel_basic where company_name like @companyName ; ";
        List<int> basicIds = new List<int>();
        List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();
        mySqlParameters.Add(new MySqlParameter()
        {
            ParameterName = "@companyName",
            Value = "%" + companyName + "%"
        });

        int count = Int32.Parse(MySqlAccessHelper.ExecuteScalar(connectionString, CommandType.Text, selectCmd, mySqlParameters.ToArray()).ToString());

        return count;
    }


    public List<BasicInformation> GetPersonBasicInformationByBasicIds(List<int> basicIds)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string basicIdsStr = "(" + StringHelper.ConvertIntListToSqlString(basicIds) + ")";
        string selectCmd = "select distinct pb.basic_id,pb.full_name,pb.province,ps.sex " +
            "from personnel_basic pb inner join personnel_certificate pc on pb.basic_id = pc.basic_id " +
            "inner join personnel_study ps on pb.basic_id = ps.basic_id where pb.basic_id in" + basicIdsStr + ";";
        List<BasicInformation> basicInformations = new List<BasicInformation>();


        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, null);
        DataTable basicInfoTable = dataSet.Tables[0];
        if (basicInfoTable != null && basicInfoTable.Rows.Count != 0)
        {
            foreach (DataRow dataRow in basicInfoTable.Rows)
            {
                if (dataRow["basic_id"] is DBNull)
                {
                    continue;
                }
                int basicId = Int32.Parse(dataRow["basic_id"].ToString());
                string fullName = dataRow["full_name"] is DBNull ? "" : dataRow["full_name"].ToString();
                string province = dataRow["province"] is DBNull ? "" : dataRow["province"].ToString();

                string sex = dataRow["sex"] is DBNull ? "" : dataRow["sex"].ToString();
                BasicInformation basicInformation = new BasicInformation()
                {
                    BasicId = basicId,
                    FullName = fullName,
                    Province = province,
                    Sex = sex
                };
                basicInformations.Add(basicInformation);
            };

        }
        return basicInformations;
    }

    public List<BasicInformation> GetBasicInformationByBasicIds(List<int> basicIds)
    {
        string connectionString = MySqlAccessHelper.getConnectingString();
        string basicIdsStr = "("+ StringHelper.ConvertIntListToSqlString(basicIds)+")"; 
        string selectCmd = "select pb.basic_id,pb.full_name,pb.province,pb.company_name,pc.certificate_type,pc.registered_major," +
            "pc.certificate_level,ps.sex "+
            "from personnel_basic pb inner join personnel_certificate pc on pb.basic_id = pc.basic_id "+
            "inner join personnel_study ps on pb.basic_id = ps.basic_id where pb.basic_id in"+basicIdsStr+";";
        List<BasicInformation> basicInformations = new List<BasicInformation>();


        DataSet dataSet = MySqlAccessHelper.GetDataSet(connectionString, CommandType.Text, selectCmd, null);
        DataTable basicInfoTable = dataSet.Tables[0];
        if (basicInfoTable != null && basicInfoTable.Rows.Count != 0)
        {
            foreach (DataRow dataRow in basicInfoTable.Rows)
            {
                if (dataRow["basic_id"] is DBNull)
                {
                    continue;
                }
                int basicId = Int32.Parse(dataRow["basic_id"].ToString());
                string fullName = dataRow["full_name"] is DBNull ? "" : dataRow["full_name"].ToString();
                string province = dataRow["province"] is DBNull ? "" : dataRow["province"].ToString();
                string companyName = dataRow["company_name"] is DBNull ? "" : dataRow["company_name"].ToString();
                string certificateType = dataRow["certificate_type"] is DBNull ? "" : dataRow["certificate_type"].ToString();
                string registeredMajor = dataRow["registered_major"] is DBNull ? "" : dataRow["registered_major"].ToString();
                string certificate_level = dataRow["certificate_level"] is DBNull ? "" : dataRow["certificate_level"].ToString();
                string sex = dataRow["sex"] is DBNull ? "" : dataRow["sex"].ToString();
                BasicInformation basicInformation = new BasicInformation()
                {
                    BasicId = basicId,
                    FullName = fullName,
                    Province = province,
                    CompanyName = companyName,
                    CertificateType = certificateType,
                    RegisteredMajor = registeredMajor,
                    CertificateLevel = certificate_level,
                    Sex = sex
                };
                basicInformations.Add(basicInformation);
            };

        }
        return basicInformations;
    }


}