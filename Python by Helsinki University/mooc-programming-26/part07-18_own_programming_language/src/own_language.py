def run(program):
  variables = {chr(ord('A') + i): 0 for i in range(26)}
  output = []

  # First pass: map all locations (labels) to their line indices
  labels = {}
  cleaned_program = []
  for i, line in enumerate(program):
      if line.endswith(':'):
          labels[line[:-1]] = len(cleaned_program)
      else:
          cleaned_program.append(line)
          
  # Helper function to resolve a value (either a variable or an integer)
  def get_value(val_str):
      if val_str in variables:
          return variables[val_str]
      return int(val_str)

  pc = 0  # Program Counter
  while pc < len(cleaned_program):
      line = cleaned_program[pc]
      parts = line.split()
      cmd = parts[0]
      
      if cmd == "END":
          break
          
      elif cmd == "PRINT":
          output.append(get_value(parts[1]))
          
      elif cmd == "MOV":
          variables[parts[1]] = get_value(parts[2])
          
      elif cmd == "ADD":
          variables[parts[1]] += get_value(parts[2])
          
      elif cmd == "SUB":
          variables[parts[1]] -= get_value(parts[2])
          
      elif cmd == "MUL":
          variables[parts[1]] *= get_value(parts[2])
          
      elif cmd == "JUMP":
          pc = labels[parts[1]]
          continue
          
      elif cmd == "IF":
          # Format: IF [val1] [op] [val2] JUMP [location]
          val1 = get_value(parts[1])
          op = parts[2]
          val2 = get_value(parts[3])
          location = parts[5]
          
          condition_met = False
          if op == "==": condition_met = val1 == val2
          elif op == "!=": condition_met = val1 != val2
          elif op == "<": condition_met = val1 < val2
          elif op == "<=": condition_met = val1 <= val2
          elif op == ">": condition_met = val1 > val2
          elif op == ">=": condition_met = val1 >= val2
          
          if condition_met:
              pc = labels[location]
              continue
              
      pc += 1
      
  return output