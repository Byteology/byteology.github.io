var currentSlide;
var slidesCount;
var page;
var vh;
var scrollPosition;
let throttlePause = false;

export function init(currentSlideIndex, totalSlidesCount, pageObject) {
    currentSlide = currentSlideIndex;
    slidesCount = totalSlidesCount;
    page = pageObject;
    document.body.classList.add("no-scrollbar");

    setVh();
    setScrollPosition();

    window.addEventListener('resize', onResize);
    window.addEventListener('scroll', onScroll);
}

export function dispose() {
    window.removeEventListener('resize', onResize);
    window.removeEventListener('scroll', onScroll);
    document.documentElement.style.removeProperty("--vh");
    document.body.classList.remove("no-scrollbar");
}

function setVh() {
    vh = window.innerHeight * 0.01;
    document.documentElement.style.setProperty("--vh", `${vh}px`);
}

function onResize(e) {
    console.log("resize");

    setVh();
    setScrollPosition();
}

function onScroll(e) {

    let prevSlide = currentSlide;

    throttle(() => {
        if (this.window.scrollY > scrollPosition) {
            currentSlide++;
        }
        else if (this.window.scrollY < scrollPosition) {
            currentSlide--;
        }

        currentSlide = Math.max(0, Math.min(slidesCount - 1, currentSlide));
    }, 500);

    setScrollPosition();
    if (prevSlide != currentSlide)
        page.invokeMethodAsync("OnSlideChanged", currentSlide);
}

function setScrollPosition() {
    scrollPosition = vh * 100 * currentSlide + 64 * currentSlide;
    window.scrollTo(0, scrollPosition);
}


const throttle = (callback, time) => {
    if (throttlePause)
        return;

    throttlePause = true;
    callback();

    setTimeout(() => {
        throttlePause = false;
    }, time);
};