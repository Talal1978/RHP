import { useState, useEffect, useMemo } from "react";
import useAxiosGet from "./useAxiosGet";
export type TCombo = { value: string; label: string; className?: string } & Record<string, any>;

const useCombo = (rubrique: string, options?: Record<string, any>) => {
    const [combo, setCombo] = useState<TCombo[]>([]);
    const memo_options = useMemo(() => options, [options ? JSON.stringify(options) : '']);
    const myAxios = useAxiosGet();

    useEffect(() => {
        let isMounted = true;
        myAxios({ apiStr: "rubrique", bdy: { rubrique, options } })
            .then((res: any) => {
                if (res.status === 200 && res.data.result) {
                    setCombo(res.data.data);
                } else {
                    setCombo([]);
                }
            })
            .catch((err) => {
                if (!isMounted) return;
                setCombo([]);
            });

        return () => { isMounted = false; };
    }, [myAxios, memo_options, rubrique]);
    return combo;
};

export default useCombo;
