var currentSlide;
var slidesCount;
var page;
var vh;
var lastScrollPosition;

export function init(currentSlideIndex, totalSlidesCount, pageObject) {
    currentSlide = currentSlideIndex;
    slidesCount = totalSlidesCount;
    page = pageObject;
    window.scrollTo(0, getDesiredScrollPosition());
    lastScrollPosition = window.scrollY;
    document.body.classList.add("home-body");

    setVh();
    resetScrollPosition();

    window.addEventListener('resize', onResize);
    window.addEventListener('scroll', onScroll);
}

export function dispose() {
    window.removeEventListener('resize', onResize);
    window.removeEventListener('scroll', onScroll);
    document.documentElement.style.removeProperty("--vh");
    document.body.classList.remove("home-body");
}

function setVh() {
    vh = window.innerHeight * 0.01;
    document.documentElement.style.setProperty("--vh", `${vh}px`);
}

function onResize(e) {
    setVh();
}

var preventOnScroll = false;
function onScroll(e) {

    if (preventOnScroll)
        return;

    let prevSlide = currentSlide;

    if (window.scrollY > lastScrollPosition)
        currentSlide++;
    else if (window.scrollY < lastScrollPosition)
        currentSlide--;

    currentSlide = Math.max(0, Math.min(slidesCount - 1, currentSlide));

    lastScrollPosition = window.scrollY;

    if (prevSlide != currentSlide) {
        preventOnScroll = true;
        setTimeout(resetScrollPosition, 1000);
        page.invokeMethodAsync("OnSlideChanged", currentSlide);
    }
}

function resetScrollPosition() {
    window.scrollTo(0, getDesiredScrollPosition());
    lastScrollPosition = window.scrollY;
    preventOnScroll = false;
}

function getDesiredScrollPosition() {
    if (currentSlide == 0)
        return 0;
    else if (currentSlide == slidesCount - 1)
        return document.documentElement.scrollHeight;
    else
        return 1;
}
