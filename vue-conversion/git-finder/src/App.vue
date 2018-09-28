<template>
  <div id="app">
    <app-navbar title="GitFinder"></app-navbar>
    <div class="container searchContainer">
      <app-search-card @user-searched="searchedUser"></app-search-card>
      <br>
      <app-profile v-if="profile !== null" :profile="profile"></app-profile>
      <app-latest-repos v-if="repos.length > 0" :repos="repos"></app-latest-repos>
    </div>
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue';
import SearchCard from './components/SearchCard.vue'
import Profile from './components/Profile.vue'
import LatestRepos from './components/LatestRepos.vue';
import { GitHubSearch } from './services/github-search.js';

export default {
  name: 'app',
  data() {
    return {
      profile: null,
      repos: []
    }
  },
  methods: {
    async searchedUser(searchOptions) {
      var gitHub = new GitHubSearch();
      var response = await gitHub.getUser(searchOptions.username, searchOptions.numberRepos, searchOptions.sortBy);
      if(!response.error) {
          this.profile = response.data.profile;
          this.repos = response.data.repos;
      }
    }
  },
  components: {
    appNavbar: Navbar,
    appSearchCard: SearchCard,
    appProfile: Profile,
    appLatestRepos: LatestRepos
  }
}
</script>

