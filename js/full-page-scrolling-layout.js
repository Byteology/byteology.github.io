export function init() {
    document.documentElement.style.setProperty('position', `fixed`);
}

export function dispose() {
    document.documentElement.style.removeProperty('position');
}