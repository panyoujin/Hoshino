
$(function () {
    //加载数据
    LoadData();
    $("#btnSearch").on('click', function () {
        pageindex = 1;
        LoadData();
    });

    $("#Import").change(function (e) {
        if (e.currentTarget.files.length <= 0) {
            return;
        }
        var formData = new FormData();
        formData.append("file", e.currentTarget.files[0]);
        requestFromUrl("/api/Upload/Post", function (obj) {
            console.info(obj);
            if (obj.Code == 200) {
                $("#imgLogo").attr("src", _Domain + obj.Result.filePath);
                $("#imgLogo").attr("pic", obj.Result.filePath);
                $("#imgLogo").attr("LogoName", obj.Result.fileName);
            }
        }, formData);
    });


    $("#btnSave").on('click', function () {

        var json = { Logo_URL: $("#imgLogo").attr("pic"), Logo_Name_CH:  $("#imgLogo").attr("LogoName"), Logo_Name_HK: $("#imgLogo").attr("LogoName"), Logo_Seq: $("#txtLogoSeq").val()};

        requestUrl("/api/b_logo_resources/Post", function (data) {
            $("#btnClose").click();
            LoadData();

        }, JSON.stringify(json), 'POST');

    });

    $(document).on("click", ".logoDelete", function () {
        var reg={ Logo_ID: $(this).attr("logoId") };

        requestUrl("/api/b_logo_resources/Delete", function (data) {

            if (data.Code === 200 && data.Result) {
                LoadData();
            }
        }, JSON.stringify(reg), 'POST');
    })


});



var pageindex = 1;
var pagesize = 10;
var LoadData = function () {
    requestUrl("/api/b_logo_resources/GetList", function (data) {
        console.log(data);
        if (data.Code === 200 && data.Result.length > 0) {
            var html = "";
            $("#tableContent").empty();
            //设置页码，页数，总数
            $.each(data.Result, function (n, item) {
                html += "<tr> \
                        <td class='project-status'>"+ (n + 1) + "</td> \
                        <td class='project-title'> \
                            <img style='width:144;height:50px;' src='"+ _Domain + item.Logo_URL + "'> \
                        </td>\
                        <td class='project-title'>	"+ item.Logo_Name_CH + "</td>\
                        <td class='project-completion'>\
                            <small>创建于 	"+ item.Create_Time + "</small>\
                        </td>\
                        '<td class='project-status'><span class='label label-warning'>" + item.Logo_Seq + "</span></td>'\
                        <td class='project-actions'>\
                            <a href='#' class='btn btn-white btn-sm logoDelete' logoId='" + item.Logo_ID + "' ><i class='fa fa-delete'></i> 删除 </a>\
                        </td>\
                        </tr>";
            });
            $("#tableContent").append(html);
        }
    }, { pageindex: pageindex, pagesize: 100 }, 'GET');

}