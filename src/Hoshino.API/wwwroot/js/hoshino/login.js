$(function () {
    var token = $.cookie('token');

    if (!$.isEmptyObject(token)) {
        window.location.href = "index.html";
        return;
    } 

    $("#form").submit(function(){return false;});

    $("#btnLogin").click(function(){
        var account=$("#txAccount").val();
        var password= $("#txPassword").val();
        if ($.isEmptyObject(account)||$.isEmptyObject(password)) {
            return;
        }
         password = $.md5(password);

        var req = {User_Account: account,Password: password};
        
        requestUrl("/api/sys_user/Login", function (obj) {
            if(obj.Code==200){
                $.cookie('token', obj.Result.token, { expires: 7 });  
                window.location.href = "index.html";
            }   
        }, JSON.stringify(req));

    });
})