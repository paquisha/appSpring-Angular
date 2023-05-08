import React,{ useState, useEffect } from 'react';
import { Button, Container, Form, Row, Stack, Col } from 'react-bootstrap';
import { enviroment } from '../service/Enviroments';
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
import Swal from 'sweetalert2';


export default function SubscripcionForm(){

  const[subscripcion, setSubscripcion] = useState({
    customerId: '',
    id: '',
    name: '',
    subscriptionId: ''
  });
  
  const [editing, setEditing] = useState(false);

  const navigate = useNavigate();

  const params = useParams();

  const { customerId, id, name, subscriptionId } = subscripcion;

  const onInputChange = (e) => {
    setSubscripcion({ ...subscripcion, [e.target.name]: e.target.value });
  };

  const loadSubscription = async (id) => {
    await axios({
        method: 'GET',
        url: `${enviroment.clientesURL}api/subscription/${id}`
        }).then(function (res) {
            setSubscripcion(res.data);
            setEditing(true);
        }).catch(function (res) {
            muestraMensaje(res.code, 'error', res.response.data);
        });
    };

    const onSubmit = async (e) => {
        e.preventDefault();
        if(params.id){
            updateSubscription(params.id, subscripcion);
        }else{
            subscripcion.customerId = params.client;
            crearSubscripcion(subscripcion);
        }
    }

    const updateSubscription = async (id, values) => {
        await axios({
            method: 'PUT',
            url: `${enviroment.clientesURL}api/subscription/${id}`,
            data: values
        })
        .then(function (res) {
            guardar();
        })
        .catch(function (res) {
            muestraMensaje(res.code, 'error', res.response.data);
        });
    }

    const crearSubscripcion = async (values) => {
        await axios({
            method: 'POST',
            url: enviroment.clientesURL + 'api/subscription',
            data: values
        }).then(function (res) {
            guardar();
        })
        .catch(function (res) {
            muestraMensaje(res.code, 'error', res.response.data);
        });
    }

    const guardar = () => {
        if(!params.id){
            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: 'Subscripcion Creada con exito',
                showConfirmButton: true,
                timer: 1500
            })
        }else{
            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: 'Subscripcion Actualizado con exito',
                showConfirmButton: true,
                timer: 1500
            })
        }
    }

    const muestraMensaje = (title, icon, text) =>{
        Swal.fire({
            position: 'top-center',
            icon: icon,
            title: title,
            text: text
        })
    }

  useEffect(() => {
    if (params.id) {
        loadSubscription(params.id);
    }
   }, [params.id]);


  return (
    <Container>
      <Row className='text-center'>
        <Col>
            {params.id ? <h4>Editar Subscripci&oacute;n</h4> : <h4>Crear Subscripci&oacute;n</h4> }
        </Col>
      </Row>
      <Form onSubmit={(e) => onSubmit(e)}>
          <Form.Group className="mb-3">
              <Form.Label>Nombre</Form.Label>
              <Form.Control 
                  name="name"
                  type="text" 
                  placeholder="Nombre"
                  value={name}
                  onChange={(e) => onInputChange(e)}
              />
              <Form.Text className="text-muted">
                  nombres.
              </Form.Text>
          </Form.Group>

          <Form.Group className="mb-3">
              <Form.Label>Subscripciones ID</Form.Label>
              <Form.Control
                  name="subscriptionId"
                  type="text" 
                  placeholder="Subscripcion ID"
                  value={subscriptionId}
                  onChange={(e) => onInputChange(e)}
              />
              <Form.Text className="text-muted">
                  Subscription ID.
              </Form.Text>
          </Form.Group>
          <Stack direction="horizontal" gap={2} className="text-center pt-1">
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
