import React, { useState,useEffect, useRef } from 'react';
import { useParams, useHistory } from 'react-router';
import { Button, Form, Col, Alert, Row } from 'react-bootstrap';
import { useForm } from 'react-hook-form';
import { IMaskInput } from 'react-imask';
import api from '../../Services/api';
import './styles.css';


const UserUpdate = () => {

  const history = useHistory();
  const [user, setUser] = useState(null);
  const { register, watch, handleSubmit, setValue, formState: { errors } } = useForm({});
  
  const passwordRepeat = useRef({});
  passwordRepeat.current = watch("Password", "");

  const {id} = useParams();

  useEffect(() =>{

    const fetchUser = async() =>{

      const response = await api.get(`users/${id}`);
      
      const obj = response.data;
      setValue("Name", obj.name);
      setValue("Email", obj.email);
      setValue("Cpf", obj.cpf);
      setValue("Password", obj.password);
      setValue("ConfirmPassword", obj.password);
      setUser(response.data);
    }
      
      fetchUser();

  }, [id, setValue]);

  const goBack = () =>{ history.goBack(); }

  const submit = async (data) => {

     const {Name, Password, Cpf, Email} = data;
     
     try{
     const response = await api.put(`users/${id}`,{
        Name, Email, Cpf, Password
     });
      
      if(response.status === 200){
           localStorage.removeItem('@ecommerce:user');
           history.push('/signin');
      }
    }catch(error){
      console.log(error.response);
    }
         
  }

  return (
    <>
          <Form className="block" onSubmit={handleSubmit(submit)} >

            <Form.Row>
              <Col md={4} />
              <Form.Group as={Col} controlId="Name">
                <Form.Label className="badge badge-dark"> Name </Form.Label>
                <Form.Control type="text"  {...register("Name", { required: true })} />
              </Form.Group>
              <Col md={4} />
            </Form.Row>

  
            <Form.Row>
              <Col md={4} />
              <Form.Group as={Col} controlId="Email">
                <Form.Label className="badge badge-dark">Enter your E-mail</Form.Label>
                <Form.Control type="email"  {...register("Email", { required: true })} />
              </Form.Group>
              <Col md={4} />
            </Form.Row>

            <Form.Row>
                  <Col md={4}/>
                       <Form.Group as={Col} controlId="Cpf">
                          <Form.Label className="badge badge-dark">Enter your Cpf document</Form.Label> <br />
                            <IMaskInput
                                mask={"000.000.000-00"}
                                radix={"."}
                                value={user?.cpf}
                                disabled={true}
                                {...register("Cpf", { required: true, maxLength: 11, minLength: 11 })}
                                unmask={true}
                                onAccept={
                                    () => { setValue("Cpf", user?.cpf) }
                                }
                            /> <br />
                        <Col md={4}/>
                        </Form.Group>
                    </Form.Row>


            <Form.Row>
              <Col md={4} />
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
                    }
                  })} />
              </Form.Group>
              {errors.Password && <span style={{ color: 'red', fontWeight: 'bold' }}>{errors.Password.message}</span>}
              <Col md={4} />
            </Form.Row>

            <Form.Row>
              <Col md={4} />
              <Form.Group as={Col} controlId="ConfirmPassword">
                <Form.Label className="badge badge-dark">Confirm Password</Form.Label>
                <Form.Control type="password"   
                  aria-invalid={errors.ConfirmPassword ? "true" : "false"}   
                  {...register("ConfirmPassword", {
                    validate: value => value === passwordRepeat.current || "The passwords do not match"
                  })} />
              </Form.Group>
              {errors.ConfirmPassword && <span style={{ color: 'red', fontWeight: 'bold' }}>{errors.ConfirmPassword.message}</span>}
              <Col md={4} />
            </Form.Row>

            <Form.Row>
              <Col md={4} />
              <Form.Group as={Col} controlId="Update">
                    <Row> 
                      <Col xs={6}> <Button className="btn btn-warning" md={6} type="submit"> Save Changes </Button> </Col>
                      <Col xs={6}> <Button className="btn btn-info" md={6}   onClick={() => goBack()}> Go Back </Button> </Col>
                     </Row>
              </Form.Group>
                 
              <Col md={4} />
            </Form.Row>

            <Form.Row>
              <Col md={4} />
              {(errors.Password && errors.ConfirmPassword) &&
                <Alert as={Col} key={1} variant="danger">
                  Fields Required
                </Alert>
              }
              <Col md={4} />
            </Form.Row>
          </Form>
    </>
  )
}

export default UserUpdate;