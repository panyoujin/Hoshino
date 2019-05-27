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


