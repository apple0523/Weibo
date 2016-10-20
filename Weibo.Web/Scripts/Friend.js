/// <reference path="App.js" />
App.FriendManage = {
    groupList: [],
    curGroup: null,

    initFollowAssignBox: function () {
        var addedContaner = $(".tagList");
        var addInput = addedContaner.find("input");
        var addedValue = $("#group_member_add_input");
        addedContaner.click(function () {
            addInput.focus();
            if (addInput.val() == "") {
                App.appendToBody($(".mbf_input_layer"), "<div class=\"mbf_input_layer\" style=\"position: absolute; z-index: 1200; display: none;\">可输入关注人名称</div>");
                var offset = addInput.offset();
                $(".mbf_input_layer").show().css("left", offset.left).css("top", offset.top + addInput.height() + 5);
            }
            else {
                $(".mbf_input_layer").hide();
            }
        });
        addInput.keyup(function () {
            if (addInput.val().length > 0) {
                addInput.css("width", addInput.val().length * 13 + 6);
                $(".mbf_input_layer").hide();
            }
        }).blur(function () { $(".mbf_input_layer").hide(); });
        App.autoComplete(addInput, function (id, name) {
            if (new RegExp("a" + id + "a", "i").test(addedValue.val()))
                return;
            var newitem = $("<li id='tag{1}' class=\"tagListli\">{0}<a href=\"javascript:void(0);\" class=\"close\"><img src=\"/Content/Image/close.gif\"></a></li>".replace("{0}", name).replace("{1}", id));
            newitem.insertBefore(addInput.parent());
            newitem.find(".close").click(function () {
                addedValue.val(addedValue.val().replace("a" + newitem.attr("id").replace("tag", "") + "a,", ""));
                newitem.remove();

            });
            addInput.css("width", 6);
            addInput.val("");
            App.OriKey = "";
            addedValue.val(addedValue.val() + "a" + id + "a,");
        }, "GetFollowListByKey");
        $(".arrowup").click(function (e) {
            e.stopPropagation();
            App.FriendManage.showFollowLayer(addedContaner, function () { });

        });
        $("#group_member_add_btton").click(function () {
            if (addedValue.val() == "") {
                return;
            }
            if (this.locked)
                return;
            this.locked = true;
            var btn = this;
            $.ajax({
                dataType: "json",
                data: { gid: App.FriendManage.curGroup.ID, follows: addedValue.val().replace(/a/ig, "") },
                url: "/Ajax/AssignFollowsToGroup/",
                cache: false,
                type: "post",
                success: function (o) {
                    if (o.Code == "A00001") {
                        App.showLoginDial();

                    }
                    else if (o.Code == "A00003") {
                        App.alert(CodeList[o.Code]);

                    }
                    else if (o.Code = "A00004") {
                        App.fullTip(CodeList[o.Code], 1000, "/"+App.config.curUid+"/follow", 3);
                    }
                    btn.locked = false;
                },
                error: function () {
                    App.alert(CodeList["A00003"]);
                    btn.locked = false;
                }
            });
        });
    },
    followLayer: "<div class=\"mbFollowLayer\" style=\"position: absolute;z-index: 900;\"><div class=\"mflshadow_right\"></div><div class=\"mflshadow_bottom\"></div><div class=\"mbf_tag\"><ul></ul></div><div class=\"mbFL_person\"></div><div class=\"mbFL_comment\" style=\"display: none;\"><p class=\"txt\"><img title=\"\" alt=\"\" src=\"/Content/Image/transparent.gif\" class=\"tipicon tip5\">&nbsp;该分组没有关注人。</p></div><div class=\"mbFL_person_bottom\"><a id='closeLayer' class=\"btn_normal btnxs lf\" href=\"javascript:void(0);\"><em>关闭</em></a><div id='boxPage' class=\"fanye rt\"></div></div></div>",
    showFollowLayer: function (showWhere, itemClickCallBack) {
        var layer = $(".mbFollowLayer");
        if (App.appendToBody($(".mbFollowLayer"), this.followLayer)) {
            layer = $(".mbFollowLayer");
            layer.JQP_ClickOther(function () { layer.hide(); });
            $("#closeLayer").click(function () { layer.hide(); });
            tagTemplate = "<li title=\"{name}\"><div class=\"mbf_tago\"><span  onclick=\"App.FriendManage.TabFollowLayer(this);App.FriendManage.getFollowsToAssignBox('{type}','{gid}',1,12)\" style=\"display: none;\"><a href=\"javascript:void(0)\">{name}</a></span><span style=\"\">{name}</span></div></li>";
            tagTemplate1 = "<li title=\"{name}\"><div class=\"mbf_tagn\"><span gid='{gid}' onclick=\"App.FriendManage.TabFollowLayer(this);App.FriendManage.getFollowsToAssignBox('{type}','{gid}',1,12)\" style=\"\"><a href=\"javascript:void(0)\">{name}</a></span><span style=\"display: none;\">{name}</span></div></li>";
            var str = [];
            str.push(tagTemplate.replace(/\{name\}/ig, "全部").replace("{type}", "all").replace(/\{gid\}/gi, -1));
            str.push(tagTemplate1.replace(/\{name\}/ig, "未分组").replace("{type}", "ng").replace(/\{gid\}/gi, -1));
            if (this.groupList.length < 4) {
                for (var i = 0; i < this.groupList.length; i++) {
                    var name = "";
                    if (App.byteLength(this.groupList[i].Name) > 8) {
                        name = App.GetStringByte(this.groupList[i].Name, 8) + "...";
                    }
                    else {
                        name = this.groupList[i].Name;
                    }
                    str.push(tagTemplate1.replace(/\{name\}/ig, name).replace("{type}", "-1").replace(/\{gid\}/gi, this.groupList[i].ID));
                }
            }
            else {
                for (var i = 0; i < 4; i++) {
                    var name = "";
                    if (App.byteLength(this.groupList[i].Name) > 8) {
                        name = App.GetStringByte(this.groupList[i].Name, 8) + "...";
                    }
                    else {
                        name = this.groupList[i].Name;
                    }
                    str.push(tagTemplate1.replace(/\{name\}/ig, name).replace("{type}", "-1").replace(/\{gid\}/gi, this.groupList[i].ID));
                }
                str.push("<li><div class=\"mbf_last\"><span><a href=\"javascript:void(0);\"><img class=\"mbfl_sicon\" src=\"/Content/Image/transparent.gif\"></a></span></div><div class=\"mbfl_other\" style=\"top: 29px; left: -99px; z-index: 1000;display:none;\"><ul>");
                for (var i = 4; i < this.groupList.length; i++) {
                    str.push(("<li  gid='{gid}' onclick=\"App.FriendManage.getFollowsToAssignBox('{type}','{gid}',1,12);App.FriendManage.liToTab(this,event);\"><a href=\"javascript:void(0);\">" + this.groupList[i].Name + "</a></li>").replace("{type}", -1).replace(/\{gid\}/gi, this.groupList[i].ID));
                }
                str.push("</ul></div></div></li>");
            }
            layer.find(".mbf_tag ul").html(str.join(""));
            var otherLayer = $(".mbfl_other");
            otherLayer.JQP_ClickOther(function () { otherLayer.hide(); });
            $(".mbf_last").click(function (e) { e.stopPropagation(); otherLayer.show(); });

        }
        showWhere = $(showWhere);
        var offset = showWhere.offset();
        layer.css("left", offset.left).css("top", offset.top + showWhere.height() + 5);
        layer.show();

        $(".mbf_tag li:first span:first").click();
    },
    TabFollowLayer: function (ctrl) {
        if (ctrl.style.display != "none") {
            $(".mbf_tago").attr("class", "mbf_tagn").find("span").hide()[0].style.display = "block";
            $(ctrl).hide().next().show().parent().attr("class", "mbf_tago");

        }

    },
    liToTab: function (ctrl, event) {
        $(".mbf_tago").attr("class", "mbf_tagn").find("span").hide()[0].style.display = "block";
        var li = $(ctrl);
        var tab = $($(".mbf_tag li")[5]);
        var liName = li.find("a").text();
        var tabName = $(tab.find("span")[1]).text();
        var ligid = li.attr("gid");
        var tabgid = tab.find("span:first").attr("gid");
        tab.html("<div class=\"mbf_tago\"><span gid='{gid}'  onclick=\"App.FriendManage.TabFollowLayer(this);App.FriendManage.getFollowsToAssignBox('{type}','{gid}',1,12)\" style=\"display: none;\"><a href=\"javascript:void(0)\">{name}</a></span><span style=\"\">{name}</span></div>".replace(/\{name\}/ig, liName).replace("{type}", "-1").replace(/\{gid\}/gi, ligid));
        tab.attr("title", liName);
        $(("<li  gid='{gid}' onclick=\"App.FriendManage.getFollowsToAssignBox('{type}','{gid}',1,12);App.FriendManage.liToTab(this,event);\"><a href=\"javascript:void(0);\">" + tabName + "</a></li>").replace("{type}", -1).replace(/\{gid\}/gi, tabgid)).insertAfter(li);
        li.remove();
        if ($.browser.msie) {
            event.cancelBubble = true;
            event.returnValue = false;
        }
        else {
            event.preventDefault();
            event.stopPropagation();
        }
    },
    getFollowsToAssignBox: function (type, gid, page, pagesize) {
        var container = $(".mbFL_person");
        var noperson = $(".mbFL_comment");
        $.ajax({
            dataType: "json",
            data: { type: type, gid: gid, page: page, pagesize: pagesize },
            url: "/Ajax/GetFollowByAssignBox/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00017") {
                    container.hide();
                    noperson.show();
                    $("#boxPage").html("");
                    return;
                }
                if (o.Code == "A00001") {
                    App.showLoginDial();
                    return;
                }
                if (o.Code == "A00003") {
                    App.alert(CodeList[o.Code]);
                    return;
                }
                var template = "<li id='li{ID}' style=\"display: block;\" class=\"\" title=\"{Name}\"><div class=\"mbFL_top\"></div><div class=\"mbFL_cen\"><div class=\"head_pic\"><a><img class=\"picborder_l\" src=\"{avatar}\"></a><img class=\"tipicon tip3\" src=\"/Content/Image/transparent.gif\" style=\"display: none;\"></div><div class=\"mbFLcen_con\"><p class=\"head_name\">{Title}</p><p></p></div></div><div class=\"mbFL_bottom\"></div></li>";
                var template1 = "<li id='li{ID}' style=\"display: block;\" class=\"mbFL_current\" title=\"{Name}\"><div class=\"mbFL_top\"></div><div class=\"mbFL_cen\"><div class=\"head_pic\"><a><img class=\"picborder_l\" src=\"{avatar}\"></a><img class=\"tipicon tip3\" src=\"/Content/Image/transparent.gif\" style=\"\"></div><div class=\"mbFLcen_con\"><p class=\"head_name\">{Title}</p><p></p></div></div><div class=\"mbFL_bottom\"></div></li>";
                var str = [];

                str.push("<ul>");
                var follows = o.Data;
                for (var i = 0; i < follows.length; i++) {
                    var isSel = false;
                    if (new RegExp("a" + follows[i].ID + "a", "i").test($("#group_member_add_input").val()))
                        isSel = true;
                    if (isSel)
                        str.push(template1.replace("{Name}", follows[i].NickName).replace("{ID}", follows[i].ID).replace("{Title}", follows[i].Title).replace("{avatar}", follows[i].avatar));
                    else
                        str.push(template.replace("{Name}", follows[i].NickName).replace("{ID}", follows[i].ID).replace("{Title}", follows[i].Title).replace("{avatar}", follows[i].avatar));

                }
                str.push("</ul>");
                container.show();
                noperson.hide();
                container.html(str.join(""));
                container.find("li").mouseenter(function () { if (this.className != "mbFL_current") this.className = "mbFL_hover" }).mouseleave(function () { if (this.className != "mbFL_current") this.className = "" }).click(function () {
                    var addedContaner = $(".tagList");
                    var addInput = addedContaner.find("input");
                    var addedValue = $("#group_member_add_input");
                    var id = $(this).attr("id").replace("li", "");
                    if (this.className == "mbFL_current") {
                        $(this).find("img:last").hide();
                        this.className = "";
                        addedValue.val(addedValue.val().replace("a" + id + "a,", ""));
                        $("#tag" + id).remove();
                    }
                    else {
                        if (new RegExp("a" + id + "a", "i").test(addedValue.val()))
                            return;
                        var newitem = $("<li id='tag{1}' class=\"tagListli\">{0}<a href=\"javascript:void(0);\" class=\"close\"><img src=\"/Content/Image/close.gif\"></a></li>".replace("{0}", $(this).attr("title")).replace("{1}", id));
                        newitem.insertBefore(addInput.parent());
                        newitem.find(".close").click(function () {
                            addedValue.val(addedValue.val().replace("a" + newitem.attr("id").replace("tag", "") + "a,", ""));
                            newitem.remove();

                        });
                        this.className = "mbFL_current";
                        addedValue.val(addedValue.val() + "a" + id + "a,");
                        $(this).find("img:last").show();
                    }
                    var layer = $(".mbFollowLayer");
                    var offset = addedContaner.offset();
                    layer.css("left", offset.left).css("top", offset.top + addedContaner.height() + 5);
                    layer.show();
                });

                App.FriendManage.buildFollowPage(o, type, gid, page, pagesize);

            },
            error: function () {
                if (o.Code == "A00003") {
                    App.alert(CodeList[o.Code]);
                    return;
                }
            }
        });
    },
    buildFollowPage: function (data, type, gid, page, pagesize) {
        if (typeof (data) == "object") {
            if (data.Count > 0) {
                var t = [];
                var size = pagesize;
                var pageNum = parseInt(data['Count'] / size);

                //get the total page number
                if (data['Count'] % size > 0) {
                    pageNum++;
                };

                if (pageNum > 0) {

                    //the section of prev page
                    if (page > 1) {
                        t.push('<a class="btn_num" href="javascript:;" onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + (page - 1) + ',' + pagesize + ');return false;"><em>上一页</em></a> ');
                    }

                    //if the total page number less than 6
                    if (pageNum < 6) {
                        for (var i = 1; i <= pageNum; i++) {
                            if (page == i) {
                                t.push('<span>' + i + '</span> ');
                            }
                            else {
                                t.push('<a class="btn_num" href="javascript:;"onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + i + ',' + pagesize + ');return false;"><em>' + i + '</em></a> ');
                            }
                        }
                    }
                    else {

                        //if the current page nummber less than 4
                        if (page < 4) {

                            for (var i = 1; i <= 5; i++) {
                                if (page == i) {
                                    t.push('<span>' + i + '</span> ');
                                }
                                else {
                                    t.push('<a class="btn_num" href="javascript:;"onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + i + ',' + pagesize + ');return false;"><em>' + i + '</em></a> ');
                                }
                            }
                            t.push('...<a href="javascript:;" class="btn_num" onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + pageNum + ',' + pagesize + ');return false;"><em>' + pageNum + '</em></a> ');
                        }
                        else if ((pageNum - 3) < page) {

                            t.push('<a class="btn_num" href="javascript:;" onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + 1 + ',' + pagesize + ');return false;"><em>' + 1 + '</em></a>...');
                            for (var i = (pageNum - 4); i <= pageNum; i++) {
                                if (page == i) {
                                    t.push('<span>' + i + '</span> ');
                                }
                                else {
                                    t.push('<a class="btn_num" href="javascript:;"onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + i + ',' + pagesize + ');return false;"><em>' + i + '</em></a> ');
                                }
                            }
                        }
                        else if (3 < page < (pageNum - 2)) {

                            t.push('<a class="btn_num" href="javascript:;" onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + 1 + ',' + pagesize + ');return false;"><em>' + 1 + '</em></a>...');
                            for (var i = (parseInt(page) - 2); i <= (parseInt(page) + 2); i++) {
                                if (page == i) {
                                    t.push('<span>' + i + '</span> ');
                                }
                                else {
                                    t.push('<a class="btn_num" href="javascript:;"onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + i + ',' + pagesize + ');return false;"><em>' + i + '</em></a> ');
                                }
                            }
                            t.push('...<a class="btn_num" href="javascript:;" onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + pageNum + ',' + pagesize + ');return false;"><em>' + pageNum + '</em></a> ');
                        }
                    };

                    //the section of next page
                    if (page < pageNum) {
                        t.push('<a class="btn_num" href="javascript:;" onclick="App.FriendManage.getFollowsToAssignBox(\'' + type + '\',\'' + gid + '\',' + (page + 1) + ',' + pagesize + ');return false;"><em>下一页</em></a>');
                    }
                };
                $("#boxPage").html(t.join(''));
            } else {
                $("#boxPage").html('');
            }

        }

    }

}

