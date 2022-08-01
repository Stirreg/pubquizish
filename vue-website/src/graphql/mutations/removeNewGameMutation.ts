import { gql } from "@apollo/client/core"

export const removeNewGameMutation = gql`
    mutation removeNewGame($id: String!) {
        removeNewGame(input: {
            id: $id
        }) {
          id
        }
    }
`
