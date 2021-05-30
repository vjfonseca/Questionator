let formQuestionario = document.querySelector("#formQuestionario");
const submitEvent = formQuestionario.addEventListener('submit', async function (e) {
  e.preventDefault();

  const formData = new FormData(this);
  let object = {};
  formData.forEach((value, key) => object[key] = value);
  const json = JSON.stringify(object);

  var myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  var requestOptions = {
    method: 'POST',
    headers: myHeaders,
    body: json,
    redirect: 'follow'
  };

  const request = await fetch("http://localhost:5000/Questionario/Create", requestOptions)
  const data = await request.json();
  data.then(window.location.href = '..');
});


// ----- A TESTAR ------
// let formQuestionario = document.querySelector("#formQuestionario");
// const submitEvent = formQuestionario.addEventListener('submit', async function (e) {
//   e.preventDefault();

//   const formData = new FormData(this);
//   let object = {};
//   formData.forEach((value, key) => object[key] = value);
//   const json = JSON.stringify(object);

//   const request = buildRequestOptions(json);

//   const request = await fetch("https://localhost:5001/Questionario/Create", request)
//   const data = await request.json();
//   data.then(window.location.href = ("http://127.0.0.1:5500/portal/questionarios/"));
// });

// function buildRequestOptions(json) {
//   let myHeaders = new Headers();
//   myHeaders.append("Content-Type", "application/json");

//   const requestOptions = {
//     method: 'POST',
//     headers: myHeaders,
//     body: json,
//     redirect: 'follow'
//   };
//   return requestOptions
// }
