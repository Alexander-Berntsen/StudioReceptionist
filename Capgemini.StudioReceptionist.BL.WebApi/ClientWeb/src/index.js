import React from 'react';
import { render } from 'react-dom';
import App from '../src/components/AppComponent';

render(<App />, document.getElementById('root'));

if (module.hot) {
  console.log('Hot reloading enabled');
  module.hot.accept();
} else {
  console.log('Hot reloading not enabled');
}
