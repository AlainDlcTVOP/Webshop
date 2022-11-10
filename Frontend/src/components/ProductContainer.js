import React from "react";

import products from "../data/products.json";
import category from "../data/category.json";

import {Card, Col, Row, Container} from "react-bootstrap";


export class ProductContainer extends React.Component {

    
  

    constructor(props) {
        super(props)
        
  this.state = {
    productId:0,
    name:"",
    price:0,
    description: "",
    productSaldo:0,
    img:"",
    brand:""
        };

    }



       
componentDidMount(){

   
}


detailsClick(product) {

  if (product.productId != null){
  
   this.setState({
    productId : product.productId,
    name: product.name,
    price: product.price,
    description: product.description,
    productSaldo: product.productSaldo,
    img: product.img,
    brand:product.brand

  });
  } 
}

render(){
  const addProduct = () => {
    alert("Product added.")
}




    const{
      productId,
      name,
      price,
      description,
      productSaldo,
      img,
      brand
    } =this.state;
       
    
        return (
            <div>
<div class="input-group  align-items-center justify-content-center  m-5">
  <div id="search-autocomplete" class="form-outline">
    <input type="search" id="form1" class="form-control" placeholder="Search" />
   
  </div>
  <button type="button" class="btn btn-primary">
    <i class="fa fa-search"></i>
  </button>
</div>
                <h1>Product</h1>
         
               <div className="container container-md">
               <div className="p-4">
                   <h1 className="display-6">Web Knas</h1>
               </div>

               

               <div className="d-flex justify-content-start">
                   <ul className="list-group list-unstyled list-group-flush">
                       {category.map((category) => (
                           <li key={category.categoryId}>
                               <a href="http://localhost:3000/products" className="list-group-item list-group-item-action">
                                   {category.name}
                               </a>
                           </li>
                           
                       )

                       )}
                   </ul>

                   <div className="d-flex justify-content-center">
                           <Container>
                               <Row xs={1} md={3} className="g-6">
                                   {products.map((product) => (
                                       <Col>
                                       <Card key={product.productId} border="dark">
                                         
                                           <Card.Body>
                                               <Card.Title className="d-flex justify-content-between align-items-baseline mb-4">
                                                   <span className="fs-4">{product.name}</span>
                                                   <span className="ms-1 text-muted">{product.price}:-</span>
                                               </Card.Title>
                                               <Card.Link  className="btn btn-primary"
                                                 data-bs-toggle="modal"
                                                 data-bs-target="#exampleModel"
                                                 onClick={() => this.detailsClick(product)}
                                               >Details</Card.Link>
                                               <Card.Link onClick={addProduct} className="btn btn-outline-dark">Add to cart</Card.Link>
                                           </Card.Body>
                                       </Card>
                                       </Col>
                                   ))}
                               </Row>
                           </Container>
                   </div>
               </div>
           </div>


           <div id="exampleModel" class="modal" tabindex="-1">
          <div class="modal-dialog modal-xl">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title">Details</h5>
                <button
                  type="button"
                  class="btn-close"
                  data-bs-dismiss="modal"
                  aria-label="Close"
                ></button>
              </div>
              <div class="modal-body">
                <div>
                  <table className="table table-striped">
                    <thead>
                      <tr>
                        <th scope="col">Id</th>
                        <th scope="col">Name</th>
                        <th scope="col">Price</th>
                        <th scope="col">Description</th>
                        <th scope="col">ProductSaldo</th>
                        <th scope="col">Image</th>
                        <th scope="col">Brand</th>
                       
                      </tr>
                    </thead>
                    <tbody>
                      <tr> 
     
      
                        <td>{productId}</td>
                        <td>{name}</td>
                        <td>{price}</td>
                        <td>{description}</td>
                        <td>{productSaldo}</td>
                        <td>{img}</td>
                        <td>{brand}</td>
                      
                          
                 
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
              <div class="modal-footer">
                <button
                  type="button"
                  class="btn btn-secondary"
                  data-bs-dismiss="modal"
                >
                  Close
                </button>
              </div>
            </div>
          </div>
        </div>




           </div>
        );
            
    }
}