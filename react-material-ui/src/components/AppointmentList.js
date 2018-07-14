import React, { Component } from 'react'
import Grid from '@material-ui/core/Grid';
import TextField from '@material-ui/core/TextField';
import * as contentful from 'contentful'
import Appointment from './Appointment'
const SPACE_ID = 'is8nytj119z9'
const ACCESS_TOKEN = '4e926752ded0ebf399e0ab22f86f247c55a529a16fad8424e8e00734534f8f9c'
const client = contentful.createClient({
    space: SPACE_ID,
    accessToken: ACCESS_TOKEN
})
class AppointmentList extends Component {
    state = {
        courses: [],
        searchString: ''
    }
    constructor() {
        super()
        this.getAppointments()
    }
    getAppointments = () => {
        client.getEntries({
            content_type: 'course',
            query: this.state.searchString
        })
        .then((response) => {
            this.setState({courses: response.items})
            console.log(this.state.courses)
        })
        .catch((error) => {
          console.log("Error occurred while fetching Entries")
          console.error(error)
        })
    }
    onSearchInputChange = (event) => {
        console.log("Search changed ..." + event.target.value)
        if (event.target.value) {
            this.setState({searchString: event.target.value})
        } else {
            this.setState({searchString: ''})
        }
        this.getAppointments()
    }
    render() {
        return (
            <div>
                { this.state.courses ? (
                    <div>
                        <TextField style={{padding: 24}}
                            id="searchInput"
                            placeholder="Search for Apointments"   
                            margin="normal"
                            onChange={this.onSearchInputChange}
                            />
                        <Grid container spacing={24} style={{padding: 24}}>
                            { this.state.courses.map(currentCourse => (
                                <Grid item xs={12} sm={6} lg={4} xl={3}>
                                    <Appointment course={currentCourse} />
                                </Grid>
                            ))}
                        </Grid>
                    </div>
                ) : "No courses found" }
            </div>
        )
    }
}
export default AppointmentList;