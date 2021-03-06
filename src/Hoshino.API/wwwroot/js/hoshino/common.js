﻿$(function () {
    var token = $.cookie('Authorization');
    if (window.location.pathname.lastIndexOf("login.html")<0 && $.isEmptyObject(token)) {
        window.location.href = "login.html";
        return;
    }
    $("#btnOutLogin").click(function () {
        $.cookie('Authorization', '');
        window.location.href = "login.html";
        // requestUrl("/api/sys_user/Logout", function (obj) {
        //     if(obj.Code==200){
        //         $.cookie('Authorization', '');
        //         window.location.href = "login.html";
        //     }   
        // }, '');
    });
    // var req = { User_Account: "admin", Password: "202cb962ac59075b964b07152d234b70" };
    // var req = { User_Account: "admin", Password: "202cb962ac59075b964b07152d234b70" };
    // requestUrl("/api/sys_user/Login", function (obj) {
    //     console.info(obj);
    // }, JSON.stringify(req));

});

//var domain = ";
var _Domain = "/";
var api = '';
var requestUrl = function (url, callBack, json, type = 'POST') {
    var urlFull = api + url;
    $.ajax({
        type: type,
        url: urlFull,
        dataType: "json",
        headers: {
            "Content-Type": "application/json;charset=utf-8",
            "Authorization": $.cookie('Authorization'),
        },
        //contentType : 'application/json;charset=UTF-8',
        data: json,
        success: function (jsonData) {
            callBack(jsonData);
        },
        error: function (obj) {
            if (obj.status === 401) {
                location = "login.html";
            }
            console.info(obj);
        }

    });
};
var requestFromUrl = function (url, callBack, data, type = 'POST') {
    var urlFull = api + url;
    $.ajax({
        type: type,
        processData: false,
        contentType: false,
        url: urlFull,
        headers: {
            "Authorization": $.cookie('Authorization'),
        },
        data: data,
        success: callBack,
        error: function (obj) {
            if (obj.status === 401) {
                location = "login.html";
            }
            console.info(obj);
        }

    });
};

var pagination = function (pageindex, pagesize, total, loaddata) {
    pageindex = Number(pageindex);
    pagesize = Number(pagesize);
    total = Number(total);
    $("#pagination").empty();
    var html = '<ul class="pagination" >';
    if (pageindex > 1) {
        html += '<li><a data="' + (pageindex - 1) + '" >&laquo;</a></li>';
    }
    var pagetotal = Math.ceil(total / pagesize);
    var index = 1;
    var more = "";
    if (pagetotal > 20) {
        more = '<li><a>...</a></li>';
    }
    if (pagetotal <= 20) {
        for (index = 1; index <= pagetotal; index++) {
            html += '<li class="' + (pageindex === index ? "active" : "") + '"><a data="' + index + '">' + index + '</a></li>';
        }
    }
    else if (pageindex <= 10) {
        for (index = 1; index <= 17; index++) {
            html += '<li class="' + (pageindex === index ? "active" : "") + '"><a data="' + index + '">' + index + '</a></li>';
        }
        html += more;
        html += '<li><a data="' + pagetotal + '">' + pagetotal + '</a></li>';
    }
    else if (pageindex > 10 && pageindex <= (pagetotal - 10)) {
        html += '<li><a data="1">1</a></li>';
        html += more;
        console.log((pageindex + 7));
        for (index = (pageindex - 7); index <= (pageindex + 7); index++) {
            html += '<li class="' + (pageindex === index ? "active" : "") + '"><a data="' + index + '">' + index + '</a></li>';
        }
        html += more;
        html += '<li><a data="' + pagetotal + '">' + pagetotal + '</a></li>';
    }
    else if (pageindex > (pagetotal - 10)) {
        html += '<li><a data="1">1</a></li>';
        html += more;
        for (index = (pagetotal - 20); index <= pagetotal; index++) {
            html += '<li class="' + (pageindex === index ? "active" : "") + '"><a data="' + index + '">' + index + '</a></li>';
        }
    }
    // console.log("pageindex:" + pageindex);
    // console.log("pagetotal:" + pagetotal);
    if (pageindex < pagetotal) {
        html += '<li><a data="' + (pageindex + 1) + '");">&raquo;</a></li></ul></div>';
    }
    $("#pagination").append(html);

    /** Update Series Num*/
    var list = $("#pagination").find('ul li');
    list.each(function (index) {
        var self = $(this);
        self.on('click', function () {
            var value = self.find('a').attr("data");
            // console.log(value);
            loaddata(value);
        });

    });
}


var ImportFile = function (uploadId, fileID, fileViewId, fileNameID,callback) {
    $("#" + uploadId).upload("api/Upload/Post?" + Math.random(), function (data) {
        console.log(data.Code);
        if (data.Code === 200 && data.Result !== null) {
            console.log(data.Result.filePath);
            console.log(data.Result.fileName);
            if ($("#" + fileID) !== undefined) {
                $("#" + fileID).val(data.Result.filePath);
            }
            if ($("#" + fileViewId) !== undefined) {
                $("#" + fileViewId).attr("src", "/" + data.Result.filePath);

            }
            if ($("#" + fileNameID) !== undefined) {
                $("#" + fileNameID).val(data.Result.fileName);
            }
            if (callback !== undefined) {
                callback(data.Result.filePath, data.Result.fileName, data.Result.fileType);
            }
        } else {
            $.alert(result.Message);
        }
    }, 'json');
    window.setTimeout(function () {

    }, 1);
}