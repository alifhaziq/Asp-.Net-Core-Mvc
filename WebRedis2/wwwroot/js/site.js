// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Title select other
function TitleForm() {
    var titleSelect = document.getElementById("titleSelect");
    var otherInput = document.getElementById("otherTitle");

    if (titleSelect.value === "Others") {
        otherInput.style.display = "block";
    } else {
        otherInput.style.display = "none";
    }
}

function NationalForm() {
    var selectElement = document.getElementById("national");
    var otherInput = document.getElementById("otherNational");

    if (selectElement.value === "other") {
        otherInput.style.display = "block";
    } else {
        otherInput.style.display = "none";
    }
}

function MartialForm() {
    var martialSelect = document.getElementById("martialStatus");
    var marriedInput = document.getElementById("married");
    var othersInput = document.getElementById("otherMartial");

    if (martialSelect.value === "married") { 
        marriedInput.style.display = "block"; 
        othersInput.style.display = "none"; 
    }
    else if (martialSelect.value === "other") {
        marriedInput.style.display = "none";
        othersInput.style.display = "block";
    }
    else
    {
        marriedInput.style.display = "none";
        othersInput.style.display = "none"; 
    }     
}

function info1Form() {
    var info1Select = document.getElementById("info1Select");
    var otherInfo1 = document.getElementById("otherInfo1");

    if (info1Select.value === "other") {
        otherInfo1.style.display = "block"; 
    } else {
        otherInfo1.style.display = "none"; 
    }
}

function info3Form() {
    var info3Select = document.getElementById("info3Select");
    var otherInfo1 = document.getElementById("otherInfo3");

    if (info3Select.value === "yes") {
        otherInfo1.style.display = "block";
    } else {
        otherInfo1.style.display = "none";
    }
}

function pepForm() {
    var pepSelect = document.getElementById("pep");
    var statusPepInput = document.getElementById("statusPep");
    var relantionPepInput = document.getElementById("relationshipPep");

    if (pepSelect.value === "yes") {
        statusPepInput.style.display = "block";
        relantionPepInput.style.display = "block";
    }
    else {
        statusPepInput.style.display = "none";
        relantionPepInput.style.display = "none";
    }
}
function DeclarationForm() {
    var decSelect = document.getElementById("Dec");
    var checkbox1 = document.getElementById("resident");

    if (decSelect.value === "resident") { 
        checkbox1.style.display = "block"; 
    } else {
        checkbox1.style.display = "none"; 
    }
}

function UsPersonFields() {
    var usPersonRadio = document.getElementById("usPerson");
    var usIdentificationNumberContainer = document.getElementById("usIdentificationNumberContainer");
    var usTaxIdentificationNumberContainer = document.getElementById("usTaxIdentificationNumberContainer");

    if (usPersonRadio.checked) {
        usIdentificationNumberContainer.style.display = "block";
        usTaxIdentificationNumberContainer.style.display = "block";
    } else {
        usIdentificationNumberContainer.style.display = "none";
        usTaxIdentificationNumberContainer.style.display = "none";
    }
}

function FatcaFields() {
    var fatcaSelect = document.getElementById("fatcaForeign");
    var fatcaCheckbox = document.getElementById("giinInput");

    if (fatcaSelect.checked) { 
        fatcaCheckbox.style.display = "block"; 
    } else {
        fatcaCheckbox.style.display = "none"; 
    }
}

function crsFields() {
    var outsideMalaysiaCheckbox = document.getElementById("outsideMalaysia");
    var inputTaxInfoSection = document.getElementById("inputTaxInfo");
    var entityInfoSection = document.getElementById("entityInfo");

    if (outsideMalaysiaCheckbox.checked) {
        inputTaxInfoSection.style.display = "block";
        entityInfoSection.style.display = "block";
    } else {
        inputTaxInfoSection.style.display = "none";
        entityInfoSection.style.display = "none";
    }
}

function DisclosureFields() {
    var disclosureCheckbox = document.getElementById("disclosure");
    var disclosureInput = document.getElementById("DisclosureInput");

    if (disclosureCheckbox.checked) {
        disclosureInput.style.display = "block";
    } else {
        disclosureInput.style.display = "none";
    }
}

