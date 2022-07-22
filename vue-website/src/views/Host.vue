<template>
  <div class="clearfix">
    <h1 class="text-4xl font-bold float-left">Games</h1>
    <Btn @click="$authentication.signOut('https://localhost:3000')" class="float-right">Sign out</Btn>
  </div>
  <section>
    <div class="mt-4 grid grid-cols-1 sm:grid-cols-3 md:grid-cols-4 gap-4">
      <Card v-for="game in gamesData?.games" :key="game.id" class="p-4">
        <h3 class="text-xl font-bold">{{ game.name }}</h3>
        <dt>Code:</dt>
        <dd>{{ game.code }}</dd>
        <dt>Created:</dt>
        <dd>{{ game.createdOn }}</dd>
        <Btn
          @click="removeNewGame({ id: game.id })"
          :loading="removeNewGameLoading"
          class="mt-4"
        >Delete</Btn>
        <Btn @click="showAddABRoundDialog = true" primary class="mt-4">Add round</Btn>
        <FormDialog
          v-model:show="showAddABRoundDialog"
          @submit="addABRoundToNewGame({ name })"
          :loading="gamesQueryLoading"
        >
          <TextInput name="name" placeholder="Name" v-model="name" class="w-full" />
        </FormDialog>
      </Card>
    </div>
    <Btn @click="showCreateNewGameDialog = true" primary class="mt-4">Create Game</Btn>
    <FormDialog
      v-model:show="showCreateNewGameDialog"
      @submit="createNewGame({ name })"
      :loading="gamesQueryLoading"
    >
      <TextInput name="name" placeholder="Name" v-model="name" class="w-full" />
    </FormDialog>
  </section>
</template>

<script setup lang="ts">
import { useMutation, useQuery } from "@vue/apollo-composable"
import { ref } from "vue"
import Btn from "../components/Btn.vue"
import FormDialog from "../components/FormDialog.vue"
import TextInput from "../components/form/TextInput.vue"
import { gamesQuery } from "../graphql/queries/gamesQuery"
import { createNewGameMutation } from "../graphql/mutations/createNewGameMutation"
import { removeNewGameMutation } from "../graphql/mutations/removeNewGameMutation"
import Card from "../components/Card.vue"

interface Game {
  id: string,
  code: string,
  name: string,
  creatorId: string,
  createdOn: string,
}

interface GamesData {
  games: Game[]
}

const { result: gamesData, loading: gamesQueryLoading } = useQuery<GamesData>(gamesQuery)

const { mutate: createNewGame, loading: createNewGameLoading } = useMutation(createNewGameMutation, () => ({
  update: (cache, { data: { createNewGame } }) => {
    const { games } = cache.readQuery({ query: gamesQuery }) as GamesData
    const gamesData = { games: [...games, createNewGame] }
    cache.writeQuery({ query: gamesQuery, data: gamesData })
  },
}))

const { mutate: removeNewGame, loading: removeNewGameLoading } = useMutation(removeNewGameMutation, () => ({
  update: (cache, { data: { removeNewGame } }) => {
    const { games } = cache.readQuery({ query: gamesQuery }) as GamesData
    const gamesData = { games: games.filter(game => game.id !== removeNewGame.id.toUpperCase()) }
    cache.writeQuery({ query: gamesQuery, data: gamesData })
  },
}))

const showCreateNewGameDialog = ref(false)
const showAddABRoundDialog = ref(false)
const name = ref("")
</script>
