<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Leadin.OA.oasystem.oaworkers.edit" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Left.ascx" TagPrefix="uc1" TagName="Left" %>
<%@ Register Src="~/Controls/footerlink.ascx" TagPrefix="uc1" TagName="footerlink" %>
<%@ Register Src="~/Controls/headerlink.ascx" TagPrefix="uc1" TagName="headerlink" %>


<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>万印名片行OA系统</title>
    <meta name="description" content="人员编辑">
    <uc1:headerlink runat="server" ID="headerlink" />
</head>

<body data-type="generalComponents">

    <form id="myform" runat="server">

        <%-- 头部导航 Begin --%>
        <uc1:Header runat="server" ID="Header" />
        <%-- 头部导航 End --%>

        <div class="tpl-page-container tpl-page-header-fixed">


            <%-- 左侧导航 Begin --%>
            <uc1:Left runat="server" ID="Left" />
            <%-- 左侧导航 End --%>




            <div class="tpl-content-wrapper">



                <div class="tpl-portlet-components">
                    <div class="portlet-title">
                        <ol class="am-breadcrumb">
                            <li><a href="/index.aspx" class="am-icon-home">首页</a></li>
                            <li><a href="/oasystem/oaworkers/index.aspx">人员管理</a></li>
                            <li class="am-active">人员编辑</li>
                        </ol>

                    </div>
                    <div class="tpl-block ">

                        <div class="am-g tpl-amazeui-form">


                            <div class="am-u-sm-12 am-u-md-9">
                                <div class="am-form am-form-horizontal">
                                    <div class="am-form-group">
                                        <label for="txtAccount" class="am-u-sm-2 am-form-label">登录帐号</label>
                                        <div class="am-u-sm-10">
                                            <input type="text" name="txtAccount" id="txtAccount" class="inputtext400" value="<%= account %>" datatype="s2-16"  ajaxurl="<%= checkAccount %>" nullmsg="登录帐号不能为空" errormsg="字母数字组合2-16位字符！" placeholder="请输入登录帐号，字母数字组合4-16位必填字符" />
                                        </div>
                                    </div>
                                     <div class="am-form-group">
                                        <label for="ddlParentType" class="am-u-sm-2 am-form-label">所属职位</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlType" datatype="*" nullmsg="请选择所属职位！">
                                                <asp:ListItem Value="">所属职位</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="txtPwd" class="am-u-sm-2 am-form-label">密码</label>
                                        <div class="am-u-sm-10">   
                                            <asp:TextBox runat="server" ID="txtPwd" placeholder="请输入密码，必填" datatype="*" nullmsg="密码不能为空！" errormsg="密码字母数字组合6-16位字符！"></asp:TextBox>
                                        </div>
                                    </div>
                                   
                                    <div class="am-form-group">
                                        <label for="txtNameInfo" class="am-u-sm-2 am-form-label">姓名</label>
                                        <div class="am-u-sm-10">   
                                            <asp:TextBox runat="server" ID="txtNameInfo" placeholder="请输入人员姓名，必填" datatype="*" nullmsg="人员的姓名不能为空！"></asp:TextBox>
                                        </div>
                                    </div>
                                   

                                    <div class="am-form-group">
                                        <label for="txtPhone" class="am-u-sm-2 am-form-label">手机号</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtPhone" TextMode="Phone" placeholder="请输入手机号码" datatype="m" nullmsg="手机号码不能为空！" errormsg="请输入正确格式的手机号码！"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="txtEmail" class="am-u-sm-2 am-form-label">邮箱</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" ignore="ignore" placeholder="请输入联系邮箱" datatype="e"  errormsg="请输入正确的邮箱格式！"></asp:TextBox>
                                        </div>
                                    </div>
                                   

                                    <div class="am-form-group">
                                        <label for="user-QQ" class="am-u-sm-2 am-form-label">状态</label>
                                        <div class="am-u-sm-10">
                                            <label class="am-checkbox-inline">
                                                <asp:CheckBox runat="server" ID="ckState" Checked="true" />
                                                勾选表示正常
                                            </label>
                                        </div>
                                    </div>


                                    <div class="am-form-group">
                                        <div class="am-u-sm-10 am-u-sm-push-2">
                                            <asp:Button runat="server" ID="btnOK" CssClass="am-btn am-btn-primary" Text="保存修改" OnClick="btnOK_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>



            </div>

        </div>
        <uc1:footerlink runat="server" ID="footerlink" />
        <script>

            $(function () {

                var demo = $("#myform").Validform({

                    tiptype: function (msg, o, cssctl) {
                        if (o.type == 3) {
                            $.tooltip(msg, 1500, false);
                        }
                    },
                    postonce: true,
                });


                setLeftMenu("人员管理", "编辑人员");



            })






        </script>


    </form>
</body>

</html>

