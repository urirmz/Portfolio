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
      <Provider store={store}>
        <div className='container-fluid'>
          <div className='row justify-content-center'>
            <div id='drum-machine' className='col-5 row'> 
              <div id='drumpad-grid' className='col-6'>
                  <Drumpad id='Q' soundSrc={soundQ}/>
                  <Drumpad id='W' soundSrc={soundW}/>
                  <Drumpad id='E' soundSrc={soundE}/>
                  <Drumpad id='A' soundSrc={soundA}/>
                  <Drumpad id='S' soundSrc={soundS}/>
                  <Drumpad id='D' soundSrc={soundD}/>
                  <Drumpad id='Z' soundSrc={soundZ}/>
                  <Drumpad id='X' soundSrc={soundX}/>
                  <Drumpad id='C' soundSrc={soundC}/>
              </div> 
              <div className='col-6'>
                  <Controls/>
              </div>            
            </div>    
          </div>          
        </div>    
      </Provider>  
    )
  }  
}

export default App;
