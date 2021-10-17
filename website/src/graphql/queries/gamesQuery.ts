import { gql } from "@apollo/client/core"

export const gamesQuery = gql`
  query {
    games {
      id,
      code,
      name,
      creatorId,
      createdOn,
    }
  }
`;
