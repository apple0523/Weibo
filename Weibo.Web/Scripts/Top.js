/// <reference path="Common/jquery-1.4.4-vsdoc.js" />
document.write('<style type="text/css">@media screen and (-webkit-min-device-pixel-ratio:0){.tsina_gnb{top:8px;}.tsina_gnb ul li.on a{margin-bottom:-1px; padding:2px 5px 10px 7px;}.tsina_gnb ul.sltmenu{top:26px;}.tsina_gnb ul.sltmenu li a{margin:0 2px; padding:4px 13px 3px;}.tsina_gnb ul li em.nmTxt,.tsina_gnb ul li a{font-family:inherit;}}.top_yellowtip{position:fixed;top:30px;_position:relative;_top:0px;width:100%;z-index:2000;}.re_top{top:0px;}</style><div class="tsina_gnbarea" id="topBar"><div class="bg_gnbarea">&nbsp;</div><div  class="tsina_gnb"><ul class="gnb_l"></ul><ul class="gnb_r"></ul></div></div><div class="top_yellowtip" id="yellowtip"><div class="small_Yellow_div tsina_gnb re_top"><div id="unreadLayer" class="small_Yellow" style="display:none"><table class="CP_w"><thead><tr><th class="tLeft"><span></span></th><th class="tMid"><span></span></th><th class="tRight"><span></span></th></tr></thead><tbody><tr><td class="tLeft"><span></span></td><td class="tMid"><div class="yInfo"><p id="unreadCommentCount" style="display: none;"></p><p id="unreadFollowCount" style="display: none;"></p><p id="unreadMsgCount" style="display: none;"></p><p id="unreadAtmeCount" style="display: none;"></p><p id="unreadAtcmtCount" style="display: none;"></p><p id="unreadNoticeCount" style="display: none;"></p><div></div></div></td><td class="tRight"><span></span></td></tr></tbody><tfoot><tr><td class="tLeft"><span></span></td><td class="tMid"></td><td class="tRight"><span></span></td></tr></tfoot></table><div class="close"><a id="WB_unread_layer_close_1316403245132" href="javascript:void(0)">&nbsp;</a></div></div></div></div>');
$(function () {
    $.ajax({
        url: "/Ajax/JudgeLogin",
        datatype: "json",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00000") {
                $("<li><a href=\"/{id}/profile/\">{name}</a></li><li><a href=\"/Message/Index\">私信</a> </li><li><a href=\"/Notice/Index/\">通知</a></li><li><a href=\"/Setup/BaseInfo\">帐号设置</a></li><li class=\"line\">|</li><li><a href=\"/User/Logout\">退出</a></li>".replace(/\{name\}/g, o.Data.name).replace(/\{id\}/g, o.Data.id)).appendTo($(".gnb_r"));
                $("<li><a href=\"/\">微博</a></li>").appendTo($(".gnb_l"));
                App.TimerFunArray.push(App.GetUnreadJsonpEvent);
                if (!App.Timer) {
                    App.StartTimer();
                }
            }
            else {
                $("<li><a onclick='App.showLoginDial();' href=\"javascript:void(0);\">登录</a></li><li><a href='javascript:void(0);' onclick='App.showLoginDial();App.showLoginDial2Reg();'>注册</a></li>").appendTo($(".gnb_r"));
            }
        },
        error: function () {
            App.alert("加载失败");
        }
    });

//    if (!window.XMLHttpRequest) {
//        if (App.$doc.scrollTop() <= 30) {
//            App.yellowTip.css("top", 30);
//        }
//        else {
//            App.yellowTip.css("top", App.$doc.scrollTop());
//        }
//    }
//    else {
//        if (App.$doc.scrollTop() <= 30) {
//            alert(App.$doc.scrollTop());
//            App.yellowTip.css("top", 30);
//        }
//        else {
//            App.yellowTip.css("top", 0);
//        }
//    }

//    App.$doc.scroll(function () {
//        if (App.$doc.scrollTop() <= 30) {
//            App.yellowTip.css("top", 30);
//            App.tipIstop = true;
//        }
//        else if (App.tipIstop) {
//            App.tipIstop = false;
//            if (!window.XMLHttpRequest)
//                App.yellowTip.css("top", App.$doc.scrollTop());
//            else
//                App.yellowTip.css("top", 0);
//        }
//    });
});

App.yellowTip=$("#yellowtip");
App.tipIstop=true;
App.UnreadTimeCount = 0;
App.GetUnreadJsonpEvent = function () {
    if (App.UnreadTimeCount % 30 == 0) {
        $("head").append("<script type=\"text/javascript\" src=\"/Jsonp/Unread/?r=" + Math.random() + "\"></script>")
    };
    App.UnreadTimeCount++;
};
App.showUnread = function (o) {
    var data = o.Data;
    if (data.followCount > 0) {
        $("#unreadFollowCount").html(data.followCount + "位新粉丝，<a href=\"\">查看我的粉丝</a>").show();
        $("#unreadLayer").show();
    }
    if (data.commentCount > 0) {
        $("#unreadCommentCount").html(data.commentCount + "条新评论，<a href=\"\">查看我的评论</a>").show();
        $("#unreadLayer").show();
    }
    if (data.msgCount > 0) {
        $("#unreadMsgCount").html(data.msgCount + "条新信息，<a href=\"\">查看我的私信</a>").show();
        $("#unreadLayer").show();
    }
    if (data.atmeCount > 0) {
        $("#unreadAtmeCount").html(data.atmeCount + "条@我的微博，<a href=\"\">查看@我的微博</a>").show();
        $("#unreadLayer").show();
    }
    if (data.atcmtCount > 0) {
        $("#unreadAtcmtCount").html(data.atcmtCount + "条@我的评论，<a href=\"\">查看@我的评论</a>").show();
        $("#unreadLayer").show();
    }
    if (data.noticeCount > 0) {
        $("#unreadNoticeCount").html(data.noticeCount + "条通知，<a href=\"\">查看我的通知</a>").show(); $("#unreadLayer").show();
    }
};