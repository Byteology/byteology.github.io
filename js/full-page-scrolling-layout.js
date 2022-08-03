export function init() {
    document.documentElement.classList.add("w-full", "h-full", "overflow-hidden");
    document.body.classList.add("w-full", "h-full", "overflow-hidden");
    document.getElementById("app").classList.add("w-full", "h-full", "overflow-hidden");
}

export function dispose() {
    document.documentElement.classList.remove("w-full", "h-full", "overflow-hidden");
    document.body.classList.remove("w-full", "h-full", "overflow-hidden");
    document.getElementById("app").classList.remove("w-full", "h-full", "overflow-hidden");
}