$(function () {
    //三个图片详情
    $("#imgPic1,#imgPic2,#imgPic3").click(function(){
        $("#hiEventShowDialog").click();
        imagePicDocument=$(this);
    });
    //video编辑
    $("#imgVideo").click(function(){
        $("#imgVideoInput").click();
    });
    //上传video event
    $("#imgVideoInput").change(function (e) {
        // console.info(e.currentTarget.files[0]);
        if(e.currentTarget.files.length<=0){
            return;
        }
        var formData = new FormData();  
        formData.append("file",e.currentTarget.files[0]);  
        requestFromUrl("/api/Upload/Post", function (obj) {
            if(obj.Code==200){
                $("#videoControl").attr("src",_Domain+obj.Result.filePath);
                $("#videoControl").attr("vic",obj.Result.filePath);
            }
            },formData);
        $("#imgVideoInput").clear(); 
    });

    //截图工具的确定 event
    $("#download").click(function(){
        var dataURL=$(".image-crop > img").cropper("getDataURL","image/jpeg");

        var file= dataURLtoFile(dataURL,"picBase64");
        // console.info(file);
        var formData = new FormData();  
        formData.append("file",file);  

        requestFromUrl("/api/Upload/Post", function (obj) {
            if(obj.Code==200){
                imagePicDocument.attr("src",_Domain+obj.Result.filePath);
                imagePicDocument.attr("pic",obj.Result.filePath);
                $("#closeDialog").click();
                console.info(obj);
            }
            },formData);
    });

    //提交表单
    $("#btnSubmit").click(function(){
        if (!$("#signupForm_base").valid()) {
            return;
         }
         $("#signupForm_attribute .attributeItem").each(function(index){
             //简体
            var ch=$(this).children(".form-group").eq(0);
            var ch_key=ch.find("div .form-control").eq(0).val();
            var ch_value=ch.find("div .form-control").eq(1).val();

             
             //繁体
             var hk=$(this).children(".form-group").eq(1);
             var hk_key=hk.find("div .form-control").eq(0).val();
             var hk_value=hk.find("div .form-control").eq(1).val();

             if ($.isEmptyObject(ch_key)||$.isEmptyObject(ch_value)||$.isEmptyObject(hk_key)||$.isEmptyObject(hk_value)) {
                parent.layer.confirm("产品属性不能为空", {
                    btn: ['确定'], //按钮
                    shade: false //不显示遮罩
                });
                return;
            }

         });

    });
    
    //属性删除 event
    $(document).on("click",".btnAttributeDelete",function(){
        $(this).parent().parent().parent().remove();
   })
    //属性删除 event
    // $(".btnAttributeDelete").click(function(){
    //      $(this).parent().parent().parent().remove();
    // });
    $("#btnAddAttribute").click(function(){
        $("#signupForm_attribute").append("<div class='attributeItem'> \
        <div class='form-group'>\
            <div class='col-sm-4'>\
                <input id='txtP_Attribute_Name_CH1' name='txtP_Attribute_Name_CH' class='form-control' type='text' placeholder='属性简体'> \
            </div> \
            <div class='col-sm-6'> \
                <input id='txtP_Attribute_Value_CH1' name='txtP_Attribute_Value_CH'  class='form-control' type='text' placeholder='简体内容'> \
            </div> \
        </div> \
        <div class='form-group'> \
            <div class='col-sm-4'> \
                <input id='txtP_Attribute_Name_HK1' name='txtP_Attribute_Name_HK' class='form-control' type='text' placeholder='属性繁体'> \
            </div> \
            <div class='col-sm-6'> \
                <input id='txtP_Attribute_Value_EN1' name='txtP_Attribute_Value_EN' class='form-control' type='text' placeholder='繁体内容'> \
            </div> \
            <div class='col-sm-2'> \
                <button class='btn btn-warning btnAttributeDelete' type='button' >删除</button> \
            </div>\
        </div>\
    </div>");

    })

});

//图片base64转图片对象
var dataURLtoFile= function (dataurl, filename) {
    var arr = dataurl.split(',');
    var mime = arr[0].match(/:(.*?);/)[1];
    var suffix=mime.split('/')[1];
    var bstr = atob(arr[1]);
    var n = bstr.length; 
    var u8arr = new Uint8Array(n);
    while(n--){
        u8arr[n] = bstr.charCodeAt(n);
    }
    //转换成file对象
    return new File([u8arr], filename+'.'+suffix, {type:mime});
    //转换成成blob对象
    //return new Blob([u8arr],{type:mime});
  }


