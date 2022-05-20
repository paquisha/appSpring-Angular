// Call the dataTables jQuery plugin
$(document).ready(function() {
  getUsuarios();
  $('#dataTable').DataTable();
});

async function getUsuarios(){
  const getUsuarios = await fetch('usuarios', {
    method: 'GET',
    headers:{
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    }
  });
  const usuarios = await getUsuarios.json();

  let listadoHtml = '';

  for(let usuario of usuarios){
    let usuarioHtml =
    `
      <td>${usuario.id}</td>
      <td>${usuarios.nombre} ${usuario.apellido}</td>
      <td>${usuario.email}</td>
      <td>${usuarios.telefono}</td>
      <td>
          <a href="#" class="btn btn-danger btn-circle btn-sm">
              <i class="fas fa-trash"> <i/>
          </a>
      </td>
    `;
    listadoHtml += usuarioHtml;
  }

  console.log(usuarios);

  document.querySelector('#usuarios tbody').outerHTML = usuario;
}