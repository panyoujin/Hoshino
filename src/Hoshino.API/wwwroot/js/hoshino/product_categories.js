
$(function () {
    var e =
        [
            {
                text: "分类 1", href: "#parent1", tags: ["4"], id: 1,
                nodes: [{ text: "二级分类 1", href: "#child1", tags: ["2"] }]
            },
            { text: "分类 2", href: "#parent2", tags: ["0"] },
            { text: "分类 3", href: "#parent3", tags: ["0"] },
            { text: "分类 4", href: "#parent4", tags: ["0"] },
            { text: "分类 5", href: "#parent5", tags: ["0"] }];
    //分类删除按钮
    $("#deleteMenu").click(function () {
        var selectText = $("#product_treeview ul .node-selected").text();
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

    $("#product_treeview").treeview({
        color: "#428bca",
        expandIcon: "glyphicon glyphicon-chevron-right",
        collapseIcon: "glyphicon glyphicon-chevron-down",
        nodeIcon: "glyphicon glyphicon-bookmark",
        data: e
    });

});

