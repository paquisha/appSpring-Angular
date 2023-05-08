import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, Container, Form, Stack, Row, Col } from 'react-bootstrap';
import { enviroment } from '../service/Enviroments';
import axios from "axios";
import Swal from 'sweetalert2';
import TablaSubscripcion from "./TablaSubscripcion";


export default function FormCliente(){

    const [ client, setClient ] = useState({
        id: '',
        isActive: false,
        name: '',
        applicationId: '',
        clientSecret: '',
        tenantId: '',
        isLoading: true
    });

    const [editing, setEditing] = useState(false);

    const navigate = useNavigate();
    const params = useParams();

    const onInputChange = (e) => {
        if(e.target.name === 'isActive'){
            setClient({ ...client, [e.target.name]: e.target.checked });
        }else{
            setClient({ ...client, [e.target.name]: e.target.value });
        }        
    };

    const loadClient = async (id) => {
        setEditing(true);
        let cliente = {};
        let secretInformation = {};
        await axios({
            method: 'GET',
            url: `${enviroment.clientesURL}api/customer/${id}`
        }).then(function (res) {
            cliente = res.data;
        }).catch(function (res) {
            console.log(res);
            cancelar(res.code, 'error', res.response.data);
        });

        await axios({
            method: 'GET',
            url: `${enviroment.clientesURL}api/customerinformationbyid/${id}`
        }).then(function (res){
            secretInformation = res.data;
        }).catch(function (res){
            console.log(res);
            cancelar(res.code, 'error', res.response.data);
        });

        let cargando = false;

        const formularioCliente = {
            id: cliente.id,
            isActive: cliente.isActive,
            name: cliente.name,
            applicationId: secretInformation.applicationId,
            clientSecret: secretInformation.clientSecret,
            tenantId: secretInformation.tenantId,
            isLoading: cargando
        };
        setClient(formularioCliente);
    };    

    const onSubmit = async (e) => {
        e.preventDefault();

        const customer = {
            name: client.name,
            isActive: client.isActive
        }
        
        const secret ={
            applicationId: client.applicationId,
            clientSecret: client.clientSecret,
            tenantId: client.tenantId,
        }

        if(params.id){
            updateCliente(params.id, customer);
            updateClientSecret(params.id, secret);
            guardar();
        }else{
            crearCliente(customer);
        }
    }

    const updateClientSecret = async (id, values) => {
        await axios({
            method: 'PUT',
            url: `${enviroment.clientesURL}api/updatecustomer/${id}`,
            data: values
        })
        .then(function (res) {
            console.log(res);
        })
        .catch(function (res) {
            cancelar(res.code, 'error', res.response.data);
        });
    }

    const updateCliente = async (id, values) => {
        await axios({
            method: 'PUT',
            url: `${enviroment.clientesURL}api/customer/${id}`,
            data: values
        })
        .then(function (res) {
            console.log(res);
        })
        .catch(function (res) {
            console.log(res);
            cancelar(res.code, 'error', res.response.data);
        });
    }

    const crearCliente = async (values) => {
        await axios({
            method: 'POST',
            url: enviroment.clientesURL + 'api/customer',
            data: values
        }).then(function (res) {
            guardar();
            navigate("/");
        })
        .catch(function (res) { 
            console.log(res);
            cancelar(res.code, 'error', res.response.data);
        });
    }

    const guardar = () => {
        if(!params.id){
            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: 'Usuario Creado con exito',
                showConfirmButton: true,
                timer: 1500
            })
        }else{
            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: 'Usuario Actualizado con exito',
                showConfirmButton: true,
                timer: 1500
            })
        }
    }

    const cancelar = (title, icon, text) =>{
        Swal.fire({
            position: 'top-center',
            icon: icon,
            title: title,
            text: text
        })
    }

    useEffect(() => {
        if (params.id) {
            loadClient(params.id);
        }
    }, [params.id]);


    // if (editing) {
    //     return(
    //         <Container>
    //             <Spinner animation="border" role="status">
    //                 <span className="visually-hidden">Loading...</span>
    //             </Spinner>
    //         </Container>
    //     );
    // }else{
    //     return (

    //     )
    // }
    return(
        <Container>
        <Row className='text-center'>
            <Col>
                {params.id ? <h4>Editar Cliente</h4> : <h4>Crear Cliente</h4> }
            </Col>
        </Row>
        <Form onSubmit={(e) => onSubmit(e)}>
            <Form.Group className="mb-3">
                <Form.Label>Nombre</Form.Label>
                <Form.Control
                    name="name"
                    type="text"
                    placeholder="Nombre"
                    value={client.name}
                    onChange={(e) => onInputChange(e)}
                />
                <Form.Text className="text-muted">
                    nombres.
                </Form.Text>
            </Form.Group>

            <Form.Check
                type="switch"
                name="isActive"
                label="Activo"
                checked={client.isActive}
                onChange={(e) => onInputChange(e)}
            />

            <Form.Group className="mb-3">
                <Form.Label>Application ID</Form.Label>
                <Form.Control
                    name="applicationId"
                    type="text"
                    placeholder="applicationId"
                    value={client.applicationId}
                    onChange={(e) => onInputChange(e)}
                />
                <Form.Text className="text-muted">
                    Application ID.
                </Form.Text>
            </Form.Group>

            <Form.Group className="mb-3">
                <Form.Label>Tenant ID</Form.Label>
                <Form.Control
                    name="tenantId"
                    type="text"
                    placeholder="Tenant ID"
                    value={client.tenantId}
                    onChange={(e) => onInputChange(e)}
                />
                <Form.Text className="text-muted">
                    tenantId.
                </Form.Text>
            </Form.Group>
            <Form.Group className="mb-3">
                <Form.Label>Client Secret</Form.Label>
                <Form.Control
                    name="clientSecret"
                    type="text"
                    placeholder="Client Secret"
                    value={client.clientSecret}
                    onChange={(e) => onInputChange(e)}
                />
                <Form.Text className="text-muted">
                    Client Secret.
                </Form.Text>
            </Form.Group>
            {
                editing ?
                    <TablaSubscripcion /> :
                    ''
            }
            <Stack direction="horizontal" gap={2} className="text-center">
                <Button variant="success" type="submit" className="ms-auto">
                    Guardar
                </Button>{' '}
                <Button variant="danger" onClick={() => navigate(`/`)}>
                    Descartar
                </Button>
            </Stack>
        </Form>
    </Container>
    )
}