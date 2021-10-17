import { createApp } from 'vue'
import App from './App.vue'
import { authentication } from './plugins/authentication'
import { hostApi } from './plugins/hostApi'
import { sentry } from './plugins/sentry'
import { apollo } from './plugins/apollo'
import './index.css'
import { router } from './plugins/router'

createApp(App)
  .use(router)
  .use(authentication)
  .use(hostApi)
  // .use(sentry)
  .use(apollo)
  .mount('#app')
