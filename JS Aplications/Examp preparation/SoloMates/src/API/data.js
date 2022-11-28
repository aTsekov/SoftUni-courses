import  *  as api from './api.js';

const endpoint = {
    "login": "users/login",
    "register": "users/register",
    "logout": "users/logout",
    "getAllItems": "data/shoes?sortBy=_createdOn%20desc", // CHECK ALL URLS AS THE SLASH/ SHOULD BE HERE AND NOT ON THE HOST.
    "getElementById":"data/shoes/",
    "deleteItemById": "/data/shoes/",
    "createItem": "data/shoes",
    "updateItemById" :"data/shoes/"    

}

//const url = "http://localhost:3030/";

//Prepare a function for each action we will need to perform with the required information. 

export async function login (email, password){
   
    const res = await api.post(endpoint.login,{email, password})    
    sessionStorage.setItem("userData", JSON.stringify(res));
}

export async function register (email, password){
    
    const res = await api.post(endpoint.register,{email, password})
    sessionStorage.setItem("userData", JSON.stringify(res));
    return res;
}

export async function logout (){
    const res = api.get(endpoint.logout)
    sessionStorage.removeItem("userData") //this actually logs out the user.
    return res;
}

export async function getAllItems (){
    const res = await api.get(endpoint.getAllItems)    
    return res;
}
export async function getItemById (id){
    const res = await api.get(endpoint.getElementById + id,)     
    return res;
}
export async function deleteItemById (id){
    const res = await api.del(endpoint.getElementById + id)    
    return res;
}

export async function createItem (data){
    const res = await api.post(endpoint.createItem,data)    
    return res;
}
export async function updateItemById (id, data){
    const res = await api.put(endpoint.getElementById + id, data)    
    return res;
}
