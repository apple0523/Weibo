/// <reference path="App.js" />
App.skinManage =  {
    pickContainer : "<div {id} style=\"position: absolute; z-index: 1000; background-color: rgb(255, 255, 255); left: 609px; top: 144px; display: none;\"></div>",
    colorFlash :"<embed wmode=\"transparent\" width=\"251\" height=\"264\" type=\"application/x-shockwave-flash\" src=\"/ColorPicker/ColorPicker.swf\" id=\"color_picker\"  allowFullscreen=\"true\" wmode=\"Opaque\" allowScriptAccess=\"always\" quality=\"high\"  flashvars=\"{vars}\"/>",
    borderContainer : "<div {id} style=\"left: 957px; top: 145px; position: absolute; z-index: 1000;\">        <ul>            <li class=\"black\"><div class=\"on\"></div></li>            <li class=\"gray\"><div></div></li>            <li class=\"pink\"><div></div></li>            <li class=\"purple\"><div></div></li>            <li  class=\"blue\"><div></div></li>            <li class=\"white\"><div></div></li>            <li  class=\"red\"><div></div></li>            <li class=\"orange\"><div></div></li>            <li class=\"yellow\"><div></div></li>            <li  class=\"green\"><div></div></li>        </ul>        <div class=\"clear btn\">            <a id=\"submitBorder\" href=\"javascript:void(0);\"><img src=\"/Content/Image/bgbtn.gif\"></a></div></div>",
    diyTemplate : "body{background-color:{set_backColor};background-image:url({bgImg}); background-repeat:{isRepeat}; background-position:top {position}; background-attachment:{locked}; } /* A类-左-文字 */ .MIB_txtal,.MIB_txtbl{color:{set_backColor1};} /* A类-左-链接 */ .MIB_linkal a:link, .MIB_linkal a:visited, .MIB_linkal a:hover, a.MIB_linkal:link, a.MIB_linkal:visited, a.MIB_linkal:hover, .MIB_linkbl a:link, .MIB_linkbl a:visited, .MIB_linkbl a:hover, a.MIB_linkbl:link, a.MIB_linkbl:visited, a.MIB_linkbl:hover{color: {set_backColor2};} /*顶部导航广场*/ .topSquLayer .arrows span, .topSquLayer .bgs{ background-color:{set_backColor5};} /* A类-右-文字 */ .MIB_txtar,.MIB_txtbr{color:{set_backColor3};} /* A类-右-链接 */ .MIB_linkar a:link, .MIB_linkar a:visited, .MIB_linkar a:hover, a.MIB_linkar:link, a.MIB_linkar:visited, a.MIB_linkar:hover, .MIB_linkbr a:link, .MIB_linkbr a:visited, .MIB_linkbr a:hover, a.MIB_linkbr:link, a.MIB_linkbr:visited, a.MIB_linkbr:hover, .MIB_linkcr a:link, .MIB_linkcr a:visited, .MIB_linkcr a:hover, a.MIB_linkcr:link, a.MIB_linkcr:visited, a.MIB_linkcr:hover {color:{set_backColor4};} /*内容的背景颜色 feed*/ .MIB_mbloglist{background-color:{set_backColor5};} ",
    defColor : { set_backColor: "#709ADE", set_backColor1: "#666666", set_backColor2: "#0082CB", set_backColor3: "#FFFFFF", set_backColor4: "#C3E9FF", set_backColor5: "#F3FCFD" },
    curColor : { set_backColor: "#709ADE", set_backColor1: "#666666", set_backColor2: "#0082CB", set_backColor3: "#FFFFFF", set_backColor4: "#C3E9FF", set_backColor5: "#F3FCFD" },
    defBorder : "black",
    curBorder : "black",
    defLock : "scroll",
    curLock : "scroll",
    defPicUrl: "",
    curPicUrl: "",
    defPicID:-1,
    curPicID:-1,
    defIsRepeat:"repeat",
    curIsRepeat:"repeat",
    defAlignStyle:"left",
    curAlignStyle:"left",
    IsUseBg:true,
    curSkinBoxHeight:209,
    curCate:0,
    curThemeId:-1,
    isUserDefined:false
}

