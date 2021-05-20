const API = "http://localhost:5000/Questionario"

async function getQuestionarios(userId) {
    const url = await buildUrl(API + "/GetAll", params = { userId: userId });
    let data = await request(url);
    print(data);
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
    let list = document.querySelector('.list-group');
    data.forEach(values => {
        const node = document.querySelector("#list-element").cloneNode(true);
        node.id = values.id
        node.titulo = values.titulo
        node.querySelector("#titulo").innerText = values.titulo
        list.appendChild(node);
    });
    document.querySelector("#carregando").remove();
}

function beginQuestionario(id) {
    window.sessionStorage.setItem("id", id);
}


getQuestionarios(1);
