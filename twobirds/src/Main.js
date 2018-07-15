import React, {Component} from 'react';
import { NavLink, Switch, Route } from 'react-router-dom';
import App from './App'
import Paient from './Patient';
const Main = () => (
      <Switch>
        <Route exact path='/' component={App}></Route>
        <Route exact path='/patient' component={Paient}></Route>                                      
      </Switch>
  );

  export default Main;