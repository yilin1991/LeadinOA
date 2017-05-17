<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editfathrt.aspx.cs" EnableEventValidation="false" Inherits="Leadin.OA.oasystem.oaorder.editfathrt" %>

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
                            <li><a href="/oasystem/oaorder/index.aspx">订单管理</a></li>
                            <li class="am-active">订单编辑</li>
                        </ol>

                    </div>
                    <div class="tpl-block ">

                        <div class="am-g tpl-amazeui-form">

                            <div class="am-u-sm-12 am-u-md-9">
                                <div class="am-form am-form-horizontal">
                                    <div class="am-form-group">
                                        <label for="ddlCustomer" class="am-u-sm-2 am-form-label">下单客户</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlCustomer" datatype="*" nullmsg="请选择下单客户！" ajaxurl='' >
                                                <asp:ListItem Value="">请选择下单客户</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="ddlAddress" class="am-u-sm-2 am-form-label">收货信息</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlAddress">
                                                <asp:ListItem Value="">请选择收货地址</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="ddlDelivery" class="am-u-sm-2 am-form-label">配送方式</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlDelivery" datatype="*" nullmsg="请选择配送方式！">
                                                <asp:ListItem Value="">请选择配送方式</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="ddlDeliverystaff" class="am-u-sm-2 am-form-label">配送人</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlDeliverystaff" >
                                                <asp:ListItem Value="">请选择配送人</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                     <div class="am-form-group">
                                        <label for="txtDeliveryNum" class="am-u-sm-2 am-form-label">配送单号</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtDeliveryNum" placeholder="请输入配送单号" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="ddlPriceType" class="am-u-sm-2 am-form-label">快递费</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlPriceType" datatype="*" nullmsg="请选择配送方式！">
                                                <asp:ListItem Value="0">非到付</asp:ListItem>
                                                <asp:ListItem Value="1">到付</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                    <div class="am-form-group">
                                        <label for="txtExplain" class="am-u-sm-2 am-form-label">订单说明</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtExplain" TextMode="MultiLine" Rows="5" placeholder="请输入类别的简介，选填"></asp:TextBox>
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
        <script src="/js/order.js"></script>
        <script>

            $(function () {

                
                $("#ddlCustomer").attr("ajaxurl", "<%= checkorder%>");


                var demo = $("#myform").Validform({

                    tiptype: function (msg, o, cssctl) {
                        if (o.type == 3) {
                            $.tooltip(msg, 1500, false);
                        }
                    },
                    postonce: true,
                    datatype: {
                        "price": /^[0-9]+(.[0-9]{2})?$/,
                        "printnum": /^[0-9]+(.[0-9]{1})?$/
                    }
                });


                setLeftMenu("订单管理", "订单编辑")



            })






        </script>


    </form>
</body>

</html>



