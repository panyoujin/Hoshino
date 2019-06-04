
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
                $("#imgBanner").attr("src", _Domain + obj.Result.filePath);
                $("#imgBanner").attr("pic", obj.Result.filePath);
                $("#imgBanner").attr("bannerName", obj.Result.fileName);
            }
        }, formData);
    });


    $("#btnSave").on('click', function () {

        var json = { Banner_URL: $("#imgBanner").attr("pic"), Banner_Name_CH:  $("#imgBanner").attr("bannerName"), Banner_Name_HK: $("#imgBanner").attr("bannerName"),
         Banner_Type: 'image', Banner_Location: "Index" };

        requestUrl("/api/b_banner_resources/Post", function (data) {
            $("#btnClose").click();
            LoadData();

        }, JSON.stringify(json), 'POST');

        // ImportFile("Import", "fileUrl", "imageurl", "fileName", function (filePath, fileName, fileType) {

        // });
    });

    $(document).on("click", ".bannerDelete", function () {
        var reg={ Banner_ID: $(this).attr("bannerId") };

        requestUrl("/api/b_banner_resources/Delete", function (data) {
            console.log(data);
            if (data.Code === 200 && !!data.Result) {
                LoadData();
            }
        }, JSON.stringify(reg), 'POST');
    })

    // $("#btnedit_Save").on('click', function () {

    //     console.log("seq:" + $("#edit_banner_seq").val());
    //     console.log("banner_id:" + $("#banner_id").val());
    //     var json = { Banner_Seq: $("#edit_banner_seq").val(), Banner_ID: $("#banner_id").val() };
    //     requestUrl("/api/b_banner_resources/Update", function (data) {
    //         $("#btnedit_Close").click();
    //         LoadData();

    //     }, JSON.stringify(json), 'POST');

    // });
});

// var showDetail = function (url, seq, banner_id) {
//     $("#edit_imageurl").attr("src", url);
//     $("#edit_banner_seq").val(seq);
//     $("#banner_id").val(banner_id);
//     $("#hiedit_EventShowDialog").click();
// };

// var delete_banner = function (banner_ID) {
//     requestUrl("/api/b_banner_resources/Delete", function (data) {
//         console.log(data);
//         if (data.Code === 200 && !!data.Result) {
//             LoadData();
//         }
//     }, { Banner_ID: banner_ID }, 'POST');

// };

var pageindex = 1;
var pagesize = 10;
var LoadData = function () {
    requestUrl("/api/b_banner_resources/GetList", function (data) {

        if (data.Code === 200 && data.Result.length > 0) {
            var html = "";
            $("#tableContent").empty();
            //设置页码，页数，总数
            $.each(data.Result, function (n, item) {
                html += "<tr> \
                        <td class='project-status'>"+ (n + 1) + "</td> \
                        <td class='project-title'> \
                            <img style='width:144;height:50px;' src='"+ _Domain + item.Banner_URL + "'> \
                        </td>\
                        <td class='project-title'>	"+ item.Banner_Name_CH + "</td>\
                        <td class='project-completion'>\
                            <small>创建于 	"+ item.Create_Time + "</small>\
                        </td>\
                        '<td class='project-status'><span class='label label-warning'>" + item.Banner_Seq + "</span></td>'\
                        <td class='project-actions'>\
                            <a href='#' class='btn btn-white btn-sm bannerDelete' bannerId='" + item.Banner_ID + "' ><i class='fa fa-delete'></i> 删除 </a>\
                        </td>\
                        </tr>";
            });
            $("#tableContent").append(html);
        }
    }, { pageindex: pageindex, pagesize: 100 }, 'GET');

}