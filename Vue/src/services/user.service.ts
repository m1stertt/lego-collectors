import http from "./http.client";
import type { User } from "../models/User";

export class UserService {
  async createUser(
    name: string,
    email: string,
    password: string
  ): Promise<User> {
    const res = await http.post<User>("/api/auth/RegisterUser", {
      name: name,
      email: email,
      password: password,
    });
    return res.data;
  }
  async loginUser(email: string, password: string): Promise<User> {
    const res = await http.post<User>("/api/auth/Login", {
      email: email,
      password: password,
    });
    return res.data;
  }
}