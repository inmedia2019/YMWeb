import App from './App'

// #ifndef VUE3
import Vue from 'vue'
Vue.config.productionTip = false

import pages from 'common/pages.js'
Vue.mixin(pages);

import location from 'common/location.js'
Vue.mixin(location);

import $conFig from 'common/config.js';
Vue.prototype.$conFig = $conFig;

import $base64 from 'common/base64.min.js'
Vue.prototype.$base64 = $base64;


import $reqUest from 'common/request.js';
Vue.prototype.$reqUest = $reqUest;


App.mpType = 'app'
const app = new Vue({
    ...App
})
app.$mount()
// #endif

// #ifdef VUE3
import { createSSRApp } from 'vue'
export function createApp() {
  const app = createSSRApp(App)
  return {
    app
  }
}
// #endif