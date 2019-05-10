
$(function () {
    var e =
        [
            {
                text: "分类 1", href: "#parent1", tags: ["4"],
                nodes: [{ text: "二级分类 1", href: "#child1", tags: ["2"] }]    
            },
            { text: "分类 2", href: "#parent2", tags: ["0"] },
            { text: "分类 3", href: "#parent3", tags: ["0"] },
            { text: "分类 4", href: "#parent4", tags: ["0"] },
            { text: "分类 5", href: "#parent5", tags: ["0"] }];

    $("#deleteMenu").click(function () {
        var select = $('#product_treeview').treeview('getSelected');
        console.info(select);
    });

    $("#product_treeview").treeview({ color: "#428bca", expandIcon: "glyphicon glyphicon-chevron-right", collapseIcon: "glyphicon glyphicon-chevron-down", nodeIcon: "glyphicon glyphicon-bookmark", data: e });

});

