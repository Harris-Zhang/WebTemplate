
if (typeof jQuery === 'undefined') {
    console.log('模板需要jQuery');
    throw new Error('模板需要jQuery');
}

$.BZAdmin = {};

$.BZAdmin.options = {

    loadingImg: '../Content/admin/img/',

    //将slimscroll添加到导航栏菜单
    //这需要您加载slimscroll插件
    menuSlimscroll: true,
    //滚动条的宽度
    menuSlimscrollWidth: '3px',
    //菜单的高度
    menuHeight: $(window).height() - $('.main-header').outerHeight() - $('.main-footer').outerHeight(),
    //元素动画时间
    animationSpeed: 100,
    //收缩菜单选择器
    sidebarToggleSelector: '.menu-button.sidebar-toggle',
    //是否激活收缩菜单选择器
    sidebarPushMenu: true,
    //菜单选择器
    sidebarTree:'.sidebar',

    //全屏按钮
    fullScreenSelector: '.fullscreen',

    //标准屏幕大小
    screenSizes: {
        xs: 480,
        sm: 768,
        md: 992,
        lg: 1200
    }
};

$(function () {
    'use strict';

    //$('body').removeClass('hold-transition');

    //访问变量
    var options = $.BZAdmin.options;
    //初始化
    //_init();
    //初始化布局
    $.BZAdmin.layout.activate();
    //树形菜单栏
    $.BZAdmin.tree(options.sidebarTree);
    //全屏和退出全屏按钮
    $.BZAdmin.fullScreen.activate(options.fullScreenSelector)

    //将 slimscroll 添加到导航栏下拉列表
    //if (options.menuSlimscroll && typeof $.fn.slimscroll != 'undefined') {
    //    $('.content-wrapper').slimscroll({
    //        scrollOverflow: true,
    //        height: options.menuHeight, //可滚动区域高度
    //        alwaysVisible: true,        //是否 始终显示组件
    //        size: options.menuSlimscrollWidth  //滚动条宽度，即组件宽度
    //    }).css('width', '100%');
    //}

    //侧边栏
    if (options.sidebarPushMenu) {
        $.BZAdmin.pushMenu.activate(options.sidebarToggleSelector);
    }

    $.BZAdmin.userMenu.showHide('.dropdown.user.user-menu');
    $.BZAdmin.userMenu.showHide('.btn-group.roll-nav.roll-right');

    $(".menuTabs").on("click", ".menu_tab", $.BZAdmin.ContentTabs.activeTab);

});



//function _init() {

//}
'use strict';
$.BZAdmin.layout = {
    activate: function () {
        var _this = this;
        _this.fix();
        _this.fixIframe();
        $(window, '.wrapper').resize(function () {
            _this.fix();
            _this.fixIframe();
        });
    },
    fix: function () {
        //获取头部高度和脚部高度
        var neg = $('.main-header').outerHeight() + $('.main-footer').outerHeight();
        var window_height = $(window).height();
        var sidebar_height = $('.sidebar').height();

        var postSetHeight = window_height >= sidebar_height ? window_height - neg : sidebar_height;
        //设置内容和侧边栏最小高度
        $('.content-wrapper').css({ 'min-height': postSetHeight, 'height': postSetHeight });



    },
    fixIframe: function () {
        //获取头部高度和脚部高度
        var neg = $('.main-header').outerHeight() + $('.main-footer').outerHeight();
        var window_height = $(window).height();
        var sidebar_height = $('.sidebar').height();
        var postSetHeight = window_height >= sidebar_height ? window_height - neg : sidebar_height;
        //设定Iframe宽度
        var contentTabsHeight = $(".content-tabs").outerHeight();
        if ($(window).width() < $.BZAdmin.options.screenSizes.sm)
            contentTabsHeight = 0;
        $(".tab_iframe").css({
            height: postSetHeight - contentTabsHeight,
            width: "100%"
        });
    }
};

$.BZAdmin.pushMenu = {
    activate: function (toggleBtn) {
        var screenSizes = $.BZAdmin.options.screenSizes;
        $(document).on('click', toggleBtn, function (e) {
            //阻止默认事件
            e.preventDefault();

            //启用侧边栏菜单
            if ($(window).width() > (screenSizes.sm - 1)) {
                if ($('body').hasClass('sidebar-collapse')) {
                    $('body').removeClass('sidebar-collapse').trigger('expanded.pushMenu');
                } else {
                    $('body').addClass('sidebar-collapse').trigger('collapsed.pushMenu');
                }
            } else {//处理小屏幕侧边栏菜单
                if ($('body').hasClass('sidebar-open')) {
                    $("body").removeClass('sidebar-open').removeClass('sidebar-collapse').trigger('collapsed.pushMenu');
                } else {
                    $("body").addClass('sidebar-open').trigger('expanded.pushMenu');
                }
            }
        });

    }
};

