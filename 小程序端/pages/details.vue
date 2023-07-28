<template>
	<view class="" id="box">

		<view class="" v-if="details">
			
			<view v-if="details.VideoUrl.indexOf('.mp4')>=0">
				<view class="center" v-bind:style="{ 'background': 'url('+details.PicUrl+') center center / cover no-repeat' }">
					<video v-if="details.VideoUrl" class="w100" @timeupdate="timeupdate" style=" height: 422rpx;" :src="details.VideoUrl" :poster="details.PicUrl" controls></video>
				</view>
				<view class="p1015 f16 fb">
					{{details.F_Titile}}
				</view>
				<view class="bfff p1015">
					<view class="flex alignitems_center justify_between">
						<view class="center">
							<view class="bor5" style="width: 6px; height: 18px; background: #BFED33;"></view>
							<view class="w10 h1"></view>
							<view class="c252525 f14 fb">介绍</view>
						</view>
					</view>
					<view class="h15"></view>
					<view class="c9B9B9B" style="line-height: 1.8">
						<mp-html :content="details.F_LiveIntroduction" />
					</view>
				</view>
			</view>
			
			<view class="p1020" v-else>
				<view class="h10"></view>
				<view class="f18">{{details.F_Titile}}</view>
				<view class="h20"></view>
				<!-- <view class="f12 c00857C">
					<text style="margin-right: 10px;" v-for="(item,index) in details.F_TagsName">#{{item}}#</text>
				</view>
				<view class="h5"></view> -->
				<view class="ter c979797">{{$conFig.dateformat3(details.F_PublishTime)}}</view>
				<view class="h20"></view>
				<view class="" style="">
					<mp-html :content="details.F_Content?details.F_Content:details.F_LiveIntroduction" />
				</view>
				<view class="h20"></view>
				<view class="center">
					<image @click="navigateTo('https://ebook.msdcnmrl.cn/#/?pub_home&sourceId=10001&v=2022121401','','05722151-86fc-48e0-8a24-ae98720d4f59')" class="w100" style="height: 50px;" src="../static/fj2.png"
						mode="widthFix"></image>
				</view>
				<view class="h20"></view>
				<view class="center">
					<image @click="navigateTo('pages/index/index','wx2d9bd6b6da808d37','05722151-86fc-48e0-8a24-ae98720d4f59')" class="w100" style="height: 50px;" src="../static/fj.png"
						mode="widthFix"></image>
				</view>
			</view>
			
			<view class="h20"></view>
			<view class="h20"></view>
			<view class="h20"></view>
			<view class="h20"></view>
			<view class="h20"></view>
		</view>

		<view class="pf pagbottom2 p1020 bfff z3 boxshadow">
			<view class="h5"></view>
			<view class="botTab flex alignitems_center justify_between">
				<view class="b00857C cfff f14 center bor5" style="height: 42px; width: 42%;" @click="navigateBack()">
					<image style="width: 18px; height: 18px; max-width: 18px; " src="../static/return.png" mode="widthFix"></image>
					<view class="w10 h1"></view>
					<view class="">返回</view>
				</view>
				<view class="center" style="height: 42px;">
					<view class="">
						<view class="bor5 bDEDDDE" style="width: 4px; height: 4px;"></view>
						<view class="h5"></view>
						<view class="bor5 bDEDDDE" style="width: 4px; height: 4px;"></view>
						<view class="h5"></view>
						<view class="bor5 bDEDDDE" style="width: 4px; height: 4px;"></view>
					</view>
				</view>
				<view class="flex alignitems_center justify_end f12 c6D7278 tec" style="height: 42px; width: 42%;">
					<view class="" @click="butDZ">
						<view class="center">
							<image style="width: 30px; height: 30px;" :src="'../static/'+(details.IsdZ==0?'zan':'zan2')+'.png'" mode="widthFix"></image>
						</view>
						<view class="">点赞</view>
					</view>
					<view class="w10 h1"></view>
					<view class="w10 h1"></view>
					<view class="" @click="butColl">
						<view class="center">
							<image style="width: 30px; height: 30px;" :src="'../static/'+(IsFavitor==0?'Coll':'Coll2')+'.png'" mode="widthFix"></image>
						</view>
						<view class="">收藏</view>
					</view>
					<view class="w10 h1"></view>
					<view class="w10 h1"></view>
					<view class="pr">
						<view class="center">
							<image style="width: 30px; height: 30px;" src="../static/share.png" mode="widthFix"></image>
						</view>
						<view class="">转发</view>
						
						<button class="pa whtl" open-type="share" style="opacity: 0;"></button>
						
					</view>
				</view>
			</view>
			<view class="h5"></view>
			<boTtom :scroll="scrollTop" :showTYS="showTYS"></boTtom>
		</view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				parameter:{},
				details:"",
				IsFavitor:0,
				istime:-1,
				showTYS:false
			}
		},
		onLoad(e) {
			
			this.parameter=e
			this.$reqUest.get('/api/Content/GetNewsInfoById',{
				Id:this.parameter.id,
				mid:this.mid
			}).then(data => {
				var [error, res] = data;
				this.details=res.data
				
				uni.setNavigationBarTitle({
					title:"文章详情"
				});
				
				// this.details.F_TagsName = this.details.F_TagsName.substr(0, this.details.F_TagsName.length - 1);
				// this.details.F_TagsName=this.details.F_TagsName.split(",")
				
				this.shareObj={
					title: this.details.F_Titile,
					path: "pages/details?id="+this.parameter.id,
					imageUrl: ""
				}
				
			})
			
			this.$reqUest.get('/api/Favitorinfo/GetUserIsFavitorInfo',{
				infoId:this.parameter.id,
				mid:this.mid
			}).then(data => {
				var [error, res] = data;
				this.IsFavitor=res.data.Data.IsFavitor
				
			})
			
		},
		methods: {
			timeupdate(res){
				var time=parseInt(res.detail.currentTime)
				if(this.istime!=time){
					if(time%3==0){
						this.istime=time
						this.AddUserAction(this.parameter.id,6,time)
					}
				}
				
			},
			getUrl(url){
				uni.navigateTo({
					url: "/pages/webview?url="+this.$base64.Base64.encode(url)
				});
			},
			butDZ(){
				
				if(!uni.getStorageSync('openid')){
					return
				}
				this.$reqUest.get('/api/Memberinfo/GetUserInfoByOpenId', {
					openId: uni.getStorageSync('openid')
				}).then(data => {
					var [error, res] = data;
					this.UserInfo = res.data
					
					if(!this.UserInfo.IsAgreeAgreement){
						if(this.details.IsdZ==0){
							this.details.IsdZ=1
							this.AddUserAction(this.parameter.id,2)
							this.UshowToast("点赞成功")
						}else{
							this.AddUserAction(this.parameter.id,8)
							this.details.IsdZ=0
						}
					}else{
						this.UshowToast("请阅读用户知情同意书并勾选！")
						setTimeout(()=>{
							this.showTYS=false
							setTimeout(()=>{
								this.showTYS=true
							},50)
						},1500)
					}
					
				})
				
				
				
			},
			butColl(){
				
				if(!uni.getStorageSync('openid')){
					return
				}
				
				this.$reqUest.get('/api/Memberinfo/GetUserInfoByOpenId', {
					openId: uni.getStorageSync('openid')
				}).then(data => {
					var [error, res] = data;
					this.UserInfo = res.data
					
					if(!this.UserInfo.IsAgreeAgreement){
						this.$reqUest.post('/api/Favitorinfo/SetUserFavitorInfo',{
							infoId:this.parameter.id,
							mid:this.mid,
							tid:this.IsFavitor,
							url:getCurrentPages()[getCurrentPages().length-1].$page.fullPath
						}).then(data => {
							var [error, res] = data;
							this.IsFavitor=this.IsFavitor==0?1:0
							if(this.IsFavitor==1){
								this.UshowToast("收藏成功")
							}
						})
					}else{
						this.UshowToast("请阅读用户知情同意书并勾选！")
						setTimeout(()=>{
							this.showTYS=false
							setTimeout(()=>{
								this.showTYS=true
							},50)
						},1500)
					}
					
				})
				
			},
			navigateToMiniProgram() {
				uni.navigateToMiniProgram({
					appId: 'wx2d9bd6b6da808d37', //目标小程序的appid
					path: 'pages/index/index', //目标小程序的页面路径
					success(res) {
						
					}
				})
			}
		}
	}
</script>

<style>
	video,image{max-width: 100%;}
	image{ width: 100% !important; }
	._block{ width: 100%; }
</style>
