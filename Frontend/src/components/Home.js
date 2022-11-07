import React,{useState} from "react";
import Navigation from "./Navigation";
import Cool from "./Cool";
import { ProductContainer } from "./ProductContainer";
import Slidetime from "./Slidetime";



const Home = () => {
  
    return (
        
        <>
           
            {/*<Slidetime/>  Hide comenent if hit navigation  */}    
            <Navigation />
            <Slidetime/>
            <ProductContainer/>
            
       
            <Cool/>
       </>
    )
        
    
}

export default Home;