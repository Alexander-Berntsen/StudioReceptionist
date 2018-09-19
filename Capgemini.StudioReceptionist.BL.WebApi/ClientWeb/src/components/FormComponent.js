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
      calleTestar: true
    };

    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.navigateToSummary = this.navigateToSummary.bind(this);
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
      this.navigateToSummary();
    } else {
      alert('Please, complete the form');
    }
    event.preventDefault();
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

  /*
      Database columns:
        ID (auto generated)
        First name
        Last name
        Telephone Number
        Company
        Meeting who
        Checked in
        Accept to save image (checkbox)
  */

  /*

    "FirstName": "Mats",
    "LastName": "Boberg",
    "MobileNumber": "0704868757",
    "Company": "Capgemini",
    "AllowSaveData": true,
    "CheckedIn": true,
    "CheckedInDateTime": "2018-09-03T17:00:00Z",
    "CheckedOutDateTime": "2018-09-03T07:00:00Z",
    "Host": "Microsoft.SharePoint.Client.FieldUserValue",
    "EmailAddress": "mats.boberg@capgemini.com"

  */

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
            name="phone"
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
