import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { NavLink } from 'react-router-dom';
class Loginform extends Component{
   constructor(){
      super();
       this.state = {
         callersName:"Margaret-Ann_De_Luca",
         patientsName: "Jane_De_Luca",
         data: []
       };
   }
   
  render(){
  	return(
       <div className="form">
       <div
          style = {{
          	marginTop: "10px",
          	marginBottom: "10px",
          	marginLeft: "250px",
            height: "500px",
            width: 3,
            backgroundColor: '#50E3C2'
          }}
        /> 
        <Form onSubmit={this.onSubmit}>
         <h1 className="name">TwoBirds Scheduler System</h1>
           <FormGroup>
          <Label for="exampleEmail">Email</Label>
          <Input type="email" name="email" id="exampleEmail" placeholder="with a placeholder" />
        </FormGroup>
        <FormGroup>
          <Label for="examplePassword">Password</Label>
          <Input type="password" name="password" id="examplePassword" placeholder="password placeholder" />
        </FormGroup>
         <NavLink to='/dashboard'>Login</NavLink>
         </Form>
       </div>
  	);
  }
}
export default Loginform;