App.skinManage.ShowColorPicker = function (clickWhere) {
    App.initDialDiv("picker_container", App.skinManage.pickContainer, true, function () { $("#picker_container").hide(); });
    clickWhere = $(clickWhere);
    var bg = clickWhere.css("background-color");
    var offset = clickWhere.offset();
    $("#picker_container").css("left", offset.left).css("top", offset.top + 100).show();
    $("#picker_container").html(this.colorFlash.replace("{vars}", "callback=App.skinManage.ColorCallBack&color=" + bg + "&who=" + clickWhere.attr("class")));
}
App.skinManage.ShowBorderBox = function () {
    if (App.initDialDiv("borderBgBox", App.skinManage.borderContainer, true, function () { $("#borderBgBox").hide(); })) {
        $(".black").add($(".gray")).add($(".pink")).add($(".purple")).add($(".blue")).add($(".white")).add($(".red")).add($(".orange")).add($(".yellow")).add($(".green")).click(function () {
            $(".on").removeClass("on");
            $(this).find("div").attr("class", "on");
            App.skinManage.curBorder = this.className;
        });
        $("#submitBorder").click(function () {
            App.skinManage.SetBorder();
            $("#borderBgBox").hide();
            return false;
        });
    }
    else {
        $("#borderBgBox").show();
    }
}
App.skinManage.RenderPage = function () {
    var temp = App.skinManage.diyTemplate;
    for (var attr in this.curColor) {
        temp = temp.replace(new RegExp("{" + attr + "}", "g"), App.skinManage.curColor[attr]);
    }

    if (this.IsUseBg) {
        temp = temp.replace("{bgImg}", App.skinManage.curPicUrl);
        temp = temp.replace("{isRepeat}", App.skinManage.curIsRepeat);
        temp = temp.replace("{position}", App.skinManage.curAlignStyle);
        temp = temp.replace("{locked}", App.skinManage.curLock);
    }
    $("head style").remove();
    $("head").append("<style id=\"diyCss\" type=\"text/css\">" + temp + "</style>");
    $("#skin_transformers").attr("href", "/Content/skins/sky_diy/skin.css");
    $("body").attr("style", "background-position: " + this.curAlignStyle + " " + this.curSkinBoxHeight + "px; background-attachment: " + this.curLock + ";");
}
App.skinManage.SetBorder = function () {
    $("#rightborder").attr("class", "MIB_mblogbgr " + App.skinManage.curBorder + "Bg");
    $("#bottomborder").attr("class", "bottomLinks " + App.skinManage.curBorder + "Bg");
    $(".set_backColor6").css("background-color", App.skinManage.curBorder);
}

App.skinManage.backToDefault = function () {
    for (var attr in this.curColor) {
        this.curColor[attr] = this.defColor[attr];
        $("." + attr).css("background-color", this.curColor[attr]);
    }
    this.curBorder = this.defBorder;
    this.SetBorder();
    this.RenderPage();
}


App.skinManage.toggle = function () {
    if (App.isVisible($("#skin_display_main"))) {
        $("#skin_display_main").hide();
        if (this.isUserDefined) {
            $("#container").attr("class", "set_interface set_shrink set_zdybg");
        }
        else {
            $("#container").attr("class", "set_interface set_shrink");
        }
        this.curSkinBoxHeight = 56;
        $("body").attr("style", "background-position: " + this.curAlignStyle + " " + this.curSkinBoxHeight + "px; background-attachment: " + this.curLock + ";");
    }
    else {
        $("#skin_display_main").show();
        if (this.isUserDefined) {
            $("#container").attr("class", "set_interface set_expand set_zdybg");
            this.curSkinBoxHeight = 209;
        }
        else {
            $("#container").attr("class", "set_interface set_expand");
            this.curSkinBoxHeight = 257;
        }
        $("body").attr("style", "background-position: " + this.curAlignStyle + " " + this.curSkinBoxHeight + "px; background-attachment: " + this.curLock + ";");
    }
}

