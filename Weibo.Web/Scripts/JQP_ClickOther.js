jQuery.fn.extend({
    JQP_ClickOther: function () {
        //        function isInside(e, target) {
        //            var x = e.pageX;
        //            var y = e.pageY;
        //            var left = target.offset().left;
        //            var width = target.width();
        //            var top = target.offset().top;
        //            var height = target.height();
        //            if (x > left && x < left + width && y > top && y < top + height) return true;
        //            return false;
        //        }
        //        if (window.click_other == null) {
        //            window.click_other = new Array();
        //        }
        //        this.except = null;
        //        var func = arguments[0];
        //        if (typeof (func) == "string") {
        //            this.except = document.getElementById(func);
        //            func = arguments[1];
        //        }
        //        window.click_other.push({ target: this, func: func });
        //        $(document).click(function (e) {
        //            for (var i = 0; i < click_other.length; i++) {
        //                var item = window.click_other[i];
        //                var target = $(item.target);
        //                if (isInside(e, target)) continue;
        //                if (item.target.except) {
        //                    var except = $(item.target.except);
        //                    if (isInside(e, except)) continue;
        //                }
        //                item.func();
        //            }
        //        });

        //    },

                if (window.click_other == null) {
                    window.click_other = new Array();
                }
                window.click_other.push({ target: this, func: arguments[0] });
                $(document.body).click(function (e) {
                    for (var i = 0; i < click_other.length; i++) {
                        var item = window.click_other[i];
                        var target = item.target;
                        if (typeof (target) == "String") target = $(target)[0];

                        if (e.target == target) {
                            continue;
                        }
                        var index = $(e.target).parents().index(target);
                        if (index == -1) {
                            item.func();
                        }
                    }
                });

//        var foo = arguments[0];
//        this.bind("click", function (e) { e.stopPropagation(); });
//        $(document.body).bind("click",foo);

    },

    JQP_UnClickOther: function () {
        if (window.click_other == null) {
            return;
        }
        for (var i = 0; i < window.click_other.length; i++) {
            var item = window.click_other[i];
            if (item.target[0] == this[0]) {
                window.click_other.splice(i, 1);
                break;
            }
        }
    }
}); 

