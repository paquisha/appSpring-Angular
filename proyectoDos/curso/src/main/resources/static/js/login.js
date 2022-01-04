// Call the dataTables jQuery plugin
$(document).ready(function() {
  //$('#usuarios').DataTable();
});

async function IniciarSesion(){

    let datos = {};
    datos.email = document.getElementById('txtEmail').value;
    datos.password = document.getElementById('txtPassword').value;

    const request = await fetch('api/login', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datos)
    });

    const response = await request.text();

    if(response == 'OK'){
        window.location.href = 'usuarios.html';
    }else{
        alert('credenciales Incorrectas');
    }
    //location.reload();
}
