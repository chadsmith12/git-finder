"use strict";

var searchUser = document.getElementById('userSearch');
var searchBtn = document.getElementById("searchBtn");
var numberRepoSelect = document.getElementById("numberRepos");
var sortBySelect = document.getElementById("sortBy");

var gitHub = new GitHub();
var ui = new GitHubUi();

searchBtn.addEventListener('click', function (e) {
    var userText = searchUser.value;
    var numberRepos = numberRepoSelect.value;
    var sortBy = sortBySelect.value;

    if (userText !== '') {
        var userData = gitHub.getUser(userText, {
            reposCount: numberRepos,
            repoSort: sortBy
        }).then(function (data) {
            if (data.error) {
                ui.showAlert('User could not be found', 'alert alert-danger');
            } else {
                ui.showProfile(data.data);
                ui.showRepos(data.data.repos);
            }
        });
    } else {
        ui.clearProfile();
    }
});
