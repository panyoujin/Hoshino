$(function () {
    //加载产品
    loadProduct();
    //加载菜单
    loadCategory();

    //产品编辑按钮
    $(document).on("click", ".productEdit", function () {
        window.location.href = "product_detail.html?productId=" + $(this).parent().attr("productId");
        // alert($(this).parent().attr("productId"));
    })

    //产品table item 选择事件
    $(document).on("click", ".productItem", function () {
        $(".productItem").css("background","");
        $(this).css("background","#CAE1FF");
        var productName= $(this).attr("productName");
        var productId= $(this).attr("productId");
        $.cookie('productName', productName);
        $.cookie('productId', productId);
    })
    

    //产品编辑删除
    $(document).on("click", ".productDelete", function () {
        var productId = $(this).parent().attr("productId");
        parent.layer.confirm("确定要删除该产品吗？", {
            btn: ['确定', '取消'], //按钮
            shade: false //不显示遮罩
        }, function () {//确定
            var req = { Product_ID: productId };
            requestUrl("/api/b_product/Delete", function (obj) {
                if (obj.Code == 200 && obj.Result == true) {
                    $("#btnSearch").click();
                    parent.layer.confirm("删除成功", {
                        btn: ['确定'], //按钮
                        shade: false //不显示遮罩
                    });
                }
            }, JSON.stringify(req));

        }, function () {//取消
        });
    })

    $("#btnSearch").click(function () {
        loadProduct($("#slCategory").val(), $("#txtSearch").val(), $("#slProduct_New").val(), $("#slProduct_Hot").val(), $("#slProduct_Recommend").val(), $("#slProduct_Status").val());
    });


});

var pageindex = 0;
var pagesize = 10;
var loadProduct = function (categoryId = -1, productName = '', productNew = -1, productHot = -1, productRecommend = -1, productStatus = -1) {
    var req = {};
    if (!$.isEmptyObject(categoryId)) {
        req.Category_ID = categoryId;
    }
    if (!$.isEmptyObject(productName)) {
        req.Product_Name_CH = productName;
    }
    if (!$.isEmptyObject(productNew)) {
        req.Product_New = productNew;
    }
    if (!$.isEmptyObject(productHot)) {
        req.Product_Hot = productHot;
    }
    if (!$.isEmptyObject(productRecommend)) {
        req.Product_Recommend = productRecommend;
    }
    if (!$.isEmptyObject(productStatus)) {
        req.Product_Status = productStatus;
    }

    var queryStr = "pageindex=" + pageindex + "&pagesize=" + pagesize;
    requestUrl('/api/b_product/GetList?' + queryStr, function (obj) {
        if (obj.Code == 200) {
            $("#tableContent").empty();
            $.each(obj.Result, function (n, item) {
                n++;
                var contentItem = "<tr class='productItem' productName='"+item.Product_Name_CH+"' productId='"+item.Product_ID +"'><td class='project-status'>" + n + "</td><td class='project-title'><a>" + item.Product_Name_CH +
                    "</a><br/><small>创建于 " + item.Create_Time + "</small></td>";

                contentItem += "<td class='project-title'><a>" + item.Product_Name_HK + "</a></td> <td class='project-completion'>";

                if (item.Product_Status == 1) {//有效
                    contentItem += "<span class='label label-warning'>启用</span>";
                } else {//无效
                    contentItem += "<span class='label label-default'>不启用</span>";
                }

                if (item.Product_Hot == 1) {//热门
                    contentItem += "<span class='label label-warning'>热门</span>";
                } else {//非热门
                    contentItem += "<span class='label label-default'>热门</span>";
                }

                if (item.Product_New == 1) {//最新
                    contentItem += "<span class='label label-primary'>最新</span>";
                } else {//非最新
                    contentItem += "<span class='label label-default'>最新</span>";
                }
                if (item.Product_Recommend == 1) {//推荐
                    contentItem += "<span class='label label-primary'>推荐</span>";
                } else {//非推荐
                    contentItem += "<span class='label label-default'>推荐</span>";
                }
                contentItem += "</td> </tr>";


                $("#tableContent").append(contentItem);
                pagination(pageindex, pagesize, obj.Total, function (index) {
                    if (pageindex !== index) {
                        pageindex = index;
                        loadProduct();
                    }
                });

            });
            var total = obj.Total;

        }
    }, JSON.stringify(req));

};


//加载菜单数据
var loadCategory = function () {
    requestUrl("/api/b_category/GetAllCategory", function (obj) {
        if (obj.Code == 200 && obj.Result.length > 0) {
            $("#slCategory").empty();
            $("#slCategory").append("<option value='' selected>请选择分类</option>");
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