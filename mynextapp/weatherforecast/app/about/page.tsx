
export default function About(props: any) {
    console.log(props.params);
    return (
        <div className="flex flex-col flex-1 items-center justify-center bg-zinc-50 font-sans dark:bg-black">
            This is the About page. You can add more content here as needed.           
        </div>
    )
}