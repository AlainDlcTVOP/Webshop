import React from 'react';
import ParticlesBg from 'particles-bg'
import Navigation from './components/Navigation';
import { Route, BrowserRouter ,Routes} from "react-router-dom";
import Login from './components/Login';
import Register from './components/Register';
import Header from './components/Header';
import './App.css';
import Home from './components/Home';


const App = () => {
 
 
    return (
      <div className="App">
       
       <BrowserRouter>
      <Routes>
        <Route path="/" exact element={<Home />}>
          
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
         
        
        </Route>
      </Routes>
        </BrowserRouter>
        </div>
        );
       
  }


export default App;