import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Header from '../Components/Header/index';
import Footer from '../Components/Footer/index';

import SignUp from '../Pages/User/SignUp/index';
import {Home} from '../Pages/Home';
import SignIn from '../Pages/SignIn/index';
import Dashboard from '../Pages/User/DashBoard/index';
import UserUpdate from '../Components/UserUpdate';

import CompanyAdd from '../Pages/Admin/Company/Create/index';
import CompanyList from '../Pages/Admin/Company/List/index';
import CompanyUpdate from '../Pages/Admin/Company/Update/index';

import ProductAdd from '../Pages/Admin/Product/Create/index';
import ProductDetails from '../Components/ProductDetails';
import ProductList from '../Pages/Admin/Product/List/index';
import ProductUpdate from '../Pages/Admin/Product/Update/index';

import Checkout from '../Pages/Checkout';

const Routes = () => {
    return (
        <>
            <BrowserRouter>
               <Header />
                 <Switch>
                    <Route path={["/home", "/"]}  component={Home} exact />

                    <Route path="/company/add"  component={CompanyAdd} exact />
                    <Route path="/company/list" component={CompanyList}/>
                    <Route path="/company/edit/:id" component={CompanyUpdate}/>

                    <Route path="/product/add"  component={ProductAdd} exact />
                    <Route path="/product/details/:id"  component={ProductDetails} exact />
                    <Route path="/product/list" component={ProductList} exact />
                    <Route path="/product/edit/:id" component={ProductUpdate} exact />
                    
                    <Route path="/signin" component={SignIn} exact />
                    <Route path="/signup" component={SignUp} exact />
                    <Route path="/user/:id" component={UserUpdate} exact/>
                    <Route path="/dashboard" component={Dashboard} exact/>

                    <Route path="/purchases/checkout" component={Checkout} exact/>


                 </Switch>
                <Footer />
            </BrowserRouter>

        </>
    );
}
export default Routes;

