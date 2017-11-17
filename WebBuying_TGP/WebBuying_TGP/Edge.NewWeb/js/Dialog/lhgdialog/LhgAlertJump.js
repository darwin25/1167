/*!
*------------------------------------------------
* 对话框其它功能扩展模块（可选外置模块）
*------------------------------------------------
*/
; (function ($, lhgdialog, undefined) {

    var _zIndex = function () {
        return lhgdialog.setting.zIndex;
    };

    lhgdialog.alertjump = function (content, yes, icon, title) {
        return lhgdialog({
            title: title || '',
            id: 'Alert',
            zIndex: _zIndex(),
            icon: icon || 'warning.png',
            lock: true,
            ok: function (here) {
                return yes.call(this, here);
            },
            close: function (here) {
                return yes.call(this, here);
            },
            resize: false,
            content: content
        });
    };

})(window.jQuery || window.lhgcore, this.lhgdialog);