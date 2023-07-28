<template>
	<view>
		<view class="pf z3 flex alignitems_center bgbj2 cfff" style="top: 0px; left: 0px; right: 0px; padding: 5px 15px;">
			<view class="pr" @click="navigateTo('/pages/search','','c7fbc372-d50b-48c1-8ba0-72961604c0df')" style="width: calc(100% - 120px);">
				<input type="text" class="bfff bor100 f14" style="padding: 5px 10px 5px 40px;border: 1px solid rgba(255, 255, 255, 0.2);background: rgba(255, 255, 255, 0.1); "
					 placeholder-style="color: rgba(255,255,255,0.6);" placeholder="HPV科普" :disabled="true" />
				<view class="pa z3 center iconfont icon-a-sousuo1 pa cfff f18"
					style="top: 0px;left: 3px; height: 100%; width: 40px;"></view>
			</view>
			
			<view class="flex f12 justify_end alignitems_center" style="width: 120px; line-height: 1; height: 34px; " @click="navigateTo('pages/index/index','wx2d9bd6b6da808d37','c7fbc372-d50b-48c1-8ba0-72961604c0df')">
				<view class="iconfont icon-weizhi"></view>
				<view style="margin-left: 5px;">查看地图</view>
			</view>
		</view>
		<view style="height: 43px;"></view>
		<view>
			<mp-html :content="details.F_PictureUrl" />
		</view>
	</view>
</template>

<script>
	export default {
		components: {
		},
		data() {
			return {
				details:{}
				
			}
		},
		onLoad() {
			this.$reqUest.get('/api/CmsManage/GetChannelInfoById',{
				Id:"565960a7-0a76-4960-9f6c-22e811b3e4b2"
			}).then(data => {
				var [error, res] = data;
				if(res.data.Result){
					this.details=res.data.Data
				}
				
			})
		},
		onShow() {

		},
		onReachBottom() {
			
		},
		 
		methods: {
			
		}
	}
</script>

<style>
</style>