<template>
	<view>
		
		<view class="tec f12" style="color: #4A4A4A; opacity: 0.6;" v-if="isindex">
			<text @click="isSMZSM=true">《免责声明》</text>&<text @click="isSTYS=true">《用户知情同意书》</text><br>
			默沙东(中国)有限公司 ©2022版权所有
		</view>
		
		<view class="pf gzgzh center z3 trall3 bor100 b00857C cfff f12" :class="scrollTop>50?'':'on'" v-if="GZH&&isindex" @click="navigateTo(GZH.F_FrontLink,'','22471ef7-3520-4773-b7fd-a452f0f6738c')">
			<view class="iconfont icon-weixin f22"></view>
			<view class="w5 h1"></view>
			<view class="" style="line-height: 1.2;">默沙东中国<br>微信公众号</view>
			<view class="w5 h1"></view>
			<view class="bfff bor100 c00857C" style="line-height: 1.2; padding: 5px 8px;">去关注</view>
		</view>
		
		<view class="pf fhtop center z3 animated fadeIn" v-if="scrollTop>50" @click="goTop">
			<view class="center bor100 iconfont icon-a-zu41 cfff f18"></view>
		</view>
		 
		<view class="pf whtl center"  v-if="isSTYS" style="z-index: 3; background: rgba(0, 0, 0, 0.5); z-index: 99; ">
			<view class="pf whtl" @click="isSTYS=false"></view>
			<view class="baaa pr z3" style="height: 80%; width: 90%; background: #fff; border-radius: 10px; ">
				<view @click="isSTYS=false" class="pf iconfont icon-guanbi bor100 cfff center" style="width: 30px; height: 30px; border: #fff solid 1px; top: 30px; right: 20px; "></view>
				<view class="tec f16 fb center c00857C" style="height: 70px;">用户知情同意书</view>
				<scroll-view :scroll-y="true" style="height: calc(100% - 172px); ">
					<view class="p1015">
						<view class="f12" style="color: #7f7f7f; line-height: 1.8; ">
							<mp-html :content="TYS.F_PictureUrl" />
						</view>
						<view class="h15"></view>
		
						<view class="f12 c00857C" v-if="form">
							<view class="ovh" @click="butAgree(0)">
								<view :class="form.option0?'':'iconfont icon-duihao'" class="fl center f12"
									style="width: 11px; height: 11px; border-radius: 2px; border: #00857C solid 1px; margin-top: 1px; ">
		
								</view>
								<view class="fr" style="width: calc(100% - 22px);">我已阅读本政策，并同意默沙东按照上述方式处理我的个人信息。</view>
							</view>
							<view class="h10"></view>
							<view class="ovh" @click="butAgree(1)">
								<view :class="form.option1?'':'iconfont icon-duihao'" class="fl center f12"
									style="width: 11px; height: 11px; border-radius: 2px; border: #00857C solid 1px; margin-top: 1px; ">
								</view>
								<view class="fr" style="width: calc(100% - 22px);">
									我同意默沙东出于提供【专业知识分享服务】目的处理我的敏感个人信息。</view>
							</view>
							<view class="h10"></view>
							<view class="ovh" @click="butAgree(2)">
								<view :class="form.option2?'':'iconfont icon-duihao'" class="fl center f12"
									style="width: 11px; height: 11px; border-radius: 2px; border: #00857C solid 1px; margin-top: 1px; ">
								</view>
								<view class="fr" style="width: calc(100% - 22px);">
									我同意默沙东为前述目的将我的个人信息提供给以上链接所列明的公司实体和供应商。
								</view>
							</view>
							<view class="h10"></view>
							<view class="ovh" @click="butAgree(3)">
								<view :class="form.option3?'':'iconfont icon-duihao'" class="fl center f12"
									style="width: 11px; height: 11px; border-radius: 2px; border: #00857C solid 1px; margin-top: 1px; ">
								</view>
								<view class="fr" style="width: calc(100% - 22px);">
									我同意默沙东为前述目的将我的个人信息传输出境。
								</view>
							</view>
							<view class="h10"></view>
							<view class="ovh" @click="butAgree(4)">
								<view :class="form.option4?'':'iconfont icon-duihao'" class="fl center f12"
									style="width: 11px; height: 11px; border-radius: 2px; border: #00857C solid 1px; margin-top: 1px; ">
								</view>
								<view class="fr" style="width: calc(100% - 22px);">
									我同意接受来自于默沙东的电子信息，包括默沙东提供的教育、服务、活动和产品的更新。
								</view>
							</view>
							<view class="h10"></view>
							<view class="ovh" @click="butAgree(5)">
								<view :class="form.option5?'':'iconfont icon-duihao'" class="fl center f12"
									style="width: 11px; height: 11px; border-radius: 2px; border: #00857C solid 1px; margin-top: 1px; ">
								</view>
								<view class="fr" style="width: calc(100% - 22px);">
									我同意默沙东或默沙东的服务提供商可以通过电话或短信的方式，与本人进行学术互动交流，就与默沙东相关的活动、教育活动、服务、产品或其他信息进行沟通。
								</view>
							</view>
						</view>
						<!-- <view class="h15"></view> -->
					</view>
				</scroll-view>
				<view class="h15"></view>
				<view style="padding: 0px 15px;">
					<view class="center f12" @click="butSelectAll" style="background: rgba(0, 133, 124, 0.1); border-radius:6px 6px 0px 0px; height: 30px; color: #00857C;">
						<view :class="form.option0||form.option1||form.option2||form.option3||form.option4||form.option5?'':'iconfont icon-duihao'" class="fl center f12"
							style="width: 11px; height: 11px; line-height: 1px; border-radius: 2px; border: #00857C solid 1px; margin-top: 1px; ">
						</view>
						<view class="fr" style=" margin-left: 5px; ">
							全部勾选
						</view>
					</view>
				</view>
				<view class="" style="padding: 0px 15px;">
					<view class="flex alignitems_center f18" style="border-top: #D6D6D6 solid 1px;padding: 1px 0px;">
						<view @click="isSTYS=false" class="center"
							style="width: 50%; height: 44px; color: #999999; ">取消</view>
						<view @click="butTYS" class="center c00857C"
							style="width: 50%; border-left: #D6D6D6 solid 1px; height: 44px; ">确定</view>
					</view>
				</view>
			</view>
		</view>
		
		<view class="pf whtl center" v-if="isSMZSM" style="z-index: 3; background: rgba(0, 0, 0, 0.5); z-index: 99; ">
			<view class="pf whtl" @click="isSMZSM=false"></view>
			<view class="cfff pr" style="height: 80%; width: 90%; border-radius: 10px; background: #fff; ">
				<view @click="isSMZSM=false" class="pf iconfont icon-guanbi bor100 cfff center" style="width: 30px; height: 30px; border: #fff solid 1px; top: 30px; right: 20px; "></view>
				
				<view class="tec f16 fb center c00857C" style="height: 70px;">免责声明</view>
				<scroll-view :scroll-y="true" style="height: calc(100% - 142px); ">
					<view class="p1015">
						
						<view class="f12" style="color: #7f7f7f; line-height: 1.8; ">
							<mp-html :content="MZSM.F_PictureUrl" />
						</view>
						<view class="h15"></view>
					</view>
				</scroll-view>
				<view class="h15"></view>
				<view class="" style="padding: 0px 15px;">
					<view class="flex alignitems_center f18" style="border-top: #D6D6D6 solid 1px;padding: 1px 0px;">
						
						<view @click="isSMZSM=false" class="center c00857C"
							style="width: 100%; height: 44px; ">确定</view>
					</view>
				</view>
				
				
				
			</view>
		</view>
		
		
		<view class="pf whtl center" :class="xsyzimg?'animated fadeIn':''" v-if="xsyz" style="z-index: 3; background: rgba(0, 0, 0, 0.5); z-index: 99; opacity: 0; ">
			<view class="pf whtl" @click="butgbyz()"></view>
			<!-- 85 -->
			<view class="cfff pr" style="width: 320px; border-radius: 10px; margin-top: -50px; ">
				<image @click="butgbyz();navcs();AddUserAction('',11,xsyzData.F_ImageUrl)" style="width: 100%;" :src="xsyzData.F_ImageUrl" @load="ImageUrl" mode="widthFix"></image>
				<view @click="butgbyz()" class="pa" style="width: 60px; height: 60px; bottom: 0px; left: calc(50% - 30px); "></view>
				<!-- <view @click="butgbyz()" class="pa" style="width: 60px; height: 60px; top: 0px; right: 0px; "></view> -->
			</view>
		</view>
	</view>
