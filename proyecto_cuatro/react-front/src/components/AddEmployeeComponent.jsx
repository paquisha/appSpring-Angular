import React, { useState } from "react";
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import EmployeeService from '../services/EmployeeService';

const AddEmployeeComponent = () => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [emailId, setEmailId] = useState("");
  const navigate = useNavigate();

  const saveEmpleado = (e) =>{
      e.preventDefault();
      let employee = {
          firstName,
          lastName,
          emailId
      }
      EmployeeService.createEmployee(employee).then(response =>{
        navigate('/employees');
      }).catch(error => {
          console.log(error);
      })
  }

  return (
    <div>
      <h3>Agregar empleado</h3>
      <br />
      <div className="container">
        <div className="row">
          <div className="card col-md-6 offset-md-3 offset-md-3">
            <h2></h2>
            <div className="card-body">
              <form>
                <div className="form-group mb-2">
                  <label>Nombre:</label>
                  <input
                    type="text"
                    placeholder="ingrese nombre"
                    name="firstName"
                    className="form-control"
                    value={firstName}
                    onChange={(e) => setFirstName(e.target.value)}
                  />
                </div>
                <div className="form-group mb-2">
                  <label>Apellido:</label>
                  <input
                    type="text"
                    placeholder="ingrese apellido"
                    name="lastName"
                    className="form-control"
                    value={lastName}
                    onChange={(e) => setLastName(e.target.value)}
                  />
                </div>
                <div className="form-group mb-2">
                  <label>Email:</label>
                  <input
                    type="email"
                    placeholder="ingrese email"
                    name="emailId"
                    className="form-control"
                    value={emailId}
                    onChange={(e) => setEmailId(e.target.value)}
                  />
                </div>
                <button type="submit" className="btn btn-success" onClick={(e) => saveEmpleado(e)}>Save</button>{" "}
                <Link to="/employees" className='btn btn-danger' >Cancelar</Link>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddEmployeeComponent;
