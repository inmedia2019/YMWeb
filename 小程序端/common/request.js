import $conFig from "common/config.js"
import $md5 from "common/md5.js"

//uni.getStorageSync('userInfo').mobile==undefined?'':uni.getStorageSync('userInfo').mobile18321454545
export default {
	common:{
		method:"GET",
		header:{
			'content-type':"application/json"
		},
		data:{}
	},
	request(options={}){
		var _h={'content-type':"application/json"
		}
		
		options.method=options.method||this.common.method
		options.header=_h
		return uni.request(options)
	},
	get(url,data={},options={},iep){
		
		options.url=$conFig.ApiUrl+url
		options.data=data
		options.method="GET"
		
		return this.request(options)
	},
	post(url,data={},options={},iep){
		
		if(iep=="iep"){
			options.url=$conFig.Api2Url+url
			
			var md5Txt=""
			for (var key in data){
				md5Txt=md5Txt+data[key]
			}
			
			data.sign=$md5(md5Txt+'985ccb0RTYa8a706c4c34a16891e67e7b')
		}else{
			options.url=$conFig.ApiUrl+url
			
		}
		
		options.data=data
		
		options.method="POST"
		
		return this.request(options)
	}
}