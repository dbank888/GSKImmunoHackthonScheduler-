import React, { Component } from 'react';
import './App.css';
import { Form } from 'reactstrap';
import $ from 'jquery';
import {
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  Button} from 'reactstrap';
import StickyFooter from 'react-sticky-footer';
import PatientInfo from './PatientInfo';

class Patient extends Component {
	constructor(){
		super();
		this.onSubmitBack = this.onSubmitBack.bind(this);
		this.onSubmit = this.onSubmit.bind(this);
    this.state={
      fname: "",
      lname: ""
    }
	}
	onSubmitBack(event){
	   event.preventDefault();
       this.props.history.push('/dashboard')
	}
	onSubmit(event){
      event.preventDefault();
      this.props.history.push('/scheduler')
       var settings = {
            "async": true,
            "crossDomain": true,
            "url": "http://gskhackathon.azurewebsites.net/api/schedule/resources?names=Jim,Mat",
            "method": "GET",
            "headers": {
                "Access-Control-Allow-Origin":"*",
                "Content-Type": "application/json",
                "Cache-Control": "no-cache"
            }
        };
        $.ajax(settings).done(function (response) {
            console.log(response);
        });     
	 }
	render(){
		return(
       <div className="backC">
        <Navbar style={styles.bdColor} light expand="md">
          <NavbarBrand href="/">Twobirds</NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
            <Nav className="ml-auto" navbar>
              <NavItem>
                <NavLink href="#">Welcome Back, Taylor Lee</NavLink>
              </NavItem>
              <NavItem>
                 <NavLink href="/">Sign Out</NavLink>
              </NavItem>
            </Nav>
        </Navbar>
        <PatientInfo />
        <StickyFooter
          bottomThreshold={50}
          normalStyles={{
          backgroundColor: "#50E3C2",
          padding: "1rem"
          }}
          stickyStyles={{
          backgroundColor: "rgba(255,255,255,.8)",
          padding: "2rem"
          }}
        >
        <Form onSubmit={this.onSubmitBack}>
         <Button outline className="backButton2" size="lg">Back</Button>
        </Form>
        <Form onSubmit={this.onSubmit}>
         <Button outline className="proceedButton" size="lg">Next</Button>
        </Form>
        </StickyFooter>
      </div>
	  );
	}
}

var styles = {
    bdColor: {
      backgroundColor: "#50E3C2"
    }
};


export default Patient;