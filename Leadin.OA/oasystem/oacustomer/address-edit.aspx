<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="address-edit.aspx.cs" Inherits="Leadin.OA.oasystem.oacustomer.address_edit" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Left.ascx" TagPrefix="uc1" TagName="Left" %>
<%@ Register Src="~/Controls/footerlink.ascx" TagPrefix="uc1" TagName="footerlink" %>
<%@ Register Src="~/Controls/headerlink.ascx" TagPrefix="uc1" TagName="headerlink" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Amaze UI Admin index Examples</title>
    <meta name="description" content="这是一个 index 页面">
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
                            <li><a href="/oasystem/oacustomer/index.aspx">客户管理</a></li>
                            <li class="am-active">收货地址编辑</li>
                        </ol>

                    </div>
                    <div class="tpl-block ">

                        <div class="am-g tpl-amazeui-form">


                            <div class="am-u-sm-12 am-u-md-9">
                                <div class="am-form am-form-horizontal">
                                   
                                    <div class="am-form-group">
                                        <label for="txtNameInfo" class="am-u-sm-2 am-form-label">联系人</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtNameInfo" placeholder="请输入联系人姓名，选填" datatype="*" nullmsg="联系人姓名不能为空！"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="txtPhone" class="am-u-sm-2 am-form-label">手机号</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtPhone" placeholder="请输入联系人手机号，选填" datatype="m" nullmsg="供应商名称不能为空！" errormsg="请输入正确格式的手机号码！"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="am-form-group">
                                        <label for="txtAddress" class="am-u-sm-2 am-form-label">联系地址</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtAddress" placeholder="请输入联系地址，选填"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="user-QQ" class="am-u-sm-2 am-form-label">状态</label>
                                        <div class="am-u-sm-10">
                                            <label class="am-checkbox-inline">
                                                <asp:CheckBox runat="server" ID="ckState" Checked="true" />
                                                勾选表示启用
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


                setLeftMenu("客户管理", "客户列表")



            })






        </script>


    </form>
</body>

</html>


