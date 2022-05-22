import axios from 'axios';
import { useState, useEffect } from 'react';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';

function App() {

  const baseUrl='http://localhost:8080/usuario';

  const [data, setdata] = useState([]);
  const [modalInsertar, setModalInsertar] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modaleliminar, setModalEliminar] = useState(false);
  const [personaSeleccionada, setPersonaSeleccionada] = useState({
    id: '',
    nombre: '',
    email: '',
    prioridad: ''
  })

  const handleChange=e=>{
    const {name, value}=e.target;
    setPersonaSeleccionada({
      ...personaSeleccionada,
      [name]: value
    });
  }

  const abrirCerrarModalInsertar=()=>{
    setModalInsertar(!modalInsertar);
  }

  const abrirCerrarModalEditar=()=>{
    setModalEditar(!modalEditar);
  }

  const abrirCerrarModalEliminar=()=>{
    setModalEliminar(!modaleliminar);
  }

  //probado
  const peticionGet = async()=>{
    await axios.get(baseUrl).then(response =>{
      setdata(response.data);
    }).catch(error => {
      console.log(error);
    })
  }

  const peticionPost = async() => {
    delete personaSeleccionada.id;
    await axios.post(baseUrl, personaSeleccionada).then(response =>{
      setdata(data.concat(response.data));
      abrirCerrarModalInsertar();
    }).catch(error =>{
      console.log(error);
    })
  }

  const peticionPut = async()=>{
    await axios.post(baseUrl, personaSeleccionada)
    .then(response =>{
      let respuesta = response.data;
      let dataAuxiliar = data;
      dataAuxiliar.map(persona => {
        if(persona.id === personaSeleccionada.id){
          persona.id = respuesta.id;
          persona.nombre = respuesta.nombre;
          persona.email = respuesta.email;
          persona.prioridad = respuesta.prioridad;        }
      });
      abrirCerrarModalEditar();
    }).catch(error=>{
      console.log(error);
    })
  }

  //probado
  const peticionDelete = async()=>{
    await axios.delete(baseUrl+'/'+personaSeleccionada.id).then(response=>{
      setdata(data.filter(persona=>persona.id!==response.data));
      abrirCerrarModalEliminar();
    }).catch(error => {
      console.log(error);
    })
  }

  const seleccionarPersona=(persona, caso)=>{
    setPersonaSeleccionada(persona);
    (caso==='Editar') ?
    abrirCerrarModalEditar() : abrirCerrarModalEliminar();
  }

  useEffect(() => {
    peticionGet();
  }, [])

  return (
    <div className="App">
    <div>
      <h3>Ejemplos de crud con spring</h3>        
    </div>
    <br />
    <div>
      <button className='btn btn-success' onClick={()=>abrirCerrarModalInsertar()}>Ingresar Persona</button>
    </div>
    <br />
    <table className='table table-bordered'>
      <thead>
        <tr>
          <th>Id</th>
          <th>Nombre</th>
          <th>Email</th>
          <th>Prioridad</th>
          <th>Aciones</th>
        </tr>
      </thead>
      <tbody>
        {data.map(persona=>(
          <tr key={persona.id}>
            <th>{persona.id}</th>
            <td>{persona.nombre}</td>
            <td>{persona.email}</td>
            <td>{persona.prioridad}</td>
            <td>
              <button className='btn btn-warning' onClick={()=>seleccionarPersona(persona, "Editar")} >Editar</button>{" "}
              <button className='btn btn-danger' onClick={()=>seleccionarPersona(persona, "Eliminar")} >Borrar</button>
            </td>
          </tr>
        ))}
      </tbody>        
    </table>


    <Modal isOpen={modalInsertar}>
      <ModalHeader>Ingresar Persona</ModalHeader>
      <ModalBody>
        <div className='form-group'>
          <label>Nombre: </label>
          <br />
          <input type="text" className="form-control" name="nombre" onChange={handleChange} />
          <br />
          <label>Email: </label>
          <br />
          <input type="text" className="form-control" name="email" onChange={handleChange} />
          <br />
          <label>Prioridad: </label>
          <br />
          <input type="text" className="form-control" name="prioridad" onChange={handleChange} />
          <br />
        </div>
      </ModalBody>
      <ModalFooter>
        <button className='btn btn-primary' onClick={()=>peticionPost()}>Insertar</button>
        <button className='btn btn-danger' onClick={()=>abrirCerrarModalInsertar()}>Cancelar</button>
      </ModalFooter>
    </Modal>

    <Modal isOpen={modalEditar}>
      <ModalHeader>Editar Persona</ModalHeader>
      <ModalBody>
        <div className='form-group'>
          <label>Id:</label>
          <br />
          <input type='text' className="form-control" readOnly value={personaSeleccionada && personaSeleccionada.id} />
          <br />
          <label>Nombre:</label>
          <br />
          <input type='text' className="form-control" name='nombre' onChange={handleChange} value={personaSeleccionada && personaSeleccionada.nombre} />
          <br />
          <label>Email:</label>
          <br />
          <input type='text' className="form-control" name='email' onChange={handleChange} value={personaSeleccionada && personaSeleccionada.email} />
          <br />
          <label>Prioridad:</label>
          <br />
          <input type='text' className="form-control" name='prioridad' onChange={handleChange} value={personaSeleccionada && personaSeleccionada.prioridad} />
          <br />
        </div>
      </ModalBody>
      <ModalFooter>
        <button className='btn btn-warning' onClick={()=>peticionPut()}>editar</button>{" "}
        <button className='btn btn-danger' onClick={()=>abrirCerrarModalEditar()} >Cancelar</button>
      </ModalFooter>
    </Modal>

    <Modal isOpen={modaleliminar}>
      <ModalBody>
        Estas seguro que deseas eliminar persona? {personaSeleccionada && personaSeleccionada.nombre}
      </ModalBody>
      <ModalFooter>
        <button className='btn btn-danger' onClick={()=>peticionDelete()} >Si</button>
        <button className='btn btn-warning' onClick={()=>abrirCerrarModalEliminar()}>No</button>
      </ModalFooter>
    </Modal>
  </div>
  );
}

export default App;
