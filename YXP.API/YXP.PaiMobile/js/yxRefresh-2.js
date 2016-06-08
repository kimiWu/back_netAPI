+(function (window, iScroll) {

    function YxRefresh(opts) {
        this.scroll = null;
        this.settings = {
            content: "",
            server: "",
            header: false,
            type: "JSON",
            down: {
                elem: "",
                data: {},
                status: true,
                action: null,
                success: null
            },
            up: {
                elem: "",
                data: {},
                status: true,
                action: null,
                success: null
            }
        };
        tools.copy(this.settings, opts);
    };

    YxRefresh.prototype.init = function () {
        var me = this;
        var downElem = document.querySelector(me.settings.down.elem);
        var upElem = document.querySelector(me.settings.up.elem);
        this.scroll = new iScroll(me.settings.content, {
            useTransition: true,
            topOffset: downElem.offsetHeight,
            onRefresh: function () {
                if (downElem.className.match('loading')) {
                    downElem.className = '';
                    downElem.querySelector('.pullDownLabel').innerHTML = '松开后立即更新';
                } else if (upElem.className.match('loading')) {
                    upElem.className = '';
                    upElem.querySelector('.pullUpLabel').innerHTML = '加载更多';
                }
            },
            onScrollMove: function () {
                if (this.y > 5 && !downElem.className.match('flip')) {
                    downElem.className = 'flip';
                    downElem.querySelector('.pullDownLabel').innerHTML = '松开后立即更新';
                    this.minScrollY = 0;
                } else if (this.y < 5 && downElem.className.match('flip')) {
                    downElem.className = '';
                    downElem.querySelector('.pullDownLabel').innerHTML = '下拉加载';
                    this.minScrollY = -downElem.offsetHeight;
                } else if (this.y < (this.maxScrollY - 5) && !upElem.className.match('flip')) {
                    upElem.className = 'flip';
                    upElem.querySelector('.pullUpLabel').innerHTML = '松开加载更多';
                    this.maxScrollY = this.maxScrollY;
                } else if (this.y > (this.maxScrollY + 5) && upElem.className.match('flip')) {
                    upElem.className = '';
                    upElem.querySelector('.pullUpLabel').innerHTML = '加载更多';
                    this.maxScrollY = upElem.offsetHeight;
                }
            }, onScrollEnd: function () {
                if (downElem.className.match('flip')) {
                    downElem.className = 'loading';
                    downElem.querySelector('.pullDownLabel').innerHTML = '刷新中...';
                    if (me.settings.down.status) {
                        me.settings.down.action && me.settings.down.action();
                        $.ajax({
                            url: me.settings.server,
                            data: me.settings.down.data,
                            headers: me.settings.header === false ? {} : me.settings.header,
                            dataType: me.settings.type,
                            success: function (data) {
                                me.settings.down.success && me.settings.down.success(data);
                                me.scroll.refresh();
                            }, error: function () {
                                me.scroll.refresh();
                            }
                        });
                    }
                } else if (upElem.className.match('flip')) { 
                    upElem.className = 'loading';
                    upElem.querySelector('.pullUpLabel').innerHTML = '刷新中...';
                    if (me.settings.up.status) {
                        me.settings.up.action && me.settings.up.action();
                        $.ajax({
                            url: me.settings.server,
                            data: me.settings.up.data,
                            headers: me.settings.header === false ? {} : me.settings.header,
                            dataType: me.settings.type,
                            success: function (data) {
                                me.settings.up.success && me.settings.up.success(data);
                                me.scroll.refresh();
                            }, error: function () {
                                me.scroll.refresh();
                            }
                        });
                    }
                }
            }
        });
    };
    var tools = {
        copy: function (obj1, obj2) {
            for (var d in obj2) {
                obj1[d] = obj2[d];
            }
            return this;
        }
    };
    window.yxr = YxRefresh
})(window, iScroll);