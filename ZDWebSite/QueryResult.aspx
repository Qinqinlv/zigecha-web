<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="true" CodeFile="QueryResult.aspx.cs" Inherits="QueryResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div style="margin-left: 20px; margin-right: 20px; margin-top: 20px; font-size: small;">
        <table width="100%" border="0">
            <tr>
                <td width="79%">
                    <asp:TextBox ID="txtQueryCondition" runat="server" Width="178px"></asp:TextBox>&nbsp;</td>
                <td width="9%">
                    <img src="images/weizhi.png" width="20" height="25" /></td>
                <td width="12%">成都</td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="margin-left: 20px; margin-right: 20px; margin-top: 20px; font-size: smaller;">
        <table width="100%" border="0">
            <tr>
                <td width="15%">热搜：</td>
                <td width="86%">消防工程师 注册会计师</td>
            </tr>
        </table>
        <br />
        <table width="100%" border="0">
            <tr>
                <td width="25%">
                    <img src="images/jisuanqi.png" width="28" height="28" />证百科</td>
                <td>有<asp:Label ID="lblZhengBaiKe" runat="server" Style="color: red;" Text="0"></asp:Label>条与<span style="color: red"><%# queryValue%></span>有关的证书百科</td>
            </tr>

        </table>
        <div style="font-size: xx-small;">
            <table width="100%" border="0">
                <tr>
                    <td width="25%">暂无此证书百科信息</td>
                    <td width="75%">&nbsp;</td>
                </tr>
            </table>
            <%--<asp:DataList ID="dlistZhengbaike" runat="server">
              <ItemTemplate>
          
              </ItemTemplate>
          </asp:DataList>--%>
        </div>

    <br />
    <table width="100%" border="0">
        <tr>
            <td width="25%">
                <img src="images/dui.png" width="28" height="28" alt="" />查证书</td>
            <td>有<asp:LinkButton ID="linkbtnChaZhengShu" runat="server" OnClick="linkbtnChaZhengShu_Click" Style="color: red;">0</asp:LinkButton>条与<span style="color: red"><%# queryValue%></span>有关的人员信息</td>
        </tr>
    </table>
    <div style="font-size: xx-small;">
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
    </div>
    <table width="100%" border="0">
        <tr>
            <td width="25%">
                <img src="images/renzheng.png" alt="" width="28" height="28" />查资质</td>
            <td>有<asp:LinkButton ID="linkbtnChaZiZhi" runat="server" Style="color: red;" OnClick="linkbtnChaZiZhi_Click">0</asp:LinkButton>条与<span style="color: red"><%# queryValue%></span>有关的资质</td>
        </tr>
    </table>
    <div style="font-size: xx-small;">
        <asp:DataList ID="dlistChaZiZhi" runat="server" Width="100%" style="color: gray;">
            <ItemTemplate>
                <table width="100%" border="0">
                    <tr>
                        <td width="75%"><%# Eval("companyName") %></td>
                        <td width="25%"></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <asp:Label ID="lblWuZiZhi" runat="server" Text="暂无有关的公司资质信息"></asp:Label>
    </div>
    <br />
    <table width="100%" border="0">
        <tr>
            <td width="25%">
                <img src="images/shuaxin2.png" width="28" height="28" />搜需求</td>
            <td>
                <p>有<asp:Label ID="lblSouXuQiu" runat="server" Style="color: red;" Text="0"></asp:Label>条与<span style="color: red"><%# queryValue%></span>有关的需求</p>
            </td>
        </tr>
    </table>
    <div style="font-size: xx-small;">
        <table width="100%" border="0">
            <tr>
                <td width="75%">
                    <p>大项目急寻总监</p>
                </td>
                <td width="25%">
                    <p>20W/年</p>
                </td>
            </tr>
        </table>
        <table width="100%" border="0">
            <tr>
                <td width="75%">
                    <p>甲级监理公司招聘监理工程师</p>
                </td>
                <td width="25%">
                    <p>9K/月</p>
                </td>
            </tr>
        </table>
    </div>
    <p></p>
    <table width="100%" border="0">
        <tr>
            <td width="25%">
                <img src="images/shenfen.png" alt="" width="28" height="28" />搜课程</td>
            <td>
                <p>有<asp:Label ID="lblSouKeCheng" runat="server" Style="color: red;" Text="0"></asp:Label>条与<span style="color: red"><%# queryValue%></span>有关的课程</p>
            </td>
        </tr>
    </table>
    <div style="font-size: xx-small;">
        <table width="100%" border="0">
            <tr>
                <td width="75%">
                    <p>基础知识1-2章</p>
                </td>
                <td width="25%">
                    <p>800元</p>
                </td>
            </tr>
        </table>
        <table width="100%" border="0">
            <tr>
                <td width="75%">
                    <p>实务冲刺班</p>
                </td>
                <td width="25%">
                    <p>3000元</p>
                </td>
            </tr>
        </table>
    </div>
    <p>&nbsp;</p>
    <table width="100%" border="0">
        <tr>
            <td width="25%">
                <img src="images/lingdang.png" width="28" height="28" />报考通</td>
            <td>
                <p>有<asp:Label ID="lblBaoKaoTong" runat="server" Style="color: red;" Text="0"></asp:Label>条与<span style="color: red"><%# queryValue%></span>有关报名考试信息</p>
            </td>
        </tr>
    </table>
    <div style="font-size: xx-small;">
        <table width="100%" border="0">
            <tr>
                <td width="75%">
                    <p>暂无本年度报名考试信息</p>
                </td>
                <td width="25%">
                    <p>&nbsp;</p>
                </td>
            </tr>
        </table>
    </div>
    <p>&nbsp;</p>
    </div>
</asp:Content>

