
var finalTvaId = 0;
var dialogTime = 1000;
var ws;
function connectSocketServer(publishId, currTvaId, sessionId) {
    //创建一个新的websocket连接
    //var port = 'ws://supersocket3.youxinpai.com:8001/socket';

    //var port = 'ws://192.168.200.34:8003/soket';
    var port = $("#socketUrl").val();
    var support = "MozWebSocket" in window ? 'MozWebSocket' : ("WebSocket" in window ? 'WebSocket' : null);

    ws = new window[support](port);
    //ws = new ReconnectingWebSocket(port);

    // when data is comming from the server, this metod is called
    //当有数据从服务器传过来时，调用此方法
    ws.onmessage = function (evt) {

        //更新价格
        var obj;
        try {
            obj = JSON.parse(evt.data);
        } catch (error) {
            console.log(evt.data);
            return false;
        }
        if (obj.result == undefined || obj.result != 5)
        { return false; }
        if (parseFloat(obj.publishID) != parseFloat($("#auctionId").val())) { console.log("error:" + obj.publishID + "  " + $("#auctionId").val()); return false; }
        DoSocketMessage(obj);
    }

    // when the connection is established, this method is called
    //当连接建立成功时，调用此方法
    ws.onopen = function () {
        //messageBoard.append('* Connection open<br/>');
        ws.send("Login&" + sessionId);
        ws.send("AuctionDetail&" + publishId + "|" + currTvaId);
    };

    // when the connection is closed, this method is called
    //当连接关闭时，调用此方法
    ws.onclose = function () {
        //messageBoard.append('* Connection closed<br/>');
        //alert("close");
        setTimeout(function () {
            OpenSocket();
        }, 2000);
        //ws.send("LeaveAuctionDetail&" + publishId);
    }
}
function DoSocketMessage(obj) {
    finalTvaId = (obj.finalTvaId == undefined ? obj.dealTvaid : obj.finalTvaId);

    var _returnType = obj.returnType;

    var socketObj = obj;
    console.log("跟踪01：" + obj.uType + "..." + obj.returnType);
    if (obj.uType == "update") {  //出价更新价格
        //需要判断是否超过投标价

        $("#beep").get(0).play();
        $(".stashow").hide();

        $("#currentPrice").html(obj.currPrice);  //更新当前价
        $("#jyPrice").html("+" + obj.buyerTradeFee);   //更新交易费
        $("#jfPrice").html("+" + obj.buyerAgentFee);   //更新交付费
        $("#hsPrice").html(obj.buyerTotalFee);   //更新合手价
        var time = $(".timer").html();
        if (parseInt(obj.restTime) > 10) {
            if (parseInt(time) > parseInt(obj.restTime)) {
                $(".timer").html(obj.restTime);  //更新时间
            }
        } else {
            $(".timer").html(obj.restTime);  //更新时间
        }


        if (finalTvaId == currTvaId) {
            $("#_myPrice").val(obj.currPrice);
        }
        console.log("跟踪011：" + obj.isOverHighTenderPrice);
        if (obj.isOverHighTenderPrice == 1) {  //是否超过投标价
            $(".bid-status .s-2").show();

        }
        console.log("跟踪012：" + obj.isOverReservationPrice);
        if (obj.isOverReservationPrice == 1) {  //是否超过保留价
            $(".bid-status .s-3").show();
            $("#isOverRePrice").val("1");
        }
        var _highTenderPrice = parseFloat($("#highTenderPrice").val());

        if (parseFloat(obj.currPrice) < _highTenderPrice) {
            if (_highTenderPrice <= parseFloat($("#_myTenderPrice").val())) {
                $("#y_high").show();
            } else {
                $("#y_high").hide();
            }
        } else {
            if (finalTvaId == currTvaId && parseFloat(obj.currPrice) > _highTenderPrice) {
                $("#y_high").show();
            } else {
                $("#y_high").hide();
            }
        }

        //if ((finalTvaId == currTvaId) && (parseFloat(obj.currPrice) > _highTenderPrice || (parseFloat(obj.currPrice) <= _highTenderPrice && parseFloat($("#_myTenderPrice").val()) >= _highTenderPrice))) {
        //    $("#y_high").show();
        //}
        if (parseFloat($("#_myTenderPrice").val()) > 0 && (parseFloat(obj.currPrice) <= _highTenderPrice && parseFloat($("#_myTenderPrice").val()) >= _highTenderPrice)) {
            $("#y_high").show();
        }
    }
    else if (obj.uType == "check") {

        //$(".timer").html(obj.restTime);  //更新时间
        var time = $(".timer").html();
        if (parseInt(obj.restTime) > 10) {
            if (parseInt(time) > parseInt(obj.restTime)) {
                $(".timer").html(obj.restTime);  //更新时间
            }
        } else {
            $(".timer").html(obj.restTime);  //更新时间
        }

        $(".bid-status .s-3").show();
        $("#isOverRePrice").val("1");

    }
    else if (obj.uType == "add") {  //投标变竞价

        //刷新隐藏值
        try {
            if (parseFloat(obj.highTenderPrice) > 0) {
                $("#highTenderPrice").val(obj.highTenderPrice);
            }

            if (parseFloat($("#_myTenderPrice").val()) >= parseFloat(obj.highTenderPrice)) {

                $("#isHighTenPrice").val("1");
                $("#ishight").val("1");
                var isNoReserve = $("#isNoReserve").val();
                if (isNoReserve == "1") {
                    $(".bid-pri-lef #currentPrice").html(parseFloat($("#_myTenderPrice").val()).toFixed(2));
                }
            }
            var html = "";
            if ($("#isNoReserve").val() == "1") {
                if (parseFloat(obj.highTenderPrice) > 0) {
                    html = "从<span class=\"c-red\">报价最高价 " + obj.highTenderPrice + "</span> 万开始加价！";
                } else {
                    html = "从起步价 <span class=\"c-red\">0万</span> 开始加价！";
                }
            } else {
                html = "从起步价 <span class=\"c-red\">" + $("#startPrice").val() + "万</span> 开始加价！";
            }
            $("#hidShowState").val(html);
        } catch (ex) { alert("error:" + ex); }
        ChangePage(socketObj);
    }
    else if (obj.uType == "deal" && obj.returnType == 1) {   //竞价结束->等待成交->5s跳转下一辆车（正在竞价）
        console.log("跟踪02：");
        ChangePage(socketObj);  //等待成交
        AutoGoNext();
    }
    else if ((obj.uType == "sale" && (obj.returnType == 3 || obj.returnType == 4)) || (obj.uType == "deal" && (obj.returnType == 3 || obj.returnType == 4))) {  //成交->成交页面->5s跳转下一辆车（正在竞价）
        console.log("跟踪05：");
        ChangePage(socketObj);  //成交
        AutoGoNext();
    }
    else if (obj.uType == "stop" || (obj.uType == "deal" && obj.returnType == 2)) {   //流拍->流拍页面->5s跳转下一辆车（正在竞价）
        ChangePage(socketObj);  //流拍
        AutoGoNext();
    }

}

