import React, { Component } from 'react';

class CheckOutComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: this.props.location.state.email
    };

    this.checkOut = this.checkOut.bind(this);
    this.navigateToCamera = this.navigateToCamera.bind(this);
  }

  navigateToCamera() {
    this.props.history.replace('/camera');
  }

  checkOut() {
    fetch('http://localhost:62064/api/ACS/CheckOut', {
      method: 'POST',
      body: JSON.stringify(this.state),
      headers: {
        'Content-type': 'application/json; charset=UTF-8'
      }
    })
      .then(response => response.json())
      .catch(error => console.error('Error:', error))
      .then(response => {
        alert('Checkout successful');
        this.navigateToCamera();
      });
  }

  navigateToCamera() {
    this.props.history.replace('/camera');
  }

  render() {
    return (
      <div>
        <h1>You are checked in already</h1>
        <p style={styles.text}>Do you want to checkout? </p>        
        <button onClick={this.checkOut} style={styles.button}>
          Checkout
        </button>
        <br />
        <p style={styles.text}>Return to the start screen?</p>
        <button onClick={this.navigateToCamera} style={styles.button}>
          Start screen
        </button>
      </div>
    );
  }
}

const styles = {
  text: {
    margin: 'auto',
    display: 'block'
  },
  button: {
    margin: 'auto',
    display: 'block'
  }
};

export default CheckOutComponent;
