window.preventPitbarHiding = () => {
    document.documentElement.classList.add("w-full", "h-full", "overflow-hidden");
    document.body.classList.add("w-full", "h-full", "overflow-hidden", "fixed");
    document.getElementById("app").classList.add("w-full", "h-full", "overflow-hidden");
};

window.resetPitbarHiding = () => {
    document.documentElement.classList.remove("w-full", "h-full", "overflow-hidden");
    document.body.classList.remove("w-full", "h-full", "overflow-hidden", "fixed");
    document.getElementById("app").classList.remove("w-full", "h-full", "overflow-hidden");
};