//显示隐藏 右上角 用户控制
$.BZAdmin.userMenu = {
    showHide: function (toggleBtn) {
        var chil = $(toggleBtn).children('ul');

        $(toggleBtn).click(function (e) {
            if (chil.hasClass('open')) {
                chil.hide();
                chil.removeClass('open');
            } else {
                chil.show();
                chil.addClass('open');
            }
             
            $(document).on('click', function () {
                chil.removeClass('open');
                chil.hide();
            })
            e.stopPropagation();//阻止事件冒泡
        })
        //chil.on('click', function (e) {
        //    e.stopPropagation();//阻止事件冒泡
        //})
    }
}

//菜单点击样式
$.BZAdmin.tree = function (menu) {
    var _this = this;
    var animationSpeed = $.BZAdmin.options.animationSpeed;
    $(document).off('click', menu + ' li a').on('click', menu + ' li a', function (e) {
        //获取点击的连接和下一个节点
        var $this = $(this);
        var checkElement = $this.next();
        //检查下一个元素是菜单&是否可见
        if ((checkElement.is('.treeview-menu')) && (checkElement.is(':visible')) && (!$('body').hasClass('sidebar-collapse'))) {
            checkElement.slideUp(animationSpeed, function () {
                checkElement.removeClass('menu-open');
            });
            checkElement.parent('li').removeClass('active');
        }
        //如果菜单不可见
        else if ((checkElement.is('.treeview-menu')) && (!checkElement.is(':visible'))) {
            //获取父菜单
            var parent = $this.parents('ul').first();
            //关闭父菜单中打开的所有菜单
            var ul = parent.find('ul:visible').slideUp(animationSpeed);
            //移出父菜单 menu-open 类
            ul.removeClass('menu-open');
            //获取父节点li
            var parent_li = $this.parent('li');

            //打开菜单，并添加menu-open 类
            checkElement.slideDown(animationSpeed, function () {
                checkElement.addClass('menu-open');
                parent.find('li.active').removeClass('active');
                parent_li.addClass('active');
                //重新布局，放置超出高度
                _this.layout.fix();
            })

            //阻止默认事件
            if (checkElement.is('.treeview-menu')) {
                e.preventDefault();
            }
        }

    });
};

