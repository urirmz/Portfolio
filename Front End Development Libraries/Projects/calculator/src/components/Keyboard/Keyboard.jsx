import './Keyboard.css';
import { Key } from '../Key/Key';
import PropTypes from 'prop-types';

Keyboard.propTypes = {
  onKeyPressed: PropTypes.func
}

export function Keyboard({ onKeyPressed }) {  
  return (
    <div id="keyboard">
      <Key symbol="AC" id="clear" onKeyPressed={ onKeyPressed }/>
      <Key symbol="/" id="divide" onKeyPressed={ onKeyPressed }/>
      <Key symbol="*" id="multiply" onKeyPressed={ onKeyPressed }/>
      <Key symbol="7" id="seven" onKeyPressed={ onKeyPressed }/>
      <Key symbol="8" id="eight" onKeyPressed={ onKeyPressed }/>
      <Key symbol="9" id="nine" onKeyPressed={ onKeyPressed }/>
      <Key symbol="-" id="subtract" onKeyPressed={ onKeyPressed }/>
      <Key symbol="4" id="four" onKeyPressed={ onKeyPressed }/>
      <Key symbol="5" id="five" onKeyPressed={ onKeyPressed }/>
      <Key symbol="6" id="six" onKeyPressed={ onKeyPressed }/>
      <Key symbol="+" id="add" onKeyPressed={ onKeyPressed }/>
      <Key symbol="1" id="one" onKeyPressed={ onKeyPressed }/>
      <Key symbol="2" id="two" onKeyPressed={ onKeyPressed }/>
      <Key symbol="3" id="three" onKeyPressed={ onKeyPressed }/>
      <Key symbol="0" id="zero" onKeyPressed={ onKeyPressed }/>
      <Key symbol="." id="decimal" onKeyPressed={ onKeyPressed }/>
      <Key symbol="=" id="equals" onKeyPressed={ onKeyPressed }/>
    </div>
  );
}