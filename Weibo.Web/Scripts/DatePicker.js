if (!domkey) {
    var domkey = {}
}
var $C = function (C) {
    return document.createElement(C)
};
domkey.Date = function (n, z, q, F, g, b, v) {
    var x = this;
    x.startDate = g || new Date();
    x.decDays = b || 7;
    var s = function (C) {
        return document.createElement(C)
    };
    var r = function (C) {
        return document.getElementById(C)
    };
    var h = function (C, H) {
        var G = 0;
        var E = C % 400 ? (C % 4 ? false : (C % 100 ? true : false)) : true;
        switch (parseInt(H)) {
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
        return G
    };
    this.year = q || (new Date()).getFullYear();
    this.month = F || (new Date()).getMonth();
    this.hlDay = v || false;
    this.fun = z ||
    function () { };
    var B = s("DIV");
    var D = s("SELECT");
    var m = s("DIV");
    var w = s("INPUT");
    var a = s("INPUT");
    var j = s("INPUT");
    var p = s("UL");
    this.oDate = s("UL");
    B.className = "selector";
    D.className = "month";
    m.className = "year";
    w.className = "yearval";
    a.className = "yearbtn";
    j.className = "yearbtn2";
    p.className = "weeks";
    this.oDate.className = "days";
    a.type = "button";
    j.type = "button";
    var o = function (C, G, E) {
        x.curYear = G || (new Date().getFullYear());
        x.curMonth = E || (new Date().getMonth());
        x.whiteDay = (new Date(x.curYear, x.curMonth, 1)).getDay();
        x.length = h(x.curYear, x.curMonth);
        x.setDateInterval(x.startDate, x.decDays)
    };
    for (var A = 0; A < this.monthText.length; A++) {
        D.options[D.length] = new Option(this.monthText[A], A)
    }
    for (var A = 0; A < this.weekText.length; A++) {
        var u = s("LI");
        u.innerHTML = this.weekText[A];
        p.appendChild(u)
    }
    B.appendChild(D);
    B.appendChild(m);
    m.appendChild(w);
    m.appendChild(a);
    m.appendChild(j);
    n.appendChild(B);
    n.appendChild(p);
    n.appendChild(this.oDate);
    D.value = this.month;
    w.value = this.year;
    D.onchange = function () {
        o(z, parseInt(w.value), D.value)
    };
    a.onclick = function () {
        var C = parseInt(w.value) + 1;
        w.value = C;
        o(z, parseInt(w.value), D.value)
    };
    j.onclick = function () {
        var C = parseInt(w.value) - 1;
        w.value = C;
        o(z, parseInt(w.value), D.value)
    };
    w.onblur = function () {
        var C = parseInt(this.value);
        if (C < 1900) {
            C = 1990
        }
        if (C > 2100) {
            C = 2010
        }
        this.value = C;
        o(z, parseInt(w.value), D.value)
    };
    w.onkeypress = function (C) {
        if (C.keyCode == 13) {
            var E = parseInt(this.value);
            if (E < 1900) {
                E = 1990
            }
            if (E > 2100) {
                E = 2010
            }
            this.value = E;
            o(z, parseInt(w.value), D.value)
        }
    };
    o(z, q, F)
};
$CLTMSG = {
  CL0501:"一月",CL0502:"二月",CL0503:"三月",CL0504:"四月",CL0505:"五月",CL0506:"六月",CL0507:"七月",CL0508:"八月",CL0509:"九月",CL0510:"十月",CL0511:"十一月",CL0512:"十二月",CL0302:"日",CL0304:"月",CL0309:"一",CL0310:"二",CL0311:"三",CL0312:"四",CL0313:"五",CL0314:"六"
}
domkey.Date.prototype = {
    monthText: [$CLTMSG.CL0501, $CLTMSG.CL0502, $CLTMSG.CL0503, $CLTMSG.CL0504, $CLTMSG.CL0505, $CLTMSG.CL0506, $CLTMSG.CL0507, $CLTMSG.CL0508, $CLTMSG.CL0509, $CLTMSG.CL0510, $CLTMSG.CL0511, $CLTMSG.CL0512],
    weekText: [$CLTMSG.CL0302, $CLTMSG.CL0309, $CLTMSG.CL0310, $CLTMSG.CL0311, $CLTMSG.CL0312, $CLTMSG.CL0313, $CLTMSG.CL0314],
    setDateInterval: function (a, o) {
        var j = this;
        var b = new Date(a.getFullYear(), a.getMonth(), a.getDate());
        var n = new Date(a.getFullYear(), a.getMonth(), a.getDate());
        n.setHours(o * -24);
        j.oDate.innerHTML = "";
        for (var h = 0; h < j.whiteDay; h++) {
            j.oDate.appendChild($C("LI"))
        }
        for (var h = 0; h < this.length; h++) {
            var m = $C("LI");
            var p = new Date(j.curYear, j.curMonth, h);
            if (p.getTime() >= n.getTime() && p.getTime() < b.getTime()) {
                var g = $C("A");
                g.href = "javascript:void(0)";
                g.setAttribute("day", h + 1);
                g.setAttribute("month", this.month);
                g.onclick = function () {
                    j.fun(j.curYear, j.curMonth, this.getAttribute("day"))
                };
                g.innerHTML = "<strong>" + (h + 1) + "</strong>";
                m.appendChild(g);
                if (j.hlDay) {
                    if (j.curYear == j.year && j.curMonth == j.month) {
                        if (j.hlDay == (h + 1)) {
                            g.className = "day"
                        }
                    }
                }
            } else {
                m.innerHTML = h + 1;
                m.title = ""
            }
            j.oDate.appendChild(m)
        }
    }
};

$.fn.JQP_DatePicker = function (options) {
    var curDate;
    if (this.val() == "" || this.val() == "点击选择日期")
        curDate = new Date();
    else
        curDate = new Date(this.val().replace(/-/g, "/"));
    var deafult = {
        curDate: curDate,
        toDate: new Date(2002, 0, 1)
    };
    var ops = $.extend(deafult, options);
    var txt = this;
    var dateElem = $("<div class='pc_caldr' style='position:absolute;z-Index:3000;left:0px;top:0px'></div>");
    var clickDoc = function () {
        dateElem.html("");
        dateElem.hide();
        $(this).unbind("click", clickDoc);
    };
    var countDays = function (s) {
        var L = 1000 * 60;
        var K = L * 60;
        var M = K * 24;
        return (Math.round(s / M))
    };
    txt.click(function (e) {
        dateElem.html("");
        dateElem.hide();
        e.stopPropagation();
        dateElem.bind("click", function (e) {
            e.stopPropagation();
        });
        $(document).bind("click", clickDoc);

        $("body").append(dateElem);
        var days;
        if (ops.curDate > ops.toDate) {
            days = countDays(ops.curDate.getTime()) - countDays(ops.toDate.getTime()) + 1;
            new domkey.Date(dateElem[0], function (x, y, z) {
                txt.val(x + "-" + (parseInt(y) + 1) + "-" + z);
                dateElem.html("");
                dateElem.hide();
            }, ops.curDate.getFullYear(), ops.curDate.getMonth(), ops.curDate, days, ops.curDate.getDate());
        }
        else {
            days = countDays(ops.toDate.getTime()) - countDays(ops.curDate.getTime()) + 1;
            new domkey.Date(dateElem[0], function (x, y, z) {
                txt.val(x + "-" + (parseInt(y) + 1) + "-" + z);
                dateElem.html("");
                dateElem.hide();
            }, ops.curDate.getFullYear(), ops.curDate.getMonth(), ops.toDate, days, ops.curDate.getDate());
        }

        dateElem.show();
        dateElem.css("top", txt.offset().top + txt.height()).css("left", txt.offset().left);
    });
    return this;
};