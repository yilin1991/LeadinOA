<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Leadin.OA.oasystem.oasystem.index" %>

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



                <div class="ztreebody am-g">

                    <div class="ztreebox am-u-sm-3 am-u-lg-3">
                        <div class="ibox-title">
                            <h5>部门列表 <small></small></h5>
                        </div>
                        <div class="ibox-content" style="padding: 15px 10px 20px 10px;">
                            <div class="zTreeDemoBackground">
                                <ul id="treeDemo" class="ztree"></ul>
                            </div>
                        </div>

                    </div>
                    <div class="ztreedetail am-u-sm-9 am-u-lg-9">
                          <iframe src="/oasystem/oacategory/detail.aspx" width="100%" style="position:static;left:-22in;top:-11in;" id="DeployBase" name="DeployBase" frameborder="0" scrolling="auto" onload="iFrameHeight()" allowtransparency="true"></iframe>
                    </div>


                </div>



            </div>

        </div>
        <uc1:footerlink runat="server" ID="footerlink" />
        <script src="/js/jquery.ztree.core-3.5.js"></script>
        <script>
            $(function () {

                setLeftMenu("类别管理", "类别管理")
                var H = $(window).height();
                $("#DeployBase").css({ 'height': H - 20 });

                $.post("/Tools/GetCateGoryTree.ashx", {}, function (res) {
                 
                        $.fn.zTree.init($("#treeDemo"), setting, res);


                }, "json");
                $('#DeployBase').css('height', '');
            })




            var setting = {
                check: {
                    enable: true
                },
                data: {
                    simpleData: {
                        enable: true
                    }
                },
                callback: {
                    onCheck: onCheck
                }
            };

            function onCheck(e, treeId, treeNode) {
                var treeObj = $.fn.zTree.getZTreeObj("treeDemo"),
                    nodes = treeObj.getCheckedNodes(true),
                    v = "";
                for (var i = 0; i < nodes.length; i++) {
                    v += nodes[i].name + ",";
                    alert(nodes[i].id); //获取选中节点的值
                }


            }
            function iFrameHeight() {
                var ifm = document.getElementById("DeployBase");
                var subWeb = document.frames ? document.frames["DeployBase"].document : ifm.contentDocument;
                if (ifm != null && subWeb != null) {
                    ifm.height = subWeb.body.scrollHeight + 0;
                }
            }

        </script>


    </form>
</body>

</html>

