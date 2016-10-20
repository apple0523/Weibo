/// <reference path="Common/jquery-1.10.2.js" />
//Layer
var dialDiv = "<div {id} class='4CancelAllLayer' style='position: absolute; z-index: 1600;'><table class='mBlogLayer'><tbody><tr><td class='top_l'></td><td class='top_c'></td><td class='top_r'></td></tr><tr><td class='mid_l'></td><td class='mid_c'></td><td class='mid_r'></td></tr><tr><td class='bottom_l'></td><td class='bottom_c'></td><td class='bottom_r'></td></tr></tbody></table></div>";
var mashDiv = "<div id='mashDiv' style=\"position: fixed;width:100%;height:100%;left:0px;top:0px; background-color: rgb(0, 0, 0);  z-index: 599;  opacity: 0.15; filter:alpha(opacity=15);\"></div>";
//Login
var loginConDiv = "<div class=\"layerBox\"><div style=\" width:530px;\" class=\"layerBoxCon\"><div class=\"layerSmartlogin\"><div class=\"layerMedia_close\"><a class=\"close\" href=\"javascript:void(0);\"></a></div><div id=\"mod_reg_login_yellow\" class=\"yellowBg\" style=\"display: none;\">如果你已开通过微博账号，可以直接<a onclick=\"App.showLoginDialBackLogin();\" href=\"javascript:void(0);\">登录</a></div><div id=\"mod_reg_information_box\" class=\"infoForm\" style=\"display: none;\"><div class=\"infoReg\"><table class=\"tab2\"> <tbody><tr><th><span>电子邮箱：</span></th><td class=\"td1\"><input type=\"text\" name=\"username\" id=\"mod_reg_username\" autocomplete=\"off\" class=\"inp\"></td><td id=\"mod_red_reg_username\"></td></tr><tr><th><span>设置密码：</span></th><td class=\"td1\"><input type=\"password\" name=\"password\" id=\"mod_reg_password\" class=\"inp\">	</td><td id=\"mod_red_reg_password\"></td></tr><tr><th><span>再次输入密码：</span></th><td class=\"td1\"><input type=\"password\" name=\"password2\" id=\"mod_reg_repassword\" class=\"inp\"></td><td id=\"mod_red_reg_repassword\"></td></tr><tr><th><span>验证码：</span></th><td class=\"td1\"><input type=\"text\" style=\"width:40px\" name=\"basedoor\" id=\"mod_reg_door\" class=\"inp w1\"><img width=\"90\" height=\"31\" align=\"absmiddle\" id=\"mod_reg_check_img\" style=\"margin:5px 0;\" src=\"/user/GetCheckCode/\"><a  href=\"javascript:App.refreshCheckCode('mod_reg_check_img');\">换一个</a></td><td id=\"mod_red_reg_door\"></td></tr><tr><th>&nbsp;</th><td class=\"td1\"><div class=\"lf\"><input type=\"checkbox\" value=\"1\" name=\"after\" checked=\"checked\" class=\"labelbox\" id=\"mod_reg_after\"><label for=\"chbb\">我同意<a target=\"_blank\" href=\"##\">《网络使用协议》</a></label></div></td><td id=\"mod_red_reg_after\"></td></tr><tr><th>&nbsp;</th><td class=\"td1\"><a id=\"mod_reg_submit\" class=\"btnlogin1\" href=\"javascript:void(0);\" onclick=\"\"></a></td><td>&nbsp;</td></tr></tbody></table></div>	<div class=\"clearit\"></div></div><div id=\"mod_reg_login_box\" class=\"infoForm\"><div class=\"infoLeft\"><table class=\"tab1\"><caption>已有新浪博客、新浪邮箱账号，可直接登录</caption><tbody><tr>	<th scope=\"row\" ><div style=\"display: none; position: absolute; margin-top: -40px; margin-left: 0px; z-index: 2000;\" id=\"mod_login_tip\" class=\"errorLayer\"><div class=\"top\"></div><div class=\"mid\"><div id=\"mod_login_close\" onclick=\"$('#mod_login_tip').hide();\"  class=\"close\">x</div><div class=\"conn\"><p id=\"mod_login_title\" class=\"bigtxt\"></p><span style=\"padding: 0px; display: none;\" id=\"mod_login_content\" class=\"stxt\"></span></div></div><div class=\"bot\"></div></div></th></tr><tr><td><div class=\"lgsz_wrap\"><input type=\"text\" id=\"mod_loginname\" class=\"inp\" style=\"color: rgb(153, 153, 153);\" autocomplete=\"off\" value=\"邮箱/会员帐号/手机号\" title=\"邮箱/会员帐号/手机号\" alt=\"邮箱/会员帐号/手机号\"></div></td></tr><tr><td><input type=\"text\" value=\"请输入密码\" id=\"mod_password_text\" class=\"inp\" style=\"color: rgb(153, 153, 153);\"><input type=\"password\" id=\"mod_password\" class=\"inp\" style=\"display: none;\"></td></tr>	<tr><th><a id=\"mod_login_submit\" class=\"btn_normal\" href=\"javascript:void(0);\"><em>登录</em></a><input type=\"checkbox\" checked=\"checked\" class=\"chkb\" id=\"mod_isremember\"><label for=\"mod_isremember\">下次自动登录</label></th></tr></tbody></table></div><div class=\"infoRight\"><p class=\"p1\">还未开通？赶快免费注册一个吧！</p><p class=\"p2\"><a onclick=\"App.showLoginDial2Reg();return false;\" class=\"btnlogin1\" href=\"javascript:void(0);\" ></a></p></div><div class=\"clearit\"></div></div></div></div></div>";
var vailRedDiv = "<span class=\"iswhat iserro\"><img title=\"\" alt=\"\" src=\"/Content/Image/transparent.gif\" class=\"tipicon tip2\"><em>请输入验证码</em></span>";
var vailOk = "<span class=\"iswhat isok\"><img title=\"\" alt=\"\" src=\"/Content/Image/transparent.gif\" class=\"tipicon tip3\"></span>";
//Tip
var alertConDiv = "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong>提示</strong><a title=\"关闭\" class=\"close\" href=\"javascript:;\"></a><div class=\"clear\"></div></div></div><div class=\"layerBoxCon\" style=\"width: 360px; height: auto;\"><div class=\"commonLayer2\"><div class=\"layerL\"><img align=\"absmiddle\" title=\"\" alt=\"\" src=\"/Content/Image/PY_ib.gif\" class=\"PY_ib PY_ib_1\"></div><div class=\"layerR\"></div><div class=\"clear\"></div>	<div class=\"MIB_btn\">	<a class=\"btn_normal\" id=\"btn_AlterClose\" href=\"javascript:;\"><em>确定</em></a></div></div></div></div>";
var confirmConDiv = "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong>提示</strong><a title=\"关闭\" class=\"close\" href=\"javascript:;\"></a><div class=\"clear\"></div></div></div><div class=\"layerBoxCon\" style=\"width: 390px; height: auto;\"><div class=\"commonLayer2\">                        	<div class=\"layerL\"><img align=\"absmiddle\" title=\"\" alt=\"\" src=\"/Content/Image/PY_ib.gif\" class=\"PY_ib PY_ib_4\"></div><div class=\"layerR\"><strong></strong><div class=\"MIB_btn\"><a class=\"btn_normal\" id=\"Btn_ConfirmOk\" href=\"javascript:;\"><em>确定</em></a>	<a class=\"btn_notclick\" id=\"Btn_ConfirmCancel\" href=\"javascript:;\"><em>取消</em></a></div></div><div class=\"clear\"></div></div></div></div>";
var tipConDiv = "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong>提示</strong><a title=\"关闭\" class=\"close\" href=\"javascript:;\"></a><div class=\"clear\"></div></div></div><div class=\"layerBoxCon\" style=\"width: 490px; height: auto;\">			<div style=\"padding-top:0\" class=\"commonLayer2\">	                <div class=\"zok\">	</div>            </div></div></div>";
var fullTipConDiv = "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong>提示</strong><a title=\"关闭\" class=\"close\" href=\"javascript:;\"></a><div class=\"clear\"></div></div></div><div class=\"layerBoxCon\" style=\"width: 360px; height: auto;\"><div class=\"commonLayer2\"><div class=\"layerL\"><img align=\"absmiddle\" title=\"\" alt=\"\" src=\"/Content/Image/PY_ib.gif\" class=\"PY_ib PY_ib_3\"></div><div class=\"layerR\"> <strong>设置成功！</strong></div><div class=\"clear\"></div> <div style=\"height:0;\" class=\"MIB_btn\"> <a class=\"btn_normal\" id=\"btn_1316141348355\" href=\"javascript:;\"><em>确定</em></a></div></div></div></div>";
//Mini
var miniConfirmDiaDiv = "<div id='miniConfirm' style=\"position: absolute; clear: both;  z-index: 1701;width: 202px; height:0px;\"><div style=\"\"><div style=\"width:200px;\" class=\"miniPopLayer\"><div class=\"txt1 gray6\"><img src=\"/Content/Image/PY_ib.gif\" class=\"tipicon tip4\"><div id='Content'></div></div><div class=\"btn\" style=\"\"><span><a  href=\"javascript:void(0)\" class=\"newabtn_ok\" style=\"width:39px;\"><em>确定</em></a></span><span><a  href=\"javascript:void(0)\" class=\"newabtn_ok\" style=\"width:39px;\"><em>取消</em></a></span></div></div></div></div>";
var miniTipDiaDiv = "<div id=\"miniTip\" style=\"position: absolute; clear: both; z-index: 1700; width: 202px; height: 0px; overflow: hidden;\"><div style=\"\"><div style=\"width:200px;\" class=\"miniPopLayer\"><div class=\"txt1 gray6\"><img src=\"/Content/Image/PY_ib.gif\" class=\"tipicon tip3\"><div id=\"Content\"></div></div><div class=\"btn\" style=\"display:none\"></div></div></div></div>";
//Expression
var expressionConDiv = "<div class=\"layerBox phiz_layerN\"><div class=\"layerBoxTop\"><div style=\"left:6px;\" class=\"layerArrow\"></div><div class=\"topCon\"><ul class=\"phiz_menu\"><li class=\"cur\"><a onclick=\"this.blur();return false;\" href=\"#\">常用表情</a></li></ul><a class=\"close\" title=\"关闭\" onclick=\"return false;\" href=\"#\"></a><div class=\"clearit\"></div></div></div><div class=\"magicT\"><div class=\"magicTL\"><ul></ul></div><div class=\"magicTR\"><a title=\"上一页\" class=\"magicbtnL01\" onclick=\"return false;\" href=\"#\"></a><a class=\"magicbtnR02\" title=\"下一页\" onclick=\"return false;\" href=\"#\"></a></div><div class=\"clear\"></div></div><div style=\"width:450px;\" class=\"layerBoxCon\"><div class=\"faceItemPicbgT\"><ul></ul><div class=\"clearit\"></div></div><div class=\"faceItemPicbg\"><ul><center><img src=\"/Content/Image/loading.gif\" style=\"margin-top:10px;margin-bottom:10px\"></center></ul><div class=\"clearit\"></div></div><div class=\"magicB\"></div></div></div>";
//picUpload
var picUploadCondiv="<div class=\"layerBox phiz_layerN\"><div class=\"layerBoxTop\" style=\"width: 100%;\"><div class=\"layerArrow\"></div><div class=\"topCon\" style=\"width: 378px;\"><ul class=\"phiz_menu\"><li class=\"cur\"><a  href=\"javascript:void(0)\">上传图片</a></li></ul><a class=\"close\" href=\"javascript:void(0)\" title=\"关闭\"></a><div class=\"clearit\"></div></div></div><div><div  class=\"layerBoxCon\"><div style=\"position:relative;\" class=\"local_pic\"><a href=\"javascript:void(0)\" style=\"overflow:hidden;position:relative;\" class=\"btn_green\"><em>从电脑选择图片</em><form target=\"ifrPicUpload\" id=\"frmPicUpload\" enctype=\"multipart/form-data\" method=\"POST\" action=\"/PicUpload/MyProfileUpload/\"><input type=\"file\"  name=\"pic1\" style=\"outline: medium none; width: 75px; height: 25px; \" hidefoucs=\"true\"></form></a><p class=\"gray9\">仅支持JPG、GIF、PNG图片文件，且文件小于5M</p></div></div></div></div>";
var picUploadingCondiv = "<div class=\"layerBox phiz_layerN\"><div><div style=\"width:258px;\" class=\"layerBoxCon1\"><div class=\"layerMedia\"><div style=\"left:25px\" class=\"layerArrow\"></div><div class=\"statusBox\"><span class=\"status_p\"><img src=\"/Content/Image/loading.gif\">请等待图片上传 ...</span><span class=\"status_b\"><a class=\"btn_normal\"  href=\"javascript:void(0)\"><em> 取消上传 </em></a></span></div></div></div></div></div>";
var picUploadedCondiv = "<div class=\"layerBox phiz_layerN\"><div><div style=\"width:258px;\" class=\"layerBoxCon1\"><div class=\"layerMedia\"><div style=\"left:25px\" class=\"layerArrow\"></div><div class=\"cur_status\"><a class=\"dele\"  href=\"javascript:void(0)\">删除</a><strong></strong></div><div class=\"cur_pic\"><center><img style=\"display: none;\" onload=\"this.style.display='block';\"></center></div></div></div></div></div>";
//videoLink
var videoCondiv = "<div class=\"layerBox\"><div class=\"layerBoxCon1\" style=\"width: 368px; height: auto;\"><div class=\"layerMedia\"><div class=\"layerArrow\"></div><div class=\"layerMedia_close\"><strong></strong><a title=\"关闭\" class=\"close\" href=\"javascript:void(0);\"></a></div>							<div class=\"layerMedia_tip02\"><em class=\"num\">1.</em><span class=\"title\">输入视频网站播放页链接地址</span><br>目前已支持<a target=\"_blank\" href=\"http://www.youku.com\">优酷网</a>、<a target=\"_blank\" href=\"http://www.tudou.com\">土豆网</a>、<a target=\"_blank\" href=\"http://www.ku6.com/\">酷6网</a>、<a target=\"_blank\" href=\"http://www.56.com/\">56网</a>等网站</div>                    <div class=\"layerMedia_input\" id=\"musicinput\">                    	<input type=\"text\" class=\"layerMusic_txt\" id=\"vinput\" style=\"color: rgb(153, 153, 153);\">                        <a href=\"javascript:void(0)\" class=\"btn_normal\" id=\"vsubmit\"><em>确定</em></a>                    </div>                    <p style=\"display:none\" class=\"layerMedia_err error_color\" id=\"vredinfo\">你输入的链接地址无法识别:)</p>					<p style=\"display:none;\" class=\"mail_pl\" id=\"normalact\"><a id=\"vcancel\" href=\"javascript:void(0);\">取消操作</a>或者<a id=\"vback\" href=\"javascript:void(0);\">作为普通的链接发布</a>。</p></div></div></div>";

//musicUpload
var musicCondiv = "<div class=\"layerBox\"><div class=\"layerBoxCon1\" style=\"width: 450px; height: auto;\"><div class=\"layerMedia\"><div class=\"layerArrow\"></div><div class=\"layerMedia_close\"><strong></strong><a title=\"关闭\" href=\"javascript:void(0);\" class=\"close\"></a></div><div class=\"lv_nav\"><ul id=\"music_tit\"> <li class=\"cur\" id=\"uploadsong\"><span><a href=\"javascript:void(0)\">上传歌曲</a></span></li><li id=\"inputmusiclink\"><span><a href=\"javascript:void(0);\">输入歌曲链接</a></span></li></ul></div><div id=\"music_content\"><div id=\"uploadsongdiv\"><div style=\"padding: 30px 0px;text-align: center;\"><span id=\"swfuploadspan\"></span><p class=\"gray9\" style=\"padding-top:10px;\">仅支持MP3文件，且文件小于10M，为方便搜索，请以歌名命名</p></div></div><div style=\"display:none; margin-bottom: 10px; width: 400px;\" class=\"upload-container\" id=\"upload_Container\"><div class=\"lists\" id=\"lists\"></div></div><div style=\"display: none;\" id=\"linksongdiv\"><div class=\"layerMedia_input\" id=\"linksonginput\"><input type=\"text\" style=\"color: rgb(153, 153, 153);\" class=\"layerMusic_txt\" value=\"请输入以MP3结尾的链接\" id=\"mlinkinput\"><a style=\"\" href=\"javascript:void(0);\" class=\"btn_normal\" id=\"mlinksubmit\"><em>添加</em></a></div><p class=\"layerMedia_err error_color\" style=\"display: none;\" id=\"mlinkredinfo\">你输入的链接地址无法识别:)</p><p style=\"display: none;\" class=\"mail_pl\" id=\"mlinkre\"><a id=\"mlinkback\" href=\"javascript:void(0);\">作为普通的链接发布</a>或者<a id=\"mlinkcancel\" href=\"javascript:void(0);\">取消操作</a>。</p></div></div></div></div></div>";

//feed
var feedTabDiv = "<div class=\"layerBox\"><div class=\"layervote layerMoveto\"><div class=\"layerMedia_close\"><a class=\"close\"onclick=\"return false;\"title=\"关闭\"href=\"javascript:;\"></a></div><div class=\"lv_nav\"><ul><li class=\"cur\"><span>转发到微博</span></li><li class=\"\"><span>转发到私信</span></li></ul></div><div class=\"layerBoxCon\"style=\"width: 450px;\"></div></div></div>";
var feedConDiv = "<div class=\"shareLayer\"><div class=\"laymoveText\"></div><div class=\"enterBox_topline\"><div class=\"lf\"><a title=\"表情\"href=\"javascript:void(0);\"class=\"faceicon1\"></a></div><div class=\"rt\"style=\"color: #008800; height: 22px; line-height: 22px; overflow: hidden\"><span class=\"normal\">还可以输入00个汉字</span></div></div><textarea id=\"PY_txt\" class=\"PY_textarea\"style=\"font-family: Tahoma,宋体;font-size: 14px; line-height: 18px; color: rgb(51, 51, 51); overflow: hidden;border: 1px solid rgb(204, 204, 204); word-wrap: break-word;\"></textarea><div class=\"selSend\"><p><input type=\"checkbox\"name=\"isLast\"id=\"isLast\"/><label for=\"isLast\"></label></p><p><input type=\"checkbox\"name=\"isRoot\"id=\"isRoot\"/><label for=\"isRoot\"></label></p></div><div class=\"MIB_btn\"><a class=\"newabtn_ok\"onclick=\"return false;\"href=\"javascript:;\"><em>转发</em></a><a class=\"btn_notclick\"onclick=\"return false;\"href=\"javascript:;\"><em>取消</em></a></div></div>";
var mesgConDiv = "<div class=\"shareLayer\"><table><tbody><tr><th>收件人：</th><td><input type=\"text\"value=\"\"class=\"inputtxt1\"style=\"color: rgb(153, 153, 153);\"/></td></tr><tr><th class=\"layerTop\">内容：</th><td><div class=\"enterBox_topline\"><div class=\"lf\"><a title=\"表情\"href=\"javascript:void(0);\"class=\"faceicon1\"></a></div><div class=\"rt\"style=\"color: #008800; height: 22px; line-height: 22px; overflow: hidden\"><span class=\"normal\">还可以输入00个汉字</span></div></div><textarea id=\"PY_txt\" class=\"PY_textarea\"style=\"font-family: Tahoma,宋体;font-size: 14px; line-height: 18px; color: rgb(51, 51, 51); overflow: hidden; border: 1px solid rgb(204, 204, 204); word-wrap: break-word; height: 132px;\"></textarea></td></tr></tbody></table><div class=\"MIB_btn\"><a class=\"newabtn_ok\"onclick=\"return false;\"href=\"javascript:;\"><em>转发</em></a><a class=\"btn_notclick\"onclick=\"return false;\"href=\"javascript:;\"><em>取消</em></a></div></div>";
//
var mediaConDiv = "<div class=\"layerBox\"><div style=\"padding:3px 0 3px 5px\"><a onclick=\"return false;\" id=\"pop_video_window_close\" href=\"javascript:void(0);\"><img class=\"small_icon cls\" src=\"/Content/Image/transparent.gif\">关闭</a></div>	<div id=\"pop_video_window\" style=\"width:440px;\" class=\"layerBoxCon\"><div><div id=\"mediaCon\" style=\"padding-top: 10px\"></div></div></div></div>";

//poppublishMB
var popMBConDiv = "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong>有什么新鲜事想告诉大家？</strong><a title=\"关闭\"class=\"close\"href=\"javascript:;\"></a><div class=\"clear\"></div></div></div><div class=\"layerBoxCon\"style=\"width: 490px; height: auto;\"><div style=\"padding-top: 14px;\"class=\"commonLayer2\"><div class=\"zPoster\"><div class=\"ztips\"><div class=\"lf gray6\">可以直接输入音乐或视频的url地址</div><div id=\"publisher_info2\"class=\"writeScores\">还可以输入<span class=\"pipsLim\">140</span>字</div></div><div class=\"ztxtarea\"><textarea name=\"\"cols=\"\"rows=\"\"id=\"publish_editor2\"range=\"0&0\"></textarea></div><div class=\"sendor\"><span ><a id=\"face\" href=\"javascript:void(0);\"><img align=\"absmiddle\"src=\"/Content/Image/transparent.gif\"alt=\"\"class=\"zmotionico\">表情</a></span><span style=\"display: \"id=\"publisher_image2\"><img align=\"absmiddle\"class=\"zpostorimgico\"alt=\"\"src=\"/Content/Image/transparent.gif\">图片</span><a id=\"publisher_submit2\" title=\"发布\"href=\"javascript:void(0);\"><img class=\"submit_notclick\"alt=\"发布\"src=\"/Content/Image/transparent.gif\"></a></div></div><div class=\"clearit\"></div></div></div></div>";

