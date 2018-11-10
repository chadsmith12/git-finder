<template>
    <div class="card card-body mb-3">
        <div class="row">
            <div class="col-md-3">
                <img :src="profile.avatar_url" class="img-fluid mb-2">
                <a :href="profile.html_url" class="btn btn-primary btn-block mb-4">
                    View Profile
                </a>
            </div>
            <div class="col-md-9">
                <span class="badge badge-primary">Public Repos: {{ profile.public_repos }}</span> &nbsp;
                <span class="badge badge-secondary">Public Gists: {{ profile.public_gists }}</span> &nbsp;
                <span class="badge badge-success">Followers: {{ profile.followers }}</span> &nbsp;
                <span class="badge badge-info">Following: {{ profile.following }}</span>
                <br><br>
                <ul class="list-group">
                    <li class="list-group-item">Company: {{ profile.company }}</li>
                    <li class="list-group-item">Website/Blog: {{ profile.blog }}</li>
                    <li class="list-group-item">Location: {{ profile.location }}</li>
                    <li class="list-group-item">Member Since: {{ profile.created_at }}</li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        profile: Object
    }
}
</script>