//全屏和退出全屏事件
$.BZAdmin.fullScreen = {
    activate: function (fullScreenBtn) {
        $(fullScreenBtn).addClass('exist')
        $(document).on('click', fullScreenBtn, function (e) {
            //全屏
            if ($(fullScreenBtn).hasClass('exist')) {
                var element = document.documentElement;
                if (element.requestFullscreen) {
                    element.requestFullscreen();
                } else if (element.msRequestFullscreen) {//IE
                    element.msRequestFullscreen();
                } else if (element.mozRequestFullScreen) {//火狐
                    element.mozRequestFullScreen();
                } else if (element.webkitRequestFullscreen) {//Chrome
                    //element.webkitRequestFullScreen();
                    element.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
                } else {
                    alert("当前浏览器不支持全屏！");
                }
                $(fullScreenBtn).removeClass('exist').addClass('full');
            }
            //退出全屏
            else {
                if (document.exitFullscreen) {
                    document.exitFullscreen();
                } else if (document.msExitFullscreen) {
                    document.msExitFullscreen();
                } else if (document.mozCancelFullScreen) {
                    document.mozCancelFullScreen();
                } else if (document.webkitExitFullscreen) {
                    document.webkitExitFullscreen();
                }
                $(fullScreenBtn).removeClass('full').addClass('exist');
            }
        });
    }
};
//loading提示 需要用到blockUI插件
$.BZAdmin.Loading = {
    //加载loading提示
    blockUI: function (options) {
        if (typeof $.fn.block === 'undefined') {
            console.log("需要blockUI插件");
            return;
        }

        options = $.extend(true, {}, options);
        var html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '">';

        if (options.animate) {
            html += '<div class="block-spinner-bar"><div class="bounce1"></div><div class="bounce2"></div><div class="bounce3"></div></div></div>';
        } else if (options.iconOnly) {
            html += '<img src="' + $.BZAdmin.options.loadingImg + 'loading.gif" align=""></div>';
        } else if (options.textOnly) {
            html += '<span>&nbsp;&nbsp;' + (options.message ? options.message : 'LOADING...') + '</span></div>';
        } else {
            html += '<img src="' + $.BZAdmin.options.loadingImg + 'loading.gif" align=""><span>&nbsp;&nbsp;' + (options.message ? options.message : 'LOADING...') + '</span></div>';
        }

        if (options.target) {
            var el = $(options.target);
            if (el.height() <= $(window).height()) {
                options.cenrerY = true;
            }
             
            el.block({
                message: html,
                baseZ: options.zIndex ? options.zIndex : 1000,
                centerY: options.cenrerY !== undefined ? options.cenrerY : false,
                css: {
                    top: '10%',
                    border: '0',
                    padding: '0',
                    backgroundColor: 'none'
                },
                overlayCSS: {
                    backgroundColor: options.overlayColor ? options.overlayColor : '#555',
                    opacity: options.boxed ? 1 : 0.1,
                    cursor: 'wait'
                }
            });

        }
        else {
            $.blockUI({
                message: html,
                baseZ: options.zIndex ? options.zIndex : 1000,
                css: {
                    border: '0',
                    padding: '0',
                    backgroundColor: 'none'
                },
                overlayCSS: {
                    backgroundColor: options.overlayColor ? options.overlayColor : '#555',
                    opacity: options.boxed ? 1 : 0.1,
                    cursor: 'wait'
                }
            });
        }
    },
    //取消loading提示
    unblockUI: function (target) {
        if (typeof $.fn.unblock === 'undefined') {
            console.log("需要blockUI插件");
            return;
        }
        if (target) {
            $(target).unblock({
                onUnblock: function () {
                    $(target).css('position', '');
                    $(target).css('zoom', '');

                }
            });
        } else {
            $.unblockUI();
        }
    }
};

