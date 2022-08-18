export function init() {
    preventSlideIncrement = false;
    preventSlideDecrement = false;

    document.getElementById("page").focus();
    document.getElementById("page").addEventListener("wheel", onPageWheel, { passive: false });

    let slides = document.getElementsByClassName("slide");
    for (var i = 0; i < slides.length; i++)
        slides[i].addEventListener("wheel", onSlideWheel, { passive: false });
}

var preventSlideIncrement;
var preventSlideDecrement;

function onPageWheel(e) {
    let layoutTimer;

    if (e.ctrlKey)
        return;

    e.preventDefault();
    e.stopPropagation();

    if (isInertiaWheel(e))
        return;

    let slides = document.getElementsByClassName("slide");
    let currentSlideIndex;
    let minDelta = 50000;
    for (var i = 0; i < slides.length; i++) {
        let delta = Math.abs(slides[i].getBoundingClientRect().y);
        if (delta < minDelta) {
            currentSlideIndex = i;
            minDelta = delta;
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


function onSlideWheel(e) {
    let slideTimer;
    let preventOverscroll;

    if (e.ctrlKey)
        return;

    if (preventSlideDecrement || preventSlideIncrement) {
        e.preventDefault();
        return;
    }

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

function isInertiaWheel(e) {
    let timer;

    if (Math.abs(e.deltaY) < 50)
        return true;

    var result = timer != undefined;

    clearTimeout(timer);
    timer = setTimeout(() => { timer = undefined; }, 100);

    return result;
}