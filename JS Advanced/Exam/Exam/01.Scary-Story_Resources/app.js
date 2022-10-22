window.addEventListener("load", solve);

function solve() {
  document.getElementById("form-btn").addEventListener("click", publish);
  let firstName = document.getElementById("first-name");
  let lastName = document.getElementById("last-name");
  let age = document.getElementById("age");
  let storyTitle = document.getElementById("story-title");
  let genre = document.getElementById("genre");
  let myStory = document.getElementById("story");



  function publish(e) {
    e.preventDefault();
    let firstNameValue = firstName.value;
    let lastNameValue = lastName.value;
    let ageValue = age.value;
    let storyTitleValue = storyTitle.value;
    let genreValue = genre.value
    let myStoryValue = myStory.value;
    if (firstNameValue === "" || lastNameValue === "" || ageValue === "" || storyTitleValue === "" || genreValue === "" || myStoryValue === "") {
      return;
    }

    let ulFather = document.getElementById("preview-list");
    let li = document.createElement("li");
    li.classList.add("story-info");

    let article = document.createElement("article");

    let h4 = document.createElement("h4");
    h4.textContent = "Name: " + firstNameValue + " " + lastNameValue;

    let pAge = document.createElement("p");
    pAge.textContent = "Age: " + ageValue;

    let pTitle = document.createElement("p");
    pTitle.textContent = "Title: " + storyTitleValue;

    let pGenre = document.createElement("p");
    pGenre.textContent = "Genre: " + genreValue;

    let pTextStory = document.createElement("p");
    pTextStory.textContent = myStoryValue;

    article.appendChild(h4);
    article.appendChild(pAge);
    article.appendChild(pTitle);
    article.appendChild(pGenre);;
    article.appendChild(pTextStory);

    li.appendChild(article);

    let saveButton = document.createElement("button");
    saveButton.classList.add("save-btn");
    saveButton.innerText = "Save Story";

    let editButton = document.createElement("button");
    editButton.classList.add("edit-btn");
    editButton.innerText = "Edit Story";

    let deleteButton = document.createElement("button");
    deleteButton.classList.add("delete-btn");
    deleteButton.innerText = "Delete Story";

    li.appendChild(saveButton);
    li.appendChild(editButton);
    li.appendChild(deleteButton);

    ulFather.appendChild(li);
    e.target.disabled = true;

    firstName.value = "";
    lastName.value = "";
    age.value = "";
    storyTitle.value = "";
    genre.value = "";
    myStory.value = "";

    editButton.addEventListener("click", edit)

    function edit(e) {
      let liToRemove = e.target.parentNode;

      firstName.value = firstNameValue;
      lastName.value = lastNameValue;
      age.value = ageValue;
      storyTitle.value = storyTitleValue;
      genre.value = genreValue
      myStory.value = myStoryValue;

      liToRemove.remove();

      let publishButton = document.getElementById("form-btn");
      publishButton.disabled = false;
    }

    saveButton.addEventListener("click", save);
    function save(e){
      let mainDiv = document.getElementById("main");
      
      mainDiv.remove();

      let newDiv = document.createElement("div");
      newDiv.setAttribute("id","main");

      let newH1 = document.createElement("h1");
      newH1.innerText = "Your scary story is saved!";
      newDiv.appendChild(newH1);

      let body = document.getElementsByClassName("body")[0];
      body.appendChild(newDiv);
    }

    deleteButton.addEventListener("click", deleteFunc);

    function deleteFunc (e){
      e.target.parentNode.remove();
      publishButton.disabled = false;
    }

  }
}
