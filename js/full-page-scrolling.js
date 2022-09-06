class FullPageScrolling {
    init() {
        this.preventPitbarHiding();

        document.getElementById("page").focus();
        document.getElementById("page").addEventListener("scroll", fps.onResize);
        document.getElementById("page").addEventListener("wheel", (e) => { wid.feed(e.deltaY); }, { passive: false, capture: true });
        document.getElementById("page").addEventListener("wheel", (e) => { fps.onPageWheel(e) }, { passive: false });

        let slides = document.getElementsByClassName("slide");
        for (var i = 0; i < slides.length; i++)
            slides[i].addEventListener("wheel", (e) => { fps.onSlideWheel(e); }, { passive: false });

        this.onResize();
    }

    dispose() {
        this.resetPitbarHiding();
    }

    preventPitbarHiding() {
        document.documentElement.classList.add("w-full", "h-full", "overflow-hidden");
        document.body.classList.add("w-full", "h-full", "overflow-hidden");
        document.getElementById("app").classList.add("w-full", "h-full", "overflow-hidden");
    }

    resetPitbarHiding() {
        document.documentElement.classList.remove("w-full", "h-full", "overflow-hidden");
        document.body.classList.remove("w-full", "h-full", "overflow-hidden");
        document.getElementById("app").classList.remove("w-full", "h-full", "overflow-hidden");
    }

    onResize() {
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
            wid.feed(e.deltaY);
            document.getElementById("page").scrollTo({ top: slides[currentSlideIndex + 1].offsetTop, behavior: "smooth" });
        }
        else if (e.deltaY < 0 && currentSlideIndex != 0) {
            wid.reset();
            wid.feed(e.deltaY);
            document.getElementById("page").scrollTo({ top: slides[currentSlideIndex - 1].offsetTop, behavior: "smooth"});
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

    feed(delta) {
        this.resetDebouncerTimer();

        // First event in some time
        if (!this.swipeStarted) {
            this.startSwipe(delta);
            this.isInertia = false;
            return;
        }

        // Wheel direction has changed
        if (this.swipePositive && delta < -1 || !this.swipePositive && delta > 1) {
            this.startSwipe(delta);
            this.isInertia = false;
            return;
        }

        // Big delta after a lot of time into the swipe
        if (Math.abs(delta) >= this.minNewSwipeDelta && Date.now() - this.swipeDurationStopwatch > this.minSwipeInterval) {
            this.startSwipe(delta);
            this.isInertia = false;
            return;
        }

        this.isInertia = true;
    }

    reset() {
        clearTimeout(this.debouceTimer);
        this.swipeDurationStopwatch = null;
        this.swipeStarted = false;
    }

    resetDebouncerTimer() {
        clearTimeout(this.debouceTimer);
        this.debouceTimer = setTimeout(this.endSwipe, this.debounceTime)
    }

    startSwipe(delta) {
        this.swipeStarted = true;
        this.swipePositive = delta > 0;
        this.swipeDurationStopwatch = Date.now();
    }

    endSwipe() {
        this.swipeStarted = false;
        this.swipeDurationStopwatch = null;
    }
}

var fps = new FullPageScrolling();
var wid = new WheelInertiaDetector();