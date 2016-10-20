App.Setup =
{
    BindSelect: function (ctrl) {
        ctrl = $(ctrl);
        var showTemp = "<div  class=\"setup_info\"><div class=\"info_tip2\"><img title=\"\" alt=\"\" src=\"/Content/Image/transparent.gif\" class=\"tipicon tip3\"  style=\"display: none;\"></div><div class=\"info_tip1\"><span class=\"info_tabTip\"><a  href=\"javascript:void(0);\" class=\"btn_privacy\"><em><span></span><img title=\"展开\" class=\"small_icon down_arrow\" src=\"/Content/Image/transparent.gif\"></em></a></span></div></div>";
        var listTemp = "<div class=\"info_tip1\" style=\"display:none;position:absolute\"><div style=\"z-index:300\"  class=\"downmenu\"></div></div>";
        var itemTemp = "<p><a href=\"javascript:void(0)\">{name}</a></p>";
        var selOption = ctrl.find("option:selected");
        var list = $(listTemp);
        $("body").append(list);
        var show = $(showTemp);
        show.insertBefore(ctrl);
        show.find(".btn_privacy").click(function (e) {
            e.stopPropagation();
            var offset = show.offset();
            list.css("left", offset.left + 13).css("top", offset.top + 5);
            list.show();
        }).find("span").text(selOption.text());
        list.JQP_ClickOther(function () { list.hide(); });
        var options = ctrl.find("option").each(function (i) {
            var item = $(itemTemp.replace("{name}", $(this).text())).click(function () {
                show.find(".btn_privacy span").text($(options[i]).text());
                list.hide();
                ctrl.val(i + 1);
            });
            list.find(".downmenu").append(item);
        });
    },
    BindInput: function (ctrl, focusText, blurCallBack) {
        ctrl = $(ctrl);
        var tipTemp = "<table class=\"cudTs\" style=\"margin-left: 0px; position: absolute; display: none;\" ><tbody><tr><td class=\"topL\"></td><td></td><td class=\"topR\"></td></tr><tr><td></td><td class=\"tdCon\">" + focusText + "</td><td></td></tr><tr><td class=\"botL\"></td><td></td><td class=\"botR\"></td></tr></tbody></table>";
        var tipElem = $(tipTemp);
        $("body").append(tipElem);

        var errorTemp = "<table class=\"cudTs3\" style=\"display:none;\"><tbody><tr><td class=\"topL\"></td><td></td><td class=\"topR\"></td></tr><tr><td></td><td  class=\"tdCon\"></td><td></td></tr><tr><td class=\"botL\"></td><td></td><td class=\"botR\"></td></tr></tbody></table>";
        var errorElem = $(errorTemp);
        var select = ctrl.parent().next().append(errorElem).find(".setup_info");
        ctrl.focus(function () {
            this.style.borderColor = "rgb(165,199,96)";
            this.style.backgroundColor = "rgb(244,255,212)";
            errorElem.hide();
            var offset = ctrl.offset();
            tipElem.css("left", ctrl.width() + offset.left + 20).css("top", offset.top + 2);
            tipElem.show();
            select.hide();
        });
        ctrl.blur(function () {
            tipElem.hide();
            if (blurCallBack)
                blurCallBack(ctrl);
        });
    },
    redInput: function (ctrl) {
        ctrl.style.borderColor = "rgb(255, 0, 0)";
        ctrl.style.backgroundColor = "rgb(255, 204, 204)";
    },
    normalInput: function (ctrl) {
        ctrl.style.borderColor = "rgb(153, 153, 153) rgb(201, 201, 201) rgb(201, 201, 201) rgb(153, 153, 153)";
        ctrl.style.backgroundColor = "rgb(255, 255, 255)";
    },
    isNickName: false,
    CheckNickName: function (ctrl, asysn) {
        this.isNickName = false;
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        if ($.trim(ctrl.val()) == "") {
            errorCon.text("请输入昵称");
            error.show();
            App.Setup.redInput(ctrl[0]);
            select.hide();
        }
        else if (/^[0-9]*$/.test($.trim(ctrl.val()))) {
            errorCon.text("昵称不能全是数字");
            error.show();
            App.Setup.redInput(ctrl[0]);
            select.hide();
        }
        else if (!/^[0-9a-zA-Z\u4e00-\u9fa5_]*$/.test($.trim(ctrl.val()))) {
            errorCon.text("支持中英文、数字或者“_”");
            error.show();
            App.Setup.redInput(ctrl[0]);
            select.hide();
        }
        else if ($.trim(ctrl.val()).replace(/[^\x00-\xff]/g, 'xx').length > 20) {
            errorCon.text("不能超过20个字母或10个汉字");
            error.show();
            App.Setup.redInput(ctrl[0]);
            select.hide();
        }
        else {
            App.ajax_IsExsitNickName(function (o) {
                if (o.Data == "1") {
                    errorCon.text("此昵称太受欢迎，已有人抢了");
                    App.Setup.redInput(ctrl[0]);
                    error.show();

                }
                else {
                    App.Setup.isNickName = true;
                    App.Setup.normalInput(ctrl[0]);
                    error.hide();
                    select.show();
                }

            }, asysn, $.trim(ctrl.val()), "/Ajax/CheckNickName1/");
        }
    },
    isRealName: false,
    checkRealName: function (ctrl) {
        this.isRealName = false;
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        if ($.trim(ctrl.val()) == "") {
            select.show();
            this.isRealName = true;
            App.Setup.normalInput(ctrl[0]);
            return;
        }
        if ($.trim(ctrl.val()).replace(/[^\x00-\xff]/g, 'xx').length > 16 || $.trim(ctrl.val()).replace(/[^\x00-\xff]/g, 'xx').length < 4) {
            App.Setup.redInput(ctrl[0]);
            errorCon.text("请输入真实姓名");
            error.show();
            select.hide();
        }
        else if (/[0-9]+/.test($.trim(ctrl.val()))) {
            errorCon.text("请输入真实姓名");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
        }
        else {
            select.show();
            this.isRealName = true;
            App.Setup.normalInput(ctrl[0]);
        }
    },
    isQQ: false,
    checkQQ: function (ctrl) {
        this.isQQ = false;
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        if ($.trim(ctrl.val()) == "") {
            select.show();
            this.isQQ = true;
            App.Setup.normalInput(ctrl[0]);
            return;
        }
        if (!/^[1-9][0-9]{4,11}$/.test($.trim(ctrl.val()))) {
            errorCon.text("请输入正确的QQ号");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
        }
        else if ($.trim(ctrl.val()).length < 5 || $.trim(ctrl.val()).length > 12) {
            App.Setup.redInput(ctrl[0]);
            errorCon.text("请输入正确的QQ号");
            error.show();
            select.hide();
        }
        else {
            select.show();
            this.isQQ = true;
            App.Setup.normalInput(ctrl[0]);
        }
    },

    isMsn: false,
    checkMsn: function (ctrl) {
        this.isMsn = false;
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        if ($.trim(ctrl.val()) == "") {
            select.show();
            this.isMsn = true;
            App.Setup.normalInput(ctrl[0]);
            return;
        }
        if (!/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/.test($.trim(ctrl.val()))) {
            errorCon.text("请输入正确的MSN地址");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
        }
        else {
            select.show();
            this.isMsn = true;
            App.Setup.normalInput(ctrl[0]);
        }
    },
    isMydec: false,
    checkMydec: function (ctrl) {
        this.isMydec = false;
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        if ($.trim(ctrl.val()) == "") {
            select.show();
            this.isMydec = true;
            App.Setup.normalInput(ctrl[0]);
            return;
        }
        if ($.trim(ctrl.val()).replace(/[^\x00-\xff]/g, 'xx').length > 140) {
            errorCon.text("你输入的个人简介不能超过70个字	");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
        }
        else {
            select.show();
            this.isMydec = true;
            App.Setup.normalInput(ctrl[0]);
        }
    },
    isRealBlog: false,
    checkRealBlog: function (ctrl) {
        this.isRealBlog = false;
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        var strRegex = "^((https|http|ftp|rtsp|mms)?://)"
  + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@ 
        + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184 
        + "|" // 允许IP和DOMAIN（域名）
        + "([0-9a-z_!~*'()-]+\.)*" // 域名- www. 
        + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名 
        + "[a-z]{2,6})" // first level domain- .com or .museum 
        + "(:[0-9]{1,4})?" // 端口- :80 
        + "((/?)|" // a slash isn't required if there is no file name 
        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
        var re = new RegExp(strRegex);
        if ($.trim(ctrl.val()) == "") {
            select.show();
            this.isRealBlog = true;
            App.Setup.normalInput(ctrl[0]);
            return;
        }
        if (!re.test($.trim(ctrl.val()))) {
            errorCon.text("请输入正确的博客地址");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
        }
        else {
            select.show();
            this.isRealBlog = true;
            App.Setup.normalInput(ctrl[0]);
        }
    },
    isCompanyName: false,
    checkCompanyName: function (ctrl) {
        this.isCompanyName = false;
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        if ($.trim(ctrl.val()).replace(/[^\x00-\xff]/g, 'xx').length > 50) {
            errorCon.text("请输入正确的单位名称，限制在25字以内");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
        }
        else if ($.trim(ctrl.val()) == "") {
            errorCon.text("请输入正确的单位名称");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
        }
        else {
            select.show();
            this.isCompanyName = true;
            App.Setup.normalInput(ctrl[0]);
        }
    },
    isRemark: false,
    checkRemark: function (ctrl) {
        this.isRemark = false;
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        if ($.trim(ctrl.val()) == "") {
            select.show();
            this.isRemark = true;
            App.Setup.normalInput(ctrl[0]);
            return;
        }
        if ($.trim(ctrl.val()).replace(/[^\x00-\xff]/g, 'xx').length > 140) {
            errorCon.text("最多可以输入70字以内的备注");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
        }
        else {
            select.show();
            this.isRemark = true;
            App.Setup.normalInput(ctrl[0]);
        }
    },
    editEmailCon: "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong node-type=\"titlestring\">修改常用邮箱</strong><a title=\"关闭\" class=\"close\" href=\"javascript:void(0)\"></a><div class=\"clearit\"></div></div></div><div  style=\"height:auto; width:390px;\" class=\"layerBoxCon\"><div  class=\"mailBoxLayer\"><div node-type=\"before\"><p class=\"gray6\">请填写自己常用的邮箱地址，方便大家联系你！</p><div class=\"inputBox\">邮箱地址：			<input type=\"text\"  value=\"\" class=\" \" style=\"border-color: rgb(153, 153, 153) rgb(201, 201, 201) rgb(201, 201, 201) rgb(153, 153, 153); background-color: rgb(255, 255, 255);\"></div><p style=\"display:none\" node-type=\"errorTip\" class=\"errorTs error_color\">请输入正确的邮箱地址</p><div class=\"btns\"><a id='BtnSave' class=\"btn_normal\" href=\"javascript:void(0);\"><em>保存</em></a><a id=\"btnCancel\" class=\"btn_normal\" href=\"javascript:void(0);\"><em>取消</em></a></div></div></div></div></div>",
    showEditEmailBox: function (email, callBack) {
        if (App.initDialDiv("editEmailBox", dialDiv, false, null)) {
            var box = $("#editEmailBox");
            box.removeClass("4CancelAllLayer");
            box.find(".mid_c").html(this.editEmailCon);
            box.find(".close").add(box.find("#btnCancel")).click(function () {
                box.remove();
                App.hideMash();
            });

        }
        var box = $("#editEmailBox");
        var position = App.centerInScreen(box);
        box.css("top", position.top).css("left", position.left);
        App.showMash();
        box.show();
        var txtbox = box.find("input");
        var saveBtn = box.find("#BtnSave");
        if (email)
            txtbox.val(email);
        txtbox.focus(function () {
            this.style.borderColor = "rgb(165,199,96)";
            this.style.backgroundColor = "rgb(244,255,212)";
        }).blur(function () {
            if (!/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/.test($.trim(txtbox.val()))) {
                box.find(".errorTs").show();
                App.Setup.redInput(this);
            }
            else {
                box.find(".errorTs").hide();
                App.Setup.normalInput(ctrl[0]);
            }
        });
        saveBtn.click(function () {
            if (!/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/.test($.trim(txtbox.val()))) {
                box.find(".errorTs").show();
                App.Setup.redInput(this);
                return false;
            }
            else {
                if (callBack) {
                    callBack($.trim(txtbox.val()));
                }
                box.hide();
                App.hideMash();
            }
        });
    },
    bindDate: function (ctrlYear, ctrlMonth, ctrlDay, curYear, curMonth, curDay) {
        var option;
        for (var i = 1900; i <= (new Date()).getFullYear(); i++) {
            if (!curYear || ctrlYear != i)
                option += "<option value=" + i + ">" + i + "</option>";
        }
        ctrlYear.html($(option));
        if (curYear) {
            if ($.browser.msie && $.browser.version == 6) {
                setTimeout(function () { ctrlYear.val(curYear); }, 1);
            }
            else {
                ctrlYear.val(curYear);
            }
        }
        option = "";
        for (var j = 1; j < 13; j++) {
            option += "<option value=" + j + ">" + j + "</option>";
        }
        ctrlMonth.html($(option));
        if (curMonth) {
            if ($.browser.msie && $.browser.version == 6) {
                setTimeout(function () { ctrlMonth.val(curMonth); }, 1);
            }
            else {
                ctrlMonth.val(curMonth);
            }
        }
        option = "";
        var Ie7SelectFix = function () {
            ctrlDay.hide();
            ctrlMonth.hide();
            ctrlYear.hide();
            ctrlDay.show();
            ctrlMonth.show();
            ctrlYear.show();
        }

        var getDayCount = function (year, month) {
            var G = 0;
            var E = year % 400 ? (year % 4 ? false : (year % 100 ? true : false)) : true;
            switch (parseInt(month) - 1) {
                case 0:
                case 2:
                case 4:
                case 6:
                case 7:
                case 9:
                case 11:
                    G = 31;
                    break;
                case 3:
                case 5:
                case 8:
                case 10:
                    G = 30;
                    break;
                case 1:
                    if (E) {
                        G = 29
                    } else {
                        G = 28
                    }
            }
            return G;
        }
        ctrlYear.change(function () {
            var G = getDayCount(this.value, ctrlMonth.val());
            for (var k = 1; k < G + 1; k++) {
                option += "<option value=" + k + ">" + k + "</option>";
            }
            ctrlDay.html($(option));
            option = "";
            Ie7SelectFix();
        });
        ctrlMonth.change(function () {
            var G = getDayCount(ctrlYear.val(), this.value);
            for (var k = 1; k < G + 1; k++) {
                option += "<option value=" + k + ">" + k + "</option>";
            }
            ctrlDay.html($(option));
            option = "";
            Ie7SelectFix();
        });
        for (var z = 1; z < getDayCount(ctrlYear.val(), ctrlMonth.val()) + 1; z++) {
            option += "<option value=" + z + ">" + z + "</option>";
        }
        ctrlDay.html($(option));
        if (curDay) {
            if ($.browser.msie && $.browser.version == 6) {
                setTimeout(function () { ctrlDay.val(curDay); }, 1);
            }
            else {
                ctrlDay.val(curDay);
            }
        }
        option = "";
        Ie7SelectFix();
    },
    pwdPower: function (l) {
        function k(n) {
            if (n >= 65 && n <= 90) {
                return 2
            } else {
                if (n >= 97 && n <= 122) {
                    return 4
                } else {
                    if (n >= 48 && n <= 57) {
                        return 1
                    } else {
                        return 8
                    }
                }
            }
        }
        function j(n) {
            var o = 0;
            for (i = 0; i < 4; i++) {
                if (n & 1) {
                    o++
                }
                n >>>= 1
            }
            return o
        }
        var h = 0,
            g = l.length;
        if (g < 6) {
            return 1
        }
        for (i = 0; i < g; i++) {
            h |= k(l.charCodeAt(i))
        }
        var m = j(h);
        if (l.length >= 10) {
            m++
        }
        switch (m) {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
            case 4:
                return 3;
            default:
                return 1
        }
    },
    checkPWD: function (ctrl) {
        ctrl = $(ctrl);
        var error = ctrl.parent().next().find(".cudTs3");
        var errorCon = error.find(".tdCon");
        var select = ctrl.parent().next().find(".setup_info");
        if (ctrl.val().length < 6 || ctrl.val().length > 16) {
            errorCon.text("密码长度不正确，应为6～16个字符");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
            return false;
        }
        else if (!new RegExp("^([\\w\\~\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\+\\`\\-\\=\\[\\]\\\\{\\}\\|\\;\\'\\:\\\"\\,\\.\\/\\<\\>\\?]{6,16})$").test(ctrl.val())) {
            errorCon.text("密码请勿使用特殊字符");
            App.Setup.redInput(ctrl[0]);
            error.show();
            select.hide();
            return false;
        }
        else {
            select.show();
            App.Setup.normalInput(ctrl[0]);
            return true;
        }
    }

}