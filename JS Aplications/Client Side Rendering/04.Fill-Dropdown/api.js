

const host = 'http://localhost:3030';

async function requester (method, url, body){
    const option = {
        method,
        headers: {}
    }

    if (body){
        option.headers["Content-Type"] = "Application/json";
        option.body = JSON.stringify(body);
    }
    const response = await fetch (host + url, option);
    const dataFromServer = await response.json();
    return Object.values(dataFromServer);
}



export {
    requester
}