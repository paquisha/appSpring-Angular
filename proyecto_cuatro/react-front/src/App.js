import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import './App.css';
import { ListEmployeeComponent } from './components/ListEmployeeComponent';
import HeaderComponent from './components/HeaderComponent';
import FooterComponent from './components/FooterComponent';

function App() {
  return (
    <div>
      <Router>
        <HeaderComponent />
        <div className='container'>
          <Routes>
            <Route exact path="/" component={ListEmployeeComponent}></Route>
            <Route path="/employees" component={ListEmployeeComponent}></Route>
          </Routes>
        </div>
        <FooterComponent />  
      </Router>
      
      <ListEmployeeComponent />
      
    </div>
  );
}

export default App;
