let serachBox = document.getElementById("search-box");
let serachSelector = document.getElementById("search-selector");
let noUsersRow = document.getElementById("NoUsers");
let searchText = "";

let checkBoxAdmin = document.getElementById("checkbox-admin");
let checkBoxUser = document.getElementById("checkbox-user");
let checkBoxBanned = document.getElementById("checkbox-banned");

let isAnyCheckBoxChecked = false;


function search() {

    isAnyCheckBoxChecked = checkBoxAdmin.checked || checkBoxUser.checked || checkBoxBanned.checked;

    let searchElementsCategory = Array.from(document.getElementsByTagName("td"));

    searchText = serachBox.value;

    let isThereSuchElement = searchElementsCategory.find(element => getElement(element));


    if (isThereSuchElement) {

        searchElementsCategory.forEach(element => filterTheElements(element));
        noUsersRow.style.display = "none";

    } else {
        searchElementsCategory.forEach(element => filterTheElements(element));


        noUsersRow.style.display = "table-row";
    }


}

function filterTheElements(element) {


    if (isAnyCheckBoxChecked) {

        let roles = [];

        if (checkBoxAdmin.checked) {
            roles.push("Admin");

        } else if (checkBoxUser.checked) {
            roles.push("User");

        } else if (checkBoxBanned.checked) {
            roles.push("Banned");

        }


        if (element.getAttribute('name') === serachSelector.value) {

            let role = Array.from(element.parentElement.children).find(child => getRoleElement(child)).innerText;


            if (!element.innerText.toUpperCase().includes(searchText.toUpperCase()) ||
                !roles.includes(role)) {

                element.parentElement.style.display = "none";

            } else {

                let isTheElementHidden = element.parentElement.style.display === "none";


                if (isTheElementHidden) {

                    element.parentElement.style.display = "table-row";
                }
            }

        }

    } else {


        if (element.getAttribute('name') === serachSelector.value) {

            if (!element.innerText.toUpperCase().includes(searchText.toUpperCase())) {

                element.parentElement.style.display = "none";

            } else {

                let isTheElementHidden = element.parentElement.style.display === "none";


                if (isTheElementHidden) {

                    element.parentElement.style.display = "table-row";
                }
            }

        }

    }

}

function getElement(element) {

    if (isAnyCheckBoxChecked) {

        let roles = [];

        if (checkBoxAdmin.checked) {
            roles.push("Admin");

        } else if (checkBoxUser.checked) {
            roles.push("User");

        } else if (checkBoxBanned.checked) {
            roles.push("Banned");

        }


        if (element.innerText.toUpperCase().includes(searchText.toUpperCase()) &&
            element.getAttribute('name') === serachSelector.value) {


            let role = Array.from(element.parentElement.children).find(child => getRoleElement(child)).innerText;

            return roles.includes(role);
        } else {

            return false;
        }

    } else {

        return element.innerText.toUpperCase().includes(searchText.toUpperCase()) &&
            element.getAttribute('name') === serachSelector.value;
    }
}

function getRoleElement(child) {
    return child.getAttribute('name') === "Role"
}
