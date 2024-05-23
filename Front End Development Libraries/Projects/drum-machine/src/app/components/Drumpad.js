import React from 'react';
// import { playSound } from '../store';
// import { connect } from 'react-redux';

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
    let drumpad = document.getElementById(this.props.id);
    let audio = document.getElementById(`audio-${this.props.id}`);

    drumpad.style.background = '#0D6EFD';
    audio.play();
    setTimeout(() => {
      drumpad.style.background = '#808080';
    }, 200);     
  } 

  render() {   
    return (
      <div onClick={this.playSound} className='drumpad rounded' id={this.props.id}>
          {this.props.id}            
          <audio controls src={this.props.sound} className='drumpad-audio' id={`audio-${this.props.id}`}></audio>
      </div> 
    )
  }  
}

// function mapStateToProps(state) {
//   return {
//     on: state.on,
//     sound: state.sound,
//     volume: state.volume
//   };
// };

// function mapDispatchToProps(dispatch) {
//   return { 
//     playSound: () => {
//       dispatch(playSound());
//     }
//   }    
// }

// const connectedComponent = connect(mapStateToProps, mapDispatchToProps) (Drumpad);

export default Drumpad;