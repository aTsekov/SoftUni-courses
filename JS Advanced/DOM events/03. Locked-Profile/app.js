function lockedProfile() {

    let showMoreButtons = Array.from(document.getElementsByTagName("button"));

    for (let button of showMoreButtons) {
        button.addEventListener("click", showMore);
    }
    function showMore(event) {

        let but = event.target; // this is the button "Show more" or "Hide it". 
        let profile = but.parentNode; // this is the div element with class "profile". 
        let moreInformation = profile.getElementsByTagName('div')[0]; // this is the div element with ID user1HiddenFields or user2HiddenFields etc.
        let lockUnclockButtons = profile.querySelector("input[type=radio]:checked").value; //This shows if the radio button in the big DIV element 
        // with class "profile" is locked or not. 

        if (lockUnclockButtons === "unlock") {
            if (but.textContent === "Show more") {
                moreInformation.style.display = "inline-block"
                event.target.innerText = "Hide it";
            }
            else {
                moreInformation.style.display = "none";
                event.target.innerText = "Show more";
            }

        }
        

    }

}
