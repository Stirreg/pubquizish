import { ApolloClient, createHttpLink, InMemoryCache } from "@apollo/client/core";
import { DefaultApolloClient } from "@vue/apollo-composable";
import { App } from "vue";

const graphQLEndpoint = 'https://localhost:5001/graphql'

export function apollo(app: App) {
  const apolloClient = new ApolloClient({
    link: createHttpLink({
      uri: graphQLEndpoint,
      credentials: 'include'
    }),
    cache: new InMemoryCache(),
  })

  app.provide(DefaultApolloClient, apolloClient)
}