//group
var GroupConDiv = "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong>{title}</strong><a title=\"关闭\" class=\"close\" href=\"javascript:;\"></a><div class=\"clear\"></div></div></div><div class=\"layerBoxCon\" style=\"width: 300px; height: auto;\"><div class=\"groupLayer\"><div class=\"inputBox\">分组名：<input type=\"text\" value=\"输入分组名字\" id=\"group_newname\"></div><div style=\"display:none\" class=\"errorTs\" id=\"errorTs\"></div><div class=\"btns\"><a class=\"btn_normal\" href=\"javascript:void(0)\" id=\"group_submit\"><em>确定</em></a><a class=\"btn_normal\" href=\"javascript:void(0)\" id=\"group_cancel\"><em>取消</em></a></div></div></div></div>";
var GroupAssignDiv = '<div class="layerBox"><div class="layerBoxTop"><div class="topCon"><strong><img class="tipicon tip3" src="/Content/Image/PY_ib.gif" alt="" title="">设置分组</strong><a title="关闭" class="close" href="javascript:;"></a><div class="clear"></div></div></div><div class="layerBoxCon" style="width: 390px; height: auto;"><div class="shareLayer groupNewBox"><div id="shareTxt" class="shareTxt clearFix"><span class="lf">为"{name}"选择分组：</span></div><div class="group_nb_bg"><ul class="group_list" id="group_list_D"></ul><div class="addNew"><a href="javascript:void(0);" id="creategrp"><em>+</em>创建新分组</a></div><div style="display:none" class="newBox" id="newgrp"><div class="newBox_input"><input type="text" class="newBox_txt" value="新分组" id="group_input" style="color: rgb(153, 153, 153);"><a class="btn_normal" id="create_group" href="javascript:void(0);"><em>创建</em></a><a id="cancel_group" href="javascript:void(0);">取消</a></div><p style="display:none" class="newBox_err error_color" id="group_error">不超过8个汉字</p></div></div><div class="addNew"> 备注姓名：<input type="text" value="设置备注" style="color: rgb(153, 153, 153);" id="set_group_remark"><span class="errorTs2 error_color" style="display:none" id="set_group_remark_err"></span></div><div class="MIB_btn"><a class="btn_normal" id="g_submit" href="javascript:void(0)"><em>保存</em></a><a class="btn_normal" id="g_nogroup" href="javascript:void(0)"><em>取消</em></a></div></div></div></div>';
var Hashtable = function () {
    this.items = {};
    this.itemsCount = 0;
    this.add = function (key, value) {
        if (!this.containsKey(key)) {
            this.items[key] = value;
            this.itemsCount++;
        }
        else
            throw "key '" + key + "' allready exists."
    };


    this.get = function (key) {
        if (this.containsKey(key))
            return this.items[key];
        else
            return null;
    };


    this.remove = function (key) {
        if (this.containsKey(key)) {
            delete this.items[key];
            this.itemsCount--;
        }
        else
            throw "key '" + key + "' does not exists."
    };



    this.containsKey = function (key) {
        return typeof (this.items[key]) != "undefined";
    };
    this.containsValue = function containsValue(value) {
        for (var item in this.items) {
            if (this.items[item] == value)
                return true;
        }
        return false;
    };
    this.contains = function (keyOrValue) {
        return this.containsKey(keyOrValue) || this.containsValue(keyOrValue);
    };
    this.clear = function () {
        this.items = {};
        itemsCount = 0;
    };
    this.size = function () {
        return this.itemsCount;
    };
    this.isEmpty = function () {
        return this.size() == 0;
    };
};

 
var ajaxUrlHash = function (event) {
    this.isSupport = ('onhashchange' in window) && ((typeof document.documentMode === 'undefined') || document.documentMode >= 8);
    this.preHash = window.location.hash;
    this.hashChangeFire = event;
    this.init();
    if (event) event();
};
ajaxUrlHash.prototype.isHashChanged = function () {
    if (this.preHash != window.location.hash) {
        this.preHash = window.location.hash;
        return true;
    }
    else
        return false;
}
ajaxUrlHash.prototype.init = function () {
    if (this.isSupport) {
        window.onhashchange = this.hashChangeFire;
    } else {
        cusSetInterval(function () {
            var o = arguments[0];
            if (o.isHashChanged()) {
                o.hashChangeFire();
            }
        }, 150, this);
    }
}
var cusSetInterval = function (fRef, mDelay) {
    if (typeof fRef == "function") {
        var argu = Array.prototype.slice.call(arguments, 2);
        var f = (function () {
            fRef.apply(null, argu);
        });
        return setInterval(f, mDelay);
    }
    return setInterval(fRef, mDelay);
};

