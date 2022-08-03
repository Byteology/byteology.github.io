export function init() {
    document.body.style.setProperty('position', `fixed`);
}

export function dispose() {
    document.body.style.removeProperty('position');
}