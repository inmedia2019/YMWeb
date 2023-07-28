<template>
	<view class="pf pagbottom bfff z3">
		
		<view class="botTab flex alignitems_center justify_around c535353 tec f12">
			<view class="pr" :class="tabBar==0?'on':''" style="" @click="reLaunch('/pages/index','','4f32caa1-1dcc-47b7-9116-ece1f485b0b1')">
				<view class="iconfont icon-bianzu c9B9B9B center pa f20"></view>
				<view class="w10" style="height: 40px;"></view>
				<view class="">首页</view>
			</view>
			<view class="pr" :class="tabBar==1?'on':''" style=""
				@click="reLaunch('/pages/main','','4f32caa1-1dcc-47b7-9116-ece1f485b0b1')">
				<view class="iconfont icon-a-lujing8 c9B9B9B center pa f20">
					
				</view>
				<view class="w10" style="height: 40px;"></view>
				<view class="">疫苗科普</view>
			</view>
			<view class="pr" :class="tabBar==2?'on':''" style=""
				@click="reLaunch('/pages/history','','4f32caa1-1dcc-47b7-9116-ece1f485b0b1')">
				<view class="iconfont icon-bianzu-2 c9B9B9B center pa f20">
					
				</view>
				<view class="w10" style="height: 40px;"></view>
				<view class="">品牌故事</view>
			</view>
			<view class="pr" :class="tabBar==3?'on':''" style=""
				@click="reLaunch('/pages/Collection','','4f32caa1-1dcc-47b7-9116-ece1f485b0b1')">
				<view class="iconfont icon-xingzhuang1 c9B9B9B center pa f20">
					
				</view>
				<view class="w10" style="height: 40px;"></view>
				<view class="">我的</view>
			</view>
		</view>
		
	</view>
</template>

<script>
	export default {
		data() {
			return {
				tabBar:0
			}
		},
		mounted() {
			var url=getCurrentPages()[getCurrentPages().length-1].route
			var data=["pages/index",'pages/main','pages/history','pages/Collection']
			for(var i=0;i<data.length;i++){
				if(url.indexOf(data[i])>=0){
					this.tabBar=i
				}
			}
		},
		onLoad() {
			
		},
		methods: {

		}
	}
</script>

<style>
</style>