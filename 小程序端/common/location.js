export default {
	methods: {
		getUserLocation() {
			this.postAddress('9999')
			return
			uni.getSetting({
				success: (res) => {
					console.log(res,"getSetting_success")
					if (!res.authSetting['scope.userLocation']) {
						console.log("!scope.userLocation_1111")
						uni.authorize({
							scope: 'scope.userLocation',
							success: () => { //1.1 允许授权
								console.log("authorize_success")
								this.geo();
							},
							fail: () => { //1.2 拒绝授权
								uni.showModal({
									title: '位置提示',
									content: '您还未授权位置信息，请授权',
									success: function(res) {
										if (res.confirm) {
											uni.openSetting({
												success: (res) => {
													
												},
												fail: (err) => {
													
												}
											})
										} else if (res.cancel) {
											
										}
									}
								});
								console.log("authorize_fail")
								this.postAddress('9999')
							}
						})
					} else {
						console.log("scope.userLocation_2222")
						this.geo();
					}
				},
				fail: () => {
					console.log(res,"getSetting_fail")
					this.postAddress('9999')
				}
			})
		},

		// 获取定位城市
		geo() {
			// var QQMapWX = require('@/common/qqmap-wx-jssdk.min.js');
			// this.qqmapsdk = new QQMapWX({
			// 	key: 'SO2BZ-PUL63-MS73Q-3DV5Y-IA376-RLBIX' //自己的key秘钥  http://lbs.qq.com/console/mykey.html 在这个网址申请
			// });
			// uni.getLocation({
			// 	type: 'wgs84',
			// 	success: (res) => {
			// 		console.log(res,"geo_success")
			// 		var latitude = res.latitude
			// 		var longitude = res.longitude
			// 		var speed = res.speed
			// 		var accuracy = res.accuracy
			// 		this.qqmapsdk.reverseGeocoder({
			// 			location: {
			// 				latitude: latitude,
			// 				longitude: longitude
			// 			},
			// 			success: (res) => {
			// 				console.log(res,"qqmapsdk_success")
			// 				let loginAddress = res.result.ad_info.name
			// 				this.postAddress(loginAddress)
			// 			},
			// 			fail: (res) => {
			// 				this.postAddress('9999')
			// 				console.log(res,"qqmapsdk_res")
			// 			},
			// 			complete: (res) => {

			// 			}
			// 		});
			// 	},
			// 	fail: (res) => {
			// 		console.log(res,"geo_res")
			// 		this.postAddress('9999')
			// 	}
			// })
		},
		//postAddress请求后台接口
		
	}
}
