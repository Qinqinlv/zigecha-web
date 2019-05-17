<%@ Page Title="证典-登录" Language="C#" MasterPageFile="~/Site.Mobile.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="margin-left: 20px;
    margin-right: 20px; font-size:13px"
    >
        <div class="limiter">
		<div class="container-login100" ">
			<div class="wrap-login100 p-l-55 p-r-55">
				
                    <div class="txt1 text-center p-b-20" style="font-size:15px;font-weight: bold;">
						<span>登 录</span>
					</div>
					<div class="wrap-input100 validate-input m-b-23" data-validate="请输入用户名">
						<span class="label-input100">用户名</span>
						<input class="input100" type="text" name="username" placeholder="请输入用户名" autocomplete="off">
						<span class="focus-input100" data-symbol="&#xf206;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="请输入密码">
						<span class="label-input100">密码</span>
						<input class="input100" type="password" name="pass" placeholder="请输入密码">
						<span class="focus-input100" data-symbol="&#xf190;"></span>
					</div>

					<div class="text-right p-t-8 p-b-31">
						<a href="javascript:">忘记密码？</a>
					</div>

					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
							<button class="login100-form-btn">登 录</button>
						</div>
					</div>

					<div class="txt1 text-center p-t-20 p-b-20">
						<span>第三方登录</span>
					</div>

					<div class="flex-c-m">
						<a href="#" class="login100-social-item bg1">
							<i class="fa fa-wechat"></i>
						</a>

						<a href="#" class="login100-social-item bg2">
							<i class="fa fa-qq"></i>
						</a>

						<a href="#" class="login100-social-item bg3">
							<i class="fa fa-weibo"></i>
						</a>
					</div>

					<div class="flex-col-c p-t-20">
						<a href="javascript:" class="txt2">立即注册</a>
					</div>
			</div>
		</div>
	</div>

            </div>
    
</asp:Content>