var dotNetObject;

export function init(dotNetObjectReference) {
    dotNetObject = dotNetObjectReference;
    setValues();

    window.visualViewport.addEventListener("resize", setValues);
    window.visualViewport.addEventListener("scroll", setValues);
}

export function dispose() {
    window.visualViewport.removeEventListener("resize", setValues);
    window.visualViewport.removeEventListener("scroll", setValues);
}

function setValues() {
    let top = window.visualViewport.offsetTop;
    let left = window.visualViewport.offsetLeft;
    let width = window.visualViewport.width;
    let height = window.visualViewport.height;

    dotNetObject.invokeMethodAsync("onChanged", top, left, width, height);
}
