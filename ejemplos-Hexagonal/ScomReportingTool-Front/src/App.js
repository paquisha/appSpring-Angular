import './App.css';
import {BrowserRouter, Routes, Route} from "react-router-dom";
import Alertas from './components/Alertas';
import Configuracion from './components/Configuracion';
import Herramientas from './components/Herramientas';
import Reportes from './components/Reportes';
import Pie from './components/footer/Footer';
import { AuthenticatedTemplate, UnauthenticatedTemplate } from "@azure/msal-react";
import Login from './components/login/login';
import Navbar from './components/navbar/Navbar' 


function App() {
  return (
    <>
      <AuthenticatedTemplate>
        <BrowserRouter>
          <Navbar />
          <Routes>
            <Route path='/' element={<Alertas />} />
            <Route path='/configuracion' element={<Configuracion />} />
            <Route path='/herramientas' element={<Herramientas />} />
            <Route path='/reportes' element={<Reportes />} />
          </Routes>
          <Pie />
        </BrowserRouter>
      </AuthenticatedTemplate>
      <UnauthenticatedTemplate>
        <Login />
      </UnauthenticatedTemplate>
    </>
  );
}

export default App;
