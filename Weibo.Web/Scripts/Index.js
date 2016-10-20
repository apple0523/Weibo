/// <reference path="Common/jquery-1.10.2.js" />

function loginCallBack(isSucess) {
    if ($("#mod_login_tip")[0] == null) {
        $("body").append(errorHtml);
        bindCloseEvent($("#mod_login_close"), $("#mod_login_tip"));
    }
    if (!isSucess) {
        $("#mod_login_title").text("登录名或密码错误");
        $("#mod_login_content").show();
        $("#mod_login_content").html("<p class='stxt2'>1、如果登录名是邮箱地址，</p><p class='stxt'>请输入全称，例如yourname@xxxx.com</p><p class='stxt2'>2、请检查登录名大小写是否正确。</p><p class='stxt2'>3、请检查密码大小写是否正确。</p>");
        setErrorDivPosition($("#mod_login_tip"), $("#loginname"));
        $("#mod_login_tip").show();
    }
    else {
        if (arguments[1] == 0) {
            $("#mod_login_title").text("你的账号还没有验证");
            $("#mod_login_content").show();
            $("#mod_login_content").html("<p class='stxt'>如果没收到请尝试点击<a id='resend' href='javascript:void(0);' >重发</a></p><p class='stxt'>如果实在收不到，请重新注册</p>");
            setErrorDivPosition($("#mod_login_tip"), $("#loginname"));
            $("#mod_login_tip").show();
            $("#resend").click(function () {
                $("#mod_login_tip").hide();
                App.ajax_resendEmail($("#loginname").val());
                
                return false;
            });
        }
        if (arguments[1] == 1) {
            window.location.href = "/User/fullinfo/";
        }
        if (arguments[1] == 2) {
            window.location.href = "/";
        }
    }
}


var errorHtml = "<div id='mod_login_tip' class='errorLayer'><div class='top'></div><div class='mid'><div id='mod_login_close' class='close'>x</div><div class='conn'>	<p id='mod_login_title' class='bigtxt'></p><span style='padding: 0px; display: none;' id='mod_login_content' class='stxt'></span></div></div><div class='bot'></div></div>";
var checkLogin = function () {
    if ($("#loginname").val() == "邮箱/会员帐号/手机号" || $.trim($("#loginname").val()) == "") {
        if ($("#mod_login_tip")[0] == null) {
            $("body").append(errorHtml);
            bindCloseEvent($("#mod_login_close"), $("#mod_login_tip"));
        }
        $("#mod_login_title").text("请输入登录名");
        $("#mod_login_content").hide();
        setErrorDivPosition($("#mod_login_tip"), $("#loginname"));
        $("#mod_login_tip").show();
        $("#loginname").focus();
        $("#password").blur();
        return;
    }
    if ($("#password").val() == "") {
        if ($("#mod_login_tip")[0] == null) {
            $("body").append(errorHtml);
            bindCloseEvent($("#mod_login_close"), $("#mod_login_tip"));
        }
        $("#password_text").focus();
        $("#mod_login_title").text("请输入密码");
        $("#mod_login_content").hide();
        setErrorDivPosition($("#mod_login_tip"), $("#password"));
        $("#mod_login_tip").show();
        return;
    }
    $("#mod_login_tip").hide();
    $("#hdLoginname").val($("#loginname").val());
    $("#hdPassword").val($("#password").val());
    $("#hdReUsername").val($("#remusrname").attr("checked"));
    if (/msie/.test(navigator.userAgent.toLowerCase())) {

        window.loginForm.submit();
    } else {

        $("#loginForm").submit();
    }
    return false;
}
var bindCloseEvent = function (btnClose, needCloseDiv) {
    btnClose.bind("click", function () {
        needCloseDiv.hide();
    });
}
var setErrorDivPosition = function (div, inputCtr) {
    var offset = inputCtr.offset();
    var l = offset.left;
    var t = offset.top - div.height();
    div.css("position", "absolute");
    div.css("left", l + "px");
    div.css("top", t + "px");
    div.css("z-index", "9999");
}

var index = {
    init: function () {
        $("#loginname").focus(function () {
            var logininput = $(this);
            logininput.css("color", "rgb(51, 51, 51)");
            if (logininput.val() == "邮箱/会员帐号/手机号")
                logininput.val("");
        });
        $("#loginname").blur(function () {
            var logininput = $(this);
            logininput.css("color", "rgb(153, 153, 153)");
            if (logininput.val() == "")
                logininput.val("邮箱/会员帐号/手机号");
        });
        $("#password_text").focus(function () {
            $(this).hide();
            $("#password").show();
            $("#password").focus();
            $("#password").click();
            $("#password").css("color", "rgb(51, 51, 51)");
        });
        $("#password").blur(function () {
            if ($(this).val() == "") {
                $("#password_text").show();
                $("#password_text").blur();
                $(this).hide();
            }
            else {
                $(this).css("color", "rgb(153, 153, 153)");
            }

        });
        $("#password").focus(function () {
            $(this).css("color", "rgb(51, 51, 51)");
        });
        $("#login_submit_btn").bind("click", checkLogin);
        $("#password").bind("keyup", function (e) {
            if (e.keyCode == 13)
                checkLogin();
        });
    }

}

//function pageX(elem) {
//    return elem.offsetParent ? elem.offsetLeft + pageX(elem.offsetParent) : elem.offsetLeft;
//}
//function pageY(elem) {
//    return elem.offsetParent ? elem.offsetTop + pageY(elem.offsetParent) : elem.offsetTop;
//} 