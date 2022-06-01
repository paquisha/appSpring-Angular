import {useState, useEffect} from 'react';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import './App.css';

function App() {

  const baseUrl='http://localhost:5082/api/Vehiculos';

  const [data, setdata] = useState([]);
  const [modalInsertar, setModalInsertar] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modaleliminar, setModalEliminar] = useState(false);
  const [vehiculoSeleccionado, setVehiculoSeleccionado] = useState({
    id: '',
    codigo: '',
    chasis: '',
    marca: '',
    modelo: '',
    anio_modelo: '',
    color: '',
    estado: '',
    fecha_registro: ''
  })

  const handleChange=e=>{
    const {name, value}=e.target;
    setVehiculoSeleccionado({
      ...vehiculoSeleccionado,
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
    delete vehiculoSeleccionado.id;
    delete vehiculoSeleccionado.fecha_registro;
    await axios.post(baseUrl, vehiculoSeleccionado).then(response =>{
      setdata(data.concat(response.data));
      abrirCerrarModalInsertar();
    }).catch(error =>{
      console.log(error);
    })
  }

  const peticionPut = async()=>{
    await axios.put(baseUrl + '/' + vehiculoSeleccionado.id, vehiculoSeleccionado)
    .then(response =>{
      let respuesta = response.data;
      let dataAuxiliar = data;
      dataAuxiliar.map(vehiculo => {
        if(vehiculo.id === vehiculoSeleccionado.id){
          vehiculo.codigo = respuesta.codigo;
          vehiculo.chasis = respuesta.chasis;
          vehiculo.marca = respuesta.marca;
          vehiculo.modelo = respuesta.modelo;
          vehiculo.anio_modelo = respuesta.anio_modelo;
          vehiculo.color = respuesta.color;
          vehiculo.estado = respuesta.estado;
          vehiculo.fecha_registro = respuesta.fecha_registro
        }
      });
      abrirCerrarModalEditar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionDelete = async()=>{
    await axios.delete(baseUrl+'/'+vehiculoSeleccionado.id).then(response=>{
      setdata(data.filter(vehiculo=>vehiculo.id!==response.data));
      abrirCerrarModalEliminar();
    }).catch(error => {
      console.log(error);
    })
  }

  const seleccionarVehiculo=(vehiculo, caso)=>{
    setVehiculoSeleccionado(vehiculo);
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
        <button className='btn btn-success' onClick={()=>abrirCerrarModalInsertar()}>Insertar Vehiculo</button>
      </div>
      <br />
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Codigo</th>
            <th>Chasis</th>
            <th>Marca</th>
            <th>Modelo</th>
            <th>Anio Modelo</th>
            <th>Color</th>
            <th>Estado</th>
            <th>Fecha Registro</th>
            <th>Aciones</th>
          </tr>
        </thead>
        <tbody>
          {data.map(vehiculo=>(
            <tr key={vehiculo.id}>
              <td>{vehiculo.codigo}</td>
              <td>{vehiculo.chasis}</td>
              <td>{vehiculo.marca}</td>
              <td>{vehiculo.modelo}</td>
              <td>{vehiculo.anio_modelo}</td>
              <td>{vehiculo.color}</td>
              <td>{vehiculo.estado}</td>
              <td>{vehiculo.fecha_registro}</td>
              <td>
                <button className='btn btn-warning' onClick={()=>seleccionarVehiculo(vehiculo, "Editar")} >Editar</button>{" "}
                <button className='btn btn-danger' onClick={()=>seleccionarVehiculo(vehiculo, "Eliminar")} >Borrar</button>
              </td>
            </tr>
          ))}
        </tbody>        
      </table>

      <Modal isOpen={modalInsertar}>
        <ModalHeader>Ingresar Vehiculo</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Codigo: </label>
            <br />
            <input type="text" className="form-control" name="codigo" onChange={handleChange} />
            <br />
            <label>Chasis: </label>
            <br />
            <input type="text" className="form-control" name="chasis" onChange={handleChange} />
            <br />
            <label>Marca: </label>
            <br />
            <input type="text" className="form-control" name="marca" onChange={handleChange} />
            <br />
            <label>Modelo: </label>
            <br />
            <input type="text" className="form-control" name="modelo" onChange={handleChange} />
            <br />
            <label>Anio Modelo: </label>
            <br />
            <input type="text" className="form-control" name="anio_modelo" onChange={handleChange} />
            <br />
            <label>Color: </label>
            <br />
            <input type="text" className="form-control" name="color" onChange={handleChange} />
            <br />
            <label>Estado: </label>
            <br />
            <input type="text" className="form-control" name="estado" onChange={handleChange} />
            <br />            
          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={()=>peticionPost()}>Insertar</button>
          <button className='btn btn-danger' onClick={()=>abrirCerrarModalInsertar()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalEditar}>
        <ModalHeader>Editar Vehiculo</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Id:</label>
            <br />
            <input type='text' className="form-control" readOnly value={vehiculoSeleccionado && vehiculoSeleccionado.id} />
            <br />
            <label>Codigo:</label>
            <br />
            <input type='text' className="form-control" name='codigo' onChange={handleChange} value={vehiculoSeleccionado && vehiculoSeleccionado.codigo} />
            <br />
            <label>Chasis:</label>
            <br />
            <input type='text' className="form-control" name='chasis' onChange={handleChange} value={vehiculoSeleccionado && vehiculoSeleccionado.chasis} />
            <br />
            <label>Marca:</label>
            <br />
            <input type='text' className="form-control" name='marca' onChange={handleChange} value={vehiculoSeleccionado && vehiculoSeleccionado.marca} />
            <br />
            <label>Modelo:</label>
            <br />
            <input type='text' className="form-control" name='modelo' onChange={handleChange} value={vehiculoSeleccionado && vehiculoSeleccionado.modelo} />
            <br />
            <label>Anio Modelo:</label>
            <br />
            <input type='text' className="form-control" name='anio_modelo' onChange={handleChange} value={vehiculoSeleccionado && vehiculoSeleccionado.anio_modelo} />
            <br />
            <label>Color:</label>
            <br />
            <input type='text' className="form-control" name='color' onChange={handleChange} value={vehiculoSeleccionado && vehiculoSeleccionado.color} />
            <br />
            <label>Estado:</label>
            <br />
            <input type='text' className="form-control" name='estado' onChange={handleChange} value={vehiculoSeleccionado && vehiculoSeleccionado.estado} />
            <br />
            <label>Fecha registro:</label>
            <br />
            <input type='text' className="form-control" name='fecha_registro' readOnly onChange={handleChange} value={vehiculoSeleccionado && vehiculoSeleccionado.fecha_registro} />
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
          Estas seguro que deseas eliminar el vehiculo? {vehiculoSeleccionado && vehiculoSeleccionado.modelo}
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
