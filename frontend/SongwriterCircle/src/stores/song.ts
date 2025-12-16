import type { Song } from '@/models/song'
import { defineStore } from 'pinia'

export const useSongStore = defineStore('user', {
  state: () => {
    return {
      song: null as Song | null,
    }
  },
  // getters: {
  // these are computed props
  // },
  // actions: {
  // these are methods
  // },
})
