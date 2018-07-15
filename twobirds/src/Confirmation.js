import React, { Component } from 'react';
import './App.css';
import { Form } from 'reactstrap';
import calendar from'./confirmation.png';
import {
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  Button} from 'reactstrap';
import StickyFooter from 'react-sticky-footer';


class Confirmation extends Component {
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
       this.props.history.push('/patient')
  }
  onSubmit(event){

      event.preventDefault();  
       this.props.history.push('/confirmation')  
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
         <div className="form">
         <div
          style = {{
            marginTop: "10px",
            marginBottom: "10px",
            marginLeft: "200px",
            height: "500px",
            width: 3,
            backgroundColor: '#50E3C2'
           }}
          /> 
         </div>
        <img  src={calendar} style={{width:"72%", marginLeft: "27%", marginTop: "-44%"}} alt="twoBirds"/>
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
         <Button outline className="backButton3" size="lg">Back</Button>
        </Form>
        <Form onSubmit={this.onSubmit}>

         <Button outline className="submitButton2" size="lg">Submit</Button>
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


export default Confirmation;