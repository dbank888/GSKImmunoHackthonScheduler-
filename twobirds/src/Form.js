import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import axios from 'axios';
import { NavLink } from 'react-router-dom';
class FormComponent extends Component{
   constructor(){
      super();
       this.state = {
         callersName:"Margaret-Ann_De_Luca",
         patientsName: "Jane_De_Luca",
         data: []
       };
   }
  onSubmit(event) {
    event.preventDefault();
    console.log("submit clicked");
    this.props.history.push('/patient')
    axios.post("http://gskhackathon.azurewebsites.net/api/schedule/recommend")
      .then(res => {
        console.log(res);
      });
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
        <Form>
         <h1 className="name">PATIENT INFORMATION</h1>
          <FormGroup>
            <Label for="Caller Name">Caller Name</Label>
            <Input type="text" name="cname" id="cName" placeholder="Caller's Name" value={this.state.callersName}/>
          </FormGroup>
           <FormGroup>
            <Label for="pName">Patient's Name</Label>
            <Input type="text" name="pname" id="pName" placeholder="Patient's Name" value={this.state.patientsName}/>
          </FormGroup>
          <FormGroup>
            <Label for="dateOfAppointment">Desired Date of Appointment</Label>
            <Input type="date" name="dop" id="dop" placeholder="mm/dd/yy" />
          </FormGroup>
          <FormGroup>
            <Label for="timeOfAppointment">Desired Time of Appointment</Label>
            <Input type="time" name="top" id="top" />
          </FormGroup>
         </Form>
       </div>
  	);
  }
}
export default FormComponent;