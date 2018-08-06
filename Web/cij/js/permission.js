$(function () {
    
    var pageAllBtn = $('a');//获取页面所有 A 标签(easyui-linkbutton)
    var btnPerm = new Array();//需要权限的按钮的数组

    //遍历所有 a标签
    $.each(pageAllBtn, function (index, data) {
        //如果是权限按钮  添加到数组里 ，并隐藏按钮
        if (($(data).attr("perm") == "true" || $(data).attr("perm") == true) &&
            ($(data).attr('keycode') != undefined && $(data).attr('keycode') != "")) {
            $(data).linkbutton('disable', true);
            $(data).hide();
            btnPerm.push(data);
        }
    });

    //获取当前用户 当前页面 的按钮权限
    $.post('/route/admin/SysRight/GetPermission', {}, function (response) {
        $.each(response, function (index, data) {
            $.each(btnPerm, function (btn_index, btn_data) {
                //如果相等 显示
                if (data.KEYCODE.toUpperCase() == $(btn_data).attr('keycode').toUpperCase()) {
                    $(btn_data).show();
                    $(btn_data).linkbutton('enable');
                }
            })
        })
    }, 'json');
     
});