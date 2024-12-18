type FetchOptions<T> = {
  path: string;
  body?: Record<string, any>;
  returnContent?: boolean;
};

export const apiFetch = async <T = void>({
  path,
  body,
  returnContent = false,
}: FetchOptions<T>): Promise<T extends void ? void : T> => {
  const response = await $fetch<T>(`/api/${path}`, {
    method: 'POST',
    body,
  });

  if (returnContent) {
    return response as T extends void ? never : T;
  }

  return undefined as T extends void ? void : never;
};
