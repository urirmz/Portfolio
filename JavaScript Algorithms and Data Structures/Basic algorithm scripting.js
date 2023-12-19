function getIndexToIns(arr, num) {
    let lowestIndex = 0;
    let lowestInArray = 0;
    let orderedArray = [];
  
    while (orderedArray.length != arr.length) {
      for (let i = 0; i < arr.length; i++) {
        if (arr[i] < arr[i + 1]) {
          lowestInArray = arr[i];
          arr[i] = "used";
        }
      }
      orderedArray.push(lowestInArray);
    }
    console.log(arr);
    console.log(orderedArray);
  
    for (let i = 0; i < orderedArray.length; i++) {
      if (num <= orderedArray[i + 1] && num > orderedArray[i]) {
        lowestIndex = i + 1;
      } else if (num > orderedArray[orderedArray.length - 1]) {
        lowestIndex = orderedArray.length;
      }
    }
    return lowestIndex;
  }
  
  getIndexToIns([40, 60], 50);