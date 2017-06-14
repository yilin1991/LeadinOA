<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Leadin.OA.oasystem.oacategory.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
  



    <script src="../../js/jquery.ztree.core-3.5.js"></script>


    <script type="text/javascript">


        function iFrameHeight() {
            var ifm = document.getElementById("DeployBase");
            var subWeb = document.frames ? document.frames["DeployBase"].document : ifm.contentDocument;
            if (ifm != null && subWeb != null) {
                ifm.height = subWeb.body.scrollHeight + 0;
            }
        }


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

        $(function() {
            var H = $(window).height();
            $("#DeployBase").css({ 'height': H - 20 });

            $.post("/Sys/Department/GetTree", {type:1}, function(res) {
                if (res.Status == "y")
                    $.fn.zTree.init($("#treeDemo"), setting, res.Data);
                else {
                }
            }, "json");
            $('#DeployBase').css('height', '');
        });

    </script>


</body>
</html>
