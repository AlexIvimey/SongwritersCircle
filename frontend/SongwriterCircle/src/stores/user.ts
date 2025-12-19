import { defineStore } from 'pinia'
import type User from '@/models/user'
import axios from 'axios'

const url = import.meta.env.API_URL

export const useUserStore = defineStore('user', {
  state: () => {
    return {
      user: null as User | null,
    }
  },
  // getters: {
  // },
  actions: {
    async createAccount(username: string, password: string) {
      try {
        const response = await axios.post(`${url}/users/create`, {
          username: username,
          password: password,
        })
        this.user = response.data;
      } catch (error) {
        return error;
      }
    },
  },
})

// Three concepts: state, getters, and actions

// State = data
// getters = computed
// actions = methods
