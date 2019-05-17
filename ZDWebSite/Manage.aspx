<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="    margin-left: 20px; margin-right: 20px; margin-top: 20px;font-size: small;">
<br />
<br />
  <table style="background-color:#F5F5F5;" width="100%" border="0">
    <tr>
      <td><asp:Image ID="imgHeadImage" runat="server" width="28" height="28" /></td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>Hi 
          <span>
            <asp:Label ID="lblNickName" runat="server" Text=""></asp:Label>
          </span> 
          <span id="dengji">
            <asp:Label ID="lblUserLevel" runat="server" Text=""></asp:Label>
          </span>
      </td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td>ID: <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
        
      <td>&nbsp;</td>
    </tr>
     <tr>
      <td><img src="geren.png" alt="" width="28" height="28" /><img src="duoren.png" alt="" width="28" height="28" /></td>
      <td>&nbsp;</td>
    </tr>
  </table>
  <p>&nbsp;</p>
        <div>
            <table width="100%" border="0">
                <tr>
                  <td><div align="center">
                    <p><asp:ImageButton ID="imgBtnCheckIn" runat="server" ImageUrl="~/Images/qianbao2.png" width="28" height="28" OnClick="imgBtnCheckIn_Click" /></p>
                    <p>财富</p>
                  </div></td>
                  <td><div align="center">
                    <p><img src="images/next.png" width="28" height="28" /></p>
                    <p>提现</p>
                  </div></td>
                  <td><div align="center">
                    <p><img src="images/zbi.png" width="28" height="28" /></p>
                    <p>Z币</p>
                  </div></td>
                </tr>
              </table>
        </div>
  
  <p>&nbsp;</p>
        <div>
            <table width="100%" border="0">
    <tr>
      <td width="51%"><p><img src="images/bijiben.png" width="28" height="28" />个人资料</p>
      <p>&nbsp;</p></td>
      <td width="49%"><img src="images/jinshi.png" width="18" height="18" />资料待完善<p>&nbsp;</p>
      </td>
    </tr>
    <tr>
      <td><p><img src="images/wo.png" width="28" height="28" />我的职业</p>
      <p>&nbsp;</p></td>
      <td>&nbsp;<p>&nbsp;</p></td>
    </tr>
    <tr>
      <td><p><img src="images/xinxi.png" width="28" height="28" />业务管理</p>
      <p>&nbsp;</p></td>
      <td><img src="images/jinshi.png" alt="" width="18" height="18" />业务进展<p>&nbsp;</p></td>
    </tr>
    <tr>
      <td><p><img src="images/fukuan.png" width="28" height="28" />邀请返现</p>
      <p>&nbsp;</p></td>
      <td><img src="images/jinshi.png" alt="" width="18" height="18" />有新用户加入<p>&nbsp;</p></td>
    </tr>
    <tr>
      <td><p><img src="images/a.png" width="28" height="28" />关于我们</p>
      <p>&nbsp;</p></td>
      <td>&nbsp;<p>&nbsp;</p></td>
    </tr>
    <tr>
      <td><p><img src="images/shezhi.png" width="28" height="28" />设置</p>
      <p>&nbsp;</p></td>
      <td>&nbsp;<p>&nbsp;</p></td>
    </tr>
  </table>
        </div>
  
  <p>&nbsp;</p>
  <p><br />
  </p>
</div>

</asp:Content>

