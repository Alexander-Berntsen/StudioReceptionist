import React, { Component } from 'react';
import Camera from './CameraComponent';
import Form from './FormComponent';
import Summary from './SummaryComponent';
import Greet from './GreetComponent';
import CheckedIn from './CheckedInComponent';
import CheckOut from './CheckOutComponent';

import { Switch, Route } from 'react-router-dom';

class AppRouterSwitch extends Component {
  render() {
    return (
      <Switch>
        <Route exact path={'/'} component={Camera} />
        <Route path={'/form'} component={Form} />
        <Route path={'/summary'} component={Summary} />
        <Route path={'/greet'} component={Greet} />
        <Route path={'/checkedin'} component={CheckedIn} />
        <Route path={'/checkout'} component={CheckOut} />
      </Switch>
    );
  }
}

export default AppRouterSwitch;
