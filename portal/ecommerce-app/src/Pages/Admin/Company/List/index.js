import React, {useState, useEffect} from 'react';
import {Link} from 'react-router-dom';
import {Table, Button, Container} from 'react-bootstrap';
import './styles.css';

import api from '../../../../Services/api';

const CompanyList = () =>{

   const [companies, setCompanies] = useState([]);
   
    useEffect(() =>{
       const fetchCompanies = async ()=>{
           const response = await api.get('companies');
           setCompanies(response.data);
       }

       fetchCompanies();

    }, []);


    const handleDelete = async (company) =>{
         
        const isDelete = window.confirm('Do you really want to delete this company?');

        if(isDelete){
        const response = await api.delete(`companies/${company.id}`);
         
         if(response.status === 200){
              setCompanies(companies.filter(c => c.id !== company.id));
          }
        }
    }


    return (
        <>
        <Container className="table-box">
           <Table responsive hover>
            <thead>
                <tr>
                    <th>Fantasy Name</th>
                    <th>Cnpj</th>
                    <th>Total Products</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>

            <tbody>
                { companies && companies.map(company =>(
                <tr key={company.id}>
                  <td>{company.fantasyName}</td>
                  <td>{company.cnpj}</td>
                  <td>{company.products?.length}</td>
                  <td>  <Link to={`/company/edit/${company.id}`}> edit </Link> </td>
                  <td> <Button onClick={() => handleDelete(company)}> delete </Button> </td>
                </tr>
                ))}
             </tbody>
             </Table>
           </Container>
        </>
    )
}


export default CompanyList;