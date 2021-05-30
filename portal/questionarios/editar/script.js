const API = "http://localhost:5000/Questionario"

GetQuestionario()
async function GetQuestionario() {
    const url = await buildUrl(API + "/GetById", params = { id: window.localStorage.getItem("id") });
    const data = await request(url);
    print(data);
    console.log(data);
}
async function buildUrl(url, params) {
    var url = new URL(url),
        params = params
    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    return url;
}
async function request(url) {
    var requestOptions = {
        method: 'GET',
    };
    const request = await fetch(url)
    const data = await request.json();
    return data;
}

function print(data) {
    document.querySelector("#carregando").style.display = "none";
    document.querySelector("#questionarioArea").style = null;

    document.querySelector("#titulo").innerHTML = data.titulo
}   

