window.clipboardCopy = {
    copyText: function (text) {
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

function saveAsFile(filename, bytesBase64
) {
    if (navigator.msSaveBlob) {
        //Download document in Edge browser
        var data = window.atob(bytesBase64);
        var bytes = new Uint8Array(data.length);
        for (var i = 0; i < data.length; i++) {
            bytes[i] = data.charCodeAt(i);
        }
        var blob = new Blob([bytes.buffer], {type: "application/octet-stream"});
        navigator.msSaveBlob(blob, filename);
    }
    else {
        var link = document.createElement('a');
        link.download = filename;
        link.href = "data:application/octet-stream;base64," + bytesBase64;
        document.body.appendChild(link); // Needed for Firefox
        link.click();
        document.body.removeChild(link);
    }
}

function printDiv() {
    // Get the div element you want to print
    var divToPrint = document.getElementById('printDivFunction');

    // Create a new window for printing
    var printWindow = window.open('', '', 'height=400,width=600');

    // Write the div's content into the new window
    printWindow.document.write('<html><head><title>Print</title></head><body>');
    printWindow.document.write(divToPrint.innerHTML);
    printWindow.document.write('</body></html>');

    // Print the content in the new window
    printWindow.print();

    // Close the new window after printing
    printWindow.close();
}
function printInvoke() {
    window.print();
}