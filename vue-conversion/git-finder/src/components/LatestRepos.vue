<template>
    <div>
        <h3 class="page-heading mb-3">Latest Repos</h3>
        <div id="latestRepos">
            <app-repo></app-repo>
            <app-repo></app-repo>
        </div>
    </div>
</template>

<script>
import Repo from './Repo.vue';

export default {
    components: {
        appRepo: Repo
    }
}
</script>

