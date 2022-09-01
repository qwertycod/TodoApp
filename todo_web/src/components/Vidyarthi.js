import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Courses from './Courses'

class Vidyarthi extends Component {
    constructor(props) {
        super(props);
        this.state ={
            error : '',
            isLoading : true,
            student : {},
            name : '',
            year : ''
        }
    }
    componentDidMount() {
        fetch(this.props.apiRootUrl + "api/student/GetByUserId/" + this.props.id, 
         {headers : this.props.headers() }
        )
        .then(result=> result.json())
        .then(result => {
            console.log(result)
            if(!result.length && result.message){
                this.setState({
                    error : result.message ? result.message : 'network error',
                }) 
                 return;
             }
             var s = result[0];
            this.setState({
                isLoaded: true,
                name:s.name,
                year:s.year,
            });
        },
        (error) => {
            this.setState({
                isLoaded:true,
                error: error.message ? error.message : 'some error'
            });
        })
    }

    render() {
        const {name, year} = this.state
        if(this.state.error){
            return <div>Error  : {this.state.error}</div>
        }
        else if(!this.state.isLoaded){
            return <div>Loading ... </div>
        }
        else{
            return (
            <div>
                <div>
                    Welcome  {name}, {year} year student
                </div>
                <div>
                    Here, we offer you list of courses to select from :
                </div>
            </div>
            
         );
        }
    }
}

Vidyarthi.propTypes = {

};

export default Vidyarthi;