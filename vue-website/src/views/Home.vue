<template>
  <section>
    <div class="text-center">
      <span class="hidden sm:inline-block sm:align-middle sm:h-screen" aria-hidden="true">&#8203;</span>
      <div class="inline-block overflow-hidden">
        <img src="../assets/pubquizish-logo.svg" />
        <div class="mt-10">
          <TextInput
            v-model="code"
            placeholder="Enter your code"
            class="text-center"
            autocomplete="off"
          />
        </div>
        <div class="relative mt-5">
          <hr class="border-gray-300" />
          <span class="bg-gray-100 px-2 absolute -top-3 inset-x-auto -ml-3 text-gray-500">or</span>
        </div>
        <Btn @click="showLoginDialog = true" primary class="mt-5">Host new game</Btn>
      </div>
    </div>
    <Dialog v-model:show="showLoginDialog">
      <div class="bg-white p-4 overflow-hidden">
        <Btn
          @click="$authentication.authenticateExternal('Google', 'https://localhost:3000/host')"
          primary
          class="float-left"
        >
          <img src="../assets/google-logo.svg" width="22" height="22" class="mr-2 float-left" />Google
        </Btn>
        <Btn @click="showLoginDialog = false" class="float-right">Cancel</Btn>
      </div>
    </Dialog>
  </section>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Btn from "../components/Btn.vue";
import TextInput from "../components/form/TextInput.vue";
import Dialog from "../components/Dialog.vue";

const code = ref("")
const showLoginDialog = ref(false)
</script>
