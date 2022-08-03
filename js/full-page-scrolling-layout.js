export function init() {
    document.body.classList.add("no-scrollbar");
    document.addEventListener("touchend", (e) => { console.log("click"); document.documentElement.requestFullscreen(); })

}

export function dispose() {
    document.body.classList.remove("no-scrollbar");
}