import React, {useEffect, useState} from 'react';
import {Table, Button, Container} from 'react-bootstrap';
import { Link } from 'react-router-dom';
import api from '../../../../Services/api';
import format from 'number-format.js';

import './styles.css';

const ProductList = () => {

      const [products, setProducts] = useState([]);
    
      const [isDelete, setIsDelete] = useState(false);

      useEffect(() =>{
         
        const fecthProducts = async () =>{
            const response = await api.get('products');
            setProducts(response.data);
        }

        fecthProducts();

      }, []);

      const handleDelete = async (product) =>{ 

           setIsDelete(window.confirm("Do you really want delete this product?"));
           
           if(isDelete){

           const response = await api.delete(`products/${product.id}`);
             
           if(response.status === 200){
                    setProducts(products.filter(p => p !== product));
               }       
            }
            setIsDelete(false);         
      }

    
      return (
       <>
       <Container className="table-box">
           
        <Table responsive hover>
            <thead>
                <tr>
                    <th>Product Name</th>
                    <th>Price $ (BRL)</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>

            <tbody>
                { products && products.map(product =>(
                <tr key={product.id}>
                  <td>{product.name}</td>
                  <td>{format("#,##0.00",product.price)}</td>
                  <td> <Link to={`/product/edit/${product.id}`}> edit </Link> </td>
                  <td> <Button onClick={() => handleDelete(product)}> delete </Button> </td>
                </tr>
                ))}
            </tbody>
           </Table>
           </Container>
       
       </>);
}
export default ProductList;