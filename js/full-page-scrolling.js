class FullPageScrolling {
    isIncrementingSlide;
    isDecrementingSlide;

    overscrollTimer;
    preventOverscroll;

    changeSlideTimer;

    inertiaTimer;

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

    init() {
        this.preventSlideIncrement = false;
        this.preventSlideDecrement = false;

        document.getElementById("page").focus();
        document.getElementById("page").addEventListener("wheel", this.onPageWheel, { passive: false });

        let scrollables = document.getElementsByClassName("scrollable");
        for (var i = 0; i < scrollables.length; i++)
            scrollables[i].addEventListener("wheel", this.onScrollableWheel, { passive: false });
    }

    onPageWheel(e) {
        if (e.ctrlKey)
            return;

        e.preventDefault();
        e.stopPropagation();

        if (fps.isInertiaWheel(e))
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

        if (e.deltaY > 0 && !fps.isIncrementingSlide) {
            clearTimeout(fps.changeSlideTimer);
            fps.isIncrementingSlide = true;
            fps.isDecrementingSlide = false;

            fps.changeSlideTimer = setTimeout(() => { fps.isIncrementingSlide = false; }, 500);

            if (currentSlideIndex != slides.length - 1) {
                slides[currentSlideIndex + 1].scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
            }
        }
        else if (e.deltaY < 0 && !fps.isDecrementingSlide) {

            clearTimeout(fps.changeSlideTimer);
            fps.isIncrementingSlide = false;
            fps.isDecrementingSlide = true;

            fps.changeSlideTimer = setTimeout(() => { fps.isDecrementingSlide = false; }, 500);

            if (currentSlideIndex != 0)
                slides[currentSlideIndex - 1].scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
        }
    }

    onScrollableWheel(e) {
        if (e.ctrlKey)
            return;

        if (fps.isDecrementingSlide || fps.isIncrementingSlide) {
            e.preventDefault();
            return;
        }

        var element = e.currentTarget;
        let atBottom = (element.scrollHeight - element.scrollTop - element.clientHeight) < 1;
        let atTop = element.scrollTop < 1;

        if ((e.deltaY > 0 && !atBottom) || (e.deltaY < 0 && !atTop)) {
            clearTimeout(fps.overscrollTimer);
            fps.preventOverscroll = true;
            fps.overscrollTimer = setTimeout(() => { fps.preventOverscroll = false; }, 500);
            e.stopPropagation();
        }
        else if (fps.preventOverscroll)
            e.stopPropagation();
    }

    isInertiaWheel(e) {
        if (Math.abs(e.deltaY) < 50 && fps.inertiaTimer)
            return true;

        var result = fps.inertiaTimer != undefined;

        clearTimeout(fps.inertiaTimer);
        fps.inertiaTimer = setTimeout(() => { fps.inertiaTimer = undefined; }, 100);

        return result;
    }
}

var fps = new FullPageScrolling();
