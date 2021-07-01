import React, {useState, useEffect} from 'react';
import api from '../Services/api';

export const AuthContext = React.createContext({user: {name: ''}, 
                                                setUser: () => {}});

export const AuthProvider = (props) =>{

     const [user, setUser] = useState({name: ''});
     
     useEffect(() =>{

         const verifyLogin = async () =>{
          
            const userStorage = localStorage.getItem('@ecommercer:user');
          if(userStorage){
                let parse = JSON.parse(userStorage);
                const response = await api.get(`users/${parse.user.id}`);

                if(response.status === 200){
                    setUser({name: parse.user.email});
                }else{
                    setUser({name: 'Hello, Guest!'});
                }
          }else{
            setUser({name: 'Hello, Guest!'});
          }
        }

        verifyLogin();

     }, []);
     
    return(<>
         <AuthContext.Provider value={{user, setUser}}>
             {props.children}
         </AuthContext.Provider>
    </>);
}

export const useAuth = () => React.useContext(AuthContext);