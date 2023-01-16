<script setup lang="ts">
  import { onMounted, ref } from "@vue/runtime-core";

  const email = ref<string | undefined>();
  const password = ref<string | undefined>();
  const formModel = ref({
    email,
    password,
  });

  onMounted(() => {
    console.log("login page");
  });

  function onLoginClicked() {
    console.log("formModel.value", formModel.value);
  }
</script>

<template>
  <div class="d-flex justify-center align-center" style="width: 100vw; height: 100vh">
    <div>
      <h1 class="text-center">Welcome to My History</h1>
      <v-card width="500">
        <v-card-text>
          <v-text-field
            label="Email"
            placeholder="example@domain.com"
            type="email"
            v-model="email"
          />

          <v-text-field label="Password" placeholder="******" type="password" v-model="password" />

          <div class="d-flex justify-end" @click="onLoginClicked">
            <v-btn class="px-8" color="primary">Login</v-btn>
          </div>
        </v-card-text>
      </v-card>
    </div>
  </div>
</template>
