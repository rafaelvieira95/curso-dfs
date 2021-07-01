import React,{useRef, useEffect} from 'react';
import { Form, Button, Col, Image, Container, Alert } from 'react-bootstrap';
import { Link, useHistory } from 'react-router-dom';
import logo from '../../_img/ms-icon-150x150.png';
import './styles.css';
import  {useForm}  from 'react-hook-form';
import api from '../../Services/api';
import {useAuth} from '../../Providers/auth';

const SignIn = () => {

    const history = useHistory();

    const {setUser} = useAuth();

    const { register, handleSubmit, watch} = useForm();
     const password = useRef({});
     password.current = watch("Password", "");
    
    useEffect(()=>{
    
         const validateToken = async () =>{

            let userLogged = localStorage.getItem("@ecommerce:user");

            if(userLogged === null)
            {
               history.push('/signin');   
            }else{
                let result = JSON.parse(userLogged);

                const response = await api.get(`users/${result.user.id}`);

                if(response.status === 401){
                    history.push('/signin');
                }
                if(response.status === 200){
                    history.push('/dashboard');
                }
            }
         }
      validateToken();
         
    },[history]);
    

    const submit = async data => {
        
         const {Email, Password, StayLogged} = data;
      
         const response = await api.post('auth',{
             Email, Password
         });
          
         if(response.status === 200){
              localStorage.removeItem('@ecommerce:user');
              
        if(StayLogged){
                localStorage.setItem("@ecommerce:user", JSON.stringify(response.data.result));
        }
                setUser({name: response.data.result.user.email});
                history.push('/dashboard');
         }   
    }
    
    
    return (

        <Container fluid>

            <Form onSubmit={handleSubmit(submit)}>
                <Form.Row>
                    <Col sm={5} md={5} />
                    <Form.Group controlId="imageLogo">
                        <Image as={Col} className="img-fluid login-logo" src={logo} roundedCircle />
                    </Form.Group>
                    <Col sm={5} md={5} />
                </Form.Row>

                <Form.Row>
                    <Col sm={3} md={3} />
                    <Form.Group as={Col} controlId="formBasicEmail">
                        <Form.Label className="badge badge-dark">Email address</Form.Label>
                        <Form.Control type="email"
                            {...register("Email",
                                { required: true,
                                 maxlength: 45 })}
                            placeholder="Enter your e-mail" />
                        <Form.Text className="text-muted">
                            We'll never share your email with anyone else.
                        </Form.Text>
                    </Form.Group>
                    <Col sm={3} md={3} />
                </Form.Row>

                <Form.Row>
                    <Col sm={3} md={3} />
                    <Form.Group as={Col} controlId="formBasicPassword">
                        <Form.Label className="badge badge-dark">Password</Form.Label>
                        <Form.Control type="password"
                            {...register("Password",
                                { required: true ,
                                 minLength: 8 ,
                                 maxLength: 16  
                                }
                                )}
                            placeholder="Enter your password" />

                        <Form.Text className="text-danger">
                          {password.current.length < 8? 'the password required at least 8 characters': ''}
                          {password.current.length > 16? 'the password required maximum 16 characters': ''} 
                        </Form.Text>
                    </Form.Group>
                
                    <Col sm={3} md={3} />
                </Form.Row>

    
                <Form.Row>
                    <Col sm={3} md={3} />
                    <Form.Group as={Col} controlId="formBasicCheckbox">
                        <Form.Check type="checkbox" 
                            defaultChecked={false}
                          {...register("StayLogged", {required: false})}

                        label="Stay logged" />
                        <Alert as={Col} key={1} variant="primary">
                            New here? create your account now
                            <Link to="/signup"> Sign up </Link>
                        </Alert>
                    </Form.Group>
                    <Col sm={3} md={3} />
                </Form.Row>

                <Form.Row>
                <Col sm={3} md={3} />
                     <Form.Group as={Col} controlId="buttonSubmit">
                        <Button  variant="primary" type="submit">
                            Logon
                        </Button>
                    </Form.Group>
                    <Col sm={3} md={3} />
                </Form.Row>

            </Form>

        </Container>
    );
}

export default SignIn;