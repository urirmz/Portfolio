import './Key.css';
import PropTypes from 'prop-types';

Key.propTypes = {
  id: PropTypes.string,
  symbol: PropTypes.string,
  onKeyPressed: PropTypes.func
}

export function Key({ id, symbol, onKeyPressed }) {
  return (
    <button className="key" id={ id } type="button" onClick={ () => onKeyPressed(symbol) }>
      { symbol }
    </button>
  )
}