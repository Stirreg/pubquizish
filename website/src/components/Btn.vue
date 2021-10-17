<template>
  <button type="button" :class="[sharedClasses, primary ? primaryClasses : defaultClasses]">
    <span :class="loading ? 'invisible' : ''">
      <slot></slot>
    </span>
    <svg
      class="animate-spin mx-auto h-5 w-5 text-primary-500 absolute"
      xmlns="http://www.w3.org/2000/svg"
      fill="none"
      viewBox="0 0 24 24"
      v-if="loading"
    >
      <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4" />
      <path
        class="opacity-75"
        fill="currentColor"
        d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
      />
    </svg>
  </button>
</template>

<script setup lang="ts">
const props = withDefaults(defineProps<{
  primary?: boolean,
  loading?: boolean,
}>(), {
  primary: false,
  loading: false,
})

const sharedClasses = "w-full inline-flex justify-center rounded-md border shadow-sm px-4 py-2 text-base font-medium focus:outline-none focus:ring-2 focus:ring-offset-2 sm:w-auto sm:text-sm"
const defaultClasses = "border-gray-300 bg-white text-gray-700 hover:bg-gray-50 focus:ring-2 focus:ring-primary-500"
const primaryClasses = "border-primary-700 bg-primary-500 text-white hover:bg-primary-700 focus:ring-2 focus:ring-primary-500"
</script>
