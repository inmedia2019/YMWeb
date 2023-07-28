// https://msdym.atline.cn/webapi/api-doc/index.html
// https://msdym.atline.cn/ymweb/Login/Index
// admin
// Admsd!@#2022

// webadmin
// Msd!@2022

import $base64 from 'common/base64.min.js'

export default {
	httpUrl:"",
	imgUrl: "",
	ApiUrl: 'https://msdym.atline.cn/webapi',   //https://msdym.atline.cn/webapi   https://apps.atline.cn/webapi
	AppSecret: "", //秘钥
	Appid: '', //
	psize: 10, //
	issign() {
		
	},

	reminfo() {},
	
	previewImage(url) {
		jweixin.previewImage({
		 current: url, // 当前显示图片的http链接
			urls: [url] // 需要预览的图片http链接列表
		});
	},
	isPoneAvailable(poneInput) {
		var myreg = /^[1][2,3,4,5,6,7,8,9][0-9]{9}$/;
		if (!myreg.test(poneInput)) {
			return false;
		} else {
			return true;
		}
	},
	isEmailAvailable(emailInput) {
		if (emailInput.indexOf("@") == -1) {
			return false;
		} else {
			return true;
		}
	},
	AddUserActionByMid(tid,vContent){
		
	},
	isLook(data, Href, mid, SpecialData, InternalData, IsPrecast) {

	},
	geturl() {
		let pages = getCurrentPages();
		var url = pages[pages.length - 1].route;
		var optDate = pages[pages.length - 1].options
		var parDate = "?"
		for (let k in optDate) {
			parDate += k + "=" + optDate[k] + "&"
		};
		parDate = parDate.substr(0, parDate.length - 1);
		url += parDate
		return url
	},

	getReLaunch(url, e) {
		var that = this
		if(url.indexOf("://")>=0){
			window.location.href = url
		}else{
			uni.navigateTo({
				url: url,
				success: function(option) {
					
				},
				fail: function(option) {
					
				},
			});
		}
	},
	getnavigateBack(url, e) {
		if (getCurrentPages().length == 1) {
			uni.reLaunch({
				url: '/pages/index'
			});
		}
		var that = this
		uni.navigateBack();
	},
	dateFormat() {
		let date = new Date();
		let year = date.getFullYear();
		// 在日期格式中，月份是从0开始的，因此要加0，使用三元表达式在小于10的前面加0，以达到格式统一  如 09:11:05
		let month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
		let day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
		let hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
		let minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
		let seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
		// 拼接
		return year + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds;
		// return year + "-" + month + "-" + day;
	},
	dateformat2(e) {
		var data,time;
		
		if(e.indexOf("T")>=0){
			data=e.split("T")[0]
			time=e.split("T")[1]
		}
		
		if(e.indexOf(" ")>=0){
			data=e.split(" ")[0]
			time=e.split(" ")[1]
		}
		
		if(data.indexOf("/")){
			data=data.split("/")[0]+"-"+data.split("/")[1]+"-"+data.split("/")[2]
		}
		return data.split("-")[1]+"-"+data.split("-")[2]+" "+time.split(":")[0]+":"+time.split(":")[1]
	},
	dateformat3(e) {
		try{
			var data,time;
			if(e.indexOf("T")>=0){
				data=e.split("T")[0]
			}
			if(e.indexOf(" ")>=0){
				data=e.split(" ")[0]
			}
			return data
		}catch(e){
			//TODO handle the exception
		}
	},
	datetodet(e,type) {
		var data,time;
		if(e.indexOf("T")>=0){
			data=e.split("T")[0]
		}
		if(e.indexOf(" ")>=0){
			data=e.split(" ")[0]
		}
		
		if(type=="year"){
			data=data.split("-")[0]
		}else if(type=="month"){
			data=data.split("-")[1]
		}else if(type=="day"){
			data=data.split("-")[2]
		}
		
		return data
	},
	datetostamp(e){
		var data,time;
		if(e.indexOf("T")>=0){
			data=e.split("T")[0]
			time=e.split("T")[1]
			
			e=data+" "+time
		}
		return new Date(e).getTime()
	},
	alert_Tips(e) {
		uni.showToast({
			icon: "none",
			title: e,
			duration: 1500,
			mask: true
		})
	},
	alert_Load(e) {
		uni.showLoading({
			title: "加载中",
			mask: true
		})
	}
}
