import React from "react";
import Lottie from "lottie-react";
import animationData from "./loading.json";
import "./loading.scss";
const Loading = () => {
  return (
    <div className="loading">
      <Lottie animationData={animationData} loop={true} className="animation" />
    </div>
  );
};

export default Loading;
