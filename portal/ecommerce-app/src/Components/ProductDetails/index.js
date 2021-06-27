import React, {useState, useEffect} from 'react';
import {Container, Row, Col, Image, Button} from 'react-bootstrap';
import {useParams} from 'react-router-dom';
import format from 'number-format.js';
import api from '../../Services/api';
import './styles.css';


const ProductDetails = () =>{
     
    const {id} = useParams();
    const [product, setProduct] = useState([]);
    const [quantity, setQuantity] = useState(1);
    const [added, setAdded] = useState(false);

    useEffect(() =>{
    
         const fetchProduct = async () =>{
              const response = await api.get(`products/${id}`);
              setProduct(response.data);
         }
         fetchProduct();

         let storage = localStorage.getItem('@cart:user');

         if (storage !== null) {
           let cart = JSON.parse(storage);
           const id_ = parseInt(id);
           cart.map(item => parseInt(item.id) === id_? setAdded(true) : false);
           
         }
         
       
    },[id]);

    const addItemToCart = () => {

    if (localStorage.getItem('@cart:user') === null) {
      const products = [];
      localStorage.setItem('@cart:user', JSON.stringify(products));
    }

    let rawCart = localStorage.getItem('@cart:user');
    let cart = JSON.parse(rawCart);

    if (added) return;
   
     const prod = {
       id: id,
       name: product.name,
       description: product.description,
       price: product.price,
       observation: product.observation,
       imageUri: product.imageUri,
       quantity: quantity
     }
    cart.push(prod);
    localStorage.setItem('@cart:user', JSON.stringify(cart));
    setAdded(true);
   }

   const removeItemFromCart = () =>{
     if(added){
        let rawCart = localStorage.getItem('@cart:user');
        let cart = JSON.parse(rawCart);
        const id_ = parseInt(id);
        cart = cart.filter(item => parseInt(item.id) !== id_);
        localStorage.setItem('@cart:user', JSON.stringify(cart));
        setAdded(false);
     }
   }


  return (
      <>
      <Container>
         <div className="view-size">
             <Row>
               <Col md={2}/>
                <Image className="image-zoom" as={Col} src={product?.imageUri} height={250} width={400}/>
                <Col xs={1}/>
                <div className="purchase-card">
                    <Row>
                        <Col xs={6}> {product?.name} </Col>
                      </Row>  
                    <Row>
                        <Col xs={6}> <p className="badge badge-dark">Price</p> </Col>         
                        <Col xs={5}>
                              <strong>  (BRL) $ 
                              {format("#,##0.00", product?.price)}
                             </strong>
                              </Col> 
                    </Row>
                     
                     <Row>
                       <Col xs={6}> {quantity} x { quantity * product?.price}</Col>  
                       <Col xs={6}> 
                            <label id="quantity" className="badge badge-dark"> Quantity </label>
                            <input for="quantity" style={{width: '50%', marginLeft: 5}} type="number" min="1" value={quantity} onChange={e => setQuantity(e.target.value)}/>
                           
                        </Col>
                     </Row>

                     <Row>
                       <Col xs={6}> Parcelas </Col>  
                       <Col xs={6}> 
                       10 X {format("#,##0.00", (quantity * product?.price)/ 10)}
                                            
                        </Col>
                     </Row>
                
                     <Row style={{marginTop: 25}}>
                       <Col xs={6}>  <Button variant={added? 'success': 'primary'} onClick={addItemToCart}> {added? 'Added to Cart' :'Add to Cart'} </Button> </Col>
                       <Col xs={6}>  <Button variant={!added? 'info': 'danger'} hidden={!added} onClick={removeItemFromCart}> Remove from Cart </Button> </Col> 
                    </Row>
                </div>

             </Row>
            
             <Row>
                 <Col><h3 className="badge badge-dark"> Description </h3></Col>
             </Row>
             <Row style={{padding: 10}}>
                 <Col>{product?.description}</Col>
             </Row>

             <Row>
                 <Col><h3 className="badge badge-dark"> Observation </h3></Col>
             </Row>
             <Row style={{padding: 10}}>
                 <Col>{product?.observation}</Col>
             </Row>

         </div>
      </Container>
      </>
  )

}

export default ProductDetails;
