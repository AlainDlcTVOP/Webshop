import React, { useState, useCallback } from "react";






import axios from 'axios';

const ProductContainer = (props) => {
    const [products, setProducts] = useState([]);
   
  
  
    useFocusEffect((
      useCallback(
        () => {
          setFocus(false);
          setActive(-1);
          
          // Products
          axios
            .get(`${baseURL}products`)
            .then((res) => {
              setProducts(res.data);
            
            })
            .catch((error) => {
              console.log('Api call error')
            })
      
          // Categories
          axios
            .get(`${baseURL}categories`)
            .then((res) => {
              setCategories(res.data)
            })
            .catch((error) => {
              console.log('Api call error')
            })
      
          return () => {
            setProducts([]);
        
          };
        },
        [],
      )
    ))
      
     
    
  
    // Product Methods
    const searchProduct = (text) => {
      setProductsFiltered(
        products.filter((i) => i.name.toLowerCase().includes(text.toLowerCase()))
      );
    };
  
    
  
    return (
      <>
 </>
    );
  };
  
  
  
  export default ProductContainer;