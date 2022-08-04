var preventSlideIncrement = false;
var preventSlideDecrement = false;

export function init() {
    document.getElementById("layout").addEventListener("wheel", onWheel, { passive: false });
}

export function dispose() {
    preventSlideIncrement = false;
    preventSlideDecrement = false;
}

function onWheel(e) {
    e.preventDefault();
    e.stopPropagation();

    let slides = document.getElementsByClassName("slide");

    if (e.deltaY > 0 && !preventSlideIncrement) {

        preventSlideIncrement = true;
        preventSlideDecrement = false;
        setTimeout(() => { preventSlideIncrement = false; }, 500);

        for (var i = 0; i < slides.length; i++) {
            if (slides[i].getBoundingClientRect().y > 0) {
                slides[i].scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
                return;
            }
        };
    }
    else if (e.deltaY < 0 && !preventSlideDecrement) {

        preventSlideIncrement = false;
        preventSlideDecrement = true;
        setTimeout(() => { preventSlideDecrement = false; }, 500);

        for (var i = slides.length - 1; i >= 0; i--) {
            if (slides[i].getBoundingClientRect().y < 0) {
                slides[i].scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
                return;
            }
        };
    }
}