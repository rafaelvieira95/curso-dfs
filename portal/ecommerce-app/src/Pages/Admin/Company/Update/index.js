import React, {useEffect, useState} from 'react';
import { useForm } from 'react-hook-form';
import { useParams ,useHistory} from 'react-router';
import { IMaskInput } from 'react-imask';
import { Form, Button, Container, Col} from 'react-bootstrap';
import api from '../../../../Services/api';

import './styles.css';

const CompanyUpdate = () => {

    const {id} = useParams();
    const history = useHistory();
  
    const { register, handleSubmit, setValue } = useForm();
    const [company, setCompany] = useState(null);

    useEffect(() =>{

        const fetchCompany = async () =>{

          const response = await api.get(`companies/${id}`);
          const obj = response.data;
          setValue("CorporateName",obj.corporateName);
          setValue("FantasyName", obj.fantasyName);
          setValue("Cnpj",obj.cnpj);
          setCompany(obj);
        }

        fetchCompany();

    }, [id, setValue]);

    
    const onSubmit = async data => {
            
      const {CorporateName, FantasyName, Cnpj} = data;
  
        const response = await api.put(`companies/${id}`,{
            CorporateName, FantasyName, Cnpj
        });

        if(response.status === 200){
           history.push('/company/list');
        }

  }

  return (

    <Container fluid>

          <Form className="form-position" onSubmit={handleSubmit(onSubmit)}>

           <Form.Row>
             <Col md={4}/>
            <Form.Group as={Col} controlId="Company.CorporateName">
              <Form.Label className="badge badge-dark"> Corporate Name </Form.Label>
              <Form.Control {...register("CorporateName", { required: true })} />
              <Form.Text className="text-muted">
                enter with name by company.
              </Form.Text>
            </Form.Group>
            <Col md={4}/>
            </Form.Row>

            <Form.Row>
            <Col md={4}/>
            <Form.Group as={Col} controlId="Company.FantasyName">
              <Form.Label className="badge badge-dark"> Fantasy Name </Form.Label>
              <Form.Control {...register("FantasyName", { required: true })} />
              <Form.Text className="text-muted">
                enter with name Fantasy.
              </Form.Text>
            </Form.Group>
            <Col md={4}/>
            </Form.Row>


            <Form.Row>
            <Col md={4}/>
            <Form.Group as={Col} controlId="Company.Cnpj">
              <Form.Label className="badge badge-danger"> Cnpj </Form.Label><br />
              <IMaskInput
                mask='00.000.000/0000-00'
                radix="."
                value={company?.cnpj}
                {...register("Cnpj", { required: true, maxlength: 14 })}
                unmask={true}
                onAccept={
                  (value) => { setValue("Cnpj", value) }
                }
              />
              <Form.Text className="text-muted"> Enter your Cnpj Here! </Form.Text>

            </Form.Group>
            <Col md={4}/>
            </Form.Row>

            <Form.Row>
            <Col md={4}/>
            <Form.Group as={Col} controlId="Button">
              <Button className="btn-success" type="submit"> Submit changes </Button>
            </Form.Group>
            <Col md={4}/>
            </Form.Row>

          </Form>
        
    </Container>

  );

}

export default CompanyUpdate;