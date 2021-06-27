import React from 'react';
import { Container, Row, Col, Tab, Nav } from 'react-bootstrap';

import Cart from '../../../Components/Cart/index';
import User from '../../../Components/UserInfo/index';
import Purchases from '../../../Components/Purchases/index';

import './styles.css';

const Dashboard = () => {
  return (
    <>
      <Container fluid style={{ marginTop: 10 }}>
        <Tab.Container id="left-tabs-example" defaultActiveKey="first">
          <Row>
            <Col md={2}>
              <Nav variant="pills" className="flex-column">
                <Nav.Item>
                  <Nav.Link eventKey="first">Items</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                  <Nav.Link eventKey="second">Purchases</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                  <Nav.Link eventKey="third">User info</Nav.Link>
                </Nav.Item>
              </Nav>
            </Col>

            <Col>
              <Tab.Content>

                <Tab.Pane  eventKey="first">
                  <Cart key={1}/>
                </Tab.Pane>

                <Tab.Pane eventKey="second">
                    <Purchases key={1}/>
                </Tab.Pane>

                <Tab.Pane eventKey="third">
                  <User key={1}/>
                </Tab.Pane>

              </Tab.Content>
            </Col>
          </Row>
        </Tab.Container>
      </Container>

    </>)
}

export default Dashboard;