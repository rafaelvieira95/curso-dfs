import React from 'react';
import { useHistory } from 'react-router';
import { Nav, Navbar, NavDropdown, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import {useAuth} from '../../Providers/auth';

const Header = () => {

   const history = useHistory();
    const {user, setUser} = useAuth();

   const handleLogout = () => {
      localStorage.removeItem('@ecommerce:user');
      setUser({name: 'Hello, Guest!'});
      history.push('/');
   }

   const handleMyPurchases = () => history.push('/dashboard');

   const handleMyCart = () => history.push('/dashboard');

   return (
      <>

         <Navbar expand="lg" variant="dark" bg="dark">
            <Navbar.Brand>  <Link className="navbar" to="/home">  Ecommerce  </Link> </Navbar.Brand>
            <Nav className="mr-auto">

               <Nav.Item>
                  <Nav.Link>
                     <Link className="navbar" to="/home">  Home  </Link>
                  </Nav.Link>
               </Nav.Item>

               <Nav.Item>
                  <Nav.Link>
                     <Link className="navbar" to="/dashboard"> Dashboard </Link>
                  </Nav.Link>
               </Nav.Item>

               <Link style={{marginLeft: 500}} className="navbar" to="/signin"> <Button> Sign In </Button> </Link>

               <NavDropdown className="navbar" title={user.name} id="collasible-nav-dropdown">
                  <NavDropdown.Item onClick={handleLogout}> Logout</NavDropdown.Item>
                  <NavDropdown.Divider />
                  <NavDropdown.Item onClick={handleMyPurchases}>My Purchases</NavDropdown.Item>
                  <NavDropdown.Item onClick={handleMyCart}>My Cart</NavDropdown.Item>
               </NavDropdown>
            </Nav>

         </Navbar>

      </>
   );
}

export default Header;
