<template>
  <input
    type="text"
    class="border rounded border-gray-300 appearance-none py-2 px-3 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-500"
    v-model="modelValue"
  />
</template>

<script setup lang="ts">
import { computed } from "vue";

const props = defineProps<{
  modelValue: string
}>()
const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
}>()

const modelValue = computed({
  get: () => props.modelValue,
  set: value => emit("update:modelValue", value)
})
</script>
