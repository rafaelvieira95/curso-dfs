import React, {useEffect, useState} from 'react';
import {Image, Carousel, Container, Row, Col} from 'react-bootstrap';
import image1 from '../../_img/carrossel-1.webp';
import image2 from '../../_img/carrossel-2.png';
import image3 from '../../_img/carrossel-3.webp';
import './styles.css'

import api from '../../Services/api';
import Item from '../../Components/Item/index';

const Home = () =>{

  const [products, setProducts] = useState([]);

  useEffect(() => {
    const fetchProducts = async () => {
      const response = await api.get('products');
      setProducts(response.data);
    }
    fetchProducts();
  }, []);

    return (
      <>
    <Container fluid>
    <Carousel className="img-size" fade >
        <Carousel.Item interval={1000}>
          <Image
            className="d-block w-100 img-size"
            src={image1}
            alt="First slide"
          />
     
        </Carousel.Item>
        <Carousel.Item interval={500}>
          <Image
            className="d-block w-100 img-size"
            src={image2}
            alt="Second slide"
          />
   
        </Carousel.Item>
        <Carousel.Item>
          <Image
            className="d-block w-100 img-size"
            src={image3}
            alt="Third slide"
          />
  
        </Carousel.Item>
      </Carousel>
      <Row>
        {
          products && products.map(product =>( 
             <Item key={product.id} as={Col} product={product}/>
          ))  
        }
         </Row>
      
    </Container>
     </>
  )
}

export {Home};


