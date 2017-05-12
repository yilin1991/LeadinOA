<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Leadin.OA.oasystem.oacustomer.index" %>

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
                            <li><a href="/oasystem/oacustomer/index.aspx">客户管理</a></li>
                            <li class="am-active">客户列表</li>
                        </ol>

                    </div>


                    <div class="tpl-block">
                        <div class="am-g">
                            <div class="am-u-sm-12 am-u-md-6">
                                <div class="am-btn-toolbar">
                                    <div class="am-btn-group am-btn-group-xs">
                                        <asp:LinkButton runat="server" ID="lbtnAdd" CssClass="am-btn am-btn-default am-btn-success" OnClick="lbtnAdd_Click"><span class="am-icon-plus"></span> 新增</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lbtnDel" CssClass="am-btn am-btn-default am-btn-danger"><span class="am-icon-plus"></span> 删除</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="am-u-sm-12 am-u-md-3">
                                <div class="am-form-group">
                                    <select data-am-selected="{btnSize: 'sm'}">
                                        <option value="option1">所有类别</option>
                                        <option value="option2">IT业界</option>
                                        <option value="option3">数码产品</option>
                                        <option value="option3">笔记本电脑</option>
                                        <option value="option3">平板电脑</option>
                                        <option value="option3">只能手机</option>
                                        <option value="option3">超极本</option>
                                    </select>
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
                                                    <th class="table-numid">客户编号</th>
                                                    <th class="table-author">公司名称</th>
                                                    <th class="table-author">客户来源</th>
                                                    <th class="table-author">所属公司</th>
                                                    <th class="table-author">联系人</th>
                                                    <th class="table-author">手机号</th>
                                                    <th class="table-author">状态</th>
                                                    <th class="table-author">邮箱</th>
                                                    <th class="table-author">微信号</th>
                                                    <th class="table-author">QQ号</th>
                                                    <th class="table-author">公司地址</th>
                                                    <th class="table-author">添加时间</th>
                                                    <th class="table-author">说明</th>
                                                    <th class="table-set">操作</th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:Repeater runat="server" ID="repList">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="ckChecked" />
                                                            </td>
                                                            <td><%# Eval("NumId") %></td>
                                                            <td><a href="edit.aspx?id=<%# Eval("Id") %>"><%# Eval("CompanyName") %></a></td>
                                                            <td><%# GetCategoryName(int.Parse(Eval("SourceId").ToString())) %></td>
                                                            <td><%# GetPartentCompany(int.Parse(Eval("ParentId").ToString())) %></td>
                                                            <td><%# Eval("NameInfo").ToString()==""?"--":Eval("NameInfo").ToString() %></td>
                                                            <td><%#Eval("Phone").ToString()==""?"--":Eval("Phone").ToString() %></td>
                                                            <td><%# Eval("StateInfo").ToString()=="1"?"正常":"禁用" %></td>
                                                            <td><%#Eval("Email").ToString()==""?"--":Eval("Email").ToString() %></td>
                                                            <td><%#Eval("WeChat").ToString()==""?"--":Eval("WeChat").ToString() %></td>
                                                            <td><%#Eval("QQNum").ToString()==""?"--":Eval("QQNum").ToString() %></td>
                                                            <td><%#Eval("Addressinfo").ToString()==""?"--":Eval("Addressinfo").ToString() %></td>
                                                            <td><%#Eval("AddTime") %></td>
                                                            <td><%#Eval("Explain").ToString()==""?"--":Eval("Explain").ToString() %></td>

                                                            <td>
                                                                <div class="am-btn-toolbar">
                                                                    <div class="am-btn-group am-btn-group-xs">
                                                                        <button class="am-btn am-btn-default am-btn-xs am-text-secondary"><span class="am-icon-pencil-square-o"></span>编辑</button>
                                                                        <button class="am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only"><span class="am-icon-trash-o"></span>删除</button>
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

                setLeftMenu("客户管理", "客户列表");

            })

        </script>


    </form>
</body>

</html>

