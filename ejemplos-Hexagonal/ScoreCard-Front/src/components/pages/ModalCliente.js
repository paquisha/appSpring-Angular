import React, { useState, useEffect } from "react";
import { FaPen, FaPlus, FaTrash } from "react-icons/fa";
import { Col, Row, Modal, Button, Form, Stack } from 'react-bootstrap';
import { useFormik } from 'formik';
import Swal from 'sweetalert2';
import axios from "axios";
import { enviroment } from '../service/Enviroments';


export default function ClienteModal({id}){

    const [client, setClient] = useState({
        name: '',
        isActive: false,
        idCliente: '',
        tenantId: '',
        clientSecret: ''
    });

    const formik = useFormik({
        initialValues: {
          name: '',
          isActive: false,
          idCliente: '',
          tenantId: '',
          clientSecret: ''
        },
        onSubmit: values => {
          console.log(JSON.stringify(values, null, 2));
        },
    });

    const loadClient = async (id) => {
        console.log(id);
        try {
            let [uno, dos ] = id.split('_');
            let idVerdadero = dos;
            console.log(idVerdadero);
    
            const response = await axios.get(`${enviroment.clientesURL}api/customer/${idVerdadero}`);
            const data = await response.json();
            setClient(data);
            console.log(data);
            
          } catch (error) {
            console.error(error);
          }

      };

    const cancelar=() =>{
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
              Swal.fire(
                'Borrado!',
                'Elemento eliminado.',
                'success'
              )
            }
        })
    }

    useEffect(() => {
        loadClient(id);
    }, [])

    return(
        <div className="modal fade" id={id} tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div className="modal-dialog modal-lg">
                <div className="modal-content">
                <div className="modal-header">
                    <h1 className="modal-title fs-5" id="exampleModalLabel">prueba - {id}</h1>
                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div className="modal-body">
                    <Form onSubmit={formik.handleSubmit}>
                        <Form.Group className="mb-3">
                            <Form.Label>Nombre</Form.Label>
                            <Form.Control 
                                id="name"
                                type="text" 
                                placeholder="Nombre"
                                onChange={formik.handleChange}
                                value={formik.values.name}
                            />
                            <Form.Text className="text-muted">
                                nombres.
                            </Form.Text>
                        </Form.Group>

                        <Form.Check 
                            type="switch"
                            id="isActive"
                            label="Activo"
                            onChange={formik.handleChange}
                            value={formik.values.isActive}
                        />

                        <Form.Group className="mb-3">
                            <Form.Label>ID Cliente</Form.Label>
                            <Form.Control 
                                id="idCliente"
                                type="text" 
                                placeholder="id Cliente"
                                onChange={formik.handleChange}
                                value={formik.values.idCliente}
                            />
                            <Form.Text className="text-muted">
                                idCliente.
                            </Form.Text>
                        </Form.Group>

                        <Form.Group className="mb-3">
                            <Form.Label>Tenant ID</Form.Label>
                            <Form.Control 
                                id="tenantId"
                                type="text" 
                                placeholder="Tenant ID"
                                onChange={formik.handleChange}
                                value={formik.values.tenantId}
                            />
                            <Form.Text className="text-muted">
                                tenantId.
                            </Form.Text>
                        </Form.Group>

                        <Form.Group className="mb-3">
                            <Form.Label>Client Secret</Form.Label>
                            <Form.Control 
                                id="clientSecret"
                                type="text" 
                                placeholder="Client Secret"
                                onChange={formik.handleChange}
                                value={formik.values.clientSecret}
                            />
                            <Form.Text className="text-muted">
                                tenantId.
                            </Form.Text>
                        </Form.Group>
                        {/* <Stack direction="horizontal" gap={2} className="text-center">
                            <Button variant="success" type="submit" className="ms-auto">
                                Guardar
                            </Button>{' '}
                            <Button variant="danger" onClick={handleClose}>
                                Descartar
                            </Button>
                        </Stack> */}
                    </Form>
                </div>
                <div className="modal-footer">
                    <button type="button" className="btn btn-secondary">Reportar</button>
                    <button type="button" className="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                </div>
                </div>
            </div>
        </div>
    )
}