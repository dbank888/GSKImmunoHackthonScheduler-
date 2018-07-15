import React, { Component } from 'react';

class Form extends Component{
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
         <h1 className="name">PATIENT INFORMATION</h1>
       </div>
  	);
  }
}
export default Form;