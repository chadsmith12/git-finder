// base url for all requests
const baseUrl = 'https://api.github.com/';

/**
 * defines the settings to be used by the github api.
 * Loads in the clientid and secret key from a json file
 * NOTE: In a production setting this is not secure. The API should actually be behind a server that you call too.
 */
class Settings {
    constructor(file) {
        fetch(file).then((res) => {
            return res.json();
        }).then((data) => {
            this.clientId = data.clientId;
            this.secretKey = data.secretKey;
        }).catch(() => {
            console.error(`ERROR: Failed to load settings file: ${file}`);
        });
    }
}

/**
 * Github API class to get information from the github api.
 */
class GitHub {
    constructor() {
        this.settings = new Settings('settings/keys.json');
        this.defaultRepoCont = 5;
        this.defaultRepoSort = 'asc';
    }

    /**
     * Configures the options for searching through the git repos.
     * Expects reposCount and repoSort keys.
     * This method should only be for internal use only. All other usage is ignored.
     * @param {object} options The options object for searching the git repos. 
     */
    configureOptions(options) {
        // didn't enter anything into options
        if(options === undefined) {
            options = {
                reposCount: this.defaultRepoCont,
                repoSort: this.defaultRepoSort
            }
        }
        // using one of the default options
        else if(options.reposCount === undefined) {
            options.reposCount = this.defaultRepoCont
        }
        else if(options.repoSort === undefined) {
            options.repoSort = this.defaultRepoSort;
        }

        return options;
    }

    /**
     * Gets all the users baseic profile data and latest public repos.
     * @param {string} userName username you are searching for 
     * @param {object} options the options to use for finding the user repos. 
     */
    async getUser(userName, options) {
        options = this.configureOptions(options);
        console.log(options);

        let isError = false;
        const clientId = this.settings.clientId;
        const secretKey = this.settings.secretKey;
        const profileResponse = await fetch(`${baseUrl}users/${userName}?client_id=${clientId}&client_secret${secretKey}`);
        const repoResponse = await fetch(`${baseUrl}users/${userName}/repos?per_page=${options.reposCount}&sort=created&direction=${options.repoSort}&client_id=${clientId}&client_secret${secretKey}`);

        if(profileResponse.status !== 200 || repoResponse.status !== 200) {
            isError = true;
        }
        const profileData = await profileResponse.json();
        const repos = await repoResponse.json();
        
        if(isError) {
            return {
                error: true,
                data: {
                    error: profileData
                }
            }
        }
        else {
            return {
                error: false,
                data: {
                    profile: profileData,
                    repos: repos
                }
            }
        }
    }
}