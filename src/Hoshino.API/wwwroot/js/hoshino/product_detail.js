$(function () {
    //菜单数据
    loadCategory();

    //获取页面传值的id
    var productId = getUrlParam("productId");
    if (!$.isEmptyObject(productId)) {
        //如果该产品不存在数据库，则返回上一级
        loadProductEditData(productId);
    } else {
        loadProductAttributeTemplate();
    }


    //提交产品基本信息 下一步
    $("#btnproduct_base_next").click(function () {
        if (!$("#signupForm_base").valid()) {
            return;
        }
        var productId = $("#productId").val();

        var productReq = {
            Product_Name_CH: $("#txtProduct_Name_CH").val(),
            Product_Name_HK: $("#txtProduct_Name_HK").val(),
            Category_ID: $("#slCategory").val(),
            Product_New: $("#slProduct_New").val(),
            Product_Hot: $("#slProduct_Hot").val(),
            Product_Recommend: $("#slProduct_Recommend").val(),
            Product_Status: $("#slProduct_Status").val(),
            Product_Seq: $("#txtProduct_Seq").val(),
        };

        if ($.isEmptyObject(productId)) {
            //保存产品
            requestUrl("/api/b_product/Post", function (obj) {
                if (obj.Code == 200) {
                    $("#productId").val(parseInt(obj.Result));
                    parent.layer.msg('保存产品信息成功', { icon: 1 });
                    // parent.layer.alert('保存产品信息成功');
                    //跳到下一个页面  图片/视频
                    $("#product_base").css("display", "none");
                    $("#product_resources").css("display", "block");
                }
            }, JSON.stringify(productReq));
        } else {
            productReq.Product_ID = productId;
            requestUrl("/api/b_product/Update", function (obj) {
                if (obj.Code == 200) {
                    parent.layer.msg('修改产品信息成功', { icon: 1 });
                    //跳到下一个页面  图片/视频
                    $("#product_base").css("display", "none");
                    $("#product_resources").css("display", "block");
                }
            }, JSON.stringify(productReq));
        }


    });


    //三个图片详情
    // $("#imgPic1,#imgPic2,#imgPic3").click(function () {
    //     $("#hiEventShowDialog").click();
    //     imagePicDocument = $(this);
    // });
    //三个图片详情
    $(document).on("click", ".imgPic", function () {
        $("#hiEventShowDialog").click();
        imagePicDocument = $(this);
    })

    //video编辑
    $("#imgVideo").click(function () {
        $("#imgVideoInput").click();
    });
    //上传video event
    $("#imgVideoInput").change(function (e) {
        if (e.currentTarget.files.length <= 0) {
            return;
        }
        var formData = new FormData();
        formData.append("file", e.currentTarget.files[0]);
        requestFromUrl("/api/Upload/Post", function (obj) {
            if (obj.Code == 200) {
                $("#videoControl").attr("src", _Domain + obj.Result.filePath);
                $("#videoControl").attr("vic", obj.Result.filePath);
            }
        }, formData);

    });

    //截图工具的确定 event
    $("#download").click(function () {
        var picMode=$("#slPicMode").val();
        var dataURL = $(".image-crop > img").cropper("getDataURL", "image/jpeg");

        var file = dataURLtoFile(dataURL, "picBase64");
        // console.info(file);
        var formData = new FormData();
        formData.append("file", file);

        requestFromUrl("/api/Upload/Post?picMode="+picMode, function (obj) {
            if (obj.Code == 200) {
                imagePicDocument.attr("src", _Domain + obj.Result.filePath);
                imagePicDocument.attr("pic", obj.Result.filePath);
                $("#closeDialog").click();
                console.info(obj);
            }
        }, formData);
    });

    //新增产品图片
    $("#btnImage").click(function () {
        $("#divImageContent").append("<div class='form-group'> \
            <input class='resourcesId' type='text' style='display:none' value='0'>\
            <a href='#' class='col-sm-3'>\
                <img class='imgPic' pic='' style='height: 200px; width: 200px; 'src='./img/default.png' alt='展示图片'>\
            </a>\
            <label class='col-sm-2 control-label'>启用：</label>\
            <div class='col-sm-2'>\
                <select  class='form-control m-b slP_Resources_Status'  name='slP_Resources_Status'>\
                    <option value='1' selected>是</option>\
                    <option value='0'>否</option>\
                </select>\
            </div>\
            <label class='col-sm-2 control-label'>排序：</label>\
            <div class='col-sm-2'>\
                <input name='txtP_Resources_Seq' class='form-control txtP_Resources_Seq' value='0' type='text'>\
            </div>\
        </div>");
    });

    // //提交产品图片 上一步
    // $("#btnproduct_resources_back").click(function () {
    //     $("#product_resources").css("display", "none");
    //     $("#product_base").css("display", "block");
    // });
    //提交产品图片 下一步
    $("#btnproduct_resources_next").click(function () {
        var insertModel = [];
        var updateModel = [];
        var video = { P_Resources_ID: $("#resourcesIdVideo").val(), Product_ID: $("#productId").val(), P_Resources_URL: $("#videoControl").attr("vic"), P_Resources_Type: "video", P_Resources_Status: $("#slP_Resources_StatusVideo").val(), P_Resources_Seq: $("#txtP_Resources_SeqVideo").val(), P_Resources_Name_CH: "默认名称", P_Resources_Name_HK: "默认名称" };
        if (video.P_Resources_ID > 0) {
            updateModel.push(video);
        } else if (!$.isEmptyObject(video.P_Resources_URL)) {
            insertModel.push(video);
        }
        $("#divImageContent .form-group").each(function (index) {
            var imageObj = { P_Resources_ID: $(this).find(".resourcesId").val(), Product_ID: $("#productId").val(),
             P_Resources_URL: $(this).find("a .imgPic").attr("pic"), P_Resources_Type: "image",
              P_Resources_Status: $(this).find("div .slP_Resources_Status").val(), P_Resources_Seq: $(this).find("div .txtP_Resources_Seq").val(), 
              P_Resources_Name_CH: "默认名称", P_Resources_Name_HK: "默认名称" };

              if (imageObj.P_Resources_ID > 0) {
                updateModel.push(imageObj);
            } else if (!$.isEmptyObject(imageObj.P_Resources_URL)) {
                insertModel.push(imageObj);
            }

        });

        if (insertModel.length > 0) {
            requestUrl("/api/b_product_resources/Post", function (obj) {
                console.info(obj);
                if (obj.Code == 200) {
                    parent.layer.msg('保存图片/视频 成功', { icon: 1 });
                } else {
                    parent.layer.msg('保存图片/视频 失败', { icon: 1 });
                    return;
                }
            }, JSON.stringify(insertModel));
        }

        if (updateModel.length > 0) {
            requestUrl("/api/b_product_resources/Update", function (obj) {
                if (obj.Code == 200) {
                    parent.layer.msg('保存图片/视频 成功', { icon: 1 });
                } else {
                    parent.layer.msg('保存图片/视频 失败', { icon: 1 });
                    return;
                }
            }, JSON.stringify(updateModel));
        }

        $("#product_resources").css("display", "none");
        $("#product_attributes").css("display", "block");
    });

    // //提交产品图片 上一步
    // $("#btnproduct_attributes_back").click(function () {
    //     $("#product_attributes").css("display", "none");
    //     $("#product_resources").css("display", "block");
    // });
    //提交产品属性 完成
    $("#btnproduct_attributes_next").click(function () {
        var product_attributes = [];
        $("#signupForm_attribute .attributeItem").each(function (index) {

            //简体
            var ch = $(this).children(".form-group").eq(0);
            var ch_key = ch.find("div .form-control").eq(0).val();
            var ch_value = ch.find("div .form-control").eq(1).val();


            //繁体
            var hk = $(this).children(".form-group").eq(1);
            var hk_key = hk.find("div .form-control").eq(0).val();
            var hk_value = hk.find("div .form-control").eq(1).val();

            //启用  排序
            var third = $(this).children(".form-group").eq(2);
            var Attribute_Status = third.find("div select").val();
            var Attribute_Seq = third.find("div .form-control").val();

            if ($.isEmptyObject(ch_key) || $.isEmptyObject(ch_value) || $.isEmptyObject(hk_key) || $.isEmptyObject(hk_value) || $.isEmptyObject(Attribute_Seq)) {
                parent.layer.msg('产品属性/排序不能为空', { icon: 1 });
                return;
            }
            var attribute = {
                Product_ID: $("#productId").val(), P_Attribute_Name_CH: ch_key, P_Attribute_Name_HK: hk_key,
                P_Attribute_Value_CH: ch_value, P_Attribute_Value_HK: hk_value, P_Attribute_Status: Attribute_Status, P_Attribute_Seq: Attribute_Seq
            };
            product_attributes.push(attribute);
        });

        // console.info(JSON.stringify(product_attributes));
        if (product_attributes.length > 0) {
            requestUrl("/api/b_product_attribute/Post", function (obj) {
                console.info(obj);
                if (obj.Code == 200) {
                    parent.layer.msg('保存成功', { icon: 1 });
                    // window.location.href = "product_manage.html";
                    $("#product_attributes").css("display", "none");
                    $("#product_rel").css("display", "block");
                } else {
                    parent.layer.msg('保存失败', { icon: 1 });
                    return;
                }
            }, JSON.stringify(product_attributes));
        }

    });

    //属性删除 event
    $(document).on("click", ".btnAttributeDelete", function () {
        $(this).parent().parent().parent().remove();
    })
    //属性删除 event
    // $(".btnAttributeDelete").click(function(){
    //      $(this).parent().parent().parent().remove();
    // });

    //属性新增 event
    $("#btnAddAttribute").click(function () {
        $("#signupForm_attribute").append("<div class='attributeItem'>\
        <div class='form-group'>\
            <div class='col-sm-4'>\
                <input  name='txtP_Attribute_Name_CH' class='form-control' type='text' placeholder='属性简体'>\
            </div>\
            <div class='col-sm-6'>\
                <input  name='txtP_Attribute_Value_CH' class='form-control' type='text' placeholder='简体内容'>\
            </div>\
        </div>\
        <div class='form-group'>\
            <div class='col-sm-4'>\
                <input  name='txtP_Attribute_Name_HK' class='form-control' type='text' placeholder='属性繁体'>\
            </div>\
            <div class='col-sm-6'>\
                <input  name='txtP_Attribute_Value_EN'class='form-control' type='text' placeholder='繁体内容'>\
            </div>\
        </div>\
        <div class='form-group'>\
            <label class='col-sm-2 control-label'>启用：</label>\
            <div class='col-sm-2'>\
                <select  class='form-control m-b'>\
                    <option value='1' selected>是</option>\
                    <option value='0'>否</option>\
                </select>\
            </div>\
            <label class='col-sm-2 control-label'>排序：</label>\
            <div class='col-sm-4'>\
                <input name='txtP_Resources_Seq' class='form-control' value='0' type='text'>\
            </div>\
            <div class='col-sm-2'>\
                <button class='btn btn-warning btnAttributeDelete' type='button'>删除</button>\
            </div>\
        </div>\
    </div>");
    })


    $("#btnSearchProcudt").click(function () {
        $("#txtSearch").val($.cookie('productName'));
        $("#productRefId").val($.cookie('productId'));
    });

    $("#btnProductRefSave").click(function () {
        if ($.isEmptyObject($("#productRefId").val())) {
            parent.layer.msg('请先选择关联产品', { icon: 1 });
            return;
        }
        var req = [{ P_Relevant_Status: 1, Source_Product_ID: $("#productId").val(), Rel_Product_ID: $("#productRefId").val(), P_Relevant_Seq: $("#productRefSort").val() }];
        requestUrl("/api/b_rel_product/Post", function (obj) {
            console.info(obj);
            if (obj.Code == 200) {
                parent.layer.msg('保存关联产品成功', { icon: 1 });
                loadProductEditData($("#productId").val());
                $("#btnProductRefClose").click();
            } else {
                parent.layer.msg('保存关联产品失败', { icon: 1 });
                return;
            }
        }, JSON.stringify(req));

    });
    $("#btnProductRef").click(function () {
        window.location.href = "product_manage.html";
    });
    //关联产品删除 event
    $(document).on("click", ".refProductDelete", function () {
        var Source_Product_ID = $("#productId").val();
        var Rel_Product_ID = $(this).attr("refId");
        var req = { Source_Product_ID: Source_Product_ID, Rel_Product_ID: Rel_Product_ID };
        requestUrl("/api/b_rel_product/Delete", function (obj) {
            console.info(obj);
            if (obj.Code == 200) {
                parent.layer.msg('删除关联产品成功', { icon: 1 });
                loadProductEditData($("#productId").val());
            } else {
                parent.layer.msg('保删除关联产品失败', { icon: 1 });
            }
        }, JSON.stringify(req));
    })

});

