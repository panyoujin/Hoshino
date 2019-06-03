$(function () {

    $("#btnSave").click(function(){
        if ($.isEmptyObject(txtPassword)||$.isEmptyObject(txtPasswordAgain)) {
            return;
        }
        var password=$("#txtPassword").val();
        var passwordAgain=$("#txtPasswordAgain").val();
        if(password!=passwordAgain){
            parent.layer.msg('密码不一致', { icon: 1 });
            return;
        }

        var req = {Password: $.md5(password)};
        requestUrl("/api/sys_user/UpdateUserPassword", function (obj) {
            if(obj.Code==200){
                parent.layer.confirm("修改密码成功", {
                    btn: ['确定'], //按钮
                    shade: false //不显示遮罩
                },function(){
                    $.cookie('Authorization', '');
                    window.location.href = "login.html";
                });

            }else{
                parent.layer.msg('修改密码失败', { icon: 1 });
            }
        }, JSON.stringify(req));
    });


})