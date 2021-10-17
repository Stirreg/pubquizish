import { App, inject } from "vue"

const hostApiUrl = 'https://localhost:5001/api/host'

export class HostApi {
    getTest() {
        return this.fetchAuthenticated(`${hostApiUrl}/test`, 'get')
    }

    fetchAuthenticated(url: string, method: string) {
        const token = localStorage.getItem('token')

        return fetch(url, {
            method: method.toUpperCase(),
            credentials: "include"
        }).then(response => {
            if (response.status === 401) {
                localStorage.removeItem('token')
            }

            return response
        })
    }

    install(app: App) {
        app.provide('hostApi', this)
    }
}

export function createHostApi() {
    return new HostApi()
}

export function useHostApi() {
    return inject('hostApi') as HostApi
}

export const hostApi = createHostApi()
