function useStorage(type: "local" | "session") {
  const storage = type === "local" ? localStorage : sessionStorage;
  const keyPrefix = "my-history-app";

  const prefix = (key: string) => `${keyPrefix}__${key}`;

  function get(key: string): string | undefined {
    return storage.getItem(prefix(key)) ?? undefined;
  }

  function set(key: string, value: string) {
    storage.setItem(prefix(key), value);
  }

  function remove(key: string) {
    storage.removeItem(prefix(key));
  }

  return {
    get,
    set,
    remove,
  };
}

export function useLocalStorage() {
  return useStorage("local");
}

export function useSessionStorage() {
  return useStorage("session");
}
