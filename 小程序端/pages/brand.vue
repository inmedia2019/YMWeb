<template>
	<view class="" id="box">
		<view class="pf z3" style="width: 100%; left:0px; top: 0px; ">
			<view class="bgbj2" style=" height: 44px;"></view>
		</view>
		<view style="height: 44px;"></view>
		<view class="p1020">
			
			<view class="">
				<view class="h10"></view>
				<view class="bralist" v-if="listData">
					<view @click="navigateTo('/pages/details?id='+item.F_Id,'','7f088af2-3fad-4b75-86c2-28186a1e73ff')" class="bralistli bor5 bfff ovh animated fadeIn" v-for="(item,index) in listData">
						<view style=" height: 266rpx;" v-bind:style="{ 'background': 'url('+item.PicUrl+') center center / cover no-repeat #fff' }"></view>
						<view class="p1020">
							<view class="f15 fb">{{item.F_Titile}}</view>
							<view class="h3"></view>
							<view class="flex alignitems_center justify_between f12 c9B9B9B">
								<view class="">{{$conFig.dateformat3(item.F_PublishTime)}}</view>
								<!-- <view class="center">
									<view class="center iconfont icon-liulan" style="line-height: 1;"></view>
									<view class="w5 h1"></view>
									<view>386</view>
								</view> -->
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
		<navT></navT>
	</view>
</template>

<script>
	import navT from '@/components/nav/nav.vue'
	import uniLoadMore from '@/components/uni-load-more/uni-load-more.vue'
	import uniSection from '@/components/uni-section/uni-section.vue'
	export default {
		components: {
			navT
		},
		data() {
			return {
				listData:[],
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
			}
		},
		onLoad() {
			this.upData()
		},
		onShow() {

		},
		onReachBottom() {
			this.upData()
		},
		methods: {
			upData() {
				if (this.status == 'noMore') {
					return
				}
				this.status = "loading"
			
				var json = {
					isRecommand:-1,
					channelId: "48b7efd0-5576-4828-942c-df18db031297",
					page: this.page,
					psize: this.$conFig.psize
				}
			
				this.$reqUest.get('/api/Content/GetInfoByChannelId', json).then(data => {
					var [error, res] = data;
					if (res.data.Data) {
						this.page++
						this.listData = [...this.listData,...res.data.Data]
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
	.bralist{}
	.bralist .bralistli{ box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.1); margin-bottom: 25px; }
	.bralist .bralistli{}
</style>