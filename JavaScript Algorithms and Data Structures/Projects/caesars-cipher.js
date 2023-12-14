function rot13(str) {
  let decodedString = "";

  const letterIndex = ["A", "B", "C", "D", "E", "F", "G",
                      "H", "I", "J", "K", "L", "M", "N",
                      "O", "P", "Q", "R", "S", "T", "U",
                      "V", "W", "X", "Y", "Z",
                      "A", "B", "C", "D", "E", "F", "G",
                      "H", "I", "J", "K", "L", "M", "N",
                      "O", "P", "Q", "R", "S", "T", "U",
                      "V", "W", "X", "Y", "Z"];

  for (let i = 0; i <= str.length - 1; i++) {

    let character = "";

    for (let j = 26; j <= letterIndex.length - 1; j++) {
      if (str[i] == letterIndex[j]) {
        character = letterIndex[j - 13];
        break;
      } else {
        character = str[i];
      }
    }
    
    decodedString += character;
  }

  return decodedString;
}

rot13("SERR PBQR PNZC");