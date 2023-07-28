<template>
	<view>
		<view style="height: 300px;"></view>
		<button @click="fz">{{openid}}</button>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				openid: uni.getStorageSync('openid')
			}
		},
		onLoad() {

		},
		onShow() {

		},
		methods: {
			fz() {
				uni.setClipboardData({
					data: uni.getStorageSync('openid'), // 必须字符串
					success: function() {
						//console.log('success');
					}
				});
			}
		}
	}
</script>

<style>
</style>
