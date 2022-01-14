import { BrowserRouter as Router, Route, Routes, Switch } from 'react-router-dom'
import './App.css';
import { ListEmployeeComponent } from './components/ListEmployeeComponent';
import HeaderComponent from './components/HeaderComponent';
import FooterComponent from './components/FooterComponent';
import AddEmployeeComponent from './components/AddEmployeeComponent';

function App() {
  return (
    <div>
      <Router>
        <HeaderComponent />
        <div className='container'>
          <Routes>
            <Route exact path="/" element={<ListEmployeeComponent />}></Route>
            <Route path="/employees" element={<ListEmployeeComponent />}></Route>
            <Route path="/add-employee" element={<AddEmployeeComponent />} ></Route>
          </Routes>
        </div>
        <FooterComponent />  
      </Router>      
    </div>
  );
}

export default App;
