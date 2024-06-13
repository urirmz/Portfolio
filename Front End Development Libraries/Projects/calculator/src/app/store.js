import { createStore } from 'redux';

const PRESSCLEAR = 'CLEAR';
const PRESSOPERATION = 'OPERATION';
const PRESSNUMBER = 'NUMBER';
const PRESSDOT = 'DOT';
const PRESSEQUALS = 'EQUALS';

export function pressClear() { return { type: PRESSCLEAR } }
export function pressOperation(operation) { return { type: PRESSOPERATION, operation: operation } }
export function pressNumber(number) { return { type: PRESSNUMBER, number: number } }
export function pressDot() { return { type: PRESSDOT } }
export function pressEquals() { return { type: PRESSEQUALS} }

const defaultState = {
    upperScreen: '',
    lowerScreen: '',
    operationsList: []
}

function getResult(operationsList) {
    while (operationsList.includes('*')) {
        let i = operationsList.findIndex((item) => item === '*');
        operationsList[i - 1] = operationsList[i - 1] * operationsList[i + 1];
        operationsList.splice(i, 2);
    }

    while (operationsList.includes('/')) {
        let i = operationsList.findIndex((item) => item === '/');
        operationsList[i - 1] = operationsList[i - 1] / operationsList[i + 1];
        operationsList.splice(i, 2);
    }

    while (operationsList.length > 1) {
        operationsList[0] = operationsList[0] + operationsList[1];
        operationsList.splice(1, 1);
    }

    return operationsList[0];
}

function getOperationsList(previousList, lastKey) {
    let list = [ ...previousList ];

    if (typeof lastKey === 'number' && list[list.length - 1] != '/' && list[list.length - 1] != '*') {
        list[list.length - 1] = parseFloat(list[list.length - 1].toString() + lastKey);
    } else {
        list.push(lastKey);
    } 
    
    return list;
}

const reducer = ( state = defaultState, action ) => {
    switch (action.type) {
        case PRESSCLEAR:
            return defaultState;
        case PRESSOPERATION:
            return {
                upperScreen: state.upperScreen + action.operation,
                lowerScreen: action.operation,
                operationsList: getOperationsList(state.operationsList, action.operation)
            }
        case PRESSNUMBER:
            return {
                upperScreen: state.upperScreen + action.number.toString(),
                lowerScreen: action.number
            }
        case PRESSDOT:
            return {
                upperScreen: state.upperScreen + '.',
                lowerScreen: '.'
            }
        case PRESSEQUALS:
            return {
                upperScreen: state.upperScreen + '=' + getResult(state.upperScreen),
                lowerScreen: getResult(state.upperScreen)
            }
    }
}

export const store = createStore(reducer);