//tab操作
$.BZAdmin.ContentTabs = {
    //添加tab选项卡
    addTabs: function (options) {
        var url = window.location.protocol + '//' + window.location.host;
        if (options.url.substr(0, 1) !== '/')
            url += '/';
        if (options.url.substr(0, 4) !== 'http')
            options.url = url + options.url; 
        
        //tab标题
        var title = '';
        //内容
        var content = '';
        //如果tab不存在，创建新的tab
        if (!$('#' + options.id)[0]) {
            //创建新tab的title
            title = '<a href="javascript:void(0);" id="tab_' + options.id + '" url-id="' + options.id + '" class="menu_tab">' + options.title;
            //是否允许关闭tab
            if (options.close) {
                title += ' <i class="fa fa-remove page_tab_colse" style="cursor:pointer;" url-id="' + options.id + '" onclick="$.BZAdmin.ContentTabs.closeTab(this)"></i>';
            }
            title += '</a>';

            //页面加载中
            $.BZAdmin.Loading.blockUI({
                target: '#tab-content',
                boxed: true,
                message: '加载中……',
                overlayColor: "#fff"
            });
            //添加Iframe
            content = '<div role="tabpanel" class="tab-pane" id="' + options.id + '">';
            content += '<iframe onload="javascript: $.BZAdmin.Loading.unblockUI(\'#tab-content\');" src="' + options.url + '" width="100%" height="100%" frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="yes"  allowtransparency="yes" id="iframe_' + options.id + '" class="tab_iframe"></iframe>';
            content += '</div>';

            //添加到tab中
            $(".page-tabs-content").append(title);
            $("#tab-content").append(content);
        }

        $(".page-tabs-content > a.active").removeClass("active");
        $("#tab-content > .active").removeClass("active");

        $("#tab_" + options.id).addClass('active');
        //todo
        $.BZAdmin.scrollTab.to($('.menu_tab.active'));
        $("#" + options.id).addClass("active");
        $.BZAdmin.layout.fixIframe();
    },
    //关闭tab
    closeTab: function (element) {
        var id = $(element).attr('url-id');
        //如果关闭的是当前tab，激活他前面一个tab
        if ($('.page-tabs-content > a.active').attr('id') === 'tab_' + id) {
            var prev = $('#tab_' + id).prev();
            var prevIframe = $('#' + id).prev();
            if (prev.length < 1) {//如果前面已经没有tab了，激活后面一个
                prev = $('#tab_' + id).next();
                prevIframe = $('#' + id).next();
            }
            setTimeout(function () { //某种bug，需要延迟执行
                prev.addClass('active');
                prevIframe.addClass('active');
            }, 0);
        }
        ////关闭TAB
        $("#tab_" + id).remove();
        $("#" + id).remove();
    },
    //关闭当前页面
    closeCurrentTab: function () {
        var currentTab = $('.page-tabs-content').find('.active').find('.fa-remove').parents('a');
        if (currentTab) {
            this.closeTab(currentTab);
        }
    },
    //关闭所有tab
    closeOtherTabs: function (isAll) {
        if (isAll) {//所有页面
            $('.page-tabs-content').children("[url-id]").find('.fa-remove').parents('a').each(function () {
                $('#tab_' + $(this).attr('url-id')).remove();
                $('#' + $(this).attr('url-id')).remove();
            });
            var firstChild = $(".page-tabs-content").children(); //选中那些删不掉的第一个菜单
            if (firstChild) {
                $('#tab_' + firstChild.attr('url-id')).addClass('active');
                $('#' + firstChild.attr('url-id')).addClass('active');
                firstChild.addClass('active');
            }
        } else {//保留当前页面
            $('.page-tabs-content').children("[url-id]").find('.fa-remove').parents('a').not(".active").each(function () {
                $('#tab_' + $(this).attr('url-id')).remove();
                $('#' + $(this).attr('url-id')).remove();
            });

        }
    },
    //刷新当前页面
    refreshTab: function () {
        var currentId = $('.page-tabs-content').find('.active').attr('url-id');
        var target = $('#iframe_' + currentId);
        var url = target.attr('src');
        $.BZAdmin.Loading.blockUI({
            target: '#tab-content',
            boxed: true,
            message: '加载中……',
            overlayColor: '#fff'
        });
        target.attr('src', url);
    },

    activeTab: function () {
        var id = $(this).attr('url-id');
        $('.menu_tab').removeClass('active');
        $('#tab-content > .active').removeClass('active');

        $('#tab_' + id).addClass('active');
        $('#' + id).addClass('active');


        $.BZAdmin.layout.fixIframe();
        //$('#iframe_' + id).animate({
        //    height:
        //})

        $.BZAdmin.scrollTab.to(this);
    }
};
//tabs 滚动
$.BZAdmin.scrollTab = {
    //计算宽度
    calSumWidth: function (element) {
        var width = 0;
        $(element).each(function () {
            width += $(this).outerWidth(true);
        });
        return width;
    },
    right: function () {
        var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
        var tabOuterWidth = this.calSumWidth($(".content-tabs").children().not(".menuTabs"));
        var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
        var scrollVal = 0;
        if ($(".page-tabs-content").width() < visibleWidth) {
            return false;
        } else {
            var tabElement = $(".menu_tab:first");
            var offsetVal = 0;
            while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                offsetVal += $(tabElement).outerWidth(true);
                tabElement = $(tabElement).next();
            }
            offsetVal = 0;
            while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                offsetVal += $(tabElement).outerWidth(true);
                tabElement = $(tabElement).next();
            }
            scrollVal = this.calSumWidth($(tabElement).prevAll());
            if (scrollVal > 0) {
                $('.page-tabs-content').animate({
                    marginLeft: 0 - scrollVal + 'px'
                }, "fast");
            }
        }
    },
    to: function (element) {
        var marginLeftVal = this.calSumWidth($(element).prevAll()), marginRightVal = this.calSumWidth($(element).nextAll());
        var tabOuterWidth = this.calSumWidth($(".content-tabs").children().not(".menuTabs"));
        var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
        var scrollVal = 0;
        if ($(".page-tabs-content").outerWidth() < visibleWidth) {
            scrollVal = 0;
        } else if (marginRightVal <= (visibleWidth - $(element).outerWidth(true) - $(element).next().outerWidth(true))) {
            if ((visibleWidth - $(element).next().outerWidth(true)) > marginRightVal) {
                scrollVal = marginLeftVal;
                var tabElement = element;
                while ((scrollVal - $(tabElement).outerWidth()) > ($(".page-tabs-content").outerWidth() - visibleWidth)) {
                    scrollVal -= $(tabElement).prev().outerWidth();
                    tabElement = $(tabElement).prev();
                }
            }
        } else if (marginLeftVal > (visibleWidth - $(element).outerWidth(true) - $(element).prev().outerWidth(true))) {
            scrollVal = marginLeftVal - $(element).prev().outerWidth(true);
        }
        $('.page-tabs-content').animate({
            marginLeft: 0 - scrollVal + 'px'
        }, "fast");
    },
    left: function () {
        var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
        var tabOuterWidth = this.calSumWidth($(".content-tabs").children().not(".menuTabs"));
        var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
        var scrollVal = 0;
        if ($(".page-tabs-content").width() < visibleWidth) {
            return false;
        } else {
            var tabElement = $(".menu_tab:first");
            var offsetVal = 0;
            while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                offsetVal += $(tabElement).outerWidth(true);
                tabElement = $(tabElement).next();
            }
            offsetVal = 0;
            if (this.calSumWidth($(tabElement).prevAll()) > visibleWidth) {
                while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).prev();
                }
                scrollVal = this.calSumWidth($(tabElement).prevAll());
            }
        }
        $('.page-tabs-content').animate({
            marginLeft: 0 - scrollVal + 'px'
        }, "fast");
    }
};

