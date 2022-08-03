export function init() {
    document.body.classList.add("no-scrollbar");
}

export function dispose() {
    document.body.classList.remove("no-scrollbar");
}