export default {
	data() {
		return {
			getresNum:0,
			residencetime:0,
			UserInfo:{},
			scrollTop:0,
			mid: uni.getStorageSync('mid'),
			openid: uni.getStorageSync('openid'),
			shareObj: {},
			ImageInx:0,
			boxData:0
		}
	},
	
	onLoad(option) {
		var that=this
		var url = getCurrentPages()[getCurrentPages().length - 1].$page.fullPath
		if (url.indexOf("login") >= 0) {
			return
		}
		if (!uni.getStorageSync('openid')) {
			uni.setStorage({
				key: 'timeUrl',
				data: url,
				success() {
					that.reLaunch("/pages/login")
				}
			});
			return
		}
		if (!uni.getStorageSync('mid')) {
			uni.setStorage({
				key: 'timeUrl',
				data: url,
				success() {
					that.reLaunch("/pages/login")
				}
			});
			return
		}
		this.$reqUest.get('/api/Memberinfo/GetUserInfoByOpenId', {
			openId: uni.getStorageSync('openid')
		}).then(data => {
			var [error, res] = data;
			this.UserInfo = res.data
			
			if(!res.data){
				uni.setStorage({
					key: 'timeUrl',
					data: url,
					success() {
						that.reLaunch("/pages/login")
					}
				});
			}else{
				if (url.indexOf("id=") >= 0) {
					this.AddUserAction(url.split("id=")[1], 0)
				} else {
					this.AddUserAction()
				}
			}
			
		})

		
		var route=getCurrentPages()[getCurrentPages().length - 1].route
		
		if(route.indexOf("?")>=0){
			route=route+"&Section=e49864ba-6802-4b44-b3e3-6cd14c46e707"
		}else{
			route=route+"?Section=e49864ba-6802-4b44-b3e3-6cd14c46e707"
		}
		this.shareObj= {
			title: "苗懂了",
			path: route,
			imageUrl: "/static/s.png"
		}
		
	},

	onShow() {
		this.getresNum=0
		this.residencetime=new Date()
		
	},
	onShareAppMessage(res) {
		var data = getCurrentPages()[getCurrentPages().length - 1].data.parameter
		if(data){
			if(data.id){
				this.AddUserAction(data.id,10)
			}else{
				this.AddUserAction("",10)
			}
		}else{
			this.AddUserAction("",10)
		}
		
		return this.shareObj
	},
	onShareTimeline(res) {
		var data = getCurrentPages()[getCurrentPages().length - 1].data.parameter
		if(data){
			if(data.id){
				this.AddUserAction(data.id,10)
			}else{
				this.AddUserAction("",10)
			}
		}else{
			this.AddUserAction("",10)
		}
		return this.shareObj
	},
	onPageScroll(e) {
		this.scrollTop = e.scrollTop;
	},
	onHide() {
		this.getresNum++
		this.restime()
	},
	onUnload() {
		this.getresNum++
		this.restime()
	},
	onReady(){
		var res = uni.getSystemInfoSync();
		var that=this
		var boxheight=-1
		setInterval(()=>{
			uni.createSelectorQuery().in(this).select('#box').boundingClientRect(data => {
				
				if(data){
					if(data.height>boxheight){
						boxheight=data.height
						this.boxData=0
					}
					data.top=data.top<0?data.top*-1:data.top
					var toproll=((data.top+res.windowHeight)/boxheight)
					toproll=toproll>1?1:toproll
					
					if(toproll>this.boxData){
						this.boxData=toproll
					}
				}
			}).exec()
		},3000)
	},
	
	methods: {
		restime(){
			if(this.$options.__file.indexOf("App.vue")>=0){
				return
			}
			if(this.getresNum==1){
				
				
				
				var data = getCurrentPages()[getCurrentPages().length - 1].data.parameter
				if(data){
					if(data.id){
						this.AddUserAction(data.id,12,parseInt((new Date().getTime()-this.residencetime.getTime())/1000))
						this.AddUserAction(data.id,13,this.boxData.toFixed(2))
					}else{
						this.AddUserAction("",12,parseInt((new Date().getTime()-this.residencetime.getTime())/1000))
						this.AddUserAction("",13,this.boxData.toFixed(2))
					}
				}else{
					this.AddUserAction("",12,parseInt((new Date().getTime()-this.residencetime.getTime())/1000))
					this.AddUserAction("",13,this.boxData.toFixed(2))
				}
				 
			}
		},
		Tagsubstr(e) {
			return e = e.substr(0, e.length - 1);
		},
		doList() {
			const that = this
			
			if(this.ImageInx<this.listData.length){
				
				uni.getImageInfo({
					src: this.listData[this.ImageInx].PicUrl,
					success: (image) => {
						// 计算图片渲染高度
						let showH = (50 * image.height) / image.width
						// 判断左右盒子高度
						if (that.leftH <= that.rightH) {
							that.leftList.push(this.listData[this.ImageInx])
							that.leftH += showH
						} else {
							that.rightList.push(this.listData[this.ImageInx])
							that.rightH += showH
						}
						this.ImageInx++
						this.doList()
					}
				})
			}
		},
		onSuccessImg(item){
			this.$set(item, 'imgLoaded', true)
		},
		navigateTo(url, type,Section) {
			
			//console.log(url, type)
			//return
			if (type == "F_ContentHref") {
				if (url.F_ContentHref) {
					url = url.F_ContentHref
				} else {
					url = "/pages/details?id=" + url.F_Id
				}
			}
			if (url == "") {
				return
			}

			if (type) {
				if (type.indexOf("wx") >= 0) {
					this.AddUserAction(type, 0, Section+type,Section)
					uni.navigateToMiniProgram({
						appId: type, //目标小程序的appid
						path: url, //目标小程序的页面路径
						success(res) {

						}
					})
					return
				}
			}
			
			if(url.indexOf("?")>=0){
				url=url+"&Section="+Section
			}else{
				url=url+"?Section="+Section
			}
			
			if (url.indexOf("://") >= 0) {
				this.AddUserAction(url, 0, Section+url,Section)
				uni.navigateTo({
					url: "/pages/webview?url=" + this.$base64.Base64.encode(url)
				});
				return
			}
			
			uni.navigateTo({
				url: url
			});
		},
		reLaunch(url, type,Section) {
			if(url.indexOf("?")>=0){
				url=url+"&Section="+Section
			}else{
				url=url+"?Section="+Section
			}
			uni.reLaunch({
				url: url
			});
		},
		AddUserAction(infoId, tid, content,Section) {
			if(!this.mid){
				return
			}
			
			//0:浏览 1:搜索 2:点赞 3:评论 4:收藏 5:广告位点击 6:视频播放时间 7:取消收藏 8:取消点赞 9:更新用户信息 10:分享  12:停留时常
			
			
			var json = {
				mid:this.UserInfo.IsAgreeAgreement?this.mid+"_user":this.mid,
				tid: 0,
				pageUrl: getCurrentPages()[getCurrentPages().length - 1].$page.fullPath,
				options:uni.getStorageSync('options')
			}
			
			if (content) {
				json.content = content
			}

			if (tid) {
				json.tid = tid
			}

			if(infoId){
				if (infoId.length>2) {
					json.infoId = getCurrentPages()[getCurrentPages().length - 1].options.id
				}
			}
			

			this.$reqUest.get('/api/UserActionInfo/AddUserActionByMid', json).then(data => {
				var [error, res] = data;
			})
		},
		navigateBack() {
			if (getCurrentPages().length == 1) {
				this.reLaunch("/pages/index")
				return
			}
			uni.navigateBack({
				delta: 1
			});
		},

		UshowToast(e) {
			uni.showToast({
				icon: "none",
				title: e,
				duration: 1500,
				mask: true
			})
		},
		UshowLoading(e) {
			uni.showLoading({
				title: "加载中",
				mask: true
			})
		}
	}
};
