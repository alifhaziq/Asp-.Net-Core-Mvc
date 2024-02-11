function toggleOtherInput() {
    var purposeSelect = document.getElementById("purposeSelect");
    var otherInput = document.getElementById("other");

    if (purposeSelect.value == "3") {
        // If "Others" is selected, show the input field
        otherInput.style.display = "block";
    } else {
        // If any other option is selected, hide the input field
        otherInput.style.display = "none";
    }
}

function toggleInput() {
    var purposeSelect = document.getElementById("existing");
    var otherInput = document.getElementById("NoAcc");

    if (purposeSelect.value == "1") {
        // If "Others" is selected, show the input field
        otherInput.style.display = "block";
    } else {
        // If any other option is selected, hide the input field
        otherInput.style.display = "none";
    }
}

function togglePEP() {
    var pepDecSelect = document.getElementById("Decpep");
    var statusPEPSelect = document.getElementById("statusPEP");
    var relationshipPEPSelect = document.getElementById("relationshipPEP");

    if (pepDecSelect.value == "1") {
        // If "Yes" is selected, show the additional selects
        statusPEPSelect.style.display = "block";
        relationshipPEPSelect.style.display = "block";
    } else {
        // If "No" is selected, hide the additional selects
        statusPEPSelect.style.display = "none";
        relationshipPEPSelect.style.display = "none";
    }
}
function toggleCheckboxes() {
    var decSelect = document.getElementById("Dec");
    var checkboxContainer = document.getElementById("checkboxContainer");

    if (decSelect.value == "1") {
        // If "I/We am/are non-resident of Malaysia" is selected, show the checkboxes
        checkboxContainer.style.display = "block";
    } else {
        // If "I/We am/are resident of Malaysia" or "Please Choose" is selected, hide the checkboxes
        checkboxContainer.style.display = "none";
    }
}
