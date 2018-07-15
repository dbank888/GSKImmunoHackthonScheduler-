import React, { Component } from 'react';
import { Form, FormGroup, Label, Input} from 'reactstrap';
import { NavLink } from 'react-router-dom';
import logo from'./Logo.png';
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
       <img  src={logo} style={{width:"20%", height:"30%", marginLeft: "5%", marginTop: "5%"}} alt="twoBirds"/>
       <div
          style = {{
          	marginTop: "10px",
          	marginBottom: "10px",
          	marginLeft: "85px",
            height: "500px",
            width: 3,
            backgroundColor: '#50E3C2'
          }}
        /> 
        
        <Form onSubmit={this.onSubmit}>
         <h1 className="name">TwoBirds Scheduler System</h1>
          <FormGroup>
          <Label for="exampleEmail">Email</Label>
          <Input type="email" name="email" id="exampleEmail" placeholder="john@twobirds.com" />
        </FormGroup>
        <FormGroup>
          <Label for="examplePassword">Password</Label>
          <Input type="password" name="password" id="examplePassword" placeholder="pasword" />
        </FormGroup>
         <div style={{marginLeft:"10%"}}><NavLink to='/dashboard'>Login</NavLink></div>
         </Form>
       </div>
  	);
  }
}
export default Loginform;