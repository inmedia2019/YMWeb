<template>
	<view id="box">
		<view class="">
			<view class="pf z3" style="top: 0px; left: 0px; width: 100%; ">
				<view class="bgbj2" style=" height: 44px;"></view>
				<view class="bfff mainNav flex alignitems_center f14 pr" style="height: 55px;">
					<view class="center pr" :class="tabInx==0?'on':''" @click="buttab(0)">
						<view class="center">
							<view class="iconfont icon-a-zu21 f18"></view>
							<view class="w10 h1"></view>
							<view class="">我的收藏</view>
						</view>
						<text class="pa bgbj2"></text>
					</view>
					<view class="center pr" :class="tabInx==1?'on':''" @click="buttab(1)">
						<view class="center">
							<view class="iconfont icon-lujing f18"></view>
							<view class="w10 h1"></view>
							<view class="">历史浏览</view>
						</view>
						<text class="pa bgbj2"></text>
					</view>
				</view>
			</view>
			<view class="" style="height: 110px;"></view>
			<view class="p1020">
				<view class="h10"></view>
				<view class="colllist">
					<view @click="navigateTo('/pages/details?id='+(tabInx==1?item.F_Id:item.infoId),'',tabInx==1?'14234029-c3bb-4c49-9be9-01736ed7a8b5':'1bb25cb5-870d-46fb-8a44-e61c7b016faf')" class="colllistLi bor5 bfff flex pr ovh animated fadeIn" v-for="(item, index) in listData" :key="index">
						<view class="colllistLiimg bor5" v-bind:style="{ 'background': 'url('+item.PicUrl+') center center / cover no-repeat #fff' }"></view>
						<view class="colllistLinr">
							<view style="height: 59px;">
								<view class="f14 c4A4A4A ellipsis2" style="max-height: 42px;">{{tabInx==1?item.F_Titile:item.infoTitle}}</view>
								<view class="h5"></view>
								<view class="f12 c000" style="opacity: 0.25;">{{$conFig.dateformat3(item.F_PublishTime)}}</view>
							</view>
							<!-- <view class="flex alignitems_center justify_end c4A4A4A f12">
								<view class="iconfont icon-a-lujing9 c00857C"></view>
								<view class="w5 h1"></view>
								<view class="" style="opacity: 0.3;">{{tabInx==1?item.F_FavoritesCount:item.FNum}}</view>
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
			<boTtom :scroll="scrollTop"></boTtom>
			<view class="h20"></view>
			<view class="h20"></view>
			<view class="h20"></view>
			<navT></navT>
		</view>
		<view>
			
		</view>
	</view>
	
	
</template>

<script>
	import navT from '@/components/nav/nav.vue'
	import uniLoadMore from '@/components/uni-load-more/uni-load-more.vue'
	import uniSection from '@/components/uni-section/uni-section.vue'
	export default {
		components: {
			uniLoadMore,
			uniSection,
			navT
		},
		data() {
			return {
				tabInx:0,
				tabData:[{
					InfoTitle:"全部",
					FavitorTypeId:""
				}],
				listData:[],
				
				
				
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
			}
		},
		onLoad(e) {
			
			this.searchinit()
			
		},
		onReachBottom(){
		　　this.upData()
		},
		methods: {
			buttab(e){
				if(this.status=="loading"){
					return
				}
				if(this.tabInx==e){
					return
				}
				this.tabInx=e
				this.searchinit()
			},
			searchinit(){
				//console.log("--------")
				this.listData=[]
				this.page=1
				this.status="more"
				this.upData()
			},
			upData() {
				
				if(this.status=='noMore'){
					return
				}
				this.status="loading"
				
				var url="/api/Favitorinfo/GetFavitorInfoByMidAndParentId"
				
				
				
				var json={
					mid:this.mid,
					page: this.page,
					psize: this.$conFig.psize
				}
				
				
				if(this.tabInx==1){
					url="/api/Content/GetHistoryByMid"
					json.tid=0
				}
				
				this.$reqUest.get(url,json).then(data => {
					var [error, res] = data;
					
					if(res.data.Data){
						this.listData=[...this.listData, ...res.data.Data]
						this.page++
						if(res.data.Data.length<this.$conFig.psize){
							this.status='noMore'
							return
						}else{
							this.status='more'
						}
					}else{
						
						this.status='noMore'
					}
					
				})
			},
		}
	}
</script>

<style>
	.collTop{ top:0px;left: 0px; right: 0px;overflow-x: auto; }
	.collTopli{ opacity: 0.7;background: rgba(255, 255, 255, 0.2); border: #fff solid 1px; padding: 3px 15px;margin-right: 10px; }
	.collTopli.on{ opacity: 1; color: #00857C;background: rgba(255, 255, 255, 1); }
	
	
	
	.mainNav{}
	.mainNav>view{ padding: 14px 0px 15px 0px; width: 50%; }
	.mainNav>view.on{ color: #00857C; font-weight: bold; }
	.mainNav>view.on text{ bottom: 0px; left: 0px; width: 100%; height: 4px; }
</style>