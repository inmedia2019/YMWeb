<template>
	<view class="" id="box">
		<view class="pf z3 ovh" style="top: 0px; left: 0px; width: 100%; height: 70px;">
			<image class="pa" style="top: 0px; left: 0px; width: 100%; height: 226rpx; " src="../static/homebg.jpg" mode="widthFix"></image>
			<view class="pr" style=" height: 70px; z-index: 3;">
				<view class="pa" style="top: 20px;left: 20px; right: 20px;">
					<input type="text" class="bfff bor100 f14" style="padding: 5px 70px 5px 40px;"
						placeholder-class="c8E8E8E" placeholder="苗懂一下 你就知道" @input="onsearchtxt" @confirm="search" :value="searchtxt" />
					<view class="pa z3 center iconfont icon-sousuo pa c8E8E8E f18 fb"
						style="top: 0px;left: 0px; height: 100%; width: 40px;"></view>
					<view @click="search" class="pa cfff center" style=" line-height: 1; z-index: 3; bottom: 0px; right: 0px; top:0px; width: 60px; background: #00857C; border-radius: 0px 100px 100px 0px; ">搜索</view>
				</view>
			</view>
		</view>
		<view class="" style="height: 70px;"></view>
		<view class="p1015">
			<view class="" v-if="!issearch">
				<view v-if="HotKey">
					<view class="h5"></view>
					<view class="c768196">热门搜索</view>
					<view class="h5"></view>
					<view class="hotList f12">
						<view class="bor5" v-for="(item,index) in HotKey" @click="searchtxt=item.F_Name;search()">{{item.F_Name}}</view>
					</view>
				</view>
				
				
				<view v-if="searchData&&searchData.length>0">
					<view class="h20"></view>
					<view class="h5"></view>
					<view class=" flex alignitems_center justify_between">
						<view class="c768196">搜索记录</view>
						<view class="f12 c9B9B9B" @click="removeStorage(-1)">清除历史</view>
					</view>
					<view class="h5"></view>
					<view class="">
						<view class="flex alignitems_center" style="height: 50px;" v-for="(item,index) in searchData">
							<view @click="searchtxt=item.txt;search()" class="flex alignitems_center" style="width: calc(100% - 50px);">
								<view class="center iconfont icon-sousuo c768196 pr" style=" margin-top: 2px;"></view>
								<view class="w10 h1"></view>
								<view class="ellipsis" style="color: #0D0E15; width: calc(100% - 24px);">{{item.txt}}</view>
							</view>
							<view class="center iconfont icon-guanbi f12" style="height: 30px; width: 50px;" @click="removeStorage(index)"></view>
						</view>
					</view>
				</view>
			</view>
			<view v-if="issearch">
				<view class="colllist">
					<view @click="navigateTo('/pages/details?id='+item.F_Id,'','24988c40-2eda-4177-83b6-df3a50b0e32b')" class="colllistLi bor5 bfff flex pr ovh animated fadeIn" v-for="(item, index) in listData" :key="index">
						<view class="colllistLiimg bor5" v-bind:style="{ 'background': 'url('+item.PicUrl+') center center / cover no-repeat #fff' }"></view>
						<view class="colllistLinr">
							<view style="height: 59px;">
								<view class="f14 c4A4A4A ellipsis2" style="max-height: 42px;">{{item.F_Titile}}</view>
								<view class="h5"></view>
								<view class="f12 c000" style="opacity: 0.25;">{{$conFig.dateformat3(item.F_PublishTime)}}</view>
							</view>
							<!-- <view class="flex alignitems_center justify_end c4A4A4A f12">
								<view class="iconfont icon-a-lujing9 c00857C"></view>
								<view class="w5 h1"></view>
								<view class="" style="opacity: 0.3;">{{item.F_FavoritesCount}}</view>
							</view> -->
						</view>
						<view class="pa f12 cfff" :style="{background: item.F_ChannelColor}" style="top: 0px; left:0px; line-height: 1; padding: 5px 10px 5px 10px; border-radius: 0px 0px 5px 0px; ">{{item.F_ChannelOne}}</view>
					</view>
				</view>
				<uni-load-more iconType="circle" :status="status" />
				<view class="center" style="height: 300px;" v-if="listData.length==0&&status=='noMore'">
					<view class="">
						<view class="center m0auto">
							<image style="width: 99px; height: 116px; " src="../static/zwxx.png" mode="widthFix"></image>
						</view>
						<view class="h10"></view>
						<view class="tec" style="color: #000; opacity: 0.3; ">暂无信息内容哦~</view>
					</view>
				</view>
				<view class="h20"></view>
			</view>
		</view>
		<boTtom :scroll="scrollTop"></boTtom>
		<view class="h20"></view>
		<view class="h20"></view>
		<view class="h20"></view>
	</view>
