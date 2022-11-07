import React,{useState} from "react";
import Navigation from "./Navigation";
import Cool from "./Cool";
import Slidetime from "./Slidetime";
import Cards from "./Cards";


const Home = () => {
  
    return (
        
        <>
           
            {/*<Slidetime/>  Hide comenent if hit navigation  */}    
       <Navigation/>
            
         
            <Cool/>
       </>
    )
        
    
}

export default Home;