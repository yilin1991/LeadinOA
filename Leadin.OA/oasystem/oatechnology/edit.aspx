<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Leadin.OA.oasystem.oatechnology.edit" %>

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
                            <li><a href="/oasystem/oatechnology/index.aspx">工艺管理</a></li>
                            <li class="am-active">工艺编辑</li>
                        </ol>

                    </div>
                    <div class="tpl-block ">

                        <div class="am-g tpl-amazeui-form">


                            <div class="am-u-sm-12 am-u-md-9">
                                <div class="am-form am-form-horizontal">
                                    <div class="am-form-group">
                                        <label for="txtTitle" class="am-u-sm-2 am-form-label">工艺名称</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtTitle" placeholder="请输入工艺名称，必填" datatype="*" nullmsg="工艺名称不能为空！"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="ddlTechnology" class="am-u-sm-2 am-form-label">所属工艺</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlTechnology" datatype="*" nullmsg="请选择所属工艺！">
                                                <asp:ListItem Value="">请选择供应商类别</asp:ListItem>
                                                <asp:ListItem Value="0">顶级工艺</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="txtPrice" class="am-u-sm-2 am-form-label">价格</label>
                                        <div class="am-u-sm-10">
                                           <asp:TextBox runat="server" ID="txtPrice" placeholder="请输入工艺价格，保留两位小数，必填" Text="0.00"  datatype="price"  ignore="ignore" errormsg="请输入正确的纸张价格们保留两位小数！"></asp:TextBox>
                                        </div>
                                    </div>
                                  <%-- <div class="am-form-group">
                                        <label for="txtTemPrice" class="am-u-sm-2 am-form-label">模版价格</label>
                                        <div class="am-u-sm-10">
                                           <asp:TextBox runat="server" ID="txtTemPrice" placeholder="请输入模版价格，保留两位小数，必填"   datatype="price"  ignore="ignore" errormsg="请输入正确的纸模版价格保留两位小数！"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                    <div class="am-form-group">
                                        <label for="txtSortNum" class="am-u-sm-2 am-form-label">排序</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtSortNum" TextMode="Number" Text="10000" pattern="[0-9]*" placeholder="请输入工艺的排序，数字越大越靠前" datatype="n" nullmsg="请输入工艺的排序！" errormsg="工艺排序为整数，数字越大越靠前！"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="txtRemark" class="am-u-sm-2 am-form-label">简介</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Rows="5" placeholder="请输入类别的简介，选填"></asp:TextBox>
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
                    datatype: {
                        "price": /^[0-9]+(.[0-9]{2})?$/
                    }
                });


                setLeftMenu("工艺管理", "工艺编辑")



            })






        </script>


    </form>
</body>

</html>


