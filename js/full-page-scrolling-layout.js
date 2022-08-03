﻿export function init() {
    document.documentElement.classList.add("w-full", "h-full");
    document.documentElement.classList.add("overflow-hidden");
    document.body.classList.add("w-full", "h-full");
    document.getElementById("app").classList.add("w-full", "h-full");
}

export function dispose() {
    document.documentElement.classList.remove("w-full", "h-full");
    document.documentElement.classList.remove("overflow-hidden");
    document.body.classList.remove("w-full", "h-full");
    document.getElementById("app").classList.remove("w-full", "h-full");
}