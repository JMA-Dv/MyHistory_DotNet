import { useAxios } from "@/composables/axios";
import { useUser } from "@/composables/user";
import { defineStore } from "pinia";
import type { LocalLoginRequest } from "./models";

export const useAuthStore = defineStore("auth-store", () => {
  const axios = useAxios();
  const user = useUser();

  async function loginAsync(request: LocalLoginRequest): Promise<void> {
    const response = await axios.post<any>("oauth/token", request); // TODO Set type in generic

    user.storeSession({
      access_token: response.data.access_token,
      refresh_token: response.data.refresh_token,
    });
  }

  function logout() {
    user.clearSession();
  }

  return {
    loginAsync,
    logout,
  };
});
