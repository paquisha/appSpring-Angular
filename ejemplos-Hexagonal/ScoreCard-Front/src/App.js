import './App.css';
import {BrowserRouter, Routes, Route} from "react-router-dom";
import { AuthenticatedTemplate, UnauthenticatedTemplate } from "@azure/msal-react";
import Clientes from './components/pages/Clientes';
import Herramientas from './components/pages/Herramientas';
import Login from './components/login/login';
import Pie from './components/footer/Footer';
import Navbar from './components/navbar/Navbar';
import { Container } from 'react-bootstrap';
import { useSpring, animated } from "@react-spring/web";
import FormCliente from "./components/pages/FormCliente";
import FormSubscripcion from './components/pages/SubscripcionForm';


function App() {
  const props = useSpring({ opacity: 1, from: { opacity: 0 } });
  return (
    <animated.div style={props}>
      <Container fluid>
        <AuthenticatedTemplate>
          <BrowserRouter>
            <Navbar />
            <Routes>              
              <Route path='/herramientas' element={<Herramientas />} />
              <Route path='/' element={<Clientes />} />
              <Route path='/cliente/new' element={<FormCliente />} />
              <Route path='/cliente/:id/edit' element={<FormCliente />} />
              <Route path='/subscripcion/new/:client' element={<FormSubscripcion />} />
              <Route path='/subscripcion/:id/edit' element={<FormSubscripcion />} />
            </Routes>
            <Pie className=''/>
          </BrowserRouter>
        </AuthenticatedTemplate>
        <UnauthenticatedTemplate>
          <Login />
        </UnauthenticatedTemplate>
      </Container>
    </animated.div>
  );
}

export default App;