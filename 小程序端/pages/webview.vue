<template>
	<web-view :src="srcUrl"></web-view>
	<!-- https://virtualqa.atline.cn/LiveMeeting2022/index.aspx -->
</template>

<script>
	export default {
		data() {
			return {
				parameter:{},
				srcUrl:""
			}
		},
		onLoad(e) {
			if(!this.mid){
				return
			}
			this.parameter=e
			this.srcUrl=this.$base64.Base64.decode(this.parameter.url)
		},
		onShow(){
			
		},
		methods: {
			
		}
	}
</script>

<style>
</style>