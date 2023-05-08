import React, { useEffect, useState } from "react";
import { Container, Row, Table, Card, ListGroup } from "react-bootstrap";
import Navbar from "react-bootstrap/Navbar";
import Form from "react-bootstrap/Form";
import Nav from "react-bootstrap/Nav";
import Button from "react-bootstrap/Button";
import { enviroment } from "./service/Enviroment";
import axios from "axios";

export default function Home() {
  const [unica, setUnica] = useState({
    id: 0,
    cedula: "",
    name: "",
    lastName: "",
    state: 0,
  });
  const [estadoPersona, setEstadoPersona] = useState(false);
  const [persona, setPersona] = useState([]);
  const [estado, setEstado] = useState(false);
  const [texto, setTexto] = useState("");

  const getPersonas = async () => {
    await axios
      .get(enviroment.base_url + "api/Persona")
      .then((response) => {
        console.log(response.data);
        setPersona(response.data);
        setEstado(true);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const data = [
    {
      id: 1,
      cedula: "1726189739",
      name: "Gina",
      lastName: "Pachacama",
      state: 1,
    },
    {
      id: 2,
      cedula: "1718970625",
      name: "Amaru",
      lastName: "Grijalva",
      state: 0,
    },
  ];

  const currentData = persona != null ? persona : data;

  const getByCedula = async () => {
    await axios
      .get(enviroment.base_url + "api/Persona/" + texto)
      .then((response) => {
        console.log(response.data);
        setUnica(response.data);
        setEstadoPersona(true);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    getPersonas();
  }, []);

  return (
    <Container>
      <Navbar bg="light" expand="lg">
        <Container fluid>
          <Navbar.Brand href="#">Prueba BGR</Navbar.Brand>
          <Navbar.Toggle aria-controls="navbarScroll" />
          <Navbar.Collapse id="navbarScroll">
            <Nav
              className="me-auto my-2 my-lg-0"
              style={{ maxHeight: "100px" }}
              navbarScroll
            >
              <Nav.Link href="#action1">Home</Nav.Link>
              <Nav.Link href="#" disabled>
                Link
              </Nav.Link>
            </Nav>
            <Form className="d-flex">
              <Form.Control
                type="search"
                placeholder="Search"
                className="me-2"
                aria-label="Search"
                value={texto}
                onChange={(e) => setTexto(e.target.value)}
              />
              <Button variant="outline-success" onClick={() => getByCedula()}>
                buscar
              </Button>
            </Form>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <Row className="pt-2">
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>#</th>
              <th>Cedula</th>
              <th>Name</th>
              <th>Last Name</th>
              <th>State</th>
            </tr>
          </thead>
          <tbody>
            {estado ? (
              currentData.map((row) => (
                <tr key={row.id}>
                  <td>{row.id}</td>
                  <td>{row.cedula}</td>
                  <td>{row.name}</td>
                  <td>{row.lastName}</td>
                  <td>{row.state === 1 ? "Activo" : "Inactivo"}</td>
                </tr>
              ))
            ) : (
              <tr>
                <td>no data</td>
              </tr>
            )}
          </tbody>
        </Table>
      </Row>
      <Row className="pt-2">
        {
            estadoPersona ?
            <Card style={{ width: "18rem" }}>
            <Card.Header>Persona</Card.Header>
            <ListGroup variant="flush">
              <ListGroup.Item>nombre: {unica.name}</ListGroup.Item>
              <ListGroup.Item>Apellido: {unica.lastName}</ListGroup.Item>
              <ListGroup.Item>Cedula: {unica.cedula}</ListGroup.Item>
            </ListGroup>
          </Card>
          :
          ''
        }
      </Row>
    </Container>
  );
}
