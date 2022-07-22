<template>
  <Dialog v-model:show="show">
    <div class="bg-white px-4 pt-5 pb-4">
      <slot></slot>
    </div>
    <div class="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse">
      <Btn class="sm:ml-2" @click="emit('submit'); show = false" primary>Save</Btn>
      <Btn @click="show = false" class="mt-2 sm:mt-0">Cancel</Btn>
    </div>
  </Dialog>
</template>

<script setup lang="ts">
import { computed } from "vue";
import Dialog from "./Dialog.vue";
import Btn from "./Btn.vue";

const props = defineProps<{
  show: boolean
  loading: boolean
}>()
const emit = defineEmits<{
  (e: 'update:show', value: boolean): void
  (e: 'submit'): void
}>()

const show = computed({
  get: () => props.show,
  set: value => emit("update:show", value)
})
</script>
