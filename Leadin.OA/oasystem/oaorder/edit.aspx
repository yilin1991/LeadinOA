<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Leadin.OA.oasystem.oaorder.edit" %>

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
                                            <asp:DropDownList runat="server" ID="ddlCustomer" datatype="*" nullmsg="请选择下单客户！">
                                                <asp:ListItem Value="">请选择下单客户</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="am-form-group">
                                        <label for="ddlType" class="am-u-sm-2 am-form-label">订单类别</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlType" datatype="*" nullmsg="请选择订单类别！">
                                                <asp:ListItem Value="">请选择下单客户</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="ddlPaper" class="am-u-sm-2 am-form-label">印刷纸张</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlPaper" datatype="*" nullmsg="请选择印刷纸张！">
                                                <asp:ListItem Value="">请选择印刷纸张</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="txtNum" class="am-u-sm-2 am-form-label">印刷数量</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtNum" placeholder="请输入印刷数量，每盒100张" Text="2.00" datatype="price" nullmsg="印刷数量不能为空！" errormsg="请输入正确的印刷数量！"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="ddlPublicversion" class="am-u-sm-2 am-form-label">客户公版</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="ddlPublicversion" >
                                                <asp:ListItem Value="0">请选择客户公版</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="user-QQ" class="am-u-sm-2 am-form-label">订单工艺</label>
                                        <div class="am-u-sm-10">

                                            <asp:Repeater runat="server" ID="repTechnology">
                                                <ItemTemplate>
                                                    <div class="technologylist">
                                                        <span class="technology"><%# Eval("NameInfo") %></span>
                                                        <asp:HiddenField runat="server" ID="hidId" Value='<%# Eval("Id") %>' />

                                                        <asp:Repeater runat="server" ID="repSubTechnology">
                                                            <ItemTemplate>
                                                                <label class="am-checkbox-inline">
                                                                    <asp:CheckBox runat="server" ID="ckTechnology" />
                                                                    <%# Eval("NameInfo") %>
                                                                </label>
                                                                <asp:HiddenField runat="server" ID="hidsubId" Value='<%# Eval("Id") %>' />
                                                                <asp:HiddenField runat="server" ID="hidPrice" Value='<%# Eval("Price") %>' />
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
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
                                        <label for="txtRemark" class="am-u-sm-2 am-form-label">快递费</label>
                                        <div class="am-u-sm-10">
                                            <asp:DropDownList runat="server" ID="DropDownList2" datatype="*" nullmsg="请选择配送方式！">
                                                <asp:ListItem Value="0">先付费</asp:ListItem>
                                                <asp:ListItem Value="1">到付</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="txtDifferencePrice" class="am-u-sm-2 am-form-label">订单差价</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtDifferencePrice" placeholder="请输入订单差价，支持正负差价" datatype="price" errormsg="请输入正确的订单差价金额！"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="am-form-group">
                                        <label for="txtDifferenceReason" class="am-u-sm-2 am-form-label">差价说明</label>
                                        <div class="am-u-sm-10">
                                            <asp:TextBox runat="server" ID="txtDifferenceReason" TextMode="MultiLine" Rows="5" placeholder="请输入类别的简介，选填"></asp:TextBox>
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



