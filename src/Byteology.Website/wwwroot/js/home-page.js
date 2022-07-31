export function init() {
    document.body.style.setProperty("overscroll-behavior", "none");
}

export function dispose() {
    document.body.style.removeProperty("overscroll-behavior");
}