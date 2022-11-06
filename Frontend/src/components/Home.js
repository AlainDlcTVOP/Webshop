import React from "react";
import Navigation from "./Navigation";
import Cool from "./Cool";

import Slidetime from "./Slidetime";

const Home = () => {
  
    return (
         <>
            <Navigation /> 
            <Slidetime/>
            {/*<Cool/>  if we want it */}    
            <Cool/>
       </>
    )
        
    
}

export default Home;