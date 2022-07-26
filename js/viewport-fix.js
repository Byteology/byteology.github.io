let vh = window.innerHeight * 0.01;
document.documentElement.style.setProperty('--vh', `${vh}px`);

window.addEventListener('resize', () => {

    let vh = window.innerHeight * 0.01;
    document.documentElement.style.setProperty('--vh', `${vh}px`);
    //console.log("resize");
    window.scrollBy(0, 1);
});

window.addEventListener('scroll', function (e) {
    //console.log("scroll");
    //window.scrollBy(0, 1);
    //console.log(this.window.scrollY);
});