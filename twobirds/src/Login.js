import React, { Component } from 'react';
import './App.css';
import { Form } from 'reactstrap';
import LoginComponent from './LoginForm';
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
  onSubmit(event) {
    event.preventDefault();
    console.log("submit clicked");
    this.props.history.push('/dashboard')
  }
  render() {
    return (
      <div className="backC">
        <Navbar style={styles.bdColor} light expand="md">
          <NavbarBrand href="/">twobirds</NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
        </Navbar>
        <LoginComponent />
      </div>
    );
  }
}

var styles = {
    bdColor: {
      backgroundColor: "#50E3C2",
      color: "#FFFFFF"
    }
};

export default App;
