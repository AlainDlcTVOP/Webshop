import React from 'react';
import { ProductContainer } from './components/ProductContainer';
import { Route, BrowserRouter ,Routes} from "react-router-dom";
import Login from './components/Login';
import Register from './components/Register';
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
              <Route path='/products' element={ <ProductContainer/> }/>
        
        </Route>
      </Routes>
        </BrowserRouter>
        </div>
        );
       
  }


export default App;