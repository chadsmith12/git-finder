export default class GitHubUi {
    constructor() {
        this.profile = document.getElementById("profile");
    }

    /**
     * Shows the profile for the user profile given.
     * @param {object} user The profile response from the github api 
     */
    showProfile(user) {
        const profile = user.profile;
        this.profile.innerHTML = `
        <div class="card card-body mb-3">
            <div class="row">
                <div class="col-md-3">
                    <img class="img-fluid mb-2" src="${profile.avatar_url}">
                        <a href="${profile.html_url}" target="_blank" class="btn btn-primary btn-block mb-4">
                            View Profile
                        </a>
                    </img>
                </div>
                <div class="col-md-9">
                    <span class="badge badge-primary">Public Repos: ${profile.public_repos}</span>
                    <span class="badge badge-secondary">Public Gists: ${profile.public_gists}</span>
                    <span class="badge badge-success">Followers: ${profile.followers}</span>
                    <span class="badge badge-info">Following: ${profile.following}</span>
                    <br><br>
                    <ul class="list-group">
                        <li class="list-group-item">Company: ${profile.company}</li>
                        <li class="list-group-item">Website/Blog: ${profile.blog}</li>
                        <li class="list-group-item">Location: ${profile.location}</li>
                        <li class="list-group-item">Member Since: ${profile.created_at}</li>
                    </ul>
                </div>
            </div>
        </div>
        <h3 class="page-heading mb-3">
            Latest Repos
        </h3>
        <div id="repos"></div>
        `
    }

    /**
     * Shows the latest repos for the repo's given.
     * @param {Array} repos Array of user repos. 
     */
    showRepos(repos) {
        let output = '';
        const forkIcon = '<i title="Forked" class="material-icons">call_split</i>';

        repos.forEach((repo) => {
            output += `
            <div class="card card-body mb-2">
                <div class="row">
                    <div class="col-md-6">
                        <a href="${repo.html_url}" target="_blank">${repo.name}</a>
                        ${repo.fork ? forkIcon : ""}
                    </div>
                    <div class="col-md-6">
                        <span class="badge badge-primary">Stars: ${repo.stargazers_count}</span>
                        <span class="badge badge-secondary">Watchers: ${repo.watchers_count}</span>
                        <span class="badge badge-success">Forks: ${repo.forks_count}</span>
                    </div>
                </div>
            </div>
            `
        });

        // output the repo's now
        document.getElementById('repos').innerHTML = output;
    }

    /**
     * Shows an alert message to the user.
     * Will automatically clear any other alerts if there were any.
     * @param {string} message The message to show to the user.
     * @param {string} className the class to attach to the alert
     * @param {Number} time the amount of time, in ms, you want the message to show up (defaults to 3 seconds)
     */
    showAlert(message, className, time) {
        this.clearAlert();

        if(time === undefined) {
            time = 3000;
        }

        const div = document.createElement('div');
        const container = document.querySelector('.searchContainer');
        div.className = className;
        div.appendChild(document.createTextNode(message));
        const search = document.querySelector('.search');
        container.insertBefore(div, search);

        setTimeout(() => {
            this.clearAlert();
        }, time);
    }

    /**
     * Clears the alert message, if one is shown.
     * If there isn't one, this method just returns.
     */
    clearAlert() {
        const currentAlert= document.querySelector('.alert');
        if(currentAlert) {
            currentAlert.remove();
        }
    }

    /**
     * Clears the profile out.
     */
    clearProfile() {
        this.profile.innerHTML = '';
    }
}