App.FriendManage.delGroup = function (ctrl, gid) {
    App.confirm("确定要删除\" " + this.curGroup.Name + " \"分组吗？<br />此分组下的人不会被取消关注。", function () {
        $.ajax({
            dataType: "json",
            data: { gid: gid },
            url: "/Ajax/DelGroup/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00018") {
                    App.fullTip("删除成功", 1000, "/" + App.config.curUid + "/follow", 3);
                    return;
                }
                if (o.Code == "A00001") {
                    App.showLoginDial();
                    return;
                }
                if (o.Code == "A00003") {
                    App.alert(CodeList[o.Code]);
                    return;
                }
            },
            error: function () {
                App.alert(CodeList["A00003"]);
            }
        });
    });
}
App.FriendManage.showGroupSelector = function (ctrl) {
    ctrl = $(ctrl);
    var layer = $(".cetdowme");
    layer.attr("curUid", ctrl.attr("personid"));
    var offset = ctrl.offset();
    layer.css("top", offset.top + 5 + ctrl.height()).css("left", offset.left).show();
    var groupArr = ctrl.attr("groupids").replace(/a/ig, "").split(',');
    layer.find('input:checkbox').each(function () {
        this.checked = false;
    });
    for (var i = 0; i < groupArr.length - 1; i++) {
        $("#group_selector_item_" + groupArr[i])[0].checked = true;
    }
}
App.FriendManage.initGroupCheckClick = function (checkbox) {
    var layer = $(".cetdowme");
    $(checkbox).click(function () {
        if (this.checked) {
            var uid = layer.attr("curUid");
            var gid = $(this).attr("ID").replace(/[^0-9]+/ig, "");
            $.ajax({
                dataType: "json",
                data: { uid: uid, gid: gid },
                url: "/Ajax/EditFollowGroup/",
                cache: false,
                type: "post",
                success: function (o) {
                    if (o.Code == "A00004") {
                        var groupNames = o.Data.split('|')[0];
                        var groupIds = o.Data.split('|')[1];
                        $("a[personid='" + uid + "']").attr("title", groupNames).attr("groupids", groupIds).find("em").html(groupNames + "<img class=\"small_icon down_arrow\" src=\"/Content/Image/transparent.gif\">");
                    }
                    else if (o.Code == "A00001") {
                        App.showLoginDial();
                    }
                    else {
                        App.fullTip(CodeList["A00003"], 1000, null, 1);
                    }
                },
                error: function () {
                    App.fullTip(CodeList["A00003"], 1000, null, 1);
                }
            });
        }
        else {
            var uid = layer.attr("curUid");
            var gid = $(this).attr("ID").replace(/[^0-9]+/ig, "");
            $.ajax({
                dataType: "json",
                data: { uid: uid, gid: gid },
                url: "/Ajax/DelFollowGroup/",
                cache: false,
                type: "post",
                success: function (o) {
                    if (o.Code == "A00004") {
                        var groupNames = o.Data.split('|')[0];
                        var groupIds = o.Data.split('|')[1];
                        $("a[personid='" + uid + "']").attr("title", groupNames).attr("groupids", groupIds).find("em").html(groupNames + "<img class=\"small_icon down_arrow\" src=\"/Content/Image/transparent.gif\">");
                    }
                    else if (o.Code == "A00001") {
                        App.showLoginDial();
                    }
                    else {
                        App.fullTip(CodeList["A00003"], 1000, null, 1);
                    }
                },
                error: function () {
                    App.fullTip(CodeList["A00003"], 1000, null, 1);
                }
            });
        }
    });
}
App.FriendManage.initGroupSelector = function () {
    var layer = $(".cetdowme");
    var error = layer.find(".error_color");
    var checkboxs = layer.find("input[type='checkbox']");
    this.initGroupCheckClick(checkboxs);
    $(".btn_privacy").click(function (e) { e.stopPropagation(); App.FriendManage.showGroupSelector(this) });
    layer.JQP_ClickOther(function () { layer.hide(); layer.attr("curUid", ""); });
    var groupSelItems = $("p[sel='1']");
    groupSelItems.mouseenter(function () {
        groupSelItems.css("class", ""); this.className = "hover";
    }).mouseleave(function () { this.className = ""; });
    layer.find("#gcBtn").click(function () {
        $(this).parent().prev().hide().next().hide().nextAll().show();
        $(".cetdowme .error_color").hide();
    });
    layer.find(".btn").find("a:last").click(function () {
        layer.find(".MIB_linedot1").show().next().show().nextAll().hide();
    }).prev().click(function () {
        var input = layer.find("input[type='text']");
        if ($.trim(input.val()) == "") {
            error.text("请输入分组名");
            error.show();
            return false;
        }
        var len = App.byteLength(input.val());
        if (len > 16) {
            error.text("请不要超过16个字符");
            error.show();
            return false;
        }
        if (this.locked)
            return false;
        this.locked = true;
        var thisBtn = this;
        $.ajax({
            dataType: "json",
            data: { Name: $.trim(input.val()) },
            url: "/Ajax/AddGroup/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00009") {
                    if (groupSelItems[0])
                        $("<p sel=\"1\"><input type=\"checkbox\" class=\"labelbox\" id=\"group_selector_item_{id}\"><label for=\"group_selector_item_{id}\" title=\"{name}\">{name}</label></p>".replace(/\{name\}/ig, o.Data.Name).replace(/\{id\}/ig, o.Data.ID)).insertAfter(groupSelItems.last());
                    else
                        $("<p sel=\"1\"><input type=\"checkbox\" class=\"labelbox\" id=\"group_selector_item_{id}\"><label for=\"group_selector_item_{id}\" title=\"{name}\">{name}</label></p>".replace(/\{name\}/ig, o.Data.Name).replace(/\{id\}/ig, o.Data.ID)).insertBefore(layer.find(".MIB_linedot1"));
                    if ($(".mbFollowLayer")[0])
                        $(".mbFollowLayer").remove();
                    App.FriendManage.groupList.push(o.Data);
                    App.FriendManage.initGroupCheckClick($("#group_selector_item_" + o.Data.ID));
                    $("p[sel='1'] :last").mouseenter(function () {
                        $("p[sel='1']").css("class", ""); this.className = "hover";
                    }).mouseleave(function () { this.className = ""; });
                    layer.find(".MIB_linedot1").show().next().show().nextAll().hide();
                }
                else if (o.Code == "A00015") {
                    error.text(CodeList[o.Code]);
                    error.show();
                }
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else {
                    App.fullTip(CodeList["A00003"], 1000, null, 1);
                }
                thisBtn.locked = false;
            },
            error: function () {
                App.fullTip(CodeList["A00003"], 1000, null, 1);
                thisBtn.locked = false;
            }
        });
    });
}

