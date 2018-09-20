import React, { Component } from 'react';

class GreetComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      firstName: this.props.location.state.firstName,
      lastName: this.props.location.state.lastName,
      company: this.props.location.state.company,
      email: this.props.location.state.email,
      personToVisit: ''
    };

    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.navigateToCamera = this.navigateToCamera.bind(this);
  }

  navigateToCamera() {
    this.props.history.replace('/camera');
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    var partialState = {};
    partialState[name] = value;
    this.setState(partialState);
  }

  handleSubmit(event) {
    if (this.state.personToVisit.length <= 0){
      alert("Please tell me who you're going to visit");
    } else {
      fetch('http://localhost:62064/api/ACS/CheckIn', {
        method: 'POST',
        body: JSON.stringify(this.state),
        headers: {
          'Content-type': 'application/json; charset=UTF-8'
        }
      })
        .then(response => response.json())
        .catch(error => console.error('Error:', error))
        .then(response => {
          alert('Check in successful');
          this.navigateToCamera();
        });
    }
    event.preventDefault();
  }

  render() {
    return (
      <div>
        <h1 style={styles.text}>
          Welcome {this.state.firstName} from {this.state.company}
        </h1>
        <form onSubmit={this.handleSubmit}>
          <label>
            Who are you going to visit?
            <input
              name="personToVisit"
              type="text"
              style={styles.inputField}
              onChange={this.handleInputChange}
            />
          </label>
          <br />
          <br />
          <input type="submit" value="Check in" style={styles.submitButton} />
        </form>
      </div>
    );
  }
}

const styles = {
  image: {
    width: '50%',
    height: '50%',
    margin: '8px 0'
  },
  text: {
    margin: 'auto',
    display: 'block'
  },
  inputField: {
    width: '100%',
    padding: '12px 20px',
    margin: '8px 0',
    boxSizing: 'border-box'
  },
  submitButton: {
    width: '40%',
    height: '50px',
    color: '#ffffff',
    backgroundColor: '#1674AD',
    borderRadius: '5px',
    float: 'right'
  }
};

export default GreetComponent;
