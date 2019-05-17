<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="true" CodeFile="QueryMore.aspx.cs" Inherits="QueryMore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <div style="margin-left: 20px; margin-right: 20px; margin-top: 20px; font-size: small;">
        以下是您查询 <span style="color:red"><%# queryValue%></span> 的信息，共有<span style="color:red"><%# total%></span>条相关信息
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="font-size: smaller;">
        <div>
            <asp:DataList ID="dlistChaZhengShu" runat="server" Width="100%" style="color: gray;">
                <ItemTemplate>
                    <table width="100%" border="0">
                        <tr>
                            <td width="15%"><%# Eval("fullName") %></td>
                            <td width="5%"><%# Eval("sex") %></td>
                            <td width="15%"><%# Eval("province") %></td>
                            <td><%# Eval("registeredMajor") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            
            <asp:Label ID="lblWuZhengShu" runat="server" Text="暂无有关的人员信息"></asp:Label>
            <p align="center">
                <asp:LinkButton ID="linkbtnUpZhengShu" runat="server" OnClick="linkbtnUpZhengShu_Click">上一页</asp:LinkButton>                  
                <asp:LinkButton ID="linkbtnNextZhengShu" runat="server" OnClick="linkbtnNextZhengShu_Click" >下一页</asp:LinkButton>                  
                <asp:LinkButton ID="linkbtnChaZhengShu" runat="server" OnClick="linkbtnChaZhengShu_Click" >精确查找</asp:LinkButton></p>
        </div>
        <div>
            <asp:DataList ID="dlistChaZiZhi" runat="server" Width="100%" style="color: gray;">
                <ItemTemplate>
                    <table width="100%" border="0">
                        <tr>
                            <td width="75%"><%# Eval("companyName") %></td>
                            <td width="25%">综合甲级</td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <asp:Label ID="lblWuZiZhi" runat="server" Text="暂无有关的公司资质信息"></asp:Label>
            <p align="center">
                <asp:LinkButton ID="linkbtnUpZiZhi" runat="server" OnClick="linkbtnUpZiZhi_Click">上一页</asp:LinkButton>                  
                    <asp:LinkButton ID="linkbtnNextZiZhi" runat="server" OnClick="linkbtnNextZiZhi_Click" >下一页</asp:LinkButton>                  
                <asp:LinkButton ID="linkbtnChaZiZhi" runat="server" OnClick="linkbtnChaZiZhi_Click" >精确查找</asp:LinkButton>

            </p>
            
        </div>
    </div>
</asp:Content>