function GetEndStatus() {//0秒后手动翻牌
    if (endInterval == undefined) {
        var auctionId = $("#auctionId").val();
        if (parseFloat(auctionId) > 0) {
            endInterval = setInterval(function () {
                if (!isPostBack) {
                    isPostBack = true;
                    $.ajax({
                        url: "/Detail/GetEndStatus",
                        type: "post",
                        dataType: "json",
                        data: { publishid: auctionId },
                        success: function (data) {
                            isPostBack = false;
                            var obj = JSON.parse(data);
                            if (obj.result == 0) {
                                var item = JSON.parse(obj.data);
                                if (item.uType == "add")
                                { return false; }
                                DoSocketMessage(item);
                                clearInterval(endInterval);
                            } else {

                                yx.tips("请求失败", true, dialogTime);
                            }
                        },
                        error: function () {
                            isPostBack = false;
                            //window.location.reload();
                            //yx.tips("网络异常", true, dialogTime);
                        }

                    })
                } else {
                    isPostBack = false;
                }
            }, 1000);
        }
    }
}
var publishId = $("#auctionId").val();
var currTvaId = $("#currTvaId").val();
var sessionId = $("#sessionId").val();
var nextPublishId = $("#nextPublishId").val();
function OpenSocket() { 
    connectSocketServer(publishId, currTvaId, sessionId);
}
var xt;
$(function () {
    //心跳检测
    if (xt == undefined) {
        xt = setInterval(function () {
            if (!ws) {
                //console.log("reopen");
                OpenSocket();
            } else {
                try {
                    ws.send(" ");
                } catch (ex) {
                    //alert("reopen" + ws);
                    OpenSocket();
                }
            }
        }, 5000);
    }
})

