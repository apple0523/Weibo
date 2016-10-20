/// <reference path="Common/jquery-1.10.2.min.js" />
/// <reference path="App.js" />

var curTxt = "";
var publish_editor =null;
var checkTxtLen = function () {
    if (curTxt != publish_editor.value) {
        curTxt = publish_editor.value;
        var normal = "你还可以输入<span class=\"pipsLim\">0</span>字";
        var error = "<div class=\"word_c\"><img class=\"tipicon tip2\" alt=\"\" title=\"\" src=\"/Content/Image/transparent.gif\"><strong>已超出<span>1</span>字</strong></div><b class=\"rcorner\"></b>";
        var curLen = App.getTxtLen($("#publish_editor"));
        if (curLen <= 280) {
            $("#publisher_info").html(normal);
            $("#publisher_info").find(".pipsLim").html(parseInt((280 - curLen) / 2));
            $("#publisher_info").removeClass("error");
            if (curLen != 0) {
                $(".postBtnBg").removeClass("bgColorA_No");
            }
            else {
                $(".postBtnBg").addClass("bgColorA_No");
            }
            return true;
        }
        else {
            $("#publisher_info").html(error);
            $("#publisher_info").find("span").html(parseInt((curLen - 280 + 1) / 2));
            $("#publisher_info").addClass("error");
            $(".postBtnBg").addClass("bgColorA_No");
            return false;
        }
        
    }
};
$(document).ready(function () {
    publish_editor = $("#publish_editor")[0];
    $("#publisher_faces").click(function (e) {
        e.stopPropagation();
        return App.showExpression($("#publish_editor"), this);
    });

    $("#publisher_pic").click(function (e) {
        e.stopPropagation();
        return App.showPicUpload(this);
    });


    $("#publisher_video").click(function (e) {
        e.stopPropagation();
        return App.ShowVideoDiaDiv($("#publish_editor"), this);
    });
    $("#publisher_music").click(function () {
        return App.showMusicDiaDiv($("#publish_editor"), this);
    });
    $("#publisher_vote").click(function () {
        return App.showVote($("#publish_editor"), this);
    });
    App.bindTxtarea($("#publish_editor")[0]);
    $("#publisher_topic").click(function () {
        App.insertTopic($("#publish_editor")[0]);
    });
    $("#publisher_submit").click(function () {
        if ($("#publish_editor").val() == "") {
            App.highLineTxtBox($("#publish_editor"));
            return;
        }
        curTxt = "";
        if (!checkTxtLen()) {
            App.alert("超过字数了");
            return;
        }
        App.disableAtag($(this));
        App.CreateOriginalMiniBlog($("#publish_editor"), function () {
            App.tip("发布成功", 1000, window.location.href);
            $("#publish_editor").val("");
        }, function () {
            App.enableAtag($("#publisher_submit"));
        });
    });



    App.TimerFunArray.push(checkTxtLen);
    App.TimerFunArray.push(App.ajaxAtWho);
    App.StartTimer();
    App.initMedia();
    App.bindGoTop(curBorder);
    App.initNameCard($("#feed_list"));
});

window.onload = function () {
    var voteItems = $("div[type='vote']");
    for (var i = 0; i < voteItems.length; i++) {
        var img = $(voteItems[i]).find("img")[0];
        var img1 = $(voteItems[i]).find("img")[1];

        $(img1).css("left", parseInt(($(img).width() - 33) / 2)).css("top", parseInt(($(img).height() - 33) / 2)).css("position", "absolute");
        $(img1).show();
    }
};


