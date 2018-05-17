const searchUser = document.getElementById('userSearch');
const searchBtn = document.getElementById("searchBtn");
const numberRepoSelect = document.getElementById("numberRepos");
const sortBySelect = document.getElementById("sortBy");

const gitHub = new GitHub();
const ui = new GitHubUi();

searchBtn.addEventListener('click', (e) => {
    const userText = searchUser.value;
    const numberRepos = numberRepoSelect.value;
    const sortBy = sortBySelect.value;

    if(userText !== '') {
        var userData = gitHub.getUser(userText, {
            reposCount: numberRepos,
            repoSort: sortBy
        }).then(data => {
            if(data.error) {
                ui.showAlert('User could not be found', 'alert alert-danger')
            }
            else {
                ui.showProfile(data.data);
                ui.showRepos(data.data.repos);
            }
        });
    }
    else {
        ui.clearProfile();
    }
});