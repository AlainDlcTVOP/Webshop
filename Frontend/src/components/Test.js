import React,{useState,useEffect} from "react"
import axios from "axios";
const Test = () => {


const [pokemon, setPokemon] = useState("");

const baseurl = "https://localhost:7164/Identity/Account/Login";

useEffect(() => {
    axios.get(baseurl).then((response) => {
        setPokemon(response.data);
       
        console.log(response.data);
    });
}, []);
  
return (
        
        <h1></h1>
           
           
        
    )

}
export default Test;





