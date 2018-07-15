import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';

export default class App extends Component {

    constructor(props, context) {
        super(props, context);

        this.state = { description: '' };
    }

    // onChange(e) {
    //     this.setState({
    //         [e.target.name]: e.target.value
    //     });
    // }

    onSubmit(e) {

        var request = new XMLHttpRequest();
        request.open('POST', '/my/url', true);
        request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        var data = {
          "CallerName": "Margaret-Ann_De_Luca",
          "PatientName": "Jane_De_Luca",
          "ApointmentTime": "2018-08-06Z09:00:00"
        }

        request.send(data);


        // e.preventDefault();

        // fetch(this.props.formAction, {
        //     headers: {
        //         'Accept': 'application/json',
        //         'Content-Type': 'application/json'
        //     },
        //     body: JSON.stringify({description: this.state.description})
        // });

        // this.setState({description: ''});
    }

    // Testing input:
    // {
    //   "CallerName": "Margaret-Ann_De_Luca",
    //   "PatientName": "Jane_De_Luca",
    //   "ApointmentTime": "2018-08-06Z09:00:00"
    // }

    render() {
        return (
            <div className="App">
                <form
                    id="main-login"
                    action={this.props.action}
                    method={this.props.method}
                    onSubmit={this.onSubmit}>
                    <h2>API Tester for twoBirds (** Hard Coded, pls look into the source) </h2>

                    <label>
                        <span class="text">CallerName:</span>
                        <input type="text" name="CallerName" value="Margaret-Ann_De_Luca"></input><br/>
                    </label>
                    <br/>
                    <label>
                        <span class="text">PatientName:</span>
                        <input type="text" name="PatientName" value="Jane_De_Luca"></input><br/>
                    </label>
                    <label>
                        <span class="text">ApointmentTime:</span>
                        <input type="text" name="ApointmentTime" value="018-08-06Z09:00:00"></input><br/>
                    </label>


                    <br/>
                    <div class="align-right">
                        <button>Submit</button>
                    </div>
                </form>
            </div>
        );
    }

}

// App.propTypes = { action: React.PropTypes.string.isRequired, method: React.PropTypes.string}
App.defaultProps = {
    action: 'http://gskhackathon.azurewebsites.net/api/schedule/recommend',
    method: 'post'
};

