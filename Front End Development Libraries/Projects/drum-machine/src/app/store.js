import { createStore } from 'redux';

const TURNONOFF = 'ONOFF';
const CHANGESOUNDNAME = 'PLAY';
const CHANGEVOLUME = 'VOLUME';

export function turnOnOff() {
    return {
      type: TURNONOFF
    }
};

export function changeSoundName(soundName) {
    return {
      type: CHANGESOUNDNAME,
      soundName: soundName
    }
};

export function changeVolume(value) {
    return {
      type: CHANGEVOLUME,
      value: value
    }
};

const controlsDefaultState = {
    on: true,
    soundName: '',
    volume: 30
};

const controlsReducer = (state = controlsDefaultState, action) => {
    switch (action.type) {
        case TURNONOFF: 
            return {
                on: !state.on,
                soundName: state.sound,
                volume: state.volume
            }
        case CHANGESOUNDNAME: 
        return {
            on: state.on,
            soundName: action.soundName,
            volume: state.volume
        }
        case CHANGEVOLUME: 
        return {
            on: state.on,
            soundName: state.sound,
            volume: action.value
        }
        default:
            return state;
    }
  };

  export const store = createStore(controlsReducer);