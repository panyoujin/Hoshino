$(function () {
    loadProduct();
});

var pageindex = 1;
var pagesize = 10;
var loadProduct=function(){
    var req = {pageindex: pageindex, pagesize: pagesize };

    requestUrl('/api/b_product/GetList', function (obj) {
        if(obj.Code==200){
            $("#tableContent").empty();
            $.each(obj.Result,function(n,item) { 
                n++;
                var contentItem="<tr><td class='project-status'>"+n+"</td><td class='project-title'><a>"+item.Product_Name_CH+
                "</a><br/><small>创建于 "+item.Create_Time+"</small><td class='project-completion'>";
                if(item.Product_Hot==1){//热门
                    contentItem+="<span class='label label-warning'>热门</span>";
                }else{//非热门
                    contentItem+="<span class='label label-default'>热门</span>";
                }

                if(item.Product_New==1){//最新
                    contentItem+="<span class='label label-primary'>最新</span>";
                }else{//非最新
                    contentItem+="<span class='label label-default'>最新</span>";
                }
                contentItem+="</td> <td class='project-people'></td>";
                contentItem+="<td class='project-actions'><a class='btn btn-white btn-sm'><i class='fa fa-folder'></i> 查看 </a>";
                contentItem+="<a class='btn btn-white btn-sm'><i class='fa fa-pencil'></i> 编辑 </a></td></tr>";

                $("#tableContent").append(contentItem);
                pagination(pageindex, pagesize, obj.Total, function (index) {
                    if (pageindex !== index) {
                        pageindex = index;
                        loadProduct();
                    }
                });

            });
            var total= obj.Total;
            
            // console.info(obj);
        }
    }, JSON.stringify(req));

};