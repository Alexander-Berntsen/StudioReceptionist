import React, { Component } from 'react';
import TopBanner from './TopBannerComponent';
import AppRouterSwitch from './AppRouterSwitch';
import { HashRouter as Router } from 'react-router-dom';

class AppComponent extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Router>
        <div>
          <TopBanner />
          <AppRouterSwitch />
        </div>
      </Router>
    );
  }
}

export default AppComponent;
