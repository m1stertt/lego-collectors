import axios from "axios";

export class CollectionService {
  async getCollection(){
    const res = await axios.get("/api/lego/");
    return res.data;
  }
}