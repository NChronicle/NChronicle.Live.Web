function FocusElement(elem) {
    elem.focus();
}

function OnKeyUpFocusElement(keyCode, element) {
    document.addEventListener("keyup", (e) => {
        if (keyCode == e.keyCode) element.focus();
    });
}

function ScrollToElement(element) {
    const elementRect = element.getBoundingClientRect();
    const absoluteElementTop = elementRect.top + window.pageYOffset;

    element.scrollIntoView(true);
}