import React from 'react';
import { Provider } from 'react-redux';
import { store } from './store';
import Key from './components/Key'

import './App.css';

class App extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <div className='container-fluid'>

        </div>
      </Provider>   
    );
  } 
  
}

export default App;
