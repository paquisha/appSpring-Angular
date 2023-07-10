import React, { useEffect, useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom';
import { API_URL } from './constants';

const Student = () => {


    const [student, setStudent] = useState([]);

    useEffect(() =>{
        axios.get(API_URL)
        .then(res => setStudent(res.data))
        .catch(err => console.log(err))
    }, []);

    const handleDelete = (id) => {
        axios.delete(`${API_URL}/${id}`)
        .then(alert('Estudiante eliminado con exito'))
        .catch('Error');
      };

  return (
    <div className='d-flex vh-100 bg-success justify-content-center aling-items-center pt-5'>
        <div className='w-75 bg-white rounded p-3'>
            <Link to="/create" className='btn btn-primary'>Agregar</Link>
            <table className='table'>
                <thead>
                    <tr>
                        <th>cedula</th>
                        <th>apellido paterno</th>
                        <th>apellido materno</th>
                        <th>nombres</th>
                        <th>genero</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        student.map((data, i)=>(
                            <tr key={data.idpersonal}>
                                <td>{data.cedula}</td>
                                <td>{data.apellido1}</td>
                                <td>{data.apellido2}</td>
                                <td>{data.nombres}</td>
                                <td>{
                                    data.genero === 'M' ? 'Masculino' : 'Femenino' 
                                }</td>
                                <td>
                                    <button className='btn btn-warning'>Editar</button>
                                    {' '}
                                    <button onClick={() => handleDelete(data.idpersonal)} className='btn btn-danger'>Borrar</button>
                                </td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        </div>
    </div>
  )
}

export default Student