</template>

<script>
	import uniLoadMore from '@/components/uni-load-more/uni-load-more.vue'
	import uniSection from '@/components/uni-section/uni-section.vue'
	export default {
		components: {
			uniLoadMore,
			uniSection
		},
		data() {
			return {
				issearch:false,
				HotKey:"",
				searchtxt: "",
				searchData:uni.getStorageSync('searchData'),
				
				page: 1,
				status: 'more',
				isUpdata: true,
				statusTypes: [{
					value: 'more',
					text: '加载前',
					checked: true
				}, {
					value: 'loading',
					text: '加载中',
					checked: false
				}, {
					value: 'noMore',
					text: '没有更多',
					checked: false
				}],
				listData: [],
			}
		},
		onLoad() {
			this.GetHotHeyWordInfo()
		},
		onShow() {

		},
		onReachBottom() {
			if (this.status == 'loading') {
				return
			}
			this.status = "more"
			this.upData()
		},
		methods: {
			GetHotHeyWordInfo(){
				this.$reqUest.get('/api/HotKeyWord/GetHotHeyWordInfo').then(data => {
					var [error, res] = data;
					if(res.data.Result){
						this.HotKey=res.data.Data
					}
					
				})
			},
			
			onsearchtxt(e){
				this.searchtxt = e.detail.value
			},
			search(){
				if(this.searchtxt==""){
					this.issearch=false
					return
				}
				
				this.searchinit()
				this.issearch=true
				if(!this.UserInfo.IsAgreeAgreement){
					this.upStsearch()
				}
			},
			searchinit() {
				if (this.status == "loading") {
					return
				}
				this.AddUserAction("",1,this.searchtxt)
				this.listData = []
				this.page = 1
				this.status = "more"
				this.upData()
			},
			upData() {
				if (this.status == 'loading') {
					return
				}
				this.status = "loading"
			
				var json = {
					isRecommand:-1,
					page: this.page,
					psize: this.$conFig.psize
				}
				if (this.searchtxt) {
					json.keyWord = this.searchtxt
				}
			
				this.$reqUest.get('/api/Content/GetInfoByChannelId', json).then(data => {
					var [error, res] = data;
					if (res.data.Data) {
						this.listData = [...this.listData,...res.data.Data]
						this.page++
						if (res.data.Data.length < this.$conFig.psize) {
							this.status = 'noMore'
							return
						} else {
							this.status = 'more'
						}
					} else {
						this.status = 'noMore'
					}
				})
			
			},
			upStsearch(){
				this.searchData=[]
				var searchData=uni.getStorageSync('searchData')
				if(searchData.length>0){
					for(var i=0;i<searchData.length;i++){
						if(searchData[i].txt!=this.searchtxt){
							this.searchData.push(searchData[i])
						}
					}
				}
				this.searchData.unshift({
					txt:this.searchtxt,
					data:Date.parse(new Date())
				})
				uni.setStorage({
					key: 'searchData',
					data: this.searchData
				});
			},
			removeStorage(e){
				var that=this
				if(e<0){
					this.searchData=[]
					uni.removeStorage({
						key: 'searchData',
						success: function (res) {
							
						}
					});
				}else{
					this.searchData.splice(e,1)
				}
				uni.setStorage({
					key: 'searchData',
					data: this.searchData
				});
			}
		}
	}
</script>

<style>
	.hotList{ overflow: hidden; }
	.hotList>view{ float: left; line-height: 1; background: #DAE2EB; padding: 4px 10px; margin-right: 15px; margin-bottom: 15px; color: #597ba5; }
	
</style>