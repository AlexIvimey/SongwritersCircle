import { defineStore } from 'pinia'
import api from '../services/api'
import type { APIResponse } from '@/models/APIResponse'
import type { User } from '@/models/user'

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
        const response = await api.post<APIResponse<User>>('/users', {
          username: username,
          password: password,
        })
        this.user = response.data.content;
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
