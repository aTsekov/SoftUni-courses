function attachEvents() {
    const sendButton = document.getElementById('submit');
    document.getElementById('refresh').addEventListener('click', loadMessages);

    sendButton.addEventListener('click', PostDataOnServer);
    loadMessages();  
}
async function loadMessages() {
    const url = `http://localhost:3030/jsonstore/messenger`;
    const res = await fetch(url);
    const data = await res.json();
 
    const messages = Object.values(data);
    const list = document.getElementById('messages');
    list.value = messages.map(m => `${m.author}: ${m.message}`).join(`\n`);
}

 function onSubmit(data) {

    const list = document.getElementById('messages');
    list.value += '\n' + `${data.author}: ${data.message}`;

}
async function PostDataOnServer() {
    const author = document.querySelectorAll("input[name='author']")[0].value;
    const message = document.querySelectorAll("input[name='content']")[0].value;

    const urlPostData = 'http://localhost:3030/jsonstore/messenger'
    const response = await fetch(urlPostData, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({author,message})
    });

    const dataResponseFromServer = await response.json()    
    document.querySelectorAll("input[name='author']")[0].value = "";
    document.querySelectorAll("input[name='content']")[0].value = "";
    onSubmit(dataResponseFromServer);

    return dataResponseFromServer;
}

attachEvents();