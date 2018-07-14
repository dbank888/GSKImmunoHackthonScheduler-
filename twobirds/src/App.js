import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem } from 'reactstrap';

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
      <div>
        <Navbar style={styles.bdColor} light expand="md">
          <NavbarBrand href="/">Twobirds</NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
            <Nav className="ml-auto" navbar>
              <NavItem>
                <NavLink href="/components/">Welcome Back, Taylor Lee</NavLink>
              </NavItem>
              <NavItem>
                <NavLink href="https://github.com/reactstrap/reactstrap">Sign Out</NavLink>
              </NavItem>
            </Nav>
        </Navbar>
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
