package ec.com.aekmot.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

import ec.com.aekmot.exception.ResourceNotFoundException;
import ec.com.aekmot.model.Employee;
import ec.com.aekmot.repository.EmployeeRepository;


@CrossOrigin(origins = {"http://localhost:3000/"})
@RestController
@RequestMapping("/api")
public class EmployeeController {
	
	@Autowired
	private EmployeeRepository employeeRepository;
	
	//get employee list
	@GetMapping("/employees")
	public List<Employee> getAllEmployees(){
		return employeeRepository.findAll();
	}
	
	@GetMapping("/employees/{id}")
	public ResponseEntity<Employee> getEmployeeById(@PathVariable long id){
		Employee employee = employeeRepository.findById(id).orElseThrow(() -> new ResourceNotFoundException("Empleado no existe con el id: " + id));
		return ResponseEntity.ok(employee);
	}
	
	@PostMapping("/employees")
	public Employee createEmployee(@RequestBody Employee employee) {
		return employeeRepository.save(employee);
	}
	
	@PutMapping("/employees/{id}")
	public ResponseEntity<Employee> updateEmployee(@PathVariable long id, @RequestBody Employee employeeDetails){
		Employee updateEmployee = employeeRepository.findById(id)
				.orElseThrow(() -> new ResourceNotFoundException("Empleado no existe con el id: " + id));
		
		updateEmployee.setFirstName(employeeDetails.getFirstName());
		updateEmployee.setLastName(employeeDetails.getLastName());
		updateEmployee.setEmailId(employeeDetails.getEmailId());
		
		employeeRepository.save(updateEmployee);
		
		return ResponseEntity.ok(updateEmployee);
	}
	
	@DeleteMapping("/employees/{id}")
	public ResponseEntity<HttpStatus> deleteEmployee(@PathVariable long id){
		Employee employee = employeeRepository.findById(id)
				.orElseThrow(() -> new ResourceNotFoundException("Empleado no existe con el id: " + id));
		
		employeeRepository.delete(employee);
		
		return new ResponseEntity<>(HttpStatus.NO_CONTENT);
	}
	
	
}