$(window).resize(function () {
    if (App.isVisible($("#mashDiv")))
    App.showMash();
});
var App = {
    config: {
        curUid: -1
    },
    E: function (s) {
        if (typeof s === "string") {
            return document.getElementById(s);
        }
        else
            return null;
    },
    UlrToJson: function (url) {
        var json = {};
        var temp = url.split('?');
        if (temp && temp.length >= 2) {
            url = temp[1];
        }
        else
            return null;
        var arr = url.split('&');
        for (var i = 0; i < arr.length; i++) {
            if (arr[i]) {
                var key = arr[i].split('=')[0];
                var value = arr[i].split('=')[1];
                if (key && value) {
                    json[key] = value;
                }
            }
        }
        return json;
    },
    $doc: $(document),
    showMash: function () {
        if (App.appendToBody($("#mashDiv"), mashDiv)) {
            $("#mashDiv").bgiframe();

        }
        if ($.browser.msie && ($.browser.version == "6.0")) {
            $("#mashDiv").css("position", "absolute").width($(window).width()).height($(document).height());
        }
        $("#mashDiv").show();
    },
    hideMash: function () {
        $("#mashDiv").hide();
    },
    checkLogin: function () {
        if ($("#mod_loginname").val() == "邮箱/会员帐号/手机号" || $.trim($("#mod_loginname").val()) == "") {
            $("#mod_login_title").text("请输入登录名");
            $("#mod_login_content").hide();
            $("#mod_login_tip").css("margin-top", $.browser.msie ? "-50px" : "-40px");
            $("#mod_login_tip").show();
            $("#mod_loginname").focus();
            $("#mod_password_text").blur();
            return;
        }
        if ($("#mod_password").val() == "") {
            $("#mod_password_text").focus();
            $("#mod_login_title").text("请输入密码");
            $("#mod_login_content").hide();
            $("#mod_login_tip").css("margin-top", $.browser.msie ? "-10px" : "0px");
            $("#mod_login_tip").show();
            return;
        }
        $("#mod_login_tip").hide();

        App.iframeSubmit({ hdLoginname: $("#mod_loginname").val(), hdPassword: $("#mod_password").val(), hdReUsername: $("#mod_isremember").attr("checked") }, "loginForm", "/User/IframeModLogin/", "loginFrame");
        return false;
    },
    initLoginDialCon: function () {
        $("#mod_loginname").focus(function () {
            var logininput = $(this);
            logininput.css("color", "rgb(51, 51, 51)");
            if (logininput.val() == "邮箱/会员帐号/手机号")
                logininput.val("");
        });
        $("#mod_loginname").blur(function () {
            var logininput = $(this);
            logininput.css("color", "rgb(153, 153, 153)");
            if (logininput.val() == "")
                logininput.val("邮箱/会员帐号/手机号");
        });
        $("#mod_password_text").focus(function () {
            $(this).hide();
            $("#mod_password").show();
            $("#mod_password").focus();
            $("#mod_password").click();
            $("#mod_password").css("color", "rgb(51, 51, 51)");
        });
        $("#mod_password").blur(function () {
            if ($(this).val() == "") {
                $("#mod_password_text").show();
                $("#mod_password_text").blur();
                $(this).hide();
            }
            else {
                $(this).css("color", "rgb(153, 153, 153)");
            }

        });
        $("#mod_password").focus(function () {
            $(this).css("color", "rgb(51, 51, 51)");
        });
        $("#mod_loginname").JQP_EmailNote({ selfn: function () { $("#mod_password_text").focus(); $("#mod_loginname").blur(); } });

        $("#mod_login_submit").bind("click", App.checkLogin);
        $("#mod_password").bind("keyup", function (e) {
            if (e.keyCode == 13)
                App.checkLogin();
        });
    },
    showLoginDial: function () {
        App.initCheckRegObj();
        App.showMash();
        App.initDialDiv("LoginDiaDiv", dialDiv, false, function () { App.hideLoginDial() });
        $("#LoginDiaDiv").find(".mid_c").html(loginConDiv);
        App.bindVailCtrl();
        App.initLoginDialCon();
        var position = App.centerInScreen($("#LoginDiaDiv"));
        $("#LoginDiaDiv").css("left", position.left + "px");
        $("#LoginDiaDiv").css("top", position.top + "px");
        $("#LoginDiaDiv").find(".layerMedia_close .close").bind("click", function () { App.hideLoginDial(); });
        $("#LoginDiaDiv").show();
    },
    showLoginDial2Reg: function () {
        $("#mod_reg_login_box").hide(); $("#mod_reg_login_yellow").show(); $("#mod_reg_information_box").show();
        App.refreshCheckCode("mod_reg_check_img");
        return false;
    },
    showLoginDialBackLogin: function () {
        $("#mod_reg_login_box").show(); $("#mod_reg_login_yellow").hide(); $("#mod_reg_information_box").hide();
        return false;
    },
    hideLoginDial: function () {
        $("#LoginDiaDiv").hide(); $("#mashDiv").hide();
    },
    initDialDiv: function (selector, str, isClickOther, clickOtherFn) {
        var obj = $("#" + selector);
        if (typeof obj == "object" && typeof str == "string") {
            if (obj[0] == null) {
                $("body").append(str.replace(/{id}/, "id=" + selector));

                if (isClickOther && typeof clickOtherFn == "function")
                    $(obj.selector).JQP_ClickOther(clickOtherFn);
                return true;
            }
        }
        return false;
    },
    isVisible: function (obj) {
        return obj.is(":visible");
    },
    centerInScreen: function (obj) {
        if (typeof obj == "object") {
            return { left: (($(document).width()) / 2 - (parseInt(obj.width()) / 2)), top: (((($(window).height() - obj.height()) / 2) + $(document).scrollTop())) };
        }
    },
    appendToBody: function (obj, str) {
        if (typeof obj == "object" && typeof str == "string") {
            if (obj[0] == null) {
                $("body").append(str);
                return true;
            }
        }
        return false;
    },
    createIframeForm: function (array, formId, formAction, iframeId) {
        var formStr = "<form name=\"" + formId + "\" id=\"" + formId + "\" method=\"post\" action=\"" + formAction + "\" style=\"display:none\" target=\"" + iframeId + "\">";
        for (var p in array) {
            formStr += "<input type=\"password\" id=\"" + p + "\" name=\"" + p + "\" />";
        }
        formStr += "</form>";
        App.appendToBody($("#" + formId), formStr);
        var iframeStr = "<iframe name=\"" + iframeId + "\" id=\"" + iframeId + "\" style=\"display:none\"></iframe>";
        App.appendToBody($("#" + iframeId), iframeStr);
    },
    iframeSubmit: function (array, formId, formAction, iframeId) {
        App.createIframeForm(array, formId, formAction, iframeId);
        for (var p in array) {
            $("#" + p).val(array[p]);
        }
        if ($.browser.msie) {
            eval("window." + formId + ".submit()");
        } else {

            $("#" + formId).submit();
        }
    },
    loginCallBack: function (isSucess) {
        if (!isSucess) {
            $("#mod_login_title").text("登录名或密码错误");
            $("#mod_login_content").hide();
            $("#mod_login_tip").css("margin-top", $.browser.msie ? "-50px" : "-40px");
            $("#mod_login_tip").show();
        }
        else {
            if (arguments[1] == 0) {
                $("#mod_login_title").text("你的账号还没有验证");
                $("#mod_login_content").hide();
                $("#mod_login_tip").css("margin-top", $.browser.msie ? "-50px" : "-40px");
                $("#mod_login_tip").show();
            }
            if (arguments[1] == 1) {
                window.location.href = "/User/fullinfo/";
            }
            if (arguments[1] == 2) {
                window.location.href = "/";
            }
        }
    },
    regCallBack: function (isSuccess, email) {
        if (isSuccess) {
            window.location.href = "/User/RegSuccess/?email=" + email;
        }
        else {
            App.alert("系统繁忙，稍后再试！");
        }
    },
    checkRegObj: { isMail: false, isPwd: false, isRePwd: false, isVailCode: false, isAgree: false },
    initCheckRegObj: function () {
        for (var p in App.checkRegObj) {
            App.checkRegObj[p] = false;
        }
    },
    checkIsMail: function (inputCtr, plus) {
        App.checkRegObj.isMail = false;
        var regStr = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
        if ($.trim(inputCtr.val()) == "") {
            plus.html(vailRedDiv);
            plus.find("em").html("请输入常用邮箱。");
            plus.show();
        }
        else if (!regStr.test(inputCtr.val())) {
            plus.html(vailRedDiv);
            plus.find("em").html("请输入正确的邮箱地址。");
            plus.show();
        }
        else {
            App.ajax_IsExsitEmail(function (o) {
                if (o.Data == "1") {
                    plus.html(vailRedDiv);
                    plus.find("em").html("该邮箱地址已被注册。");
                    plus.show();
                }
                else {
                    App.checkRegObj.isMail = true;
                    plus.html(vailOk);
                    plus.show();
                }
            }, arguments[2] != null ? arguments[2] : true, $.trim(inputCtr.val()));

        }

    },

    checkIsPwd: function (inputCtr, plus) {
        App.checkRegObj.isPwd = false;
        var regStr = /\s+/;
        if (regStr.test(inputCtr.val())) {
            plus.html(vailRedDiv);
            plus.find("em").html("密码请勿使用特殊字符。");
            plus.show();
        }
        else if (inputCtr.val() == "") {
            plus.html(vailRedDiv);
            plus.find("em").html("密码太短了，最少6位。");
            plus.show();
        }
        else if (inputCtr.val().length < 6) {
            plus.html(vailRedDiv);
            plus.find("em").html("密码太短了，最少6位。");
            plus.show();
        }
        else if (inputCtr.val().length > 16) {
            plus.html(vailRedDiv);
            plus.find("em").html("密码太长了，最多16位。");
            plus.show();
        }
        else {
            App.checkRegObj.isPwd = true;
            plus.html(vailOk);
            plus.show();
        }
    },
    checkIsRePwd: function (inputCtr, plus) {
        App.checkRegObj.isRePwd = false;
        if (inputCtr.val() != $("#mod_reg_password").val()) {
            plus.html(vailRedDiv);
            plus.find("em").html("两次输入的密码不同。");
            plus.show();
        }
        else {
            if ($("#mod_reg_password").val() != "") {
                App.checkRegObj.isRePwd = true;
                plus.html(vailOk);
                plus.show();
            }
        }
    },

    checkIsVailCode: function (inputCtr, plus) {
        App.checkRegObj.isVailCode = false;
        if (inputCtr.val() == "") {
            plus.html(vailRedDiv);
            plus.find("em").html("请输入验证码。");
            plus.show();
        }
        else {
            App.ajax_IsValidCode(function (o) {
                if (o.Data == "1") {
                    plus.html(vailRedDiv);
                    plus.find("em").html("验证码不正确。");
                    plus.show();
                }
                else {
                    App.checkRegObj.isVailCode = true;
                    plus.html(vailOk);
                    plus.show();
                }
            }, arguments[2] != null ? arguments[2] : true, $.trim(inputCtr.val()));

        }
    },

    checkIsAgree: function (inputCtr, plus) {
        App.checkRegObj.isAgree = false;
        if (inputCtr.attr("checked") != true) {
            plus.html(vailRedDiv);
            plus.find("em").html("需同意使用协议。");
            plus.show();
        }
        else {
            App.checkRegObj.isAgree = true;
            plus.html(vailOk);
            plus.show();
        }
    },
    bindVailCtrl: function () {
        $("#mod_reg_username").JQP_EmailNote({ selfn: function () { $("#mod_reg_password").focus(); $("#mod_reg_username").blur(); } });
        $("#mod_reg_username").bind("blur", function () { App.checkIsMail($(this), $(" #mod_red_reg_username")) });
        $("#mod_reg_password").bind("blur", function () { App.checkIsPwd($(this), $("#mod_red_reg_password")) });
        $("#mod_reg_repassword").bind("blur", function () { App.checkIsRePwd($(this), $("#mod_red_reg_repassword")) });
        $("#mod_reg_door").bind("blur", function () { App.checkIsVailCode($(this), $("#mod_red_reg_door")) });
        $("#mod_reg_after").bind("click", function () { App.checkIsAgree($(this), $("#mod_red_reg_after")) });
        $("#mod_reg_submit").bind("click", function () {
            App.disableAtag($(this));
            App.checkIsAgree($("#mod_reg_after"), $("#mod_red_reg_after"));
            App.checkIsMail($("#mod_reg_username"), $(" #mod_red_reg_username"), false);
            App.checkIsPwd($("#mod_reg_password"), $("#mod_red_reg_password"));
            App.checkIsRePwd($("#mod_reg_repassword"), $("#mod_red_reg_repassword"));
            App.checkIsVailCode($("#mod_reg_door"), $("#mod_red_reg_door"), false);

            if (App.checkRegObj.isAgree && App.checkRegObj.isMail && App.checkRegObj.isPwd && App.checkRegObj.isRePwd && App.checkRegObj.isVailCode) {
                App.iframeSubmit({ formMail: $("#mod_reg_username").val(), formPwd: $("#mod_reg_password").val() }, "RegForm", "/User/IframeModReg/", "RegIframe");
            }
            else {
                App.enableAtag($(this));
            }
            return false;
        });
    },

    refreshCheckCode: function (imgCtr) {
        $("#" + imgCtr).attr("src", '/User/GetCheckCode/' + Math.random());
    },
    ajax_IsExsitEmail: function (callback, async, val) {
        $.ajax(
       {
           async: async,
           url: "/Ajax/CheckEmail/",
           datatype: "json",
           cache: false,
           data: { email: val },
           type: "post",
           success: function (o) {
               callback(o);
           },
           error: function (request) {

           }
       }
    );
    },
    ajax_IsExsitNickName: function (callback, async, val, url) {
        if (!url) {
            url = "/Ajax/CheckNickName/";
        }
        $.ajax(
       {
           async: async,
           url: url,
           datatype: "json",
           cache: false,
           data: { name: val },
           type: "post",
           success: function (o) {
               callback(o);
           },
           error: function (request) {

           }
       }
    );
    },
    ajax_IsValidCode: function (callback, async, val) {
        $.ajax(
       {
           async: async,
           url: "/Ajax/CheckCode/",
           datatype: "json",
           cache: false,
           data: { Code: val },
           type: "post",
           success: function (o) {
               callback(o);
           },
           error: function (request) {
           }
       }
    );
    },
    ajax_resendEmail: function (val) {
        $.ajax(
       {
           async: false,
           url: "/Ajax/ReSendEmail/",
           datatype: "json",
           cache: false,
           data: { Email: val },
           type: "post",
           success: function (o) {
               if (o.Data == "1") {
                   App.tip("发送成功，请查收！", 2000);
               }
               else {
                   App.confirm("系统繁忙，请稍后再试一试");
               }
           },
           error: function (request) {
           }
       }
    );
    },
    disableAtag: function (o, css, isNotAdd) {
        var a = o.clone();
        a.insertAfter(o);
        o.hide();
        a.removeAttr("onclick");
        if (css != null) {
            if (arguments[2] == null)
                a.addClass(css);
            else
                a.attr("class", css);
        }
    },
    enableAtag: function (o) {
        o.show();
        o.next().remove();
    },
    alert: function (text) {
        App.showMash();
        App.initDialDiv("AlertDiaDiv", dialDiv, false, function () { $("#AlertDiaDiv").hide(); App.hideMash(); });
        $("#AlertDiaDiv").find(".mid_c").html(alertConDiv);
        $("#AlertDiaDiv").css("z-index", 2000);
        $("#AlertDiaDiv").find(".close").bind("click", function () {
            $("#AlertDiaDiv").hide();
            App.hideMash();
        });

        $("#AlertDiaDiv").find("#btn_AlterClose").bind("click", function () {
            $("#AlertDiaDiv").hide();
            App.hideMash();
        });
        $("#AlertDiaDiv").find(".layerR").html("<strong>" + text + "</strong>");

        var position = App.centerInScreen($("#AlertDiaDiv"));
        $("#AlertDiaDiv").css("left", position.left + "px");
        $("#AlertDiaDiv").css("top", position.top + "px");
        $("#AlertDiaDiv").show();
    },
    confirm: function (text, callBack) {
        App.showMash();
        App.initDialDiv("ConfirmDiaDiv", dialDiv, false, function () { $("#ConfirmDiaDiv").hide(); App.hideMash(); });
        $("#ConfirmDiaDiv").find(".mid_c").html(confirmConDiv);
        $("#ConfirmDiaDiv").find(".close").bind("click", function () {
            $("#ConfirmDiaDiv").hide();
            App.hideMash();
        });

        $("#ConfirmDiaDiv").find("#Btn_ConfirmOk").bind("click", function () {
            $("#ConfirmDiaDiv").hide();
            App.hideMash();
            callBack();
            return false;
        });

        $("#ConfirmDiaDiv").find("#Btn_ConfirmCancel").bind("click", function () {
            $("#ConfirmDiaDiv").hide();
            App.hideMash();
            return false;
        });
        $("#ConfirmDiaDiv").find(".layerR strong").html(text);

        var position = App.centerInScreen($("#ConfirmDiaDiv"));
        $("#ConfirmDiaDiv").css("left", position.left + "px").css("z-index", 1700).css("top", position.top + "px").show();
    },
    tip: function (text, timeout, href) {
        App.initDialDiv("TipDiaDiv", dialDiv, false, function () { $("#TipDiaDiv").hide(); });
        $("#TipDiaDiv").find(".mid_c").html(tipConDiv);
        $("#TipDiaDiv").find(".close").bind("click", function () {
            $("#TipDiaDiv").hide();
        });

        var position = App.centerInScreen($("#TipDiaDiv"));
        $("#TipDiaDiv").css("left", position.left + "px").css("top", position.top + "px").css("z-index", 1700).show();
        $(".zok").html("<img align=\"absmiddle\" title=\"\" alt=\"\" src=\"/Content/Image/transparent.gif\" class=\"PY_ib PY_ib_3\">" + text);
        setTimeout(function () {
            $("#TipDiaDiv").hide();
            if (href != null) {
                window.location.href = href;
            }
        }, timeout);
    },
    fullTip: function (text, timeout, href, type) {
        App.initDialDiv("FullTipDiaDiv", dialDiv, false, function () { $("#FullTipDiaDiv").hide(); });
        var fullElem = $("#FullTipDiaDiv");
        fullElem.find(".mid_c").html(fullTipConDiv);
        fullElem.find(".close").bind("click", function () {
            fullElem.hide();
        });


        var position = App.centerInScreen(fullElem);
        fullElem.css("left", position.left + "px");
        fullElem.css("top", position.top + "px");
        fullElem.css("z-index", 1700);

        fullElem.find(".PY_ib").attr("class", "PY_ib PY_ib_" + type);
        fullElem.find(".layerR").html("<strong>" + text + "</strong>")
        fullElem.show();
        setTimeout(function () {
            fullElem.hide();
            if (href != null) {
                window.location.href = href;
            }
        }, timeout);
    },
    miniConfirm: function (text, popWhere, callBack) {
        $("#miniConfirm").remove();
        App.appendToBody($("#miniConfirm"), miniConfirmDiaDiv);
        if ($.browser.msie) {
            $("#miniConfirm").css("width", 210);
        }
        var left = $(popWhere).offset().left - ((210 - $(popWhere).width()) / 2);
        var top = $(popWhere).offset().top - ($.browser.msie ? 85 : 77);
        $("#miniConfirm").find("#Content").html(text);
        $("#miniConfirm").css("z-index", 2001).css("left", left).css("top", $(popWhere).offset().top).css("overflow", "hidden").animate({ "height": ($.browser.msie ? 85 : 77), "top": top }, 300, function () { $("#miniConfirm").css("overflow", ""); });
        $($("#miniConfirm").find(".newabtn_ok")[0]).click(function () {
            $("#miniConfirm").css("overflow", "hidden");
            $("#miniConfirm").animate({ "height": 0, "top": top + ($.browser.msie ? 85 : 77) }, 300, function () {
                if (callBack != null) {
                    callBack();
                }
            });
            return false;
        });

        $($("#miniConfirm").find(".newabtn_ok")[1]).click(function () {
            $("#miniConfirm").css("overflow", "hidden");
            $("#miniConfirm").animate({ "height": 0, "top": top + ($.browser.msie ? 85 : 77) }, 300);
            return false;
        });

        return false;
    },
    FullMiniTip: function (text, popWhere, timeout, type) {
        $("#miniTip").remove();
        App.appendToBody($("#miniTip"), miniTipDiaDiv);
        if ($.browser.msie) {
            $("#miniTip").css("width", 210);
        }
        var left = $(popWhere).offset().left - ((210 - $(popWhere).width()) / 2);
        var top = $(popWhere).offset().top - ($.browser.msie ? 54 : 46);
        var $minitip = $("#miniTip");
        $minitip.find("#Content").html(text);
        $minitip.find(".tipicon").attr("class", "tipicon tip" + type);
        $minitip.css("z-index", 2001);
        $minitip.css("left", left);
        $minitip.css("top", $(popWhere).offset().top);
        $minitip.css("overflow", "hidden");
        $minitip.animate({ "height": ($.browser.msie ? 54 : 46), "top": top }, 300, function () { $minitip.css("overflow", ""); });


        setTimeout(function () {
            $minitip.css("overflow", "hidden");
            $minitip.animate({ "height": 0, "top": top + ($.browser.msie ? 54 : 46) }, 300);
        }, timeout);
        return false;
    },
    miniTip: function (text, popWhere, timeout) {
        $("#miniTip").remove();
        App.appendToBody($("#miniTip"), miniTipDiaDiv);
        if ($.browser.msie) {
            $("#miniTip").css("width", 210);
        }
        var left = $(popWhere).offset().left - ((210 - $(popWhere).width()) / 2);
        var top = $(popWhere).offset().top - ($.browser.msie ? 54 : 46);
        var $minitip = $("#miniTip");
        $minitip.find("#Content").html(text);
        $minitip.css("left", left);
        $minitip.css("top", $(popWhere).offset().top);
        $minitip.css("overflow", "hidden");
        $minitip.animate({ "height": ($.browser.msie ? 54 : 46), "top": top }, 300, function () { $minitip.css("overflow", ""); });

        setTimeout(function () {
            $minitip.css("overflow", "hidden");
            $minitip.animate({ "height": 0, "top": top + ($.browser.msie ? 54 : 46) }, 300);
        }, timeout);
        return false;
    },
    BindCityCtrl: function (ctrl, type, val, callBack, url) {
        var items = "";
        if (!url) {
            url = "/Ajax/GetCity/";
        }
        $.ajax(
       {
           async: true,
           url: url,
           datatype: "json",
           cache: false,
           data: { Type: type, Val: val },
           type: "get",
           success: function (o) {
               for (var i = 0; i < o.Data.length; i++) {
                   items = items + "<option value='" + o.Data[i].ID + "'>" + o.Data[i].Name + "</option>";
               }
               ctrl.html(items);
               if (callBack)
                   callBack();
           },
           error: function (request) {
           }
       }
    );
    },
    insertTxt2Txtarea: function (txtCtrl, insertVal) {

        $(txtCtrl).focus();
        var con = $(txtCtrl)[0].value;
        var start = parseInt($(txtCtrl).attr("range").split("&")[0]);
        var sel = parseInt($(txtCtrl).attr("range").split("&")[1]);
        var pre = con.substr(0, start);
        var last = con.substr(start + sel);
        $(txtCtrl).val(pre + insertVal + last);
        var pos = start + insertVal.length;
        var ctrl = $(txtCtrl)[0];
        App.setSelectRange(ctrl, pos, pos);
        App.saveTxtCtrlRangePos(ctrl);
    },
    saveTxtCtrlRangePos: function (textBox) {
        if (document.selection) {
            textBox.focus();
            var ds = document.selection;
            var range = ds.createRange();
            var stored_range = range.duplicate();
            stored_range.moveToElementText(textBox);
            stored_range.setEndPoint("EndToEnd", range);
            textBox.selectionStart = stored_range.text.length - range.text.length;
            textBox.selectionEnd = textBox.selectionStart + range.text.length;
        }
        $(textBox).attr("range", textBox.selectionStart + "&0");
    },
    ExpressionsObj: null,
    TargetTextarea: null,
    IsLoadExpression: false,
    showExpression: function (txtCtrl, showWhere) {
        App.TargetTextarea = txtCtrl;
        App.HideAllDiaDiv();
        if (App.initDialDiv("divExpression", dialDiv, true, function () { $("#divExpression").hide(); })) {
            $("#divExpression").css("z-index", 2000);
            $("#divExpression").find(".mid_c").html(expressionConDiv);
            var showWhere = $(showWhere).offset();
            $("#divExpression").css("left", showWhere.left - 15);
            $("#divExpression").css("top", showWhere.top + 20);
            $("#divExpression").show();
            $.ajax({
                type: "Post",
                url: "/Ajax/GetExpressionType/",
                datatype: "json",
                cache: false,
                success: function (o) {
                    var typeEles = "<ul Page=\"1|1\">";
                    for (var i = 0; i < parseInt(o.Data.length / 7) + 1; i++) {
                        for (var j = i * 7; j < (7 * (i + 1)); j++) {
                            if (o.Data[j] != null) {
                                typeEles += ("<li group=\"" + i + "\" style=\"display:" + (j < 7 ? "block" : "none") + "\"><a href=\"javascript:void(0);\" class='" + (j == 0 ? "magicTcur" : "") + "'  type=\"" + o.Data[j].ID + "\" >" + o.Data[j].Name + "</a></li>");
                                if ((j + 1) % 7 != 0 && j != o.Data.length - 1) {
                                    typeEles += ("<li class=\"magiclicur\" style=\"display:" + (j < 7 ? "block" : "none") + "\" group=\"" + i + "\" >|</li>");
                                }
                            }
                            else {
                                break;
                            }
                        }
                    }
                    typeEles += "</ul>";
                    $(".magicTL").html(typeEles);
                    $(".magicTL").find("ul").attr("Page", "1|" + (parseInt(o.Data.length / 7) + 1));
                    $.ajax({
                        type: "Post",
                        url: "/Ajax/GetExpressions/",
                        datatype: "json",
                        cache: false,
                        success: function (obj) {
                            App.IsLoadExpression = true;
                            App.ExpressionsObj = obj.Data;
                            var defaultExpressionEles = "<ul>";
                            var topExpressionEles = "<ul>";

                            for (var k = 0; k < obj.Data.length; k++) {
                                if (obj.Data[k].IsTop == 1) {
                                    topExpressionEles += ("<li title=\"" + obj.Data[k].Name + "\"><a class=\"forElive\" href=\"javascript:void(0);\"><img src=\"" + obj.Data[k].Url + "\" alt=\"" + obj.Data[k].Name + "\"></a></li>");
                                }
                                if (obj.Data[k].IsDefault == 1) {
                                    defaultExpressionEles += ("<li title=\"" + obj.Data[k].Name + "\"><a class=\"forElive\" href=\"javascript:void(0);\"><img src=\"" + obj.Data[k].Url + "\" alt=\"" + obj.Data[k].Name + "\"></a></li>");
                                }
                            }
                            topExpressionEles += "</ul><div class=\"clearit\"></div>";
                            defaultExpressionEles += "</ul><div class=\"clearit\"></div>";
                            $(".faceItemPicbgT").html(topExpressionEles);
                            $(".faceItemPicbg").html(defaultExpressionEles);
                            $(".magicTL").find("a").bind("click", function () {
                                $(".faceItemPicbgT").hide();
                                var expElse = "<ul>";
                                var type = $(this).attr("type");
                                if (App.ExpressionsObj != null) {
                                    var data = App.ExpressionsObj;
                                    for (var n = 0; n < data.length; n++) {
                                        if (data[n].Type == type) {
                                            expElse += ("<li title=\"" + data[n].Name + "\"><a class=\"forElive\" href=\"javascript:void(0);\"><img src=\"" + data[n].Url + "\" alt=\"" + data[n].Name + "\"></a></li>");
                                        }
                                    }
                                    expElse += "</ul><div class=\"clearit\"></div>";
                                    $(".faceItemPicbg").html(expElse);
                                    $(".magicTcur").removeClass("magicTcur");
                                    $(this).addClass("magicTcur").blur();

                                }
                                return false;
                            });
                            $($(".magicTL").find("a")[0]).bind("click", function () {
                                $(".faceItemPicbgT").show();
                                var expTopElse = "<ul>";
                                var expDefaultElse = "<ul>";
                                if (App.ExpressionsObj != null) {
                                    var data = App.ExpressionsObj;
                                    for (var m = 0; m < data.length; m++) {

                                        if (data[m].IsTop == 1) {
                                            expTopElse += ("<li title=\"" + data[m].Name + "\"><a class=\"forElive\" href=\"javascript:void(0);\"><img src=\"" + data[m].Url + "\" alt=\"" + data[m].Name + "\"></a></li>");
                                        }
                                        if (data[m].IsDefault == 1) {
                                            expDefaultElse += ("<li title=\"" + data[m].Name + "\"><a class=\"forElive\" href=\"javascript:void(0);\"><img src=\"" + data[m].Url + "\" alt=\"" + data[m].Name + "\"></a></li>");
                                        }

                                    }
                                    expTopElse += "</ul><div class=\"clearit\"></div>";
                                    expDefaultElse += "</ul><div class=\"clearit\"></div>";
                                    $(".faceItemPicbgT").html(expTopElse);
                                    $(".faceItemPicbg").html(expDefaultElse);
                                    $(".magicTcur").removeClass("magicTcur");
                                    $(this).addClass("magicTcur").blur();
                                }
                                return false;
                            });
                            $($(".magicTR").find("a")[0]).bind("click", function () {
                                if ($(this).attr("class") == "magicbtnL01")
                                    return false;
                                if ($(this).next().attr("class") == "magicbtnR01")
                                    $(this).next().attr("class", "magicbtnR02")
                                var curPage = parseInt($(".magicTL").find("ul").attr("Page").split("|")[0]);
                                var pageCount = parseInt($(".magicTL").find("ul").attr("Page").split("|")[1]);
                                $("li[group='" + (curPage - 1) + "']").hide();
                                curPage = curPage - 1;
                                $("li[group='" + (curPage - 1) + "']").show();
                                $(".magicTL").find("ul").attr("Page", curPage + "|" + pageCount);
                                if (curPage == 1) {
                                    $(this).attr("class", "magicbtnL01");
                                }
                                return false;
                            });

                            $($(".magicTR").find("a")[1]).bind("click", function () {
                                if ($(this).attr("class") == "magicbtnR01")
                                    return false;
                                if ($(this).prev().attr("class") == "magicbtnL01")
                                    $(this).prev().attr("class", "magicbtnL02")
                                var curPage = parseInt($(".magicTL").find("ul").attr("Page").split("|")[0]);
                                var pageCount = parseInt($(".magicTL").find("ul").attr("Page").split("|")[1]);
                                $("li[group='" + (curPage - 1) + "']").hide();
                                curPage = curPage + 1;
                                $("li[group='" + (curPage - 1) + "']").show();
                                $(".magicTL").find("ul").attr("Page", curPage + "|" + pageCount);
                                if (curPage == pageCount) {
                                    $(this).attr("class", "magicbtnR01");
                                }
                                return false;
                            });
                            $("#divExpression").find(".close").bind("click", function () {
                                $("#divExpression").hide();
                            });
                            $(".forElive").live("click", function () {
                                var val = "[" + $(this).find("img").attr("alt") + "] ";
                                App.insertTxt2Txtarea(App.TargetTextarea, val);
                                $("#divExpression").hide();
                            });
                        },
                        error: function (request) {
                        }
                    });
                },
                error: function (request) {
                }
            });


        }
        else {

            var showWhere = $(showWhere).offset();
            $("#divExpression").css("left", showWhere.left - 15);
            $("#divExpression").css("top", showWhere.top + 20);
            $("#divExpression").show();
            if (App.IsLoadExpression) {
                $($(".magicTL").find("a")[0]).click();
                var prevBtn = $($(".magicTR").find("a")[0]);
                var nextBtn = $($(".magicTR").find("a")[1]);
                prevBtn.attr("class", "magicbtnL01");
                nextBtn.attr("class", "magicbtnR02");
                var curPage = parseInt($(".magicTL").find("ul").attr("Page").split("|")[0]);
                var pageCount = parseInt($(".magicTL").find("ul").attr("Page").split("|")[1]);
                $(".magicTL").find("li").hide();
                curPage = 1;
                $("li[group='" + (curPage - 1) + "']").show();
                $(".magicTL").find("ul").attr("Page", curPage + "|" + pageCount);
            }
        }
        return false;

    },
    showPicUpload: function (showWhere) {
        if (App.isVisible($("#divPicUploadLoding")))
            return;
        if (App.isVisible($("#divPicUploadLoded")))
            return;
        App.HideAllDiaDiv();

        if (App.initDialDiv("divPicUpload", dialDiv, true, function () { $("#divPicUpload").hide(); })) {

            $("#divPicUpload").find(".mid_c").html(picUploadCondiv);
            var showWhere = $(showWhere).offset();
            App.picUploadPos = showWhere;
            $("#divPicUpload").css("left", showWhere.left - 35);
            $("#divPicUpload").css("top", showWhere.top + 20);
            $("#divPicUpload").show();
            $("#divPicUpload").find(".close").click(function () {
                $("#divPicUpload").hide();
            });
            $("#divPicUpload").find(".btn_green").mousemove(function (e) {
                var btnX = e.pageX - $(this).offset().left;
                var btnY = e.pageY - $(this).offset().top;
                var uploadInput = $(this).find("input");
                uploadInput.css("left", btnX - 60);
                uploadInput.css("top", btnY - 10);
            });
            $("#frmPicUpload").find("input").change(function () { App.PicUpload("frmPicUpload", this, function () { App.ShowUploadPicLoding(); }); });
        }
        else {
            $("#divPicUpload").show();
        }
        return false;
    },
    HideAllDiaDiv: function () {
        $(".4CancelAllLayer").hide();
    },
    PicUpload: function (formid, uploadCtrl, callBack) {
        if (!(/\.(gif|jpg|png|jpeg)$/i.test($(uploadCtrl).val()))) {
            App.alert("请上传jpg、gif、png格式的图片。");
            return false;
        }
        else {
            var iframeStr = "<iframe class=\"fb_img_iframe\" frameborder=\"0\"  name=\"ifrPicUpload\" id=\"ifrPicUpload\" src=\"about:blank\" style=\"display:none;\" ></iframe>";
            App.appendToBody($("#ifrPicUpload"), iframeStr);
            if ($.browser.msie) {
                eval("window." + formid + ".submit();");
            } else {

                $("#" + formid).submit();
            }
            callBack();
        }
        var clone = $(uploadCtrl).clone();
        clone.removeAttr("value");
        $(uploadCtrl).remove();
        $("#" + formid).html(clone);
        $("#" + formid).find("input").change(function () {
            App.PicUpload(formid, this, callBack);
        });
    },
    ShowUploadPicLoding: function () {
        App.HideAllDiaDiv();
        if (App.initDialDiv("divPicUploadLoding", dialDiv, false, null)) {
            $("#divPicUploadLoding").find(".mid_c").html(picUploadingCondiv);
            $("#divPicUploadLoding").css("left", App.picUploadPos.left - 35);
            $("#divPicUploadLoding").css("top", App.picUploadPos.top + 20);
            $("#divPicUploadLoding").show();

            $("#divPicUploadLoding").removeClass("4CancelAllLayer");
            $("#divPicUploadLoding").find(".btn_normal").click(function () {
                $("#ifrPicUpload").remove();
                $("#divPicUploadLoding").hide();
            });
        }
        else {
            $("#divPicUploadLoding").show();
        }
    },
    picUploadPos: null,
    ShowUploadPicLoded: function (img, name, id) {
        if (App.initDialDiv("divPicUploadLoded", dialDiv, false, null)) {
            $("#divPicUploadLoded").find(".mid_c").html(picUploadedCondiv);
            $("#divPicUploadLoded").css("left", App.picUploadPos.left - 35);
            $("#divPicUploadLoded").css("top", App.picUploadPos.top + 20);
            $("#divPicUploadLoded").show();
            $("#divPicUploadLoded").removeClass("4CancelAllLayer");
            $("#divPicUploadLoded").find(".dele").click(function () {
                $("#divPicUploadLoded").hide();
                $("#divPicUploadLoded").find("img").hide();
                App.attachPic = -1;
            });

        }
        else {
            $("#divPicUploadLoded").show();
        }
        $("#divPicUploadLoded").find("img")[0].src = img + "?m=" + Math.random() * 10000;
        $("#divPicUploadLoded").find(".cur_status").find("strong").html(name);
        App.attachPic = id;
    },
    PicUploadCallBack: function (status, imgSrc, imgName, imgID) {
        $("#divPicUploadLoding").hide();
        if (status == 1) {
            App.ShowUploadPicLoded(arguments[1], arguments[2], arguments[3]);
        }
        if (status == -1) {
            App.alert("上传有异常失败，请稍后再试。");
        }
        if (status == -2) {
            App.alert("上传图片超过5M,请重新上传。");
        }

    },
    ShowVideoDiaDiv: function (txtCtrl, showWhere) {
        App.HideAllDiaDiv();
        App.TargetTextarea = txtCtrl;
        if (App.initDialDiv("divVidoLink", dialDiv, true, function () { $("#divVidoLink").hide(); })) {
            $("#divVidoLink").find(".mid_c").html(videoCondiv);
            var showWhere = $(showWhere).offset();
            $("#divVidoLink").css("left", showWhere.left - 143);
            $("#divVidoLink").css("top", showWhere.top + 20);
            $("#divVidoLink").show();
            $("#divVidoLink").find(".close").click(function () {
                $("#divVidoLink").hide();
            });
            $("#divVidoLink").find("#vsubmit").click(function () {
                var txt = $("#divVidoLink").find("#vinput");
                var infoP = $("#divVidoLink").find("#vredinfo");
                var infoP1 = $("#divVidoLink").find("#normalact");
                if ($.trim(txt.val()) == "") {
                    infoP.html("请输入Url");
                    infoP1.show();
                    infoP.show();
                    return false;
                }
                $.ajax({
                    url: "/Ajax/CheckVideoUrl/",
                    type: "POST",
                    cache: false,
                    dataType: "json",
                    data: { Url: $.trim(txt.val()) },
                    success: function (o) {
                        if (o.Code == "A00007") {
                            infoP.html(CodeList[o.Code]);
                            infoP1.show();
                            infoP.show();
                        }
                        else {
                            $("#divVidoLink").hide();
                            App.insertTxt2Txtarea(App.TargetTextarea, o.Data + " ");
                        }
                    }
                });
                return false;
            });
            $("#divVidoLink").find("#vcancel").click(function () {
                $("#divVidoLink").hide();
            });
            $("#divVidoLink").find("#vback").click(function () {
                $("#divVidoLink").hide();
                var txt = $("#divVidoLink").find("#vinput");
                App.insertTxt2Txtarea(App.TargetTextarea, $.trim(txt.val()) + " ");
            });
            $("#divVidoLink").find("#vinput").focus(function () {
                this.style.color = "rgb(51, 51, 51)";
            }).blur(function () {
                this.style.color = "rgb(153, 153, 153)";
            });
        }
        else {
            $("#divVidoLink").show();
            $("#divVidoLink").find("#vredinfo").hide();
            $("#divVidoLink").find("#normalact").hide();
            $("#divVidoLink").find("#vinput").val("");
        }
        return false;
    },
    showMusicDiaDiv: function (txtCtrl, showWhere) {
        App.HideAllDiaDiv();
        App.TargetTextarea = txtCtrl;
        if (App.initDialDiv("divMusicDiaDiv", dialDiv, false, null)) {
            $("#divMusicDiaDiv").removeClass("4CancelAllLayer");
            $("#divMusicDiaDiv").find(".mid_c").html(musicCondiv);
            var showWhere = $(showWhere).offset();
            $("#divMusicDiaDiv").css("left", showWhere.left - 143);
            $("#divMusicDiaDiv").css("top", showWhere.top + 20);
            $("#divMusicDiaDiv").show();
            $("#divMusicDiaDiv").find(".close").click(function () {
                $("#divMusicDiaDiv").hide();
            });
            App.initSwfUpload();

            $("#divMusicDiaDiv #inputmusiclink").find("a").click(
            function () {
                $("#divMusicDiaDiv #linksongdiv").show();
                $("#divMusicDiaDiv #uploadsongdiv").hide();
                $("#divMusicDiaDiv #upload_Container").hide();
                $("#divMusicDiaDiv #uploadsong").attr("class", "");
                $("#divMusicDiaDiv #inputmusiclink").attr("class", "cur");
            });

            $("#divMusicDiaDiv #uploadsong").find("a").click(
            function () {
                $("#divMusicDiaDiv #linksongdiv").hide();
                $("#divMusicDiaDiv #uploadsongdiv").show();
                $("#divMusicDiaDiv #uploadsong").attr("class", "cur");
                $("#divMusicDiaDiv #inputmusiclink").attr("class", "");
            });

            $("#divMusicDiaDiv #mlinkinput").focus(function () {
                $(this).css("color", "rgb(51, 51, 51)");
                if ($.trim($(this).val()) == "请输入以MP3结尾的链接")
                    $(this).val("");
            }).blur(function () {
                if ($(this).val() == "") {

                    $(this).val("请输入以MP3结尾的链接");
                }
                $(this).css("color", "rgb(153, 153, 153)");
            });

            $("#divMusicDiaDiv").find("#mlinksubmit").click(function () {
                var txt = $("#divMusicDiaDiv").find("#mlinkinput");
                var infoP = $("#divMusicDiaDiv").find("#mlinkredinfo");
                var infoP1 = $("#divMusicDiaDiv").find("#mlinkre");
                if ($.trim(txt.val()) == "请输入以MP3结尾的链接") {
                    infoP.html("请输入Url");
                    infoP1.show();
                    infoP.show();
                    return false;
                }
                $.ajax({
                    url: "/Ajax/CheckMusicUrl/",
                    type: "POST",
                    cache: false,
                    dataType: "json",
                    data: { Url: $.trim(txt.val()) },
                    success: function (o) {
                        if (o.Code == "A00007") {
                            infoP.html(CodeList[o.Code]);
                            infoP1.show();
                            infoP.show();
                        }
                        else {
                            $("#divMusicDiaDiv").hide();
                            App.insertTxt2Txtarea(App.TargetTextarea, o.Data + " ");
                        }
                    }
                });
                return false;
            });
            $("#divMusicDiaDiv").find("#mlinkcancel").click(function () {
                $("#divMusicDiaDiv").hide();
            });
            $("#divMusicDiaDiv").find("#mlinkback").click(function () {
                $("#divMusicDiaDiv").hide();
                var txt = $("#divMusicDiaDiv").find("#mlinkinput");
                App.insertTxt2Txtarea(App.TargetTextarea, $.trim(txt.val()) + " ");
            });
        }
        else {
            $("#divMusicDiaDiv").show();
        }
        return false;
    },
    swfu: null,
    initSwfUpload: function () {
        var settings = {
            flash_url: "/swfupload/swfupload.swf",
            upload_url: "/Music/Upload/",
            post_params: {},
            file_size_limit: "10 MB",
            file_types: "*.mp3",
            file_types_description: "mp3音频文件",
            file_upload_limit: 0,
            file_queue_limit: 1,
            custom_settings: {
                progressTarget: "lists",
                progressBarDiv: "upload_Container",
                musicDiaDiv: "divMusicDiaDiv",
                txtArea: App.TargetTextarea
            },
            debug: false,

            // Button settings
            button_image_url: "/swfupload/public_btn_01.png",
            button_width: "75",
            button_height: "28",
            button_placeholder_id: "swfuploadspan",
            button_text: '<span class="theFont">上传音乐</span>',
            button_text_style: ".theFont { font-size: 14; }",
            button_text_left_padding: 5,
            button_text_top_padding: 3,
            button_window_mode: SWFUpload.WINDOW_MODE.OPAQUE,

            // The event handler functions are defined in handlers.js
            file_queued_handler: fileQueued,
            file_queue_error_handler: fileQueueError,
            file_dialog_complete_handler: fileDialogComplete,
            upload_start_handler: uploadStart,
            upload_progress_handler: uploadProgress,
            upload_error_handler: uploadError,
            upload_success_handler: uploadSuccess,
            upload_complete_handler: uploadComplete,
            queue_complete_handler: queueComplete	// Queue plugin event
        };

        App.swfu = new SWFUpload(settings);
    },
    setSelectRange: function (textarea, start, end) {
        if (typeof textarea.createTextRange != 'undefined')// IE 
        {
            var length = start;
            for (var i = 1; i < length; i++) {
                if (textarea.value.charAt(i) == '\n') {
                    start--;
                    end--;
                }
            }
            var range = textarea.createTextRange();
            // 先把相对起点移动到0处 
            range.moveStart("character", 0)
            range.moveEnd("character", 0);
            range.collapse(true); // 移动插入光标到start处 
            range.moveEnd("character", end);
            range.moveStart("character", start);
            range.select();
        } // if 
        else if (typeof textarea.setSelectionRange != 'undefined') {
            textarea.setSelectionRange(start, end);
            textarea.focus();
        } // else 
    },
    insertTopic: function (txtarea) {
        var index;
        index = $(txtarea)[0].value.indexOf("#请在这里输入自定义话题#");
        if (index != -1) {
            App.setSelectRange(txtarea, index + 1, index + 12);
            App.selPos(txtarea);
        }
        else {
            App.insertTxt2Txtarea(txtarea, "#请在这里输入自定义话题#");
            App.insertTopic(txtarea);
        }
    },
    getTxtLen: function (obj) {
        return $(obj)[0].value.replace(/[^\x00-\xff]/g, 'xx').length;
    },
    TimerFunArray: [],
    Timer: null,
    StartTimer: function () {
        App.Timer = setInterval(function () {
            for (var i = 0; i < App.TimerFunArray.length; i++) {
                App.TimerFunArray[i]();
            }
        }, 1000);
    },
    StopTimer: function () {
        clearInterval(App.Timer);
    },
    attachPic: -1,
    CreateOriginalMiniBlog: function (txtCtr, successCallBack, defaultCallBack) {
        var con = $.trim($(txtCtr).val()).replace(/\n/g, "");
        con = App.htmlencode(con);
        var data = { Content: con, AttachPic: App.attachPic };
        $.ajax({
            url: "/Ajax/CreateOriginalMiniBlog/",
            type: "POST",
            cache: false,
            dataType: "json",
            data: data,
            success: function (o) {
                if (o.Code == "A00009") {
                    App.tip(CodeList[o.Code], 1000);
                    if (successCallBack)
                        successCallBack();
                }
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else if (o.Code == "A00016") {
                    App.alert(CodeList[o.Code]);
                }
                else {
                    App.alert(CodeList["A00003"]);
                }
                if (defaultCallBack)
                    defaultCallBack();
            },
            error: function () {
                App.alert(CodeList["A00003"]);
                if (defaultCallBack)
                    defaultCallBack();
            }
        });

    },
    CreateQuoteMiniBlog: function (txtCtr, oriMid, quoMid, isRoot, isLast, successCallBack, defaultCallBack) {
        var con = $.trim($(txtCtr).val()).replace(/\n/g, "");
        con = App.htmlencode(con);
        var data = { Content: con, oriMid: oriMid, quoMid: quoMid, isRoot: isRoot, isLast: isLast };
        $.ajax({
            url: "/Ajax/CreateQuoteMiniBlog/",
            type: "POST",
            cache: false,
            dataType: "json",
            data: data,
            success: function (o) {
                if (o.Code == "A00010") {
                    App.tip(CodeList[o.Code], 1000);
                    if (successCallBack)
                        successCallBack();
                }
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else if (o.Code == "A00016") {
                    App.alert(CodeList[o.Code]);
                }
                else {
                    App.alert(CodeList["A00003"]);
                }
                if (defaultCallBack)
                    defaultCallBack();
            },
            error: function () {
                App.alert(CodeList["A00003"]);
                if (defaultCallBack)
                    defaultCallBack();
            }
        });

    },
    request: function (paras) {
        var url = location.href;
        var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
        var paraObj = {}
        for (i = 0; j = paraString[i]; i++) {
            paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
        }
        var returnValue = paraObj[paras.toLowerCase()];
        if (typeof (returnValue) == "undefined") {
            return "";
        } else {
            return returnValue;
        }
    },
    scaleImg: function (imgA, mid) {
        var dispDiv = $("#disp_" + mid);
        var prevDiv = $("#prev_" + mid);
        var isOri = $("#mid_" + mid).find(".source")[0] == null;
        var imgCon = "<div class=\"blogPicOri\"><p><cite><a  id=\"back_" + mid + "\" href=\"javascript:;\"><img src=\"/Content/Image/transparent.gif\" class=\"small_icon cls\" title=\"收起\">收起</a><cite class=\"MIB_line_l\">|</cite></cite><cite><a  id=\"oriImg_" + mid + "\" target=\"_blank\" href=\"\"><img src=\"/Content/Image/transparent.gif\" class=\"small_icon original\" title=\"查看大图\">查看大图</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a  id=\"left_" + mid + "\" href=\"javascript:;\" ><img src=\"/Content/Image/transparent.gif\" class=\"small_icon turn_l\" title=\"向左转\">向左转</a></cite><cite><a  id=\"right_" + mid + "\" class=\"last_turn_r\" href=\"javascript:;\" ><img src=\"/Content/Image/transparent.gif\" class=\"small_icon turn_r\" title=\"向右转\">向右转</a></cite></p><img src=\"\" class=\"imgSmall\"  id=\"load_" + mid + "\"></div>";
        var elseCon = "";
        var loadIco = $(imgA).next();
        var thumImg = $(imgA).find("img");
        var midImgSrc = thumImg.attr("src").replace("Thum", "Middle");
        var larImgSrc = thumImg.attr("src").replace("Thum", "Large");
        if (isOri) {
            elseCon = "<div class=\"MIB_assign\"><div class=\"MIB_assign_t\"></div><div class=\"MIB_assign_c MIB_txtbl\">{0}</div><div class=\"MIB_assign_b\"></div></div>";
        }
        else {
            elseCon = "<div class=\"MIB_linedot_l1\"></div>{0}";
        }
        dispDiv.html(elseCon.replace("{0}", imgCon));
        loadIco.css("top", parseInt(($(thumImg).height() - 16) / 2));
        loadIco.css("left", parseInt(($(thumImg).width() - 16) / 2));
        loadIco.show();

        $("#oriImg_" + mid).attr("href", larImgSrc);
        $("#load_" + mid).load(function () {
            loadIco.hide();
            prevDiv.hide();
            dispDiv.show();

        }).add($("#back_" + mid)).click(function () {
            prevDiv.show();
            dispDiv.html("");
            dispDiv.hide();
        });
        $("#load_" + mid).attr("src", midImgSrc);
        var R = function (g) {
            g.className = "imgSmall";
            $(g).click(function () {
                prevDiv.show();
                dispDiv.html("").hide();

            });
            g.style.display = "none";
            g.style.display = "inline";
            dispDiv[0].style.cssText = "text-align:center;width:100%;";
        };
        $("#left_" + mid).click(function () {
            App.rotate.rotateLeft("load_" + mid, 90, R, 440);
            return false;
        });
        $("#right_" + mid).click(function () {
            App.rotate.rotateRight("load_" + mid, 90, R, 440);
            return false;
        });
    },
    openVideo: function (mid, vid) {
        var xmlrequst = App.ajaxRequstList.get("mid_" + mid);
        if (xmlrequst != null) {
            xmlrequst.abort();
        }
        var dispDiv = $("#disp_" + mid);
        var prevDiv = $("#prev_" + mid);
        var isOri = $("#mid_" + mid).find(".source")[0] == null;
        var vCon = "<div style=\"margin-bottom: 1px;\"><div><div id=\"videoShow_" + mid + "\" style=\"padding-top: 10px\"></div></div></div>";
        var errorCon = "<div>很抱歉，该内容无法显示，请重试。</div>";
        var loadCon = "<div><center><img src=\"/Content/Image/loading.gif\" style=\"padding-top:20px;padding-bottom:20px\"></center></div>";
        var allCon = "";
        if (isOri) {
            allCon = "<div class=\"MIB_assign\"><div class=\"MIB_assign_t\"></div><div class=\"MIB_assign_c MIB_txtbl\"><div class=\"blogPicOri\"><p><cite><a  id=\"back_" + mid + "\" href=\"javascript:;\" title=\"收起\" onclick=\"return false;\"><img title=\"收起\" class=\"small_icon cls\" src=\"/Content/Image/transparent.gif\">收起</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"title_" + mid + "\" title=\"\" href=\"\" target=\"_blank\"><img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">载入中...</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"pop_" + mid + "\"  onclick=\"return false;\" href=\"####\"><img alt=\"\" title=\"\" class=\"small_icon turn_r\" src=\"/Content/Image/transparent.gif\">弹出</a></cite></p>{0}</div></div><div class=\"MIB_assign_b\"></div></div>";
        }
        else {
            allCon = "<div class=\"MIB_linedot_l1\"></div><p><cite><a id=\"back_" + mid + "\" href=\"javascript:;\" title=\"收起\" onclick=\"return false;\"><img title=\"收起\" class=\"small_icon cls\" src=\"/Content/Image/transparent.gif\">收起</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"title_" + mid + "\" title=\"\" href=\"\" target=\"_blank\"><img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">载入中...</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"pop_" + mid + "\" onclick=\"return false;\" href=\"####\"><img alt=\"\" title=\"\" class=\"small_icon turn_r\" src=\"/Content/Image/transparent.gif\">弹出</a></cite></p>{0}";
        }
        dispDiv.html(allCon.replace("{0}", loadCon));
        dispDiv.show();
        prevDiv.hide();
        $("#back_" + mid).click(function () {
            prevDiv.show();
            dispDiv.html("");
            dispDiv.hide();
            var xmlrequst = App.ajaxRequstList.get("mid_" + mid);
            if (xmlrequst != null) {
                xmlrequst.abort();
            }
        });
        App.ajaxRequstList.add("mid_" + mid, $.ajax({
            dataType: "json",
            data: { Vid: vid },
            url: "/Ajax/GetVideo/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Data != null) {

                    if (o.Code == "A00003")
                        dispDiv.html(allCon.replace("{0}", errorCon));
                    else if (o.Code == "A00001") {
                        App.showLoginDial();
                    }
                    else {
                        dispDiv.html(allCon.replace("{0}", vCon));
                        $("#videoShow_" + mid).html(o.Data.Flv);
                        $("#title_" + mid).attr("href", o.Data.Url);
                        $("#title_" + mid).attr("title", o.Data.Url);
                        $("#title_" + mid).html("<img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">" + o.Data.Title);
                    }
                    App.ajaxRequstList.remove("mid_" + mid);
                    $("#back_" + mid).click(function () {
                        prevDiv.show();
                        dispDiv.html("");
                        dispDiv.hide();
                    });
                    $("#pop_" + mid).click(function () {
                        App.showMediaDiv(o.Data.Flv);
                        prevDiv.show();
                        dispDiv.html("");
                        dispDiv.hide();
                    });
                }
            }, error: function () {
                dispDiv.html(allCon.replace("{0}", errorCon));
                App.ajaxRequstList.remove("mid_" + mid);
                $("#back_" + mid).click(function () {
                    prevDiv.show();
                    dispDiv.html("");
                    dispDiv.hide();
                });
            }
        }));
    },
    playMusic: function (mid, musicid) {
        var xmlrequst = App.ajaxRequstList.get("mid_" + mid);
        if (xmlrequst != null) {
            xmlrequst.abort();
        }
        var dispDiv = $("#disp_" + mid);
        var prevDiv = $("#prev_" + mid);
        var isOri = $("#mid_" + mid).find(".source")[0] == null;
        var vCon = "<div style=\"margin-bottom: 1px;\"><div><div id=\"videoShow_" + mid + "\" style=\"padding-top: 10px\"></div></div></div>";
        var errorCon = "<div>很抱歉，该内容无法显示，请重试。</div>";
        var loadCon = "<div><center><img src=\"/Content/Image/loading.gif\" style=\"padding-top:20px;padding-bottom:20px\"></center></div>";
        var allCon = "";
        if (isOri) {
            allCon = "<div class=\"MIB_assign\"><div class=\"MIB_assign_t\"></div><div class=\"MIB_assign_c MIB_txtbl\"><div class=\"blogPicOri\"><p><cite><a  id=\"back_" + mid + "\" href=\"javascript:;\" title=\"收起\" onclick=\"return false;\"><img title=\"收起\" class=\"small_icon cls\" src=\"/Content/Image/transparent.gif\">收起</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"title_" + mid + "\" title=\"\" href=\"\" target=\"_blank\"><img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">载入中...</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"pop_" + mid + "\"  onclick=\"return false;\" href=\"####\"><img alt=\"\" title=\"\" class=\"small_icon turn_r\" src=\"/Content/Image/transparent.gif\">弹出</a></cite></p>{0}</div></div><div class=\"MIB_assign_b\"></div></div>";
        }
        else {
            allCon = "<div class=\"MIB_linedot_l1\"></div><p><cite><a id=\"back_" + mid + "\" href=\"javascript:;\" title=\"收起\" onclick=\"return false;\"><img title=\"收起\" class=\"small_icon cls\" src=\"/Content/Image/transparent.gif\">收起</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"title_" + mid + "\" title=\"\" href=\"\" target=\"_blank\"><img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">载入中...</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"pop_" + mid + "\" onclick=\"return false;\" href=\"####\"><img alt=\"\" title=\"\" class=\"small_icon turn_r\" src=\"/Content/Image/transparent.gif\">弹出</a></cite></p>{0}";
        }
        dispDiv.html(allCon.replace("{0}", loadCon));
        dispDiv.show();
        prevDiv.hide();
        $("#back_" + mid).click(function () {
            prevDiv.show();
            dispDiv.html("");
            dispDiv.hide();
            var xmlrequst = App.ajaxRequstList.get("mid_" + mid);
            if (xmlrequst != null) {
                xmlrequst.abort();
            }
        });
        App.ajaxRequstList.add("mid_" + mid, $.ajax({
            dataType: "json",
            data: { MusicID: musicid },
            url: "/Ajax/GetMusic/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Data != null) {
                    if (o.Code == "A00003")
                        dispDiv.html(allCon.replace("{0}", errorCon));
                    else if (o.Code == "A00001") {
                        App.showLoginDial();
                    }
                    else {
                        dispDiv.html(allCon.replace("{0}", vCon));
                        $("#videoShow_" + mid).html(o.Data.Flv);
                        $("#title_" + mid).attr("href", o.Data.Url);
                        $("#title_" + mid).attr("title", o.Data.Url);
                        $("#title_" + mid).html("<img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">" + o.Data.Title);
                    }
                    App.ajaxRequstList.remove("mid_" + mid);
                    $("#back_" + mid).click(function () {
                        prevDiv.show();
                        dispDiv.html("");
                        dispDiv.hide();
                    });
                    $("#pop_" + mid).click(function () {
                        App.showMediaDiv(o.Data.Flv);
                        prevDiv.show();
                        dispDiv.html("");
                        dispDiv.hide();
                    });
                }
            }, error: function () {
                dispDiv.html(allCon.replace("{0}", errorCon));
                App.ajaxRequstList.remove("mid_" + mid);
                $("#back_" + mid).click(function () {
                    prevDiv.show();
                    dispDiv.html("");
                    dispDiv.hide();
                });
            }
        }));

    },
    startVote: function (mid, voteid) {
        var xmlrequst = App.ajaxRequstList.get("mid_" + mid);
        if (xmlrequst != null) {
            xmlrequst.abort();
        }
        var dispDiv = $("#disp_" + mid);
        var prevDiv = $("#prev_" + mid);
        var isOri = $("#mid_" + mid).find(".source")[0] == null;
        var vCon = "<div style=\"margin-bottom: 1px;\"><div><div id=\"videoShow_" + mid + "\" style=\"padding-top: 10px\"></div></div></div>";
        var errorCon = "<div>很抱歉，该内容无法显示，请重试。</div>";
        var loadCon = "<div><center><img src=\"/Content/Image/loading.gif\" style=\"padding-top:20px;padding-bottom:20px\"></center></div>";
        var allCon = "";
        if (isOri) {
            allCon = "<div class=\"MIB_assign\"><div class=\"MIB_assign_t\"></div><div class=\"MIB_assign_c MIB_txtbl\"><div class=\"blogPicOri\"><p><cite><a  id=\"back_" + mid + "\" href=\"javascript:;\" title=\"收起\" onclick=\"return false;\"><img title=\"收起\" class=\"small_icon cls\" src=\"/Content/Image/transparent.gif\">收起</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"title_" + mid + "\" title=\"\" href=\"\" target=\"_blank\"><img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">载入中...</a></cite></p><div><div class=\"MIB_linedot_l1\"></div>{0}</div></div></div><div class=\"MIB_assign_b\"></div></div>";
        }
        else {
            allCon = "<div class=\"MIB_linedot_l1\"></div><p><cite><a id=\"back_" + mid + "\" href=\"javascript:;\" title=\"收起\" onclick=\"return false;\"><img title=\"收起\" class=\"small_icon cls\" src=\"/Content/Image/transparent.gif\">收起</a></cite><cite class=\"MIB_line_l\">|</cite><cite><a id=\"title_" + mid + "\" title=\"\" href=\"\" target=\"_blank\"><img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">载入中...</a></cite></p><div><div class=\"MIB_linedot_l1\"></div>{0}</div>";
        }
        dispDiv.html(allCon.replace("{0}", loadCon));
        dispDiv.show();
        prevDiv.hide();
        $("#back_" + mid).click(function () {
            prevDiv.show();
            dispDiv.html("");
            dispDiv.hide();
            var xmlrequst = App.ajaxRequstList.get("mid_" + mid);
            if (xmlrequst != null) {
                xmlrequst.abort();
            }
        });
        App.ajaxRequstList.add("mid_" + mid, $.ajax({
            dataType: "json",
            data: { mid: mid, vid: voteid },
            url: "/Ajax/GetVoteFeedHtml/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Data != null) {
                    if (o.Code == "A00003")
                        dispDiv.html(allCon.replace("{0}", errorCon));
                    else if (o.Code == "A00001") {
                        App.showLoginDial();
                    }
                    else {
                        dispDiv.html(allCon.replace("{0}", vCon));
                        $("#videoShow_" + mid).html(o.Data);
                        $("#title_" + mid).attr("href", o.Url);
                        $("#title_" + mid).attr("title", o.Url);
                        $("#title_" + mid).html("<img class=\"small_icon original\" src=\"/Content/Image/transparent.gif\">" + o.Title);

                        var voteDiv = $("div[voteDiv='" + voteid + "']");
                        var isJoined = voteDiv.attr("isJoined") == "true";
                        var isExpire = voteDiv.attr("isExpire") == "true";
                        var maxSel = parseInt(voteDiv.attr("maxSel"));
                        var voteBtn = voteDiv.find(".onvote_btn02");
                        var optionCount = parseInt(voteDiv.attr("optionCount"));
                        if (!isJoined && !isExpire) {
                            var optionCtls = voteDiv.find("input[name='item_id']").change(function () {

                                if (maxSel != -1) {
                                    var selectedCount = 0;
                                    for (var i = 1; i <= optionCount; i++) {
                                        if ($("#checked_" + voteid + "_" + i)[0].checked) {
                                            selectedCount++;
                                        }

                                    }
                                    if (selectedCount <= maxSel && selectedCount != 0) {
                                        voteBtn.attr("class", "onvote_btn01");
                                    }
                                    else {
                                        voteBtn.attr("class", "onvote_btn02");
                                    }
                                }
                                else if (this.checked) {
                                    voteBtn.attr("class", "onvote_btn01");
                                }
                            });
                        }
                        voteBtn.click(function () {
                            if (this.className == "onvote_btn01" && !this.locked) {
                                this.locked = true;
                                this.className = "onvote_btn02"
                                var selItemIDs = "";
                                for (var i = 1; i <= optionCount; i++) {
                                    if ($("#checked_" + voteid + "_" + i)[0].checked) {
                                        selItemIDs += $("#checked_" + voteid + "_" + i)[0].value + ",";
                                    }

                                }
                                var curbtn = this;
                                var niming = voteDiv.find("#niming")[0].checked ? 1 : "";
                                var feedMiniblog = voteDiv.find("#share")[0].checked ? 1 : "";
                                $.ajax({
                                    dataType: "json",
                                    data: { vid: voteid, selItemIDs: selItemIDs, niMing: niming, feedMiniBlog: feedMiniblog },
                                    url: "/Ajax/JoinVote/",
                                    cache: false,
                                    type: "post",
                                    success: function (o) {
                                        if (o.Code == "A00003")
                                            App.fullTip(CodeList[o.Code], 1000, null, 1);
                                        else if (o.Code == "A00001") {
                                            App.showLoginDial();
                                        }
                                        else {
                                            $("#back_" + mid).click();
                                            App.fullTip(CodeList[o.Code], 1000, null, 1);
                                        }
                                        curbtn.className = "onvote_btn01";
                                        curbtn.locked = false;
                                    },
                                    error: function () {
                                        App.fullTip(CodeList["A00003"], 1000, null, 1);
                                        curbtn.className = "onvote_btn01";
                                        curbtn.locked = false;
                                    }
                                });
                            }
                        });
                    }
                    App.ajaxRequstList.remove("mid_" + mid);
                    $("#back_" + mid).click(function () {
                        prevDiv.show();
                        dispDiv.html("");
                        dispDiv.hide();
                    });
                    $("#pop_" + mid).click(function () {
                        App.showMediaDiv(o.Data.Flv);
                        prevDiv.show();
                        dispDiv.html("");
                        dispDiv.hide();
                    });
                }
            }, error: function () {
                dispDiv.html(allCon.replace("{0}", errorCon));
                App.ajaxRequstList.remove("mid_" + mid);
                $("#back_" + mid).click(function () {
                    prevDiv.show();
                    dispDiv.html("");
                    dispDiv.hide();
                });
            }
        }));

    },

    showFeedDiv: function (mid, isOri, oriMid) {
        $.ajax({
            dataType: "json",
            url: "/Ajax/InitQuoteBox/",
            data: { mid: mid },
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00005") {
                    if (App.initDialDiv("divFeedTabDiv", dialDiv, false, null)) {
                        $("#divFeedTabDiv").removeClass("4CancelAllLayer");
                        $("#divFeedTabDiv").find(".mid_c").html(feedTabDiv);
                        App.showMash();
                        $("#divFeedTabDiv .layerBoxCon").html(feedConDiv);
                        var position = App.centerInScreen($("#divFeedTabDiv"));
                        $("#divFeedTabDiv").css("left", position.left + "px");
                        $("#divFeedTabDiv").css("top", position.top + "px");
                        $("#divFeedTabDiv").find(".close").click(function () {
                            $("#divFeedTabDiv").remove();
                            App.hideMash();
                        });
                        var tabs = $("#divFeedTabDiv .lv_nav").find("li");
                        tabs.click(function () {
                            if (this.className == "cur")
                                return;
                            else {
                                if ($(this).next()[0] != null) {
                                    App.tabToFeed(mid, isOri, oriMid, o.Data);
                                    this.className = "cur";
                                    $(this).next()[0].className = "";
                                }
                                else {
                                    App.tabToMes(mid, isOri, o.Data);
                                    this.className = "cur";
                                    $(this).prev()[0].className = "";
                                }
                                this.className = "cur";
                            }
                        });

                    }

                    App.tabToFeed(mid, isOri, oriMid, o.Data);
                    return false;
                }
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else {
                    App.alert(CodeList["A00003"]);
                }
            },
            error: function () {
                App.alert(CodeList["A00003"]);
            }
        });

    },
    tabToMes: function (mid, isOri, Data) {
        $("#divFeedTabDiv .layerBoxCon").html(mesgConDiv);
        var txtName = $("#divFeedTabDiv").find(".inputtxt1");
        var txtCon = $("#divFeedTabDiv").find("#PY_txt");
        var sendLink = $(".MIB_btn").find("a")[0];
        var $sendLink = $(sendLink);
        var calLink = $(".MIB_btn").find("a")[1];
        var $calLink = $(calLink);
        var numshowElem = $("#divFeedTabDiv .rt");

        App.bindTxtarea(txtCon[0], { IsEnableAuto: true, keyUpCallBack: function () {
            if (!App.checkTxtLen(numshowElem, ["<span class=\"normal\">还可以输入{0}个汉字</span>", "<span class=\"wrong\">已超出{0}个汉字</span>"], txtCon)) {
                sendLink.locked = true;
                $sendLink.attr("class", "btn_notclick");
            }
            else {
                sendLink.locked = false;
                $sendLink.attr("class", "newabtn_ok");
            }
        }
        });
        if (isOri == 1) {
            txtCon.val("给你推荐一条微博：//" + Data.Name + "：" + Data.Content + "-原文地址：" + Data.url);
        }
        else {
            txtCon.val("给你推荐一条微博：//" + Data.Name + "：" + Data.Content + "//" + Data.oriName + "：" + Data.oriContent + "-原文地址：" + Data.url);
        }
        this.autoComplete(txtName, function (id, name) { txtName.val(name); App.OriKey = "" }, "GetFollowListByKey");
        var isPush = false;
        for (var i = 0; i < App.TimerFunArray.length; i++) {
            if (App.TimerFunArray[i] == this.autoCompleteTimerEvent) {
                isPush = true;
            }
        }
        if (!isPush) {
            App.TimerFunArray.push(this.autoCompleteTimerEvent);
        }
        $calLink.click(function () {
            $("#divFeedTabDiv").remove();
            App.hideMash();
        });
        $("#divFeedTabDiv .faceicon1").click(function () {
            return App.showExpression(txtCon, $(this));
        });
        App.setCursorPosition(txtCon[0], 0);
        txtCon.mouseup();
        txtCon.attr("range", "0&0");
        if (!App.checkTxtLen(numshowElem, ["<span class=\"normal\">还可以输入{0}个汉字</span>", "<span class=\"wrong\">已超出{0}个汉字</span>"], txtCon)) {
            sendLink.locked = true;
            $sendLink.attr("class", "btn_notclick");
        }
        else {
            sendLink.locked = false;
            $sendLink.attr("class", "newabtn_ok");
        }
        $sendLink.click(function () {
            if (sendLink.locked)
                return;
            if (!App.checkTxtLen(numshowElem, ["<span class=\"normal\">还可以输入{0}个汉字</span>", "<span class=\"wrong\">已超出{0}个汉字</span>"], txtCon)) {
                sendLink.locked = true;
                $sendLink.attr("class", "btn_notclick");
                return;
            }
            if ($.trim(txtName.val()) == "") {
                App.highLineTxtBox(txtName);
                return;
            }
            if ($.trim(txtCon.val()) == "") {
                App.highLineTxtBox(txtCon);
                return;
            }
            if (this.locked)
                return;
            this.locked = true;
            var thisBtn = this;
            App.AddMessage($.trim(txtName.val()), $.trim(txtCon.val()), function () {
                $("#divFeedTabDiv").remove();
                App.hideMash();
                App.fullTip("发送成功", 1000, null, 3);
            }, function () { thisBtn.locked = false; });
        });
    },
    tabToFeed: function (mid, isOri, oriMid, Data) {
        $("#divFeedTabDiv .layerBoxCon").html(feedConDiv);
        var $txtbox = $("#divFeedTabDiv").find("#PY_txt");
        var txtbox = $txtbox[0];
        var sms = $("#mid_" + mid).find(".sms");
        var source = $("#mid_" + mid).find(".source");
        if (isOri == 1) {
            $(".laymoveText").html(sms.html());
            $("#isLast").next().text("同时评论给 " + Data.Name);
            $("#isRoot").hide().next().hide();
        }
        else {
            $(".laymoveText").html(source.html());
            $("#isLast").next().text("同时评论给 " + Data.Name);
            $("#isRoot").next().text("同时评论给原作者 " + Data.oriName);
            $txtbox.val("//@" + Data.Name + "：" + Data.Content);
        }
        $("#divFeedTabDiv .faceicon1").click(function () {
            return App.showExpression($txtbox, $(this));
        });
        var sendLink = $(".MIB_btn").find("a")[0];
        var $sendLink = $(sendLink);
        var calLink = $(".MIB_btn").find("a")[1];
        var $calLink = $(calLink);
        var numshowElem = $("#divFeedTabDiv .rt");

        App.bindTxtarea(txtbox, { IsEnableAuto: true, keyUpCallBack: function () {
            if (!App.checkTxtLen(numshowElem, ["<span class=\"normal\">还可以输入{0}个汉字</span>", "<span class=\"wrong\">已超出{0}个汉字</span>"], $txtbox)) {
                sendLink.locked = true;
                $sendLink.attr("class", "btn_notclick");
            }
            else {
                sendLink.locked = false;
                $sendLink.attr("class", "newabtn_ok");
            }
        }
        });
        App.setCursorPosition(txtbox, 0);
        $txtbox.mouseup();
        $txtbox.attr("range", "0&0");
        $calLink.click(function () {
            $("#divFeedTabDiv").remove();
            App.hideMash();
        });
        if (!App.checkTxtLen(numshowElem, ["<span class=\"normal\">还可以输入{0}个汉字</span>", "<span class=\"wrong\">已超出{0}个汉字</span>"], $txtbox)) {
            sendLink.locked = true;
            $sendLink.attr("class", "btn_notclick");
        }
        else {
            sendLink.locked = false;
            $sendLink.attr("class", "newabtn_ok");
        }
        $txtbox.JQP_HighLineInput2({ nullCon: "随便说点什么吧..." });
        $sendLink.click(function () {
            if (sendLink.locked)
                return;
            if (!App.checkTxtLen(numshowElem, ["<span class=\"normal\">还可以输入{0}个汉字</span>", "<span class=\"wrong\">已超出{0}个汉字</span>"], $txtbox)) {
                sendLink.locked = true;
                $sendLink.attr("class", "btn_notclick");
                return;
            }

            var quoMid = mid;
            if (oriMid == "-1") {
                oriMid = quoMid;
            }
            var isLast = null;
            var isRoot = null;
            if ($("#isLast")[0] != null) {
                if ($("#isLast")[0].checked) {
                    isLast = 1;
                }
            }
            if ($("#isRoot")[0] != null) {
                if ($("#isRoot")[0].checked) {
                    isRoot = 1;
                }
            }
            sendLink.locked = true;
            $sendLink.attr("class", "btn_notclick");
            App.CreateQuoteMiniBlog($txtbox, oriMid, quoMid, isRoot, isLast, function () {
                App.tip("转发成功", 1000);
            }, function () {
                sendLink.locked = false;
                $sendLink.attr("class", "newabtn_ok");
                $("#divFeedTabDiv").remove();
                App.hideMash();
            });
        });
    },
    htmlencode: function (str) {
        var s = "";
        if (str.length == 0) return "";
        s = str.replace(/&/g, "&amp;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        return s;
    },
    htmldecode: function (str) {
        var s = "";
        if (str.length == 0) return "";
        s = str.replace(/&amp;/g, "&");
        s = s.replace(/&lt;/g, "<");
        s = s.replace(/&gt;/g, ">");
        return s;
    },
    oKey: "",
    isShowAtWho: false,
    isKeyUp: false,
    ajaxAtWho: function () {
        if (App.isKeyUp) {
            App.isKeyUp = false;
            if ($(App.TargetTextarea)[0] == null)
                return;
            var atStart = App.getAtPos($(App.TargetTextarea)[0]);
            var key = "";
            if (atStart != -1) {

                $("#preSpan").html($(App.TargetTextarea)[0].value.substr(0, atStart).replace(/\n/g, "<br>").replace(/\s/g, $.browser.msie ? "<PRE style=\"DISPLAY: inline; OVERFLOW: hidden;font-family: Tahoma,宋体;WORD-WRAP: break-word\"> </PRE>" : "<span style='white-space:pre-wrap;font-family: Tahoma,宋体;'> </span>"));
                $("#rearSpan").html($(App.TargetTextarea)[0].value.substr(atStart + 1).replace(/\n/g, "<br>").replace(/\s/g, $.browser.msie ? "<PRE style=\"DISPLAY: inline; OVERFLOW: hidden;font-family: Tahoma,宋体;WORD-WRAP: break-word\"> </PRE>" : "<span style='white-space:pre-wrap;font-family: Tahoma,宋体;'> </span>"));

                $("#HideTextArea").scrollTop($(App.TargetTextarea).scrollTop());
                var offset = $("#atSpan").offset();
                offset.top += 20;
                $(".Atwho").css("top", offset.top).css("left", offset.left);

                var curpos = App.getPos(App.TargetTextarea);
                var atLength = curpos.start - atStart - 1;
                var key = $(App.TargetTextarea)[0].value.substr(atStart + 1, atLength);
                if (App.oKey == key)
                    return;
                else if ($("#rearSpan").text() == "") {
                    $(".Atwho").hide();
                    App.isShowAtWho = false;
                    App.oKey = "";
                    return;
                }
                else {
                    $(".Atwho").show();
                    App.isShowAtWho = true;
                    App.oKey = key;
                    $.ajax({
                        dataType: "json",
                        data: { key: key },
                        url: "/Ajax/GetFollowListByKey/",
                        cache: false,
                        type: "post",
                        success: function (o) {
                            var str = "<div style=\"height:20px;color:#999999;padding-left:8px;padding-top:2px;line-height:18px;font-size:12px;Tahoma,宋体;\">想用@提到谁？</div>";
                            if (o.Code == "A00017") {
                                str += ("<li curName='" + key + "' class='cur'>" + key + "</li>");
                            }
                            else {
                                for (var i = 0; i < o.Data.length; i++) {
                                    if (i == 0)
                                        str += ("<li curName='" + o.Data[i].NickName + "' class='cur'>" + o.Data[i].Title.replace(new RegExp("(" + key + ")", "gi"), "<b>$1</b>") + "</li>");
                                    else
                                        str += ("<li curName='" + o.Data[i].NickName + "'>" + o.Data[i].Title.replace(new RegExp("(" + key + ")", "gi"), "<b>$1</b>") + "</li>");
                                }
                            }
                            $(".Atwho ul").html(str);
                            $(".Atwho ul").find("li").hover(function () {
                                $(".Atwho ul").find("li").removeClass("cur");
                                $(this).addClass("cur");
                            }).click(function () {
                                App.setAtVal($(App.TargetTextarea)[0], $(this).attr("curName") + " ");
                                $(".Atwho").hide();
                                App.isShowAtWho = false;
                            });
                        }
                    });

                }
            }
            else {
                App.oKey = "";
                $(".Atwho").hide();
                App.isShowAtWho = false;
            }
        }

    },
    getPos: function (textBox) {
        start = parseInt($(textBox).attr("range").split("&")[0]);
        var sel = parseInt($(textBox).attr("range").split("&")[1]);
        return { start: start, sel: sel };
    },
    getAtPos: function (textBox) {
        var pos = App.getPos(textBox);
        while (pos.start >= 0) {
            pos.start = pos.start - 1;
            if (textBox.value.substr(pos.start, 1) == "@")
                return pos.start;
            else if (textBox.value.substr(pos.start, 1) == " ")
                return -1;
            else if (textBox.value.substr(pos.start, 1) == "\n")
                return -1;
            else if (textBox.value.substr(pos.start, 1) == ":")
                return -1;
            else if (textBox.value.substr(pos.start, 1) == "：")
                return -1;
        }
        return -1;
    },
    setAtVal: function (textBox, insertVal) {

        var con = $(textBox)[0].value;
        var start = App.getAtPos(textBox) + 1;
        var end = parseInt($(textBox).attr("range").split("&")[0]);
        var pre = con.substr(0, start);
        var last = con.substr(end);
        $(textBox).val(pre + insertVal + last);
        App.setCursorPosition(textBox, (pre + insertVal).length);
        App.saveTxtCtrlRangePos(textBox);
    },
    setCursorPosition: function (ctrl, pos) {
        if (ctrl.setSelectionRange) {
            ctrl.focus();
            ctrl.setSelectionRange(pos, pos);
        }
        else if (ctrl.createTextRange) {
            var length = pos;
            for (var i = 1; i < length; i++) {
                if (ctrl.value.charAt(i) == '\n') {
                    pos--;
                }
            }
            var range = ctrl.createTextRange();
            range.collapse(true);
            range.moveEnd('character', pos);
            range.moveStart('character', pos);
            range.select();
        }
    },
    checkTxtLen: function (insertWhere, insertTemp, txtCtr) {
        var normal = insertTemp[0];
        var error = insertTemp[1];
        var curLen = App.getTxtLen($(txtCtr));

        if (curLen <= 280) {
            $(insertWhere).html(normal.replace("{0}", parseInt((280 - curLen) / 2)));
            return true;
        }
        else {
            $(insertWhere).html(error.replace("{0}", parseInt((curLen - 280 + 1) / 2)));
            return false;
        }

    },

    GetStringByte: function (g, a) {
        var b = g.replace(/\*/g, " ").replace(/[^\x00-\xff]/g, "**");
        g = g.slice(0, b.slice(0, a).replace(/\*\*/g, " ").replace(/\*/g, "").length);
        if (App.byteLength(g) > a) {
            g = g.slice(0, g.length - 1)
        }
        return g
    },
    byteLength: function (b) {
        if (typeof b == "undefined") {
            return 0
        }
        var a = b.match(/[^\x00-\x80]/g);
        return (b.length + (!a ? 0 : a.length))
    },
    rotate: {
        rotateRight: function (a, g, h, b) {
            this._img[a] = this._img[a] || {};
            this._img[a]._right = this._img[a]._right || 0;
            this._img[a]._right++;
            this._rotate(a, g == undefined ? 90 : g, h, b)
        },
        rotateLeft: function (a, g, h, b) {
            this._img[a] = this._img[a] || {};
            this._img[a]._left = this._img[a]._left || 0;
            this._img[a]._left++;
            this._rotate(a, g == undefined ? -90 : -g, h, b)
        },
        _img: {},
        _rotate: function (m, h, s, r) {
            var b = App.E(m);
            b.angle = ((b.angle == undefined ? 0 : b.angle) + h) % 360;
            if (b.angle >= 0) {
                var u = Math.PI * b.angle / 180
            } else {
                var u = Math.PI * (360 + b.angle) / 180
            }
            var q = Math.cos(u);
            var j = Math.sin(u);
            if (document.all && !window.opera) {
                var g = document.createElement("img");
                g.src = b.src;
                g.height = b.height;
                g.width = b.width;
                if (!this._img[m]._initWidth) {
                    this._img[m]._initWidth = g.width;
                    this._img[m]._initHeight = g.height
                }
                if (g.height > r + 8) {
                    g._w1 = g.width;
                    g._h1 = g.height;
                    g.height = r - 4;
                    g.width = (g._w1 * g.height) / g._h1
                }
                g.style.filter = "progid:DXImageTransform.Microsoft.Matrix(M11=" + q + ",M12=" + (-j) + ",M21=" + j + ",M22=" + q + ",SizingMethod='auto expand')";
                var o = this;
                setTimeout(function () {
                    var v = o._img[m]._left,
                p = o._img[m]._right;
                    if (p % 2 == 0 || v % 2 == 0 || Math.abs(p - v) % 2 == 0) {
                        g.width = o._img[m]._initWidth - 4;
                        g.height = o._img[m]._initHeight - 4
                    }
                    if ((v === 1 && !p) || (!v && p === 1)) {
                        o._img[m]._width = g.width;
                        o._img[m]._height = g.height
                    }
                    if (p > 0 && v > 0 && Math.abs(p - v) % 2 != 0) {
                        g.width = o._img[m]._width - 4;
                        g.height = o._img[m]._height - 4
                    }
                },
            0)
            } else {
                var g = document.createElement("canvas");
                if (!b.oImage) {
                    g.oImage = b
                } else {
                    g.oImage = b.oImage
                }
                g.style.width = g.width = Math.abs(q * g.oImage.width) + Math.abs(j * g.oImage.height);
                g.style.height = g.height = Math.abs(q * g.oImage.height) + Math.abs(j * g.oImage.width);
                if (g.width > r) {
                    g.style.width = r + "px"
                }
                var a = g.getContext("2d");
                a.save();
                if (u <= Math.PI / 2) {
                    a.translate(j * g.oImage.height, 0)
                } else {
                    if (u <= Math.PI) {
                        a.translate(g.width, -q * g.oImage.height)
                    } else {
                        if (u <= 1.5 * Math.PI) {
                            a.translate(-q * g.oImage.width, g.height)
                        } else {
                            a.translate(0, -j * g.oImage.width)
                        }
                    }
                }
                a.rotate(u);
                try {
                    a.drawImage(g.oImage, 0, 0, g.oImage.width, g.oImage.height)
                } catch (n) { }
                a.restore()
            }
            g.id = b.id;
            g.angle = b.angle;
            b.parentNode.replaceChild(g, b);
            if (s && typeof s === "function") {
                s(g)
            }
        }
    },
    removeTag: function (str) {
        var reg = new RegExp("<img\\s+title=\"?([^\"]+)\"?\\s+src=\"[^>]*\">", "gi");
        str = str.replace(reg, "[$1]");
        reg = new RegExp("<[^>]*>", "gi");
        str = str.replace(reg, "");
        return $.trim(str);
    },
    ajaxRequstList: new Hashtable(),
    showMediaDiv: function (media) {
        if (App.initDialDiv("MediaConDiv", dialDiv, false, null)) {
            $("#MediaConDiv").removeClass("4CancelAllLayer");
            $("#MediaConDiv").find(".mid_c").html(mediaConDiv);
            $("#MediaConDiv").find("#mediaCon").html(media);
            $("#MediaConDiv").show();

        }
        else {
            $("#MediaConDiv").find("#mediaCon").html(media);
            $("#MediaConDiv").show();
        }
        if ($.browser.msie && $.browser.version == "6.0") {
            var st = $(document).scrollTop(), winh = $(window).height();
            winw = $(window).width();
            var mWidth = $("#MediaConDiv").width();
            var mHeight = $("#MediaConDiv").height();
            $("#MediaConDiv").css("top", st + winh - mHeight);
            $("#MediaConDiv").css("left", winw - mWidth);
            $(window).unbind(".sjj");
            $(window).bind("scroll.sjj", function () {
                st = $(document).scrollTop();
                $("#MediaConDiv").css("top", st + winh - mHeight);
                $("#MediaConDiv").css("left", winw - mWidth);
            });
        }
        else {
            $("#MediaConDiv").css("position", "fixed").css("bottom", 0).css("right", 0);

        }
        $("#pop_video_window_close").click(function () {
            $("#MediaConDiv").hide();
            $("#MediaConDiv").find("#mediaCon").html("");
        });
    },
    DelCommentFromBox: function (alink, cid, mid) {
        this.confirm("是否删除该条评论", function () {
            if (alink.locked)
                return false;
            alink.locked = true;
            App.DelComment(cid, function (data) {
                var list = $("#comment_list_" + mid);
                list.find(".PL_list").remove();
                list.find(".moreheight").remove();
                list.find(".MIB_assign_c").append(data);
                App.initNameCard(list);
            }, function () {
                alink.locked = false;
            });
            return false;
        });
        return false;
    },
    DelCommentFromPager: function (alink, cid, mid) {
        this.confirm("是否删除该条评论", function () {
            if (alink.locked)
                return false;
            alink.locked = true;
            App.DelComment(cid, function (data) {
                $(alink).parent().parent().fadeOut();
            }, function () {
                alink.locked = false;
            });
            return false;
        });
        return false;
    },
    InsertCommentBox: function (mid, ownerUid) {
        var xmlrequst = App.ajaxRequstList.get("mid_c" + mid);
        if (xmlrequst != null) {
            xmlrequst.abort();
        }
        if ($.trim($("#comment_list_" + mid).html()) == "") {
            $("#comment_list_" + mid).html("<div style=\"padding:30px 0;text-align:center\"><img src=\"/Content/Image/loading.gif\"></div>");
            App.ajaxRequstList.add("mid_c" + mid, $.ajax({
                dataType: "json",
                data: { Mid: mid, OwnerUid: ownerUid },
                url: "/Ajax/GetComments/",
                cache: false,
                type: "post",
                success: function (o) {
                    if (o.Code == "A00003")
                        App.alert(CodeList[o.Code]);
                    else if (o.Code == "A00011")
                        App.alert(CodeList[o.Code]);
                    else if (o.Code == "A00001") {
                        App.showLoginDial();
                    }
                    else {

                        var list = $("#comment_list_" + mid).html(o.Data);
                        App.initNameCard(list);
                        var $textbox = $("#comment_content_" + mid);
                        var textbox = $textbox[0];
                        list.find(".faceicon1").click(function (e) {
                            e.stopPropagation();
                            App.showExpression(textbox, this);
                        });

                        App.bindTxtarea(textbox, { IsEnableAuto: true, keyUpCallBack: function () {
                            if (App.getTxtLen(textbox) > 280) {
                                textbox.value = App.GetStringByte(textbox.value, 280);
                            }
                        }
                        });

                        var post = $("#comment_post_" + mid).click(function () {
                            $textbox.keyup();
                            if ($.trim(textbox.value) == "") {
                                App.alert("请输入内容");
                                textbox.focus();
                                return;
                            }
                            if (this.locked) {
                                App.alert("ff");
                                return;
                            }

                            this.locked = true;
                            var alink = this;
                            $(this).attr("class", "btn_notclick");
                            var replyUID = null;
                            var replyCID = null;
                            if (textbox.value.lastIndexOf("回复@" + textbox.nickName) == 0) {
                                replyCID = textbox.replycid;
                                replyUID = textbox.replyuid;
                                if (textbox.value.length <= ("回复@" + textbox.nickName + ":").length) {
                                    App.alert("请输入内容");
                                    textbox.focus();
                                    return;
                                }
                            }
                            var agree = null;
                            var isRoot = null;
                            if ($("#isroot_" + mid)[0] != null) {
                                if ($("#isroot_" + mid)[0].checked) {
                                    isRoot = 1;
                                }
                            }
                            if ($("#agree_" + mid)[0] != null) {
                                if ($("#agree_" + mid)[0].checked) {
                                    agree = 1;
                                }
                            }
                            App.addComment(mid, ownerUid, textbox.value, replyCID, replyUID, agree, isRoot, function (Data) {
                                list.find(".PL_list").remove();
                                list.find(".moreheight").remove();
                                list.find(".MIB_assign_c").append(Data);
                                App.initNameCard(list);
                            }, function () {
                                alink.locked = false;
                                $(alink).attr("class", "btn_normal");
                                textbox.value = "";
                            });

                            return false;
                        });
                    }
                    var x = App.ajaxRequstList.get("mid_c" + mid);
                    if (x != null)
                        App.ajaxRequstList.remove("mid_c" + mid);
                },
                error: function () {
                    var x = App.ajaxRequstList.get("mid_c" + mid);
                    if (x != null)
                        App.ajaxRequstList.remove("mid_c" + mid);
                }
            }));
        }
        else {
            $("#comment_list_" + mid).html("");
        }
    },
    addComment: function (Mid, OwnerUid, content, replyCid, replyUid, agree, isRoot, successCallback, defaultCallback) {
        if (App.byteLength(content) > 280) {
            content = App.GetStringByte(content, 280);
        }
        content = App.htmlencode(content);
        $.ajax({
            dataType: "json",
            data: { Mid: Mid,
                OwnerUid: OwnerUid,
                content: content,
                replyCid: replyCid,
                replyUid: replyUid,
                agree: agree,
                isRoot: isRoot
            },
            url: "/Ajax/AddComment/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00003")
                    App.alert(CodeList[o.Code]);
                else if (o.Code == "A00011")
                    App.alert(CodeList[o.Code]);
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else if (o.Code == "A00016") {
                    App.alert(CodeList[o.Code]);
                }
                else if (o.Code == "A00026") {
                    App.alert(CodeList[o.Code]);
                }
                else if (o.Code == "A00028") {
                    App.alert(CodeList[o.Code]);
                }
                else {
                    if (successCallback) {
                        successCallback(o.Data);
                    }
                }
                if (defaultCallback) {
                    defaultCallback();
                }
            },
            error: function () {
                App.alert(CodeList["A00003"]);
                if (defaultCallback) {
                    defaultCallback();
                }
            }
        });

    },
    DelComment: function (cid, successCallback, defaultCallback) {
        $.ajax({
            dataType: "json",
            data: { cid: cid },
            url: "/Ajax/DelComment/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00003")
                    App.alert(CodeList[o.Code]);
                else if (o.Code == "A00011")
                    App.alert(CodeList[o.Code]);
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else {
                    if (successCallback) {
                        successCallback(o.Data);
                    }
                }
                if (defaultCallback) {
                    defaultCallback();
                }
            },
            error: function () {
                App.alert(CodeList["A00003"]);
                if (defaultCallback) {
                    defaultCallback();
                }
            }
        });

    },
    bindAddComment: function (alink, mid, ownerUid, txtboxid, agreeid, rootid) {
        var $textbox = $("#" + txtboxid);
        var textbox = $textbox[0];
        $textbox.keyup();
        if ($.trim(textbox.value) == "") {
            App.alert("请输入内容");
            textbox.focus();
            return;
        }



        var replyUID = null;
        var replyCID = null;
        if (textbox.value.lastIndexOf("回复@" + textbox.nickName) == 0) {
            replyCID = textbox.replycid;
            replyUID = textbox.replyuid;
            if (textbox.value.length <= ("回复@" + textbox.nickName + ":").length) {
                App.alert("请输入内容");
                textbox.focus();
                return;
            }
        }
        if (alink.locked) {
            App.alert("ff");
            return;
        }

        alink.locked = true;
        $(alink).attr("class", "btn_notclick");
        var agree = null;
        var isRoot = null;
        if ($("#" + rootid)[0] != null) {
            if ($("#" + rootid)[0].checked) {
                isRoot = 1;
            }
        }
        if ($("#" + agreeid)[0] != null) {
            if ($("#" + agreeid)[0].checked) {
                agree = 1;
            }
        }
        App.addComment(mid, ownerUid, textbox.value, replyCID, replyUID, agree, isRoot, function (Data) {
        }, function () {
            alink.locked = false;
            $(alink).attr("class", "btn_normal");
            textbox.value = "";
            App.GetPagerComments(mid, ownerUid, 0, 1, 20);
            $('.navStyle .lf').hide()[0].style.display = 'block';
        });
    },
    GetPagerComments: function (mid, ownerUid, isFollow, page, pagesize) {
        $.ajax(
       {
           async: false,
           url: "/Ajax/GetPagerCommentsList/",
           datatype: "json",
           cache: false,
           data: { Mid: mid, OwnerUid: ownerUid, Page: page, PageSize: pagesize, isFollow: isFollow },
           type: "post",
           success: function (o) {
               if (o.Code == "A00003")
                   App.alert(CodeList[o.Code]);
               else if (o.Code == "A00011")
                   App.alert(CodeList[o.Code]);
               else {
                   $(".commentsList").html(o.Data);
                   App.initNameCard($(".commentsList"));
                   $("#CommentCount").text(o.Count);
                   if (parseInt(o.Count) > 20) {
                       if ($(".fanye")[0] == null) {
                           $(".commentsmanage").append("<div class=\"fanye MIB_txtbl MIB_linedot3\"></div>");
                           $(".navStyle").append("<div class=\"fanye MIB_txtbl\"></div>");
                       }
                       App.buildCommentPage(o, mid, ownerUid, page, pagesize, isFollow);
                   }
                   else {
                       if ($(".fanye")[0]) {
                           $(".fanye").remove();
                       }
                   }
               }
           },
           error: function (request) {
               App.alert(CodeList["A00003"]);
           }
       }
    );

    },
    ReplyComment: function (cid, cuid, nickName, mid) {
        var $textbox = $("#comment_content_" + mid);
        var textbox = $textbox[0];
        textbox.replycid = cid;
        textbox.replyuid = cuid;
        textbox.nickName = nickName;
        textbox.value = "";
        App.insertTxt2Txtarea(textbox, "回复@" + nickName + ":");
    },
    ReplyComment4Details: function (cid, cuid, nickName, mid) {
        var $replyElem = $("#comment_reply_" + mid + "_" + cid);
        if (!App.isVisible($replyElem)) {
            $replyElem.show();
            var $textbox = $("#comment_content_" + mid + "_" + cid);
            var $face = $("#comment_face_" + mid + "_" + cid);
            var textbox = $textbox[0];
            textbox.replycid = cid;
            textbox.replyuid = cuid;
            textbox.nickName = nickName;
            textbox.value = "";
            App.bindTxtarea(textbox, { IsEnableAuto: true, keyUpCallBack: function () {
                if (App.getTxtLen(textbox) > 280) {
                    textbox.value = App.GetStringByte(textbox.value, 280);
                }
            }
            });
            $face.click(function (e) {
                e.stopPropagation();
                App.showExpression($textbox, this);
                return false;
            });
            App.insertTxt2Txtarea(textbox, "回复@" + nickName + ":");
        }
        else {
            $replyElem.hide();
        }
    },
    bindAddCommentBtn: function (alink, mid, ownerUid, txtboxid, agreeid, rootid) {
        var $textbox = $("#" + txtboxid);
        var textbox = $textbox[0];
        $textbox.keyup();
        if ($.trim(textbox.value) == "") {
            App.alert("请输入内容");
            textbox.focus();
            return;
        }



        var replyUID = null;
        var replyCID = null;
        if (textbox.value.lastIndexOf("回复@" + textbox.nickName) == 0) {
            replyCID = textbox.replycid;
            replyUID = textbox.replyuid;
            if (textbox.value.length <= ("回复@" + textbox.nickName + ":").length) {
                App.alert("请输入内容");
                textbox.focus();
                return;
            }
        }
        if (alink.locked) {
            App.alert("ff");
            return;
        }

        alink.locked = true;
        $(alink).attr("class", "btn_notclick");
        var agree = null;
        var isRoot = null;
        if ($("#" + rootid)[0] != null) {
            if ($("#" + rootid)[0].checked) {
                isRoot = 1;
            }
        }
        if ($("#" + agreeid)[0] != null) {
            if ($("#" + agreeid)[0].checked) {
                agree = 1;
            }
        }
        App.addComment(mid, ownerUid, textbox.value, replyCID, replyUID, agree, isRoot, function (Data) {
            App.fullTip("回复成功", 1000, null, 3);
        }, function () {
            alink.locked = false;
            $(alink).attr("class", "btn_normal");
            textbox.value = "";
        });
    },
    hideExtendBtn: function (ctrl) {
        $(ctrl).find("div[extend='true']").css("visibility", "hidden");
        $(ctrl).find("a[extend='true']").css("visibility", "hidden");
        $(ctrl).find("span[extend='true']").css("visibility", "hidden");
        $(ctrl).find("p[extend='true']").css("visibility", "hidden");
        $(ctrl).find("em[extend='true']").css("visibility", "hidden");
    },
    showExtendBtn: function (ctrl) {
        $(ctrl).find("div[extend='true']").css("visibility", "visible");
        $(ctrl).find("a[extend='true']").css("visibility", "visible");
        $(ctrl).find("span[extend='true']").css("visibility", "visible");
        $(ctrl).find("p[extend='true']").css("visibility", "visible");
        $(ctrl).find("em[extend='true']").css("visibility", "visible");
    },
    writeDebug: function (txt) {
        App.showMediaDiv(txt);
    },
    selPos: function (textBox) {
        var start = 0; var end = 0;
        if (document.selection) {
            var range = document.selection.createRange();
            if (range.parentElement().id == textBox.id) {

                var range_all = document.body.createTextRange();
                range_all.moveToElementText(textBox);

                for (start = 0; range_all.compareEndPoints("StartToStart", range) < 0; start++)
                    range_all.moveStart('character', 1);
                for (var i = 0; i <= start; i++) {
                    if (textBox.value.charAt(i) == '\n')
                        start++;
                }
                var range_all = document.body.createTextRange();
                range_all.moveToElementText(textBox);

                for (end = 0; range_all.compareEndPoints('StartToEnd', range) < 0; end++)
                    range_all.moveStart('character', 1);
                for (var i = 0; i <= end; i++) {
                    if (textBox.value.charAt(i) == '\n')
                        end++;
                }

            }
        }
        else {
            start = textBox.selectionStart;
            end = textBox.selectionEnd;
        }
        $(textBox).attr("range", start + "&" + (end - start));
    },
    bindTxtarea: function (txtbox, options) {
        var settings = $.extend({
            IsEnableAuto: false,
            width: 398,
            keyUpCallBack: null
        }, options);
        var start = 0;
        var end = 0;
        var hideTxtareaDiv = "<div style='display:none;' id=\"HideTextArea\"><span id=\"preSpan\"></span> <span id=\"atSpan\">@</span><span id=\"rearSpan\"></span></div>";
        var atWhoDiv = "<div style=\"z-index: 2000; position: absolute; display: none; \" class=\"Atwho\"><ul><div><div style=\"height:20px;color:#999999;padding-left:8px;padding-top:2px;line-height:18px;font-size:12px;Tahoma,宋体;\">想用@提到谁？</div></div></ul></div>";

        if (settings.IsEnableAuto) {
            App.autoHeightTextArea(txtbox, null, 1000000);
        }

        if ($("#HideTextArea")[0] == null) {
            $("body").append(hideTxtareaDiv);
        }
        if ($(".Atwho")[0] == null) {
            $("body").append(atWhoDiv);
            $(".Atwho").JQP_ClickOther(function () { $(".Atwho").hide(); App.isShowAtWho = false; });
        }
        var init = function (box) {
            App.TargetTextarea = box;
            $("#HideTextArea").attr("style", $(box).attr("style"));
            $("#HideTextArea").css("z-index", -1000);
            $("#HideTextArea").css("left", $(box).offset().left);
            $("#HideTextArea").css("top", $(box).offset().top);
            $("#HideTextArea").css("position", "absolute");
            $("#HideTextArea").css("word-wrap", "break-word");
            if (/msie/.test(navigator.userAgent.toLowerCase())) {
                $("#HideTextArea").css("filter", "alpha(opacity=0)");
            }
            else
                $("#HideTextArea").css("opacity", "0");
            if (settings.IsEnableAuto) {
                $("#HideTextArea").css('overflow-y', 'hiden');
                $("#HideTextArea").css("height", "");
            }
            else {
                $("#HideTextArea").css("overflow-y", "auto");
                $("#HideTextArea").css("height", $(box).height());
            }
            $("#HideTextArea").css("width", $(box).width());
            $("#HideTextArea").css("paddingLeft", $(box).css("paddingLeft"));
            $("#HideTextArea").css("paddingRight", $(box).css("paddingRight"));
            $("#HideTextArea").css("paddingTop", $(box).css("paddingTop"));
            $("#HideTextArea").css("paddingBottom", $(box).css("paddingBottom"));

            $("#HideTextArea").css("line-height", $(box).css("line-height"));
            $("#HideTextArea").css("font-size", $(box).css("font-size"));
            $("#HideTextArea").css("font-family", $(box).css("font-family"));

            $("#HideTextArea").show();

        };
        init(txtbox);
        $(txtbox).mouseup(function () {
            App.isKeyUp = true;
            App.selPos(this);
            init(this);
            return;
        });
        $(txtbox).mousedown(function () {
            App.selPos(this);
            return;
        });

        $(txtbox).keydown(function (e) {
            if (App.isShowAtWho) {
                var curLi = $(".Atwho ul").find(".cur");
                var index = $(".Atwho ul").find("li").index(curLi);
                var length = $(".Atwho ul").find("li").length;
                $(".Atwho ul").find("li").removeClass("cur");
                switch (e.which) {
                    case 38:
                        if (index == 0) {
                            $($(".Atwho ul").find("li")[length - 1]).addClass("cur");

                        }
                        else
                            $($(".Atwho ul").find("li")[index - 1]).addClass("cur");
                        e.preventDefault();
                        break;
                    case 40:
                        if (index == length - 1) {
                            $($(".Atwho ul").find("li")[0]).addClass("cur");

                        }
                        else
                            $($(".Atwho ul").find("li")[index + 1]).addClass("cur");
                        e.preventDefault();
                        break;
                    case 13:
                        App.setAtVal(this, curLi.attr("curName") + " ");
                        e.preventDefault();
                        $(".Atwho").hide();
                        App.isShowAtWho = false;
                        break;

                }
            }
            return;
        });
        $(txtbox).keyup(function (e) {
            App.isKeyUp = true;
            if (settings.keyUpCallBack)
                settings.keyUpCallBack();
            App.saveTxtCtrlRangePos(this);


            if (e.shiftKey && e.which == 50) {
                $(".Atwho").hide();
                App.isShowAtWho = false;
                return;
            }
            return;
        });
    },
    getTextAreaHeight: function (b) {
        b = $(b);
        if (b[0].defaultHeight == null) {
            b[0].defaultHeight = window.parseInt(b.height());
        }
        var g;
        if ($.browser.msie) {
            g = Math.max(b[0].scrollHeight, b[0].defaultHeight);
        } else {
            var a = $("#_____textarea_____");
            if (a[0] == null) {
                a[0] = document.createElement("textarea");
                a[0].id = "_____textarea_____";
                document.getElementsByTagName("body")[0].appendChild(a[0])
            }
            if (a.currentTarget != b)
                a[0].style.top = "-1000px";
            a[0].style.height = "0px";
            a[0].style.position = "absolute";
            a[0].style.overflow = "hidden";
            a[0].style.width = b.css("width");
            a[0].style.fontSize = b.css("fontSize");
            a[0].style.fontFamily = b.css("fontFamily");
            a[0].style.lineHeight = b.css("lineHeight");
            a[0].style.paddingLeft = b.css("paddingLeft");
            a[0].style.paddingRight = b.css("paddingRight");
            a[0].style.paddingTop = b.css("paddingTop");
            a[0].style.paddingBottom = b.css("paddingBottom")
            a[0].value = b[0].value;
            g = Math.max(a[0].scrollHeight, b[0].defaultHeight);
            a.currentTarget = b;
        }
        return g;
    },
    autoHeightTextArea: function (h, b, g) {
        h = h;
        b = b ||
    function () { };
        var a = function (p, n) {
            if (b) {
                b()
            }
            var j;
            var m;
            var o = App.getTextAreaHeight(p);
            n = n || o;
            if (o > n) {
                j = n;
                if (p.style.overflowY === "hidden") {
                    p.style.overflowY = "auto"
                }
            } else {
                j = o;
                if (p.style.overflowY === "auto") {
                    p.style.overflowY = "hidden"
                }
            }
            p.style.height = Math.min(n, o) + "px"
        };
        if (h.binded == null) {
            $(h).keyup(function () {
                a(h, g)
            });
            $(h).focus(function () {
                a(h, g)
            });
            $(h).blur(function () {
                a(h, g)
            });
            h.binded = true;
            h.style.overflowY = "hidden";
            h.style.overflowX = "hidden"
        }
    },
    mouseoutIco: function (img) {
        if ($.browser.msie) {

            img.style.filter = "alpha(opacity=50)";
        }
        else
            img.style.opacity = 0.5;
    },
    mouseoverIco: function (img) {
        if ($.browser.msie) {
            img.style.filter = "alpha(opacity=80)";
        }
        else
            img.style.opacity = 0.8;
    },
    initMedia: function ($range) {
        if ($range) {
            $("#"+$range).find("div[type='video']").click(function () {
                App.openVideo($(this).attr("mid"), $(this).attr("vid"));
            });
            $("#" + $range).find(" a[type='video']").click(function () {
                var mid = $(this).parent().attr("mid");
                App.openVideo(mid, $(this).attr("mediaID"));
                return false;
            });

            $("#" + $range).find(" div[type='music']").click(function () {
                App.playMusic($(this).attr("mid"), $(this).attr("musicid"));
            });
            $("#" + $range).find("a[type='music']").click(function () {
                var mid = $(this).parent().attr("mid");
                App.playMusic(mid, $(this).attr("mediaID"));
                return false;
            });

            $("#" + $range).find(" div[type='vote']").click(function () {
                App.startVote($(this).attr("mid"), $(this).attr("voteid"));

            });
            $("#" + $range).find(" a[type='vote']").click(function () {
                var mid = $(this).parent().attr("mid");
                App.startVote(mid, $(this).attr("mediaID"));
                return false;
            });
        }
        else {
            $("div[type='video']").click(function () {
                App.openVideo($(this).attr("mid"), $(this).attr("vid"));
            });
            $("a[type='video']").click(function () {
                var mid = $(this).parent().attr("mid");
                App.openVideo(mid, $(this).attr("mediaID"));
                return false;
            });

            $("div[type='music']").click(function () {
                App.playMusic($(this).attr("mid"), $(this).attr("musicid"));
            });
            $("a[type='music']").click(function () {
                var mid = $(this).parent().attr("mid");
                App.playMusic(mid, $(this).attr("mediaID"));
                return false;
            });

            $("div[type='vote']").click(function () {
                App.startVote($(this).attr("mid"), $(this).attr("voteid"));
                
            });
            $("a[type='vote']").click(function () {
                var mid = $(this).parent().attr("mid");
                App.startVote(mid, $(this).attr("mediaID"));
                return false;
            });
        }
    },
    buildCommentPage: function (data, mid, ownerUid, page, pagesize, isFollow) {
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
                        t.push('<a class="btn_normal btns" href="javascript:;" onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + (page - 1) + ',' + pagesize + ');return false;"><em>上一页</em></a> ');
                    }

                    //if the total page number less than 6
                    if (pageNum < 6) {
                        for (var i = 1; i <= pageNum; i++) {
                            if (page == i) {
                                t.push('<span>' + i + '</span> ');
                            }
                            else {
                                t.push('<a class="btn_num" href="javascript:;"onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + i + ',' + pagesize + ');return false;"><em>' + i + '</em></a> ');
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
                                    t.push('<a class="btn_num" href="javascript:;"onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + i + ',' + pagesize + ');return false;"><em>' + i + '</em></a> ');
                                }
                            }
                            t.push('...<a href="javascript:;" class="btn_num" onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + pageNum + ',' + pagesize + ');return false;"><em>' + pageNum + '</em></a> ');
                        }
                        else if ((pageNum - 3) < page) {

                            t.push('<a class="btn_num" href="javascript:;" onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + 1 + ',' + pagesize + ');return false;"><em>' + 1 + '</em></a>...');
                            for (var i = (pageNum - 4); i <= pageNum; i++) {
                                if (page == i) {
                                    t.push('<span>' + i + '</span> ');
                                }
                                else {
                                    t.push('<a class="btn_num" href="javascript:;"onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + i + ',' + pagesize + ');return false;"><em>' + i + '</em></a> ');
                                }
                            }
                        }
                        else if (3 < page < (pageNum - 2)) {

                            t.push('<a class="btn_num" href="javascript:;" onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + 1 + ',' + pagesize + ');return false;"><em>' + 1 + '</em></a>...');
                            for (var i = (parseInt(page) - 2); i <= (parseInt(page) + 2); i++) {
                                if (page == i) {
                                    t.push('<span>' + i + '</span> ');
                                }
                                else {
                                    t.push('<a class="btn_num" href="javascript:;"onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + i + ',' + pagesize + ');return false;"><em>' + i + '</em></a> ');
                                }
                            }
                            t.push('...<a class="btn_num" href="javascript:;" onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + pageNum + ',' + pagesize + ');return false;"><em>' + pageNum + '</em></a> ');
                        }
                    };

                    //the section of next page
                    if (page < pageNum) {
                        t.push('<a class="btn_normal btns" href="javascript:;" onclick="App.GetPagerComments(' + mid + ',' + ownerUid + ',' + isFollow + ',' + (page + 1) + ',' + pagesize + ');return false;"><em>下一页</em></a>');
                    }
                };
                $(".fanye").html(t.join(''));
            } else {
                $(".fanye").html('');
            }

        }

    },
    showPopMiniBlog: function (txt) {
        App.showMash();
        if (App.initDialDiv("PopMiniBlog", dialDiv, false, null)) {
            var pop = $("#PopMiniBlog");
            pop.find(".mid_c").html(popMBConDiv);
            pop.removeClass("4CancelAllLayer");
            var position = App.centerInScreen(pop);
            pop.css("left", position.left + "px");
            pop.css("top", position.top + "px");
            pop.show();
            var $txtbox = pop.find("#publish_editor2");
            if (txt) {
                $txtbox.val(txt);
            }
            var txtbox = $txtbox[0];
            pop.find(".close").click(function () {
                pop.hide();
                App.hideMash();
            });
            pop.find("#face").click(function (e) {
                e.stopPropagation();
                App.showExpression($txtbox, this);
            });
            var $submit = pop.find("#publisher_submit2");
            var submit = $submit[0];
            App.bindTxtarea(txtbox, { keyUpCallBack: function () {
                var curLen = App.getTxtLen(txtbox);
                if (curLen > 280) {
                    $("#publisher_info2").html("已超过<span class=\"pipsLim\">140</span>字");
                    $(".pipsLim").css("color", "#FF3300");
                    $(".pipsLim").text(parseInt((curLen - 280 + 1) / 2));
                }
                else {
                    $("#publisher_info2").html("还可以输入<span class=\"pipsLim\">140</span>字");
                    $(".pipsLim").text(parseInt((280 - curLen) / 2));
                }
            }
            });

            pop.find("#publisher_image2").click(function (e) {
                e.stopPropagation();
                App.showPicUpload(this);
            });

            $submit.click(function () {
                if ($.trim(txtbox.value) == "") {
                    App.highLineTxtBox($(txtbox));
                    return false;
                }
                var curLen = App.getTxtLen(txtbox);
                if (curLen > 280) {
                    $("#publisher_info2").html("已超过<span class=\"pipsLim\">140</span>字");
                    $(".pipsLim").css("color", "#FF3300");
                    $(".pipsLim").text(parseInt((curLen - 280 + 1) / 2));
                    submit.locked = true;
                }
                else {
                    $("#publisher_info2").html("还可以输入<span class=\"pipsLim\">140</span>字");
                    $(".pipsLim").text(parseInt((280 - curLen) / 2));
                    submit.locked = false;
                }
                if (submit.locked)
                    return;
                App.CreateOriginalMiniBlog($txtbox, function () {
                    App.tip("发布成功", 1000, window.location.reload());
                    $txtbox.val("");
                }, function () {
                    submit.locked = false;
                });
            });
        }
        else {
            var pop = $("#PopMiniBlog");
            var position = App.centerInScreen(pop);
            pop.css("left", position.left + "px");
            pop.css("top", position.top + "px");
            pop.show();
        }
    },
    bindGoTop: function (skin) {

        var backTopEle = $('<a class="goTop" style="position: fixed; bottom: 30px;"><span class="goTopbg ' + skin + '"></span><span class="goTopcon"><em class="toparr">&lt;</em><span>返回顶部</span></span></a>').appendTo($("body")).click(function () {
            $("html, body").scrollTop(0);
        });

        var backTopFun = function () {
            var st = $(document).scrollTop(), winh = $(window).height();
            (st > 300) ? backTopEle.show() : backTopEle.hide();
            if (!window.XMLHttpRequest) {
                backTopEle.css("top", st + winh - 100);
                backTopEle.css("position", "absolute");
            }
        }
        $(window).bind("scroll", backTopFun);
        $(function () { backTopFun(); });

    },
    AddFavorite: function (uid, mid, alink) {
        if (!alink.isFav) {
            $.ajax(
       {
           url: "/Ajax/AddFavorite/",
           datatype: "json",
           cache: false,
           data: { UID: uid, MID: mid },
           type: "post",
           success: function (o) {
               if (o.Code == "A00003") {
                   App.FullMiniTip(CodeList["A00003"], alink, 2000, 1);
               }
               else if (o.Code == "A00011") {
                   App.FullMiniTip(CodeList[o.Code], alink, 1000, 1);
               }
               else if (o.Code == "A00001") {
                   App.showLoginDial();
               }
               else if (o.Code == "A00012") {

                   App.FullMiniTip(CodeList[o.Code], alink, 1000, 3);
                   $(alink).text("取消收藏");
                   alink.isFav = true;
               }
           },
           error: function (request) {
               App.FullMiniTip(CodeList["A00003"], alink, 1000, 1);
           }
       });
        }
        else {
            $.ajax(
       {
           url: "/Ajax/DelFavorite/",
           datatype: "json",
           cache: false,
           data: { UID: uid, MID: mid },
           type: "post",
           success: function (o) {
               if (o.Code == "A00003") {
                   App.FullMiniTip(CodeList["A00003"], alink, 1000, 1);
               }
               else if (o.Code == "A00001") {
                   App.showLoginDial();
               }
               else if (o.Code == "A00013") {
                   App.FullMiniTip(CodeList[o.Code], alink, 1000, 3);
                   $(alink).text("收藏");
                   alink.isFav = false;
               }
           },
           error: function (request) {
               App.FullMiniTip(CodeList["A00003"], alink, 1000, 1);
           }
       });
        }
    },
    showVote: function (txtCtrl, showWhere) {
        App.TargetTextarea = txtCtrl;
        App.HideAllDiaDiv();
        if (App.initDialDiv("divVote", dialDiv, true, function () { $("#divVote").hide(); })) {
            $("#divVote").css("z-index", 2000);
            var showWhere = $(showWhere).offset();
            $("#divVote").css("left", showWhere.left - 195);
            $("#divVote").css("top", showWhere.top + 20);
            $("#divVote").css("width", 420);
            $("#divVote").find(".mBlogLayer").css("width", "100%");
            $("#divVote .mid_c").html("<div class=\"layerBox\"><div class=\"layerBox_loading\"><div class=\"layerBox_loading\" id=\"loading\"><div class=\"ll_info\"><img width=\"16\" height=\"16\" src=\"/Content/Image/loading.gif\"><p id=\"msg\"></p></div></div></div></div>");
            $("#divVote").show();

            $.ajax(
                           {
                               url: "/Ajax/GetVoteDiaHtml/",
                               datatype: "json",
                               cache: false,
                               type: "post",
                               success: function (o) {
                                   if (o.Code == "A00003") {
                                       App.alert(CodeList["A00003"]);
                                   }
                                   else if (o.Code == "A00001") {
                                       App.showLoginDial();
                                   }
                                   else if (o.Code == "A00005") {
                                       $("#divVote .mid_c").html(o.Data);
                                       $("#divVote .layerMedia_close a").click(function () {
                                           $("#divVote").hide();
                                       });
                                       $(".lv_input3").focus(function () {
                                           $(this).addClass("lv_focus");
                                       }).blur(function () {
                                           $(this).removeClass("lv_focus");
                                       }).keyup(function () {
                                           this.value = App.GetStringByte(this.value, 50);
                                       }); ;

                                       $(".lv_inputsub input").live("focus", function () {
                                           $(this).parent().addClass("lv_focus");
                                       }).live("blur", function () {
                                           $(this).parent().removeClass("lv_focus");
                                       }).live("keyup", function () {
                                           this.value = App.GetStringByte(this.value, 40);
                                       });
                                       $('.lv_textarea').focus(function () {
                                           $(this).addClass("lv_focus");
                                       }).blur(function () {
                                           $(this).removeClass("lv_focus");
                                       }).keyup(function () {
                                           this.value = App.GetStringByte(this.value, 480);
                                       });

                                       $(".vote_addicon").next().click(function () {
                                           var l = $(".lv_inputsub").length;
                                           if (l < 20) {
                                               var txt = "";

                                               for (var i = l; i < l + 5; i++) {
                                                   txt += "<p class=\"lv_inputsub\"><span>" + (i + 1) + ".</span><input type=\"text\" name=\"items\" act=\"vitem\"></p><p>";

                                               }
                                               if (App.E("optionType").value == 2) {
                                                   var options = "";
                                                   for (var k = 2; k <= l + 5; k++) {
                                                       options += "<option value=\"" + k + "\">" + k + "项</option>";
                                                   }
                                                   $("#optionNum").html(options);
                                               }
                                               $(txt).insertBefore($(".vote_addicon").parent());
                                           }
                                       });

                                       $("#uploadingPic a").click(function () {
                                           $("#uploadimg_iframe").remove();
                                           $("#addPic").show();
                                           $("#uploadingPic").hide();
                                           $("#addPic").append($("<iframe id=\"uploadimg_iframe\" name=\"uploadimg_iframe\" src=\"about:blank\" style=\"display: none\"></iframe>"));
                                       });
                                       $("#delPic a").click(function () {
                                           $("#addPic").show();
                                           $("#delPic").hide();
                                           $("#voteImgID").val("");
                                       });
                                       $("#voteError .close").click(function () {
                                           $("#voteError").hide();
                                       });
                                       $("#voteFile").change(function () {
                                           App.votePicUpload(App.votePicUploading);
                                       });
                                       $("#PublishVote").click(function () {

                                       });
                                       $('.lv_calendar').JQP_DatePicker({  toDate: new Date(2555, 0, 1) }).keydown(function () { return false; });
                                       $("#optionType").change(function () {
                                           if (this.value == 2) {
                                               var ls = $(".lv_inputsub input").length;
                                               var options = ""
                                               for (var k = 2; k <= ls; k++) {
                                                   options += "<option value=\"" + k + "\">" + k + "项</option>";
                                               }
                                               $("#optionNum").show().html(options);
                                           }
                                           else {
                                               $("#optionNum").hide();
                                           }
                                       });
                                       $("#PublishVote").click(function () {
                                           if ($.trim($(".lv_input3").val()) == "") {
                                               $("#voteError .bigtxt").text("投票标题错误");
                                               $("#voteError .stxt").text("标题必须有哦，最多25个汉字");
                                               $("#voteError").show();
                                               return false;
                                           }
                                           else {
                                               var ls = $(".lv_inputsub input").length;
                                               var count = 0;
                                               for (var i = 0; i < ls; i++) {
                                                   if ($.trim($(".lv_inputsub input")[i].value) != "")
                                                       count++;
                                               }
                                               if (count < 2) {
                                                   $("#voteError .bigtxt").text("投票选项错误");
                                                   $("#voteError .stxt").text("选项太少啦，至少2个哦");
                                                   $("#voteError").show();
                                                   return false;
                                               }
                                           }
                                           if (this.locked)
                                               return false;
                                           this.locked = true;
                                           var title = App.htmlencode(App.GetStringByte($(".lv_form .lv_input3").val(), 50));
                                           var remark = "";
                                           var lvtxtarea = $(".lv_form .lv_textarea");
                                           if ($.trim(lvtxtarea.val()) != "") {
                                               remark = App.htmlencode(App.GetStringByte(lvtxtarea.val(), 480).replace(/\n/g, ""));
                                           }
                                           var imgPid = "";
                                           var hPid = $("#voteImgID");
                                           if ($.trim(hPid.val()) != "") {
                                               imgPid = hPid.val();
                                           }
                                           var options = "";

                                           var inputOpts = $(".lv_inputsub input");
                                           var ls = inputOpts.length;
                                           for (var i = 0; i < ls; i++) {
                                               if ($.trim(inputOpts[i].value) != "")
                                                   options += App.htmlencode(App.GetStringByte(inputOpts[i].value, 40)) + ",";
                                           }
                                           var displayType = 2;
                                           if ($(".lv_form .lv_input2")[0].checked) {
                                               displayType = 1;
                                           }
                                           var optiontype = "";
                                           var optionNum = "";
                                           if (App.E("optionType").value == 1) {
                                               optiontype = "1";

                                           }
                                           else {
                                               optiontype = "2";
                                               optionNum = App.E("optionNum").value;
                                           }
                                           var calendar = $(".lv_calendar");
                                           var expireTime = calendar.val() + " " + calendar.next().val() + ":" + calendar.next().next().val();
                                           $.ajax({
                                               url: "/Ajax/CreateVote/",
                                               data: { Title: title, Remark: remark, ImgPid: imgPid, Options: options, DisplayType: displayType, OptionType: optiontype, OptionNum: optionNum, ExpireTime: expireTime },
                                               datatype: "json",
                                               cache: false,
                                               type: "post",
                                               success: function (o) {
                                                   if (o.Code == "A00003") {
                                                       App.FullMiniTip(CodeList["A00003"], App.E("PublishVote"), 1000, 1);
                                                   }
                                                   else if (o.Code == "A00001") {
                                                       App.showLoginDial();
                                                   }
                                                   else {
                                                       App.FullMiniTip(CodeList[o.Code], App.E("PublishVote"), 1000, 3);
                                                       setTimeout(function () {
                                                           $("#divVote").JQP_UnClickOther();
                                                           $("#divVote").remove();

                                                           App.insertTxt2Txtarea(App.TargetTextarea, o.Data);
                                                       }, 1000);
                                                   }
                                                   App.E("PublishVote").locked = false;
                                               },
                                               error: function () {
                                                   App.FullMiniTip(CodeList["A00003"], App.E("PublishVote"), 1000, 1);
                                                   App.E("PublishVote").locked = false;

                                               }
                                           });
                                       });
                                       $("li[nav='new']").click(function () {
                                           $("div[tab='new']").show();
                                           $("div[tab='list']").hide();
                                           $("li[nav='new']").attr("class", "cur");
                                           $("li[nav='list']").attr("class", "");
                                       });
                                       $("li[nav='list']").click(function () {
                                           $("div[tab='list']").show();
                                           $("div[tab='new']").hide();
                                           $("li[nav='list']").attr("class", "cur");
                                           $("li[nav='new']").attr("class", "");
                                       });

                                   }
                               },
                               error: function () {
                                   App.alert(CodeList["A00003"]);
                               }
                           });
        }
        else {
            $("#divVote").show();
        }
        return false;
    },
    votePicUpload: function (callBack) {
        if (!(/\.(gif|jpg|png|jpeg)$/i.test($("#voteFile").val()))) {
            $("#voteError .bigtxt").text("图片格式不正确");
            $("#voteError .stxt").text("只支持jpg,png,gif");
            $("#voteError").show();
            return false;
        }
        else {
            if ($.browser.msie) {
                eval("window.voteForm.submit();");
            } else {

                $("#voteForm").submit();
            }
            callBack();
        }
        var clone = $("#voteFile").clone();
        clone.removeAttr("value");
        $("#voteFile").remove();
        $("#voteForm").append(clone);
        $("#voteForm").find("input").change(function () {
            App.votePicUpload(callBack);
        });
    },
    votePicUploading: function () {
        $("#uploadingPic").show();
        $("#addPic").hide();
        $("#uploadingPic a").click(function () {
            $("#uploadimg_iframe").remove();
            $("#addPic").show();
            $("#uploadingPic").hide();
            $("#addPic").append($("<iframe id=\"uploadimg_iframe\" name=\"uploadimg_iframe\" src=\"about:blank\" style=\"display: none\"></iframe>"));
        });
    },
    votePicCallBack: function (status, imgID, imgName) {
        $("#uploadingPic").hide();
        if (status == 1) {
            App.votePicUploaded(imgID, imgName);
        }
        if (status == -1) {

            $("#voteError .bigtxt").text("上传失败");
            $("#voteError .stxt").text("请重试");
            $("#voteError").show();
            $("#addPic").show();
        }
        if (status == -2) {
            $("#voteError bigtxt").text("上传失败");
            $("#voteError stxt").text("上传图片超过5M,请重新上传。");
            $("#voteError").show();
            $("#addPic").show();
        }

    },
    votePicUploaded: function (imgID, imgName) {
        $("#voteImgID").val(imgID);
        $("#uploadingPic").hide();
        $("#delPic").show();
        $("#votePicName").text(imgName);
    },
    lazyObject: null,
    lazyFunction: function (func, lazyTime) {
        if (lazyTime > 0 && func != null) {
            this.lazyObject = setTimeout(func, lazyTime);
        }
    },
    lazyEvent: function (obj, eventName, eventName1, lazyTime, func, func1) {
        if (obj != null && eventName != "" && eventName1 != null) {
            $(obj).bind(eventName, function (e) {
                if (func && lazyTime > 0) {
                    App.lazyObject = setTimeout(function () { func(obj); }, lazyTime);
                }
            }).bind(eventName1, function (e) {
                if (App.lazyObject) {
                    clearTimeout(App.lazyObject);
                    if (func1 != null) {
                        func1();
                    }
                }
            });
        }
    },
    curGetLink: null,
    curAutoCompleteTxtBox: null,
    curAutoCompleteCallBack: null,
    OriKey: "",
    autoIsKeyUp: false,
    autoCompleteTimerEvent: function () {
        if (!App.autoIsKeyUp)
            return;
        if (!App.curGetLink)
            return;
        if (!App.curAutoCompleteTxtBox)
            return;
        if ($.trim(App.curAutoCompleteTxtBox.val()) == "")
            return;
        if (App.curAutoCompleteTxtBox.val() == App.OriKey)
            return;
        App.OriKey = App.curAutoCompleteTxtBox.val();
        var layer = $(".layerMedia_menu");
        App.autoIsKeyUp = false;
        $.ajax({
            dataType: "json",
            data: { key: App.OriKey },
            url: "/Ajax/" + App.curGetLink + "/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00017") {
                    layer.hide();
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
                var str = "";
                for (var i = 0; i < o.Data.length; i++) {
                    if (i == 0)
                        str += "<li style=\"overflow: hidden; height: 20px;\" id=\"" + o.Data[i].ID + "\" val='" + o.Data[i].NickName + "' class=\"cur\">" + o.Data[i].Title.replace(new RegExp("(" + App.OriKey + ")", "gi"), "<b>$1</b>") + "</li>"
                    else
                        str += ("<li style=\"overflow: hidden; height: 20px;\" id=\"" + o.Data[i].ID + "\" val='" + o.Data[i].NickName + "'>" + o.Data[i].Title.replace(new RegExp("(" + App.OriKey + ")", "gi"), "<b>$1</b>") + "</li>");
                }

                layer.show();
                var offset = App.curAutoCompleteTxtBox.offset();
                layer.css("left", offset.left).css("top", offset.top + App.curAutoCompleteTxtBox.height() + 5);

                layer.find("ul").html(str).find("li").hover(function () {
                    layer.find("li").removeClass("cur");
                    $(this).addClass("cur");
                }).click(function () {
                    layer.hide();
                    App.OriKey = "";
                    if (App.curAutoCompleteCallBack) {
                        App.curAutoCompleteCallBack($(this).attr("id"), $(this).attr("val"));
                    }
                });
            }
        });
    },
    autoCompleteLayer: "<div class=\"layerMedia_menu\" style=\"width: 161px; position: absolute; z-index: 1601; display: none;\"><ul></ul></div>",
    autoComplete: function (ctrl, callBack, requestAction) {
        var layer = $(".layerMedia_menu")
        if (App.appendToBody(layer, this.autoCompleteLayer)) {
            layer = $(".layerMedia_menu");
            layer.JQP_ClickOther(function () { layer.hide(); App.OriKey = ""; });
        }
        $(ctrl).keydown(function (e) {
            App.autoIsKeyUp = true;
            var curLi = layer.find(".cur");
            var index = layer.find("li").index(curLi);
            var length = layer.find("li").length;
            var lis = layer.find("li").removeClass("cur");
            switch (e.which) {
                case 38:
                    if (index == 0) {
                        $(lis[length - 1]).addClass("cur");

                    }
                    else
                        $(lis[index - 1]).addClass("cur");
                    e.preventDefault();
                    break;
                case 40:
                    if (index == length - 1) {
                        $(lis[0]).addClass("cur");

                    }
                    else
                        $(lis[index + 1]).addClass("cur");
                    e.preventDefault();
                    break;
                case 13:
                    App.OriKey = "";
                    if (callBack) {
                        if (curLi.attr("val") && layer.is(":visible"))
                            callBack(curLi.attr("id"), curLi.attr("val"));
                    }
                    e.preventDefault();
                    layer.hide();
                    App.autoIsKeyUp = false;
                    break;

            }
        }).focus(function () {
            if (requestAction) {
                App.curGetLink = requestAction;
            }
            App.curAutoCompleteTxtBox = $(this);
            if (callBack)
                App.curAutoCompleteCallBack = callBack;
        });
    }
};