</template>

<script>
	var now = new Date();
	var year = now.getFullYear(); //得到年份
	var month = now.getMonth()+1;//得到月份
	var date = now.getDate();//得到日期
	
	
	export default {
		props: ['scroll','showTYS'],
		data() {
			return {
				isindex:false,
				
				GZH: "",
				
				TYS: {},
				isSTYS: false,
				form: "",
				
				MZSM: {},
				isSMZSM: false,
				
				scrollTop:0,
				
				xsyz:false,
				xsyzimg:false,
				xsyzData:{}
			}
		},
		mounted() {
			
			
			var url=getCurrentPages()[getCurrentPages().length-1].route
			if(url.indexOf('pages/index')>=0){
				this.isindex=true
			}
			
			this.$reqUest.get('/api/CmsManage/GetChannelInfoById', {
				Id: "c418e657-eef0-4adc-825d-fab1e828a413"
			}).then(data => {
				var [error, res] = data;
				this.GZH = res.data.Data
			})
			
			this.$reqUest.get('/api/CmsManage/GetChannelInfoById', {
				Id: "2624f86b-39a0-45c2-a335-e2b093d3331a"
			}).then(data => {
				var [error, res] = data;
				if (res.data.Result) {
					this.TYS = res.data.Data
				}
			})
			
			this.$reqUest.get('/api/Memberinfo/GetUserInfoByOpenId', {
				openId: uni.getStorageSync('openid')
			}).then(data => {
				var [error, res] = data;
				if(res.data){
					this.form = res.data
					if(!this.form.IsAgreeAgreement){
						//console.log(1)
						this.form.option0 = false
						this.form.option1 = false
						this.form.option2 = false
						this.form.option3 = false
						this.form.option4 = false
						this.form.option5 = false
					}else{
						//console.log(2)
						this.form.option0 = true
						this.form.option1 = true
						this.form.option2 = true
						this.form.option3 = true
						this.form.option4 = true
						this.form.option5 = true
					}
				}
				
				
			})
			
			this.$reqUest.get('/api/CmsManage/GetChannelInfoById', {
				Id: "6698ad0b-f075-426c-97ad-897433e8d9cb"
			}).then(data => {
				var [error, res] = data;
				if (res.data.Result) {
					this.MZSM = res.data.Data
				}
			})
			
			
			//
			this.$reqUest.get('/api/Block/GetBannerByChannelId', {
				channelId: "6f7cfcf8-0e87-469e-856f-27206ebd33cf"
			}).then(data => {
				var [error, res] = data;
				var data=res.data.Data[0]
				//console.log(data)
				if(data){
					this.xsyzData=data
					
					// var xsyzSync=uni.getStorageSync('xsyzSync')
					// if(url.indexOf('pages/index')>=0&&this.xsyzData.F_EnabledMark){
					// 	if(xsyzSync==""||xsyzSync.year!=year||xsyzSync.month!=month||xsyzSync.date!=date){
							
					// 	}
					// }
					//this.xsyz=true
					if(url.indexOf('pages/index')>=0&&this.xsyzData.F_EnabledMark){
						// if(this.$parent.$scope.options.channel=="CIIEofflineOfflineSocialgroupNAStefanie11051110"){
						// 	return
						// }
						// if(this.$parent.$scope.options.channel=="CIIEofflineOfflineInteractScreenNAStefanie11051110"){
						// 	return
						// }
						this.xsyz=true
					}
				}
			})
		},
		watch: {
			scroll: {
				handler(item, index) {
					this.scrollTop = item
				},
				deep: true
			},
			showTYS: {
				handler(item, index) {
					this.isSTYS=true
				},
				deep: true
			}
		},
		onLoad(e) {
			
		},
		methods: {
			navcs(){
				//console.log(this.$parent.$scope.$page.fullPath)
				this.navigateTo(this.xsyzData.F_LinkUrl+'?'+(this.$parent.$scope.$page.fullPath).split("?")[1],'','b40307ff-570f-4e92-b810-780c44a5001f')
			},
			butgbyz(){
				this.xsyz=false
				uni.setStorage({
					key: 'xsyzSync',
					data: {
						year:year,
						month:month,
						date:date
					},
					success() {
						
					}
				});
			},
			ImageUrl(){
				this.xsyzimg=true
			},
			goTop() {
				wx.pageScrollTo({
					scrollTop: 0
				})
			},
			
			butSelectAll(){
				if(this.form.option0||this.form.option1||this.form.option2||this.form.option3||this.form.option4||this.form.option5){
					this.form.option0 = false
					this.form.option1 = false
					this.form.option2 = false
					this.form.option3 = false
					this.form.option4 = false
					this.form.option5 = false
				}else{
					this.form.option0 = true
					this.form.option1 = true
					this.form.option2 = true
					this.form.option3 = true
					this.form.option4 = true
					this.form.option5 = true
				}
				this.$forceUpdate()
			},
			
			butAgree(e) {
				if (e == 0) {
					this.form.option0 = this.form.option0 ? false : true
				}
				if (e == 1) {
					this.form.option1 = this.form.option1 ? false : true
				}
				if (e == 2) {
					this.form.option2 = this.form.option2 ? false : true
				}
				if (e == 3) {
					this.form.option3 = this.form.option3 ? false : true
				}
				if (e == 4) {
					this.form.option4 = this.form.option4 ? false : true
				}
				if (e == 5) {
					this.form.option5 = this.form.option5 ? false : true
				}
				
				
				
				this.$forceUpdate()
			},
			butTYS() {
				if (this.form.option0) {
					this.UshowToast("请同意本政策，并同意默沙东按照上述方式处理我的个人信息。")
					return
				}
				if (this.form.option1) {
					this.UshowToast("请同意默沙东出于提供【专业知识分享服务】目的处理我的敏感个人信息。")
					return
				}
				if (this.form.option2) {
					this.UshowToast("请同意默沙东为前述目的将我的个人信息提供给以上链接所列明的公司实体和供应商。")
					return
				}
				if (this.form.option3) {
					this.UshowToast("请同意默沙东为前述目的将我的个人信息传输出境。")
					return
				}
				if (this.form.option4) {
					this.UshowToast("请同意接受来自于默沙东的电子信息，包括默沙东提供的教育、服务、活动和产品的更新。")
					return
				}
				if (this.form.option5) {
					this.UshowToast("请我同意默沙东或默沙东的服务提供商可以通过电话或短信的方式，与本人进行学术互动交流，就与默沙东相关的活动、教育活动、服务、产品或其他信息进行沟通。")
					return
				}
				this.UshowLoading()
				this.$reqUest.get('/api/Memberinfo/ModifyUserInfoByMid', {
					mid:uni.getStorageSync('mid'),
					tid:1,
					tValue:false
				}).then(data => {
					var [error, res] = data;
					uni.hideLoading()
					this.isSTYS=false
					this.UshowToast("提交成功！")
					this.UserInfo.IsAgreeAgreement=false
				})
			},
		}
	}
</script>

<style>
</style>