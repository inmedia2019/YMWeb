<template>
	<view>
		
		<view class="center pr" style="min-height: 2506rpx;">
			<image @load="Si1t" :style="{'opacity':Si1?1:0}" style="width: 100%;" :src="page.i1" mode="widthFix"></image>
			<!-- <view class="center pa" style="bottom: 140rpx; left: 0px; right: 0px; ">
				<image @click="butyy()" class="pulse infinite animated slow1" style="width: 261rpx; height: 94rpx;" src="https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/230215/rilibut.png" mode="widthFix"></image>
			</view> -->
			
			
			<view class="center pa" style="bottom: 175rpx; left: 12%; right: 12%; ">
				<video v-if="page" class="w100" @timeupdate="timeupdate" style=" height: 322rpx;" :src="page.videourl" :poster="page.picurl" controls></video>
			</view>
		</view>
		<view class="pf whtl center" v-if="istx" style="background: rgba(0, 0, 0, 0.5);">
			<view class="center pr" style="width: 320px;">
				<image style="width: 320px; height: 278px;" src="https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/230215/rilitk.png" mode="widthFix"></image>
				<view class="pa whtl">
					<view class="tec" style="margin-top:84px;font-size:18px;line-height: 1.3;">
						恭喜，你是第<text class="fb" style="font-size: 30px; padding: 0px 5px; color: #ff5270;">{{CResult}}</text>个<br>预约活动的人
					</view>
					<view class="tec pr" style="margin-top: 20px;">
						<view class="center">
							<image style="width: 93rpx; height: 93rpx;" src="https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/230215/rili.png" mode="widthFix"></image>
						</view>
						<view class="f12">开启日历提醒</view>
						<view class="pa whtl z3" @click="addPhoneCalendar"></view>
					</view>
				</view>
				
				<view @click="istx=false" class="iconfont icon-guanbi cfff center pa bor100" style="border: #fff solid 2px; width: 35px; height: 35px; bottom: -45px; left: 50%; margin-left: -17px; "></view>
			</view>
		</view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				Si1:false,
				CResult:0,
				istx:false,
				istime: -1,
				page:""
				// page: {
				// 	"title": "把握此刻美好",
				// 	"i1": "https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/230215/rl.jpg",
				// 	"isend": false,
				// 	"endTxt": "活动已结束！"
				// }
			}
		},
		onLoad() {
			
			uni.request({
				url: 'https://msdym.atline.cn/230224/getISCJ.aspx', //仅为示例，并非真实接口地址。
				method: "POST",
				data: {
					mid: uni.getStorageSync('mid')
				},
				header: {
					'content-type': "application/x-www-form-urlencoded"
				},
				success: (res) => {
					
					this.page =res.data
					
					// this.page.title="“美好共建计划”"
					// this.page.shareimage="https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/activity/230215/shareimage.png"
					// this.page.sharetitle="有一种美好，在守护中盛放"
					
					
					uni.setNavigationBarTitle({
						title: this.page.title
					});
					
					this.shareObj= {
						title: this.page.sharetitle,
						path: "pages/activity/230215?Section=e49864ba-6802-4b44-b3e3-6cd14c46e707",
						imageUrl: this.page.shareimage
					}
			
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
		onShareAppMessage(res) {
			var data = getCurrentPages()[getCurrentPages().length - 1].data.parameter
			if(data){
				if(data.id){
					this.AddUserAction(data.id,10)
				}else{
					this.AddUserAction("",10)
				}
			}else{
				this.AddUserAction("",10)
			}
			
			return this.shareObj
		},
		onShareTimeline(res) {
			var data = getCurrentPages()[getCurrentPages().length - 1].data.parameter
			if(data){
				if(data.id){
					this.AddUserAction(data.id,10)
				}else{
					this.AddUserAction("",10)
				}
			}else{
				this.AddUserAction("",10)
			}
			return this.shareObj
		},
		methods: {
			timeupdate(res){
				var time=parseInt(res.detail.currentTime)
				if(this.istime!=time){
					if(time%3==0){
						this.istime=time
						this.AddUserAction("230215",6,time)
					}
				}
			},
			Si1t(){
				this.Si1=true
			},
			butyy() {
				
				uni.request({
					url: 'https://msdym.atline.cn/230224/setCResult.aspx', //仅为示例，并非真实接口地址。
					method: "POST",
					data: {
						mid: uni.getStorageSync('mid')
					},
					header: {
						'content-type': "application/x-www-form-urlencoded"
					},
					success: (res) => {
						this.CResult=res.data
						this.istx=true
					}
				});
				
				
			},
			addPhoneCalendar() {
				var timeStr = "2023/03/08 10:00:00"
				//var timeStr = "2023/02/24 12:00:00"
				wx.addPhoneCalendar({
						title: "“无忧共建计划”公益健康沙龙",
						startTime: new Date(timeStr.replace(/-/g, "/")).getTime() / 1000,
						alarm: false, //是否提醒
						//alarmOffset: 600,
						description: "恭喜您预约成功", //日历的备注
						success() {
							this.UshowToast("添加成功！")
						},
						fail() {
							wx.showModal({
								title: "提示",
								content: "添加失败或请“设置-隐私-日历”中允许微信使用日历",
								showCancel: false,
							});
						}
				})
			}
		}
	}
</script>

<style>
</style>
