<template>
	<view class="" v-if="tabData" id="box">
		<view class="pf z3" style="width: 100%; left:0px; top: 0px; ">
			<view class="bgbj2" style=" height: 44px;"></view>
			<view class="bfff mainNav flex alignitems_center f16" style="height: 55px;">
				<view class="center pr" @click="butTab(index)" :class="tabInx==index?'on':''" v-for="(item,index) in tabData">{{item.F_ChannelName}}<text class="pa bgbj2"></text></view>
			</view>
		</view>
		<view style="height: 100px;"></view>
		<view class="p1020">
			<view class="" v-if="tab2Data">
				<view class="h10"></view>
				<view class="c535353 maintab2" style="overflow-x: auto; line-height: 1; width: calc(100% + 20px); padding: 0px 0px 0px 20px; margin-left: -20px; ">
					<view class="flex alignitems_center" style="width: max-content;">
						<view class="bor5" @click="but2Tab(index)" :class="tab2Inx==index?'on':''" v-for="(item,index) in tab2Data">{{item.F_ChannelName}}</view>
					</view>
				</view>
				<view v-if="tab3Data">
					<view class="h20"></view>
					<view class="c535353 maintab3 f12" style="overflow-x: auto; line-height: 1; width: calc(100% + 20px); padding: 0px 0px 0px 20px; margin-left: -20px; ">
						<view class="flex alignitems_center" style="width: max-content;">
							<view class="bor5" @click="but3Tab(index)" :class="tab3Inx==index?'on':''" v-for="(item,index) in tab3Data">{{item.F_ChannelName}}</view>
						</view>
					</view>
				</view>
				<view class="h10"></view>
			</view>
			<view class="">
				<view class="h15"></view>
				<view class="flex justify_between pblBox">
					<view class="pbll">
						<view class="pr bor5 ovh animated fadeIn bfff pt-page-delay100" v-show="item.imgLoaded" v-for="(item,index) in leftList"
							@click="navigateTo('/pages/details?id='+item.F_Id,'','1b74cb64-86a6-47c5-81fc-0cccff861049')">
							<view class="center">
								<image style="width: 100%;" :src="item.PicUrl" mode="widthFix" @load="onSuccessImg(item)"></image>
							</view>
							<view class="wbtxt f12 ellipsis">{{item.F_Titile}}</view>
							<view :style="{background: item.F_ChannelColor}" class="pa f12 cfff"
								style="top: 0px; left:0px; line-height: 1; padding: 5px 8px; border-radius: 0px 0px 10px 0px;">
								{{item.F_ChannelOne}}
							</view>
						</view>
					</view>
					<view class="pblr">
						<view class="pr bor5 ovh animated fadeIn bfff pt-page-delay100" v-show="item.imgLoaded" v-for="(item,index) in rightList"
							@click="navigateTo('/pages/details?id='+item.F_Id,'','1b74cb64-86a6-47c5-81fc-0cccff861049')">
							<view class="center">
								<image style="width: 100%;" :src="item.PicUrl" mode="widthFix" @load="onSuccessImg(item)"></image>
							</view>
							<view class="wbtxt f12 ellipsis">{{item.F_Titile}}</view>
							<view :style="{background: item.F_ChannelColor}" class="pa f12 cfff"
								style="top: 0px; left:0px; line-height: 1; padding: 5px 8px; border-radius: 0px 0px 10px 0px;">
								{{item.F_ChannelOne}}
							</view>
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
				<boTtom :scroll="scrollTop"></boTtom>
				<view class="h10"></view>
				<view class="h20"></view>
				<view class="h10"></view>
				<view class="h20"></view>
				<view class="h20"></view>
				<view class="h20"></view>
				<view class="h20"></view>
				<view class="h20"></view>
			</view>
		</view>
		<navT></navT>
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
				parameter:{},
				tabInx:0,
				tabData:[],
				
				tab2Inx:0,
				tab2Data:"",
				
				tab3Inx:0,
				tab3Data:"",
				
				page: 1,
				status: 'more',
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
				// 初始化左右盒子
				leftList: [],
				rightList: [],
				// 初始化左右盒子高度
				leftH: 0,
				rightH: 0
			}
		},
		onLoad(e) {
			this.parameter=e
			//console.log(this.parameter)
			//this.parameter.tab2=3
			this.uptabData()
		},
		onShow() {

		},
		methods: {
			uptabData(){
				if (this.status == "loading") {
					return
				}
				this.$reqUest.get('/api/CmsManage/GetChannelInfoByParentId', {
					parentId: "c9672fe0-5538-47d4-aeff-8507ff2aed36"
				}).then(data => {
					var [error, res] = data;
					if(res.data.Result){
						this.tabData.push(res.data.Data[4])
						this.tabData.push(res.data.Data[5])
						this.tabData.push(res.data.Data[6])
						this.tabData.push(res.data.Data[7])
						
						this.butTab(this.parameter.id?this.parameter.id:0)
					}else{
						this.init()
					}
					
				})
			},
			butTab(index){
				
				if (this.status == "loading") {
					return
				}
				this.tab2Data=""
				this.tab3Data=""
				this.tabInx=index
				
				this.$reqUest.get('/api/CmsManage/GetChannelInfoByParentId', {
					parentId: this.tabData[this.tabInx].F_Id
				}).then(data => {
					var [error, res] = data;
					
					if(res.data.Result){
						this.tab2Data=[]
						this.tab2Data = res.data.Data
						
						var id=""
						for(var i=0;i<this.tab2Data.length;i++){
							id+=this.tab2Data[i].F_Id+","
						}
						
						id=this.Tagsubstr(id)
						
						this.tab2Data.unshift({
							F_ChannelName:"全部",
							F_Id:id
						})
						this.but2Tab(this.parameter.tab2?this.parameter.tab2:0)
					}else{
						this.init()
					}
				})
			},
			but2Tab(index){
				if (this.status == "loading") {
					return
				}
				this.tab3Data=""
				this.tab2Inx=index
				if(this.tab2Inx==0){
					this.init()
					return
				}
				
				this.$reqUest.get('/api/CmsManage/GetChannelInfoByParentId', {
					parentId: this.tab2Data[this.tab2Inx].F_Id
				}).then(data => {
					var [error, res] = data;
					
					if(res.data.Result){
						this.tab3Data=[]
						this.tab3Data = res.data.Data
						
						var id=""
						for(var i=0;i<this.tab3Data.length;i++){
							id+=this.tab3Data[i].F_Id+","
						}
						
						id=this.Tagsubstr(id)
						
						this.tab3Data.unshift({
							F_ChannelName:"全部",
							F_Id:id
						})
						this.init()
						
					}else{
						this.init()
					}
					
				})
			},
			but3Tab(index){
				if (this.status == "loading") {
					return
				}
				this.tab3Inx=index
				if(this.tab3Inx==0){
					this.init()
					return
				}
				
				this.init()
			},
			init() {
				this.listData = []
				this.leftList= []
				this.rightList= []
				// 初始化左右盒子高度
				this.leftH= 0
				this.rightH= 0
				
				this.page = 1
				this.status = "more"
				this.upData()
			},
			upData(){
				if (this.status == 'noMore') {
					return
				}
				this.status = "loading"
				
				var channelId=""
				
				
				if(this.tabData){
					channelId=this.tabData[this.tabInx].F_Id
				}
				
				if(this.tab2Data){
					channelId=this.tab2Data[this.tab2Inx].F_Id
				}
				
				if(this.tab3Data){
					channelId=this.tab3Data[this.tab3Inx].F_Id
				}
				
				
				var json = {
					isRecommand:-1,
					channelId:channelId,
					page: this.page,
					psize: this.$conFig.psize
				}
				
				this.$reqUest.get('/api/Content/GetInfoByChannelId', json).then(data => {
					var [error, res] = data;
					if (res.data.Data) {
						this.listData = [...res.data.Data]
						this.ImageInx=0
						this.doList()
						if (res.data.Data.length < this.$conFig.psize) {
							this.status = 'noMore'
							return
						} else {
							this.status = 'more'
							this.page++
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
	.mainNav{}
	.mainNav>view{ padding: 18px 0px 15px 0px; width: 25%; }
	.mainNav>view.on{ color: #00857C; font-weight: bold; }
	.mainNav>view.on text{ bottom: 0px; left: 0px; width: 100%; height: 4px; }
	
	.maintab2{}
	.maintab2>view>view{ margin-right: 5px; padding: 8px 10px; }
	.maintab2>view>view.on{ background: #00857C; color: #fff; }
	
	.maintab3{}
	.maintab3>view>view{ margin-right: 15px; padding: 5px 15px; }
	.maintab3>view>view.on{ background: #6ECEB2; color: #fff; }
</style>