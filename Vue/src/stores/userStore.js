import { defineStore } from "pinia";
import { UserService } from "@/services/user.service";

const userService = new UserService();

export const UserStore = defineStore({
  id: "userStore",
  state: () => ({
    loggedInUser: { name: "" },
  }),
  getters: {
    userName: (state) => {
      if (state.loggedInUser.name != undefined) return state.loggedInUser.name;
      else return "";
    },
  },
  actions: {
    createUser(name, email, password) {
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
    loginUser(email, password) {
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