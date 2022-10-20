function solve() {

    let recName = document.getElementById("recipientName");
    let title = document.getElementById("title");
    let message = document.getElementById("message");

    document.getElementById("add").addEventListener("click", add);
    document.getElementById("reset").addEventListener("click", reset);

    function add(e) {
        e.preventDefault();
        if (recName.value !== "" && title.value !== "" && message.value !== "") {
            let ulToAttachTheLi = document.getElementById("list");

            let li = document.createElement("li");
            let h4Title = document.createElement("h4");
            h4Title.innerText = "Title: " + title.value;

            let h4RecName = document.createElement("h4");
            h4RecName.innerText = "Recipient Name: " + recName.value;

            let spanMessage = document.createElement("span");
            spanMessage.innerText = message.value;

            let innerDiv = document.createElement("div");
            innerDiv.setAttribute("id", "list-action")

            let sendButton = document.createElement("button");
            sendButton.setAttribute("type", "submit"); /////
            sendButton.setAttribute("id", "send");
            sendButton.innerText = "Send";

            let deleteButton = document.createElement("button");
            deleteButton.setAttribute("type", "submit");
            deleteButton.setAttribute("id", "delete");
            deleteButton.innerText = "Delete";

            li.appendChild(h4Title);
            li.appendChild(h4RecName);
            li.appendChild(spanMessage);

            innerDiv.appendChild(sendButton);
            innerDiv.appendChild(deleteButton);
            li.appendChild(innerDiv);
            ulToAttachTheLi.appendChild(li);

            recName.value = "";
            title.value = "";
            message.value = "";

            sendButton.addEventListener("click", send);

            function send(e) {
                let sentMailsBoxUL = document.getElementsByClassName("sent-list")[0];

                let liSent = document.createElement("li");

                let spanTo = document.createElement("span");
                spanTo.innerText = "To: " + h4RecName.innerText.substring(15) + " ";

                let spanTitle = document.createElement("span");
                spanTitle.innerText = "Title: " + h4Title.innerText.substring(7);

                liSent.appendChild(spanTo);
                liSent.appendChild(spanTitle);

                let divInSent = document.createElement("div");
                divInSent.classList.add("btn");

                let butInSent = document.createElement("button");
                butInSent.setAttribute("type", "submit");
                butInSent.setAttribute("class", "delete");
                butInSent.innerText = "Delete";

                divInSent.appendChild(butInSent);
                liSent.appendChild(divInSent);

                sentMailsBoxUL.appendChild(liSent);

                e.target.parentElement.parentElement.remove()

                let deleteButton2 = document.getElementsByClassName("delete")[0];
                deleteButton2.addEventListener("click", deleteBtns)
            }

            let deleteButton1 = document.getElementById("delete")
            let deleteButton2 = document.getElementsByClassName("delete")[0];

            deleteButton1.addEventListener("click", deleteBtns)
            deleteButton2.addEventListener("click", deleteBtns)

            function deleteBtns(e) {
                let ulDeleteList = document.getElementsByClassName("delete-list")[0];
                let titleToDelete = e.target.parentElement.parentElement.childNodes[0];
                let recToDelete = e.target.parentElement.parentElement.childNodes[1];

                let span1Del = document.createElement("span");
                span1Del.innerText = titleToDelete.innerText + " ";

                let spand2Del = document.createElement("span");
                spand2Del.innerText = recToDelete.innerText;

                let liToDel = document.createElement("li");
                
                liToDel.appendChild(span1Del);
                liToDel.appendChild(spand2Del);
                ulDeleteList.appendChild(liToDel);

                e.target.parentElement.parentElement.remove();
            }
        }
    }
    function reset(e) {
        e.preventDefault();
        recName.value = "";
        title.value = "";
        message.value = "";
    }
}



solve()