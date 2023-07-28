<template>
	<view id="box">
		<!-- <official-account  style="width:100%;"></official-account> -->
		<view class="center pr ovh" style="height: 115px;"
			@click="navigateTo('/pages/search','','22471ef7-3520-4773-b7fd-a452f0f6738c')">
			<image class="pa" style="top: 0px; left: 0px; width: 100%; height: 226rpx; " src="../static/homebg.jpg"
				mode="widthFix"></image>
			<view class="pa" style="top: 20px;left: 20px; right: 20px;">
				<input type="text" class="bfff bor100 f14" style="padding: 5px 10px 5px 40px;"
					placeholder-class="c8E8E8E" placeholder="苗懂一下 你就知道" :disabled="true" />
				<view class="pa z3 center iconfont icon-sousuo pa c8E8E8E f18 fb"
					style="top: 0px;left: 0px; height: 100%; width: 40px;"></view>
			</view>
		</view>
		<view class="p1020" style=" margin-top: -65px; z-index: 3; position: relative;">
			<view class="h10"></view>
			<view>
				<view class="bor5 ovh" style="box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.1);">
					<swiper @change="changeBanner" class="insw bor5 ovh bfff" :autoplay="true" :interval="3000"
						:duration="500">
						<swiper-item v-for="(item,index) in bannerData" :key="index">
							<view
								@click="navigateTo(item.F_LinkUrl,item.F_Remark,'421d8faa-88fb-42ff-94ee-0b0b88b06f1d')"
								class="inswLi bor5"
								v-bind:style="{ 'background': 'url('+item.PicUrl+') center center / cover no-repeat #fff' }">
							</view>
						</swiper-item>
					</swiper>
				</view>
				<view class="h15"></view>
				<view class="qhBox center">
					<view class="bor10 b9B9B9B trall3" @click="butNum(index)" v-for="(item, index) in bannerData"
						:key="index" :class="[nowCurrent==index?'on':'']"></view>
				</view>
			</view>
			<view class="h20"></view>
			<view class="h5"></view>
			<view class="innav f12 c535353 tec">
				<view @click="navigateTo('/pages/history','','22471ef7-3520-4773-b7fd-a452f0f6738c')"
					class="center bfff bor5">
					<view class="">
						<view class="center">
							<image style="width: 84rpx; height: 84rpx;"
								src="https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/upload/Group117.png"
								mode="widthFix"></image>
						</view>
						<view class="" style="height: 5rpx;"></view>
						<view style="font-size: 24rpx;">
							品牌故事
						</view>
					</view>
				</view>
				<view @click="navigateTo('/pages/main','','22471ef7-3520-4773-b7fd-a452f0f6738c')"
					class="center bfff bor5">
					<view class="">
						<view class="center">
							<image style="width: 84rpx; height: 84rpx;"
								src="https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/upload/Group1818.png"
								mode="widthFix"></image>
						</view>
						<view class="" style="height: 5rpx;"></view>
						<view style="font-size: 24rpx;">
							疫苗科普
						</view>
					</view>
				</view>
				<view @click="navigateTo('/pages/VaccineTools','','22471ef7-3520-4773-b7fd-a452f0f6738c')"
					class="center bfff bor5">
					<view class="">
						<view class="center">
							<image style="width: 84rpx; height: 84rpx;"
								src="https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/upload/Group122.png"
								mode="widthFix"></image>
						</view>
						<view class="" style="height: 5rpx;"></view>
						<view style="font-size: 24rpx;">
							疫苗工具
						</view>
					</view>
				</view>
				<view
					@click="navigateTo('https://ebook.msdcnmrl.cn/#/?pub_home&sourceId=10001&v=2022121401','','22471ef7-3520-4773-b7fd-a452f0f6738c')"
					class="center bfff bor5">
					<view class="">
						<view class="center">
							<image style="width: 84rpx; height: 84rpx;"
								src="https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/upload/Group1817.png"
								mode="widthFix"></image>
						</view>
						<view class="" style="height: 5rpx;"></view>
						<view style="font-size: 24rpx;">
							疫百科
						</view>
					</view>
				</view>
			</view>
			<view class="clear"></view>
			<view class="h20"></view>
			<view v-if="leftList.length>0">
				<view class="flex alignitems_center justify_between">
					<view class="center">
						<view class="b00857C bor5" style="width: 6px; height: 18px;"></view>
						<view class="w10 h1"></view>
						<view class="c00857C f16">推荐阅读</view>
					</view>
					<view class="center c9AA8B6 f12"
						@click="navigateTo('/pages/main','','7ae118ef-c402-49a8-980b-b113ed955a0d')">
						<view>查看更多</view>
						<view class="w5 h1"></view>
						<view class="iconfont icon-youshuangjiantou"></view>
					</view>
				</view>
				<view class="h20"></view>
				<view class="flex justify_between pblBox">
					<view class="pbll">
						<view class="pr bor5 ovh animated fadeIn bfff pt-page-delay100" v-show="item.imgLoaded"
							v-for="(item,index) in leftList"
							@click="navigateTo('/pages/details?id='+item.F_Id,'','7ae118ef-c402-49a8-980b-b113ed955a0d')">
							<view class="center">
								<image style="width: 100%;" :src="item.PicUrl" mode="widthFix" @load="onSuccessImg(item)">
								</image>
							</view>
							<view class="wbtxt f12 ellipsis">{{item.F_Titile}}</view>
							<view :style="{background: item.F_ChannelColor}" class="pa f12 cfff"
								style="top: 0px; left:0px; line-height: 1; padding: 5px 8px; border-radius: 0px 0px 10px 0px;">
								{{item.F_ChannelOne}}
							</view>
						</view>
					</view>
					<view class="pblr">
						<view class="pr bor5 ovh animated fadeIn bfff pt-page-delay100" v-show="item.imgLoaded"
							v-for="(item,index) in rightList"
							@click="navigateTo('/pages/details?id='+item.F_Id,'','7ae118ef-c402-49a8-980b-b113ed955a0d')">
							<view class="center">
								<image style="width: 100%;" :src="item.PicUrl" mode="widthFix" @load="onSuccessImg(item)">
								</image>
							</view>
							<view class="wbtxt f12 ellipsis">{{item.F_Titile}}</view>
							<view :style="{background: item.F_ChannelColor}" class="pa f12 cfff"
								style="top: 0px; left:0px; line-height: 1; padding: 5px 8px; border-radius: 0px 0px 10px 0px;">
								{{item.F_ChannelOne}}
							</view>
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
			<view class="h20"></view>
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
	export default {
		components: {
			uniLoadMore,
			navT
		},
		data() {
			return {
				currentCityName:"",
				searchtxt: "",
				setval: "",
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

				nowCurrent: 0,
				bannerData: [],
				tabInx: 0,
				tabData: [],
				listData: [],
				// 初始化左右盒子
				leftList: [],
				rightList: [],
				// 初始化左右盒子高度
				leftH: 0,
				rightH: 0,

 
			}
		},
		onLoad() {


			//this.UshowToast("提示")

			this.$reqUest.get('/api/Block/GetBannerByChannelId', {
				channelId: "c9672fe0-5538-47d4-aeff-8507ff2aed36"
			}).then(data => {
				var [error, res] = data;
				this.bannerData = res.data.Data
			})
			this.$reqUest.get('/api/CmsManage/GetChannelInfoByParentId', {
				parentId: "c9672fe0-5538-47d4-aeff-8507ff2aed36"
			}).then(data => {
				var [error, res] = data;
				for (var i = 0; i < 8; i++) {
					this.tabData.push(res.data.Data[i])
				}
				this.getUserLocation()

			})
		},
		onShow() {

		},

		onReachBottom() {
			this.upData()
		},

		methods: {
			postAddress(loginAddress) {
				
				console.log(loginAddress,"loginAddress")
				
				this.currentCityName=loginAddress
				//this.currentCityName="广州"
				
				this.searchinit()
			},
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
			onsearchtxt(e) {
				this.searchtxt = e.detail.value
			},
			search() {
				this.searchinit()
			},
			upSearch() {
				if (this.status == "loading") {
					return
				}
				this.searchtxt = ""
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
					currentCityName:this.currentCityName,
					isRecommand: 1,
					page: this.page,
					psize: this.$conFig.psize
				}

				this.$reqUest.get('/api/Content/GetHomeInfoByChannelId', json).then(data => {
					var [error, res] = data;
					if (res.data.Data) {
						this.listData = [...res.data.Data]
						this.ImageInx = 0
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
	.insw {
		height: 250rpx;
	}

	.inswLi {
		height: 250rpx;
	}

	.qhBox {}

	.qhBox>view {
		width: 5px;
		height: 5px;
		margin-right: 10px;
	}

	.qhBox>view:last-child {
		margin-right: 0px;
	}

	.qhBox>view.on {
		width: 13px;
		background: #049895;
	}

	.intab {}

	.intab>view {
		width: 28%;
	}

	.intab>view.on {
		color: #fff;
		height: 145px;
		background: #00857C;
		border-radius: 5px 5px 0px 0px;
	}

	.inlist {}

	.inlistLi {
		width: calc(50% - 10px);
		margin-right: 20px;
		margin-bottom: 15px;
	}

	.inlist .inlistLi:nth-child(2n) {
		margin-right: 0px;
	}

	.inlistLiimg {
		height: 160rpx;
		border: #fff solid 2px;
	}

	.inlistLiname {}
</style>
