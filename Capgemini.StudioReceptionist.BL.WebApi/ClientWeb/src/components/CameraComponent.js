import React, { Component } from 'react';
import Webcam from 'react-webcam';

class CameraComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      image: ''
    };

    this.checkFaceRecognitionForMatch = this.checkFaceRecognitionForMatch.bind(
      this
    );
    console.log(props);
  }

  setRef = webcam => {
    this.webcam = webcam;
  };

  capture = () => {
    this.state.image = this.webcam.getScreenshot();
    this.checkFaceRecognitionForMatch();
  };

  navigateToGreet() {
    this.props.history.push({
      pathname: '/greet',
      state: {
        firstName: this.state.firstName,
        lastName: this.state.lastName,
        company: this.state.company,
        email: this.state.email
      }
    });
  }

  navigateToCheckOut() {
    this.props.history.push({
      pathname: '/checkout',
      state: {
        email: this.state.email
      }
    });
  }

  navigateToForm() {
    this.props.history.push({
      pathname: '/form',
      state: {
        image: this.state.image
      }
    });
  }

  checkFaceRecognitionForMatch() {
    fetch(location.protocol + '//' + location.host +'/api/ACS/DetectAndIdentifyFace', {
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
        const parsedJson = JSON.parse(response);
        console.log("Is registered : " + parsedJson.registered);
        console.log("Is checked in : " + parsedJson.checkedIn);
        if (parsedJson.registered == "true") {
          console.log("User registered")
          if (parsedJson.checkedIn == "true") {
            console.log("and checked in")
            this.state = {
              email: parsedJson.email
            }
            console.log(this.state.email)
            console.log(parsedJson.email)
            this.navigateToCheckOut();
          } else {
            console.log("and not checked in")
            this.state = {
              firstName: parsedJson.firstName,
              lastName: parsedJson.lastName,
              company: parsedJson.company,
              email: parsedJson.email
            }
            this.navigateToGreet();
          }
        } else {          
          console.log("User not registered")
          this.navigateToForm();
        }
      });
  }

  render() {
    const videoConstraints = {
      width: 1280,
      height: 720,
      facingMode: 'user'
    };

    return (
      <div>
        <Webcam
          audio={false}
          height={500}
          ref={this.setRef}
          screenshotFormat="image/jpeg"
          width={500}
          videoConstraints={videoConstraints}
          style={styles.camera}
        />
        <button onClick={this.capture} style={styles.snapButton}>
          Capture photo
        </button>
      </div>
    );
  }
}

const styles = {
  camera: {
    width: '100%',
    margin: '8px 0'
  },
  snapButton: {
    margin: 'auto',
    display: 'block'
  }
};

export default CameraComponent;
