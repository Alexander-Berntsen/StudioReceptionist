import React, { Component } from 'react';

class SummaryComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      firstName: this.props.location.state.firstName,
      lastName: this.props.location.state.lastName,
      telephone: this.props.location.state.telephone,
      email: this.props.location.state.email,
      company: this.props.location.state.company,
      saveData: this.props.location.state.saveData,
      image: this.props.location.state.image
    };

    console.log(this.state);

    this.submitToBackend = this.submitToBackend.bind(this);
  }

  submitToBackend() {
    fetch('https://jsonplaceholder.typicode.com/posts', {
      method: 'POST',
      body: JSON.stringify(this.state),
      headers: {
        'Content-type': 'application/json; charset=UTF-8'
      }
    })
      .then(response => response.json())
      .catch(error => console.error('Error:', error))
      .then(response => {
        console.log('Success:', response);
        alert('Upload successful');
        this.navigateToGreetScreen();
      });
  }

  navigateToGreetScreen() {
    this.props.history.push({
      pathname: '/greet',
      state: {
        name: this.state.name,
        company: this.state.company,
        image: this.state.image
      }
    });
  }

  render() {
    return (
      <div>
        <div>Please, confirm</div>
        <div>First Name: {this.state.firstName}</div>
        <div>Last Name: {this.state.lastName}</div>
        <div>Telephone: {this.state.telephone}</div>
        <div>Email: {this.state.email}</div>
        <div>Company: {this.state.company}</div>
        <img src={this.state.image} style={styles.image} />
        <button onClick={this.submitToBackend} style={styles.submitButton}>
          Submit to backend
        </button>
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
  submitButton: {
    margin: 'auto',
    display: 'block'
  }
};

export default SummaryComponent;
