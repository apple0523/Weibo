(function ($) {
    var itemindex = 1;
    var itemcount = 0;
    $.fn.JQP_EmailNote = function (options) {
        var deafult = {
            arrayEmail: ["sina.com", "sina.com.cn", "163.com", "qq.com", "sohu.com"], //默认邮箱数组
            selfn: null//选择之后触发的时间
        };
        var ops = $.extend(deafult, options);
        itemcount = 0;
        itemindex = 1;
        var InitNote = function (loginCtr, arrayEmail) {
            if (typeof (loginCtr) == "object" && typeof (arrayEmail) == "object") {
                var offset = loginCtr.offset();
                var ulStr = "<div><ul style='display:none;width:198px;left:" + offset.left + "px;top:" + (parseInt(offset.top) + parseInt(loginCtr.height())) + "px' id='sinaNote' class='passCard'><li class='note'>请选择邮箱类型</li><li id='sinaNote_MenuItem_Title' style='color: rgb(0, 0, 0); background-color: rgb(232, 244, 252);'></li></ul></div>";
                if ($("#sinaNote")[0] == null)
                    $("body").append(ulStr);
                var note = $("#sinaNote");
                loginCtr[0].onkeyup = function (e) {
                    var currKey = 0, e = e || event;
                    currKey = e.keyCode || e.which || e.charCode;
                    offset = loginCtr.offset();
                    $("#sinaNote").css("left", offset.left + "px");
                    $("#sinaNote").css("top", (parseInt(offset.top) + parseInt(loginCtr.height())) + "px");
                    if (currKey != 38 && currKey != 40 && currKey != 13) {
                        initliItem(loginCtr, arrayEmail);
                        note.show();
                        itemindex = 1;
                        itemcount = $("ul.passCard>li").length - 1;
                    }
                    else {
                        note.show();
                        var lis = $("ul.passCard>li")
                        switch (currKey) {
                            case 38:
                                if (itemindex == 1) {
                                    itemindex = lis.length - 1;
                                    liSelected($(lis[itemindex]));
                                }
                                else {
                                    itemindex--;
                                    liSelected($(lis[itemindex]));
                                }

                                break;
                            case 40:
                                if (itemindex == lis.length - 1) {
                                    itemindex = 1;
                                    liSelected($(lis[itemindex]));
                                }
                                else {
                                    itemindex++;
                                    liSelected($(lis[itemindex]));
                                }
                                break;
                            case 13:
                                $(this).val($(lis[itemindex]).text());
                                note.hide();
                                itemcount = 0;
                                itemindex = 1;
                                ops.selfn();
                                //$("#password_text").focus();
                                break;
                        }
                    }
                };
                $(document).bind("click", function () {
                    note.hide();
                    itemcount = 0;
                    itemindex = 1;
                });
                $("ul.passCard").hover(function (e) { }, function () {
                    liSelected($("#sinaNote_MenuItem_Title"));
                    itemcount = 0;
                    itemindex = 1;
                });
            }
        };

        var initliItem = function (loginCtr, arrayEmail) {
            var value = $.trim(loginCtr.val());
            $("#sinaNote").html("<li class='note'>请选择邮箱类型</li><li id='sinaNote_MenuItem_Title' select='1' style='color: rgb(0, 0, 0); background-color: rgb(232, 244, 252);'></li>");
            $("#sinaNote_MenuItem_Title").text(value);
            $("#sinaNote_MenuItem_Title").attr("title", value);

            BindLiEvent($("ul.passCard li:last-child"), loginCtr);
            $.each(arrayEmail, function (i, v) {
                if (value.indexOf('@@') < 0) {
                    if (value.indexOf('@') >= 0 && value.split('@')[1] != "") {
                        if (value.split('@')[1] == v || v.indexOf(value.split('@')[1]) == 0) {
                            var sd = "<li select='0' title='" + value.split('@')[0] + "@" + v + "' id='sinaNote_MenuItem_" + v + "'>" + value.split('@')[0] + "@" + v + "</li>";
                            $("#sinaNote").append(sd);
                        }
                    }
                    else {
                        if (value.indexOf('@') >= 0)
                            $("#sinaNote").append("<li select='0' title='" + value + v + "' id='sinaNote_MenuItem_" + v + "'>" + value + v + "</li>");
                        else
                            $("#sinaNote").append("<li select='0' title='" + value + "@" + v + "' id='sinaNote_MenuItem_" + v + "'>" + value + "@" + v + "</li>");

                    }
                    BindLiEvent($("ul.passCard li:last-child"), loginCtr);
                }
            });

        };
        var BindLiEvent = function (li, loginCtr) {
            if (typeof (li) == "object") {
                li.bind("click", function () {
                    loginCtr.val(li.text());
                    ops.selfn();
                    //$("#password_text").focus();
                });
                li.hover(function (e) {
                    liSelected(li);
                });
            }
        };

        var liSelected = function (li) {
            if (typeof (li) == "object") {
                $("li[select='1']").css("color", "rgb(153, 153, 153)");
                $("li[select='1']").css("background-color", "white");
                $("li[select='1']").attr("select", "0");
                li.css("color", "rgb(0, 0, 0)");
                li.css("background-color", "rgb(232, 244, 252)");
                li.attr("select", "1");
            }
        };
        InitNote(this, ops.arrayEmail);
    }
})(jQuery);
