import { gql } from "@apollo/client/core";

export const createNewGameMutation = gql`
  mutation createNewGame($name: String!) {
      createNewGame(command: {
          name: $name
      }) {
          id,
          code,
          name,
          creatorId,
          createdOn,
      }
  }
`
