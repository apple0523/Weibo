/// <reference path="Common/jquery-1.10.2.js" />
(function ($) {
    var tipsDiv = "<div id='newTips' class='new_plus' style='position: absolute; z-index: 251;display: none;'><div class='mentip'><div class='tpbg'></div><div class='maincent'></div><div class='btbg'></div></div></div>";
    $.fn.JQP_TxtTips = function (options) {
        var deafult = {
            txt: "请输入提示内容", //默认提示内容
            VailFn: null,  //验证函数
            plusId: null,  //显示块ID
            isTxtInput: true //是否为Text类型输入标签
        };
        var ops = $.extend(deafult, options);

        if (!ops.isTxtInput) {
            $(this).click(function () {
                ops.VailFn($(this), $("#" + ops.plusId));
            });
        }
        if (ops.isTxtInput) {
            $(this).focus(function () {
                $(this).css("color", "rgb(51,51,51)");
                $("#" + ops.plusId).show();
                var x = $("#" + ops.plusId).offset().left;
                var y = $("#" + ops.plusId).offset().top;
                $("#" + ops.plusId).hide();
                if ($("#newTips")[0] == null) {
                    $("body").append(tipsDiv);
                }
                if ($.trim($(this).val()) == "") {
                    $("#newTips").css("top", y + "px");
                    $("#newTips").css("left", x + "px");
                    $("#newTips").show();
                    $(".maincent").html(ops.txt);
                    $("#" + ops.plusId).hide()
                }
                else {
                    ops.VailFn($(this), $("#" + ops.plusId),true);
                }

            });
        }
        if (ops.isTxtInput) {
            $(this).blur(function () {

                $("#newTips").hide();
                $(this).css("color", "rgb(153,153,153)");
                $(this).val($.trim($(this).val()));
                ops.VailFn($(this), $("#" + ops.plusId),true);
            });
        }
    }
})(jQuery);

var isMail = false;
var isPwd = false;
var isRePwd = false;
var isVailCode = false;
var isAgree = false;

var checkMail = function (inputCtr, plus,async) {
    isMail = false;
    var regStr = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
    if ($.trim(inputCtr.val()) == "") {
        plus.html("<div class='errormt'>" + "<strong><span>" + "请输入常用邮箱。" + "</span></strong></div>");
        plus.show();
    }
    else if (!regStr.test(inputCtr.val())) {
        plus.html("<div class='errormt'>" + "<strong><span>" + "请输入正确的邮箱地址。" + "</span></strong></div>");
        plus.show();
    }
    else {
        App.ajax_IsExsitEmail(function (o) {
            if (o.Data == "1") {
                plus.html("<div class='errormt'>" + "<strong><span>" + "该邮箱地址已被注册，<a href='#' onclick=''>登陆</a>" + "</span></strong></div>");
                plus.show();
            }
            else {
                isMail = true;
                plus.html("<div class='success'><img class='tipicon tip3' src='/Content/Image/transparent.gif'/></div>");
                plus.show();

            }
        }, async, $.trim(inputCtr.val()));
    }
}



var checkPwd = function (inputCtr, plus) {
    isPwd = false;
    var regStr = /\s+/;
    if (regStr.test(inputCtr.val())) {
        plus.html("<div class='errormt'>" + "<strong><span>" + "密码请勿使用特殊字符。" + "</span></strong></div>");
        plus.show();
    }
    else if (inputCtr.val() == "") {
        plus.html("<div class='errormt'>" + "<strong><span>" + "密码太短了，最少6位。" + "</span></strong></div>");
        plus.show();
    }
    else if (inputCtr.val().length < 6) {
        plus.html("<div class='errormt'>" + "<strong><span>" + "密码太短了，最少6位。" + "</span></strong></div>");
        plus.show();
    }
    else if (inputCtr.val().length > 16) {
        plus.html("<div class='errormt'>" + "<strong><span>" + "密码太长了，最多16位。" + "</span></strong></div>");
        plus.show();
    }
    else {
        isPwd = true;
        plus.html("<div class='success'><img class='tipicon tip3' src='/Content/Image/transparent.gif'/></div>");
        plus.show();
    }
}
var checkRePwd = function (inputCtr, plus) {
    isRePwd = false;
    if (inputCtr.val() != $("#reg_password").val()) {
        plus.html("<div class='errormt'>" + "<strong><span>" + "两次输入的密码不同" + "</span></strong></div>");
        plus.show();
    }
    else {
        if ($("#reg_password").val() != "") {
            isRePwd = true;
            plus.html("<div class='success'><img class='tipicon tip3' src='/Content/Image/transparent.gif'/></div>");
            plus.show();
        }
    }
}

var checkVailCode = function (inputCtr, plus, async) {
    isVailCode = false;
    if (inputCtr.val() == "") {
        plus.html("<div class='errormt'>" + "<strong><span>" + "请输入验证码" + "</span></strong></div>");
        plus.show();
    }
    else {
        App.ajax_IsValidCode(function (o) {
            if (o.Data == "1") {
                plus.html("<div class='errormt'>" + "<strong><span>" + "验证码不正确" + "</span></strong></div>");
                plus.show();
            }
            else {
                isVailCode = true;
                plus.html("<div class='success'><img class='tipicon tip3' src='/Content/Image/transparent.gif'/></div>");
                plus.show();
            }
        }, async,$.trim(inputCtr.val()));
        
    }
}



    var checkIsAgree = function (inputCtr, plus) {
        isAgree = false;
        if (inputCtr.attr("checked") != true) {
            plus.html("<div class='errormt'>" + "<strong><span>" + "需同意使用协议" + "</span></strong></div>");
            plus.show();
        }
        else {
            isAgree = true;
            plus.html("<div class='success'><img class='tipicon tip3' src='/Content/Image/transparent.gif'/></div>");
            plus.show();
        }
    }

    var RegCallback = function (isSuccess,email) {
        if (isSuccess) {
            window.location.href = "/User/RegSuccess/?email="+email;
        }
        else {
            App.alert("系统繁忙，稍后再试！");
        }
    }




