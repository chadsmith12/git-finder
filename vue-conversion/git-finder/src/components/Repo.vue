<template>
    <div class="card card-body mb-2">
        <div class="row">
            <div class="col-md-6">
                <a :href="repo.html_url" target="_blank">{{ repo.name }}</a>
                <i v-if="repo.fork" title="Forked" class="material-icons">call_split</i>
            </div>
            <div class="col-md-6">
                <span class="badge badge-primary">Stars: {{ repo.stargazers_count }}</span> &nbsp;
                <span class="badge badge-secondary">Watchers: {{ repo.watchers_count }}</span> &nbsp;
                <span class="badge badge-success">Forks: {{ repo.forks_count }}</span> &nbsp;
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        repo: Object
    },

}
</script>

