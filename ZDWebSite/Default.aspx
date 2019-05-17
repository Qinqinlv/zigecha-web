<%@ Page Title="证典-首页" Language="C#" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div style="background-image:url(Images/beijing1.png); background-size: 300px 200px; 
    margin-left: 20px;
    margin-right: 20px;
    margin-top: 5px;
    font-size: small;">
<br />
<table width="100%" border="0">
    <tr>
      <th width="50%" height="100" scope="col">
          <div align="left">
              <asp:ImageButton ID="imgbtnWoDe" runat="server" ImageUrl="~/Images/wode.png" Width="28" Height="28" OnClick="imgbtnWoDe_Click" />
        </div></th>
      <th width="50%" scope="col"><div align="right">
        <p><img src="images/vipbeijing.jpg" width="60" height="28" /></p>
        <p><a runat="server" href="~/"><img src="images/liaojiexiangqing.jpg" width="48" height="18" /></a></p>
</div></th>
    </tr>
  </table>
<table width="100%" border="0">
  <tr>
    <td width="100%"><div align="center">
        <img alt="" src="Images/zigecha.png"  width="123" height="55" /><br />
        zigecha.com</div></td>
  </tr>
</table>
</div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="margin-left: 20px;
    margin-right: 20px;
    margin-top: 20px;
    font-size: small;">
<br />
        <table width="100%" border="0">
  <tr>
    <td width="100%">
        <div align="center" style="vertical-align: middle;">
                <asp:TextBox ID="txtSouSuo" runat="server" placeholder="输入资格证\姓名\公司"
                style="padding-left: 28px;background-image: url(Images/chaxun-28.jpg);background-repeat: no-repeat;background-position: 1% center;}" Width="180px" Height="28"></asp:TextBox>
                <asp:ImageButton style="vertical-align: middle;" ID="imgbtn" runat="server" ImageUrl="~/Images/shouye_btn.png" Width="30" Height="30" OnClick="imgbtn_Click" />
            </td>
        </div>
    </tr>
</table>

<br />
<table width="100%" border="0">
  <tr>
    <td width="100%"><div id="resou" align="left">
        热搜 : <asp:Label ID="lblRouSou" runat="server" Text="注册消防师 注册会计师"></asp:Label></div></td>
    </tr>
</table>
<br />
<table width="100%" border="0">
  <tr>
    <td><p align="center"><img src="images/dui.png" width="30" height="30" /></p>
      <p align="center">
          <asp:LinkButton ID="linkBtnChaZhengShu" runat="server" OnClick="linkBtnChaZhengShu_Click">查证书</asp:LinkButton>
        </p>

    </td>
    <td><p align="center"><img src="images/renzheng.png" width="30" height="30" /></p>
      <p align="center">
          <asp:LinkButton ID="linkBtnChaZiZi" runat="server" OnClick="linkBtnChaZiZi_Click" >查资质</asp:LinkButton>
      </p></td>
    <td><p align="center"><img src="images/chaxunrencai.png" width="30" height="30" /></p>
      <p align="center">找人才</p></td>
    <td><p align="center"><img src="images/jisuanqi.png" width="30" height="30" /></p>
      <p align="center">证百科</p></td>
  </tr>
  <tr>
    <td><p align="center"><img src="images/shenglue.png" width="30" height="30" /></p>
      <p align="center">更多</p>
      <p>&nbsp;</p></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>
<br />
<br />
<table width="100%" border="0">
  <tr>
    <td width="25%">&nbsp;</td>
    <td width="25%">&nbsp;</td>
    <td width="25%">&nbsp;</td>
    <td width="25%"><div align="center">
      <p><img src="images/kefu.png" width="30" height="30" /></p>
      <p>客服</p>
    </div></td>
  </tr>
</table>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
