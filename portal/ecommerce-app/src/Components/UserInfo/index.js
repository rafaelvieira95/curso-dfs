import React, {useState, useEffect} from 'react';
import { useHistory } from 'react-router';
import { InputGroup, FormControl, Container, Row, Col } from 'react-bootstrap';
import { IMaskInput } from 'react-imask';
import {Link} from 'react-router-dom';
import api  from '../../Services/api';

const UserInfo = () => {

    const history = useHistory();
    const [user, setUser] = useState(null);

    useEffect(() => {

          const fetchAuthUser = async ()=>{

              try{
     
                let storage = localStorage.getItem('@ecommerce:user');
                if(storage === null)
                    history.push('/signin');

                let result = JSON.parse(storage);
                const response = await api.get(`/users/${result?.user.id}`);
                setUser(response.data);

              }catch(err){

                  if(err.response?.status === 401){
                      history.push('/signin');
                  }
              }         
          }

          fetchAuthUser();
        
        return () => setUser(null);

       },[history]);

    return (
        <>
            <Container fluid>
                <Row>   
                <InputGroup as={Col} md={6} className="mb-3">
                    <InputGroup.Prepend>
                        <InputGroup.Text id="basic-addon1"> User Name</InputGroup.Text>
                    </InputGroup.Prepend>
                    <FormControl
                        placeholder="Username"
                        aria-label="Username"
                        value={user?.name}
                        readonly
                        aria-describedby="basic-addon1"
                    />
                </InputGroup>
                </Row>

                <Row>
                   <InputGroup as={Col} md={6} className="mb-3">
                      <InputGroup.Append>
                         <InputGroup.Text id="basic-addon2">E-mail</InputGroup.Text>
                      </InputGroup.Append>

                    <FormControl
                        value={user?.email}
                        readonly
                        placeholder="Recipient's email"
                        aria-label="Recipient's email"
                        aria-describedby="basic-addon2"
                    />
        
                 </InputGroup>
                </Row>

                <Row>
                <InputGroup as={Col} md={6} className="mb-3">
                    <InputGroup.Prepend>
                        <InputGroup.Text id="basic-addon3">
                           CPF
                        </InputGroup.Text>
                    </InputGroup.Prepend>
                    <IMaskInput 
                      id="basic-url"
                      mask="000.000.000-00"
                     disabled 
                     value={user?.cpf} 
                     aria-describedby="basic-addon3"
                     />
                   
                </InputGroup>
                </Row>

                <Row>
                    <Col md={6}> <Link to={`/user/${user?.id}`}> update user data</Link> </Col>
                </Row>
             </Container>  
        </>
    )
}

export default UserInfo;