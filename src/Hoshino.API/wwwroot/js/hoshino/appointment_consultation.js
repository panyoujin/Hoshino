
$(function () {
    //加载数据
    LoadData();
    $("#btnSearch").on('click', function () {
        pageindex = 1;
        LoadData();
    });

    $("#btnUpdateStatus").on('click', function () {
        var ac_id = $("#AC_ID").html();
        var Processing_Result = $("#Processing_Result").val();
        requestUrl("/api/b_appointment_consultation/UpdateStatus?AC_ID=" + ac_id, function (data) {
            $("#btnClose").click();
            LoadData();

        }, JSON.stringify({ AC_Status: 1, Processing_Result: Processing_Result }), 'POST');

    });
});

var showDetail = function (ac_id) {
    $("#hiEventShowDialog").click();
    requestUrl("/api/b_appointment_consultation/Get", function (data) {
        console.log(data);
        if (data.Code === 200 && !!data.Result) {
            console.log(data.Result.Company);
            $("#Company").html(data.Result.Company);
            $("#Contacts").html(data.Result.Contacts);
            $("#Phone").html(data.Result.Phone);
            $("#Email").html(data.Result.Email);
            $("#Matter").html(data.Result.Matter);
            $("#AC_ID").html(data.Result.AC_ID);
        }
    }, { AC_ID: ac_id }, 'GET');

};

var updateStatus = function (ac_id) {
    $("#hiEventUpdateStatus").click();
    $("#AC_ID").html(ac_id);
};

var pageindex = 1;
var pagesize = 10;
var LoadData = function () {

    requestUrl("/api/b_appointment_consultation/GetList", function (data) {

        if (data.Code === 200 && data.Result.length > 0) {
            var html = "";
            $("#tableContent").empty();
            //设置页码，页数，总数
            $.each(data.Result, function (n, item) {
                html += '<tr>';
                html += '<td class="project-status">' + item.AC_ID + '</td>';
                html += '<td class="project-status">' + item.Company + '</td>';
                html += '<td class="project-status">' + item.Contacts + '</td>';
                html += '<td class="project-status">' + item.Phone + '</td>';
                html += '<td class="project-status">' + item.Email + '</td>';
                html += '<td class="project-status">' + item.Matter + '</td>';
                if (item.AC_Status === 0) {
                    html += '<td class="project-status">未处理</td>';
                } else {
                    html += '<td class="project-status">' + item.Processing_Result + '</td>';
                }
                html += '<td class="project-actions">';
                html += '<a href="#" class="btn btn-white btn-sm" onclick="showDetail(' + item.AC_ID + ')"><i class="fa fa-binoculars"></i> 查看 </a>';
                if (item.AC_Status === 0) {
                    html += '<a href="#" class="btn btn-white btn-sm" onclick="updateStatus(' + item.AC_ID + ')"><i class="fa fa-binoculars"></i> 标记为已处理 </a>';
                }

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