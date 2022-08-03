export function init() {
    document.body.classList.add("no-scrollbar");
    document.addEventListener("touchend", (e) => { window.scrollTo(0, 800); })

}

export function dispose() {
    document.body.classList.remove("no-scrollbar");
}