App.addGroup = function (name, sucCallback, defCallback) {
    $.ajax({
        dataType: "json",
        data: { Name: name },
        url: "/Ajax/AddGroup/",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00009") {
                if (sucCallback)
                    sucCallback(o);
            }
            else if (o.Code == "A00015") {
                App.fullTip(CodeList[o.Code], 1000, null, 1);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.fullTip(CodeList["A00003"], 1000, null, 1);
            }
            if (defCallback)
                defCallback();
        },
        error: function () {
            App.fullTip(CodeList["A00003"], 1000, null, 1);
            if (defCallback)
                defCallback();
        }
    });
}


App.editGroupName = function (gid, name, sucCallback, defCallback) {
    $.ajax({
        dataType: "json",
        data: { Name: name, Gid: gid },
        url: "/Ajax/EditGroupName/",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00004") {
               
                if (sucCallback)
                    sucCallback(o);
            }
            else if (o.Code == "A00015") {
                App.fullTip(CodeList[o.Code], 1000, null, 1);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.fullTip(CodeList["A00003"], 1000,null, 1);
            }
            if (defCallback)
                defCallback();
        },
        error: function () {
            App.fullTip(CodeList["A00003"], 1000, null, 1);
            if (defCallback)
                defCallback();
        }
    });
}


