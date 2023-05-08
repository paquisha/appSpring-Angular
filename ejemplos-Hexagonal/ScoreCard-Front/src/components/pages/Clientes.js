import React,{ useState, useEffect } from 'react'
import { Button, Container, Form, Row, Stack, Table, Col } from 'react-bootstrap';
import Pagination from 'react-bootstrap/Pagination';
import { FaPen, FaPlus, FaTrash } from "react-icons/fa";
import Swal from 'sweetalert2';
import axios from "axios";
import { enviroment } from '../service/Enviroments';
import { useNavigate } from "react-router-dom";

export default function Clientes(){

    const navigate = useNavigate();

    const itemsPerPage = 10;
    const [estado, setEstado] = useState(false);
    const [clientes, setClientes] = useState(null);

    //get
    const peticionGet = async()=>{
        await axios.get(enviroment.clientesURL+'api/customer').then(response =>{
          setClientes(response.data.value);
          setEstado(true);
        }).catch(error => {
          console.log(error);
        })
    }

    const data = [
        {id: 1, nombre: "IASA", estado: true, ultimaCaptura: "", numeroCapturas: 4, numeroSubscripciones: 3},
        {id: 1, nombre: "GLOBAL BANK", estado: true, ultimaCaptura: "", numeroCapturas: 4, numeroSubscripciones: 3},
        {id: 1, nombre: "UTPL", estado: true, ultimaCaptura: "", numeroCapturas: 4, numeroSubscripciones: 3}
    ];

    // Estado para almacenar el número de página actual
    const [currentPage, setCurrentPage] = useState(1);

    // Función para calcular el índice inicial del elemento actual
    const startIndex = (currentPage - 1) * itemsPerPage;

    // Función para calcular el índice final del elemento actual
    const endIndex = startIndex + itemsPerPage;

    // Función para cambiar a la página siguiente
    const nextPage = () => {
        setCurrentPage(currentPage + 1);
    };

    // Función para cambiar a la página anterior
    const prevPage = () => {
        setCurrentPage(currentPage - 1);
    };

    // Función para cambiar a una página específica
    const goToPage = (page) => {
        setCurrentPage(page);
    };

    // Obtener los datos para la página actual
    const currentData = clientes != null ? clientes.slice(startIndex, endIndex) : data.slice(startIndex, endIndex)

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
          await axios.delete(`${enviroment.clientesURL}api/customer/${id}`, {
            method: "DELETE",
          });
          setClientes(clientes.filter((client) => client.id !== id));
        } catch (error) {
          console.error(error);
        }
    };

    useEffect(() => {
        peticionGet();
    }, [])

    return(
        <Container fluid>
            <Row>
                <Form.Group>
                    <Form.Label>Listado de Clientes</Form.Label>
                </Form.Group>
            </Row>
            {/*vamos a poner la tabla aca*/}
            <Table striped bordered hover>
                <thead>
                    <tr className='text-center'>
                        <th>Nombre</th>
                        <th>Estado</th>
                        <th>Ultima Captura</th>
                        <th># Capturas</th>
                        <th># Subscripciones</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    { estado ?
                    currentData.map((item, index) =>(
                        <tr key={index}>
                            <td>{item.name}</td>
                            <td className='text-center'>
                                {item.isActive === true ?
                                    <Form.Check
                                        disabled
                                        type="switch"
                                        id="custom-switch"
                                        checked
                                    />
                                :
                                    <Form.Check
                                        disabled
                                        type="switch"
                                        id="custom-switch"
                                    />
                                }
                            </td> 
                            <td>{item.ultimaCaptura}</td>
                            <td>{item.numeroCapturas}</td>
                            <td>{item.numeroSubscripciones}</td>
                            <td className='text-center'>
                                <Button variant="outline-warning" onClick={() => navigate(`/cliente/${item.id}/edit`)}><FaPen /></Button>{' '}
                                <Button variant='outline-danger' onClick={() => cancelar(item.id)}><FaTrash /></Button>                             
                            </td>
                        </tr>
                    )) 
                    :
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    }
                </tbody>
            </Table>
            <Stack className='text-center'>
                <Col>
                    <Button variant='outline-success rounded' onClick={() => navigate("/cliente/new")}><FaPlus /></Button>
                </Col>
            </Stack>
            {/*paginacion*/}
            <Row className='pt-2'>
                <Pagination>
                    <Pagination.First onClick={() => goToPage(1)} />
                    <Pagination.Prev
                    onClick={() => prevPage()}
                    disabled={currentPage === 1}
                    />
                    {data.map((item, index) => (
                    <Pagination.Item
                        key={index}
                        active={index + 1 === currentPage}
                        onClick={() => goToPage(index + 1)}
                    >
                        {index + 1}
                    </Pagination.Item>
                    ))}
                    <Pagination.Next
                    onClick={() => nextPage()}
                    disabled={currentPage === Math.ceil(data.length / itemsPerPage)}
                    />
                    <Pagination.Last
                    onClick={() => goToPage(Math.ceil(data.length / itemsPerPage))}
                    />
                </Pagination>
            </Row>
        </Container>
    );
}