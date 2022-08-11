﻿export function init() {
    document.getElementById("layout").focus();
    document.getElementById("layout").addEventListener("wheel", onLayoutWheel, { passive: false });

    let slides = document.getElementsByClassName("slide");
    for (var i = 0; i < slides.length; i++)
        slides[i].addEventListener("wheel", onSlideWheel, { passive: false });
}

function onLayoutWheel(e) {
    let layoutTimer;
    let preventSlideIncrement;
    let preventSlideDecrement;

    if (e.ctrlKey)
        return;

    e.preventDefault();
    e.stopPropagation();

    if (isInertiaWheel(e))
        return;

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


function onSlideWheel(e) {
    let slideTimer;
    let preventOverscroll;

    if (e.ctrlKey)
        return;

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