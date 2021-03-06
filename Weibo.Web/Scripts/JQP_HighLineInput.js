﻿(function ($) {
    $.fn.JQP_HighLineInput = function (options) {
        var deafult = {
            focusColor: "rgb(51, 51, 51)",
            blurColor: "rgb(153, 153, 153)"
        };
        var ops = $.extend(deafult, options);
        this.focus(function () {
            $(this).css("color", ops.focusColor);
        });
        this.blur(function () {
            $(this).css("color", ops.blurColor);
         });
    }
})(jQuery);

(function ($) {
    $.fn.JQP_HighLineInput2 = function (options) {
        var deafult = {
            focusColor: "rgb(51, 51, 51)",
            blurColor: "rgb(153, 153, 153)",
            nullCon:"请输入内容"
        };
        var ops = $.extend(deafult, options);
        this.focus(function () {
            $(this).css("color", ops.focusColor);
            if($(this).val()==ops.nullCon){
               $(this).val("");
            }
        });
        this.blur(function () {
            $(this).css("color", ops.blurColor);
            if($(this).val()==""){
               $(this).val(ops.nullCon);
            }
        });
        return this;
    }
})(jQuery);