App.skinManage.ColorCallBack = null;

 App.skinManage.themePicUpload= function (callBack) {
     if (!(/\.(gif|jpg|png|jpeg)$/i.test($("#themeFile").val()))) {
            App.alert("支持大小不超过5M的jpg、gif、png图片上传，请重新上传");
            return false;
        }
        else {
            if ($.browser.msie) {
                eval("window.uploadeForm.submit();");
            } else {

                $("#uploadeForm").submit();
            }
            callBack();
        }
        var clone = $("#themeFile").clone();
        clone.removeAttr("value");
        $("#themeFile").remove();
        $("#uploadeForm").append(clone);
        $("#uploadeForm").find("input").change(function () {
            App.skinManage.themePicUpload(callBack);
        });
    }
    App.skinManage.themePicUploading = function () {
        $("#ulState").html("图片上传中<img width=\"16\" height=\"16\" src=\"/Content/Image/loading.gif\">");
        $("#ulState").show();
        $("#themeFile").hide();
    }
    App.skinManage.themePicCallBack = function (status, imgID, imgUrl) {
        if (status == 1) {
            App.skinManage.themePicUploaded(imgID, imgUrl);
            return;
        }
        if (status == -1) {
            App.alert("上传失败，请重试");
        }
        if (status == -2) {
            App.alert("上传图片超过5M,请重新上传。");
        }
        $("#themeFile").show();
        $("#ulState").hide();
        $("#reupload").hide();
    }
    App.skinManage.themePicUploaded = function (imgID, imgUrl) {
        App.skinManage.curPicUrl = imgUrl;
        App.skinManage.curPicID = imgID;
        $("#ulState").html("上传成功");
        $("#reupload").show();
        $(".imgBox img").attr("src", imgUrl.replace("Large", "Thum"));
        App.skinManage.RenderPage();
    }

    App.skinManage.switchTopTips = function (nav, listid) {
        var item = $("#" + listid);
        if (!App.isVisible(item)) {
            $("#skin_display_main").show();
            item.nextAll().hide();
            item.prevAll().hide();
            item.show();
            $(".activeMenu").removeClass("activeMenu");
            $(nav).addClass("activeMenu");
            this.curCate = parseInt(listid.replace("t", ""));
            if ($("#t" + this.curCate).attr("class") == "set_userDefined") {
                this.curThemeId = -1;
                $(".set_chosedTemp").removeClass("set_chosedTemp onborder");
                this.RenderPage();
                this.SetBorder();
                this.isUserDefined = true;
                this.curSkinBoxHeight = 209;
                $("#innerContainer").attr("class", "set_innerDiv set_zdy");
                $("#container").attr("class", "set_interface set_expand set_zdybg");
            }
            else {
                this.isUserDefined = false;
                this.curSkinBoxHeight = 257;
                $("#innerContainer").attr("class", "set_innerDiv");
                $("#container").attr("class", "set_interface set_expand");
                this.initPage();
            }
            $("body").attr("style", "background-position: " + this.curAlignStyle + " " + this.curSkinBoxHeight + "px; background-attachment: " + this.curLock + ";");

        }
    }

    App.skinManage.nextPageTheme = function (alink) {
       var items = $("#t" + this.curCate + " li");
        var list=$("#t" + this.curCate);
        var curIndex=parseInt(list.attr("curIndex"));
        var pageNum=parseInt(items.length/12);
        curIndex++;
        list.attr("curIndex",curIndex);
        $(alink).prev().show();
        if(curIndex==pageNum){
           $(alink).hide();
        }
        items.hide();
        for(var i=curIndex*12;i<(curIndex+1)*12;i++)
        {
        if(items==null)
           break;
          $(items[i]).show();
          
        }


    }
    App.skinManage.prevPageTheme = function (alink) {
        var items = $("#t" + this.curCate + " li");
        var list=$("#t" + this.curCate);
        var curIndex=parseInt(list.attr("curIndex"));
        var pageNum=parseInt(items.length/12);
        curIndex--;
        list.attr("curIndex",curIndex);
        $(alink).next().show();
        if(curIndex==0){
           $(alink).hide();
        }
        items.hide();
        for(var i=curIndex*12;i<(curIndex+1)*12;i++)
        {
           if(items==null)
           break;
          $(items[i]).show();
        }
    }

    App.skinManage.initPage = function () {
        if ($("#t" + this.curCate).attr("class") == "set_userDefined") {
            $("#pagingContainer").hide();
            return;
        }
        var list = $("#t" + this.curCate);
        var curIndex = parseInt(list.attr("curIndex"));
        var itemCount = parseInt(list.attr("pagecount"));
        if (itemCount <= 12) {
            $("#pagingContainer").hide();
            return;
        }
        else {
            $("#pagingContainer").show();
        }
        if (curIndex == 0) {
            $("#pagePrev").hide();
        }
        else
            $("#pagePrev").show();
        if (curIndex == parseInt(itemCount / 12)) {
            $("#pageNext").hide();
        }
        else
            $("#pageNext").show();
    }

    App.skinManage.skinOut = function (ctrl) {
        if (ctrl.className != "set_chosedTemp onborder") {
            ctrl.className = "";
        }
    }

    App.skinManage.skinOver = function (ctrl) {
        if (ctrl.className != "set_chosedTemp onborder") {
            ctrl.className = "onborder";
        }
    }

    App.skinManage.setTheme = function (ctrl, tid, cssUrl) {
        this.curThemeId = tid;
        $(".set_chosedTemp").removeClass("set_chosedTemp onborder");
        ctrl.className = "set_chosedTemp onborder";
        $("#skin_transformers").remove();
        
        $("head").append(" <link id=\"skin_transformers\" rel=\"stylesheet\" type=\"text/css\" href=\" \" />");
        $("#skin_transformers").attr("href", cssUrl + "?r=" + Math.random());
        $("head style").remove();
    }

    App.skinManage.SaveTheme = function () {
        App.confirm("确定保存设定？", function () {
            var colors = "";
            for (var i = 0; i < 6; i++) {
                colors += App.skinManage.curColor[i] + ",";
            }

        });
    }

    App.skinManage.SaveTheme = function (ctrl) {
        if (ctrl.Locked)
            return;
        ctrl.Locked = true;
        var colors = "";
        for (var attr in App.skinManage.curColor) {
            colors += App.skinManage.curColor[attr] + ",";
        }
        var border = App.skinManage.curBorder;
        var lock = App.skinManage.curLock;
        var pid = App.skinManage.curPicID;
        var repeat = App.skinManage.curIsRepeat;
        var align = App.skinManage.curAlignStyle;
        var useBg = App.skinManage.IsUseBg;
        var themeId = App.skinManage.curThemeId;

        $.ajax(
       {
           url: "/Ajax/SaveTheme/",
           datatype: "json",
           cache: false,
           data: { Color: colors, Border: border, Lock: lock, Pid: pid, Repeat: repeat, Align: align, UseBg: useBg, ThemeId: themeId },
           type: "post",
           success: function (o) {
               if (o.Code == "A00003") {
                   App.alert(CodeList[o.Code]);
               }
               else if (o.Code == "A00001") {
                   App.showLoginDial();
               }
               else 
                   App.fullTip(CodeList[o.Code], 1000, "/", 3);
               ctrl.Locked = false;
           },
           error: function (request) {
               App.alert(CodeList["A00003"]);
               ctrl.Locked = false;
           }
       });
   }

   App.skinManage.cancelTheme = function () {
       App.confirm("您设置的皮肤还没有保存，确定离开吗？", function () {
           window.location.href = "/";
       });
   }

   App.skinManage.initDiyBox = function () {
       for (var attr in this.curColor) {
           $("." + attr).css("background-color", this.curColor[attr]);
       }
       $(".set_backColor6").css("background-color", this.curBorder);
       if (this.curPicID != -1 && this.curPicUrl != "") {
           $("#useBg img").attr("src", this.curPicUrl.replace(/large/i, "thum"));
       }
       if (!this.IsUseBg) {
           $("#nouseBg").attr("class", "set_nobg set_border");
           $("#useBg").attr("class", "set_bg");
           $("#themeFile").attr('disabled', 'disabled');
           $("#iLock").attr('disabled', 'disabled');
           $("#sRepeat").attr('disabled', 'disabled');
           $("#sAlignStyle").attr('disabled', 'disabled');
       }
       if (this.curLock == "scroll") {
           App.E("iLock").checked = false;
       }
       else {
           App.E("iLock").checked = true;
       }
       App.E("sRepeat").value = this.curIsRepeat;
       App.E("sAlignStyle").value = this.curAlignStyle;

   }