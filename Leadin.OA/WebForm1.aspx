<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Leadin.OA.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" id="Button1"  value="提交"/>
        </div>
    </form>
    <script src="js/jquery-1.11.1.min.js"></script>
    <script>

        $(function () {
            $("#Button1").on("click", function () {

                var obj = {};
                obj.NumId = "1000000";
                obj.Title = "类别";
                obj.SubTitle = "副类别";
                obj.Explain = "说明";
                obj.ParentId = 0;
                obj.StateInfo = 1;
                obj.LevelNum = 0;
                obj.SortNum = 10000;
                obj.LinkUrl = "";
                obj.Remark = "";
                AddTime = Date.now;

                $.ajax({
                    type: "POST",
                    url: "http://192.168.1.115:8022/api/Category",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(obj),
                    success: function (data) {
                        alert("数据成功添加！");
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });
            });
        });

    </script>


</body>
</html>
