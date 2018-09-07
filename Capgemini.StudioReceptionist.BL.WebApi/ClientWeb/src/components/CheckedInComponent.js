import React, { Component } from 'react';

class CheckedInComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      personToVisit: this.props.location.state.personToVisit
    };
    this.navigateToCamera = this.navigateToCamera.bind(this);
  }

  navigateToCamera() {
    this.props.history.replace('/camera');
  }

  render() {
    return (
      <div>
        <h1 style={styles.text}>
          {this.state.personToVisit} will soon receive you. Please wait.
        </h1>
        <button onClick={this.navigateToCamera} style={styles.button}>
          New check-in
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

export default CheckedInComponent;
