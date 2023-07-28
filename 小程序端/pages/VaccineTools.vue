<template>
	<view class="p1015">
		<view class="pf" style="top: 0px; left: 0px; right: 0px; z-index: 10;background: #F3F6F8; ">
			<view class="p1015" style="padding: 10px 15px 0px 15px;">
				<view class="center bor5 ovh" @click="navigateTo('pages/index/index','wx2d9bd6b6da808d37','d9377749-8e90-43d4-86f9-4936845d06b7')">
					<image style="height: 256rpx;" class="w100" src="https://msdym.atline.cn/ymweb/upload/image/2022/08/6379704025236671471582712.jpg" mode="widthFix"></image>
				</view>
			</view>
		</view>
		<view style="height: 256rpx;"></view>
		<view class="h10"></view>
		<view class="pr" @click="navigateTo('/pages/search','','d9377749-8e90-43d4-86f9-4936845d06b7')">
			<input type="text" class="bfff bor100 f14" style="padding: 10px 10px 10px 40px;border: #6ECEB2 solid 1px; "
				placeholder-class="c8E8E8E" placeholder="HPV科普" :disabled="true" />
			<view class="pa z3 center iconfont icon-a-sousuo1 pa c00857C f18"
				style="top: 0px;left: 3px; height: 100%; width: 40px;"></view>
		</view>
		<view class="h10"></view>
		<view class="pr" style="height: 394rpx;" v-if="columnData">
			<view style="height: 0px;">
				<image style="width: calc(100% + 30px); margin-left: -15px;height: 394rpx;" :src="'https://yimiaomini.oss-cn-hangzhou.aliyuncs.com/upload/va'+(tabInx==1?'1ss':'2')+'.png'" mode="widthFix"></image>
			</view>
			<view class="pr z3">
				<view class="h10"></view>
				<view class="ovh">
					<view class="fl" @click="tabInx=1" style="height: 80rpx; width: 45%; "></view>
					<view class="fr" @click="tabInx=2" style="height: 80rpx; width: 45%; "></view>
				</view>
				<view class="pr" v-if="tabInx==1">
					<view class="pa center" style="color: #00857c; top: 30rpx; left: 80rpx; ">
						<view class="" style=" font-size: 28rpx;"><!-- {{columnData[0].F_Name}} -->广州</view>
						<view class="iconfont icon-xiangxiajiantou center r90s" style="line-height:1px; font-size: 24rpx; margin-left: 16rpx; "></view>
					</view>
					<view class="pa center" style="color: #00857c; top: 116rpx; left: 80rpx; ">
						<view class="" style=" font-size: 28rpx;"><!-- {{columnData[1].F_Name}} -->上海</view>
						<view class="iconfont icon-xiangxiajiantou center r90s" style="line-height:1px; font-size: 24rpx; margin-left: 16rpx; "></view>
					</view>
					<view class="" style="height: 22rpx; width: 50%;"></view>
					<!-- <view class="z3 pr" @click="navigateTo('/pages/Strategy?id='+columnData[0].F_Id,'','d9377749-8e90-43d4-86f9-4936845d06b7')" style="height: 60rpx; width: 50%;"></view>
					<view class="" style="height: 22rpx; width: 50%;"></view>
					<view class="z3 pr" @click="navigateTo('/pages/Strategy?id='+columnData[1].F_Id,'','d9377749-8e90-43d4-86f9-4936845d06b7')" style="height: 60rpx; width: 50%;"></view>
					<view class="" style="height: 22rpx; width: 50%;"></view> -->
					<view class="z3 pr" @click="navigateTo('/pages/Strategy?id=575ef54e-d2f9-44cc-bb3b-a2c31279772b','','d9377749-8e90-43d4-86f9-4936845d06b7')" style="height: 60rpx; width: 50%;"></view>
					<view class="" style="height: 22rpx; width: 50%;"></view>
					<view class="z3 pr" @click="navigateTo('/pages/Strategy?id=7d436d7e-97a4-4b30-934f-98460b1db307','','d9377749-8e90-43d4-86f9-4936845d06b7')" style="height: 60rpx; width: 50%;"></view>
					<view class="" style="height: 22rpx; width: 50%;"></view>
					<view class="z3 pr" @click="navigateTo('/pages/Strategy','','d9377749-8e90-43d4-86f9-4936845d06b7')" style="height: 60rpx; width: 50%;"></view>
				</view>
				<view v-if="tabInx==2">
					<view class="" style="height: 80rpx; width: 50%;"></view>
					<view class="" @click="navigateTo('/pages/QA','','d9377749-8e90-43d4-86f9-4936845d06b7')" style="height: 80rpx; width: 50%;"></view>
				</view>
			</view>
		</view>
		<view class="h5"></view>
		<view class="">
			<view class="">
				<view @click="navigateTo('/pages/details?id='+item.F_Id,'','d9377749-8e90-43d4-86f9-4936845d06b7')" class="bfff animated fadeIn ovh" style="border-radius: 8px; margin-bottom: 15px;box-shadow: 0px 10px 10px rgba(0, 0, 0, 0.1); " v-for="(item, index) in listData" :key="index">
					<view class="pr center">
						<image style="width: 100%;" :src="item.PicUrl" mode="widthFix"></image>
						<view class="pa f12 cfff b00857C cfff center" style="top: 0px; left:0px; line-height: 1; border-radius: 0px 0px 5px 0px; padding: 7px 10px; ">
							<view class="iconfont icon-weizhi"></view>
							<view class="" style="margin-left: 5px;">{{item.F_CityName}}</view>
						</view>
					</view>
					<view class="" style="padding: 10px 15px;">
						{{item.F_Titile}}
					</view>
					
				</view>
			</view>
		</view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				tabInx:1,
				listData:[],
				columnData:""
			}
		},
		onLoad() {
			
			this.getUserLocation()
			
			
		},
		onShow() {

		},
		onReachBottom() {
			
		},
		 
		methods: {
			postAddress(loginAddress) {
				this.currentCityName=loginAddress
				console.log(this.currentCityName)
				this.$reqUest.get("/api/CityInfo/GetCityIdByChannelId",{
					channel:"dc3944f1-b596-4e4f-8326-5eb4d67d1e10",
					cityName:this.currentCityName
				}).then(data => {
					var [error, res] = data;
					
					if(res.data.Data){
						this.columnData=res.data.Data
					}else{
					}
					
				})
				
				var json = {
					channelId: "dc3944f1-b596-4e4f-8326-5eb4d67d1e10",
					currentCityName:this.currentCityName,
					page: 1,
					psize: 2
				}
				
				this.$reqUest.get("/api/Content/GetHomeInfoByChannelId",json).then(data => {
					var [error, res] = data;
					
					if(res.data.Data){
						this.listData=[...this.listData, ...res.data.Data]
						
						
					}else{
						
						this.status='noMore'
					}
					
				})
			},
		}
	}
</script>

<style>
	page{ background: #F3F6F8; }
	.missAngle{
	    background: linear-gradient(-134deg, transparent 28px, #E1E7EB 0);
		border-radius: 5px 0px 0px 0px;
	}
	
	.missAngle.on{
	    background: linear-gradient(-134deg, transparent 28px, #fff 0);
	}
	.missAngle2{
	    background: linear-gradient(132deg, transparent 28px, #E1E7EB 0);
		border-radius: 5px 0px 0px 0px;
	}
	.missAngle2.on{
	    background: linear-gradient(132deg, transparent 28px, #fff 0);
	}
</style>