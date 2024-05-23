import React from 'react';
import { Provider } from 'react-redux';
import { store } from './store';
import Editor from './components/Editor';
import Previewer from './components/Previewer';

import './App.css';

class App extends React.Component {
  render() {
    return (
      <div>
        <Provider store={store}>
          <Editor/>
          <Previewer/>
        </Provider>
      </div>      
    )
  }  
}

export default App;