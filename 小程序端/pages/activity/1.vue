<template>
	<view class="" v-if="page">
		<view class="center" v-if="page.i1">
			<image style="width: 100%;" :src="page.i1" mode="widthFix"></image>
		</view>
		<view class="pr ovh" v-if="page.i2" style="margin-top: -1px;">
			<image class="fl" style="width: 100%;" :src="page.i2[tabInx]" mode="widthFix"></image>
			<view class="pa" @click="tabInx=0" style="height: 50px; width: 50%; top: 0px; left: 0px; z-index: 3;">
			</view>
			<view class="pa" @click="tabInx=1" style="height: 50px; width: 50%; top: 0px; right: 0px; z-index: 3;">
			</view>
		</view>
		<view class="center" v-if="page.i3" style="margin-top: -1px;">
			<image style="width: 100%;" :src="page.i3" mode="widthFix"></image>
		</view>
		<view class="center" v-if="page.i4" style="margin-top: -1px;">
			<image style="width: 100%;" :src="page.i4" mode="widthFix"></image>
		</view>
		<view class="" v-if="page.i5" style="margin-top: -1px;"
			:style="{'background':'url('+page.i5+')','background-size':'100% auto'}">
			<swiper @change="swchange" :interval="3000" :duration="300" style="height: 766rpx;" previous-margin="26rpx"
				next-margin="50rpx">
				<swiper-item v-for="(item,index) in page.sw" class="center">
					<view :style="{'transform':'scale('+(index==swInx?'1':'0.85')+')'}" class="trall3 w100"
						style="-webkit-transform-origin:left center; height: 100%; ">
						<image class="fl"
							style="width: 95%;box-shadow: 0px 10px 10px 0px rgba(2, 134, 124, 0.69); border-radius: 20px;"
							:src="item" mode="widthFix"></image>
					</view>
				</swiper-item>
			</swiper>
		</view>
		<view class="center" v-if="page.i6" style="margin-top: -1px;">
			<image style="width: 100%;" :src="page.i6" mode="widthFix"></image>
		</view>
		<view class="center" v-if="page.i7" style="margin-top: -1px;">
			<image @click="navigateTo(page.LinkUrl,'','863d0a44-3c25-4117-a14f-e9a452fe1a4f')" style="width: 100%;" :src="page.i7" mode="widthFix"></image>
			<!-- <image @click="navigateTo('/pages/details?id=a413b499-c120-45ab-aba4-bed140791c38','','863d0a44-3c25-4117-a14f-e9a452fe1a4f')" style="width: 100%;" :src="page.i7" mode="widthFix"></image> -->
		</view>
		<view class="center" v-if="page.i8" style="margin-top: -1px;">
			<image style="width: 100%;" :src="page.i8" mode="widthFix"></image>
		</view>
		<view class="center pr" v-if="page.i9" style="margin-top: -1px;">
			<image style="width: 100%;" :src="page.i9" mode="widthFix"></image>
			<view class="pa whtl ">
				<view class="FlopBox flex alignitems_center justify_between" style="padding: 30rpx 60rpx;">
					<view class="pr" :class="luckdrawnum==0?'on':''" @click="butluckdraw(0)"
						:style="{'background':'url('+page.Flop+') no-repeat','background-size':'100% auto'}"></view>
					<view class="pr" :class="luckdrawnum==1?'on':''" @click="butluckdraw(1)"
						:style="{'background':'url('+page.Flop+') no-repeat','background-size':'100% auto'}"></view>
					<view class="pr" :class="luckdrawnum==2?'on':''" @click="butluckdraw(2)"
						:style="{'background':'url('+page.Flop+') no-repeat','background-size':'100% auto'}"></view>
				</view>
				<view class="center">
					<image style="width: 144rpx;" :src="page.sycs[page.isluckdraw?0:1]" mode="widthFix"></image>
				</view>
				<view class="pa" @click="GetUserZJInfo()" style=" bottom: 0px; right: 25px; width: 95px; height: 50px; z-index: 3; "></view>
			</view>
		</view>
		<view class="center" v-if="page.i10" style="margin-top: -1px;">
			<image style="width: 100%;" :src="page.i10" mode="widthFix"></image>
		</view>

		<view class="pf whtl center animated fadeIn" v-if="isshowjp!=-1"
			style=" background: rgba(0, 0, 0, 0.7); z-index: 9;">
			<view style="width: 320px;" class="center pr" v-if="isshowjp==0">
				<image  @click="navigateTo(page.LinkUrl,'','863d0a44-3c25-4117-a14f-e9a452fe1a4f')" :src="page.wzj" mode="widthFix"></image>
				<view class="pa" style=" width: 50px; height: 50px; top: 0px; right: 13px; z-index: 3; "
					@click="isshowjp=-1"></view>
			</view>
			<view style="width: 320px;" class="center pr" v-if="isshowjp==1">
				<image :src="page.zj" mode="widthFix"></image>
				<image class="pa" style=" top: 110px; left: 47px; width: 105px; height: 105px;" :src="UserZJData"
					mode="widthFix"></image>
				<view class="pa" style=" width: 50px; height: 50px; top: 0px; right: 13px; z-index: 3; "
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
				UserZJData:"",
				page:"",
				// page: {
				// 	title: "女性健康跨界艺术展",
				// 	i1: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_01.jpg",
				// 	i2: ["https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_031.jpg",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_03.jpg"
				// 	],
				// 	i4: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_04.jpg",
				// 	i5: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_05.jpg",
				// 	i6: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_06.jpg",
				// 	i7: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_07.jpg",
				// 	i8: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_08.jpg",
				// 	i9: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_09.jpg",
				// 	i10: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/%E6%B4%BB%E5%8A%A8%E9%A1%B5_10.jpg",
				// 	sw: ["https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/sw1.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/sw2.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/sw3.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/sw4.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/sw5.png"
				// 	],
				// 	LinkUrl: "https://ebook.msdwechat.cn/",
				// 	Flop: "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/fp1.png",
				// 	Tips: "您的抽奖机会已用完!",
				// 	sycs: ["https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/cs0.png",
				// 		"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/cs1.png"
				// 	],
				// 	wzj:"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/tk2.png",
				// 	zj:"https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/1/tk3.png",
				// 	isluckdraw: false
				// }
			}
		},
		onLoad() {
			uni.request({
				url: 'https://msdym.atline.cn/activity202211/getISCJ.aspx', //仅为示例，并非真实接口地址。
				method:"POST",
				data: {
					mid: uni.getStorageSync('mid')
				},
				header: {
					'content-type': "application/x-www-form-urlencoded"
				},
				success: (res) => {
					this.page=res.data
					
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
				if(!uni.getStorageSync('mid')){
					return
				}
				if (this.page.isluckdraw) {
					this.UshowToast(this.page.Tips)
					return
				}
				this.page.isluckdraw = true
				this.UshowLoading()
				uni.request({
					url: 'https://msdym.atline.cn/activity202211/setCResult.aspx', //仅为示例，并非真实接口地址。
					method:"POST",
					data: {
						mid: uni.getStorageSync('mid')
					},
					header: {
						'content-type': "application/x-www-form-urlencoded"
					},
					success: (res) => {
						uni.hideLoading()
						this.luckdrawnum = e
						setTimeout(() => {
							if(res.data==""){
								this.isshowjp = 0
							}else{
								this.isshowjp = 1
								this.UserZJData=res.data
							}
						}, 1000)
					}
				});
			},
			GetUserZJInfo(){
				if(!uni.getStorageSync('mid')){
					return
				}
				this.UshowLoading()
				uni.request({
					url: 'https://msdym.atline.cn/activity202211/GetUserZJInfo.aspx', //仅为示例，并非真实接口地址。
					method:"POST",
					data: {
						mid: uni.getStorageSync('mid')
					},
					header: {
						'content-type': "application/x-www-form-urlencoded"
					},
					success: (res) => {
						uni.hideLoading()
						if(res.data==0){
							this.isshowjp = 0
						}else{
							this.isshowjp = 1
							this.UserZJData=res.data
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
		width: 204rpx;
		height: 324rpx;
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
