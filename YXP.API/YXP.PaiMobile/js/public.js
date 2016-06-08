  ; (function (doc, win) {
 var docEl = doc.documentElement,
     resizeEvt = 'orientationchange' in window ? 'orientationchange' : 'resize',
     recalc = function () {
         var clientWidth = docEl.clientWidth;
         if (!clientWidth) return;
         docEl.style.fontSize = 20 * (clientWidth / 375) + 'px';
     };
 if (!doc.addEventListener) return;
 win.addEventListener(resizeEvt, recalc, false);
 doc.addEventListener('DOMContentLoaded', recalc, false);
})(document, window);


var publics = function(element){
    element = $(element);
    //初始化所有的连接
    $.each(element.find('a'), function(i, a){
        var _href = $(a).attr('href');
        if(_href){
            $(a).attr('href', 'javascript:void(0);');
            $(a).touch({
                tap: {
                    start: function(){
                        $(this).addClass('onTap');
                    },
                    end: function(){
                        $(this).removeClass('onTap');
                        window.location.href = _href;
                    },
                    error: function(){
                        $(this).removeClass('onTap');
                    }
                }
            }, 5 ,true);
        }
    });

    //初始化所有包含data-url的跳转
    element.find('*[data-url]').touch({
        tap: {
            start: function(){
                $(this).addClass('onTap');
            },
            end: function(){
                $(this).removeClass('onTap');
                var _url = $(this).attr('data-url');
                if(_url && _url != 'false')
                    window.location.href = _url;
            },
            error: function(){
                $(this).removeClass('onTap');
            }
        }
    }, 5, true);

    var _url = $(element).attr('data-url');

    if(_url && _url != 'false'){
        element.touch({
            tap: {
                start: function(){
                    $(this).addClass('onTap');
                },
                end: function(){
                    $(this).removeClass('onTap');
                    window.location.href = _url;
                },
                error: function(){
                    $(this).removeClass('onTap');
                }
            }
        }, 5, true);
    }

    element.find("header i").touch({
        tap: function(){
            $('input, textarea').blur();
            var _class = $(this).attr('class')
            ,   _index = false
            ,   _url = $(this).attr('data-url');

            if( _url != 'false'){
                if(_class && (_class.indexOf('button') != -1 || _class.indexOf('right') != -1))
                    _index = true;

                if(!_index){
                    if(!_url){
                        window.history.go(-1);
                    }else{
                        window.location.href = _url;
                    };
                };
            };
        }
    }, 5, true);

    //初始化所有的tag
    element.find('.switch nav li').touch({
        tap: function(){
            var _parent = $(this).parents('.switch')
            ,   _index = $(this).index();

            _parent.find('nav li.on').removeClass('on');
            _parent.find('.collection > li.on').removeClass('on');
            $(this).addClass('on');
            _parent.find('.collection > li').eq(_index).addClass('on');
            //$(window).scrollTop(0);
        }
    }, 5, true);

    //初始化 search_button 打开搜索面板
    element.find('.search_button').touch({
        tap: {
            start: function(){
                $(this).addClass('onTap');
            },
            end:function(){
                $(this).removeClass('onTap');
                $('#search').addClass('on');
            },
            error: function(){
                $(this).removeClass('onTap');
            }
        }
    }, 5, true);

    //搜索面板点击空白关闭
    element.find('#search .close').touch({
        tap: function(){
            $('#search').removeClass('on');
        }
    }, 5, true);

    (function(){
        $.each($('.float'), function(i, f){
            var after = $(document.createElement('div')).addClass('after').appendTo('.float .table-cell');
            after.touch({
                tap: function(){
                    var that = this;
                    window.setTimeout(function(){
                        $(that).parents('.float').eq(0).css('display','none');
                    }, 300);
                }
            }, 5, true);
        });
    })();

    //浮动窗口
    element.find('*[open-window]').touch({
        tap: function(){
            var that = this;
            //window.setTimeout(function(){
            var _window = $(that).attr('open-window');
            $(_window).css('display','block');
            //},300);
            window.setTimeout(function(){
                $(_window).find('*[close-window]').touch({
                    tap: function(){
                        $(that).untouch('tap');
                        var that = this;
                        window.setTimeout(function(){
                            var _window = $(that).attr('close-window');
                            $(_window).css('display','none');
                        }, 300);
                    }
                }, 5, true);
            }, 500);
        }
    }, 5, true);


    element.find('button').touch({
        tap: {
            start: function(){
                $(this).addClass('onTap');
            },
            end: function(){
                $(this).removeClass('onTap');
            },
            error: function(){
                $(this).removeClass('onTap');
            }
        }
    });

    //element.find('*[close-window]').touch({
    //    tap: function(){
    //        var that = this;
    //        window.setTimeout(function(){
    //            var _window = $(that).attr('close-window');
    //            $(_window).css('display','none');
    //        }, 300);
    //    }
    //}, 5, true);

    //element.find('input').click(function(){return false;}).touch({tap: function(){$(this).focus();}});

    element.find('#btn_addPVAccount').touch({tap: function(){return false}});
    element.find(".div_Item").touch({
        tap: function () {
            return false;
        }
    });

    var dzc_div = element.find('#dzc_div');
    if(dzc_div.length){
        dzc_div.parent().css('margin-top','0');
    }

    $.each(element.find('input[type="text"], textarea'), function(i, text){
        var _size = eval($(text).attr('data-size'));
        if(typeof _size == 'number'){
            $(text).keyup(function(){
                var curLength=$(text).val().length;
                if(curLength >= _size){
                    var num=$(text).val().substr(0,_size);
                    $(text).val(num);
                };
            });
        }
    });

    //checkbox样式
    var _checkbox = {}
        ,   creationSimulationRadio = function(radio){
            this.radio = radio;
            this.name = radio.name;
            this.state = $(radio).prop('checked');
            this.disabled = $(radio).attr('disabled');
            this.changeArray = new Array();
            this.radio.simulation = this;
            $(this.radio).data('simulation', this);
            this.init();
        };

    creationSimulationRadio.prototype = {
        init: function(){
            var simulationRadio = this.simulationRadio = $(document.createElement('i')).addClass('radio');

            if(this.disabled){
                simulationRadio.addClass('disabled');
            }
            else if(this.state)
                simulationRadio.addClass('on');
            this.replace();
        },
        replace: function(){
            $(this.radio).css('display','none').before($(this.simulationRadio)); //
            this.incident();
        },
        incident: function(){
            var that = this;
            $(this.simulationRadio).touch({
                tap: function(){
                    if(!that.disabled){
                        $('input').blur();
                        if(!that.state){
                            that.stateChange(true);
                        };
                    }
                }
            }, 5, true);
        },
        arrayChange: function(callback){
            $.each(_checkbox[this.name], function(i, c){
                c.stateChange(false);
            });
            callback();

            $.each(_checkbox[this.name], function(i, c){
                $.each(c.changeArray, function(i, a){
                    a.call(c.radio);
                });
            });
        },
        stateChange: function(state){
            var that = this;

            function change(){
                //var _class = state ? 'radio on' : 'radio';
                var _class = that.disabled ? 'radio disabled' : (state ? 'radio on' : 'radio');

                $(that.radio).prop('checked', state);
                $(that.simulationRadio).attr('class', _class);

                that.state = state;
            };

            if(state)
                this.arrayChange(change);
            else
                change();
        },
        change: function(callback){
            this.changeArray.push(callback);
        }
    };

    $.each(element.find('input[type="radio"]'), function(i, c){
        var name = $(c).attr('name');

        var _simulationRadio = new creationSimulationRadio(c);

        //判断当前name的radio是否出现过，如果第一次出现，就创建一个新的数组将当前radio放入，否则将当前radio放入当前name的数组中
        if(!(_checkbox[name] instanceof Array)){
            _checkbox[name] = new Array(_simulationRadio);
        }else{
            _checkbox[name].push(_simulationRadio);
        };

        c.radioChange = function(state){
            if(!$(c).attr('disabled'))
                _simulationRadio.stateChange(state);
        };

        $(c).data('radioChange', function(state){
            _simulationRadio.stateChange(state);
        });

        $(c).change(function(){
            this.radioChange($(this).prop('checked'));
        });
    });


    var _checked = {}
        ,   creationSimulationChecked = function(checkbox){
            this.checkbox = checkbox;
            this.name = checkbox.name;
            this.state = $(checkbox).prop('checked');
            this.init();
        };

    creationSimulationChecked.prototype = {
        init: function(){
            var simulationCheckebox = this.simulationCheckbox = $(document.createElement('i')).addClass('radio');
            if(this.state)
                simulationCheckebox.addClass('on');
            this.replace();
        },
        replace: function(){
            $(this.checkbox).css('display','none').before($(this.simulationCheckbox));
            this.change();
        },
        change: function(){
            var that = this;
            this.simulationCheckbox.touch({
                tap: function(){
                    if($(that.checkbox).prop('checked')){
                        $(that.checkbox).prop('checked', false);
                        //that.checkbox.removeAttribute('checked');
                    }else{
                        $(that.checkbox).prop('checked', true);
                        //that.checkbox.setAttribute('checked', 'checked');
                    };
                    var start = $(that.checkbox).prop('checked');

                    if(start)
                        $(that.simulationCheckbox).addClass('on');
                    else
                        $(that.simulationCheckbox).removeClass('on');

                }
            });

            $()

        }
    };

    $.each(element.find('input[type="checkbox"]'), function(i, c){
        var name = $(c).attr('name');
        var _simulationRadio = new creationSimulationChecked(c);
    });


    if($('#returnTop').length){
        $('#returnTop').css({
            display: 'none',
            opacity: 0
        });
        $('#returnTop').touch({
            tap: {
                start: function(){
                    $(this).addClass('onTap');
                },
                end: function(){
                    $(this).removeClass('onTap');
                    $('html,body').animate({scrollTop: '0px'}, 300);
                },
                error: function(){
                    $(this).removeClass('onTap');
                }
            }
        }, 5, true);

        var _top = $(window).scrollTop();
        if(_top < 100){
            $('#returnTop').css({
                display:'none',
                opacity:0
            });
        }else{
            $('#returnTop').css({
                display:'block'
            });
        };

        $(window).scroll(function(){
            var _top = $(window).scrollTop();
            if(_top <= 100){
                $('#returnTop').stop().animate({opacity: 0}, 200, function(){
                    $(this).css('display', 'none');
                });
            }else {
                $('#returnTop').css('display', 'block').stop().animate({opacity: 1}, 200);
            }
        });
    };


    //重新发拍+线
    //$.each(element.find('button.block'), function(i, button){
    //    if($(button).html() == '重新发拍'){
            //$(button).parents('tr').addClass('partition-top');
        //}
    //});

    //保证金header
    var _html = element.find('header').html();
    if(_html && _html.indexOf('保证金')!= -1 && _html.indexOf('保证金使用记录') == -1){
        element.find('ul').eq(1).addClass('list');
    };

};



$(function(){
    publics($('body'));

    var _header = $('header').css('position') == 'fixed';
    var u = navigator.userAgent, app = navigator.appVersion
    ,   isiOS = !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/);

    if(_header && isiOS){
        $('input, select, textarea').focus(function(){
            $('header').css('position', 'absolute');
        }).blur(function(){
            $('header').css('position', 'fixed');
        });
    }

});