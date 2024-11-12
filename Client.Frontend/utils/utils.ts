export const formatNumber = (num: number): string => {
  const numString = num.toString();
  return numString.length === 4
    ? `${numString[0]} ${numString.slice(1)}`
    : numString;
};

export const pluralizeWord = (
  count: number,
  [singular, few, many]: [string, string, string]
): string => {
  if (count % 100 >= 11 && count % 100 <= 19) {
    return many;
  }

  switch (count % 10) {
    case 1:
      return singular;
    case 2:
    case 3:
    case 4:
      return few;
    default:
      return many;
  }
};