//图片base64转图片对象
var dataURLtoFile = function (dataurl, filename) {
    var arr = dataurl.split(',');
    var mime = arr[0].match(/:(.*?);/)[1];
    var suffix = mime.split('/')[1];
    var bstr = atob(arr[1]);
    var n = bstr.length;
    var u8arr = new Uint8Array(n);
    while (n--) {
        u8arr[n] = bstr.charCodeAt(n);
    }
    //转换成file对象
    return new File([u8arr], filename + '.' + suffix, { type: mime });
    //转换成成blob对象
    //return new Blob([u8arr],{type:mime});
}

//加载菜单数据
var loadCategory = function () {
    requestUrl("/api/b_category/GetBackAllCategory", function (obj) {
        if (obj.Code == 200 && obj.Result.length > 0) {
            $("#slCategory").empty();
            $.each(obj.Result, function (n, firstItem) {
                $("#slCategory").append("<option value='" + firstItem.ID + "'>" + firstItem.Name + "</option>");
                if (firstItem.Child.length > 0) {
                    $.each(firstItem.Child, function (m, secondItem) {
                        $("#slCategory").append("<option value='" + secondItem.ID + "'>&nbsp;&nbsp;&nbsp;&nbsp;" + secondItem.Name + "</option>");
                    });
                }

            });
        }
    }, '', 'GET');
}