App.popGroupDiv = function (gid, gName) {
    if (App.initDialDiv("GroupDiv", dialDiv, false, null)) {
        var groupDiv = $("#GroupDiv");
        groupDiv.removeClass("4CancelAllLayer");
        groupDiv.find(".mid_c").html(GroupConDiv.replace("{title}", gName != null ? "编辑分组名" : "创建分组"));
        $("#GroupDiv .close").add($("#group_cancel")).click(function () {
            groupDiv.remove();
            App.hideMash();
        });
        var txtGroup = $("#group_newname");
        txtGroup.JQP_HighLineInput2({ nullCon: "输入分组名字" });
        if (gName)
            txtGroup.val(gName);
        var position = App.centerInScreen(groupDiv);
        groupDiv.css("left", position.left + "px");
        groupDiv.css("top", position.top + "px");
        App.showMash();
        var error = $("#errorTs");
        var btnSubmit = $("#group_submit").click(function () {
            if (this.locked)
                return false;
            this.locked = true;
            if (txtGroup.val() == "输入分组名字") {
                this.locked = false;
                error.text("请输入分组名");
                error.show();
                return false;
            }
            var len = App.byteLength(txtGroup.val());
            if (len > 16) {
                this.locked = false;
                error.text("请不要超过16个字符");
                error.show();
                return false;
            }
            if (gName) {
                App.editGroupName(gid, $.trim(txtGroup.val()), function (o) {
                    App.fullTip(CodeList[o.Code], 1000, window.location.href.replace("#", ""), 3);
                }, function () {
                    App.E("group_submit").locked = false;
                });
            }
            else {
                App.addGroup($.trim(txtGroup.val()), function (o) {
                    App.fullTip(CodeList[o.Code], 1000, window.location.href.replace("#", ""), 3);
                 }, function () {
                    App.E("group_submit").locked = false;
                });
            }
            return false;
        });
    }
}

