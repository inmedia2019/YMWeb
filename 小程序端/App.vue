<script>
	export default {
		onLaunch: function(options) {
			uni.setStorage({
				key: 'options',
				data: options,
				success() {
					
				}
			});
			
			const updateManager = uni.getUpdateManager();
			// 检查小程序是否有新版本发布
			updateManager.onCheckForUpdate(function (res) {
			  // 请求完新版本信息的回调
			});
			
			// 小程序有新版本，则静默下载新版本，做好更新准备
			updateManager.onUpdateReady(function (res) {
				
			  uni.showModal({
				title: '更新提示',
				content: '「苗懂了」小程序更新升级！',
				showCancel:false,
				success(res) {
				  if (res.confirm) {
					// 新的版本已经下载好，调用 applyUpdate 应用新版本并重启
					updateManager.applyUpdate();
				  }
				}
			  });
			
			});
			
			updateManager.onUpdateFailed(function (res) {
			  
			  // 新的版本下载失败
			  uni.showModal({
				title: '已经有新版本了哟~',
				content: '新版本已经上线啦~，请您删除当前小程序，重新搜索打开哟~'
			  });
			  
			});
		},
		onShow: function(options) {
			uni.setStorage({
				key: 'options',
				data: options,
				success() {
					
				}
			});
		},
		onHide: function() {
			
		}
	}
</script>

