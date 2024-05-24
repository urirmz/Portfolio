import React from 'react';
import { changeSoundName } from '../store';
import { connect } from 'react-redux';

class Drumpad extends React.Component {
  constructor(props) {
    super(props);    
    this.playSound = this.playSound.bind(this);
  }    

  componentDidMount() {
    window.addEventListener('keydown', (event) => {
      if (event.key === this.props.id.toLowerCase()) {
        this.playSound();
      }
    });
  }

  playSound() {    
    if (this.props.on) {
      switch(this.props.id) {
        case 'Q':
          this.props.changeSoundName('Heater 1');
          break;
        case 'W':
          this.props.changeSoundName('Heater 2');
          break;
        case 'E':
          this.props.changeSoundName('Heater 3');
          break;
        case 'A':
          this.props.changeSoundName('Heater 4');
          break;
        case 'S':
          this.props.changeSoundName('Clap');
          break;
        case 'D':
          this.props.changeSoundName('Open HH');
          break;
        case 'Z':
          this.props.changeSoundName('Kick n\' Hat');
          break;
        case 'X':
          this.props.changeSoundName('Kick');
          break;
        case 'C':
          this.props.changeSoundName('Closed HH');
          break;
        default: 
      }


      let drumpad = document.getElementById(this.props.id);
      let audio = document.getElementById(`audio-${this.props.id}`);

      drumpad.style.background = '#0D6EFD';
      audio.volume = this.props.volume / 100;
      audio.play();
      setTimeout(() => {
        drumpad.style.background = '#808080';
      }, 200);    
    }     
  } 

  render() {   
    return (
      <div onClick={this.playSound} className='drumpad rounded' id={this.props.id}>
          {this.props.id}            
          <audio controls src={this.props.soundSrc} className='drumpad-audio' id={`audio-${this.props.id}`}></audio>
      </div> 
    )
  }  
}

function mapStateToProps(state, ownProps) {
  return {
    on: state.on,
    soundName: state.soundName,
    volume: state.volume,
    id: ownProps.id,
    soundSrc: ownProps.soundSrc
  };
};

function mapDispatchToProps(dispatch) {
  return { 
    changeSoundName: (soundName) => {
      dispatch(changeSoundName(soundName));
    }
  }    
}

const connectedComponent = connect(mapStateToProps, mapDispatchToProps) (Drumpad);

export default connectedComponent;