App.editRemarkConDiv = "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong>设置备注名</strong><a title=\"关闭\" class=\"close\" href=\"javascript:;\"></a><div class=\"clear\"></div></div></div><div class=\"layerBoxCon\" style=\"width: 390px; height: auto;\"><div class=\"layerBoxCon\" style=\"width: 390px;\"><div class=\"inviteLayer\"><p class=\"flName\">给朋友加个备注名，方便认出他是谁</p><div class=\"inviteLayerInput\"><input type=\"text\" value=\"\" id=\"remark\" class=\"PY_input\"><a class=\"btn_normal\" href=\"javascript:void(0);\" id=\"submit\"><em>保存</em></a></div><p style=\"display:none;\" id=\"errorTip\" class=\"errorTs yellow2\">超过8个字啦！为他起个常用名吧</p></div></div></div></div>";

App.showEditRemarkBox = function (ctrl, uid) {
    if (App.initDialDiv("EditRemarkBox", dialDiv, false, null)) {
        var box = $("#EditRemarkBox");
        box.removeClass("4CancelAllLayer");
        box.find(".mid_c").html(this.editRemarkConDiv);
        box.find(".close").click(function () {
            box.remove();
            App.hideMash();
        });
    }
    ctrl = $(ctrl);
    var box = $("#EditRemarkBox");
    var position = this.centerInScreen(box);
    var input = $("#remark");
    if (ctrl.text() != "设置备注")
        input.val(ctrl.text());
    box.css("top", position.top).css("left", position.left);

    this.showMash();
    box.show();
    box.find("#remark").focus().keyup(function () {
        if (App.byteLength(this.value) > 16) {
            this.value = App.GetStringByte(this.value, 16);
        }
    });
    box.find("#submit").click(function () {

        if (App.byteLength(input[0].value) > 16) {
            box.find("#errorTip").show();
            return;
        }
        if (this.locked)
        { return; }
        this.locked = true;
        var thisBtn = this;
        $.ajax({
            dataType: "json",
            data: { uid: uid, remark: $.trim(input.val()) },
            url: "/Ajax/EditRemark/",
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00004") {
                    App.fullTip(CodeList[o.Code], 1000, null, 3);
                    if ($.trim(input.val())=="")
                        ctrl.text("设置备注");
                    else
                        ctrl.text($.trim(input.val()));
                    box.remove();
                    App.hideMash();
                }
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else {
                    App.alert(CodeList["A00003"]);
                }
                thisBtn.locked = false;
            },
            error: function () {
                App.alert(CodeList["A00003"]);
                thisBtn.locked = false;
            }
        });

    });
}

