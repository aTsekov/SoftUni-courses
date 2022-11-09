function attachEvents() {
    const loadButton = document.getElementById('btnLoad');
    loadButton.addEventListener('click', loadRecords);
    const ulPhoneBook = document.getElementById('phonebook');
    const personField = document.getElementById('person');
    const phoneField = document.getElementById('phone');
    const createButton = document.getElementById('btnCreate');
    createButton.addEventListener("click", postInPhoneBook);
    
   


    async function postInPhoneBook() {

        const body = {
            "person": personField.value,
            "phone": phoneField.value
        };

        if (personField.value !== "" && phoneField.value !== "") {
            const urlPostData = 'http://localhost:3030/jsonstore/phonebook'
            const response = await fetch(urlPostData, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(body)
            });
            personField.value = "";
            phoneField.value = "";
            loadRecords();
        }
    }

    function displayRecords(data) {
        ulPhoneBook.innerHTML = "";

        let str = "";
        for (const el of data) {
            str = `${el.person}: ${el.phone}`
            const li = document.createElement('li');
            li.innerText = str;
            li.setAttribute("data-id", el._id);

            const deleteButton = document.createElement('button');
            deleteButton.innerText = "Delete";           

            li.appendChild(deleteButton);
            ulPhoneBook.appendChild(li);
            deleteButton.addEventListener('click',deletePostInPhoneBook);
        }
    }

    async function loadRecords() {
        const urlGET = `http://localhost:3030/jsonstore/phonebook`;
        const res = await fetch(urlGET);
        const DBreply = await res.json();
        const reply = Object.values(DBreply);

        return displayRecords(reply);
    }
    function deletePostInPhoneBook(e){
        
        let li= e.target.parentElement;
        let id = li.getAttribute('data-id')
        deleteRecord(id);
        loadRecords();
    }

    async function deleteRecord(id){
        const urlToDelete = `http://localhost:3030/jsonstore/phonebook/${id}`
        const result = await fetch(urlToDelete,{
            method: 'DELETE',
            headers:{},
            body: JSON.stringify(null)

        });
    }

}





attachEvents();