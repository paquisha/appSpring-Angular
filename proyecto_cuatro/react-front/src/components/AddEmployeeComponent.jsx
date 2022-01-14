import React, { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import { Link, useParams } from 'react-router-dom';
import EmployeeService from '../services/EmployeeService';

const AddEmployeeComponent = () => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [emailId, setEmailId] = useState("");
  const navigate = useNavigate();
  const {id} = useParams();

  const saveOrUpdateEmpleado = (e) =>{
      e.preventDefault();
      let employee = {
          firstName,
          lastName,
          emailId
      }

      if(id){
          EmployeeService.updateEmployee(id, employee).then(response =>{
            navigate('/employees');
          }).catch(error =>{
              console.log(error);
          })
      }else{
        EmployeeService.createEmployee(employee).then(response =>{
            navigate('/employees');
          }).catch(error => {
              console.log(error);
          })
      }
  }

  useEffect(() => {
      EmployeeService.getEmployeeById(id).then((response) => {
          setFirstName(response.data.firstName);
          setLastName(response.data.lastName);
          setEmailId(response.data.emailId);
      }).catch(error => {
          console.log(error);
      })
  }, [])

  const title=()=>{
      if(id){
          return <h2 className="text-center">Editar empleado</h2>
      }else{
        return <h2 className="text-center">Agregar empleado</h2>
      }
  }

  return (
    <div>
      <br />
      {
          title()
      }
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
                <button type="submit" className="btn btn-success" onClick={(e) => saveOrUpdateEmpleado(e)}>Save</button>{" "}
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
