<template>
	<view id="box">
		<view class="pf z3" style="top: 0px; left: 0px; width: 100%; background: #F3F6F8; ">
			<view class="bgbj2" style=" height: 44px;"></view>
			<view class="p1015">
				<view class="h15"></view>
				<view class="c535353 maintab3 f12" style="overflow-x: auto; line-height: 1; width: calc(100% + 20px); padding: 0px 0px 0px 20px; margin-left: -20px; ">
					<view class="flex alignitems_center" style="width: max-content;">
						<view class="bor5" @click="buttab(index)" :class="tabInx==index?'on':''" v-for="(item,index) in tabData">{{item.F_ChannelName}}</view>
					</view>
				</view>
			</view>
		</view>
		<view class="" style="height: 101px;"></view>
		
		<view class="p1020">
			
			<view class="" v-if="listData">
				<view class="h10"></view>
				<view class="colllist">
					<view @click="navigateTo('/pages/details?id='+item.F_Id,'','0cd2da1b-f2cb-42ff-8272-9fb8041ea337')" class="colllistLi bor5 bfff flex pr ovh animated fadeIn" v-for="(item, index) in listData" :key="index">
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
						<view :style="{background: item.F_ChannelColor}" class="pa f12 cfff"
							style="top: 0px; left:0px; line-height: 1; padding: 5px 8px; border-radius: 0px 0px 10px 0px;">
							{{item.F_ChannelOne}}
						</view>
					</view>
				</view>
				<view class="clear"></view>
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
				parameter:{},
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

				tabInx: 0,
				tabData: [],
				listData: [],
			}
		},
		onLoad(e) {
			this.parameter=e
			
			if(this.parameter.id){
				this.tabInx=this.parameter.id
			}
			
			this.$reqUest.get('/api/CmsManage/GetChannelInfoByParentId', {
				parentId: "c0829ae1-bc6a-40b0-8f67-465ea1424239"
			}).then(data => {
				var [error, res] = data;
				this.tabData = res.data.Data
				
				if(this.tabData.length>0){
					
					
					var id=""
					for(var i=0;i<this.tabData.length;i++){
						id+=this.tabData[i].F_Id+","
					}
					id=this.Tagsubstr(id)
					
					this.tabData.unshift({
						F_ChannelName:"全部",
						F_Id:id
					})
				}
				
				
				this.searchinit()
			})
			
			
		},
		onShow() {

		},
		
		onReachBottom() {
			this.upData()
		},
		methods: {
			changeBanner(e) {
				this.nowCurrent = e.detail.current;
			},
			buttab(e) {
				if (this.status == "loading") {
					return
				}
				if (this.tabInx == e) {
					return
				}
				this.tabInx = e
				this.searchinit()
			},
			searchinit() {
				if (this.status == "loading") {
					return
				}
				this.listData = []
				this.page = 1
				this.status = "more"
				this.upData()
			},
			upData() {
				if (this.status == 'noMore') {
					return
				}
				this.status = "loading"

				var json = {
					isRecommand:-1,
					channelId: this.tabData[this.tabInx].F_Id,
					page: this.page,
					psize: this.$conFig.psize
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

			}
		}
	}
</script>

<style>
	.maintab3{}
	.maintab3>view>view{ margin-right: 15px; background: #fff; padding: 5px 15px; }
	.maintab3>view>view.on{ background: #00857C; color: #fff; }
</style>