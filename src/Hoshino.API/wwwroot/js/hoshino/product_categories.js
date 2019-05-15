
$(function () {
    //加载菜单数据
    LoadCategory();
    
    //菜单数据
    // var e =
    //     [
    //         {
    //             text: "分类 1", href: "#parent1", tags: ["4"], id: 1,
    //             nodes: [{ text: "二级分类 1", href: "#child1", tags: ["2"] }]
    //         },
    //         { text: "分类 2", href: "#parent2", tags: ["0"] },
    //         { text: "分类 3", href: "#parent3", tags: ["0"] },
    //         { text: "分类 4", href: "#parent4", tags: ["0"] },
    //         { text: "分类 5", href: "#parent5", tags: ["0"] }
    //     ];

    //分类删除按钮
    $("#deleteMenu").click(function () {
        var selectText = $("#product_treeview ul .node-selected").text();
        var categoryId = $("#product_treeview ul .node-selected").attr('categoryId');
        if ($.isEmptyObject(selectText)) {
            return;
        }
        //console.info(selectText);
        var msg = "你确定要删除[" + selectText + "]该分类吗?";

        parent.layer.confirm(msg, {
            btn: ['确定', '取消'], //按钮
            shade: false //不显示遮罩
        }, function () {
                parent.layer.msg('确定', { icon: 1 });
        }, function () {
                parent.layer.msg('取消', { shift: 6 });
        });

    });

    $("#btnCategoryInsert").click(function(){
        var slCategory= $("#slCategory").val();
        var txcategoryCH= $("#txcategoryCH").val();
        var txcategoryHK= $("#txcategoryHK").val();
        var txcategorySeq= $("#txcategorySeq").val();
        //$("#categoryInsert").css("display", "none");
        $("#btnCategoryClose").click();
        // var req = { Parent_Category_ID: slCategory, Category_Name_CH: txcategoryCH,Category_Name_HK:txcategoryHK,Category_Status:1,Category_Seq:txcategorySeq };
        // requestUrl("/api/b_category/Post", function (obj) {
        //     if(obj.Code==200){
                
        //     }
        // }, JSON.stringify(req));
        });

});


var categoryObj=[];
var categoryFirstClass=[{text:"一级分类",categoryId:0}];

var LoadCategory=function(){
    console.info("获取菜单数据");
    //获取菜单数据

    requestUrl("/api/b_category/GetAllCategory", function (obj) {
         
         if(obj.Code==200 && obj.Result.length>0){
            $.each(obj.Result,function(n,value) { 
                var obj = {text:value.Name,categoryId:value.ID};	
                
                if(value.Child.length>0){
                    var objChild=[];

                    $.each(value.Child,function(n,child) { 
                        var objChildItem = {text:child.Name,categoryId:child.ID};	
                        objChild.push(objChildItem);
                    });
                    obj['nodes']=objChild;
                }
                categoryFirstClass.push(obj);
                categoryObj.push(obj);

            });
            
            $("#product_treeview").treeview({
                color: "#428bca",
                expandIcon: "glyphicon glyphicon-chevron-right",
                collapseIcon: "glyphicon glyphicon-chevron-down",
                nodeIcon: "glyphicon glyphicon-bookmark",
                data: categoryObj
            });

            //弹出框分类
            $.each(categoryFirstClass,function(n,value) { 
              
                $("#slCategory").append("<option value='"+value.categoryId+"'>"+value.text+"</option>");
            })
            
         }
     },'','GET');

}