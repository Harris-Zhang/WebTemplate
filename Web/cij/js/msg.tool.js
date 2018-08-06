var cMsg = {};
cMsg.alert_f = function (msg) {
    $.messager.alert('系统提示', msg, 'error');
}
cMsg.alert_s = function (msg) {
    $.messager.alert('系统提示', msg, 'info');
}
cMsg.show = function (msg) {
    $.messager.show({ title: '系统提示', msg: msg })
}
cMsg.confirm = function (msg, callBack) {
    $.messager.confirm('系统提示', msg, callBack);
}