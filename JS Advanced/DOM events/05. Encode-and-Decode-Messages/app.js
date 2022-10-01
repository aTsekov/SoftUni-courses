function encodeAndDecodeMessages() {
    
    let button = document.addEventListener('click', transform);


    function transform (event) {
        let but = event.target;
        
        let textElements = Array.from(document.getElementsByTagName('textarea'));

        let stringToTransform;
        let result ="";

        //debugger;
        if(but.textContent === "Encode and send it"){
            stringToTransform = textElements[0].value;

            for (let i = 0; i < stringToTransform.length; i++) {
                let charNum = stringToTransform.charCodeAt(i);
                charNum += 1;
                result += String.fromCharCode(charNum);
                
            }
            textElements[0].value = "";
            textElements[1].value = result;
            let test = textElements[1].value
            console.log(test);

        }
        else if(but.textContent ==="Decode and read it"){
            stringToTransform = textElements[1].value;

            for (let i = 0; i < stringToTransform.length; i++) {
                let charNum = stringToTransform.charCodeAt(i);
                charNum -= 1;
                result += String.fromCharCode(charNum);
                
            }
            textElements[1].value = result;
        }
    }
}