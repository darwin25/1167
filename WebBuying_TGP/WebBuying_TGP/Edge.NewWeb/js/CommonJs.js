var CommonJs = {
    //获取所有URL参数，返回一个JSON
    GetUrlParams: function () {
        var m = {};
        var str = location.search;
        if (str.length > 0) {
            var strUrl = location.search.substring(1, location.search.length).split('&');
            for (var i = 0; i < strUrl.length; i++) {
                var curStr = strUrl[i].split('=');
                if (curStr.length == 2) {
                    m[curStr[0]] = curStr[1];
                }
            }
        }
        return m;
    },
    //将JSON转为URL形式
    GetUrlByJson: function (json) {
        var u = "";
        for (var key in json) {
            u = u + key + "=" + escape(json[key]) + "&";
        }
        return u.substring(0, u.length - 1);
    },
    //设置options选中,obj:js对象
    SelectedObj: function (obj, v) {
        $ops = $(obj).find("option");
        $ops.removeAttr("selected");
        $ops.each(function () {
            if ($(this).attr("value") == v) {
                $(this).attr({ "selected": "selected" });
                return false;
            }
        });
    }
};