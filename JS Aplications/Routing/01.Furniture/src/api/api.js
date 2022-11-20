const host = "http://localhost:3030/"


async function request (url, options) {
    try{
        const response = await fetch (host + url, options); //Make a request to the server to the relevant endpoint and with the
        //correct options. The options will determine if the request is GET, POST,PUT or DELETE and it will add body if necessary. 

        if(!response.ok){ // if we do not have a response from the server throw an error. This is the possible server error
            //such as a bad request. In this case the "OK" will be false;
            const error = await Response.json();
            throw new Error(error.message);
        }
        try{
            const data = await response.json(); // wait for response from the server.
            // if the response is "OK" then but the data is missing then this should also throw an error;
            return data;
        }
        catch(e){
            alert(e.message);
            return error;
        }
    }
    catch(e){
        alert(e.message);
        return error;
    }
}

function getOptions(method, body){ // Here we create the options for the request. 
    const options = {
        method,
        headers: {}
    }
    const user = JSON.parse(sessionStorage.getItem("userData")); //Get the user if it is logged in.
    
    if (user) { // if it is logged in gets the user's access token and add it to the authorization header.
        const token = user.accessToken;
        options.headers["X-Authorization"] = token;
    }
    if(body){ // if we have body we add the header and the body to the options so we can give options to the request function.
        options.headers["Content-Type"] = "Application/json"
        options.body = JSON.stringify(body);
    }
    return options;
}


//Provide the necessary data for each different request
export async function get (url){ // GET needs only the url
    return await request(url, getOptions("GET"))
}
export async function post (url, data){// POST needs url, headers and body. 
    debugger;
    return await request(url, getOptions("POST", data))
}
export async function put (url,data){//PUT needs url, headers and body. 
    return await request(url, getOptions("PUT",data))
}
export async function del (url){//DELETE needs url only.  
    return await request(url, getOptions("DELETE"))
}