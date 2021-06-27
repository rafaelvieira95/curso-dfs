import React from 'react';
import { Row, Col, Media, Image, Button } from 'react-bootstrap';
import format from 'number-format.js';
import './styles.css';

const CartItem = ({ id, imageUri, name, description, price, quantity, cart }) => {

    const removeItemFromCart = () =>{
        const id_ = parseInt(id);
        localStorage.setItem('@cart:user', JSON.stringify(cart.filter(item => parseInt(item.id) !== id_)));  
    }

    return (
        <>
            <Media className="mediaItem">
                <Image
                    width={130}
                    height={100}
                    className="align-self-center mr-3"
                    src={imageUri}
                    alt={"product cart"}
                />

                <Media.Body className="mediaBody">
                    <h3>{name}</h3>
                    <p>{description}</p>
                    <Row>
                        <Col xs={2}> <strong>$ {format("#,##0.00",price)}</strong> </Col>
                        <Col xs={2}> {quantity} piece</Col>
                    </Row>

                    <Row className="mediaItemButtons">
                        <Col>
                            <Button variant="danger" size="sm" onClick={removeItemFromCart}> Delete </Button>
                        </Col>
                    </Row>
                </Media.Body>
            </Media>
        </>
    )
}

export default CartItem;