function errorMessage(carId) {

    var password = document.getElementById(`${carId.toString()}`);
    var errSpan = document.getElementById(`err-span-${carId.toString()}`)

    password.addEventListener("input", changeValidity(event));

    function changeValidity(e) {

        if (password.validity.patternMismatch) {
            password.setCustomValidity(' ');

            errSpan.innerText = "Invalid Password!";
        } else {
            password.setCustomValidity("");

        }
    };
}


function showRemoveTr(carId) {

    let removeTr = document.getElementById(`remove-tr-${carId.toString()}`);

    removeTr.style.display = "table-row";



}
function collapseRemoveTd(carId) {

    let id = carId.toString();

    let removeTr = document.getElementById(`remove-tr-${id}`);
    var errSpan = document.getElementById(`err-span-${id}`)
    var passwordInput = document.getElementById(`${id}`)

    removeTr.style.display = 'none';
    errSpan.innerHTML = '';
    passwordInput.value = '';

}