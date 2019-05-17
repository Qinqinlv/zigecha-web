<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="true" CodeFile="CheckInAmount.aspx.cs" Inherits="CheckInAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="    margin-left: 20px; margin-right: 20px; margin-top: 20px;font-size: small;">
        <br/>
        <div>
            <asp:Label ID="Label1" runat="server" style="color:#00CD00;"><b>商品一：价格为<span style="color:#f00;font-size:small">1分</span>钱</b></asp:Label><br/><br/>
        </div>
	    <div align="center">
            <asp:Button ID="Button1" runat="server" Text="立即购买" style="border-radius: 15px;background-color:#00CD00; border:0px #FE6714 solid; cursor: pointer;  color:white;  font-size:16px;" OnClick="Button1_Click" Height="27px" Width="127px" />
	    </div>
        <br/><br/><br/>
        <div>
            <asp:Label ID="Label2" runat="server" style="color:#00CD00;"><b>商品二：价格为<span style="color:#f00;font-size:small">2分</span>钱</b></asp:Label><br/><br/>
	    </div>
        <div align="center">
            <asp:Button ID="Button2" runat="server" Text="立即购买" style="border-radius: 15px;background-color:#00CD00; border:0px #FE6714 solid; cursor: pointer;  color:white;  font-size:16px;" OnClick="Button2_Click" Height="27px" Width="127px" />
	    </div>
    </div>

</asp:Content>

