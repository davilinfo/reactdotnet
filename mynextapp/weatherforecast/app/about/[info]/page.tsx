import { Metadata } from "next";

export default async function About({params, searchParams} : {params: {info: string}, searchParams: any}) {
    console.log({params, searchParams});
    let {info} = await params;
    info = decodeURI(info);
    return (
        <div className="flex flex-col flex-1 items-center justify-center bg-zinc-50 font-sans dark:bg-black">
            This is the About page with info.  {info.toString()}
        </div>
    )
}