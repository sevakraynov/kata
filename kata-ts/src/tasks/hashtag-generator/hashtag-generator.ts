const hashTagGenerator = (str: string) : string | boolean => {

    const firstCaseToUpper = (s: string) : string => {
        return `${s[0].toUpperCase()}${s.substring(1, s.length).toLowerCase()}`;
    };

    str = str.split(" ")
      .filter(item => item !== "")
      .map(firstCaseToUpper)
      .join("");

    if(str === "") return false;

    const hashTag = `#${str}`;

    return hashTag.length > 140 ? false : hashTag;
}

export default hashTagGenerator;
