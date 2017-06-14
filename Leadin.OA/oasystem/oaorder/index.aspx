<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Leadin.OA.oasystem.oaorder.index" %>

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
    <meta name="description" content="职工列表">
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
                            <li class="am-active">订单列表</li>
                        </ol>

                    </div>


                    <div class="tpl-block">
                        <div class="am-g">
                            <div class="am-u-sm-12 am-u-md-4">
                                <div class="am-btn-toolbar">
                                    <div class="am-btn-group am-btn-group-xs">
                                        <asp:LinkButton runat="server" ID="lbtnAdd" CssClass="am-btn am-btn-default am-btn-success" OnClick="lbtnAdd_Click"><span class="am-icon-plus"></span> 新增</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lbtnMoney" CssClass="am-btn am-btn-default am-btn-danger" OnClick="lbtnMoney_Click"><span class="am-icon-plus"></span> 标记为已付款</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="am-u-sm-12 am-u-md-5">
                                <div class="am-form-group am-btn-group-xs">
                                   
                                    <asp:DropDownList runat="server" ID="ddlStateInfo" data-am-selected="{btnSize: 'sm'}">
                                        <asp:ListItem Value="">订单状态</asp:ListItem>
                                    </asp:DropDownList>
                                    


                                     <asp:LinkButton runat="server" ID="lbtnState" CssClass="am-btn am-btn-default am-btn-danger" OnClick="lbtnState_Click"><span class="am-icon-plus"></span> 修改订单状态</asp:LinkButton>

                                </div>
                            </div>
                            <div class="am-u-sm-12 am-u-md-3">
                                <div class="am-input-group am-input-group-sm">
                                    <input type="text" class="am-form-field">
                                    <span class="am-input-group-btn">
                                        <%--<button class="am-btn  am-btn-default am-btn-success tpl-am-btn-success am-icon-search" type="button"></button>--%>
                                        <asp:LinkButton runat="server" ID="btnSearch" CssClass="am-btn  am-btn-default am-btn-success tpl-am-btn-success am-icon-search"></asp:LinkButton>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="am-g">
                            <div class="am-u-sm-12">
                                <div class="am-form ">
                                    <div class="am-scrollable-horizontal">
                                        <table class="am-table am-table-striped am-table-hover table-main am-text-nowrap">
                                            <thead>
                                                <tr>
                                                    <th class="table-check">
                                                        <input type="checkbox" id="ckCheckAll"></th>
                                                    <th class="table-numid">订单编号</th>
                                                    <th class="table-author">公司名称</th>
                                                    <th class="table-author">收货信息</th>
                                                    <th class="table-author">配送方式</th>
                                                    <th class="table-author">配送人</th>
                                                    <th class="table-author">配送单号</th>
                                                    <th class="table-author">快递费用</th>
                                                    <th class="table-author">订单金额</th>
                                                    <th class="table-author">货款状态</th>
                                                     <th class="table-author">订单状态</th>
                                                     <th class="table-author">添加时间</th>
                                                    <th class="table-set">操作</th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:Repeater runat="server" ID="repList" OnItemCommand="repList_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="ckChecked" />
                                                            </td>
                                                            <td><%# Eval("NumId") %>
                                                                <asp:HiddenField runat="server" ID="hidfid" Value='<%# Eval("Id") %>' />
                                                            </td>
                                                            <td><%# GetCustomerName(int.Parse(Eval("CustomerId").ToString())) %></td>
                                                            <td><%# GetAddressDetail(Eval("AddressId").ToString()) %></td>

                                                            <td><%#  GetDisDistribution(int.Parse(Eval("Id").ToString()))[0] %></td>
                                                            <td><%#  GetDisDistribution(int.Parse(Eval("Id").ToString()))[1]%></td>
                                                            <td><%#  GetDisDistribution(int.Parse(Eval("Id").ToString()))[2] %></td>
                                                            <td><%#  GetDisDistribution(int.Parse(Eval("Id").ToString()))[3] %></td>

                                                            <td><%# GetFathrtMoney(int.Parse(Eval("Id").ToString())).ToString("0.00")+" 元" %></td>
                                                            <td><%# Eval("MoneyState").ToString()=="1"?"已付款":"未付款" %></td>
                                                            <td><%# GetCategoryName(int.Parse(Eval("StateInfo").ToString())) %></td>
                                                             <td><%# Convert.ToDateTime(Eval("AddTime").ToString()).ToString("yyyy-MM-dd") %></td>
                                                            <td>
                                                                <div class="am-btn-toolbar" style="width:150px;">
                                                                    <div class="am-btn-group am-btn-group-xs">


                                                                        <asp:LinkButton runat="server" ID="lbtnDistribution" CommandName="lbtnDistribution" CssClass="am-btn am-btn-default am-btn-xs am-text-secondary"><span class="am-icon-pencil-square-o"></span> 编辑</asp:LinkButton>
                                                                        <asp:LinkButton runat="server" ID="lbtnSonOrder" CommandName="lbtnSonOrder" CssClass="am-btn am-btn-default am-btn-xs am-text-secondary"><span class="am-icon-trash-o"></span> 子订单</asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>




                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="am-cf">

                                        <div class="am-fl">
                                            <ul class="am-pagination tpl-pagination">
                                                <li class="am-disabled"><a href="#">«</a></li>
                                                <li class="am-active"><a href="#">1</a></li>
                                                <li><a href="#">2</a></li>
                                                <li><a href="#">3</a></li>
                                                <li><a href="#">4</a></li>
                                                <li><a href="#">5</a></li>
                                                <li><a href="#">»</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <hr>
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

                setLeftMenu("订单管理", "订单列表");

            })

        </script>


    </form>
</body>

</html>

