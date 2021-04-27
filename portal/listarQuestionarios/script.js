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

  const request = await fetch("https://localhost:5001/Questionario/Create", requestOptions)
  const data = await request.json();
  data.then();
});

