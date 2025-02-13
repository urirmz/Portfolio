import './Calculator.css';
import { Display } from '../Display/Display';
import { Keyboard } from '../Keyboard/Keyboard';
import { useCallback, useEffect, useState } from 'react';

export function Calculator() {
  let [equation, setEquation] = useState("");
  let [result, setResult] = useState("0");
  let [lastSymbolIndex, setLastSymbolIndex] = useState(0);
  let [solved, setSolved] = useState(false);

  function onKeyPressed(keySymbol) {
    if (keySymbol === "AC") {
      clear();
    } else if (keySymbol === "=") {
      solve();
    } else if (isNumber(keySymbol)) {
      inputNumber(keySymbol);
    } else {
      inputOperation(keySymbol);
    }
  }

  function clear() {
    setSolved(false);
    setLastSymbolIndex(0);
    setEquation("");
  }

  function solve() {
    if (solved) {
      return;
    }

    let cleanEquation = isNaN(equation.at(-1))
                        ? equation.substring(0, equation.length - 1)
                        : equation;

    setLastSymbolIndex(cleanEquation.length);

    let result = parseFloat(eval(cleanEquation));
    setEquation(`${cleanEquation}=${result}`);
    setResult(result);
    setSolved(true);
  }

  function inputOperation(operation) {
    if (solved) {
      reduceEquation();
    }

    let equationLastIndex = equation.length - 1;

    setEquation(equation => isNaN(equation.charAt(equationLastIndex)) 
                            ? equation.substring(0, equationLastIndex) + operation 
                            : equation + operation);
  }

  function inputNumber(number) {
    if (solved) {
      clear();
    }

    setEquation(equation => equation + number);
  }
  
  function reduceEquation() {
    setEquation(equationLastNumber());

    setLastSymbolIndex(0);
    setSolved(false);
  }
  
  const equationLastNumber = useCallback(() => 
    lastSymbolIndex === 0 ? equation : equation.substring(lastSymbolIndex + 1, equation.length), 
  [equation, lastSymbolIndex]);

  // Set result
  useEffect(() => {
    let equationLastIndex = Math.max(0, equation.length - 1);
    let equationLastCharacter = equation[equationLastIndex];

    if (equation === "") {
      setResult('0');
    } else if (isNumber(equationLastCharacter)) {
      setResult(equationLastNumber());
    } else {
      setResult(equationLastCharacter);
      setLastSymbolIndex(equationLastIndex);
    }
  }, [equation, equationLastNumber]);

  function isNumber(character) {
    return !isNaN(character) || character === ".";
  }
  
  return (
    <div className="calculator">
      <Display equation={ equation } result={ result } />
      <Keyboard onKeyPressed={ onKeyPressed } />
    </div>
  )
}