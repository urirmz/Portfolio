import { createStore } from 'redux';

const TURNONOFF = 'ONOFF';
const PLAYSOUND = 'PLAY';
const CHANGEVOLUME = 'VOLUME';

export function turnOnOff() {
    return {
      type: TURNONOFF
    }
};

export function playSound(sound) {
    return {
      type: PLAYSOUND,
      sound: sound
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
    sound: '',
    volume: 30
};

const controlsReducer = (state = controlsDefaultState, action) => {
    switch (action.type) {
        case TURNONOFF: 
            return {
                on: !state.on,
                sound: state.sound,
                volume: state.volume
            }
        case PLAYSOUND: 
        return {
            on: state.on,
            sound: action.sound,
            volume: state.volume
        }
        case CHANGEVOLUME: 
        return {
            on: state.on,
            sound: state.sound,
            volume: action.value
        }
        default:
            return state;
    }
  };

  export const store = createStore(controlsReducer);