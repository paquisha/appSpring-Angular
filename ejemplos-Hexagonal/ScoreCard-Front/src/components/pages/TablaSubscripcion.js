import React,{ useState, useEffect } from 'react';
import { Button, Container, Form, Stack, Table, Col } from 'react-bootstrap';
import { enviroment } from '../service/Enviroments';
import { FaPen, FaPlus, FaTrash } from "react-icons/fa";
import { useNavigate, useParams } from "react-router-dom";
import Swal from 'sweetalert2';
import axios from "axios";

export default function TablaSubscripcion(){
  
  const[estado, setEstado] = useState(false);
    const [subscripcion, setSubscripcion] = useState(null);
    const navigate = useNavigate();
    const params = useParams();

    const loadSubscripcions = async (id) => {
        await axios({
            method: 'GET',
            url: `${enviroment.clientesURL}api/subscription/CustomerId/${id}`
          }).then(function (res) {
            console.log(res.data.value);
            setSubscripcion(res.data.value);
            setEstado(true);
            })
            .catch(function (res) {
               console.log(res)
        });
    };

    const data = [
        {id: "prueba", name: "nombre uno"},
        {id: "pruebados", name: "nombre dos"}
    ];

    const cancelar = (id) =>{
        Swal.fire({
            title: 'Está seguro que desea eliminar',
            text: "",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, Borrar!'
          }).then((result) => {
            if (result.isConfirmed) {
                handleDelete(id);
              Swal.fire(
                'Borrado!',
                'Elemento eliminado.',
                'success'
              )
            }
        })
    }

    const handleDelete = async (id) => {
        try {
          await axios.delete(`${enviroment.clientesURL}api/subscription/${id}`, {
            method: "DELETE",
          });
          setSubscripcion(subscripcion.filter((subs) => subs.id !== id));
        } catch (error) {
          console.error(error);
        }
    };

    useEffect(() => {
      if (params.id) {
        loadSubscripcions(params.id);
      }
    }, [params.id]);

  return (
    <>
      <Container>
        <div className='text-center'>
            <h6>Listado Subscripciones</h6>
        </div>
        <Table striped bordered hover>
            <thead>
                <tr className='text-center'>
                    <th>Nombre</th>
                    <th>Subscripciones</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody className='pb-2'>
                { estado ?
                  subscripcion.map((item, index) =>(
                    <tr key={index}>
                      <td>{item.name}</td>
                      <td>{item.id}</td>
                      <td className='text-center'>
                          <Button variant="outline-warning" onClick={() => navigate(`/subscripcion/${item.id}/edit`)}><FaPen /></Button>{' '}
                          <Button variant='outline-danger' onClick={() => cancelar(item.id)}><FaTrash /></Button>                             
                      </td>
                    </tr>
                )) 
                : 
                <tr>
                  <td></td>
                  <td></td>
                  <td></td>
                </tr>
              }
            </tbody>
        </Table>
        <Stack className='text-center'>
                <Col>
                    <Button variant='outline-success rounded' onClick={() => navigate(`/subscripcion/new/${params.id}`)}><FaPlus /></Button>
                </Col>
            </Stack>
      </Container>
    </>
  )
}
