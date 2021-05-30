const API = "http://localhost:5000/Questionario"

async function getQuestionario() {
    const id = await sessionStorage.getItem("id");
    const url = await buildUrl(API + "/GetById", params = { id: id });
    const data = await requestGet(url);
    print(data);
}
async function buildUrl(url, params) {
    var url = new URL(url),
        params = params
    Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
    return url;
}
async function requestGet(url) {
    var requestOptions = {
        method: 'GET',
    };
    const request = await fetch(url, requestOptions)
    const data = await request.json();
    return data;
}
function print(data) {
    if (!data) { console.log("data vazio") }
    else {
        document.querySelector("#titulo").textContent = data.titulo;
        const q = document.querySelector(".perguntas");
        const clone = document.querySelector("#perguntaTemplate").cloneNode(true);
        data.perguntas.forEach(pergunta => {
            const p = clone.cloneNode(true);
            p.querySelector("h6").innerText = pergunta.texto
            p.querySelector("textarea").name = pergunta.id
            q.appendChild(p);
        });
    }
}
/* ---------*/
const submitEvent = formResponder.addEventListener('submit', async function (e) {
    e.preventDefault();
    const respostas = buildFormData2(this);
    const url = API + "/AddResposta";
    const response = postParallel(url, respostas);
});
function buildFormData2(form) {
    let formData = new FormData(form);
    let arr = new Array();
    formData.forEach((value, key) => {
        arr.push({
            "perguntaId": key,
            "texto": value
        })
    });
    return arr;
}
function postOptions(json) {
    const myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    const requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: json,
        redirect: 'follow'
    };
    return requestOptions;
}
async function postParallel(url, data) {
    const prom = data.map(async (element) =>{
        await fetch(url, postOptions(JSON.stringify(element)))
    })

    const ok = await Promise.all(prom);
    ok.forEach(element => {
        element.text
    });
}
console.log('FALTER TRATAR O RETORNO DO PROM DE POST PARALLEL')
getQuestionario();