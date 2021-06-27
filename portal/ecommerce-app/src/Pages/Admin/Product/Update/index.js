import React, {useEffect} from 'react';
import {Container, Col, Form, Button} from 'react-bootstrap';
import {useForm} from 'react-hook-form';
import { useHistory, useParams } from 'react-router';
import './styles.css';
import api from '../../../../Services/api';


const ProductUpdate = () =>{

     const {register, handleSubmit,setValue} = useForm();

     const {id} = useParams();
     const history = useHistory();
     
     const submit = async data =>{
             
            const {Name, Description, Price, Observation, CompanyId, ImageUri} = data;
           
           try{
           
            const response = await api.put(`products/${id}`,{
                Name, 
                Description, 
                Price, 
                Observation,
                ImageUri, 
                CompanyId,
            });

            if(response.status === 200){
                history.push('/product/list');
            }
               
          }catch(error){
              if(error.response.status === 401){
                  history.push('/signin');
              }
              if(error.response.status === 500){
               console.log(error);
              }
          }
     }

     
     useEffect(() =>{

          const fetchProduct = async () => {

              const response = await api.get(`products/${id}`);
              const obj = response.data;
           
              setValue("Name", obj.name);
              setValue("Description", obj.description);
              setValue("Price", obj.price);
              setValue("Observation", obj.observation);
              setValue("ImageUri", obj.imageUri);
              setValue("CompanyId", obj.companyId);
          }

          fetchProduct();
            
     },[id, setValue]);

    
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
                  <Form.Group as={Col} controlId="Button">
                  <Button className="btn-warning" type="submit">Submit changes</Button>
                  </Form.Group>
                  <Col md={4} />
                </Form.Row>
             </Form>
          
        </Container>
     </>
    );
}

export default ProductUpdate;