import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import EmployeeService from "../services/EmployeeService";

export const ListEmployeeComponent = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    getAllEmployees();
  }, []);

  const getAllEmployees = () =>{
    EmployeeService.getAllEmployees()
      .then((response) => {
        setEmployees(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  const deleteEmployee = (employeeId) =>{
    if(employeeId){
      EmployeeService.deleteEmployee(employeeId).then(response =>{
        getAllEmployees();
      }).catch(error =>{
        console.log(error);
      })
    }
  }

  return (
    <div className="container">
      <h2 className="text-center">Lista de Empleados</h2>
      <br />
      <Link to="/add-employee" className="btn btn-primary mb-2">
        Agregar Empleado
      </Link>
      <br />
      <table className="table table-bordered table-striped">
        <thead>
          <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Email</th>
            <th>Aciones</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((empleado) => (
            <tr key={empleado.id}>
              <th>{empleado.id}</th>
              <td>{empleado.firstName}</td>
              <td>{empleado.lastName}</td>
              <td>{empleado.emailId}</td>
              <td>
              <Link
                  className="btn btn-warning"
                  to={`/edit-employee/${empleado.id}`}
                >
                  Editar
                </Link>{" "}
                <button className="btn btn-danger" onClick={() => deleteEmployee(empleado.id)}>Borrar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};
