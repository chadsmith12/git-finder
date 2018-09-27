<template>
  <div id="app">
    <app-navbar title="GitFinder"></app-navbar>
    <div class="container searchContainer">
      <app-search-card></app-search-card>
      <br>
      <app-profile></app-profile>
      <app-latest-repos></app-latest-repos>
    </div>
  </div>
</template>

<script>
import Navbar from './components/Navbar.vue';
import SearchCard from './components/SearchCard.vue'
import Profile from './components/Profile.vue'
import LatestRepos from './components/LatestRepos.vue';

export default {
  name: 'app',
  components: {
    appNavbar: Navbar,
    appSearchCard: SearchCard,
    appProfile: Profile,
    appLatestRepos: LatestRepos
  }
}
</script>

