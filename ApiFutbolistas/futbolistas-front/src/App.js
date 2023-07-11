import {useState, useEffect} from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';

function App() {

  const baseUrl='https://localhost:44310/api/Futbolista';

  const [data, setdata] = useState([]);
  const [modalInsertar, setModalInsertar] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modaleliminar, setModalEliminar] = useState(false);
  const [futbolistaSeleccionado, setFutbolistaSeleccionado] = useState({
    id: '',
    nombre: '',
    posicion: '',
    nacionalidad: '',
    imagen: ''
  })

  const handleChange=e=>{
    const {name, value}=e.target;
    setFutbolistaSeleccionado({
      ...futbolistaSeleccionado,
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

  const peticionGet = async()=>{
    await axios.get(baseUrl).then(response =>{
      setdata(response.data);
    }).catch(error => {
      console.log(error);
    })
  }

  const peticionPost = async() => {
    delete futbolistaSeleccionado.id;
    await axios.post(baseUrl, futbolistaSeleccionado).then(response =>{
      setdata(data.concat(response.data));
      abrirCerrarModalInsertar();
    }).catch(error =>{
      console.log(error);
    })
  }

  const peticionPut = async()=>{
    await axios.put(baseUrl + '/' + futbolistaSeleccionado.id, futbolistaSeleccionado)
    .then(response =>{
      let respuesta = response.data;
      let dataAuxiliar = data;
      dataAuxiliar.map(futbolista => {
        if(futbolista.id === futbolistaSeleccionado.id){
          futbolista.nombre = respuesta.nombre;
          futbolista.posicion = respuesta.posicion;
          futbolista.nacionalidad = respuesta.nacionalidad;
          futbolista.imagen = respuesta.imagen;
        }
      });
      abrirCerrarModalEditar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionDelete = async()=>{
    await axios.delete(baseUrl+'/'+futbolistaSeleccionado.id).then(response=>{
      setdata(data.filter(futbolista=>futbolista.id!==response.data));
      abrirCerrarModalEliminar();
    }).catch(error => {
      console.log(error);
    })
  }

  const seleccionarFutbolista=(futbolista, caso)=>{
    setFutbolistaSeleccionado(futbolista);
    (caso==='Editar') ?
    abrirCerrarModalEditar() : abrirCerrarModalEliminar();
  }

  useEffect(() => {
    peticionGet();
  }, [])



  return (
    <div className="App">
      <div>
        <h3>Ejemplos de crud con c#</h3>        
      </div>
      <br />
      <div>
        <button className='btn btn-success' onClick={()=>abrirCerrarModalInsertar()}>Insertar Futbolista</button>
      </div>
      <br />
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Posicion</th>
            <th>Nacionalidad</th>
            <th>Imagen</th>
            <th>Aciones</th>
          </tr>
        </thead>
        <tbody>
          {data.map(futbolista=>(
            <tr key={futbolista.id}>
              <th>{futbolista.id}</th>
              <td>{futbolista.nombre}</td>
              <td>{futbolista.posicion}</td>
              <td>{futbolista.nacionalidad}</td>
              <td>
                <img src={futbolista.imagen} width={100} height={100}/>
              </td>
              <td>
                <button className='btn btn-warning' onClick={()=>seleccionarFutbolista(futbolista, "Editar")} >Editar</button>{" "}
                <button className='btn btn-danger' onClick={()=>seleccionarFutbolista(futbolista, "Eliminar")} >Borrar</button>
              </td>
            </tr>
          ))}
        </tbody>        
      </table>


      <Modal isOpen={modalInsertar}>
        <ModalHeader>Ingestar Futbolista</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Nombre: </label>
            <br />
            <input type="text" className="form-control" name="nombre" onChange={handleChange} />
            <br />
            <label>Posicion: </label>
            <br />
            <input type="text" className="form-control" name="posicion" onChange={handleChange} />
            <br />
            <label>Nacionalidad: </label>
            <br />
            <input type="text" className="form-control" name="nacionalidad" onChange={handleChange} />
            <br />
            <label>Imagen: </label>
            <br />
            <input type="text" className="form-control" name="imagen" onChange={handleChange} />
            <br />
          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={()=>peticionPost()}>Insertar</button>
          <button className='btn btn-danger' onClick={()=>abrirCerrarModalInsertar()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalEditar}>
        <ModalHeader>Editar futbolista</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Id:</label>
            <br />
            <input type='text' className="form-control" readOnly value={futbolistaSeleccionado && futbolistaSeleccionado.id} />
            <br />
            <label>Nombre:</label>
            <br />
            <input type='text' className="form-control" name='nombre' onChange={handleChange} value={futbolistaSeleccionado && futbolistaSeleccionado.nombre} />
            <br />
            <label>Posicion:</label>
            <br />
            <input type='text' className="form-control" name='posicion' onChange={handleChange} value={futbolistaSeleccionado && futbolistaSeleccionado.posicion} />
            <br />
            <label>Nacionalidad:</label>
            <br />
            <input type='text' className="form-control" name='nacionalidad' onChange={handleChange} value={futbolistaSeleccionado && futbolistaSeleccionado.nacionalidad} />
            <br />
            <label>Imagen:</label>
            <br />
            <input type='text' className="form-control" name='imagen' onChange={handleChange} value={futbolistaSeleccionado && futbolistaSeleccionado.imagen} />
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
          Estas seguro que deseas eliminar al futbolista? {futbolistaSeleccionado && futbolistaSeleccionado.nombre}
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
