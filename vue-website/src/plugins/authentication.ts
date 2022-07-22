import { App, inject } from "vue"

const externalAuthenticationEndpoint = "https://localhost:5001/api/authentication/external-sign-in"
const signOutEndpoint = "https://localhost:5001/api/authentication/sign-out"

export class Authentication {
  authenticateExternal(
    provider: string,
    returnUrl?: string
  ) {
    if (!returnUrl) {
      returnUrl = window.location.href
    }

    window.location.href = `${externalAuthenticationEndpoint}/${provider}?returnUrl=${returnUrl}`
  }

  signOut(returnUrl?: string) {
    if (!returnUrl) {
      returnUrl = window.location.href
    }

    window.location.href = `${signOutEndpoint}?returnUrl=${returnUrl}`
  }

  install(app: App) {
    app.config.globalProperties.$authentication = this
    app.provide('authentication', this)
  }
}

export function createAuthentication() {
  return new Authentication()
}

export function useAuthentication() {
  return inject('authentication') as Authentication
}

export const authentication = createAuthentication()

declare module '@vue/runtime-core' {
  export interface ComponentCustomProperties {
    $authentication: Authentication
  }
}
