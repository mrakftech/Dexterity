window.clipboardCopy = {
    copyText: function(text) {
        navigator.clipboard.writeText(text).then(function () {
            //alert("Copied to clipboard!");
        })
            .catch(function (error) {
                alert(error);
            });
    }
};

window.ScrollToBottom = (elementName) => {
    element = document.getElementById(elementName);
    element.scrollTop = element.scrollHeight - element.clientHeight;
}
window.PlayAudio = (elementName) => {
    document.getElementById(elementName).play();
}