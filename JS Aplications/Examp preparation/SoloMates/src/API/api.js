const host = "http://localhost:3000"; // maybe my local host is wrong. to test this!!

async function request ( url, options){
    try {
        const response = await fetch (host, url, options)
        if (!response.ok){
            const err = await Response.json();
            throw new Error(err.message);
        }
        try {
            if(response.status === 204){
                return response //if 204 the response is empty
            }

            const data = await response.json()

            return data;
        } catch (error) {
            alert(error.message);
            throw error;
        }
        
    } catch (error) {
        alert(error.message);
            throw error;
    }
}

function getOptions (method, body){
    const options = {
        method,
        headers: {}
    }

    const user = JSON.parse(sessionStorage("userData"));

    if (user){
        const token = user.accessToken;
        options.headers["X-Authorization"] = token;
    }
    if(body){
        options.headers["content-Type"] = "Application/json";
        options.body = JSON.stringify(body);
    }
}

//Provide the necessary data for each different request
export async function get(url) { // GET needs only the url
    return await request(url, getOptions("GET"))
}
export async function post(url, data) {// POST needs url, headers and body. 
    
    return await request(url, getOptions("POST", data))
}
export async function put(url, data) {//PUT needs url, headers and body. 
    return await request(url, getOptions("PUT", data))
}
export async function del(url) {//DELETE needs url only.  
    return await request(url, getOptions("DELETE"))
}