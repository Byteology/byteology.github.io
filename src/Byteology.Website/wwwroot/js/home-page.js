﻿var currentSlide;
var slidesCount;
var page;
var vh;
var scroller;

export function init(currentSlideIndex, totalSlidesCount, pageObject) {
    currentSlide = currentSlideIndex;
    slidesCount = totalSlidesCount;
    page = pageObject;
    scroller = document.getElementById("home-scroller")

    window.scrollTo(0, 1);

    //setVh();
    resetScrollPosition();

    window.addEventListener('resize', onResize);
    scroller.addEventListener('scroll', onScroll);
}

export function dispose() {
    window.removeEventListener('resize', onResize);
    scroller.removeEventListener('scroll', onScroll);
    document.documentElement.style.removeProperty("--vh");
}

function setVh() {
    vh = window.innerHeight * 0.01;
    document.documentElement.style.setProperty("--vh", `${vh}px`);
}

function onResize(e) {
    //preventOnScroll = true; 
    //setVh();
    //resetScrollPosition();
    //preventOnScroll = false;
}

//var preventOnScroll = false;
function onScroll(e) {

    alert(scroller.scrollTop);

    //if (preventOnScroll)
    //    return;

    let prevSlide = currentSlide;

    if (scroller.scrollTop >= 2) 
        currentSlide++;
    else if (scroller.scrollTop <= 0)
        currentSlide--;

    currentSlide = Math.max(0, Math.min(slidesCount - 1, currentSlide));

    if (prevSlide != currentSlide) {
        setTimeout(resetScrollPosition, 500);
        page.invokeMethodAsync("OnSlideChanged", currentSlide);
    }
}

function resetScrollPosition() {
    if (currentSlide == 0)
        scroller.scrollTo(0, 0);
    else if (currentSlide == slidesCount - 1)
        scroller.scrollTo(0, 2);
    else
        scroller.scrollTo(0, 1);
}