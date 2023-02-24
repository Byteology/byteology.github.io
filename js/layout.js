class FullPageScrolling {
    start() {
        document.getElementById("page").addEventListener("scroll", fps.reScrollSlides);
        document.getElementById("page").addEventListener("wheel", wid.feed, { passive: false, capture: true });
        document.getElementById("page").addEventListener("wheel", fps.onPageWheel, { passive: false });

        let slides = document.getElementsByClassName("slide");
        for (var i = 0; i < slides.length; i++)
            slides[i].addEventListener("wheel", fps.onSlideWheel, { passive: false });

        this.reScrollSlides();
    }

    stop() {
        document.getElementById("page").removeEventListener("scroll", fps.reScrollSlides);
        document.getElementById("page").removeEventListener("wheel", wid.feed, { passive: false, capture: true });
        document.getElementById("page").removeEventListener("wheel", fps.onPageWheel, { passive: false });

        let slides = document.getElementsByClassName("slide");
        for (var i = 0; i < slides.length; i++)
            slides[i].removeEventListener("wheel", fps.onSlideWheel, { passive: false });
    }

    reScrollSlides() {
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

        for (var i = 0; i < slides.length; i++) {
            if (i < currentSlideIndex)
                slides[i].scrollTop = 9999;
            else if (i > currentSlideIndex)
                slides[i].scrollTop = 0;
        }
    } 

    onPageWheel(e) {
        if (e.ctrlKey)
            return;

        e.preventDefault();
        e.stopPropagation();

        if (wid.isInertia)
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

        if (e.deltaY > 0 && currentSlideIndex != slides.length - 1) {
            wid.reset();
            wid.feed(e);
            document.getElementById("page").scrollTo({ top: slides[currentSlideIndex + 1].offsetTop, behavior: "instant" });
        }
        else if (e.deltaY < 0 && currentSlideIndex != 0) {
            wid.reset();
            wid.feed(e);
            document.getElementById("page").scrollTo({ top: slides[currentSlideIndex - 1].offsetTop, behavior: "instant"});
        }
    }

    onSlideWheel(e) {
        if (e.ctrlKey)
            return;

        var element = e.currentTarget;
        let atBottom = (element.scrollHeight - element.scrollTop - element.clientHeight) < 1;
        let atTop = element.scrollTop < 1;

        if ((e.deltaY > 0 && !atBottom) || (e.deltaY < 0 && !atTop)) {
            e.stopPropagation();
        }
        else {
            if (wid.isInertia) {
                e.stopPropagation();
            }
            e.preventDefault();
        }
    }
}

class WheelInertiaDetector {
    debounceTime = 500;
    minSwipeInterval = 500;
    minNewSwipeDelta = 30;

    swipeStarted;
    swipePositive;
    swipeDurationStopwatch;
    debouceTimer;

    isInertia;

    feed(e) {
        let delta = e.deltaY;
        wid.resetDebouncerTimer();

        // First event in some time
        if (!wid.swipeStarted) {
            wid.startSwipe(delta);
            wid.isInertia = false;
            return;
        }

        // Wheel direction has changed
        if (wid.swipePositive && delta < -1 || !wid.swipePositive && delta > 1) {
            wid.startSwipe(delta);
            wid.isInertia = false;
            return;
        }

        // Big delta after a lot of time into the swipe
        if (Math.abs(delta) >= wid.minNewSwipeDelta && Date.now() - wid.swipeDurationStopwatch > wid.minSwipeInterval) {
            wid.startSwipe(delta);
            wid.isInertia = false;
            return;
        }

        wid.isInertia = true;
    }

    reset() {
        clearTimeout(wid.debouceTimer);
        wid.swipeDurationStopwatch = null;
        wid.swipeStarted = false;
    }

    resetDebouncerTimer() {
        clearTimeout(wid.debouceTimer);
        wid.debouceTimer = setTimeout(wid.endSwipe, wid.debounceTime)
    }

    startSwipe(delta) {
        wid.swipeStarted = true;
        wid.swipePositive = delta > 0;
        wid.swipeDurationStopwatch = Date.now();
    }

    endSwipe() {
        wid.swipeStarted = false;
        wid.swipeDurationStopwatch = null;
    }
}

var fps = new FullPageScrolling();
var wid = new WheelInertiaDetector();

window.onNavigated = () => {
    document.getElementById("page").scrollTo(0, 0);
    collapseHamburger();
};

window.collapseHamburger = () => {
    let hamburger = document.getElementById("hamburger");
    if (hamburger)
        hamburger.checked = false;
}
