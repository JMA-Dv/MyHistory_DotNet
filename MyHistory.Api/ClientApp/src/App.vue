<script lang="ts" setup>
  console.log("App root!");
</script>

<template>
  <v-app>
    <v-main>
      <RouterView :key="$route.fullPath" />
    </v-main>
  </v-app>
</template>
