import './Display.css';
import PropTypes from 'prop-types';

Display.propTypes = {
  equation: PropTypes.string,
  result: PropTypes.string
};

export function Display({ equation, result }) {
  return (
    <div id="display">
      <div className="subscreen top">{ equation }</div>
      <div className="subscreen bottom">{ result }</div>
    </div>
  )
}

