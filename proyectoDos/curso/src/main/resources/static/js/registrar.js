// Call the dataTables jQuery plugin
$(document).ready(function() {
  //$('#usuarios').DataTable();
});

async function registrarUsuarios(){

    let datos = {};
    datos.nombre = document.getElementById('txtNombre').value;
    datos.apellido = document.getElementById('txtApellido').value;
    datos.telefono = document.getElementById('txtTelefono').value;
    datos.email = document.getElementById('txtEmail').value;
    datos.password = document.getElementById('txtPassword').value;

    let repetirPassword = document.getElementById('txtRepitPassword').value;

    console.log(datos);

    if(repetirPassword != datos.password){
        alert('La contrase;a es diferente');
        return;
    }

    const request = await fetch('api/usuario', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datos)
    });
    //const usuario = await request.json();

    location.reload();

}
