let serachBox = document.getElementById("search-box");
let serachSelector = document.getElementById("search-selector");
let noUsersRow = document.getElementById("NoUsers");
let searchText = "";



function search() {


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

function getElement(element) {


    return element.innerText.toUpperCase().includes(searchText.toUpperCase()) &&
        element.getAttribute('name') === serachSelector.value;

}
