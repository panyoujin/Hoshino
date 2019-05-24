$(function () {
    $("#imgPic1,#imgPic2,#imgPic3").click(function(){
        $("#hiEventShowDialog").click();
        imagePicDocument=$(this);
        // $(".image-crop > img").cropper("getDataURL");

        //  alert($(this).attr("id"));
    });

    $("#download").click(function(){
        var dataURL=$(".image-crop > img").cropper("getDataURL");

        var file= dataURLtoFile(dataURL,"picBase64");
        // console.info(file);
        var formData = new FormData();  
        formData.append("file",file);  

        requestFromUrl("/api/Upload/Post", function (obj) {
            if(obj.Code==200){
                imagePicDocument.attr("src",_Domain+obj.Result.filePath);
                $("#closeDialog").click();
                console.info(obj);
            }
            },formData);


    });
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


