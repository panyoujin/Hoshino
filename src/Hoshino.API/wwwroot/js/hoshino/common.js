$(function () {
    // var req = { User_Account: "admin", Password: "202cb962ac59075b964b07152d234b70" };
    var req = { User_Account: "admin", Password: "202cb962ac59075b964b07152d234b70" };
    requestUrl("/api/sys_user/Login", function (obj) {
        console.info(obj);
    }, JSON.stringify(req));
});

//var domain = "http://www.hosinowt.com";
var domain = "http://localhost:60737";
var requestUrl = function (url, callBack, json, type = 'POST') {
    var urlFull = domain + url;
    $.ajax({
        type: type,
        url: urlFull,
        dataType: "json",
        contentType : 'application/json;charset=UTF-8',
        data: json,
        success: callBack,
        error:function(obj){
            console.info(obj);
        }
        
    });
};