function generateReport() {
    let tableRows = Array.from(document.querySelectorAll('tbody tr')); 
    let columnName = Array.from(document.querySelectorAll('thead tr'));
    let checkboxes = Array.from(document.querySelectorAll('input[type=checkbox]'))
    let myObj = {};
    

        for (const checkbox of checkboxes) {
            if(checkbox.checked){

                let propertyName = checkbox.name;

                for (const r of tableRows){
                    obj = {};
                    obj = r.textContent;
                    console.log(obj);
                    myObj.propertyName = obj[propertyName];
                    console.log(myObj)
                }

            }
        }
        
    
}