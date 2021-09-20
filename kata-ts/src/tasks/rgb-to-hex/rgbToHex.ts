const rgbToHex = (r: number, g: number, b: number) : string => {
    
    const toHex = (n: number): string => {
        const hex = (n < 0 ? 0 : n > 255 ? 255 : n).toString(16).toUpperCase();
        return hex.length === 1 ? `0${hex}` : hex;
    };
    
    return `${toHex(r)}${toHex(g)}${toHex(b)}`;
};

export default rgbToHex;