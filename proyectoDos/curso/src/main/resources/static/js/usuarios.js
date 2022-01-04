// Call the dataTables jQuery plugin
$(document).ready(function() {
  cargarUsuarios();
  $('#usuarios').DataTable();
});

async function cargarUsuarios(){
    const request = await fetch('api/usuarios', {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    });
    const usuarios = await request.json();

    let listadoHtml = '';
    for(let usuario of usuarios){
        let botonEditar = '<a href="#" onClick="actualizarUsuario('+ usuario.id +')" class="btn btn-success btn-circle btn-sm"><i class="fas fa-check"></i></a>';
        let botonEliminar = '<a href="#" onClick="eliminarUsuario('+ usuario.id +')" class="btn btn-danger btn-circle btn-sm"><i class="fas fa-trash"></i></a>';
        let telefono = usuario.telefono == null ? '-' : usuario.telefono;
        let usuarioHtml = '<tr><td>'+ usuario.id +'</td><td>'+ usuario.nombre +
        ' '+ usuario.apellido +'</td><td>'+ usuario.email +'</td><td>'+ telefono +
        '</td><td>'+ botonEditar + botonEliminar +'</td></tr>';
        listadoHtml += usuarioHtml;
    }
    console.log(usuarios);

    document.querySelector('#usuarios tbody').outerHTML = listadoHtml;
}

async function eliminarUsuario(id){
    if(!confirm('Desea eliminar este usuario?')){
        return;
    }
    console.log('usuario para eliminar: '+id);
        const request = await fetch('api/usuario/' + id, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
    location.reload();
}

async function actualizarUsuario(id){
    if(!confirm('Desea eliminar este usuario?')){
        return;
    }
    console.log('usuario para actualizar: '+id);
    const request = await fetch('api/usuario/' + id, {
         method: 'UPDATE',
         headers: {
             'Accept': 'application/json',
              'Content-Type': 'application/json'
         }
      });
    location.reload();
}
