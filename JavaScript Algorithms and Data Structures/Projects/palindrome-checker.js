function palindrome(str) {
  let cleanStr = str.replace(/[^a-zA-Z0-9]/g, '');
  cleanStr = cleanStr.toLowerCase();

  let reversedStr = "";
  
  for (let i = 1; i <= cleanStr.length ; i++) {
    reversedStr += cleanStr[cleanStr.length - i];
  }
  
  return (reversedStr == cleanStr);
}

palindrome("eye");