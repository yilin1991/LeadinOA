<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Leadin.OA.Login" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Amaze UI Admin index Examples</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <meta name="apple-mobile-web-app-title" content="Amaze UI" />

    <link rel="icon" type="image/png" href="i/favicon.png">
    <link rel="apple-touch-icon-precomposed" href="i/app-icon72x72@2x.png">
    <link rel="stylesheet" href="css/amazeui.min.css" />
    <link rel="stylesheet" href="css/admin.css">
    <link rel="stylesheet" href="css/app.css">
 
</head>

<body data-type="login">
    <form id="login" runat="server">
        <div class="am-g myapp-login">
            <div class="myapp-login-logo-block  tpl-login-max">
                <div class="myapp-login-logo-text">
                    <div class="myapp-login-logo-text">
                        Amaze UI<span> Login</span> <i class="am-icon-skyatlas"></i>

                    </div>
                </div>

                <div class="login-font">
                    <i>Log In </i>or <span>Sign Up</span>
                </div>
                <div class="am-u-sm-10 login-am-center">
                    <div class="am-form">
                        <fieldset>
                            <div class="am-form-group">
                                <input type="text" class="" name="txtAccount" id="txtAccount" placeholder="请输入登录的帐号" datatype="*" nullmsg="登录帐号不能为空！" errormsg="登录帐号不能为空！">
                            </div>
                            <div class="am-form-group">
                                <input type="password" class="" name="txtPassword" id="txtPassword" placeholder="请输入登录密码" datatype="*" nullmsg="登录密码不能为空！" errormsg="登录密码不能为空！">
                            </div>
                            <p>
                               
                                <asp:Button runat="server" ID="btn" Text="登录" CssClass="am-btn am-btn-default" OnClick="btn_Click" />

                            </p>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>

        <script src="js/jquery-1.11.1.min.js"></script>

        <script src="js/jquery.hDialog.js"></script>
        <script src="js/amazeui.min.js"></script>
        <script src="js/app.js"></script>

        <script src="js/Validform_v5.3.2.js"></script>
        <script>


            $(function () {

                var demo = $("#login").Validform({

                    tiptype: function (msg, o, cssctl) {
                        if (o.type == 3) {
                            $.tooltip(msg, 1500, false);
                        }
                    },
                    postonce: true,          
                });


              


            })


           



        </script>
    </form>

</body>

</html>