App.FriendManage.cancelFollow = function (id, name, alink) {
    if (alink.locked)
        return;
    App.miniConfirm("是否取消关注" + name, alink, function () {

        alink.locked = true;
        App.CancelFollow(id, function (ID, O) {
            $("li[id='" + id + "']").fadeOut();
        }, function () { alink.locked = false; });
    });

};
App.FriendManage.cancelFan = function (id, name, alink) {
    if (alink.locked)
        return;
    App.miniConfirm("是否移除" + name, alink, function () {

        alink.locked = true;
        App.CancelFan(id, function (ID, O) {
            $("li[id='" + id + "']").fadeOut();
        }, function () { alink.locked = false; });
    });

};

App.FriendManage.follow = function (id, name, alink) {
    if (alink.locked)
        return false;
    alink.locked = true;
    App.FollowOne(id, name, function (Id, Name, o) {
        $('<p class="mutual"><img class="small_icon sicon_atteo" title="互相关注中" src="/Content/Image/transparent.gif"></p>').insertAfter($(alink).parent());
        $(alink).parent().remove();
    }, function () {
        alink.locked = false;
    });
}

App.FriendManage.followOne = function (id, name, alink) {
    if (alink.locked)
        return false;
    alink.locked = true;
    App.FollowOne(id, name, function (Id, Name, o) {
        $("<a href='javascript:void(0);' class='concernBtn_Yet'><span class='add_yet'></span>已关注</a>").insertAfter($(alink));
        $(alink).remove();
    }, function () {
        alink.locked = false;
    });
};