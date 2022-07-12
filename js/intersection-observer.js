const intersectionCallback = (entries) => {
    entries.forEach(entry => {
        let elem = entry.target;

        if (entry.isIntersecting) {
            elem.classList.add('onscreen');
            elem.classList.add('entered-screen');
        }
        else  {
            elem.classList.remove('onscreen');
        }
    });
}

const intersectionObserver = new IntersectionObserver(intersectionCallback, { threshold: 1.0 });

window.observeIntersections = () => {
    intersectionObserver.disconnect();
    let targets = Array.from(document.getElementsByClassName('intersection-observable'));
    targets.forEach((target) => {
        intersectionObserver.observe(target);
    });
}
