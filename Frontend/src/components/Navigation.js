import React from 'react';
import { Outlet, Link } from "react-router-dom";
import Slidetime from "./Slidetime";
const Navigation = ({ onRouteChange, isSignedIn }) => {
    if (isSignedIn) {
      return (
        <nav style={{display: 'flex', justifyContent: 'flex-end'}}>
          <p onClick={() => onRouteChange('signout')} className='f3 link dim black underline pa3 pointer'>Sign Out</p>
        </nav>
      );
    } else {
      return (
        <>
       
          <nav style={{ display: 'flex', justifyContent: 'flex-end' }}>
            <p className='f3 link dim black underline pa3 pointer'><Link to="/">Home</Link></p>

          <p onClick={() => onRouteChange('login')} className='f3 link dim black underline pa3 pointer'> <Link to="/login">Sign in</Link></p>
          <p onClick={() => onRouteChange('register')} className='f3 link dim black underline pa3 pointer'><Link to="/register">register</Link></p>
          <p className='f3 link dim black underline pa3 pointer'>ShoppingCart</p>
        </nav> 
          <Outlet />
          </>
      );
     
    }
}

export default Navigation;