function convertToRoman(num) {
    let roman = '';
  
    let thousands = Math.floor(num / 1000);
    let remainder = num % 1000;
    while (thousands > 0) {
      roman += "M";
      thousands--;
    }; 
  
    let hundreds = Math.floor(remainder / 100);
    remainder = remainder % 100;
    while (hundreds > 0) {
      switch(hundreds) {
        case 9:
          roman += "CM";
          hundreds -= 9;
          break;
        case 8:
        case 7:
        case 6:
        case 5:
          roman += "D";
          hundreds -= 5;
          break;
        case 4:
          roman += "CD";
          hundreds -= 4;
          break;
        case 3:
        case 2:
        case 1:
          roman += "C";
          hundreds -= 1;
          break;
      }
    }
  
    let tens = Math.floor(remainder / 10);
    remainder = remainder % 10;
    while (tens > 0) {
      switch(tens) {
        case 9:
          roman += "XC";
          tens -= 9;
          break;
        case 8:
        case 7:
        case 6:
        case 5:
          roman += "L";
          tens -= 5;
          break;
        case 4:
          roman += "XL";
          tens -= 4;
          break;
        case 3:
        case 2:
        case 1:
          roman += "X";
          tens -= 1;
          break;
      }
    }
  
    let units = remainder;
    while (units > 0) {
      switch(units) {
        case 9:
          roman += "IX";
          units -= 9;
          break;
        case 8:
        case 7:
        case 6:
        case 5:
          roman += "V";
          units -= 5;
          break;
        case 4:
          roman += "IV";
          units -= 4;
          break;
        case 3:
        case 2:
        case 1:
          roman += "I";
          units -= 1;
          break;
      }
    }
  
  
   return roman;
  }
  
  convertToRoman(36);