import * as api from './api.js';
const endpoint = {
    "login": "users/login",
    "register": "users/register",
    "logout": "users/logout",
    "createItem": "data/catalog",
    "getAllItems": "data/catalog",
    "getElementById": "data/catalog",
    "myItems": "data/catalog?where=_ownerId%3D%22"

}

const url = "http://localhost:3030/";

//Prepare a function for each action we will need to perform with the required information. 

export async function login (email, password){
    const res = await api.post(endpoint.login,{email, password})
    sessionStorage.setItem("userData", JSON.stringify(res));
    return res;
}

export async function register (email, password){
    
    const res = await api.post(endpoint.register,{email, password})
    sessionStorage.setItem("userData", JSON.stringify(res));
    return res;
}

export async function logout (){
    const res = await api.get(endpoint.logout)
    sessionStorage.removeIte("userData") //this actually logs out the user.
    return res;
}
export async function createItem (data){
    const res = await api.post(endpoint.createItem,data)    
    return res;
}
export async function getAllItems (data){
    const res = await api.get(endpoint.getAllItems,data)    
    return res;
}
export async function getItemById (id){
    const res = await api.get(endpoint.getElementById + id,)     
    return res;
}
export async function updateItemById (id, data){
    const res = await api.put(endpoint.getElementById + id, data)    
    return res;
}
export async function deleteItemById (id){
    const res = await api.del(endpoint.getElementById + id)    
    return res;
}
export async function getMyItems (){
    const userData = JSON.parse(sessionStorage(getItem("userData")));
    const userId = userData && userData._id // if there is user data - only in this case take the ID
    let id = `${userId}%22`
    const res = await api.get(endpoint.myItems + id)   

    return res;
}

