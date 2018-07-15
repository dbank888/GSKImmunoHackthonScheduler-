import React, { Component } from 'react';
import './App.css';
import { Form } from 'reactstrap';
import FormCompoent from './Form';
import {
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  Card, CardImg, CardText, CardBody,
  CardTitle, CardSubtitle,
  Button} from 'reactstrap';
import StickyFooter from 'react-sticky-footer';

class PatientInfo extends Component {
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
		   <div className="customCards">
             <Card> 
             <CardBody>
             <CardTitle>Card title</CardTitle>
             <CardSubtitle>Card subtitle</CardSubtitle>
            </CardBody>
           </Card>
           <Card> 
             <CardBody>
             <CardTitle>Card title</CardTitle>
             <CardSubtitle>Card subtitle</CardSubtitle>
            </CardBody>
           </Card>
		   </div>
		  </div>	
		);
	}
}		

export default PatientInfo;