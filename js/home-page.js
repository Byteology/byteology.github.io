var currentSlide;
var slidesCount;
var page;
var vh;
var scroller;
var lastEvent = "none";

export function init(currentSlideIndex, totalSlidesCount, pageObject) {
    currentSlide = currentSlideIndex;
    slidesCount = totalSlidesCount;
    page = pageObject;
    scroller = document.getElementById("home-scroller")

    window.scrollTo(0, 1);

    //setVh();
    printDebugData();
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
    lastEvent = "resize";
    //preventOnScroll = true;
    //setVh();
    //resetScrollPosition();
    //preventOnScroll = false;

    resetScrollPosition();
}

var preventOnScroll = false;
function onScroll(e) {

    lastEvent = "scroll";
    

    if (preventOnScroll)
        return;


    let prevSlide = currentSlide;

    if (scroller.scrollTop > getDesiredScrollPosition()) 
        currentSlide++;
    else if (scroller.scrollTop < getDesiredScrollPosition())
        currentSlide--;

    currentSlide = Math.max(0, Math.min(slidesCount - 1, currentSlide));

    if (prevSlide != currentSlide) {
        //preventOnScroll = true;
        //setTimeout(resetScrollPosition, 2000);
        //resetScrollPosition();
        //page.invokeMethodAsync("OnSlideChanged", currentSlide);
    }
    printDebugData();
}

function resetScrollPosition() {
    //scroller.scrollTo({ left: 0, top: getDesiredScrollPosition(), behavior: "instant" });
    preventOnScroll = false;

    printDebugData();

}

function getDesiredScrollPosition() {
    return 1;

    if (currentSlide == 0)
        return 0;
    else if (currentSlide == slidesCount - 1)
        return 2;
    else
        return 1;
}

function printDebugData() {
    var text = `le: ${lastEvent} st: ${scroller.scrollTop} pos: ${preventOnScroll} cs: ${currentSlide}`;
    document.getElementById("test").innerHTML = text;
}