def dict_of_numbers() -> dict:
    ones = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", 
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", 
            "seventeen", "eighteen", "nineteen"]
    
    tens = ["", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"]
    
    number_dict = {}
    
    for i in range(100):
        if i < 20:
            number_dict[i] = ones[i]
        else:
            ten_digit = i // 10
            one_digit = i % 10
            if one_digit == 0:
                number_dict[i] = tens[ten_digit]
            else:
                number_dict[i] = f"{tens[ten_digit]}-{ones[one_digit]}"
                
    return number_dict
