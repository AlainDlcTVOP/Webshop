import React, { Component } from 'react'  
import "slick-carousel/slick/slick.css";  
import "slick-carousel/slick/slick-theme.css";  
import Slider from "react-slick";  
import './slick.css'; 

const Slidetime = () =>  {  
   
        var images = [    
            { img: 'assets/place.jpg' },    
            { img: 'assets/place2.jpg' },    
            { img: 'assets/place3.jpg' },    
            
          ];   
    var imgSlides = () =>  
    images.map(num => (  
      <div className="imgpad">  
          <img className="imgdetails" src= {num.img} width="100%"/>    
      </div>  
    ));  
  return (  
    <div className="App">  
         <div class='container-fluid'>        
            <div className="row title" style={{marginBottom: "10px"}} >        
            <div class="col-sm-12 btn btn-info">        
         
            </div>        
            </div>    
            </div>  
      <Slider  
    dots={true}  
        slidesToShow={1}  
        slidesToScroll={1}  
        autoplay={true}  
        
        autoplaySpeed={2500}>{imgSlides()}</Slider>  
    </div>  
  );  
}  
 
export default Slidetime;  