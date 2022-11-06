import React from "react";
import { Outlet, Link } from "react-router-dom";
const Header = () => {
    return (
        <div>
             <nav style={{display: 'flex', justifyContent: 'flex-end'}}>
        
    
      
             <Link to="/login">Login</Link>
                    
                    <Link to="/register">Register</Link>
                <Outlet />
                </nav>
        </div>
    )
}

export default Header;