(function ($) {
    $.fn.sidebarMenu = function (options) {
        options = $.extend({}, $.fn.sidebarMenu.defaults, options || {});
        var target = $(this);
        var level = 0;
        if (options.data) {
            init(target, options.data, level);
        } else {
            if (!options.url) return;
            $.getJSON(options.url, options.param, function (data) {
                init(target, data, level);
            });
        }
        function init(target, data, level) {
            $.each(data, function (index, item) {
                //如果是header 添加header中
                var header = $('<li class="header"></li>');
                if (item.isHeader !== null && item.isHeader === true) {
                    header.append(item.text);
                    target.append(header);
                    return;
                }

                var li = $('<li class="treeview" data-level="' + level + '"></li>');
                var a = $('<a role="button"></a>');
                if (level > 0) {
                    a = $('<a role="button" style="padding-left:' + (level * 20 + 13) + 'px"></a>');
                }

                var icon = $('<i></i>');

                icon.addClass(item.icon);
                var isOpen = item.isOpen;
                var text = $('<span class="title"></span>');
                text.addClass('menu-text').text(item.text);
                a.append(icon);
                a.append(text);
                //a.addClass("nav-link");
                if (isOpen === true) {
                    li.addClass("active");
                }

                if (item.children && item.children.length > 0) {
                    var pullSpan = $('<span class="pull-right-container"></span>');
                    var pullIcon = $('<i class="fa fa-angle-left pull-right"></i>');
                    pullSpan.append(pullIcon);
                    a.append(pullSpan);
                    li.append(a);

                    var menus = $('<ul></ul>');
                    menus.addClass('treeview-menu');
                    if (isOpen === true) {
                        menus.css("display", "block");
                        menus.addClass("menu-open");
                    } else {
                        menus.css("display", "none");
                    }

                    init(menus, item.children, level + 1);
                    li.append(menus);
                } else {
                    //打开新的页面
                    if (item.targetType !== null && item.targetType === 'blank') {
                        a.attr('href', item.url);
                        a.attr('target', '_blank');
                    }
                    //tab形式打开页面
                    else if (item.targetType !== null && item.targetType === 'iframe-tab') {
                        var href = '$.BZAdmin.ContentTabs.addTabs({id:\'' + item.id + '\',title:\'' + item.text + '\',close:true,url:\'' + item.url + '\'});';
                        a.attr('onclick', href);
                    }
                    //代表单iframe页面
                    else if (item.targetType !== null && item.targetType === "iframe") {
                        a.attr("href", item.url);
                        a.addClass("iframeOpen");
                        $("#iframe-main").addClass("tab_iframe");
                    } else {
                        a.attr("href", item.url);
                        a.addClass("iframeOpen");
                        $("#iframe-main").addClass("tab_iframe");
                    }

                    //a.addClass('nav-link');
                    var badge = $('<span></span>');

                    if (item.tip !== null && item.tip > 0) {
                        badge.addClass('label').addClass('label-succree').text(item.tip);
                    }
                    a.append(badge);
                    li.append(a);
                }
                target.append(li);
            })
        }
    }
    $.fn.sidebarMenu.defaults = {
        url: null,
        param: null,
        data: null
    };
})(jQuery);



