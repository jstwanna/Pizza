export const formatNumber = (num: number): string => {
  const numString = num.toString();
  return numString.length === 4
    ? `${numString[0]} ${numString.slice(1)}`
    : numString;
};
