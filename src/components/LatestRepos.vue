<template>
    <div>
        <h3 class="page-heading mb-3">Latest Repos</h3>
        <div id="latestRepos">
            <app-repo v-for="(repo, index) in repos" :key="index" :repo="repo"></app-repo>
        </div>
    </div>
</template>

<script>
import Repo from './Repo.vue';

export default {
    props: {
        repos: Array
    },
    components: {
        appRepo: Repo
    }
}
</script>

