+(function (window, iScroll, $) {
    function Yxscroll(opts) {
        this.settings = {
            wrapper: "",
            server: "",
            header: false,
            type: "JSON",
            down: {
                elem: "",
                textBox: "",
                text1: "下拉加载",
                text2: "松开后立即更新",
                loaddingText: "刷新中...",
                data: {},
                action: null,
                success: null
            },
            up: {
                elem: "",
                textBox: "",
                text1: "加载更多",
                text2: "松开后立即更新",
                loaddingText: "刷新中...",
                data: {},
                action: null,
                success: null
            }
        }, that = this;
        $.extend(that.settings, opts);
        var mainScroll,
            downElem = document.querySelector(that.settings.down.elem),
            upY = 0,
            upElem = document.querySelector(that.settings.up.elem);
        var init = function () {
            mainScroll = new iScroll(that.settings.wrapper.substring(1), {
                useTransition: true,
                topOffset: downElem.offsetHeight,
                onRefresh: function () {
                    if (downElem.className.match('loading')) {
                        downElem.className = downElem.className.replace("loading", "").trim();
                        downElem.querySelector(that.settings.down.textBox).innerHTML = that.settings.down.text2 || "松开后立即更新";
                    }
                    else if (upElem && upElem.className.match('loading')) {
                        upElem.className = upElem.className.replace("loading", "").trim();
                        upElem.querySelector(that.settings.up.textBox).innerHTML = that.settings.up.text1 || "上拉加载";
                    }
                },
                onScrollMove: function () {
                    upY = this.y;
                    if (this.y > 5 && !downElem.className.match('flip')) {
                        downElem.className += ' flip';
                        downElem.querySelector(that.settings.down.textBox).innerHTML = that.settings.down.text2 || "松开后立即更新";
                        this.minScrollY = 0;
                    } else if (this.y < 5 && downElem.className.match('flip')) {
                        downElem.className = downElem.className.replace("flip", "").trim();
                        downElem.querySelector(that.settings.down.textBox).innerHTML = that.settings.down.text1 || "下拉加载";
                        this.minScrollY = -downElem.offsetHeight;
                    } else if (this.y < (this.maxScrollY - 5) && !upElem.className.match('flip')) {
                        upElem.className += ' flip';
                        //upElem.querySelector(that.settings.up.textBox).innerHTML = that.settings.up.text2 || "松开后立即更新";
                        this.maxScrollY = this.maxScrollY;
                    } else if (this.y > (this.maxScrollY + 5) && upElem.className.match('flip')) {
                        upElem.className = upElem.className.replace("flip", "").trim();
                        upElem.querySelector(that.settings.up.textBox).innerHTML = that.settings.up.text1 || "上拉加载";
                        this.maxScrollY = upElem.offsetHeight;
                    }
                },
                onScrollEnd: function () {
                    if (downElem.className.match('flip')) {
                        downElem.className = downElem.className.replace("flip", "").trim();
                        downElem.className += ' loading';
                        downElem.querySelector(that.settings.down.textBox).innerHTML = that.settings.down.loaddingText || "刷新中...";
                        that.settings.down.action && that.settings.down.action(that.settings.down);
                        $.get(that.settings.server, that.settings.down.data, function (data) {
                            if (that.settings.down.success) {
                                that.settings.down.success(data);
                            }
                            mainScroll.refresh();
                        }, function (data) {
                            mainScroll.refresh();
                        }, that.settings.type, that.settings.header);
                    } else if (upElem && upElem.className.match('flip') && upY < -60) {
                        upElem.className = upElem.className.replace("flip", "").trim();
                        upElem.className += ' loading';
                        upElem.querySelector(that.settings.up.textBox).innerHTML = that.settings.up.loaddingText || "刷新中...";
                        that.settings.up.action && that.settings.up.action(that.settings.up);
                        $.get(that.settings.server, that.settings.up.data, function (data) {
                            if (that.settings.up.success) {
                                that.settings.up.success(data);
                            }
                            mainScroll.refresh();
                        }, function (data) {
                            mainScroll.refresh();
                        }, that.settings.type, that.settings.header);
                    }
                }
            });
            setTimeout(function () { document.getElementById(that.settings.wrapper.substring(1)).style.left = '0'; }, 800);
        };
        document.addEventListener('touchstart', function (e) {
            if (e && e.preventDefault)
                e.preventDefault();
            else
                window.event.returnValue = false;
            return false;
        }, false);
        document.addEventListener('touchend', function (e) {
            if (e && e.preventDefault)
                e.preventDefault();
            else
                window.event.returnValue = false;
            return false;
        }, false);
        init();
    };
    window.yxr = Yxscroll
})(window, iScroll, typeof Zepto === "undefined" ? jQuery : Zepto);