
$(function () {
    //加载数据
    LoadData();
    $("#btnSearch").on('click', function () {
        pageindex = 1;
        LoadData();
    });

    $("#btnAdd").on('click', function () {
        $("#hiEventShowDialog").click();
    });

    $("#Import").change(function () {
        //ImportFile("Import", "fileUrl", "imageurl","fileName");
    });
    $("#btnSave").on('click', function () {
        ImportFile("Import", "fileUrl", "imageurl", "fileName", function (filePath, fileName, fileType) {
            var json = { Banner_URL: filePath, Banner_Name_CH: fileName, Banner_Name_HK: fileName, Banner_Type: 'image', Banner_Location: "Index" };

            requestUrl("/api/b_banner_resources/Post", function (data) {
                $("#btnClose").click();
                LoadData();

            }, JSON.stringify(json), 'POST');
        });

    });
    $("#btnedit_Save").on('click', function () {

        console.log("seq:" + $("#edit_banner_seq").val());
        console.log("banner_id:" + $("#banner_id").val());
        var json = { Banner_Seq: $("#edit_banner_seq").val(), Banner_ID: $("#banner_id").val() };
        requestUrl("/api/b_banner_resources/Update", function (data) {
            $("#btnedit_Close").click();
            LoadData();

        }, JSON.stringify(json), 'POST');

    });
});

var showDetail = function (url, seq, banner_id) {
    $("#edit_imageurl").attr("src", url);
    $("#edit_banner_seq").val(seq);
    $("#banner_id").val(banner_id);
    $("#hiedit_EventShowDialog").click();
};

var delete_banner = function (banner_ID) {
    requestUrl("/api/b_banner_resources/Delete", function (data) {
        console.log(data);
        if (data.Code === 200 && !!data.Result) {
            LoadData();
        }
    }, { Banner_ID: banner_ID }, 'POST');

};

var pageindex = 1;
var pagesize = 10;
var LoadData = function () {

    requestUrl("/api/b_banner_resources/GetList", function (data) {

        if (data.Code === 200 && data.Result.length > 0) {
            var html = "";
            $("#tableContent").empty();
            //设置页码，页数，总数
            $.each(data.Result, function (n, item) {
                html += '<tr>';
                html += '<td class="project-status">' + (n + 1) + '</td>';
                html += '<td class="project-status">' + item.Banner_URL + '<br/><small>创建于 ' + item.Create_Time + '</small></td>';
                html += '<td class="project-status">' + item.Banner_Seq + '</td>';
                html += '<td class="project-actions">';
                html += '<a href="#" class="btn btn-white btn-sm" onclick="showDetail(\'' + item.Banner_URL + '\',' + item.Banner_Seq + ',' + item.Banner_ID + ')"><i class="fa fa-binoculars"></i> 查看 </a>';
                html += '<a href="#" class="btn btn-white btn-sm" onclick="delete_banner(' + item.Banner_ID + ')"><i class="fa fa-delete"></i> 删除 </a>';
                html += '</td>';
                html += '</tr>';
            });
            $("#tableContent").append(html);
            pagination(pageindex, pagesize, data.Total, function (index) {
                if (pageindex !== index) {
                    pageindex = index;
                    LoadData();
                }
            });
        }
    }, { pageindex: pageindex, pagesize: 10 }, 'GET');

}