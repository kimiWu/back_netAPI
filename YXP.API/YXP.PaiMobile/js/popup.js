//扩展插件
$.extend({
	dialog:{
		bgHtml:'<div id="zhezhao" style="position:fixed;top:0px;"></div>',

		alertHtml:'<div id="alertdiv" class="anim-show" style="display:block;"><div class="alertdiv-txt"><p>{TEXT}</p></div><div class="alertdiv-btn"><a onclick="$.dialog.clickOk();" href="javascript:void(0)">确定</a></div></div>',

		confirmHtml:'<div id="alertdiv" class="anim-show" style="display:block;"><div class="alertdiv-txt"><p>{TEXT}</p></div><div class="alertdiv-btn"><a style="width:50%;" onclick="$.dialog.clickOk();" href="javascript:void(0)">确定</a><a style="width:50%;border-left:1px solid #a1a1a1;" onclick="$.dialog.clickCancle();" href="javascript:void(0)">取消</a></div></div>',

		noticeHtml:'<div id="alertdiv"  class="anim-show" style="display:block;"><div class="alertdiv-txt" style="border-bottom:0px;"><p>{TEXT}</p></div></div>',


		// 确定处理
		clickOkHandle:function(){},

		// 取消处理
		clickCancleHandle:function(){},

		// 弹出提示框
		showAlert:function(text,okCallback){
			this.init();
			this.showBg();
			if(okCallback){
				this.clickOkHandle = okCallback;
			}
			var html = this.alertHtml.replace('{TEXT}',text);
			$('body').append(html);
		},


		// 弹出提示框
		showNotice:function(text,redirectCallback){
			this.init();
			this.showBg();
			var html = this.noticeHtml.replace('{TEXT}',text);
			$('body').append(html);
			setTimeout(function(){
				$.dialog.close();
				if(redirectCallback){ redirectCallback();}
			},1000);

		},

		// 初始化函数
		init:function(){
			$('#zhezhao').hide();
			$('#alertdiv').remove();
			this.clickCancleHandle = this.clickOkHandle = function(){};
		},

		// 弹出询问框
		showConfirm:function(text,okCallback,cancleCallback){
			this.init();
			this.showBg();
			if(okCallback){
				this.clickOkHandle = okCallback;
			}
			if(cancleCallback){
				this.clickCancleHandle = cancleCallback;
			}
			var html = this.confirmHtml.replace('{TEXT}',text);
			$('body').append(html);
		},

		// 显示背景层
		showBg:function(text){
			if($('body').find('#zhezhao').length < 1){
				$('body').append(this.bgHtml);
			}
			$('#zhezhao').css('height',($(window).height()+'px')).fadeIn();
			$('body').css('overflow','hidden');
		},

		// 卸载弹窗
		close:function(){
			$('#alertdiv').fadeOut(10,function(){
				$('#zhezhao').hide();
				$('#alertdiv').remove();
				$('body').css('overflow','scroll');
			});
		},

		// 点击取消捕获
		clickCancle:function(){
			this.close();
			this.clickCancleHandle();
		},

		// 点击确定捕获
		clickOk:function(){
			this.close();
			this.clickOkHandle();
		},
	},

	timer:{
		timer:null,
		loopHandle:function(){},
		endHandle:function(){},
		time:0,

		setTimer:function(time,loop_calback,end_callback){

			this.time = time;

			if(loop_calback){
				this.loopHandle = loop_calback;
			}

			if(end_callback){
				this.endHandle = end_callback;
			}

			this.timer = window.setInterval(function(){
				$.timer.loopEvent();
			},1000);

		},
		loopEvent:function(){
			if(--this.time <= 0){
				this.endEvent();
				return;
			}
			this.loopHandle(this.time);
		},
		endEvent:function(){
			clearInterval(this.timer);
			this.endHandle();
		},
	},

	ajaxSubmit0:function(target,beforeSubmit,afterSubmit){
		$.ajax({
			context:target,
			url:target.attr('action'),
			type:target.attr('method'),
			data:target.serialize(),
			beforeSend:beforeSubmit,
			success:afterSubmit
		});
		return false;
	}
});