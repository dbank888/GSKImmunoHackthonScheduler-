import React, { Component } from 'react';
import './App.css';
import patient1 from'./patient1.png';
import patient2 from'./patient2.png';
import patient3 from'./patient3.png';
import axios from 'axios';

import {
  Card, 
  CardImg,
  CardBody,
  CardTitle,
  InputGroup,
  InputGroupAddon, 
  InputGroupText, 
  Input } from 'reactstrap';

class PatientInfo extends Component {
	constructor(){
		super();
		this.state={
			data: []
		}
	}
	componentDidMount() {
		console.log("Component Did mount Called");
		var data = {
          "CallerName": "Margaret-Ann_De_Luca",
          "PatientName": "Jane_De_Luca"
        }
        var headers = {
            'Content-Type': 'application/json'
        }
        axios.get('http://gskhackathon.azurewebsites.net/api/schedule/recommend', data, headers)
          .then(res => {
            console.log("Component Did mount Called");
         }); 
     }
	render(){
	   return(
		 <div className="form">
         <div
          style = {{
          	marginTop: "10px",
          	marginBottom: "10px",
          	marginLeft: "200px",
            height: "1100px",
            width: 3,
            backgroundColor: '#50E3C2'
           }}
         /> 
         <div className="customCard2">
           <h3 style={{marginTop: "5%", marginBottom: "3%", textAlign: "center", color: "#50E3C2", textDecoration: "underline"}}>Records Found</h3>
		  <div className="customCards">
             <Card>
              <CardImg top width="100%" src={patient1} alt="Card image cap" /> 
             </Card>
            <Card>
              <CardBody>
               <CardTitle>Vaccinations</CardTitle>
                <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                </InputGroupAddon>
               <Input placeholder="HPV" />
              </InputGroup> 
               <br />
              <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                 </InputGroupAddon>
                 <Input placeholder="Pneumococcal Infection" />
              </InputGroup> 
                <br />
              <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                 </InputGroupAddon>
                 <Input placeholder="Hepatitis B" />
              </InputGroup>  
             </CardBody>
            </Card>
		   </div>
           <h3 style={{marginTop: "6%",marginBottom: "3%", textAlign: "center", color: "#50E3C2", textDecoration: "underline"}}>Family Tree</h3>
		    <div className="customCards">
             <Card>
              <CardImg top width="100%" src={patient2} alt="Card image cap" /> 
             </Card>
            <Card>
              <CardBody>
               <CardTitle>Vaccinations</CardTitle>
                <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                </InputGroupAddon>
               <Input placeholder="HPV" />
              </InputGroup> 
               <br />
              <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                 </InputGroupAddon>
                 <Input placeholder="Pneumococcal Infection" />
              </InputGroup> 
                <br />
              <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                 </InputGroupAddon>
                 <Input placeholder="Hepatitis B" />
              </InputGroup>  
             </CardBody>
            </Card>
		   </div>
          <div className="customCards">
             <Card>
              <CardImg top width="100%" src={patient3} alt="Card image cap" /> 
             </Card>
            <Card>
              <CardBody>
               <CardTitle>Vaccinations</CardTitle>
                <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                </InputGroupAddon>
               <Input placeholder="HPV" />
              </InputGroup> 
               <br />
              <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                 </InputGroupAddon>
                 <Input placeholder="Pneumococcal Infection" />
              </InputGroup> 
                <br />
              <InputGroup>
                 <InputGroupAddon addonType="prepend">
                 <InputGroupText>
                 <Input addon type="checkbox" aria-label="Checkbox for following text input" />
                 </InputGroupText>
                 </InputGroupAddon>
                 <Input placeholder="Hepatitis B" />
              </InputGroup>  
             </CardBody>
            </Card>
		   </div>
		  </div>
		  </div>	
		);
	}
}		

export default PatientInfo;