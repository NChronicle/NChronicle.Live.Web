window.FocusElement = (elem) => elem.focus();
window.OnKeyUpFocusElement = (keyCode, element) =>
    document.addEventListener("keyup", (e) => {
        if (keyCode == e.keyCode) element.focus();
    });
window.ScrollToElement = (elem) => elem.scrollIntoView(true);

(function () {
    let previousFocus;
    window.TakeFocus = (elem) => {
        previousFocus = document.activeElement;
        window.FocusElement(elem);
    };
    window.RestoreFocus = () => window.FocusElement(previousFocus);
})();
