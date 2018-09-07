import React, { Component } from 'react';

class GreetComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: this.props.location.state.firstName,
      company: this.props.location.state.company,
      image: this.props.location.state.image,
      personToVisit: ''
    };

    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
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
    if (this.state.personToVisit.length > 0) {
      this.props.history.push({
        pathname: '/checkedin',
        state: {
          personToVisit: this.state.personToVisit
        }
      });
    } else {
      alert("Please tell me who you're going to visit");
    }
    event.preventDefault();
  }

  render() {
    return (
      <div>
        <h1 style={styles.text}>
          Welcome {this.state.name}, {this.state.company}
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
