const validParentheses = (str: string): boolean => {
  const openBrackets = "[{(";
  const closedBrackets = "]})";
  const stack: Array<string> = [];

  for (let i = 0; i < str.length; i++) {
    const letter = str[i];
    if (`${openBrackets}${closedBrackets}`.indexOf(letter) < 0) continue;
    if (openBrackets.indexOf(letter) !== -1) {
      stack.push(letter);
    } else {
      if (stack.length === 0) {
        return false;
      }

      const top = stack.pop();
      if (top && openBrackets.indexOf(top) > -1 && closedBrackets.indexOf(letter) === -1) {
        return false;
      }
    }
  }

  return stack.length === 0;
};

export default validParentheses;
