import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';

import capLogo from '../images/capgemini-logo.png';

class TopBannerComponent extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <NavLink to="/camera">
        {/*         <img
          src={require('../images/capgemini-logo.png')}
          style={styles.logo}
        />
 */}
        <img src={capLogo} style={styles.logo} />
        <hr />
      </NavLink>
    );
  }
}

const styles = {
  logo: {
    width: '25%',
    height: '10%'
  },
  button: {
    margin: 'auto',
    display: 'block'
  }
};

export default TopBannerComponent;
