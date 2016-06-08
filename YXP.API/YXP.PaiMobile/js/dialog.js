; (function (window, $) {

    var yx = {
        version: "1.0.0.0",
        dialogs: []
    };

    var confirm = '<div class="aui-dialog  logout-alert" id="{boxId}">' +
        '        <div class="aui-dialog-body aui-text-center">' +
        '        </div>' +
        '        <div class="aui-dialog-footer">' +
        '            <div class="aui-dialog-btn cancel"></div>' +
        '            <div class="aui-dialog-btn ok"></div>' +
        '        </div>' +
        '    </div>';

    var tips = '<div class="aui-toast"  id="{tipsId}" style="top: 50%;">' +
        // '<i class="aui-iconfont "></i>' +
        '<div class="aui-toast-content" style="text-align: center;padding: .6rem;line-height:1.2rem;font-size:.75rem;margin-bottom:0px;"></div>' +
        '</div>';

    var loading = '<div class="aui-toast"  id="{loadingId}">' +
        '<div class="aui-toast-loading"></div>' +
        '<div class="aui-toast-content"></div>' +
        '</div>';

    var make = "<div class='aui-mask' id='{makeId}'></div>";

    function Dialog(opts) {
        var id = this.tools.random(100000000, 999999999);
        this.id = "dialog" + id;
        this.makeId = "make" + id;
        this.settings = {
            content: "",
            init: false,
            okText: "确定",
            time: 4000,
            icon: true,
            ok: true,
            cancelText: "取消",
            cancel: false,
            type: "confirm",
            focus: -1
        };
        $.extend(this.settings, opts);
        this.confirm = $(confirm.replace("{boxId}", this.id));
        this.make = $(make.replace("{makeId}", this.makeId));
        this.tips = $(tips.replace("{tipsId}", this.id));
        this.loading = $(loading.replace("{loadingId}", this.id));
        this.init();
    }

    Dialog.prototype.init = function () {
        var me = this;
        switch (this.settings.type.toLowerCase()) {
            case "tips":
                this.tips.find(".aui-toast-content").html(this.settings.content);
                this.settings.icon ? this.tips.find(".aui-iconfont").addClass("aui-icon-check") : this.tips.find(".aui-iconfont").addClass("aui-icon-close");
                setTimeout(function () {
                    me.tips.remove();
                }, this.settings.time || 2000);
                break;
            case "loading":
                this.loading.find(".aui-toast-content").html(this.settings.content || "加载中...");
                break;
            case "confirm":
            default:
                $("body").append(this.confirm);
                this.confirm.find(".aui-dialog-body").html(this.settings.content);
                this.confirm.find(".cancel").text(this.settings.cancelText || "取消");
                this.confirm.find(".ok").text(this.settings.okText || "确定");
                if (this.settings.focus === 0) {
                    this.confirm.find(".aui-dialog-btn").eq(0).addClass("aui-text-danger");
                }
                if (this.settings.focus > 0) {
                    this.confirm.find(".aui-dialog-btn").eq(1).addClass("aui-text-danger");
                }
                this.confirm.find(".cancel").on("touchend", function (e) {
                    me.cancel();
                    e.preventDefault();
                });
                this.confirm.find(".ok").on("touchend", function (e) {
                    me.ok();
                    e.preventDefault();
                });

                this.confirm.find(".aui-dialog-btn").on("touchstart", function () {
                    if (!$(this).hasClass("active")) {
                        $(this).addClass("active");
                    }
                }, false);

                this.confirm.find(".aui-dialog-btn").on("touchend", function () {
                    if ($(this).hasClass("active")) {
                        $(this).removeClass("active");
                    }
                }, false);
                break;
        }
        this.settings.init && this.settings.init(this);
    }

    Dialog.prototype.tools = {
        random: function (min, max) {
            var num = max - min;
            return parseInt(Math.random() * num + min);
        }
    }

    Dialog.prototype.show = function () {
        switch (this.settings.type.toLowerCase()) {
            case "tips":
                $("body").append(this.tips);
                break;
            case "loading":
                $("body").append(this.loading);
                break;
            case "confirm":
            default:
                $("body").append(this.confirm);
                $("body").append(this.make);
                break;
        }
    }


    Dialog.prototype.cancel = function () {
        this.settings.cancel && this.settings.cancel();
        switch (this.settings.type.toLowerCase()) {
            case "confirm":
            default:
                this.confirm.remove();
                this.make.remove();
                break;
        }
    }

    Dialog.prototype.ok = function () {
        if (typeof this.settings.ok === "boolean")
            this.close();
        else {
            if (this.settings.ok !== false) {
                this.close();
            }
            this.settings.ok && this.settings.ok();
        }
    }

    Dialog.prototype.close = function () {
        $("#" + this.id).remove();
        $("#" + this.makeId).remove();
    };

    yx.dialog = function (opts) {
        var dialog = new Dialog(opts);
        dialog.show();
        return dialog;
    }

    yx.confirm = function (text, okfn, cfn) {
        var d = yx.dialog({
            content: text,
            cancelText: "取消",
            okText: "确定",
            focus: 1,
            cancel: function () {
                cfn && cfn();
            },
            ok: function () {
                okfn && okfn();
            }
        });
        return d;
    }

    yx.tips = function (text, icon, time) {
        var dialog = new Dialog({
            type: "tips",
            icon: icon,
            content: text,
            time: time
        });
        dialog.show();
        return dialog;
    }


    yx.loading = function (text) {
        var dialog = new Dialog({
            type: "loading",
            content: text
        });
        dialog.show();
        return dialog;
    }
    window.yx = yx;
})(window, typeof Zepto === "undefined" ? jQuery : Zepto);