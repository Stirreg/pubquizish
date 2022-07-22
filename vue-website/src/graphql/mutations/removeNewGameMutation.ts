import { gql } from "@apollo/client/core"

export const removeNewGameMutation = gql`
    mutation removeNewGame($id: String!) {
        removeNewGame(command: {
            id: $id
        }) {
          id
        }
    }
`