function checkMoneyFormat(val) {
    if (val == 0) return false;
    var reg = /^\+?(:?(:?\d+\.\d+)|(:?\d+))$/;
    var isMoneyFormatRight = reg.test(val);
    return isMoneyFormatRight;
}



function ChangePage(obj) {
    if (obj.publishID != undefined && (obj.returnType != undefined || obj.uType == "add") && obj.uType != undefined) {
        $.ajax({
            url: "/Detail/GetPartView",
            type: "post",
            data: { type: obj.uType, auctionId: obj.publishID, state: (obj.returnType == undefined ? 0 : obj.returnType) },
            success: function (data) {
                console.log("跟踪03：" + obj.uType + "..." + obj.returnType);
                $("#bidArea").html(data);
                if (obj.uType == "stop" || (obj.uType == "deal" && obj.returnType == 2)) {
                    SetPass(obj);
                }
                else if ((obj.uType == "sale" && (obj.returnType == 3 || obj.returnType == 4)) || (obj.uType == "deal" && (obj.returnType == 3 || obj.returnType == 4))) {
                    SetSale(obj);
                }
                else if (obj.uType == "deal" && obj.returnType == 1) {
                    SetWaitSale(obj);
                }
            },
            error: function () {
                alert("网络异常");
            }
        })
    }
}
function SetPass(obj) {
    if (parseFloat(obj.myHighPrice) > 0) {  //判断是否报价或者出价
        $("#pass_01").hide();
        if (obj.highPriceType == 2) {  //外迁
            $(".tips-txt .sp1").html("外迁");
        }
        else {
            $(".tips-txt .sp1").html("本市");
        }
        if (obj.highPriceSource == 2) {  //竞价
            $(".tips-txt .sp3").html("(加价)");
        }
        else {
            $(".tips-txt .sp3").html("(报价)");
        }
        $(".tips-txt .sp5").html(obj.myHighPrice);

        $("#pass_02").show();


    }
    else {
        $("#pass_01").show();
        $("#pass_02").hide();
    }
}
function SetSale(obj) {
    console.log("跟踪06：");
    if (parseFloat(obj.myHighPrice) > 0) {  //判断是否报价或者出价
        if (obj.returnType == 3) {
            $("#sale_01").hide();
            $("#sale_02").hide();
            $("#sale_03 .bid-pri-lef #_currPrice").html(obj.highPrice);//当前价
            $("#sale_03 .bid-pri-lef #_jyPrice").html(parseFloat(parseFloat(obj.tradeServiceFee) / 10000).toFixed(2));//交易费
            $("#sale_03 .bid-pri-lef #_jfPrice").html(parseFloat(parseFloat(obj.serviceDeliveryFee) / 10000).toFixed(2));//交付费
            $("#sale_03 .bid-pri-lef #_hsPrice").html(obj.buyerTotalFee);//合手价
            $("#sale_03").show();
        }
        else {
            $("#sale_01").hide();
            if (obj.highPriceType == 2) {  //外迁
                $(".tips-txt .sp1").html("外迁");
            }
            else {
                $(".tips-txt .sp1").html("本市");
            }
            if (obj.highPriceSource == 2) {  //竞价
                $(".tips-txt .sp3").html("(加价)");
            }
            else {
                $(".tips-txt .sp3").html("(报价)");
            }
            $(".tips-txt .sp5").html(obj.myHighPrice);
            $("#sale_02").show();
            $("#sale_03").hide();
        }
    }
    else {
        $("#sale_01").show();
        $("#sale_02").hide();
        $("#sale_03").hide();
    }
}
function SetWaitSale(obj) {
    console.log("跟踪04：");
    if (parseFloat(obj.myHighPrice) > 0) {  //判断是否报价或者出价
        if (obj.isHighPrice == 1) {  //判断是否是最高价
            $("#waitSale_01").hide();
            $("#waitSale_02").hide();
            $("#waitSale_03 .bid-pri-lef #_currPrice").html(obj.highPrice);//当前价
            $("#waitSale_03 .bid-pri-lef #_jyPrice").html(parseFloat(parseFloat(obj.tradeServiceFee) / 10000).toFixed(2));//交易费
            $("#waitSale_03 .bid-pri-lef #_jfPrice").html(parseFloat(parseFloat(obj.serviceDeliveryFee) / 10000).toFixed(2));//交付费
            $("#waitSale_03 .bid-pri-lef #_hsPrice").html(obj.buyerTotalFee);//合手价
            $("#waitSale_03").show();
        }
        else {
            $("#waitSale_01").hide();
            if (obj.highPriceType == 2) {  //外迁
                $(".tips-txt .sp1").html("外迁");
            }
            else {
                $(".tips-txt .sp1").html("本市");
            }
            if (obj.highPriceSource == 2) {  //竞价
                $(".tips-txt .sp3").html("(加价)");
            }
            else {
                $(".tips-txt .sp3").html("(报价)");
            }
            $(".tips-txt .sp5").html(obj.myHighPrice);
            $("#waitSale_02").show();
            $("#waitSale_03").hide();
        }
    }
    else {
        $("#waitSale_01").show();
        $("#waitSale_02").hide();
        $("#waitSale_03").hide();
    }

}
var timeint;
function AutoGoNext() {
    var nextPublishId = $("#nextPublishId").val();
    if (nextPublishId != "0") {
        var tt = 5;
        if (timeint == undefined) {
            timeint = setInterval(function () {
                if (tt <= 0) {
                    clearInterval(timeint);
                    //ws.onclose();
                    window.location.href = "/detail/index?auctionId=" + nextPublishId + "&carSourceID=0";
                } else {
                    tt -= 1;
                }
            }, 1000);
        }
    }
}
function click() {
    window.history.go(-1);
}
function bidTip(str) {
    $(".tips-info2").html(str);
    $(".tips-info2").show();
    setTimeout(function () {
        $(".tips-info2").hide();
    }, 1000);
}
$(function () {
    OpenSocket();
    $.each($('#slide .f'), function (i, box) {
        var _id = $(box).attr('id');
        $(box).find('ul').width($(box).find('li').length * 100 + '%');
        $(box).find('ul li').width(100 / $(box).find('li').length + '%');
        box.scroll = new IScroll('#' + _id, {
            scrollX: true,
            scrollY: false,
            momentum: false,
            snap: true,
            snapSpeed: 400,
            keyBindings: true
        })
    });
    $.each($('mark'), function (i, mark) {
        var _left = parseFloat($(mark).attr('left')) * 100 + '%';
        var _top = parseFloat($(mark).attr('top')) * 100 + '%';
        var _direction = $(mark).attr('direction');

        $(mark)
                .addClass(_direction)
                .css({
                    left: _left,
                    top: _top
                });

    });
    $('mark').touch({
        tap: function () {
            $(this).parents('li').find('mark').css('z-index', 999);
            $(this).css('z-index', 1000);
        }
    });
    $('#main button').touch({
        tap: function () {
            var _name = $(this).attr('name');
            var _num = $(this).find('span').attr('data-num');

            if (_num > 0) {
                $('#slide-' + _name).css({
                    MozTransform: 'translate(0, 0)',
                    WebkitTransform: 'translate(0, 0)',
                    OTransform: 'translate(0, 0)',
                    transform: 'translate(0, 0)',
                    MozTransition: '-moz-transform 0.2s ease-in',
                    WebkitTransition: '-webkit-transform 0.2s ease-in',
                    OTransition: '-o-transform 0.2s ease-in',
                    transition: 'transform 0.2s ease-in'
                });
            }
        }
    });

    $('#slide .f button').touch({
        tap: function () {
            var _name = $(this).attr('name');
            var _transform = 'translate';
            if (_name == 'left')
                _transform += '(-100%, 0)';
            else if (_name == 'right')
                _transform += '(100%, 0)';
            else if (_name == 'top')
                _transform += '(0, -100%)';

            $('#slide-' + _name).css({
                MozTransform: _transform,
                WebkitTransform: _transform,
                OTransform: _transform,
                transform: _transform,
                MozTransition: '-moz-transform 0.2s ease-in',
                WebkitTransition: '-webkit-transform 0.2s ease-in',
                OTransition: '-o-transform 0.2s ease-in',
                transition: 'transform 0.2s ease-in'
            });
        }
    });


})
