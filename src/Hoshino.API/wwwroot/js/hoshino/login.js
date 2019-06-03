$(function () {
    var token = $.cookie('Authorization');

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
                $.cookie('Authorization', obj.Result.token, { expires: 7 });  
                window.location.href = "login.html";
            }
            parent.layer.msg(obj.Message, { icon: 1 });

        }, JSON.stringify(req));

    });
})