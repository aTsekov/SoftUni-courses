window.addEventListener("load", solve);

function solve() {
    document.getElementById("publish-btn").addEventListener("click", post);
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

    }
}

