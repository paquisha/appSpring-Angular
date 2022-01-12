import {useState, useEffect} from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';

function App() {
  const baseUrl='https://localhost:7032/api/futbolista';
  const [data, setdata] = useState([]);

  const peticionGet = async()=>{
    await axios.get(baseUrl).then(response =>{
      setdata(response.data);
    }).catch(error => {
      console.log(error);
    })
  }

  useEffect(() => {
    peticionGet();
  }, [])
  return (
    <div className="App">
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Posicion</th>
            <th>Nacionalidad</th>
            <th>Aciones</th>
          </tr>
        </thead>
        <tbody>
          {data.map(futbolista => {
            <tr key={futbolista.id}>
              <td>{futbolista.id}</td>
              <td>{futbolista.nombre}</td>
              <td>{futbolista.posicion}</td>
              <td>{futbolista.nacionalidad}</td>
              <td>
                <button className='btn btn-primary'>Editar</button>
                <button className='btn btn-danger'>eliminar</button>
              </td>
            </tr>
          })}
        </tbody>        
      </table>
    </div>
  );
}

export default App;
