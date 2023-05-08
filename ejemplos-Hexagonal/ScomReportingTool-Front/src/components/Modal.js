import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import { FaTrash,FaPlus } from "react-icons/fa";
import { Col, Row } from 'react-bootstrap';
import Stack from 'react-bootstrap/Stack';


export default function ElementoModal({id, title, contenido, show, handleClose}){
    const [causaUno, setCausaUno] = useState(true);
    return(
        <Modal id={id} show={show} onHide={handleClose} className='modal-xl'>
        <Modal.Header closeButton>
          <Modal.Title>{title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form>
                <Row>
                    <Col>
                        <Form.Label>{contenido}</Form.Label>
                    </Col>
                    <Col>
                        <Form.Group className="mb-3" controlId="Area">
                            <Form.Label>Area</Form.Label>
                            <Form.Select aria-label="Clientes">
                                <option>Seleccione...</option>
                                <option value="1">One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                            </Form.Select>
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group className="mb-3" controlId="destinatarios">
                            <Form.Label>Grupo Destinatarios</Form.Label>
                            <Form.Select aria-label="Clientes">
                                <option>Seleccione...</option>
                                <option value="1">One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                            </Form.Select>
                        </Form.Group>
                    </Col>
                </Row>
                <Row>
                    <Col className='col-md-6'>
                        <Form.Group className="mb-3" controlId="umbral">
                            <Form.Label>Valor de Umbral</Form.Label>
                            <Form.Control type="text" placeholder="Valor de Umbral" />
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group className="mb-3" controlId="equipo">
                            <Form.Label>Equipo</Form.Label>
                            <Form.Control type="text" placeholder="" />
                        </Form.Group>
                    </Col>
                </Row>
                <Row>
                    <Form.Group className="mb-3" controlId="descripcion">
                        <Form.Label>descripci&oacute;n</Form.Label>
                        <Form.Control type="text" placeholder="Descripci&oacute;n" />
                    </Form.Group>
                </Row>
                <Row>
                    <Col>
                        <Row>
                            Causas:
                            <Form.Group className={causaUno ? "show-element mb-3" : "mb-3"}>
                                <Form.Label>Es probabable que el host no disponga de los</Form.Label>{' '}
                                <Button variant="outline-success" onClick={() => setCausaUno(causaUno)} >
                                    <FaTrash />
                                </Button>
                            </Form.Group>
                        </Row>
                        <Row>
                            <Form.Group className='mb-3'>
                                <Form.Label>Puede que haya demasiados CPU virtuales en</Form.Label>{' '}
                                    <Button variant="outline-success">
                                        <FaTrash />
                                    </Button>
                            </Form.Group>
                        </Row>
                        <Stack direction="horizontal" gap={3}>
                            <Form.Group className='mb-3'>
                                <Form.Control type="text" />
                            </Form.Group>
                            <Button variant="outline-success mb-3">
                                <FaPlus />
                            </Button>
                        </Stack>
                    </Col>
                    <Col>
                        <Row>
                            Resoluciones:
                            <Form.Group className='mb-3'>
                                <Form.Label>Compruebe que VMware Tools este instalado</Form.Label>{' '}
                                    <Button variant="outline-success">
                                        <FaTrash />
                                    </Button>
                            </Form.Group>
                        </Row>
                        <Row>
                            <Form.Group className='mb-3'>
                                <Form.Label>Determine si el valor alto de tiempo de prepa</Form.Label>{' '}
                                    <Button variant="outline-success">
                                        <FaTrash />
                                    </Button>
                            </Form.Group>
                        </Row>
                        <Stack direction="horizontal" gap={3}>
                            <Form.Group className='mb-3'>
                                <Form.Control type="text" />
                            </Form.Group>
                            <Button variant="outline-success mb-3">
                                <FaPlus />
                            </Button>
                        </Stack>
                    </Col>
                </Row>
            </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="success" onClick={handleClose}>
            Previsualizar
          </Button>
          <Button variant="primary" onClick={handleClose}>
            Reportar
          </Button>
          <Button variant="danger" onClick={handleClose}>
            Cancelar
          </Button>
        </Modal.Footer>
      </Modal>
    )
}

// export default function ElementoModal({id,titulo,contenido}){
//     return(
//         <div className="modal fade" id={id} tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
//         <div className="modal-dialog modal-xl">
//             <div className="modal-content">
//             <div className="modal-header">
//                 <h1 className="modal-title fs-5" id="exampleModalLabel">{titulo}</h1>
//                 <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
//             </div>
//             <div className="modal-body">
//                 {contenido}
//             </div>
//             <div className="modal-footer">
//                 <button type="button" className="btn btn-success">Previsualizar</button>
//                 <button type="button" className="btn btn-secondary">Reportar</button>
//                 <button type="button" className="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
//             </div>
//             </div>
//         </div>
//         </div>
//     )
// }