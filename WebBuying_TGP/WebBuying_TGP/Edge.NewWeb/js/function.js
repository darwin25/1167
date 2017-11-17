//==========================页面加载时JS函数开始===============================
//输入框显示提示效果，配合CSS运用
$(function () {
    $(".input,.login_input,.textarea").focus(function () {
        $(this).addClass("focus");
    }).blur(function () {
        $(this).removeClass("focus");
    });

    $(".submit").mouseover(function () {
        $(this).addClass("submitFocus");

    }).mouseout(function () {
        $(this).removeClass("submitFocus");
    });

    //输入框提示,获取拥有HintTitle,HintInfo属性的对象
    $("[HintTitle],[HintInfo]").focus(function (event) {
        $("*").stop(); //停止所有正在运行的动画
        $("#HintMsg").remove(); //先清除，防止重复出错
        var HintHtml = "<ul id=\"HintMsg\"><li class=\"HintTop\"></li><li class=\"HintInfo\"><b>" + $(this).attr("HintTitle") + "</b>" + $(this).attr("HintInfo") + "</li><li class=\"HintFooter\"></li></ul>"; //设置显示的内容
        var offset = $(this).offset(); //取得事件对象的位置
        var cWidth = $(this).width(); //取得事件对象的位置
        $("body").append(HintHtml); //添加节点
        $("#HintMsg").fadeTo(0, 0.85); //对象的透明度
        var HintHeight = $("#HintMsg").height(); //取得容器高度
        $("#HintMsg").css({ "top": offset.top + "px", "left": offset.left + cWidth + 20 + "px" }).fadeIn(500);
    }).blur(function (event) {
        $("#HintMsg").remove(); //删除UL
    });


    $(".svaPoint,.svaAmount,.svaQty").bind("keyup", function (event) {
        var keyCode = event.which;
        if (keyCode >= 37 && keyCode <= 40) return;

        var element = document.getElementById($(this).attr("id"))
        var pos = getCursortPosition(element);

        var result = formatNumber($(this).val(), pos);

        $(this).val(result[0]);

        setSelection(element, pos + result[1]);
    });

    $(".svaCode").addClass("inputUpper");
    $(".svaCode").keypress(function (event) {
        var keyCode = event.which;
        if ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (keyCode >= 48 && keyCode <= 57))
            return true;
        else
            return false;
    }).focus(function () {
        this.style.imeMode = 'disabled';
    });

    $(".NumMaskValid").keypress(function (event) {
        var keyCode = event.which;

        if (keyCode == 65 || (keyCode == 57) || (keyCode == 97))
            return true;
        else
            return false;
    }).focus(function () {
        this.style.imeMode = 'disabled';
    });

    //添加输入限制
    if (jQuery != undefined && jQuery.validator != undefined) {
        jQuery.validator.addMethod("svaAmount", function (value, element) {
            if (value == null || value.length <= 0) return true;

            var reg = /^(\d{1,2},){0,1}(\d{1,3},){0,1}\d{1,3}(\.\d{1,2})?$/gi;
            return reg.exec(value);
        }, jQuery.validator.messages.SvaAmount);

        jQuery.validator.addMethod("svaPoint", function (value, element) {
            if (value == null || value.length <= 0) return true;

            var reg = /^(\d{1,2},){0,1}(\d{1,3},){0,1}\d{1,3}$/gi;
            return reg.exec(value);
        }, jQuery.validator.messages.SvaPoint);

        jQuery.validator.addMethod("svaDiscount", function (value, element) {
            if (value == null || value.length <= 0) return true;

            var reg = /^(100|\d{1,2})$/gi;
            return reg.exec(value);
        }, jQuery.validator.messages.SvaDiscount);

        jQuery.validator.addMethod("svaQty", function (value, element) {
            if (value == null || value.length <= 0) return true;

            var reg = /^(\d{1,2},){0,1}\d{1,3}$/gi;
            return reg.exec(value);
        }, jQuery.validator.messages.SvaQty);

        jQuery.validator.addMethod("NumMaskValid", function (value, element) {
            if (value == null || value.length <= 0) return true;
            var reg = /^A*9+$/gi;
            var isNumber = /^9+/gi;
            if (isNumber.exec(value)) {
                $(".NumPatternValid").val("");
                $(".NumPatternValid").attr('disabled', true);
                $(".NumPatternValid").removeClass("required");

            }
            else {
                $(".NumPatternValid").removeAttr('disabled');
                $(".NumPatternValid").addClass("required");
            }
            return reg.exec(value);
        }, jQuery.validator.messages.NumMaskValid);

        jQuery.validator.addMethod("NumPatternValid", function (value, element) {
            var reg = /^A+/gi;
            var mask = $(".NumMaskValid").val();
            if (mask.length <= 0) return true;

            var result = reg.exec(mask);
            if (result == null || result.length <= 0) return true;

            return result.toString().length == value.length;

        }, jQuery.validator.messages.NumPatternValid);

        jQuery.validator.addMethod("svaCode", function (value, element) {
            if (value == null || value.length <= 0) return true;

            var reg = /^[A-Z0-9]+$/gi;
            return reg.exec(value);

        }, jQuery.validator.messages.SvaCode);
    }
});


