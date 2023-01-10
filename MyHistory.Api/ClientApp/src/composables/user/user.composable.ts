import jwtDecode from "jwt-decode";
import { computed } from "vue";
import { useSessionStorage } from "../storage";
import type { UserClaims } from "./UserClaims";

export function useUser() {
  const storage = useSessionStorage();
  const accessTokenKey = "access_token";
  const refreshTokenKey = "refresh_token";

  const accessToken = computed<string | undefined>(() => {
    return storage.get(accessTokenKey);
  });

  const refreshToken = computed<string | undefined>(() => {
    return storage.get(refreshTokenKey);
  });

  const claims = computed<UserClaims>(() => {
    const access_token = accessToken.value;

    if (!access_token) {
      throw new Error("An access token has not been set");
    }

    const decoded = jwtDecode<any>(access_token);

    return {
      ...decoded, // TODO Map claims?
    };
  });

  function clearSession() {
    storage.remove(accessTokenKey);
    storage.remove(refreshTokenKey);
  }

  function storeSession(session: { access_token: string; refresh_token?: string }) {
    storage.set(accessTokenKey, session.access_token);

    if (session.refresh_token) {
      storage.set(refreshTokenKey, session.refresh_token);
    }
  }

  return {
    claims,
    accessToken,
    refreshToken,
    clearSession,
    storeSession,
  };
}
