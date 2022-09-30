function addItem() {
    
    let  itemText = document.getElementById("newItemText").value;
    let itemValue = document.getElementById("newItemValue").value;
    let option = document.createElement('option');
    option.textContent = itemText;
    option.value = itemValue;

    let menu = document.getElementById('menu');
    menu.appendChild(option);

let empty ='';

    document.getElementById("newItemText").value = empty;
    document.getElementById("newItemValue").value = empty;
}