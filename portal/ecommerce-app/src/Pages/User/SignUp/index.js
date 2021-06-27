import React, {useRef} from 'react';
import { useForm } from 'react-hook-form';
import {useHistory} from 'react-router';
import { Container, Form, Col, Alert, Button } from 'react-bootstrap';
import { IMaskInput } from 'react-imask';
import api from '../../../Services/api';
import './styles.css';

const SignUp = () => {

    const { register, handleSubmit, watch, setValue, formState: { errors } } = useForm();
    const history = useHistory();
    const password = useRef({});
    password.current = watch("Password", "");

    const submit =  async (data) => {
       
         const {Name, Cpf, Password, Email} = data;
         const response = await api.post('users',{
              Name, Email, Cpf, Password
         });

         if(response.status === 200)
              history.push('/signin');
        
    }

    return (
        <>
            <Container fluid>
                <Form className="block" onSubmit={handleSubmit(submit)} >

                    <Form.Row>
                        <Col md={4}/>
                        <Form.Group as={Col} controlId="Name">
                            <Form.Label className="badge badge-dark"> Name </Form.Label>
                            <Form.Control type="text" {...register("Name", { required: true })} />
                        </Form.Group>
                        <Col md={4}/>
                    </Form.Row>

                    <Form.Row>
                        <Col md={4}/>
                        <Form.Group as={Col} controlId="Cpf">
                            <Form.Label className="badge badge-dark">Enter your Cpf document</Form.Label> <br />
                            <IMaskInput
                                mask={"000.000.000-00"}
                                radix={"."}
                                {...register("Cpf", { required: true, maxLength: 11, minLength: 11 })}
                                unmask={true}
                                onAccept={
                                    (value) => { setValue("Cpf", value) }
                                }
                            /> <br />
                        <Col md={4}/>
                        </Form.Group>
                    </Form.Row>

                    <Form.Row>
                        <Col md={4}/>
                        <Form.Group as={Col} controlId="Email">
                            <Form.Label className="badge badge-dark">Enter your E-mail</Form.Label>
                            <Form.Control type="email" {...register("Email", { required: true })} />
                        </Form.Group>
                        <Col md={4}/>
                    </Form.Row>

                    <Form.Row>
                        <Col md={4}/>
                        <Form.Group as={Col} controlId="Password">
                            <Form.Label className="badge badge-dark"> Password</Form.Label>
                            <Form.Control type="password" 
                             aria-invalid={errors.Password ? "true" : "false"}
                               {...register("Password", { 
                                   required: true,
                                   maxLength: 16,
                                   minLength: {
                                        value: 8,
                                        message: "Password must have at least 8 characters"       
                                   } })} />
                        </Form.Group>
                        {errors.password && <span style={{color: 'red', fontWeight: 'bold'}}>{errors.password.message}</span>}
                        <Col md={4}/>
                    </Form.Row>
                    
                    <Form.Row>
                        <Col md={4}/>
                        <Form.Group as={Col} controlId="ConfirmPassword">
                            <Form.Label className="badge badge-dark">Confirm Password</Form.Label>
                            <Form.Control type="password" 
                               aria-invalid={errors.ConfirmPassword ? "true" : "false"}
                               {...register("ConfirmPassword", { 
                                validate: value => value === password.current || "The passwords do not match"
                            }) } />
                            </Form.Group>
                            {errors.ConfirmPassword && <span style={{color: 'red', fontWeight: 'bold'}}>{errors.ConfirmPassword.message}</span>}
                        <Col md={4}/>
                    </Form.Row>
                      
                
                    <Form.Row>
                        <Col md={4}/>
                        <Form.Group as={Col} controlId="SignUp">
                            <Button className="btn btn-success" type="submit"> Sign Up </Button>
                            
                        </Form.Group>
                        <Col md={4}/>
                    </Form.Row>

                    <Form.Row>
                        <Col md={4}/>
                            {(errors.Password && errors.ConfirmPassword) &&
                             <Alert as={Col} key={1} variant="danger">
                               Fields Required
                             </Alert>
                             }
                        <Col md={4}/>
                    </Form.Row>
                </Form>

            </Container>
        </>
    );
}

export default SignUp;