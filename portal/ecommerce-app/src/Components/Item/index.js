import React from 'react';
import { Card } from 'react-bootstrap';
import {Link} from 'react-router-dom';

const Item = (props) => {

  const { id, name, description, price, imageUri } = props.product;

  return (
    <>
      <Card key={id} style={{ width: '20rem', marginLeft: 34, marginTop: 15, padding: 10 }}>
      <Link to={`product/details/${id}`}>
          <Card.Img height={180} width={200} src={imageUri} />
        </Link>
        <Card.Header>
          <Card.Title>{name}</Card.Title>
          <Card.Subtitle> <strong>R$ {price} </strong> </Card.Subtitle>
        </Card.Header>
        <Card.Body>
          <Card.Text> {description} </Card.Text>
        </Card.Body>
      </Card>
    </>
  )
}

export default Item;
