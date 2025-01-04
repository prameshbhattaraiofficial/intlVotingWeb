
function isPhoneNumber(evt) {
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = evt.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
function isNumberOnly(evt) {
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = evt.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
function lettersOnly(evt) {
    evt = (evt) ? evt : evt;
    var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
        ((evt.which) ? evt.which : 0));
    if (charCode > 32 && (charCode < 65 || charCode > 90) &&
        (charCode < 97 || charCode > 122)) {
        return false;
    }
    return true;
}

function containsOnlySpecialCharacters(event) {

    // Define a regular expression to match only "-" "/", and "\" characters
    const regex = /^[\/\-\\\.]+$/;

    // Test if the input matches the regex, and return false if it does not
    if (!regex.test(event.key)) {
        return false;
    }

    // If the input matches the regex, return true
    return true;
}


