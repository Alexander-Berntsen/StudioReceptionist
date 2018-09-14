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
    this.fetchPersonalData = this.fetchPersonalData.bind(this);

    console.log(props);
  }

  setRef = webcam => {
    this.webcam = webcam;
  };

  capture = () => {
    this.state.image = this.webcam.getScreenshot();
    this.checkFaceRecognitionForMatch();
  };

  checkFaceRecognitionForMatch() {
    var id = 'mats.boberg%40capgemini.com';

    let randomBoolean = Math.random() >= 0.5;
    alert('Simulated Facial Recognition match: ' + randomBoolean);

    if (randomBoolean) {
      this.state.firstName = 'Max';
      this.state.lastName = 'Wallin';
      this.state.company = 'Capgemini';
      this.state.image = require('../resources/strings').defaultPhoto;

      this.fetchPersonalData();
    } else {
      this.navigateToForm();
    }
  }

  fetchPersonalData(id) {
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
        this.navigateToGreet();
      });

    /*
    fetch(
      'https://capgeministudioreceptionistblwebapi.azurewebsites.net/api/values?id=' +
        id,
      {
        method: 'GET',
        headers: {
          'Content-type': 'application/json; charset=UTF-8'
        }
      }
    )
      .then(response => response.json())
      .catch(error => console.error('Error:', error))
      .then(response => {
        console.log(response);
        console.log(response.FirstName);
        // TODO: Problem with response here, not received as json, just as string
        this.state = {
          firstName: response.FirstName,
          lastName: response.LastName,
          company: response.Company,
          image: require('../resources/strings').defaultPhoto
        };
        this.navigateToGreet();
      });
*/
  }

  navigateToGreet() {
    this.props.history.push({
      pathname: '/greet',
      state: {
        firstName: this.state.firstName,
        lastName: this.state.lastName,
        company: this.state.company,
        image: this.state.image
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
