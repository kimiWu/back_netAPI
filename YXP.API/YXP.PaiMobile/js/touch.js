var utils = (function (){

    var me = {};

    //判断对象是否为 json
    me.isJSON = function(obj){
        var isJSON = typeof obj == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length;
        return isJSON;
    };

    //判断对象是否为 array
    me.isArray = function(obj){
        var isArray = typeof obj != 'object' ? false : obj instanceof Array ? true : false;
        return isArray;
    };

    //判断对象是否为 DOM
    me.isDOM = ( typeof HTMLElement === 'object' ) ?
        function(obj){
            return obj instanceof HTMLElement;
        } : function(obj){
        return obj && typeof obj === 'object' && obj.nodeType === 1 && typeof obj.nodeName === 'string';
    };

    //html字符串转为 dom
    me.createHTML = function(str){

        var newHTML = document.createElement('div');
        newHTML.innerHTML = str;
        newHTML = newHTML.childNodes[0];
        return newHTML;

    };

    me.isPhone = (function(){
        var phone = (navigator.userAgent.match(/Android/i) == 'Android') || ((navigator.userAgent.indexOf('iPhone') != -1) || (navigator.userAgent.indexOf('iPod') != -1) || (navigator.userAgent.indexOf('iPad') != -1));
        return phone;
    })();

    //push json
    me.pushJSON = function(p, n){

        if(!n){
            n = p;
            p = {};
        }

        var newJSON = p;
        if(this.isJSON(n)){
            for(var i in n)
                p[i] = n[i];
            newJSON = p;
        }else if(this.isArray(n)){
            for(var j in n)
                if(this.isJSON(n[j]))
                    for(var i in n[j])
                        p[i] = n[j][i];
        };

        return newJSON;
    };

    //json数组和url互转
    me.stringToJSON = function(obj){
        var newObj = typeof obj == 'string' ? {} : '?';
        if(typeof obj == 'string'){
            obj = obj.split('&');
            if(obj.length == 0)
                return false;
            for(var i in obj){
                obj[i] = obj[i].split('=');
                newObj[obj[i][0]] = obj[i][1];
            }
        }else if(this.isJSON(obj)){
            for(var i in obj)
                newObj += i+'='+obj[i]+'&';
            newObj = newObj.substring(0, newObj.length - 1);
        }else
            newObj = false;

        return newObj;
    };

    //获取url内的参数
    me.setUrlParam = function(url){
        return url.indexOf('?') != -1 ? this.stringToJSON(url.substring(url.indexOf('?') + 1, url.length)) : '';
    };

    //获取删掉参数的 url
    me.removeUrlParam = function(url){
        return url.indexOf('?') != -1 ? url.substring(0, url.indexOf('?')) : url;
    };

    return me;
})();


