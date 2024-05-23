import React from 'react';
import { Provider } from 'react-redux';
import { store } from './store';
import Drumpad from './components/Drumpad';
import Controls from './components/Controls';
import './App.css';

const soundQ = require('./sounds/Heater-1.mp3');
const soundW = require('./sounds/Heater-2.mp3');
const soundE = require('./sounds/Heater-3.mp3');
const soundA = require('./sounds/Heater-4_1.mp3');
const soundS = require('./sounds/Heater-6.mp3');
const soundD = require('./sounds/Dsc_Oh.mp3');
const soundZ = require('./sounds/Kick_n_Hat.mp3');
const soundX = require('./sounds/RP4_KICK_1.mp3');
const soundC = require('./sounds/Cev_H2.mp3');

class App extends React.Component {
  render() {
    return (
      <div className='container-fluid'>
        <div className='row justify-content-center'>
          <div id='drum-machine' className='col-5 row'> 
            <div id='drumpad-grid' className='col-6'>
              <Provider store={store}>
                <Drumpad id='Q' sound={soundQ}/>
                <Drumpad id='W' sound={soundW}/>
                <Drumpad id='E' sound={soundE}/>
                <Drumpad id='A' sound={soundA}/>
                <Drumpad id='S' sound={soundS}/>
                <Drumpad id='D' sound={soundD}/>
                <Drumpad id='Z' sound={soundZ}/>
                <Drumpad id='X' sound={soundX}/>
                <Drumpad id='C' sound={soundC}/>
              </Provider>
            </div> 
            <div className='col-6'>
              <Provider store={store}>
                <Controls/>
              </Provider>
            </div>            
          </div>    
        </div>          
      </div>      
    )
  }  
}

export default App;
