export function init() {
    document.getElementById("layout").focus();
    document.getElementById("layout").addEventListener("wheel", onLayoutWheel, { passive: false });

    let slides = document.getElementsByClassName("slide");
    for (var i = 0; i < slides.length; i++)
        slides[i].addEventListener("wheel", onSlideWheel, { passive: false });
}

export function dispose() {
    preventSlideIncrement = false;
    preventSlideDecrement = false;
    preventOverscroll = false;
}

var layoutTimer;
var preventSlideIncrement = false;
var preventSlideDecrement = false;
function onLayoutWheel(e) {
    e.preventDefault();
    e.stopPropagation();

    let slides = document.getElementsByClassName("slide");
    let currentSlideIndex;
    for (var i = 0; i < slides.length; i++) {
        if (Math.abs(slides[i].getBoundingClientRect().y) < 100) {
            currentSlideIndex = i;
            break;
        }
    }

    if (currentSlideIndex === undefined)
        return;

    if (e.deltaY > 0 && !preventSlideIncrement) {
        clearTimeout(layoutTimer);
        preventSlideIncrement = true;
        preventSlideDecrement = false;

        layoutTimer = setTimeout(() => { preventSlideIncrement = false; }, 500);

        if (currentSlideIndex != slides.length - 1) {
            slides[currentSlideIndex + 1].scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
        }
    }
    else if (e.deltaY < 0 && !preventSlideDecrement) {

        clearTimeout(layoutTimer);
        preventSlideIncrement = false;
        preventSlideDecrement = true;
        layoutTimer = setTimeout(() => { preventSlideDecrement = false; }, 500);

        if (currentSlideIndex != 0)
            slides[currentSlideIndex - 1].scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
    }
}

var slideTimer;
var preventOverscroll = false;
function onSlideWheel(e) {
    var slide = e.currentTarget;
    let atBottom = (slide.scrollHeight - slide.scrollTop - slide.clientHeight) < 1;
    let atTop = slide.scrollTop < 1;

    if ((e.deltaY > 0 && !atBottom) || (e.deltaY < 0 && !atTop)) {
        clearTimeout(slideTimer);
        preventOverscroll = true;
        slideTimer = setTimeout(() => { preventOverscroll = false; }, 500);
        e.stopPropagation();
    }
    else if (preventOverscroll)
        e.stopPropagation();
}