import React, {useEffect, useState} from 'react';
import {Container, Col, Form, Button} from 'react-bootstrap';
import {useForm} from 'react-hook-form';
import { useHistory } from 'react-router';
import './styles.css';
import api from '../../../../Services/api';


const Product = () =>{

    
     const {register, handleSubmit} = useForm();
     const [companies, setCompanies] = useState([]);
    
     const history = useHistory();
     
     const submit = async data =>{
             
            const {Name, Description, Price, Observation, CompanyId, ImageUri} = data;
           
           try{
           
            const response = await api.post('products',{
                Name, 
                Description, 
                Price, 
                Observation,
                ImageUri, 
                CompanyId,
            });

            if(response.status === 200){
              history.push('/');
            }
               
          }catch(error){
            console.exception(error);
          }
     }

     
     useEffect(() =>{

          const fetchCompanies =  async () =>{
               const response = await api.get('companies');
               setCompanies(response.data);
              
          }
          fetchCompanies();
     },[]) 
    

  
    return (
     <>
        <Container fluid>

            <Form onSubmit={handleSubmit(submit)} className="block">   

            
               <Form.Row>
               <Col md={4} />
                <Form.Group as={Col} md={4} controlId="Product.Name">
                  <Form.Label className="badge badge-dark"> Name </Form.Label>
                  <Form.Control type="text"
                   {...register("Name", {
                     required: true,
                    minLength: 5,
                    maxLength: 45
                    })}/>
                  <Form.Text className="text-muted"> insert product name </Form.Text>
                </Form.Group>
                <Col md={4} />
                </Form.Row>

               <Form.Row>
               <Col md={4} />
                <Form.Group as={Col} md={4} controlId="Product.Description">
                <Form.Label className="badge badge-dark"> Descritpion </Form.Label>
                  <Form.Control as="textArea" rows={4} placeholder="type one description of product max 1024 caracter" 
                        {...register("Description", {
                          required: true, 
                          minLength: 5,
                          maxLength: 1024,
                        })}
                        />
                  <Form.Text className="text-muted"> comment at least short descritpion about product </Form.Text>
                </Form.Group>
                <Col md={4} />
                </Form.Row>

              <Form.Row>
                <Col md={4} />
                <Form.Group as={Col} md={3} controlId="Product.Price">
                <Form.Label className="badge badge-dark"> Price </Form.Label>
                  <Form.Control type="number" 
                    {...register("Price",{
                      required: true,
                      max: 1000000,
                      min: 1
                    })}
                  defaultValue={0.0} required/>
                  <Form.Text className="text-muted"> product's cost </Form.Text>
                </Form.Group>
                <Col md={4} />
                </Form.Row>

                <Form.Row>
                <Col md={4} />
                <Form.Group as={Col} md={4} controlId="Product.Observation">
                <Form.Label className="badge badge-dark"> Observation </Form.Label>
                  <Form.Control as="textArea" placeholder="max 2048 caracteres" rows={6}
                    {...register("Observation", {
                      required: true,
                      minLength: 10,
                      maxLength: 2048
                    })}
                  />
                  <Form.Text className="text-muted"> comment at least short observation about product </Form.Text>
                </Form.Group>
                <Col md={4} />
                </Form.Row>
                  
                <Form.Row>
                <Col md={4} />
                    <Form.Group as={Col} controlId="Product.Image">
                       <Form.Label className="badge badge-primary"> Image Location (use link) </Form.Label>
                       <Form.Control  type="link" 
                          {...register("ImageUri", 
                          { required: true}
                         )}
                        />
                    </Form.Group>
                    <Col md={4} />
                </Form.Row>
               
                <Form.Row>
                <Col md={4} />
                  <Form.Group as={Col} md={2} controlId="Product.Company">
                  <Form.Label className="badge badge-dark"> Company </Form.Label>
                 <Form.Control as="select" 
                    {...register("CompanyId", {
                      required: true,
                      onChange: e => e.target.value
                    })}>
                      
                    { companies && companies.map(c => <option key={c.id} value={c.id}> {c.fantasyName} </option>)}
                 </Form.Control>
                 <Col md={4} />  
              </Form.Group>
                </Form.Row>
           
                <Form.Row>
                <Col md={4} />
                  <Form.Group as={Col} controlId="Button">
                  <Button className="btn-success" type="submit">Submit</Button>
                  </Form.Group>
                  <Col md={4} />
                </Form.Row>
             </Form>
          
        </Container>
     </>
    );
}

export default Product;