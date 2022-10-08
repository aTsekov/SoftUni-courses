function validate(objHTTP) {
    let possibleMethods = ["GET", "POST", "DELETE", "CONNECT"]
    let uriPattern = /^[\w.]+$/g;
    let versions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
    let specialChars = [`<`, `>`, `\\`,`&`, `'`, `"` ]

    if(!possibleMethods.includes(objHTTP.method)) {
        throw new Error("Invalid request header: Invalid Method");
    }
    if(!objHTTP.hasOwnProperty("uri")){ // checks if the object has its own property
        throw new Error("Invalid request header: Invalid URI");
    }
    if(!objHTTP.uri.match(uriPattern) && objHTTP.uri !== "*"){ //Should it be && or ||?
        throw new Error("Invalid request header: Invalid URI");
    }
    if(!versions.includes(objHTTP.version)){
        throw new Error("Invalid request header: Invalid Version");
    }
    if(!objHTTP.hasOwnProperty("message")){
        throw new Error("Invalid request header: Invalid Message");
    }
    if(specialChars.includes(objHTTP.message)){
        throw new Error("Invalid request header: Invalid Message");
    }
    
    return objHTTP;

}

validate({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
})
validate({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
})
validate({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
})