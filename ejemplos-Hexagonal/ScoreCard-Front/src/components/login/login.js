import React from 'react'
import { SignInButton } from "../SignInButton";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export default function Login(props){
  return (
    <Container fluid className='login'>
        <Row className='pt-5 mb-5'>
        </Row>
        <Row className='pt-5 mb-5'>
        </Row>
        <Row className='pt-5 mb-5'>
        </Row>
        <Row>
            <Col className='text-center text-white pt-5'>
                <h2 className=''>BIT</h2>
            </Col>
        </Row>
        <Row>
            <Col className='text-center pt-5'>
                <SignInButton />
            </Col>
        </Row>
        <Row>
            <Col className='text-center text-white'>
                Por favor inicia Ses&iacute;on
            </Col>
        </Row>
    </Container>
  )
}