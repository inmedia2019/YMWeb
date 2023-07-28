<template>
	<view class="" v-if="page">
		<view class="center" v-if="page.i1">
			<image style="width: 100%;height: 420rpx;" :src="page.i1" mode="widthFix"></image>
		</view>
		<view class="pr ovh" v-if="page.i2" style="margin-top: -1px;">
			<image class="fl" style="width: 100%;height: 597rpx;" :src="page.i2[tabInx]" mode="widthFix"></image>
			<view class="pa" @click="tabInx=0" style="height: 50px; width: 50%; top: 0px; left: 0px; z-index: 3;">
			</view>
			<view class="pa" @click="tabInx=1" style="height: 50px; width: 50%; top: 0px; right: 0px; z-index: 3;">
			</view>
		</view>
		<view class="" v-if="page.i3" style="margin-top: -1px; height: 1166rpx; "
			:style="{'background':'url('+page.i3+')','background-size':'100% auto'}">
			
			<view style="height: 265rpx;"></view>
			
			<swiper @change="swchange" :interval="3000" :duration="300" style="height: 782rpx;" previous-margin="0rpx"
				next-margin="100rpx">
				<swiper-item v-for="(item,index) in page.sw" class="center">
					<view class="trall3 w100">
						<image class="fl"
							style="width: 105%;"
							:src="item" mode="widthFix"></image>
					</view>
				</swiper-item>
			</swiper>
			
			<view class="" style="height: 30rpx;"></view>
			<view class="center">
				<image style="width: 158rpx; height: 36rpx;" :src="page.t1" mode="widthFix"></image>
			</view>
			
			
		</view>
		<view class="center" v-if="page.i4" style="margin-top: -1px;">
			<image style="width: 100%;" :src="page.i4" mode="widthFix"></image>
		</view>
		<view class="pr" v-if="page.i5" style="margin-top: 0px; height: 829rpx; "
			:style="{'background':'url('+page.i5+')','background-size':'100% auto'}">
			
			<view class="pa whtl ">
				<view class="FlopBox flex alignitems_center justify_between" style="">
					<view class="pr" :class="luckdrawnum==0?'on':''" @click="butluckdraw(0)"
						:style="{'background':'url('+page.Flop+') no-repeat','background-size':'100% auto'}"></view>
					<view class="pr" :class="luckdrawnum==1?'on':''" @click="butluckdraw(1)" style="margin: 0px -80rpx;"
						:style="{'background':'url('+page.Flop+') no-repeat','background-size':'100% auto'}"></view>
					<view class="pr" :class="luckdrawnum==2?'on':''" @click="butluckdraw(2)"
						:style="{'background':'url('+page.Flop+') no-repeat','background-size':'100% auto'}"></view>
				</view>
				<view class="pa" @click="GetUserZJInfo()"
					style=" bottom: 180rpx; right: 25px; width: 95px; height: 50px; z-index: 3; "></view>
			</view>
		</view>
		
		<view class="center" v-if="page.i10" style="margin-top: -1px;">
			<image style="width: 100%;" :src="page.i10" mode="widthFix"></image>
		</view>

		<view class="pf whtl center animated fadeIn" v-if="isshowjp!=-1"
			style=" background: rgba(0, 0, 0, 0.7); z-index: 9;">
			<view style="width: 320px;" class="center pr" v-if="isshowjp==0">
				<image @click="navigateTo(page.LinkUrl,'','863d0a44-3c25-4117-a14f-e9a452fe1a4f')" :src="page.wzj"
					mode="widthFix"></image>
				<view class="pa" style=" width: 70px; height: 70px; top: 0px; right: 0px; z-index: 3; "
					@click="isshowjp=-1"></view>
			</view>
			<view style="width: 320px;" class="center pr" v-if="isshowjp==1">
				<image :src="page.zj" mode="widthFix"></image>
				<image class="pa" style=" top: 90px; left: 82px; width: 150px; height: 150px;" :src="UserZJData"
					mode="widthFix"></image>
				<view class="pa" style=" width: 70px; height: 70px; top: 0px; right: 0px; z-index: 3; "
					@click="isshowjp=-1"></view>
			</view>
		</view>

		<view class="dn">
			<image :src="page.zj" mode="widthFix"></image>
			<image :src="page.wzj" mode="widthFix"></image>
		</view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				tabInx: 0,
				swInx: 0,
				luckdrawnum: -1,
				isshowjp: -1,
				UserZJData: "",
				page: "",
				// page: {
				// 	"title": "女性健康艺术展",
				// 	"i1": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/t1.jpg",
				// 	"i2": ["https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/t2.jpg",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/t2s.jpg"
				// 	],
				// 	"i3": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/t3.jpg",
				// 	"i4": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/t4.jpg",
				// 	"i5": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/t5.jpg",
				// 	"t1": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/t1.png",
				// 	"sw": ["https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/k1.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/k2.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/k3.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/k4.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/k5.png"
				// 	],
				// 	"Flop": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/t2.png",
				// 	"Tips": "您的抽奖机会已用完!",
				// 	"isluckdraw": false,
				// 	"wzj": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/ts2.png",
				// 	"zj": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/221215/ts3.png",
				// 	"isend": false,
				// 	"endTxt": "活动已结束！"
				// }
			}
		},
		onLoad() {
			
			uni.request({
				url: 'https://msdym.atline.cn/221215/getISCJ.aspx', //仅为示例，并非真实接口地址。
				method: "POST",
				data: {
					mid: uni.getStorageSync('mid')
				},
				header: {
					'content-type': "application/x-www-form-urlencoded"
				},
				success: (res) => {
					this.page = res.data
					
					
					
					
					uni.setNavigationBarTitle({
						title: this.page.title
					});

					// this.page.isend=false
					// this.page.endTxt="活动已结束！"


					if(this.page.isend){
						this.UshowToast(this.page.endTxt)
						setTimeout(()=>{
							this.reLaunch('/pages/index','','')
						},1500)
					}


				}
			});
		},
		onShow() {

		},


		methods: {
			swchange(e) {
				this.swInx = e.detail.current
			},
			butluckdraw(e) {
				if (!uni.getStorageSync('mid')) {
					return
				}
				if (this.page.isluckdraw) {
					this.UshowToast(this.page.Tips)
					return
				}
				this.page.isluckdraw = true
				this.UshowLoading()
				uni.request({
					url: 'https://msdym.atline.cn/221215/setCResult.aspx', //仅为示例，并非真实接口地址。
					method: "POST",
					data: {
						mid: uni.getStorageSync('mid')
					},
					header: {
						'content-type': "application/x-www-form-urlencoded"
					},
					success: (res) => {
						uni.hideLoading()
						this.luckdrawnum = e
						// this.isshowjp = 1
						// this.UserZJData = res.data
						// return
						setTimeout(() => {
							if (res.data == "") {
								this.isshowjp = 0
							} else {
								this.isshowjp = 1
								this.UserZJData = res.data
							}
						}, 1000)
					}
				});
			},
			GetUserZJInfo() {
				if (!uni.getStorageSync('mid')) {
					return
				}
				this.UshowLoading()
				uni.request({
					url: 'https://msdym.atline.cn/221215/GetUserZJInfo.aspx', //仅为示例，并非真实接口地址。
					method: "POST",
					data: {
						mid: uni.getStorageSync('mid')
					},
					header: {
						'content-type': "application/x-www-form-urlencoded"
					},
					success: (res) => {
						uni.hideLoading()
						
						if (res.data == 0) {
							this.isshowjp = 0
						} else {
							this.isshowjp = 1
							this.UserZJData = res.data
						}
						
					}
				});
			}
		}
	}
</script>

<style>
	.FlopBox {}

	.FlopBox>view {
		-webkit-transform: perspective(1000px);
		width: 274rpx;
		height: 591rpx;
		-webkit-transform-style: preserve-3d;
		transform-style: preserve-3d;
	}

	.FlopBox>view.on {
		-webkit-animation: FlopBox 1s linear;
	}


	@keyframes FlopBox {
		0% {
			transform: rotateY(0deg);
		}

		50% {
			transform: rotateY(-180deg);
		}

		100% {
			transform: rotateY(-360deg);
		}
	}
</style>
