function telephoneCheck(str) {
  let isValid = true;

  // Area code check
  if (str[0] == 1 && str[1] != " " && str[1] != "-" && str[1] != "(") {
    isValid = false;
  }
  if (str[0] != 1 && str[0] != "(" && str[0] < 5) {
    isValid = false;
  } 

  // Shape test
  let hasParentheses = 0;
  let parenthesesPosition = 0;
  for (let i = 0; i < str.length; i++) {
      // Look for special characters
      let specialCharacter = "";
      if (parseInt(str[i]) != str[i]) {
        specialCharacter = str[i];
      }
      switch(specialCharacter) {
        case "":
          break;
        case "(":
          if (i > 2) {isValid = false};
          hasParentheses++;
          parenthesesPosition = i;
          break;
        case ")":
          if (i > 6) {isValid = false};
          hasParentheses++;
          break;
        case "-":
        case " ":
          if (
              str[i + 1] != "(" &&
              (parseInt(str[i + 1]) != str[i + 1] ||
               parseInt(str[i + 2]) != str[i + 2] ||
               parseInt(str[i + 3]) != str[i + 3])
             )
          isValid = false;
          break;
      }
  }
  if (hasParentheses != 0 && hasParentheses != 2) {
      isValid = false;
  }
  if (hasParentheses != 0 && str[parenthesesPosition + 1] < 5) {
      isValid = false;
  }

  // All are numbers test
  let cleanString = str.replaceAll("(", "");
  cleanString = cleanString.replaceAll(")", "");
  cleanString = cleanString.replaceAll("-", "");
  cleanString = cleanString.replaceAll(" ", "");
  for (let i = 0; i < cleanString.length; i++) {
    if (parseInt(cleanString[i]) != cleanString[i]) {
      isValid = false;
    }
  }

  // Length test
  cleanString = cleanString.replace(/\D/g, "")
  if (cleanString.length < 10 || cleanString.length > 13) {
    isValid = false;
  }

  return isValid;
}

// telephoneCheck("555-555-5555");

let test = "1 555-555-5555";
console.log(telephoneCheck(test));