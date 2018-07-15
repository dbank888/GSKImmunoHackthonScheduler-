import React from 'react';
import { Switch, Route } from 'react-router-dom';
import App from './App'
import Paient from './Patient';
import Login from './Login';
import Scheduler from './Scheduler';

const Main = () => (
      <Switch>
        <Route exact path='/' component={Login}></Route>
        <Route exact path='/dashboard' component={App}></Route>
        <Route exact path='/patient' component={Paient}></Route> 
        <Route exact path='/scheduler' component={Scheduler}></Route>                                     
      </Switch>
  );

  export default Main;