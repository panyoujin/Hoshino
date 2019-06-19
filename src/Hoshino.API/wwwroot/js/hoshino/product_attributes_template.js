$(function () {
    console.log("template 1");
    loadProductAttributeTemplate(productId);

    console.log("template 2");
    //提交产品属性 完成
    $("#btnproduct_attributes_next").click(function () {
        var product_attributes = [];
        $("#signupForm_attribute .attributeItem").each(function (index) {

            //简体
            var ch = $(this).children(".form-group").eq(0);
            var ch_key = ch.find("div .form-control").eq(0).val();


            //繁体
            var hk = $(this).children(".form-group").eq(1);
            var hk_key = hk.find("div .form-control").eq(0).val();

            //启用  排序
            var third = $(this).children(".form-group").eq(2);
            var Attribute_Seq = third.find("div .form-control").val();

            if ($.isEmptyObject(ch_key)  || $.isEmptyObject(hk_key)  || $.isEmptyObject(Attribute_Seq)) {
                parent.layer.msg('产品属性/排序不能为空', { icon: 1 });
                return;
            }
            var attribute = {P_Attribute_Name_CH: ch_key, P_Attribute_Name_HK: hk_key, P_Attribute_Seq: Attribute_Seq
            };
            product_attributes.push(attribute);
        });

        // console.info(JSON.stringify(product_attributes));
        if (product_attributes.length > 0) {
            requestUrl("/api/b_product_attribute_template/Post", function (obj) {
                console.info(obj);
                if (obj.Code === 200) {
                    parent.layer.msg('保存成功', { icon: 1 });
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
    });
    //属性删除 event
    // $(".btnAttributeDelete").click(function(){
    //      $(this).parent().parent().parent().remove();
    // });

    //属性新增 event
    $("#btnAddAttribute").click(function () {
        $("#signupForm_attribute").append("<div class='attributeItem'>\
         <div class='form-group'>\
                        <label class='col-sm-2 control-label'>属性简体：</label>\
            <div class='col-sm-4'>\
                <input  name='txtP_Attribute_Name_CH' class='form-control' type='text' placeholder='属性简体'>\
            </div>\
        </div>\
        <div class='form-group'>\
                        <label class='col-sm-2 control-label'>属性繁体：</label>\
            <div class='col-sm-4'>\
                <input  name='txtP_Attribute_Name_HK' class='form-control' type='text' placeholder='属性繁体'>\
            </div>\
        </div>\
        <div class='form-group'>\
            <label class='col-sm-2 control-label'>排序：</label>\
            <div class='col-sm-4'>\
                <input name='txtP_Resources_Seq' class='form-control' value='0' type='text'>\
            </div>\
            <div class='col-sm-2'>\
                <button class='btn btn-warning btnAttributeDelete' type='button'>删除</button>\
            </div>\
        </div>\
    </div>");
    });



});



//编辑产品信息
var loadProductAttributeTemplate = function (productId) {
    requestUrl("/api/b_product_attribute_template/GetList", function (obj) {
        console.info(obj);
        if (obj.Code === 200) {
            if (obj.Result.length > 0) {
                $("#signupForm_attribute").empty();
                $.each(obj.Result, function (n, item) {
                    $("#signupForm_attribute").append("<div class='attributeItem'>\
                    <div class='form-group'>\
                        <label class='col-sm-2 control-label'>属性简体：</label>\
                        <div class='col-sm-4'>\
                            <input  name='txtP_Attribute_Name_CH' value='"+ item.P_Attribute_Name_CH + "' class='form-control' type='text' placeholder='属性简体'>\
                        </div>\
                    </div>\
                    <div class='form-group'>\
                        <label class='col-sm-2 control-label'>属性繁体：</label>\
                        <div class='col-sm-4'>\
                            <input  name='txtP_Attribute_Name_HK' value='"+ item.P_Attribute_Name_HK + "' class='form-control' type='text' placeholder='属性繁体'>\
                        </div>\
                    </div>\
                    <div class='form-group'>\
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
