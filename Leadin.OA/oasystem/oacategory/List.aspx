<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Leadin.OA.oasystem.oacategory.List" %>

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
                            <li><a href="/oasystem/oacategory/index.aspx">类别管理</a></li>
                            <li class="am-active">类别列表</li>
                        </ol>

                    </div>


                    <div class="tpl-block">

                        <div class="am-g">
                            <div class="am-u-sm-12">
                                <div id="sui_nav" class="sui-nav am-u-sm-3">
                                    <div class="sui-navtop">
                                        <p>类别列表</p>
                                    </div>
                                    <div class="sui-nav-wrapper nav-border ">
                                        <ul>
                                            <asp:Repeater runat="server" ID="repCategoryList">
                                                <ItemTemplate>
                                                    <li><a href="#"><span class="glyphicon glyphicon-edit"></span><%# Eval("Title") %></a>
                                                        <asp:HiddenField runat="server" ID="hidId" Value='<%# Eval("Id") %>' />
                                                        <ul>
                                                            <asp:Repeater runat="server" ID="repSecondList">
                                                                <ItemTemplate>
                                                                    <li><a href="#"><span class="glyphicon glyphicon-edit"></span><%# Eval("Title") %></a>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>



                                        </ul>


                                    </div>
                                </div>

                                <div class="nav-detail am-u-sm-9">
                                    <div class="nav-detail-top">
                                        <div class="am-btn-toolbar am-fr">
                                            <div class="am-btn-group am-btn-group-xs">
                                                <asp:LinkButton runat="server" ID="lbtnAdd" CssClass="am-btn am-btn-default am-btn-success"><span class="am-icon-plus"></span> 新增</asp:LinkButton>
                                                <asp:LinkButton runat="server" ID="lbtnDel" CssClass="am-btn am-btn-default am-btn-danger"><span class="am-icon-plus"></span> 删除</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="nav-detail-explain">
                                        <p><span>类别名称：</span><span>客户类别</span></p>
                                        <p><span>类别别名：</span><span>暂无</span></p>
                                        <p><span>所属父类别：</span><span>顶级类别</span></p>
                                        <p><span>类别排序：</span><span>1000</span></p>
                                        <p><span>类别状态：</span><span>正常</span></p>
                                        <p><span>类别简介：</span><span>客户类别</span></p>
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

                setLeftMenu("类别管理", "类别管理")
                var topbar = $('#sui_nav').SuiNav({ toggleName: '.MenuToggle', closingCascade: true, });
            })

        </script>


    </form>
</body>

</html>


