import { useEffect, useRef } from "react";
import isEqual from "lodash.isequal";

export function useDeepCompareEffect(callback: () => void, dependencies: any) {
  const currentDepsRef = useRef();

  if (!isEqual(currentDepsRef.current, dependencies)) {
    currentDepsRef.current = dependencies;
  }

  useEffect(callback, [currentDepsRef.current]);
}
