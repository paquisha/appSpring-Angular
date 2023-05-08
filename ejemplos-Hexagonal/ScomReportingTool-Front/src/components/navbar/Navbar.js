import React from 'react'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { SignOutButton } from "../SignOutButton";

export default function navegacion(){


  return (
    <Navbar bg="dark" variant='dark' expand="lg">
    <Container>
      <Navbar.Brand href="/">Scom</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="me-auto">
          <Nav.Link href="/">Alertas</Nav.Link>
          <Nav.Link href="/configuracion">Configuraci&oacute;n</Nav.Link>
          <Nav.Link href="/herramientas">Herramientas</Nav.Link>
          <Nav.Link href="/reportes">Reportes</Nav.Link>
        </Nav>
        <Nav>
           <SignOutButton /> 
        </Nav>
      </Navbar.Collapse>
    </Container>
  </Navbar>
  )
}
