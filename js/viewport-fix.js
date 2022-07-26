let vh = window.innerHeight * 0.01;
document.documentElement.style.setProperty('--vh', `${vh}px`);

window.addEventListener('resize', () => {

    let vh = window.innerHeight * 0.01;
    console.log(vh);
    document.documentElement.style.setProperty('--vh', `${vh}px`);
    window.scrollBy(0, 0);
    alert(vh);
});

window.addEventListener('scroll', function (e) {
    console.log(window.scrollY);
});