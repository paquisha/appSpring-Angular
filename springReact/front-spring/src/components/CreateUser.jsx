import React from 'react'

export default function CreateUser() {

  const crearUsuario = (e) => {
    e.preventDefault();
    const nombre = e.target.valor1.value;
    const email = e.target.valor2.value;
    const prioridad = parseInt(e.target.valor3.value, 10);
    console.log(`nombre: ${nombre}, email: ${email}, prioridad: ${prioridad}`)
  }

  return (
    <div>
        <div className='container'>
            <form onSubmit={crearUsuario}>
              <h5>Crear Usuario</h5>
                <div className='mb-3'>
                  <label className='form-label'>Ingrese Nombre</label>
                  <input type='number' className='form-control' name='valor1' placeholder='Ingrese Nombre' />
                </div>
                <div className='mb-3'>
                  <label className='form-label'>Ingrese email</label>
                  <input type='number' className='form-control' name='valor2' placeholder='Ingrese email' />
                </div>
                <div className='mb-3'>
                  <label className='form-label'>Ingrese prioridad</label>
                  <input type='number' className='form-control' name='valor3' placeholder='Ingrese prioridad' />
                </div>
                <div>
                <button type='submit' className='btn btn-success'>Crear</button>
                </div>
            </form>
        </div>
    </div>
  )
}
