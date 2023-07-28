<template>
	<view>
		
	</view>
</template>

<script>
	export default {
		data() {
			return {
				
			}
		},
		onLoad() {
			var that=this
			uni.login({
				provider: 'weixin',
				success: function(res) {
					that.$reqUest.get('/api/Wechat/Authorize',{
						js_code: res.code
					}).then(data => {
						var [error, res] = data;
						
						uni.setStorage({
							key: 'openid',
							data: res.data.Data.openid,
							success(){
								uni.setStorage({
									key: 'mid',
									data: res.data.Data.mid,
									success(){
										var timeUrl=uni.getStorageSync('timeUrl')
										if(timeUrl){
											if(timeUrl.indexOf("login") >= 0){
												that.reLaunch("/pages/index")
											}else{
												that.reLaunch(uni.getStorageSync('timeUrl'))
											}
										}else{
											that.reLaunch("/pages/index")
										}
									}
								});
							}
						});
					})
				},
				fail:function(res) {
					
				}
			});
		},
		onShow(){
			
		},
		methods: {
			
		}
	}
</script>

<style>
</style>