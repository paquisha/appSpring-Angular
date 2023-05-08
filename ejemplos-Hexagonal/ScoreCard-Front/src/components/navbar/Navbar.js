import React from "react";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { SignOutButton } from "../SignOutButton";

export default function navegacion(){
    return(
        <Navbar bg="dark" variant='dark' expand="lg">
        <Container>
          <Navbar.Brand href="/">
            <img
              src="https://grupobusiness.it/hs-fs/hubfs/raw_assets/public/Business_It_November2022/images/BusinessITLogo-1.png?width=595&name=BusinessITLogo-1.png"
              width="30"
              height="30"
              className="d-inline-block align-top"
              alt="React Bootstrap logo"
            />
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="/">Clientes</Nav.Link>
              <Nav.Link href="/herramientas">Herramientas</Nav.Link>
            </Nav>
            <Nav>
               <SignOutButton /> 
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    )
}