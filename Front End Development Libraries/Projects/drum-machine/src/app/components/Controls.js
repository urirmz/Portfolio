import React from 'react';
import { turnOnOff, changeVolume } from '../store';
import { connect } from 'react-redux';

class Controls extends React.Component {
  constructor(props) {
    super(props);
    this.turnOnOff = this.turnOnOff.bind(this);
    this.changeVolume = this.changeVolume.bind(this);
  }

  turnOnOff() {
    this.props.turnOnOff();
  }

  changeVolume(event) {
    this.props.changeVolume(event.target.value);
  }

  render() {
    return (
      <div id='controls'>          
        <div className='form-check form-switch' id='power'>
          <label className='form-check-label' htmlFor='power-switch'>Power</label>
          <input className='form-check-input' type='checkbox' id='power-switch' checked={this.props.on} readOnly onClick={this.turnOnOff}/>
        </div>
        <div id='status-box'>
          {this.props.sound}
        </div>
        <input type="range" min='0' max='100' onChange={this.changeVolume} value={this.props.volume} className="form-range" id="volume"></input>
      </div>      
    )
  }  
}

function mapStateToProps(state) {
  return {
    on: state.on,
    sound: state.sound,
    volume: state.volume
  };
};

function mapDispatchToProps(dispatch) {
  return { 
    turnOnOff: () => {
      dispatch(turnOnOff());
    },
    changeVolume: (value) => {
      dispatch(changeVolume(value));
    },
  }    
}

const connectedComponent = connect(mapStateToProps, mapDispatchToProps) (Controls);

export default connectedComponent;