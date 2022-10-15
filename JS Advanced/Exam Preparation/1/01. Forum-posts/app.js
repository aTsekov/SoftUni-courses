window.addEventListener("load", solve);

function solve() {
    document.getElementById("publish-btn").addEventListener("click", post);
    document.getElementById("clear-btn").addEventListener("click", clear);

    let title = document.getElementById("post-title");
    let category = document.getElementById("post-category");
    let content = document.getElementById("post-content");


    function post(event) {
        let titleValue = title.value;
        let categoryValue = category.value;
        let contentValue = content.value;
        if(titleValue === "" || categoryValue === "" || contentValue === ""){
            return;
        }

        let ulReviewList = document.getElementById("review-list");
        let li = document.createElement("li");
        li.classList.add("rpost");
        let article = document.createElement("article");

        let h4 = document.createElement("h4");
        h4.textContent = titleValue;

        let p1 = document.createElement("p");
        p1.textContent = "Category: " + categoryValue;

        let p2 = document.createElement("p");
        p2.textContent ="Content: " + contentValue;

        let editButton = document.createElement("button");
        editButton.textContent = "Edit";
        editButton.classList.add("action-btn");
        editButton.classList.add("edit");

        let approveButton = document.createElement("button");
        approveButton.textContent = "Approve";
        approveButton.classList.add("action-btn");
        approveButton.classList.add("approve");
        article.appendChild(h4);
        article.appendChild(p1);
        article.appendChild(p2);
        li.appendChild(article);
        li.appendChild(approveButton);
        li.appendChild(editButton);
       
        ulReviewList.appendChild(li);
        title.value = "";
        category.value = "";
        content.value = "";

        let edits = document.getElementsByClassName("action-btn edit");
        for (let editButton of edits) { 
            editButton.addEventListener("click", editText);
        }
       
    
        function editText (e){
            let rpost = e.target.parentNode;
            rpost.childNodes[0].childNodes
            title.value =  rpost.childNodes[0].childNodes[0].innerText;
            category.value =  rpost.childNodes[0].childNodes[1].innerText.substring(9);
            content.value =  rpost.childNodes[0].childNodes[2].innerText.substring(9);
            rpost.remove();

        }

        let approveBtns = document.getElementsByClassName("action-btn approve");
        for (let approveBtn of approveBtns) { 
            approveBtn.addEventListener("click",approve);
        }
        

       

    }
    function approve(e){
        let butt = e.target;
        let publishedRecords = document.getElementById("published-list");
        let ulReviewList = document.getElementById("review-list");
        // The problem is somewhere here. THe two buttons are not deleted. 
        let h4 = butt.parentNode.childNodes[0].childNodes[0]
        let p1 = butt.parentNode.childNodes[0].childNodes[1]
        let p2 = butt.parentNode.childNodes[0].childNodes[2]
        
        let art = document.createElement("article");
        art.appendChild(h4);
        art.appendChild(p1);
        art.appendChild(p2);
   
        publishedRecords.appendChild(art);

        

        //ulReviewList.childNodes[1].remove()
        //return;
        

    }
    function clear(e){
        let publishedRecords = document.getElementById("published-list").remove();

    }



   
}

