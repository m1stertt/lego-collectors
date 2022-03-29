import { defineStore } from "pinia";
import type { User } from "../models/User";
import { UserService } from "../services/user.service";

const userService: UserService = new UserService();

export const UserStore = defineStore({
  id: "userStore",
  state: () => ({
    loggedInUser: { name: "" } as User,
  }),
  getters: {
    userName: (state) => {
      if (state.loggedInUser.name != undefined) return state.loggedInUser.name;
      else return "";
    },
  },
  actions: {
    createUser(name: string, email: string, password: string) {
      return new Promise((resolve, reject) => {
        userService
          .createUser(name, email, password)
          .then((user) => {
            this.loggedInUser = user;
            resolve(true);
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
          .then((user) => {
            this.loggedInUser = user;
            resolve(true);
          })
          .catch((err) => {
            reject(err);
          });
      });
    },
  },
});