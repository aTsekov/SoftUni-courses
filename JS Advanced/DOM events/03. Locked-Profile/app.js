function lockedProfile() {

    let lockUnclockButtons = Array.from(document.querySelectorAll("input[type=radio]"));
    let showMoreButtons = Array.from(document.getElementsByTagName("button"));

    for (const lockBut of lockUnclockButtons) {
        lockBut.addEventListener("click", lock);

        function lock(event) {

            if (lockBut.value === "unlock") {
                for (let button of showMoreButtons) {
                    button.addEventListener("click", showMore);
                }

            }
        }

    }
    function showMore(event) {
        let user1Div = document.getElementById("user1HiddenFields");
        let but = event.target.innerText;

        if (but === "Show more") {
            user1Div.style.display = "inline-block"
            event.target.innerText = "Hide It";
        }
        else {
            user1Div.style.display = "none";
            event.target.innerText = "Show more";
        }

    }
}
