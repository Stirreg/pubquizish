import * as Sentry from '@sentry/vue'
import { App } from 'vue'

const sentryDsn = "https://d84927547af34583a76f70ff79274c44@o246012.ingest.sentry.io/5939393"

export function sentry(app: App) {
    Sentry.init({
        app: app,
        dsn: sentryDsn
    })
}