App.MessageConDiv = "<div class=\"layerBox\"><div class=\"layerBoxTop\"><div class=\"topCon\"><strong>发私信</strong><a title=\"关闭\" class=\"close\" href=\"javascript:;\"></a><div class=\"clear\"></div></div></div><div class=\"layerBoxCon\" style=\"width: 430px; height: auto;\"><table class=\"noteTab2\"><tbody>	<tr>	<th>发私信给：&nbsp;</th><td><input type=\"text\"  class=\"PY_input\" id=\"popUpNick\" style=\"color: rgb(153, 153, 153);\">&nbsp;&nbsp;</td></tr><tr class=\"tPadding\"><th>私信内容：&nbsp;</th><td><textarea class=\"PY_input\" id=\"popUpEditor\" range=\"0&0\" style=\"overflow: hidden;\"></textarea></td></tr><tr class=\"tPadding1\"><th></th><td><a title=\"表情\" href=\"javascript:void(0);\" id=\"insert_face_icon\" class=\"faceicon1\"></a></td></tr>	<tr><th></th><td><a class=\"btn_normal\" href=\"javascript:void(0);\" id=\"popUpSubmit\"><em>发送</em></a>	<span class=\"errorTs2 error_color\" style=\"display:none\" id=\"popUpError\">密码错误</span></td></tr><tr><td></td><td><p class=\"inviteLayer_tip gray9\">说明：长度不能超过300字</p></td></tr></tbody></table></div></div>";
App.showMessageBox = function (toName) {
    if (App.initDialDiv("MessageBox", dialDiv, false, null)) {
        var box = $("#MessageBox");
        box.removeClass("4CancelAllLayer");
        box.find(".mid_c").html(this.MessageConDiv);
        box.find(".close").click(function () {
            box.remove();
            App.hideMash();
        });
        var textarea = $("#popUpEditor").keyup(function () {
            if (App.byteLength(this.value) > 600)
                this.value = App.GetStringByte(this.value, 600);
        });
        var input = $("#popUpNick");
        input.JQP_HighLineInput();
        $("#insert_face_icon").click(function (e) {
            e.stopPropagation();
            App.showExpression(textarea, this);
        });
        this.bindTxtarea(textarea[0], { IsEnableAuto: true, keyUpCallBack: function () { } });
        this.autoComplete(input, function (id, name) { input.val(name); App.OriKey = "" }, "GetFollowListByKey");
        var isPush = false;
        for (var i = 0; i < App.TimerFunArray.length; i++) {
            if (App.TimerFunArray[i] == this.autoCompleteTimerEvent) {
                isPush = true;
            }
        }
        if (!isPush) {
            App.TimerFunArray.push(this.autoCompleteTimerEvent);
        }
        $("#popUpSubmit").click(function () {
            var popUpError = $("#popUpError");
            if ($.trim(input.val()) == "") {
                popUpError.show();
                popUpError.text("请输入收信人昵称");
                return;
            }
            if (App.byteLength(textarea.val()) > 600) {
                popUpError.show();
                popUpError.text("内容超过300字");
                return;
            }
            if ($.trim(textarea.val()) == "") {
                popUpError.show();
                popUpError.text("内容不能为空");
                return;
            }
            if (this.locked)
                return;
            this.locked = true;
            var thisBtn = this;
            App.AddMessage($.trim(input.val()), $.trim(textarea.val()), function () {
                box.remove();
                App.hideMash();
                App.fullTip("发送成功", 1000, null, 3);
            }, function () { thisBtn.locked = false; });
        });
    }
    var box = $("#MessageBox");
    var position = this.centerInScreen(box);
    var input = $("#popUpNick");
    var textarea = $("#popUpEditor");
    if (toName)
        input.val(toName);
    box.css("top", position.top).css("left", position.left);
    App.showMash();
    box.show();
}

