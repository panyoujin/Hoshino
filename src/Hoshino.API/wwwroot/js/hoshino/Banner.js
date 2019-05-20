
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

    $("#btnSave").on('click', function () {
        var json = { Banner_URL: $("#fileUrl").val(), Banner_Name_CH: $("#fileName").val(), Banner_Name_HK: $("#fileName").val(), Banner_Type: 'image', Banner_Location: "Index" };
        requestUrl("/api/b_banner_resources/Post", function (data) {
            $("#btnClose").click();
            LoadData();

        }, JSON.stringify(json), 'POST');
    });
});

var showDetail = function (url) {


};

var delete_banner = function (banner_ID) {
    requestUrl("/api/b_banner_resources/Delete", function (data) {
        console.log(data);
        if (data.Code === 200 && !!data.Result) {
            LoadData();
        }
    }, { Banner_ID: banner_ID }, 'HttpDelete');

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
                html += '<td class="project-status">' + item.Banner_ID + '</td>';
                html += '<td class="project-status">' + item.Banner_URL + '</td>';
                html += '<td class="project-status">' + item.Banner_Seq + '</td>';
                html += '<td class="project-actions">';
                html += '<a href="#" class="btn btn-white btn-sm" onclick="showDetail(' + item.Banner_URL + ')"><i class="fa fa-binoculars"></i> 查看 </a>';
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