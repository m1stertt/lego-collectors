import { defineStore } from "pinia";
import type { User } from "../models/User";
import { UserService } from "../services/user.service";

const userService: UserService = new UserService();

export const UserStore = defineStore({
  id: "userStore",
  state: () => ({
    loggedInUser: { email: "" } as User,
    token: String,
  }),
  getters: {
    email: (state) => {
      if (state.loggedInUser.email != undefined) return state.loggedInUser.email;
      else return "";
    },
  },
  actions: {
    createUser(name: string, email: string, password: string) {
      return new Promise((resolve, reject) => {
        userService
          .createUser(name, email, password)
          .then((token) => {
            if(token.token) localStorage.setItem('token', token.token);
            resolve(token);
          })
          .catch((err) => {
            reject(err);
          });
      });
    },
    loginUser(email: string, password: string) {
      return new Promise((resolve, reject) => {
        userService
          .loginUser(email, password)
          .then((token) => {
            if(token.token) localStorage.setItem('token', token.token);
            resolve(token);
          })
          .catch((err) => {
            reject(err);
          });
      });
    },
    getProfile(){
      return new Promise((resolve, reject) => {
        userService
            .getProfile()
            .then((profile:User) => {
              this.loggedInUser=profile;
              resolve(profile);
            })
            .catch((err) => {
              reject(err);
            });
      });
    }
  },
});