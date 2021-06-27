import React, { useEffect, useState, useRef } from 'react';
import { Button, Container, Form, Row, Col, Table } from 'react-bootstrap';
import { useHistory } from 'react-router';
import { useForm } from 'react-hook-form';
import { IMaskInput } from 'react-imask';
import format from 'number-format.js';

import api from '../../Services/api';

const Checkout = () => {

    const history = useHistory();
    const UserId = useRef({});
    const { register, handleSubmit, setValue, formState: { errors } } = useForm({});
    const [items, setItems] = useState([]);
    const [itemsDesc, setItemDesc] = useState([]);


    const handleGoBack = () => history.goBack();

    useEffect(() => {

        const loadItems = () => {

            let myCart = localStorage.getItem('@cart:user');
            var userStorage = localStorage.getItem('@ecommerce:user');

            if (myCart !== null && userStorage !== null) {

                let cartItems = JSON.parse(myCart);
                let user = JSON.parse(userStorage);
                setItemDesc(cartItems);
                
                var myItems = []
                cartItems.forEach(p => {
                
                     myItems.push({
                        ProductId: parseInt(p.id),
                        Quantity: parseInt(p.quantity)
                     });      
                });
                setItems(myItems);
                UserId.current = parseInt(user?.user.id);           
            }
        }

        loadItems();
    
    }, []);

    const onSubmit = async (data) => {

        const { Address, PostalCode, Observation, FormatOfPayment, StatusPurchase } = data;

        const Price = itemsDesc.reduce((acc, item) => item.price + acc, 0);
 
        const response = await api.post('purchases', {
            Address,
            PostalCode,
            Observation,
            FormatOfPayment,
            StatusPurchase,
            Price,
            Items: items,
            UserId: UserId.current
        });

        if (response.status === 200){
            localStorage.removeItem('@cart:user');
            history.push('/dashboard');
        }
     }


    return (
        <>
            <Container fluid={true}>
                <Row>
                    <Col xs={6}>
                        <Form onSubmit={handleSubmit(onSubmit)}>

                            <Form.Row>
                                <Form.Group as={Col} controlId="Address">
                                    <Form.Label for="Address" className="badge badge-dark">Address </Form.Label>
                                    <Form.Control type="text"
                                        placeholder="type your address"
                                        {...register("Address", {
                                            required: true,
                                            maxLength: 255,
                                            minLength: 5
                                        })} />
                                </Form.Group>
                            </Form.Row>

                            <Form.Row>
                                <Form.Group as={Col} controlId="ZipCode">
                                    <Form.Label className="badge badge-dark" > Zip Code </Form.Label> &nbsp;
                                    <IMaskInput
                                        mask="00000-000"
                                        radix="."
                                        unmask={true}
                                        {...register("PostalCode", {
                                            required: true,
                                            maxLength: {
                                                value: 8,
                                                message: 'zip code required 8 numbers'
                                            },
                                            minLength: {
                                                value: 8,
                                                message: 'zip code required 8 numbers'
                                            }
                                        })}
                                        onAccept={(value) => setValue("PostalCode", value)
                                        }
                                    />
                                    <p> {errors.PostalCode && <span style={{ color: 'red', fontWeight: 'bold' }}> {errors.PostalCode?.message} </span>} </p>
                                </Form.Group>
                            </Form.Row>

                            <Form.Row>
                                <Form.Group as={Col} controlId="Observation">
                                    <Form.Label className="badge badge-dark"> Observation </Form.Label>
                                    <Form.Control as="textarea" rows={4} placeholder="(optional) insert least one observation about your new purchase"
                                        {...register("Observation", {
                                            required: true,
                                            minLength: {
                                                value: 0
                                            }
                                        })}
                                    />
                                </Form.Group>
                            </Form.Row>

                            <Form.Row>
                                <Form.Group as={Col} controlId="FormatOfPayment">
                                    <Form.Label className="badge badge-dark">Format of Payment </Form.Label>
                                    <Form.Control as="select" {...register("FormatOfPayment", {
                                        required: true,
                                        value: "1",
                                        onChange: e => e.target.value
                                    })}>
                                        <option value="1" selected> Credit Card</option>
                                        <option value="2"> Debit Card</option>
                                        <option value="3"> Bank Billet</option>

                                    </Form.Control>
                                </Form.Group>
                            </Form.Row>

                            <Form.Row>
                                <Form.Group as={Col} controlId="StatusPurchase">
                                    <Form.Label className="badge badge-dark">Status of Purchase </Form.Label>
                                    <Form.Control as="select" {...register("StatusPurchase", {
                                        required: true,
                                        value: "1",
                                        onChange: e => e.target.value
                                    })}>
                                        <option value="1" selected> Open </option>
                                        <option value="2"> Paid </option>

                                    </Form.Control>
                                </Form.Group>
                            </Form.Row>


                            <Form.Row>
                                <Form.Group as={Col} controlId="btnSubmit" >
                                    <Button type="submit" sm={6}> Submit </Button>
                                </Form.Group>

                                <Form.Group as={Col} controlId="btnBack">
                                    <Button className="btn btn-warning" onClick={() => handleGoBack()}> Go Back </Button>
                                </Form.Group>

                              <Form.Group as={Col} controlId="Total"> 
                                  <Form.Label> Total $ (BRL) </Form.Label>
                                  </Form.Group>

                              <Form.Group>
                                 <Form.Label> 
                                       <p><strong>
                                          { format("#,##0.00",itemsDesc.reduce((acc, item) => item.price + acc, 0))} 
                                      </strong></p> 
                                 </Form.Label>
                              </Form.Group>

                            </Form.Row>
                        </Form>
                    </Col>

                    <Col xs={6}>

                        <Table responsive fluid hover>
                            <thead>
                                <tr>
                                    <th>Icon</th>
                                    <th>Product Name</th>
                                    <th>Price</th>
                                </tr>
                            </thead>

                            <tbody>
                                {itemsDesc && itemsDesc.map(product => (
                                    <tr key={product.id}>
                                        <td><img src={product.imageUri} alt="product" height={64} width={64}/></td>
                                        <td>{product.name}</td>
                                        <td> {format("#,##0.00", product.price)} </td>
                                    </tr>
                                ))}
                            </tbody>
                        </Table>


                    </Col>

                </Row>
            </Container>
        </>
    )
}

export default Checkout;