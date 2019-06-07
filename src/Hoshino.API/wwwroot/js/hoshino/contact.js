
$(function () {
    //加载数据
    LoadData();
    $("#btnSearch").click(function () {
        pageindex = 1;
        LoadData();
    });

    $(document).on("click", ".appointmentUpdateStatus", function () {
        var Contact_ID = $(this).attr("Contact_ID");
        showDetail(Contact_ID);
        $("#hiEventUpdateStatus").click();
    })

    $("#btnUpdateStatus").click(function () {
        var Contact_ID = $("#hiContact_ID").val();
        var Processing_Result = $("#txtProcessing_Result").val();
        requestUrl("/api/b_contact/UpdateStatus?Contact_ID=" + Contact_ID, function (data) {
            $("#btnClose").click();
            LoadData();
        }, JSON.stringify({ Contact_Status: 1, Processing_Result: Processing_Result }), 'POST');
    });
    
});

var showDetail = function (Contact_ID) {
    requestUrl("/api/b_contact/Get", function (data) {
        console.log(data);
        if (data.Code === 200 && !!data.Result) {
            
            $("#hiContact_ID").val(data.Result.Contact_ID);
            $("#txtCompany").val(data.Result.Company);
            $("#txtContacts").val(data.Result.Contacts);
            $("#txtPhone").val(data.Result.Phone);
            $("#txtEmail").val(data.Result.Email);
            $("#txtWechat").html(data.Result.Wechat);
            $("#txtWhatsApp").html(data.Result.WhatsApp);
            var statusStr = "";
            if (data.Result.Contact_Status == 0) {
                statusStr = "<span class='label label-primary'>未处理</span>";
                $("#btnUpdateStatus").show();
            } else {
                statusStr = "<span class='label label-warning'>已处理</span>";
                $("#btnUpdateStatus").hide();
            }
            $("#txtContact_Status").html(statusStr);
            $("#txtMatter").val(data.Result.Matter);
            $("#txtProcessing_Result").val(data.Result.Processing_Result);

            $("#hiEventShowDialog").click();
        }
    }, { Contact_ID: Contact_ID }, 'GET');

};



var pageindex = 1;
var pagesize = 10;
var LoadData = function () {

    requestUrl("/api/b_contact/GetList", function (data) {

        $("#tableContent").empty();
        if (data.Code === 200 && data.Result.length > 0) {
            var html = "";
            //设置页码，页数，总数
            $.each(data.Result, function (n, item) {
                var statusStr = "";
                var dataUrl = "";
                var matterStr = "";
                if (!!!item.Contact_Status || item.Contact_Status === 0) {
                    statusStr = "<span class='label label-primary'>未处理";
                } else {
                    statusStr = "<span class='label label-default'>已处理";
                }
                if (!$.isEmptyObject(item.Material)) {
                    dataUrl = item.Material;
                }
                if (item.Matter.length > 50) {
                    matterStr = item.Matter.substr(0, 50) + '...';
                } else {
                    matterStr = item.Matter;
                }
                html += "<tr> \
                <td class='project-status'>"+ statusStr + "</td>\
                <td class='project-title'>"+ matterStr + "</label> " +(item.Contact_Status===1?("<br />\
                    <small class='label label-warning'>处理结果: "+ item.Processing_Result + "</small>"):"")+"\
                </td>\
                <td class='project-completion'>\
                        <span class='label label-default'>"+ item.Create_Time + " </td>\
                <td class='project-completion'>"+ item.Company + "</td>\
                <td class='project-completion'>"+ item.Contacts + "</td>\
                <td class='project-completion'>"+ item.Phone + "</td>\
                <td class='project-people'>"+ item.Email + "</td>\
                <td class='project-people'>"+ dataUrl + "</td>\
                <td class='project-actions'>\
                    <a href='#'  class='btn btn-white btn-sm appointmentUpdateStatus' Contact_ID='" + item.Contact_ID + "'><i class='fa fa-pencil'></i> 标记为已处理 </a>\
                </td>\
                </tr>";
            });
            $("#tableContent").append(html);
            pagination(pageindex, pagesize, data.Total, function (index) {
                if (pageindex !== index) {
                    pageindex = index;
                    LoadData();
                }
            });
        }
    }, { Contact_Status: $("#Contact_Status").val(), pageindex: pageindex, pagesize: 10 }, 'GET');

}