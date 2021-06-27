import React, {useEffect, useState} from 'react';
import {Row, Col, Button} from 'react-bootstrap'; 
import format from 'number-format.js';
import CartItem from '../CartItem/index';
import { useHistory } from 'react-router';

const Cart= () =>{
            
      const [cart, setCart] = useState([]);
      const [subTotal, setSubTotal] = useState(0.0);
      const history = useHistory();

      const handleCheckout = () => history.push('/purchases/checkout');

      const refreshCart = () =>{

        var storage = localStorage.getItem('@cart:user');
          if(storage !== null){
               let parse = JSON.parse(storage);  
               let subtotal = 0.0;      
               parse.forEach(item => subtotal = subtotal + (item.quantity * item.price))
               setSubTotal(subtotal);  
               setCart(parse);  
           
          }  
      }

      useEffect(() => {

        var storage = localStorage.getItem('@cart:user');
          if(storage !== null){
               let parse = JSON.parse(storage);      
               setCart(parse);  
               let subtotal = 0.0;      
               parse.forEach(item => subtotal = subtotal + (item.quantity * item.price))
               setSubTotal(subtotal);
          }  
      }, []);  
     

    return(
        <>   
            {
              cart && cart.map((item,i) =>( <ul key={i} style={{listStyleType: 'none'}}>
                          <li onClick={refreshCart} >
                            <CartItem key={i} 
                                cart={cart}
                                id={item.id}
                                name={item.name} 
                                imageUri={item.imageUri}
                                description={item.description}
                                price={item.price}
                                quantity={item.quantity}/>
                                
                          </li>
              </ul> )
              
              )
            }

            <Row style={{ marginTop: 10 }}>
              <Col xs={6}> <h4><strong> Subtotal (BRL) $ </strong></h4> </Col>
              <Col xs={6}> <strong> {format("#,##0.00", subTotal)} </strong></Col>
            </Row>

             <Row style={{ marginTop: 10 }}>
               <Col xs={6}> <Button onClick={() => handleCheckout()}> Checkout </Button></Col>
             </Row>

        </>
  
    )
}

export default Cart;