//编辑产品信息
var loadProductEditData = function (productId) {
    requestUrl("/api/b_product/GetBack?Product_ID=" + productId, function (obj) {
        // console.info(obj);
        if (obj.Code == 200) {
            $("#productId").val(parseInt(obj.Result.Product_ID));
            $("#txtProduct_Name_CH").val(obj.Result.Product_Name_CH);
            $("#txtProduct_Name_HK").val(obj.Result.Product_Name_HK);
            $("#slCategory").val(obj.Result.Category_ID);
            $("#slProduct_New").val(obj.Result.Product_New);
            $("#slProduct_Hot").val(obj.Result.Product_Hot);
            $("#slProduct_Recommend").val(obj.Result.Product_Recommend);
            $("#slProduct_Status").val(obj.Result.Product_Status);
            $("#txtProduct_Seq").val(obj.Result.Product_Seq);

            if (obj.Result.product_resourcesList.length > 0) {
                var picIndex = 1;
                $("#divImageContent").empty();
                $.each(obj.Result.product_resourcesList, function (n, item) {
                    if (item.P_Resources_Type == "image") {
                        // $("#resourcesId" + picIndex).val(item.P_Resources_ID);
                        // $("#imgPic" + picIndex).attr("pic", item.P_Resources_URL);
                        // $("#imgPic" + picIndex).attr("src", _Domain + item.P_Resources_URL);
                        // $("#slP_Resources_Status" + picIndex).val(item.P_Resources_Status);
                        // $("#txtP_Resources_Seq" + picIndex).val(item.P_Resources_Seq);
                        var imgStatusStr = "";
                        if (item.P_Resources_Status == 1) {
                            imgStatusStr = "<option value='1' selected>是</option><option value='0'>否</option>";
                        } else {
                            imgStatusStr = "<option value='1'>是</option><option value='0' selected>否</option>";
                        }
    
                        $("#divImageContent").append("<div class='form-group'> \
                        <input class='resourcesId' type='text' style='display:none' value='"+item.P_Resources_ID+"'>\
                        <a href='#' class='col-sm-3'>\
                            <img class='imgPic' pic='"+item.P_Resources_URL+"' style='height: 200px; width: 200px;' src='"+_Domain+item.P_Resources_URL+"' alt='展示图片'>\
                        </a>\
                        <label class='col-sm-2 control-label'>启用：</label>\
                        <div class='col-sm-2'>\
                            <select class='form-control m-b slP_Resources_Status' name='slP_Resources_Status'>"+imgStatusStr+"</select>\
                        </div>\
                        <label class='col-sm-2 control-label'>排序：</label>\
                        <div class='col-sm-2'>\
                            <input name='txtP_Resources_Seq' class='form-control txtP_Resources_Seq' value='"+item.P_Resources_Seq+"' type='text'>\
                        </div>\
                        </div>");

                        picIndex++;
                    } else if (item.P_Resources_Type == "video") {
                        $("#resourcesIdVideo").val(item.P_Resources_ID);
                        $("#videoControl").attr("vic", item.P_Resources_URL);
                        $("#videoControl").attr("src", _Domain + item.P_Resources_URL);
                        $("#slP_Resources_StatusVideo").val(item.P_Resources_Status);
                        $("#txtP_Resources_SeqVideo").val(item.P_Resources_Seq);
                    }
                });
            }

            if (obj.Result.product_attributeList.length > 0) {
                $("#signupForm_attribute").empty();
                $.each(obj.Result.product_attributeList, function (n, item) {
                    var attributeStatusStr = "";
                    if (item.P_Attribute_Status == 1) {
                        attributeStatusStr = "<option value='1' selected>是</option><option value='0'>否</option>";
                    } else {
                        attributeStatusStr = "<option value='1'>是</option><option value='0' selected>否</option>";
                    }

                    $("#signupForm_attribute").append("<div class='attributeItem'>\
                    <div class='form-group'>\
                        <div class='col-sm-4'>\
                            <input  name='txtP_Attribute_Name_CH' value='"+ item.P_Attribute_Name_CH + "' class='form-control' type='text' placeholder='属性简体'>\
                        </div>\
                        <div class='col-sm-6'>\
                            <input  name='txtP_Attribute_Value_CH' value='"+ item.P_Attribute_Value_CH + "' class='form-control' type='text' placeholder='简体内容'>\
                        </div>\
                    </div>\
                    <div class='form-group'>\
                        <div class='col-sm-4'>\
                            <input  name='txtP_Attribute_Name_HK' value='"+ item.P_Attribute_Name_HK + "' class='form-control' type='text' placeholder='属性繁体'>\
                        </div>\
                        <div class='col-sm-6'>\
                            <input  name='txtP_Attribute_Value_EN'class='form-control' value='"+ item.P_Attribute_Value_HK + "' type='text' placeholder='繁体内容'>\
                        </div>\
                    </div>\
                    <div class='form-group'>\
                        <label class='col-sm-2 control-label'>启用：</label>\
                        <div class='col-sm-2'>\
                            <select  class='form-control m-b'> \
                            "+ attributeStatusStr + " </select>\
                        </div>\
                        <label class='col-sm-2 control-label'>排序：</label>\
                        <div class='col-sm-4'>\
                            <input name='txtP_Resources_Seq' value='"+ item.P_Attribute_Seq + "' class='form-control' value='0' type='text'>\
                        </div>\
                        <div class='col-sm-2'>\
                            <button class='btn btn-warning btnAttributeDelete' type='button'>删除</button>\
                        </div>\
                    </div>\
                </div>");
                });
            } else {
                loadProductAttributeTemplate();
            }

            if (obj.Result.rel_productList.length > 0) {
                $("#tableContent").empty();
                console.info(obj.Result.rel_productList);
                $.each(obj.Result.rel_productList, function (n, item) {
                    n++;
                    $("#tableContent").append("  <tr> \
                        <td class='project-status'>"+ n + "</td>\
                        <td class='project-title'>"+ item.Product_Name_CH + "</td>\
                        <td class='project-completion'>排序： <span class='label label-warning'>"+ item.Product_Seq + "</span>\
                        </td>\
                        <td class='project-actions'>\
                            <a href='#' class='btn btn-white btn-sm refProductDelete' refId='"+ item.Product_ID + "'><i class='fa fa-trash-o fa-fw'></i> 删除</a>\
                        </td>\
                        </tr>");
                })
            }
        } else {
            history.back(-1);
        }
    }, '', 'GET');

};

