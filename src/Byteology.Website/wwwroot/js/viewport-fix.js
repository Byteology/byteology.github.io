let vh = window.innerHeight * 0.01;
document.documentElement.style.setProperty('--vh', `${vh}px`);

window.scrollTo(0, 500);

window.addEventListener('resize', () => {

    let vh = window.innerHeight * 0.01;
    document.documentElement.style.setProperty('--vh', `${vh}px`);
    //console.log("resize");
    //window.scrollBy(0, 500);
});

window.addEventListener('scroll', function (e) {

    if (this.window.scrollY > 500)
        console.log("down");
    else if (this.window.scrollY < 500)
        console.log("up");

    this.window.scrollTo(0, 500);

    //console.log("scroll");
    //window.scrollBy(0, 1);
    //console.log(this.window.scrollY);
});



// add totalSlides and currentSlide properties to the Home component
// import a js module on after render and call an init method with the 2 parameters
// the init method sets the current vh (to the root element of the component or one of the child elements), adds both listeners and calls a setCurrentSlide method with the recieved parameter
// it also removes the scrollbar of the body
// the resize listener sets the current vh and calls setCurrentSlide method with the current slide as parameter
// the scroll listener is throttled for as long as the scroll animation is (maybe a little less)
// it gets the Y of the current slide, checks if the scroll is up and down and calls setCurrentSlide with the appropriate parameters
// if the scrollY is the same as the currentSlide Y then it does nothing
// if it is being throttled it calls setCurrentSlide with the currentSlide as parameter
// setCurrentSlide calculates the Y of the new slide and calls window.ScrollTo(0, currentSlideY)
// it then calls the setCurrentSlide method of the home component if the current slide was changed
// the home component calls a dispose js method when disposing
// the dispose method removes both listeners and returns the scrollbar of the body
// the setCurrentSlide method of the component just sets the currentSlide property and issues a rerender
// The whole component is wrapped in a div that has height: calc(totalSlides * 100 * var(--vh, 1vh) + (totalSlides - 1) * 64px)
// inside it there is another div that has height: calc(100 * var(--vh, 1vh)) and has the background image and a hidden scrollbar
// inside it there is another div with the actual content
// it is absolutely positioned and has a transition for the top property
// it also has top: calc(-currentSlide * (100 * var(--vh, 1vh) + 64px))
// the slides have a spacing of 64px and height: calc(100 * var(--vh, 1vh))