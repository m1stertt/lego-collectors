import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:5000", //@todo sort out
  headers: {
    "Content-type": "application/json",
  },
});