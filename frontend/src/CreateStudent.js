import axios from 'axios';
import React, { useState } from 'react'
import { API_URL } from './constants';
import { useNavigate } from 'react-router-dom';

const CreateStudent = () => {
    const [cedula, setCedula] = useState('');
    const [apellidoPaterno, setApellidoPaterno] = useState('');
    const [apellidoMaterno, setApellidoMaterno] = useState('');
    const [nombres, setNombres] = useState('');
    const [genero, setGenero] = useState('');
    const navigate = useNavigate();

    function handleSubmit(event){
        event.preventDefault();
        const body ={
            cedula: cedula,
            apellido1: apellidoPaterno,
            apellido2: apellidoMaterno,
            nombres: nombres,
            genero: genero
        };
        console.log(body);
        axios.post(`${API_URL}`, body)
        .then(res => {
            console.log(res);
            navigate('/')
        }).catch(err => console.log(err));
    }

  return (
    <div className='d-flex vh-100 bg-success justify-content-center aling-items-center pt-5'>
        <div className='w-75 bg-white rounded p-3'>
            <form onSubmit={handleSubmit}>
                <h2>Agregar Estudiante</h2>
                <div className='mb-2'>
                    <label htmlFor=''>Cedula</label>
                    <input type='text' placeholder='Ingrese cedula' value={cedula} className='form-control' onChange={e => setCedula(e.target.value)} />
                </div>
                <div className='mb-2'>
                    <label htmlFor=''>Apellido paterno</label>
                    <input type='text' placeholder='Ingrese apellido' value={apellidoPaterno} className='form-control' onChange={e => setApellidoPaterno(e.target.value)} />
                </div>
                <div className='mb-2'>
                    <label htmlFor=''>Apellido Materno</label>
                    <input type='text' placeholder='Ingrese apellido' value={apellidoMaterno} className='form-control' onChange={e => setApellidoMaterno(e.target.value)} />
                </div>
                <div className='mb-2'>
                    <label htmlFor=''>Nombres</label>
                    <input type='text' placeholder='Ingrese nombres' value={nombres} className='form-control' onChange={e => setNombres(e.target.value)}/>
                </div>
                <div className='mb-2'>
                <label htmlFor=''>Genero</label>
                    <select className="form-select" aria-label="Default select example" id='genero' value={genero} onChange={e => setGenero(e.target.value)}>
                        <option selected>seleccione</option>
                        <option value="M">Masculino</option>
                        <option value="F">Femenino</option>
                    </select>
                </div>
                <button className='btn btn-success'>Enviar</button>
            </form>
        </div>
    </div>
  )
}

export default CreateStudent