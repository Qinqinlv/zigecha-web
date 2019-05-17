<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <div style="margin-left: 20px;
    margin-right: 20px; font-size:13px"
    >

        <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-l-55 p-r-55">
				
                    <div class="txt1 text-center" style="font-size:15px;font-weight: bold;">
						<span>注 册</span>
					</div>
					<div class="wrap-input100 validate-input m-b-23" data-validate="请输入用户名">
						<span class="label-input100">用户名</span>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="input100" placeholder="请输入用户名" OnTextChanged="txtUserName_TextChanged"  ></asp:TextBox>
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

					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
                            <asp:LinkButton ID="linkbtnRegister" runat="server" CssClass="login100-form-btn" OnClick="linkbtnRegister_Click">注 册</asp:LinkButton>
						</div>
					</div>

					
			</div>
		</div>
	</div>

            </div>
</asp:Content>

