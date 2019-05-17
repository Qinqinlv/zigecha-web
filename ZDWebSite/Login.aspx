<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin-left: 20px;
    margin-right: 20px; font-size:13px"
    >

        <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-l-55 p-r-55">
				
                    <div class="txt1 text-center" style="font-size:15px;font-weight: bold;">
						<span>登 录</span>
					</div>
					<div class="wrap-input100 validate-input m-b-23" data-validate="请输入用户名">
						<span class="label-input100">用户名</span>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="input100" placeholder="请输入用户名" OnTextChanged="txtUserName_TextChanged" ></asp:TextBox>
						<span class="focus-input100" data-symbol="&#xf206;"></span>
                        
					</div>
                <div class="text-right">
                    <asp:Label ID="lblUserName" runat="server" style="color:red" Text="请输入用户名!"></asp:Label>
					</div>
                    
					<div class="wrap-input100 validate-input" data-validate="请输入密码">
						<span class="label-input100">密码</span>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="input100" placeholder="请输入密码" TextMode="Password" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
						<span class="focus-input100" data-symbol="&#xf190;"></span>
					</div>
                <div class="text-right">
                    <asp:Label ID="lblPassword" runat="server" style="color:red" Text="请输入密码!"></asp:Label>
					</div>
					<div class="text-right p-t-8 p-b-31">
						<a href="javascript:">忘记密码？</a><asp:CheckBox ID="chkRemenberMe" runat="server" Text="记住用户"/>
					</div>

					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
                            <asp:LinkButton ID="linkbtnLogin" runat="server" CssClass="login100-form-btn" OnClick="linkbtnLogin_Click">登 录</asp:LinkButton>
						</div>
					</div>

					<div class="txt1 text-center p-t-8 p-b-20">
						<span>第三方登录</span>
					</div>

					<div class="flex-c-m">
                        <asp:LinkButton ID="linkbtnWechat" runat="server" CssClass="login100-social-item bg1" OnClick="linkbtnWechat_Click"><i class="fa fa-wechat"></i></asp:LinkButton>

						<%--<a href="#" class="login100-social-item bg2">
							<i class="fa fa-qq"></i>
						</a>

						<a href="#" class="login100-social-item bg3">
							<i class="fa fa-weibo"></i>
						</a>--%>
					</div>

					<div class="flex-col-c p-t-8">
                        <asp:LinkButton ID="linkbtnRegister" CssClass="txt2" runat="server" OnClick="linkbtnRegister_Click">立即注册</asp:LinkButton>
					</div>
			</div>
		</div>
	</div>

            </div>
</asp:Content>

