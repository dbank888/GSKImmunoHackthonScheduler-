import React, { Component } from 'react';
import './App.css';
import Form from './Form';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  Button,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem } from 'reactstrap';
import StickyFooter from 'react-sticky-footer';

class App extends Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render() {
    return (
      <div className="backC">
        <Navbar style={styles.bdColor} light expand="md">
          <NavbarBrand href="/">Twobirds</NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
            <Nav className="ml-auto" navbar>
              <NavItem>
                <NavLink href="#">Welcome Back, Taylor Lee</NavLink>
              </NavItem>
              <NavItem>
                <NavLink href="#">Sign Out</NavLink>
              </NavItem>
            </Nav>
        </Navbar>
        <Form />
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
       <Button outline className="submitButton" size="lg">Submit</Button>
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

export default App;
