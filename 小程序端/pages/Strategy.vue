<template>
	<view class="">
		<view class="pf z3 flex alignitems_center bgbj2 cfff"
			style="top: 0px; left: 0px; right: 0px; padding: 5px 15px;">
			<view class="pr" @click="navigateTo('/pages/search','','88041be9-5c5e-4530-a3eb-c759765feb42')"
				style="width: 120px;">
				<input type="text" class="bfff bor100 f14"
					style="padding: 5px 10px 5px 40px;border: 1px solid rgba(255, 255, 255, 0.2);background: rgba(255, 255, 255, 0.1); "
					placeholder-style="color: rgba(255,255,255,0.6);" placeholder="HPV科普" :disabled="true" />
				<view class="pa z3 center iconfont icon-a-sousuo1 pa cfff f18"
					style="top: 0px;left: 3px; height: 100%; width: 40px;"></view>
			</view>
			<view class="center f12" style="width: calc(100% - 240px); line-height: 1;">
				<picker class="" @change="bindPickerChange" :range="array" range-key="F_CityName">
					<view class="center" style="width: 100%; height: 34px; ">
						<view style="margin-right: 5px;">{{array[arrayInx].F_CityName}}</view>
						<view class="iconfont icon-xiangxiajiantou"></view>
					</view>
				</picker>
			</view>
			<view class="flex f12 justify_end alignitems_center" style="width: 120px; line-height: 1; height: 34px; "
				@click="navigateTo('pages/index/index','wx2d9bd6b6da808d37','88041be9-5c5e-4530-a3eb-c759765feb42')">
				<view class="iconfont icon-weizhi"></view>
				<view style="margin-left: 5px;">查看地图</view>
			</view>
		</view>

		<view style="height: 50px;"></view>
		<view class="p1015">
			<view class="">
				<view @click="navigateTo('/pages/details?id='+item.F_Id,'','88041be9-5c5e-4530-a3eb-c759765feb42')"
					class="bfff animated fadeIn ovh"
					style="border-radius: 8px; margin-bottom: 15px;box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.1); "
					v-for="(item, index) in listData" :key="index">
					<view class="pr center">
						<image style="width: 100%;" :src="item.PicUrl" mode="widthFix"></image>
						<view class="pa f12 cfff b00857C cfff center"
							style="top: 0px; left:0px; line-height: 1; border-radius: 0px 0px 5px 0px; padding: 7px 10px; ">
							<view class="iconfont icon-weizhi"></view>
							<view class="" style="margin-left: 5px;">{{item.F_CityName}}</view>
						</view>
					</view>
					<view class="" style="padding: 10px 15px;">
						{{item.F_Titile}}
					</view>

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
		</view>
	</view>
</template>

<script>
	import uniLoadMore from '@/components/uni-load-more/uni-load-more.vue'
	

	export default {
		components: {
			uniLoadMore
		},
		data() {
			return {
				array: [],
				arrayInx: 0,
				listData: [],
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
			
			
			this.$reqUest.get('/api/CityInfo/GetCityInfo').then(data => {
				var [error, res] = data;
				this.array = res.data.Data

				this.array.unshift({
					F_CityName: "全国",
					F_Id: ""
				})

				if (e.id) {
					for (var i = 0; i < this.array.length; i++) {
						if (e.id == this.array[i].F_Id) {
							this.arrayInx = i
						}
					}
				}

				this.upData()
			})

			//
		},
		onShow() {

		},
		onReachBottom() {
			this.upData()
		},

		methods: {
			bindPickerChange(e) {
				this.arrayInx = e.detail.value
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
					channelId: "dc3944f1-b596-4e4f-8326-5eb4d67d1e10",
					page: this.page,
					psize: this.$conFig.psize
				}

				if (this.arrayInx > 0) {
					json.cityId = this.array[this.arrayInx].F_Id
				}

				this.$reqUest.get("/api/Content/GetInfoByChannelId", json).then(data => {
					var [error, res] = data;

					if (res.data.Data) {
						this.listData = [...this.listData, ...res.data.Data]

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
			},
		}
	}
</script>

<style>
</style>
