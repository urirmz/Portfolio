function checkCashRegister(price, cash, cid) {
  // Set currency table and number of currencies
  const currencyTable = [
    ["PENNY", 0.01],
    ["NICKEL", 0.05],
    ["DIME", 0.1],
    ["QUARTER", 0.25],
    ["ONE", 1],
    ["FIVE", 5],
    ["TEN", 10],
    ["TWENTY", 20],
    ["ONE HUNDRED", 100]
  ];
  Object.freeze(currencyTable);
  const numberOfCurrencies = currencyTable.length;

  // Set initial conditions for return arrays
  let change = {
    status: "CLOSED",
    change: []
  };
  let insufficientChange = {
    status: "INSUFFICIENT_FUNDS",
    change: []
  };

  let changeToPay = cash - price; 
  
  // Check if cash in drawer is more than change to pay
  let totalCid = 0;
  let tiedChange = false;
  for (let i = 0; i < cid.length; i++) {totalCid += cid[i][1];} 
  if (totalCid < changeToPay) {return insufficientChange;}
  else if (totalCid == changeToPay) {tiedChange =  true;}

    // Send change when is tied
  if (tiedChange) {
    change.change = cid;
    return change; 
  }

  // Check coins to pay in each currency
  let insufficientFunds = false;
  let i = numberOfCurrencies - 1;
  let j = 0;

  for (let i = numberOfCurrencies - 1; i >= 0; i--) {
    let testCurrency = currencyTable[i][1];
    let consWeHaveInThisCurrency = Math.floor(cid[i][1] / testCurrency);
    let coinsToPayInThisCurrency = 0;
    
    if (testCurrency <= changeToPay) {
      while (changeToPay >= testCurrency && consWeHaveInThisCurrency > 0) {
      changeToPay -= testCurrency;
      changeToPay = changeToPay.toFixed(2);
      coinsToPayInThisCurrency++;
      consWeHaveInThisCurrency--;
      }
      change.change.push(currencyTable[i]);
      change.change[j][1] = coinsToPayInThisCurrency * testCurrency;
      cid[i][1] -= coinsToPayInThisCurrency * testCurrency;
      j++;
    }
    if (i <= 0 && changeToPay > 0) {
      insufficientFunds = true;
    }
  }

  if (insufficientFunds) {return insufficientChange;} 
  else if (tiedChange) {change.status = "CLOSED";} 
  else {change.status = "OPEN";}
  return change;
  
}

console.log(checkCashRegister(19.5, 20, 
  [["PENNY", 0.5],
   ["NICKEL", 0], 
   ["DIME", 0], 
   ["QUARTER", 0], 
   ["ONE", 0], 
   ["FIVE", 0], 
   ["TEN", 0], ["TWENTY", 0], ["ONE HUNDRED", 0]]));