const searchUser = document.getElementById('userSearch');
const searchBtn = document.getElementById("searchBtn");
const gitHub = new GitHub();
const ui = new GitHubUi();

searchBtn.addEventListener('click', (e) => {
    const userText = searchUser.value;

    if(userText !== '') {
        var userData = gitHub.getUser(userText).then(data => {
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