import { defineStore } from "pinia";
import { CollectionService } from "../services/collection.service";

const collectionService: CollectionService = new CollectionService();

export const CollectionStore = defineStore({
  id: "collectionStore",
  state: () => ({
    collection:[],
  }),
  getters: {
    collection: (state) => {
      if (state.collection.length) return state.collection;
      else return undefined;
    },
  },
  actions: {
    getCollection(){
      return new Promise((resolve, reject) => {
        collectionService
            .getCollection()
            .then((collection) => {
              console.log(collection);
              resolve(collection);
            })
            .catch((err) => {
              reject(err);
            });
      });
    }
  },
});