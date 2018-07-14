import React, { Component } from 'react';
import './App.css';
import NavBar from './components/NavBar'
import AppointmentList from './components/AppointmentList'

class App extends Component {
  render() {
    return (
      <div>
        <NavBar />
        <AppointmentList />
      </div>
    );
  }
}

export default App;
