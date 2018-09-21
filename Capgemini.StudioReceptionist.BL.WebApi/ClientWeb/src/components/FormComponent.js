import React, { Component } from 'react';

class FormComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      firstName: '',
      lastName: '',
      telephone: '',
      email: '',
      company: '',
      saveData: false,
      image: this.props.location.state.image
    };

    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.navigateToSummary = this.navigateToSummary.bind(this);
    this.navigateToCamera = this.navigateToCamera.bind(this);
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
    if (this.state.firstName.length > 0 && this.state.company.length > 0) {
      fetch(location.protocol + '//' + location.host +'/api/ACS/RegisterRequest/AddPerson', {
        method: 'POST',
        body: JSON.stringify(this.state),
        headers: {
          'Content-type': 'application/json; charset=UTF-8'
        }
      })
        .then(response => response.json())
        .catch(error => console.error('Error:', error))
        .then(response => {
          const parsedJson = JSON.parse(response);
          const responseData = {
            personId: parsedJson.personId,
            image: this.state.image
          }
          fetch(location.protocol + '//' + location.host +'/api/ACS/RegisterRequest/AddFaceToPerson', {
            method: 'POST',
            body: JSON.stringify(responseData),
            headers: {
              'Content-type': 'application/json; charset=UTF-8'
            }
          })
            .then(response => response.json())
            .catch(error => console.error('Error:', error))
            .then(response => {
              if (response == true) {
                alert('Upload successful, please identify yourself in camera');
              } else {
                alert('Something went very wrong...');
              }
              this.navigateToCamera();
            });
        });
    } else {
      alert('Please, complete the form');
    }
    event.preventDefault();
  }

  navigateToCamera() {
    this.props.history.replace('/camera');
  }

  navigateToSummary() {
    this.props.history.push({
      pathname: '/summary',
      state: {
        firstName: this.state.firstName,
        lastName: this.state.lastName,
        telephone: this.state.telephone,
        email: this.state.email,
        company: this.state.company,
        saveData: this.state.saveData,
        image: this.props.location.state.image
      }
    });
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label>
          First Name:
          <input
            name="firstName"
            type="text"
            style={styles.inputField}
            value={this.state.value}
            onChange={this.handleInputChange}
          />
        </label>
        <label>
          Last Name:
          <input
            name="lastName"
            type="text"
            style={styles.inputField}
            value={this.state.value}
            onChange={this.handleInputChange}
          />
        </label>
        <label>
          Telephone:
          <input
            name="telephone"
            type="text"
            style={styles.inputField}
            value={this.state.value}
            onChange={this.handleInputChange}
          />
        </label>
        <label>
          E mail address:
          <input
            name="email"
            type="text"
            style={styles.inputField}
            value={this.state.value}
            onChange={this.handleInputChange}
          />
        </label>
        <label>
          Company:
          <input
            name="company"
            type="text"
            style={styles.inputField}
            value={this.state.value}
            onChange={this.handleInputChange}
          />
        </label>
        <label>
          Do you accept that we save your image for facial recognition?{' '}
          <input
            name="saveData"
            type="checkbox"
            value={this.state.value}
            onChange={this.handleInputChange}
          />{' '}
          Yes
        </label>
        <br />
        <br />
        <input type="submit" value="Submit" style={styles.submitButton} />
      </form>
    );
  }
}

const styles = {
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

export default FormComponent;