<style>
	@import url("common/animate.min.css");
	@import url("common/iconfont.css");
	/*每个页面公共css */
	page{ font-size: 14px; line-height: 1.5; color: rgba(51, 51, 51, 1);background: #F3F6F8; }
	view{-webkit-tap-highlight-color: rgba(0, 0, 0, 0);}
	
	
	/* .textjustify{ text-align: justify;} */
	
	.fl{ float: left;  }
	.fr{ float: right;}
	
	.w5{ width: 5px; }
	.w10{ width: 10px; }
	.w15{ width: 15px; }
	.w20{ width: 20px; }
	
	.h1{ height: 1px;}
	.h2{ height: 2px;}
	.h3{ height: 3px;}
	.h5{ height: 5px;}
	.h10{ height: 10px;}
	.h15{ height: 15px;}
	.h18{ height: 18px;}
	.h20{ height: 20px;}
	.h25{ height: 25px;}
	.h30{ height: 30px;}
	.h35{ height: 35px;}
	.h40{ height: 40px;}
	.h45{ height: 45px;}
	.h50{ height: 50px;}
	.h80{ height: 100px; }
	.h100{ height: 100%; }
	
	.f8{ font-size: 8px; }
	.f10{ font-size: 10px; }
	.f12{ font-size: 12px; }
	.f13{ font-size: 13px; }
	.f14{ font-size: 14px; }
	.f15{ font-size: 15px; }
	.f16{ font-size: 16px; }
	.f17{ font-size: 17px; }
	.f18{ font-size: 18px; }
	.f20{ font-size: 20px; }
	.f22{ font-size: 22px; }
	.f25{ font-size: 25px; }
	.fb{ font-weight: bold; }
	
	.c000{ color: #000; }
	.cfff{ color: #fff; }
	.c666{ color: #666; }
	.c333{ color: #333; }
	.c999{ color: #999999; }
	.c4A4A4A{ color: #4A4A4A; }
	.c6b6b6b{ color: #6b6b6b; }
	.c979797{ color: #979797; }
	.c00857C{ color: #00857C; }
	.c6D7278{ color: #6D7278; }
	.c535353{ color: #535353; }
	.c9AA8B6{ color: #9AA8B6; }
	.c8E8E8E{ color: #8E8E8E; }
	.c9B9B9B{ color: #9B9B9B; }
	.c252525{ color: #252525; }
	.c768196{ color: #768196; }
	.c6ECEB2{ color: #6ECEB2; }
	
	.b000{ background: #000; }
	.bfff{ background: #fff; }
	.bf7f7f7{ background: #fff; }
	.bededed{ background: #ededed; }
	.b00857C{ background: #00857C; }
	.bb1b1b1{ background: #b1b1b1; }
	.b9B9B9B{ background: #9B9B9B; }
	.bDEDDDE{ background: #DEDDDE; }
	.b6ECEB2{ background: #6ECEB2; }
	
	.op6{ opacity: 0.6; }
	.op7{ opacity: 0.7; }
	.op2{ opacity: 0.2; }
	
	.w100{ width: 100%; }
	.whtl{ width: 100%; height: 100%; top: 0px; left: 0px; }
	
	.pf{ position: fixed; }
	.pa{ position: absolute;}
	.pr{ position: relative;}
	.dn{ display: none;}
	.db{ display: block;}
	.clear{ clear: both;}
	.ovh{ overflow: hidden; }
	.tec{ text-align: center; }
	.ter{ text-align: right; }
	.m0auto{ margin: 0px auto; }
	
	.lin1{ line-height: 1; }
	.p1015{ padding: 10px 15px; }
	.p1020{ padding: 10px 20px; }
	
	.bor5{ border-radius:5px ; }
	.bor10{ border-radius:10px ; }
	.bor100{ border-radius: 100px; }
	
	.ellipsis{
		overflow: hidden;
	    text-overflow: ellipsis;
	    -o-text-overflow: ellipsis;
	    white-space:nowrap;
	}
	.ellipsis2{
		overflow:hidden;
		text-overflow:ellipsis;
		display:-webkit-box;
		-webkit-box-orient:vertical;
		-webkit-line-clamp:2; 
	}
	
	.ellipsis3{
		overflow:hidden;
		text-overflow:ellipsis;
		display:-webkit-box;
		-webkit-box-orient:vertical;
		-webkit-line-clamp:3; 
	}
	
	.center{display: -webkit-box;
					display: -ms-flexbox;
					display: -webkit-flex;
					display: flex;
					-webkit-box-pack: center;
					-ms-flex-pack: center;
					-webkit-justify-content: center;
					justify-content: center;
					-webkit-box-align: center;
					-ms-flex-align: center;
					-webkit-align-items: center;
					align-items: center;}
	
	.trall1{transition: all .1s;}
	.trall3{transition: all .3s;}
	
	.r180{transform:rotate(180deg)}
	.r90{transform:rotate(90deg)}
	.r90s{transform:rotate(-90deg)}
	
	.eventsnone{pointer-events: none;}
	.eventsnall{pointer-events: all;}
	
	.tk{z-index: 10; background: rgba(0, 0, 0, 0.6); }
	.z3{ z-index: 3; }
	
	.boxshadow{ box-shadow: 0px 0px 10px rgba(0,0,0,0.1); }
	
	.flex{ display: flex; }
	.alignitems_center{align-items:center}
	.alignitems_end{align-items: flex-end;}
	.alignitems_start{align-items: flex-start;}
	.justify_around{justify-content: space-around;}
	.justify_between{justify-content:space-between}
	.justify_end{justify-content: flex-end;}
	
	
	.bgbj2{background: linear-gradient(217deg, #6ECEB2 3%, #6ECEB2 3%, #00857C 95%, #00857C 95%);}
	
	.pagbottom{ padding: 0px 20px; bottom: 0px;left: 0px; right: 0px; height: 80px; border-radius: 25px 25px 0px 0px; box-shadow: 0px 2px 24px 0px rgba(0, 0, 0, 0.13); }
	.botTab>view{ width: 50px; }
	.botTab>view.on .iconfont{ top: -22px; width: 50px; height: 56px; color: #fff; background: linear-gradient(217deg, #6ECEB2 3%, #6ECEB2 3%, #00857C 95%, #00857C 95%); border-radius: 8px; }
	.botTab .iconfont{ width: 50px; top: 10px; left: 0px; }
	
	.pagbottom2{ padding: 10px 20px 15px 20px; bottom: 0px;left: 0px; right: 0px; border-radius: 0px 0px 0px 0px; box-shadow: 0px 2px 24px 0px rgba(0, 0, 0, 0.13); }
	
	
	/* .innav{}
	.innav>view{ float: left; margin-right: 13px; margin-bottom: 13px; width: calc(25% - 10px); height: 40px; line-height: 1.2; box-shadow: 0px 3px 7px 0px rgb(110 206 178 / 53%); }
	.innav>view:nth-child(4n){ margin-right: 0px; }
	.innav>view>view{ width: 37px; text-align: center; } */
	
	.innav{}
	.innav>view{ float: left; margin-right: 13px; width: calc(25% - 10px); padding: 24rpx 0px;  line-height: 1.2; box-shadow: 0px 3px 7px 0px rgb(110 206 178 / 53%); }
	.innav>view:nth-child(4n){ margin-right: 0px; }
	
	
	.fhtop{box-shadow: 0px 6px 10px 0px rgba(0, 0, 0, 0.3); bottom: 110px; right: 20px; border-radius: 100px; width: 42px;height: 42px;background: rgb(0 133 124 / 27%);border: 4px solid rgba(0, 133, 124, 0.27); }
	.fhtop>view{ width: 42px;height: 42px;background: rgb(0 133 124 / 100%);}
	
	.gzgzh{width: 175px; height: 46px; bottom: 180px; right: 0px; box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.3); }
	.gzgzh.on{ bottom: 100px;}
	
	.pblBox>view {
		width: calc(50% - 5px);
	}
	.pblBox>view>view{ margin-bottom: 15px; box-shadow: 0px 4px 8px 0px rgba(0, 0, 0, 0.1); }
	.pblBox .wbtxt{ padding: 8px 8px; }
	
	.colllist{}
	.colllistLi{box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.1); padding: 15px;margin-bottom: 15px; }
	.colllistLiimg{ width: 276rpx; height: 154rpx;margin-right: 20rpx; }
	.colllistLinr{ width: calc(100% - 296rpx); }
</style>