App.AddMessage = function (nickname, content, susCallBack, defCallBack) {
    content = App.htmlencode(content);
    $.ajax({
        dataType: "json",
        data: { NickName: nickname, Content: content },
        url: "/Ajax/CreateMessage/",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00009") {
                if (susCallBack)
                    susCallBack();
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else if (o.Code == "A00019") {
                App.fullTip(CodeList[o.Code], 1000, null, 1);
            }else if (o.Code == "A00002") {
                App.fullTip(CodeList[o.Code],1000,null,1);
            } else if (o.Code == "A00026") {
                App.fullTip(CodeList[o.Code], 1000, null, 1);
            }
            else if (o.Code == "A00027") {
                App.fullTip(CodeList[o.Code], 1000, null, 1);
            }
            else {
                App.fullTip(CodeList["A00003"], 1000, null, 1);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.fullTip(CodeList["A00003"], 1000, null, 1);
            if (defCallBack)
                defCallBack();
        }
    });
}

App.AddQueryToUrl = function (oriUrl, key, value) {
    if (oriUrl.indexOf("?") > 0) {
        if (oriUrl.indexOf("&" + key) > 0 || oriUrl.indexOf("?" + key) > 0) {
            oriUrl = oriUrl.replace(RegExp("&*" + key + "=[^&]+", "ig"), "");
        }
        if (oriUrl.split('?')[1] == "") {
            oriUrl += key + "=" + value;
        }
        else {
            oriUrl += "&" + key + "=" + value;
        }
    }
    else {
        oriUrl += "?" + key + "=" + value;
    }
    return oriUrl;
}

App.RemoveQueryFromUrl = function (oriUrl, key) {
    if (oriUrl.indexOf("&" + key) > 0 || oriUrl.indexOf("?" + key) > 0) {
        oriUrl = oriUrl.replace(RegExp("&*" + key + "=[^&]+", "ig"), "");
    }
    return oriUrl;
}

App.AddUserTopic = function (name, susCallBack, defCallBack) {
    $.ajax({
        dataType: "json",
        data: { name: name },
        url: "/Ajax/AddUserTopic/",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00009") {
                if (susCallBack)
                    susCallBack(o);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else if (o.Code == "A00025") {
                App.fullTip(CodeList[o.Code], 1000, null, 1);
            }
            else {
                App.fullTip(CodeList["A00003"], 1000, null, 1);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.fullTip(CodeList["A00003"], 1000, null, 1);
            if (defCallBack)
                defCallBack();
        }
    });
}

App.DelUserTopic = function (id, susCallBack, defCallBack) {
    $.ajax({
        dataType: "json",
        data: { id: id },
        url: "/Ajax/DelUserTopic/",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00018") {
                if (susCallBack)
                    susCallBack(CodeList[o.Code]);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.fullTip(CodeList["A00003"], 1000, null, 1);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.fullTip(CodeList["A00003"], 1000, null, 1);
            if (defCallBack)
                defCallBack();
        }
    });
}
App.FollowOne = function (id, name, susCallBack, defCallBack) {
    $.ajax({
        dataType: "json",
        data: { id: id },
        url: "/Ajax/FollowOne/",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00009") {
                if (susCallBack)
                    susCallBack(id, name, o);
                App.showGroupAssignBox(id, name);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else if (o.Code == "A00026") {
                App.fullTip(CodeList[o.Code], 1000, null, 1);
            }
            else if (o.Code == "A00029") {
                App.confirm(CodeList[o.Code], function () {
                    App.outBlackList(id, function (d) {
                        App.fullTip(CodeList[d.Code], 1000, null, 3);
                     }, null);
                });
            }
            else {
                App.fullTip(CodeList["A00003"], 1000, null, 1);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.fullTip(CodeList["A00003"], 1000, null, 1);
            if (defCallBack)
                defCallBack();
        }
    });
}

App.CancelFollow = function (id, susCallBack, defCallBack) {
    $.ajax({
        dataType: "json",
        data: { id: id },
        url: "/Ajax/CancelFollow/",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00018") {
                if (susCallBack)
                    susCallBack(id, o);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.fullTip(CodeList["A00003"], 1000, null, 1);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.fullTip(CodeList["A00003"], 1000, null, 1);
            if (defCallBack)
                defCallBack();
        }
    });
};
App.CancelFan = function (id, susCallBack, defCallBack) {
    $.ajax({
        dataType: "json",
        data: { id: id },
        url: "/Ajax/CancelFan/",
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00018") {
                if (susCallBack)
                    susCallBack(id, o);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.fullTip(CodeList["A00003"], 1000, null, 1);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.fullTip(CodeList["A00003"], 1000, null, 1);
            if (defCallBack)
                defCallBack();
        }
    });
}

App.yellowTip = $("#yellowtip");
App.tipIstop = true;
App.UnreadTimeCount = 0;
App.GetUnreadJsonpEvent = function () {
    if (App.UnreadTimeCount % 30 == 0) {
        $("head").append("<script type=\"text/javascript\" src=\"/Jsonp/Unread/?r=" + Math.random() + "\"></script>")
    };
    App.UnreadTimeCount++;
};
App.showUnread = function (o) {
    var data = o.Data;
    if (data.followCount > 0) {
        $("#unreadFollowCount").html(data.followCount + "位新粉丝，<a href=\"\">查看我的粉丝</a>").show();
        
    } else {
        $("#unreadFollowCount").hide();
    }
    if (data.commentCount > 0) {
        $("#unreadCommentCount").html(data.commentCount + "条新评论，<a href=\"\">查看我的评论</a>").show();
       
    }
    else {
        $("#unreadCommentCount").hide();
    }
    if (data.msgCount > 0) {
        $("#unreadMsgCount").html(data.msgCount + "条新信息，<a href=\"\">查看我的私信</a>").show();
        
    }
    else {
        $("#unreadMsgCount").hide();
    }
    if (data.atmeCount > 0) {
        $("#unreadAtmeCount").html(data.atmeCount + "条@我的微博，<a href=\"\">查看@我的微博</a>").show();
       
    }
    else {
        $("#unreadAtmeCount").hide();
    }
    if (data.atcmtCount > 0) {
        $("#unreadAtcmtCount").html(data.atcmtCount + "条@我的评论，<a href=\"\">查看@我的评论</a>").show();
        
    }
    else {
        $("#unreadAtcmtCount").hide();
    }
    if (data.noticeCount > 0) {
        $("#unreadNoticeCount").html(data.noticeCount + "条通知，<a href=\"\">查看我的通知</a>").show(); $("#unreadLayer").show();
    }
    else {
        $("#unreadNoticeCount").hide();
    }

    if (data.followCount > 0 || data.commentCount > 0 || data.msgCount > 0 || data.atmeCount > 0 || data.atcmtCount > 0 || data.noticeCount > 0) {
    $("#unreadLayer").show();
    }
    else{
    $("#unreadLayer").hide();
    }
};
App.showGroupAssignBox = function (uid, name) {
    if (App.initDialDiv("GroupAssignBox", dialDiv, false, null)) {
        var groupDiv = $("#GroupAssignBox");
        groupDiv.removeClass("4CancelAllLayer");
        groupDiv.find(".mid_c").html(GroupAssignDiv.replace("{name}", name));
        $("#GroupAssignBox .close").add($("#g_nogroup")).click(function () {
            groupDiv.remove();
            App.hideMash();
        });
        var txtSetRemark = $("#set_group_remark");
        txtSetRemark.JQP_HighLineInput2({ nullCon: "设置备注" });
        var position = App.centerInScreen(groupDiv);
        groupDiv.css("left", position.left + "px");
        groupDiv.css("top", position.top + "px");
        App.showMash();

        $.ajax({
            dataType: "json",
            url: "/Ajax/GetAllGroup/",
            cache: false,
            data: { fuid: uid },
            type: "post",
            success: function (o) {
                if (o.Code == "A00005") {
                    var ul = $("#group_list_D");
                    if (o.Data.length > 0) {
                        for (var i = 0; i < o.Data.length; i++) {
                            var li;
                            if (o.Data[i].IsSet == 0) {
                                li = $('<li><input id="g{id}" class="labelbox" type="checkbox" name="g{id}" value="{id}"><label title="{name}" for="g{id}" style="cursor:pointer;">{name}</label></li>'.replace(/\{name\}/g, o.Data[i].Name).replace(/\{id\}/g, o.Data[i].ID));
                            }
                            else {
                                li = $('<li><input id="g{id}" checked  class="labelbox" type="checkbox" name="g{id}" value="{id}"><label title="{name}" for="g{id}" style="cursor:pointer;">{name}</label></li>'.replace(/\{name\}/g, o.Data[i].Name).replace(/\{id\}/g, o.Data[i].ID));
                            }
                            li.mouseover(function () { this.className = "hover"; }).mouseout(function () { this.className = "" });
                            ul.append(li);

                        }
                    }
                    var newgrp = $("#newgrp");
                    $("#creategrp").click(function () {
                        newgrp.fadeIn();
                        return false;
                    });
                    $("#cancel_group").click(function () {
                        newgrp.fadeOut();
                        return false;
                    });
                    var groupInput = $("#group_input").JQP_HighLineInput2({ nullCon: "新分组" });
                    var error = $("#group_error");
                    var btnAdd = $("#create_group").click(function () {
                        if (this.locked)
                            return false;
                        this.locked = true;
                        if (groupInput.val() == "新分组") {
                            this.locked = false;
                            error.text("请输入分组名");
                            error.show();
                            return false;
                        }
                        var len = App.byteLength(groupInput.val());
                        if (len > 16) {
                            this.locked = false;
                            error.text("请不要超过16个字符");
                            error.show();
                            return false;
                        }

                        App.addGroup($.trim(groupInput.val()), function (o) {
                            var li = $('<li><input id="g{id}" class="labelbox" type="checkbox" name="g{id}" value="{id}"><label title="{name}" for="g{id}" style="cursor:pointer;">{name}</label></li>'.replace(/\{name\}/g, o.Data.Name).replace(/\{id\}/g, o.Data.ID));
                            li.mouseover(function () { this.className = "hover"; }).mouseout(function () { this.className = "" });
                            ul.append(li);
                        }, function () {
                            btnAdd[0].locked = false;
                        });
                        return false;
                    });
                    $("#g_submit").click(function () {
                        if (this.locked)
                            return false;
                        if (App.byteLength(txtSetRemark.val()) > 16) {
                            $("#set_group_remark_err").show().text("只能输入16个字节");
                            return false;
                        }
                        var gids = "";
                        var remark = txtSetRemark.val();
                        var inputs = ul.find("input");
                        for (var i = 0; i < inputs.length; i++) {
                            if (inputs[i].checked) {
                                gids += inputs[i].value + ",";
                            }
                        }
                        if (remark == "设置备注") remark = "";
                            this.locked = true;
                            var btn = this;
                            $.ajax({
                                dataType: "json",
                                url: "/Ajax/SetGroup/",
                                cache: false,
                                data: { gids: gids, remark: remark, fuid: uid },
                                type: "post",
                                success: function (o) {
                                    if (1 == 1) {
                                        App.fullTip(CodeList["A00004"], 1000, null, 3);
                                        groupDiv.remove();
                                        App.hideMash();
                                    }
                                    else if (o.Code == "A00001") {
                                        App.showLoginDial();
                                    }
                                    else {
                                        App.fullTip(CodeList["A00003"], 1000, null, 1);
                                    }
                                    btn.locked = false;
                                }, error: function () {
                                    App.fullTip(CodeList["A00003"], 1000, null, 1);
                                    btn.locked = false;
                                }
                            });
                        return false;
                    });
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
};
App.getDivShowPosition = function (height, ctrl) {
    ctrl = $(ctrl);
    var scrollTop = $(document).scrollTop();
    var offset = ctrl.offset();
    if (offset.top - height > scrollTop) {
        return { type: "down", left: offset.left, top: offset.top - height };
    }
    else {
        return { type: "up", left: offset.left, top: offset.top + ctrl.height() + 5 };
    }
};
App.NameCardHashTable = new Hashtable();
App.removeNcItemInHsTable = function (key) {
    this.NameCardHashTable.remove(key);
};
App.ShowNameCard = function (elem) {
    var $elem = $(elem);
    var nameCard = $("#NameCard");
    nameCard.find(".mid_c").html('<div class="layerBox"><div style="width: 298px;" class="layerBoxCon1"><div class="name_card"><div class="layerArrow"></div></div></div></div>');
    var uname = $elem.attr("uname");
    var curData = this.NameCardHashTable.get(uname);
    if (curData) {
        nameCard.find(".name_card").append(curData)
        var curPosition = App.getDivShowPosition(nameCard.height(), $elem);
        if (curPosition.type == "down") {
            nameCard.find(".layerArrow").addClass("layerArrow_d");
        }
        nameCard.css("left", curPosition.left).css("top", curPosition.top).show();
    }
    else {
        var loadCon = $('<div style="width: 295px;" class="layerBox"><div class="layerBox_loading"><div class="ll_info"><img width="16" height="16" src="/Content/Image/loading.gif" alt="" title=""><p>正在加载，请稍候。。。</p></div></div></div>');
        nameCard.find(".name_card").append(loadCon);
        var curPosition = this.getDivShowPosition(nameCard.height(), $elem);
        if (curPosition.type == "down") {
            nameCard.find(".layerArrow").addClass("layerArrow_d");
        }
        nameCard.css("left", curPosition.left).css("top", curPosition.top).show();
        $.ajax({
            dataType: "json",
            url: "/Ajax/GetNameCard/",
            data: { name: uname },
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00005") {
                    App.NameCardHashTable.add(uname, o.Data);
                    nameCard.hide().find(".mid_c").html('<div class="layerBox"><div style="width: 298px;" class="layerBoxCon1"><div class="name_card"><div class="layerArrow"></div></div></div></div>').find(".name_card").append(o.Data);
                    curPosition = App.getDivShowPosition(nameCard.height(), $elem);
                    if (curPosition.type == "down") {
                        nameCard.find(".layerArrow").addClass("layerArrow_d");
                    }
                    nameCard.css("left", curPosition.left).css("top", curPosition.top).show();
                }
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else {
                    App.alert(CodeList["A00003"]);
                }
            },
            error: function () {
                App.alert(CodeList["A00003"]);
            }
        });
    }
};
App.initNameCard = function (container) {
    var $NameCard = null;
    if (App.initDialDiv("NameCard", dialDiv, false, null)) {
        $NameCard = $("#NameCard");
        App.lazyEvent($NameCard, "mouseleave", "mouseenter", 500, function () {
            $NameCard.hide();
        });
    }
    else {
        $NameCard = $("#NameCard");
    }
    var $elems = container.find("a[namecard='true']");
    for (var i = 0; i < $elems.length; i++) {
        App.lazyEvent($elems[i], "mouseenter", "mouseleave", 500, function (o) {
            App.ShowNameCard(o);
        }, function () { App.lazyFunction(function () { $NameCard.hide(); }, 500) });
    }
    var $elems = container.find("img[namecard='true']");
    for (var i = 0; i < $elems.length; i++) {
        App.lazyEvent($elems[i], "mouseenter", "mouseleave", 500, function (o) {
            App.ShowNameCard(o);
        }, function () { App.lazyFunction(function () { $NameCard.hide(); }, 500) });
    }

};


App.NameCardFollow = function (id, name, alink) {
    if (alink.locked)
        return;
    alink.locked = true;
    App.FollowOne(id, name, function (ID, Name, O) {
        App.removeNcItemInHsTable(Name);
    }, function () { alink.locked = false; });
};
App.CancelNameCardFollow = function (id, name, alink) {
    if (alink.locked)
        return;
    App.miniConfirm("是否取消关注" + name, alink, function () {
        alink.locked = true;
        App.CancelFollow(id, function (ID, O) {
            App.removeNcItemInHsTable(name);
        }, function () { alink.locked = false; });
    });

};
App.pullBlackList = function (id, successCallBack, defCallBack) {
    $.ajax({
        dataType: "json",
        url: "/Ajax/AddBlackList/",
        data: { id: id },
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00030") {
                if (successCallBack)
                    successCallBack(o);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.alert(CodeList["A00003"]);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.alert(CodeList["A00003"]);
            if (defCallBack)
                defCallBack();
        }
    });
};
App.outBlackList = function (id, successCallback, defCallBack) {
    $.ajax({
        dataType: "json",
        url: "/Ajax/DelBlackListByUID/",
        data: { uid: id },
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00023") {
                if (successCallback)
                    successCallback(o);
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.alert(CodeList["A00003"]);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.alert(CodeList["A00003"]);
            if (defCallBack)
                defCallBack();
        }
    });
};

App.miniblogDel = function ( mid,alink) {
    this.miniConfirm("是否删除该条微博", alink, function () {
        $.ajax({
            dataType: "json",
            url: "/Ajax/DelMiniBlog/",
            data: { mid: mid },
            cache: false,
            type: "post",
            success: function (o) {
                if (o.Code == "A00018") {
                    $("#mid_" + mid).fadeOut();
                }
                else if (o.Code == "A00001") {
                    App.showLoginDial();
                }
                else {
                    App.alert(CodeList["A00003"]);
                }

            },
            error: function () {
                App.alert(CodeList["A00003"]);
            }
        });
    });

};

App.DelMessageByMid = function (mid, sucCallBack, defCallBack) {

    $.ajax({
        dataType: "json",
        url: "/Ajax/DelMessageByMid/",
        data: { mid: mid },
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00018") {
                if (sucCallBack)
                    sucCallBack();
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.alert(CodeList["A00003"]);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.alert(CodeList["A00003"]);
            if (defCallBack)
                defCallBack();
        }
    });

};

App.DelMessageByUID = function (uid,toUid, sucCallBack, defCallBack) {

    $.ajax({
        dataType: "json",
        url: "/Ajax/DelMessageByUid/",
        data: { uid: uid,toUid:toUid },
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00018") {
                if (sucCallBack)
                    sucCallBack();
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.alert(CodeList["A00003"]);
            }
            if (defCallBack)
                defCallBack();
        },
        error: function () {
            App.alert(CodeList["A00003"]);
            if (defCallBack)
                defCallBack();
        }
    });

};

App.showReportBox = function (alink, uid, type, typeid) {
    if (alink.locked)
        return false;
    alink.locked = true;
    $.ajax({
        dataType: "json",
        url: "/Ajax/GetComplaintContent/",
        data: { ToUID: uid, ConType: type, ConID: typeid },
        cache: false,
        type: "post",
        success: function (o) {
            if (o.Code == "A00005") {
                if (App.initDialDiv("ReportBox", dialDiv, false, null)) {
                    var box = $("#ReportBox");
                    box.removeClass("4CancelAllLayer");
                    box.find(".mid_c").html(o.Data);
                    $("#ReportBox .close").click(function () {
                        box.remove();
                        App.hideMash();
                    });
                    var position = App.centerInScreen(box);
                    box.css("left", position.left + "px");
                    box.css("top", position.top + "px");
                    App.showMash();

                    $("#SendReport").click(function () {
                        if (this.locked)
                            return false;
                        this.locked = true;
                        sendLink = this;
                        $.ajax({
                            dataType: "json",
                            url: "/Ajax/CreateComplaint/",
                            data: { ToUID: uid, ComplaintConType: type, ComplaintConID: typeid, ComplaintReason: $("input[name='reportType']:checked").val(), ComplaintSupplement: $("#supplement").val() },
                            cache: false,
                            type: "post",
                            success: function (od) {
                                if (od.Code == "A00031") {
                                    box.remove();
                                    App.hideMash();
                                    App.fullTip(CodeList["A00031"], 1000, null, 3);
                                }
                                else if (od.Code == "A00001") {
                                    App.showLoginDial();
                                }
                                else {
                                    App.fullTip(CodeList["A00003"], 1000, null, 1);
                                }
                                sendLink.locked = false;
                            },
                            error: function () {
                                App.fullTip(CodeList["A00003"], 1000, null, 1);
                                sendLink.locked = false;
                            }
                        });

                    });
                }
            }
            else if (o.Code == "A00001") {
                App.showLoginDial();
            }
            else {
                App.alert(CodeList["A00003"]);
            }
            alink.locked = false;
        },
        error: function () {
            App.alert(CodeList["A00003"]);
            alink.locked = false;
        }
    });

};

App.highLineTxtBox = function ($txtbox) {
    $txtbox.css("backgroundColor", 'rgb(255, 180, 180)');
    $txtbox.animate({ backgroundColor: 'rgb(255, 255, 255)' }, 300, function () {
        $txtbox.css("backgroundColor", 'rgb(255, 180, 180)');
        $txtbox.animate({ backgroundColor: 'rgb(255, 255, 255)' }, 300);
    });
};

App.elemBlur = function ($elem, $clickElem) {
    var clickDoc = function () {
        $elem.hide();
        $(this).unbind("click", clickDoc);
    };
    $clickElem.click(function (e) {
        e.stopPropagation();
        $(document).bind("click", clickDoc);
    });
    $elem.bind("click", function (e) {
        e.stopPropagation();
    });
};
