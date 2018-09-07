import React, { Component } from 'react';
import Camera from './CameraComponent';
import Form from './FormComponent';
import Summary from './SummaryComponent';
import Greet from './GreetComponent';
import CheckedIn from './CheckedInComponent';

import { Switch, Route, Redirect } from 'react-router-dom';

class AppRouterSwitch extends Component {
  render() {
    return (
      <Switch>
        <Route exact path={'/camera'} component={Camera} />
        <Route exact path={'/form'} component={Form} />
        <Route exact path={'/summary'} component={Summary} />
        <Route exact path={'/greet'} component={Greet} />
        <Route exact path={'/checkedin'} component={CheckedIn} />
        <Redirect from="**" to="/camera" />
      </Switch>
    );
  }
}

export default AppRouterSwitch;
