var easyui_lang_msg = {};
easyui_lang_msg.beforePageText = '第';
easyui_lang_msg.afterPageText = '共{pages}页';
easyui_lang_msg.displayMsg = '显示{from}到{to},共{total}记录';
easyui_lang_msg.loadMsg = '加载中，请稍等...';
easyui_lang_msg.ok = '确定';
easyui_lang_msg.cancel = '取消';
easyui_lang_msg.missingMessage = '此项不能为空';
easyui_lang_msg.emailMessage = '无效的电子邮件地址';
easyui_lang_msg.urlMessage = '无效的URL地址';
easyui_lang_msg.lengthMessage = '长度必须介于{0}和{1}之间';
easyui_lang_msg.remoteMessage = '请修正该字段';
easyui_lang_msg.weeks = ['日', '一', '二', '三', '四', '五', '六'];
easyui_lang_msg.months = ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'];
easyui_lang_msg.currentText = '今天';
easyui_lang_msg.closeText = '关闭';
easyui_lang_msg.okText = '确定';
$.ajax({
    type: "post",
    url: "/route/admin/SysLanguager/GetByEasyUIAll",
    data: {},
    async: false,
    dataType: 'json',
    success: function (response) {

        $.each(response, function (index, data) {
            if (data.langValue == "" || data.langValue == undefined) {
                return true
            }
            switch(data.controlId){
                case "easyui_all_beforepageText":
                    easyui_lang_msg.beforePageText = data.langValue;
                    break;
                case "easyui_all_afterpageText":
                    easyui_lang_msg.afterPageText = data.langValue;
                    break;
                case "easyui_all_displayMsg":
                    easyui_lang_msg.displayMsg = data.langValue;
                    break;
                case "easyui_all_loadMsg":
                    easyui_lang_msg.loadMsg = data.langValue;
                    break;
                case "easyui_all_ok":
                    easyui_lang_msg.ok = data.langValue;
                    break;
                case "easyui_all_cancel":
                    easyui_lang_msg.cancel = data.langValue;
                    break;
                case "easyui_all_missingMessage":
                    easyui_lang_msg.missingMessage = data.langValue;
                    break;
                case "easyui_all_emailMessage":
                    easyui_lang_msg.emailMessage = data.langValue;
                    break;
                case "easyui_all_urlMessage":
                    easyui_lang_msg.urlMessage = data.langValue;
                    break;
                case "easyui_all_lengthMessage":
                    easyui_lang_msg.lengthMessage = data.langValue;
                    break;
                case "easyui_all_remoteMessage":
                    easyui_lang_msg.remoteMessage = data.langValue;
                    break;
                case "easyui_all_weeks":
                    easyui_lang_msg.weeks = data.langValue.split(',');
                    break;
                case "easyui_all_months":
                    easyui_lang_msg.months = data.langValue.split(',');
                    break;
                case "easyui_all_currentText":
                    easyui_lang_msg.currentText = data.langValue;
                    break;
                case "easyui_all_closeText":
                    easyui_lang_msg.closeText = data.langValue;
                    break;
                case "easyui_all_okText":
                    easyui_lang_msg.okText = data.langValue;
                    break;
            }                
        });
    }
});

if ($.fn.pagination) {
    $.fn.pagination.defaults.beforePageText = easyui_lang_msg.beforePageText;
    $.fn.pagination.defaults.afterPageText = easyui_lang_msg.afterPageText;

    $.fn.pagination.defaults.displayMsg = easyui_lang_msg.displayMsg;
}
if ($.fn.datagrid) {
    $.fn.datagrid.defaults.loadMsg = easyui_lang_msg.loadMsg;
}
if ($.fn.treegrid && $.fn.datagrid) {
    $.fn.treegrid.defaults.loadMsg = $.fn.datagrid.defaults.loadMsg;
}
if ($.messager) {
    $.messager.defaults.ok = easyui_lang_msg.ok;
    $.messager.defaults.cancel = easyui_lang_msg.cancel;
}
if ($.fn.validatebox) {
    $.fn.validatebox.defaults.missingMessage = easyui_lang_msg.missingMessage;
    $.fn.validatebox.defaults.rules.email.message = easyui_lang_msg.emailMessage;
    $.fn.validatebox.defaults.rules.url.message = easyui_lang_msg.urlMessage;
    $.fn.validatebox.defaults.rules.length.message = easyui_lang_msg.lengthMessage;
    $.fn.validatebox.defaults.rules.remote.message = easyui_lang_msg.remoteMessage;
}
if ($.fn.numberbox) {
    $.fn.numberbox.defaults.missingMessage = easyui_lang_msg.missingMessage;
}
if ($.fn.combobox) {
    $.fn.combobox.defaults.missingMessage = easyui_lang_msg.missingMessage;
}
if ($.fn.combotree) {
    $.fn.combotree.defaults.missingMessage = easyui_lang_msg.missingMessage;
}
if ($.fn.combogrid) {
    $.fn.combogrid.defaults.missingMessage = easyui_lang_msg.missingMessage;
}
if ($.fn.calendar) {
    $.fn.calendar.defaults.weeks = easyui_lang_msg.weeks;
    $.fn.calendar.defaults.months = easyui_lang_msg.months;
}
if ($.fn.datebox) {
    $.fn.datebox.defaults.currentText = easyui_lang_msg.currentText;
    $.fn.datebox.defaults.closeText = easyui_lang_msg.closeText;
    $.fn.datebox.defaults.okText = easyui_lang_msg.okText;
    $.fn.datebox.defaults.missingMessage = easyui_lang_msg.missingMessage;
    $.fn.datebox.defaults.formatter = function (date) {
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
    };
    $.fn.datebox.defaults.parser = function (s) {
        if (!s) return new Date();
        var ss = s.split('-');
        var y = parseInt(ss[0], 10);
        var m = parseInt(ss[1], 10);
        var d = parseInt(ss[2], 10);
        if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
            return new Date(y, m - 1, d);
        } else {
            return new Date();
        }
    };
}
if ($.fn.datetimebox && $.fn.datebox) {
    $.extend($.fn.datetimebox.defaults, {
        currentText: $.fn.datebox.defaults.currentText,
        closeText: $.fn.datebox.defaults.closeText,
        okText: $.fn.datebox.defaults.okText,
        missingMessage: $.fn.datebox.defaults.missingMessage
    });
}

