import React,{ useState } from 'react'
import Form from 'react-bootstrap/Form';
import Table from 'react-bootstrap/Table';
import Pagination from 'react-bootstrap/Pagination';
import Button from 'react-bootstrap/Button';
import Modal from './Modal'


export default function Alert(){

    let dia = new Date();

    const itemsPerPage = 4;

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    //data
    const data = [
        {id: 1,fecha: '1/1/2023', nombreAlerta: 'Windows Memory Over Threshold', equipo: 'MARESA DB11', cliente: 'Maresa', severidad: 'Alta', sla: '0:15'},
        {id: 2,fecha: '1/1/2023', nombreAlerta: 'Cluster service', equipo: 'MB-PA-PRO-AP-94', cliente: 'Multibank', severidad: 'Alta', sla: '0:15'},
        {id: 3,fecha: '1/1/2023', nombreAlerta: 'Failed to Connect to Computer', equipo: 'SRVPAZONBB', cliente: 'Bainter', severidad: 'Media', sla: '0:45'},
        {id: 4,fecha: '1/1/2023', nombreAlerta: 'Windows Memory Over Threshold', equipo: 'MARESA DB11', cliente: 'Maresa', severidad: 'Alta', sla: '0:15'},
        {id: 5,fecha: '1/1/2023', nombreAlerta: 'Windows Memory Over Threshold', equipo: 'MARESA DB11', cliente: 'Maresa', severidad: 'Alta', sla: '0:15'},
        {id: 6,fecha: '1/1/2023', nombreAlerta: 'Windows Memory Over Threshold', equipo: 'MARESA DB11', cliente: 'Maresa', severidad: 'Alta', sla: '0:15'},
        {id: 7,fecha: '1/1/2023', nombreAlerta: 'Windows Memory Over Threshold', equipo: 'MARESA DB11', cliente: 'Maresa', severidad: 'Alta', sla: '0:15'},
        {id: 8,fecha: '1/1/2023', nombreAlerta: 'Windows Memory Over Threshold', equipo: 'MARESA DB11', cliente: 'Maresa', severidad: 'Alta', sla: '0:15'},
        {id: 9,fecha: '1/1/2023', nombreAlerta: 'Windows Memory Over Threshold', equipo: 'MARESA DB11', cliente: 'Maresa', severidad: 'Alta', sla: '0:15'},
        {id: 10,fecha: '1/1/2023', nombreAlerta: 'Windows Memory Over Threshold', equipo: 'MARESA DB11', cliente: 'Maresa', severidad: 'Alta', sla: '0:15'}
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
    const currentData = data.slice(startIndex, endIndex);

    return(
        <div className='container-fluid'>
            <div className='row pt-3'>
                <div className='col-md-3'>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Inicio</Form.Label>
                    <Form.Control type="date" placeholder={dia.getDate()} />
                </Form.Group>
                </div>

                <div className='col-md-3'>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label>Fin</Form.Label>
                        <Form.Control type="date" placeholder={dia.getDate()} />
                    </Form.Group>
                </div>

                <div className='col-md-3'>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label>Clientes</Form.Label>
                        <Form.Select aria-label="Clientes">
                            <option>Seleccione...</option>
                            <option value="1">One</option>
                            <option value="2">Two</option>
                            <option value="3">Three</option>
                        </Form.Select>
                    </Form.Group>
                </div>

                <div className='col-md-3'>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label>Estado</Form.Label>
                        <Form.Select aria-label="Clientes">
                            <option>Seleccione...</option>
                            <option value="1">One</option>
                            <option value="2">Two</option>
                            <option value="3">Three</option>
                        </Form.Select>
                    </Form.Group>
                </div>
            </div>
            {/* aqui inicia la tabla*/}
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Fecha</th>
                        <th>Nombre Alerta</th>
                        <th>Equipo Afectado</th>
                        <th>Cliente</th>
                        <th>Severidad</th>
                        <th>SLA</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                {currentData.map((item, index) => (
                    <tr key={index}>
                        <td>{item.fecha}</td>
                        <td>{item.nombreAlerta}</td>
                        <td>{item.equipo}</td>
                        <td>{item.cliente}</td>
                        <td>{item.severidad}</td>
                        <td>{item.sla}</td>
                        <td className='text-center'>
                            <Button variant="success" onClick={handleShow} >Procesar</Button>{' '}
                            {/* <Button variant="success" data-bs-toggle="modal" data-bs-target={`#id${item.id}`}>Procesar</Button>{' '} */}
                            <Button variant="danger">Descartar</Button>
                            {/* <Modal id={`id${item.id}`} titulo={item.cliente} contenido={item.nombreAlerta} /> */}
                            <Modal id={`id${item.id}`} title={item.cliente} contenido={item.nombreAlerta} show={show} handleClose={handleClose} />
                        </td>
                    </tr>
                ))}
                </tbody>
            </Table>
            <div className='text-center'>
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
            </div>            
        </div>
    )
}