(function(){

    HTMLElement.prototype.touch = function(options, deviation, stop){
        var that = this
            //,   isTouch = "createTouch" in document ? true : false
        ,   isTouch = "ontouchend" in document ? true : false
        ,   direction = [null, null]
        ,   _deviation = deviation || 5
        ,   tap = false
        ,   move = false
        ,   hold = false
        ,   moveStart = false
        ,   moveError = true
        ,   holdLoad = null
        ,   holdTime = 700
        ,   holdStart = false
        ,   position = {
            start : {
                x: null,
                y: null
            }
        }
        //,   stop = stop == undefined || stop == null ? false : stop;

        ,   stop = false;
        if(!that.touchState && that.touchState !== false)
            that.touchState = true;
        if(!that.eventListener)
            that.eventListener = {
                start : null,
                move: null,
                end: null
            };

        if(!that.incident){
            that.incident = {
                tap: {
                    start: [],
                    end: [],
                    error: []
                },
                move: {
                    start: [],
                    move: [],
                    end: [],
                    error: []
                },
                hold: {
                    success: [],
                    end: [],
                    error: []
                }
            };
        };

        deviation = deviation || _deviation;

        //删除上一次的注册事件
        if(that.eventListener.start){
            that.removeEventListener('mousedown', that.eventListener.start);
            that.removeEventListener('touchstart', that.eventListener.start);

            that.removeEventListener('mousemove', that.eventListener.move);
            that.removeEventListener('touchmove', that.eventListener.move);

            that.removeEventListener('mouseup', that.eventListener.end);
            that.removeEventListener('touchend', that.eventListener.end);
        };

        //push 绑定的事件
        for(i in options){
            if(utils.isJSON(that.incident[i])){
                if(i === 'tap' && typeof options.tap === 'function')
                    that.incident.tap.end.push(options.tap);
                else if(i === 'move' && typeof options.move === 'function')
                    that.incident.move.move.push(options.move);
                else if(i === 'hold' && typeof options.hold === 'function')
                    that.incident.hold.success.push(options.hold);
                else if(utils.isJSON(options[i])){
                    for(j in options[i]){
                        if(utils.isArray(that.incident[i][j]))
                            that.incident[i][j].push(options[i][j]);
                    };
                };

            };
        };

        //计算tap的误差值
        deviation = new Array(deviation, deviation - deviation * 2);


        //var tapStartLoad = null;


        //touch事件开始
        that.eventListener.start = function(event){

            //tapStartLoad = window.setTimeout(function(){
            //    tapStartLoad = null;
            //    if(stop && tap) {
            //        event.preventDefault();
            //        event.stopPropagation();
            //    }
            //}, 300);
            //
            //tapStartLoad = function(){
            //    event.preventDefault();
            //    event.stopPropagation();
            //};

            var _event = [event];

            if(event.type === 'touchstart') {
                that.removeEventListener('mousedown', that.eventListener.start);
                _event = event.touches;
            };

            var _input = document.getElementsByTagName('input');
            for(var i in _input){
                if(_input[i].blur)
                    _input[i].blur();
            };

            var _textarea = document.getElementsByTagName('textarea');
            for(var i in _textarea){
                if(_textarea[i].blur)
                    _textarea[i].blur();
            };

            position.start.x = _event[0].clientX;
            position.start.y = _event[0].clientY;

            _event[0].startX = position.start.x;
            _event[0].startY = position.start.y;


            //tap start
            if(that.touchState && that.incident.tap.start.length){
                tap = true;
                for(i in that.incident.tap.start)
                    that.incident.tap.start[i].call(that, _event[0]);
            }else if(that.touchState && that.incident.tap.end.length)
                tap = true;

            ////move start

            if(that.touchState && (that.incident.move.start.length || that.incident.move.move.length)){
                move = true;
            };

            if(that.touchState && that.incident.hold.success.length){
                holdStart = true;
                holdLoad = setTimeout(function(){
                    hold = true;
                    holdStart = false;

                    tap = false;
                    if(hold){
                        for(i in that.incident.hold.success){
                            that.incident.hold.success[i].call(that, _event[0]);
                        }

                        for(i in that.incident.tap.error)
                            that.incident.tap.error[i].call(that, _event[0]);
                    }

                }, holdTime);
            };
            //
            //if(stop && typeof stop != 'function'){
            //    stop = function(){
            //        event.preventDefault();
            //        event.stopPropagation();
            //    }
            //}
            //
            //if(stop){
            //    this.addEventListener('touchstart', stop, false);
            //};
        };

        //touch事件移动
        that.eventListener.move = function(event){

            //window.clearTimeout(tapStartLoad);
            //tapStartLoad = null;

            var _event = [event];

            if(event.type === 'touchmove') {
                that.removeEventListener('mousemove', that.eventListener.move);
                _event = event.touches;
            };



            //计算方向
            if(position.start.x > _event[0].clientX)
                direction[0] = 'left';
            else if(position.start.x < _event[0].clientX)
                direction[0] = 'right';
            else
                direction[0] = null;

            if(position.start.y > _event[0].clientY)
                direction[1] = 'top';
            else if(position.start.y < _event[0].clientY)
                direction[1] = 'bottom';
            else
                direction[1] = null;

            _event[0].direction = direction;

            _event[0].startX = position.start.x;
            _event[0].startY = position.start.y;

            //计算tap 偏移量
            var _deviation = false;
            if(
                position.start.x - _event[0].clientX < deviation[1] ||
                position.start.y - _event[0].clientY < deviation[1] ||
                position.start.x - _event[0].clientX > deviation[0] ||
                position.start.y - _event[0].clientY > deviation[0] //||
            //that.incident.move.move.length
            ) {
                _deviation = true;
            }else{
                _deviation = false;
            };


            //tap move
            if(that.touchState && tap && _deviation){
                tap = false;

                if( that.incident.tap.error.length)
                    for(i in that.incident.tap.error)
                        that.incident.tap.error[i].call(that, _event[0]);
            };

            //hold move
            if(holdStart && !hold && _deviation){
                holdStart = false;
                clearTimeout(holdLoad);
                holdLoad = null;

                if(that.incident.hold.error.length){
                    for(i in that.incident.hold.error)
                        that.incident.hold.error[i].call(that, _event[0]);
                };
            };

            //move move
            if(_deviation && move && !moveStart){
                moveStart = true;
                moveError = false;
                position.start.x = _event[0].clientX;
                position.start.y = _event[0].clientY;

                _event[0].startX = position.start.x;
                _event[0].startY = position.start.y;

                for(i in that.incident.move.start)
                    that.incident.move.start[i].call(that, _event[0]);
            };

            _event[0].startX = position.start.x;
            _event[0].startY = position.start.y;

            if(move && moveStart){
                if(that.incident.move.move.length && move){
                    for(i in that.incident.move.move)
                        that.incident.move.move[i].call(that, _event[0]);
                };
            };

            //if(stop)
            //    event.stopPropagation();

        };

        //touch事件结束
        that.eventListener.end = function(event) {


            //if(stop) {
            //    event.preventDefault();
            //    event.stopPropagation();
            //}


            if (event.type === 'touchend')
                that.removeEventListener('mouseup', that.eventListener.end);

            event.startX = position.start.x;
            event.startY = position.start.y;



            //Tap End
            //window.setTimeout(function(){
            //function touchEnd(){
                if (tap){
                    tap = false;

                    var u = navigator.userAgent, app = navigator.appVersion;
                    var isAndroid = u.indexOf('Android') > -1 || u.indexOf('Linux') > -1;

                    var _stop = true;

                    if (that.incident.tap.end.length) {
                        for (i in that.incident.tap.end){
                            var t = that.incident.tap.end[i].call(that, event);
                            if(t === false)
                                _stop = t;
                        };

                        if(_stop === false){
                            event.preventDefault();
                            event.stopPropagation();
                        }
                    };

                    if(that.incident.hold.error.length){
                        for (i in that.incident.hold.error)
                            that.incident.hold.error[i].call(that, event);
                    };
                }

                //Move End
                if(move && moveError){
                    move = false;
                    if (that.incident.move.error.length) {
                        for (i in that.incident.move.error)
                            that.incident.move.error[i].call(that, event);
                    };
                };

                if (move && !moveError) {
                    move = false;
                    moveStart = false;
                    moveError = true;
                    if (that.incident.move.end.length) {
                        for (i in that.incident.move.end)
                            that.incident.move.end[i].call(that, event);
                    };
                };

                //hold end
                if(hold){
                    hold = false;
                    if (that.incident.hold.end.length) {
                        for (i in that.incident.hold.end)
                            that.incident.hold.end[i].call(that, event);
                    };
                };

                if(holdStart){
                    holdStart = false;
                    hold = false;
                    clearTimeout(holdLoad);
                    holdLoad = null;
                };
            //}

            //if(tapStartLoad !== null){
            //    window.setTimeout(function(){
            //        touchEnd();
            //    }, 300);
            //}else{
            //    touchEnd();
            //}

            //}, 200);

        };

        that.eventListener.cancel = function(event){

            for(i in that.incident.move.end)
                that.incident.move.end[i].call(that, event);

            for(i in that.incident.tap.error)
                that.incident.tap.error[i].call(that, event);

            event.preventDefault();
            event.stopPropagation();
        };

        ////绑定 鼠标/手指 事件




        //if(stop){
        //    stop = function(event){
        //        event.preventDefault();
        //        event.stopPropagation();
        //    };
        //
        //    that.addEventListener('mousedown', stop, false);
        //    that.addEventListener('touchstart', stop, false);
        //}

        if(isTouch){
            that.addEventListener('touchstart', that.eventListener.start, false);
            that.addEventListener('touchmove', that.eventListener.move, false);
            that.addEventListener('touchend', that.eventListener.end, false);
            that.addEventListener('touchcancel', that.eventListener.cancel, false);

        }else{
            that.addEventListener('mousedown', that.eventListener.start, false);
            that.addEventListener('mousemove', that.eventListener.move, false);
            that.addEventListener('mouseup', that.eventListener.end, false);
        };

        return this;

    };

    //untouch
    HTMLElement.prototype.untouch = function(type, speed, fn){

        var _default = {
                tap: 'end',
                move: 'move',
                hold: 'success'
            }
            ,   defaultNull = true;


        if(!this.incident)
            return this;

        if(!speed && !fn){
            for(i in this.incident[type]){
                this.incident[type][i] = new Array();
            };
        }else if(speed && !fn){
            this.incident[type][speed] = [];
        }else{
            if(typeof speed === 'function'){
                fn = speed;
                speed = _default[type];
            };
            for(i in this.incident[type][speed]){
                if(this.incident[type][speed][i] === fn){
                    this.incident[type][speed].splice(i, 1);
                }
            };
        };

        for(i in this.incident){
            for(j in this.incident[i]){
                if(this.incident[i][j].length){
                    defaultNull = false;
                    break;
                };
            };

            if(!defaultNull)
                break;
        };

        if(defaultNull){

            this.removeEventListener('mousedown', this.eventListener.start);
            this.removeEventListener('touchstart', this.eventListener.start);

            this.removeEventListener('mousemove', this.eventListener.move);
            this.removeEventListener('touchmove', this.eventListener.move);
            this.removeEventListener('mouseup', this.eventListener.end);
            this.removeEventListener('touchend', this.eventListener.end);
        };

        return this;

    };

    //touch untouch for Jquery
    try{

        $.fn.extend({
            touch: function(options, deviation, stop){
                $.each(this, function(i, d){
                    d.touch(options, deviation, stop);
                });
            },
            untouch: function(type, speed, fn){
                $.each(this, function(i, d){
                    d.untouch(type, speed, fn);
                });
            }
        });

    }catch(err){
        console.log(err);
    }

})();