//更换EasyUI主题
function changeThemeFun(cls) {/* 更换主题 */
    if (cls == null || cls == undefined || cls == "")
        cls = "skin-blue";
    var $easyuiTheme = $('#easyuiTheme');
    var url = $easyuiTheme.attr('href');
    var href = '/Content/easyui/themes/' + cls + '/easyui.css';
    $easyuiTheme.attr('href', href);

    var $iframe = $('iframe');
    if ($iframe.length > 0) {
        for (var i = 0; i < $iframe.length; i++) {
            var ifr = $iframe[i];
            $(ifr).contents().find('#easyuiTheme').attr('href', href);
        }
    }
}; 
changeThemeFun(localStorage.getItem("skin"));
//if ($.cookie('easyuiThemeName')) {
//    changeThemeFun($.cookie('easyuiThemeName'));
//}

////更换多语言
//function changeLanguage(langName) {
//    debugger;
//    var $lang = $("#easyuiLang");
//    var url = $lang.attr("src");
//    var tmpName = "easyui-lang-";
//    switch (langName.toUpperCase()) {
//        case "ZH_CN":
//            tmpName += "zh_CN";
//            break;
//        case "ZH_TW":
//            tmpName += "zh_TW";
//            break;
//        case "EN_US":
//            tmpName += "en";
//            break;
//    }
//    var src = "/Views/js/easyui/locale/" + tmpName + ".js";
//    synchJs("easyuiLang", src);
//    //$lang.attr("src", src);
//    var $iframe = $('iframe');
//    if ($iframe.length > 0) {
//        for (var i = 0; i < $iframe.length; i++) {
//            var ifr = $iframe[i];
//            synchJs("easyuiLang", src);
//            //$(ifr).contents().find('#easyuiLang').attr('src', src);
//            $(ifr).contents().find('#easyuiLang').remove();
//        }
//    }

//    $.cookie('easyuiLangName', langName, {
//        expires: 7, path: '/'
//    });

//}

//if ($.cookie('easyuiLangName')) {
//    changeLanguage($.cookie('easyuiLangName'));
//}
