def list_sum(list1, list2) -> list:
  list_sum = []
  for i in range(0, len(list1)):
    list_sum.append(list1[i] + list2[i])
  return list_sum