//编辑产品信息
var loadProductAttributeTemplate = function () {
    requestUrl("/api/b_product_attribute_template/GetList", function (obj) {
        console.info(obj);
        if (obj.Code === 200) {
            if (obj.Result.length > 0) {
                $("#signupForm_attribute").empty();
                $.each(obj.Result, function (n, item) {
                    var attributeStatusStr = "<option value='1' selected>是</option><option value='0'>否</option>";

                    $("#signupForm_attribute").append("<div class='attributeItem'>\
                    <div class='form-group'>\
                        <div class='col-sm-4'>\
                            <input  name='txtP_Attribute_Name_CH' value='"+ item.P_Attribute_Name_CH + "' class='form-control' type='text' placeholder='属性简体'>\
                        </div>\
                        <div class='col-sm-6'>\
                            <input  name='txtP_Attribute_Value_CH' value='' class='form-control' type='text' placeholder='简体内容'>\
                        </div>\
                    </div>\
                    <div class='form-group'>\
                        <div class='col-sm-4'>\
                            <input  name='txtP_Attribute_Name_HK' value='"+ item.P_Attribute_Name_HK + "' class='form-control' type='text' placeholder='属性繁体'>\
                        </div>\
                        <div class='col-sm-6'>\
                            <input  name='txtP_Attribute_Value_EN'class='form-control' value='' type='text' placeholder='繁体内容'>\
                        </div>\
                    </div>\
                    <div class='form-group'>\
                        <label class='col-sm-2 control-label'>启用：</label>\
                        <div class='col-sm-2'>\
                            <select  class='form-control m-b'> \
                            "+ attributeStatusStr + " </select>\
                        </div>\
                        <label class='col-sm-2 control-label'>排序：</label>\
                        <div class='col-sm-4'>\
                            <input name='txtP_Resources_Seq' value='"+ item.P_Attribute_Seq + "' class='form-control' value='0' type='text'>\
                        </div>\
                        <div class='col-sm-2'>\
                            <button class='btn btn-warning btnAttributeDelete' type='button'>删除</button>\
                        </div>\
                    </div>\
                </div>");
                });
            }

        } else {
            console.log("template 3");
        }
    }, '', 'GET');

};


function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}