//==========================页面加载时JS函数结束===============================

//===========================系统管理JS函数开始================================

//后台主菜单控制函数
function tabs(tabNum) {
    //设置点击后的切换样式
    $("#tabs ul li").removeClass("hover");
    $("#tabs ul li").eq(tabNum - 1).addClass("hover");
    //根据参数决定显示子菜单
    $(".fragment").hide();
    $(".fragment").eq(tabNum - 1).show();
}

//全选取消按钮函数，调用样式如：
function checkAll(chkobj) {
    if ($(chkobj).attr("checked") == true) {
        $(".checkall input").attr("checked", true);
        $(".checkall input[disabled]").attr("checked", false);

    } else {
        $(".checkall input").attr("checked", false);
    }
}

//全选取消按钮函数，调用样式如：
function checkAllSearch(chkobj) {
    if ($(chkobj).attr("checked") == true) {
        $(".checkall input").attr("checked", true);
        $(".checkall ").attr("checked", true);

    } else {
        $(".checkall input").attr("checked", false);
        $(".checkall ").attr("checked", false);
    }
}

//判断是否有选择
function checkAndConfirm(msg) {
    var isCheck = false;
    $(".checkall input").each(function () {
        if ($(this).attr("checked") == true) {
            isCheck = true;
            return false;
        }
    });
    if (!isCheck) {
        parent.jAlert("Please Select Item", "Warning Message.");
        return false;
    }
    else {
        return confirm(msg);
    }
}

//===========================系统管理JS函数结束================================

//================上传文件JS函数开始，需和jquery.form.js一起使用===============
//单个文件上传
function SingleUpload(repath, hideValue, uppath, savefilesubpath, submitUrl) {

    submitUrl = submitUrl + "?ReFilePath=" + repath + "&UpFilePath=" + uppath + "&SaveFileSubPath=" + savefilesubpath;
    //开始提交
    $("#form1").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $("#" + repath).nextAll(".files").eq(0).hide();
            //显示LOADING图片
            $("#" + repath).nextAll(".uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.msg == 1) {
                $("#" + repath).val(data.msbox);
                $("#" + hideValue).val(data.msbox);
            } else {
                alert(data.msbox);
            }
            $("#" + repath).nextAll(".files").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
            $("#" + repath).nextAll(".files").eq(0).show();
            $("#" + repath).nextAll(".uploading").eq(0).hide();
        },
        url: submitUrl,
        type: "post",
        dataType: "json",
        timeout: 600000
    });
};
//===========================上传文件JS函数结束================================

//===========================检测Url函数开始================================
function checkUrl(link) {
    var textboxs = $(link).parent().children("input");
    if (textboxs.length > 0) {
        var regUrl = /\?Url=[^&]*/gi;
        link.href = link.href.replace(regUrl, "?Url=" + textboxs[0].value);
    }
}
//===========================检测Url函数结束================================
//===========================格式化输出=====================================
function formatNumber(num) {
    if (!num || num.length <= 0) return "";
    var strNum = "";
    var dif = 0;
    for (i = 0; i < num.length; i++) {
        if (num.charAt(i) == ",") {
            dif = dif - 1;
            continue;
        }
        strNum += num.charAt(i);
    }

    //判断是否存在小数
    var reg = /\.\w+/g;
    var amount = reg.exec(strNum);
    if (amount != null) {
        strNum = strNum.replace(reg, "");
    }

    var result = "";
    for (i = strNum.length - 1; i >= 0; i--) {
        if ((i - 2) % 3 == 0) {
            result += ",";
            dif = dif + 1;
        }
        result += strNum.charAt(strNum.length - i - 1);
    }
    if (result.charAt(0) == ",") {
        result = result.substring(1, result.length);
        dif = dif - 1;
    }

    if (amount != null) result = result + amount;

    return [result, dif];
}

