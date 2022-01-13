import axios from 'axios';

const EMPLOYEE_BASE_REST_API_URL = 'http://localhost:8080/api/employees';

class employeeServices{
    getAllEmployees(){
        return axios.get(EMPLOYEE_BASE_REST_API_URL);
    }
}

export default new employeeServices();