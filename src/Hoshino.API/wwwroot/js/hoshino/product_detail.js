$(function () {
    $("#imgPic1,#imgPic2,#imgPic3").click(function(){
        $("#hiEventShowDialog").click();
        imagePicDocument=$(this);
        // $(".image-crop > img").cropper("getDataURL");

        //  alert($(this).attr("id"));
    });

    $("#download").click(function(){
        var dataURL=$(".image-crop > img").cropper("getDataURL");
        // imagePicDocument.attr("src",url);

        // var req = {ImgBase64:dataURL.substr(dataURL.indexOf(',') + 1)};
        // console.info(req);
        // requestUrl("/api/Upload/PostBase64", function (obj) {
        //     console.info(obj);
        //     if(obj.Code==200){
        //         console.info(obj);
        //     }
        //     }, JSON.stringify(req),'POST');

        // var req = {ImgBase64:dataURL.substr(dataURL.indexOf(',') + 1)};
        var file= dataURLtoFile(dataURL,"picBase64");
        var formData = new FormData(file);
      


        requestFromUrl("/api/Upload/Post", function (obj) {
            console.info(obj);
            if(obj.Code==200){
                console.info(obj);
            }
            },formData);

    });
});


var dataURLtoFile= function (dataurl, filename) {
    var arr = dataurl.split(',');
    var mime = arr[0].match(/:(.*?);/)[1];
    var bstr = atob(arr[1]);
    var n = bstr.length; 
    var u8arr = new Uint8Array(n);
    while(n--){
        u8arr[n] = bstr.charCodeAt(n);
    }
    //转换成file对象
    return new File([u8arr], filename, {type:mime});
    //转换成成blob对象
    //return new Blob([u8arr],{type:mime});
  }


