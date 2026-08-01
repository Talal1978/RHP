type CacheEntry<T> = {
  data: T;
  expiry: number;
};

const cache: Map<string, CacheEntry<any>> = new Map();

export function getCache<T>(key: string): T | undefined {
  const entry = cache.get(key);
  if (!entry) return undefined;
  if (Date.now() > entry.expiry) {
    cache.delete(key);
    return undefined;
  }
  return entry.data;
}

export function setCache<T>(key: string, data: T, ttlSeconds: number = 300): void {
  cache.set(key, { data, expiry: Date.now() + ttlSeconds * 1000 });
}

export function invalidateCache(keyPattern?: string): void {
  if (!keyPattern) {
    cache.clear();
    return;
  }
  for (const key of cache.keys()) {
    if (key.includes(keyPattern)) cache.delete(key);
  }
}
