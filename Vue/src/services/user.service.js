import http from "./http.client";

export class UserService {
  async createUser(name, email, password){
    const res = await http.post("/api/auth/RegisterUser", {
      name: name,
      email: email,
      password: password,
    });
    return res.data;
  }
  async loginUser(email, password){
    const res = await http.post("/api/auth/Login", {
      email: email,
      password: password,
    });
    return res.data;
  }
}