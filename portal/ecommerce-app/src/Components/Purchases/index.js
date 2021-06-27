import React, {useState, useEffect} from 'react';
import {Table , Modal, Button} from 'react-bootstrap';
import format from 'number-format.js';
import api from '../../Services/api';

const ViewItems = ({id}) =>{
   
    const [items, setItems] = useState([]);    
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    useEffect(() => {

        const fetchItemsByPurchase = async() =>{
            const response  = await api.get(`items/${id}`);
            setItems(response.data);
        }
        fetchItemsByPurchase();

        return () => setItems([]);
    }, [id]);


return (
  <>
    <Button variant="primary" onClick={handleShow}>
      View
    </Button>

    <Modal show={show} size="lg" onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Show Items by purchase {`#${id}`}</Modal.Title>
      </Modal.Header>
      <Modal.Body> 
          <ul> 
              {items && items.map(item => (
                   <li style={{listStyle: 'none'}} key={item.id}>
                       <img src={item.product.imageUri} alt="product" height={45} width={45}/> 
                       <p><strong> {item.product.name}  - $ {format("#,##0.00",item.product.price)}  <span> X {item.quantity}</span> </strong></p> 
                    </li>)) }
          </ul>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
        </>
    );
}

const Purchases = ()=>{

    const [id, setId] = useState(null);
    const [purchases, setPurchases] = useState([]);


    const formatOfPayment = (option) =>{
      switch(option){
        case 1: 
             return 'Credit Card';
        case 2:
             return 'Debit Card';
        case 3: 
             return 'Bank Billet';

        default: return 'N/A';
      }
    }

const statusPurchase = (option) =>{
    switch(option){
      case 1:
        return 'Open';
      case 2:
        return 'Paid';

      default: return 'N/A';
    }
}

    useEffect(() =>{
        
         const userStorage = localStorage.getItem('@ecommerce:user');
         if(userStorage !== null){
             let userLogged = JSON.parse(userStorage);
             setId(parseInt(userLogged?.user.id));
         }

        const fetchPurchases = async () =>{
            if(id !== null){
            const response = await api.get(`users/${id}`);
            setPurchases(response.data.purchases);
            }
        }

        fetchPurchases();

        return () => {
             setId(null);
             setPurchases([]);
          }
    },[id]);  

    return (
        <> 
        <Table fluid responsive hover>
            <thead>
                <tr>
                    <th>Address</th>
                    <th>Postal Code</th>
                    <th>Date of Purchase</th>
                    <th>Format of Payment</th>
                    <th>Status Purchase</th>
                    <th>Price $ (BRL) </th>
                    <th>View Products</th>
                </tr>
            </thead>

            <tbody>
                { purchases && purchases.map(purchase =>(
                <tr key={purchase.id}>
                  <td>{purchase.address}</td>
                  <td> {purchase.postalCode}</td>
                  <td>{new Date(purchase.date).toLocaleDateString("pt-BR")}</td>
                  <td>{formatOfPayment(purchase.formatOfPayment)}</td>
                  <td>{statusPurchase(purchase.statusPurchase)}</td>
                  <td> {format("#,##0.00",purchase.price)}</td>
                  <td> <ViewItems id={purchase.id} /> </td>
                </tr>
                ))}
            </tbody>
           </Table>
          
        </>
    );
}

export default Purchases;