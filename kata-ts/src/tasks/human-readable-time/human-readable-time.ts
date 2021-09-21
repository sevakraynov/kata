const humanReadableTime = (sec: number): string => {
  const leadingZero = (n: number): string => (n > 9 ? `${n}` : `0${n}`);
  const secondsInMinutes = 60;
  const secondsInHours = 60 * 60;

  const hours = Math.floor(sec / secondsInHours);
  const minutes = Math.floor((sec % secondsInHours) / secondsInMinutes);
  const seconds = Math.floor((sec % secondsInHours) % secondsInMinutes);

  return `${leadingZero(hours)}:${leadingZero(minutes)}:${leadingZero(seconds)}`;
};

export default humanReadableTime;