function closeLoadingBar() {
    tb_remove();
    if ($('#TB_load').length > 0) {
        $('#TB_load').remove();
    }
}

function setSelection(editor, pos) {
    if (editor.setSelectionRange) {
        editor.focus();
        editor.setSelectionRange(pos, pos);
    } else if (editor.createTextRange) {
        var textRange = editor.createTextRange();
        textRange.collapse(true);
        textRange.moveEnd("character", pos);
        textRange.moveStart("character", pos);
        textRange.select();
    }
}
function getCursortPosition(ctrl) {//获取光标位置函数
    var CaretPos = 0; // IE Support
    if (document.selection) {
        ctrl.focus();
        var Sel = document.selection.createRange();
        Sel.moveStart('character', -ctrl.value.length);
        CaretPos = Sel.text.length;
    }
    // Firefox support
    else if (ctrl.selectionStart || ctrl.selectionStart == '0')
        CaretPos = ctrl.selectionStart;
    return (CaretPos);
}
(function ($) {
    $.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
})(jQuery);


function printdiv(printpage) {
    window.focus();
    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body>";
    var newstr = document.getElementById(printpage).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + newstr + footstr;
    window.print();
    document.body.innerHTML = oldstr;
    return false;
}
//===========================格式化输出=====================================

//===========================注释函数=====================================
//主框架切换及显示首次快捷菜单
//$(function(){
//	//Close打开左栏目
//	$("#sysBar").toggle(function(){
//		$("#mainLeft").hide();
//		$("#barImg").attr("src","images/butOpen.gif");
//	},function(){
//		$("#mainLeft").show();
//		$("#barImg").attr("src","images/butClose.gif");
//	});
//	//页面加载完毕，显示第一个子菜单
//	$(".left_menu").hide();
//	$(".left_menu:eq(0)").show();
//});

//遮罩提示窗口
//function jsmsg(w, h, msgtitle, msgbox, url,msgcss) {
//    $("#msgdialog").remove();
//    var cssname = "";
//    switch (msgcss) {
//        case "Success":
//            cssname = "icon-01";
//            break;
//        case "Error":
//            cssname = "icon-02";
//            break;
//        default:
//            cssname = "icon-03";
//            break;
//    }
//    var str = "<div id='msgdialog' title='" + msgtitle + "'><p class='" + cssname + "'>" + msgbox + "</p></div>";
//    $("body").append(str);
//    $("#msgdialog").dialog({
//        //title: null,
//        //show: null,
//        bgiframe: true,
//        autoOpen: false,
//        width: w,
//        //height: h,
//        resizable: false,
//        closeOnEscape: true,
//        buttons: { "确定": function() { $(this).dialog("close"); } },
//        modal: true
//    });
//    $("#msgdialog").dialog("open");
//    if (url == "back") {
//        sysMain.history.back(-1);
//    } else if(url !="") {
//        sysMain.location.href = url;
//    }
//}

//可以自动Close的提示
//function jsprint(msgtitle, url, msgcss) {
//    $("#msgprint").remove();
//    var cssname = "";
//    switch (msgcss) {
//        case "Success":
//            cssname = "pcent correct";
//            break;
//        case "Error":
//            cssname = "pcent disable";
//            break;
//        default:
//            cssname = "pcent warning";
//            break;
//    }
//    var str = "<div id=\"msgprint\" class=\"" + cssname + "\">" + msgtitle + "</div>";
//    $("body").append(str);
//    $("#msgprint").show();
//    if (url == "back") {
//        sysMain.history.back(-1);
//    } else if (url != "") {
//        sysMain.location.href = url;
//    }
//    //3秒后清除提示
//    setTimeout(function() {
//        $("#msgprint").fadeOut(500);
//        //如果动画结束则删除节点
//        if (!$("#msgprint").is(":animated")) {
//            $("#msgprint").remove();
//        }
//    }, 3000);
//}

//全选取消按钮函数，调用样式如：
//function checkAll(chkobj){
//	if($(chkobj).text()=="全选")
//	{
//		$(chkobj).text("取消");
//		$(".checkall input").attr("checked", true);
//	}else{
//		$(chkobj).text("全选");
//		$(".checkall input").attr("checked", false);
//	}
//}
//===========================注释函数=====================================