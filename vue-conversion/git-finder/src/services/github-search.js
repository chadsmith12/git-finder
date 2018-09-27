// base url for all requests
const baseUrl = 'https://api.github.com/';
const secretKey = 'INSERT SECRET KEY HERE';
const clientId = 'f0af4cac36e54e0d4409';

/**
 * GitHubSearch Api class to get information from the github API.
 */
export class GitHubSearch {
    /**
     * Gets all the users basic profile data and latest public repos
     * @param {string} userName The username you are searching for
     * @param {Number} repoCount The number of repo's to include in the search
     * @param {string} repoSort The way to sort the repo
     */
    async getUser(userName, repoCount, repoSort) {
        let isError = false;
        const profileResponse = await fetch(`${baseUrl}users/${userName}?client_id=${clientId}&client_secret${secretKey}`);
        const repoResponse = await fetch(`${baseUrl}users/${userName}/repos?per_page=${repoCount}&sort=created&direction=${repoSort}&client_id=${clientId}&client_secret${secretKey}`);

        if(profileResponse.status !== 200 || repoResponse.status !== 200) {
            isError = true;
        }

        const profileData = await profileResponse.json();
        const reposData = await repoResponse.json();

        return this._createResponse(isError, profileData, reposData);
    }

    /**
     * creates a correctly formatted response object for getUser to return
     * @param {boolean} isError If the response was an error
     * @param {object} profileData The resposne data for the profile
     * @param {object} repoData The response data for the repos
     */
    _createResponse(isError, profileData, repoData) {
        if(isError) {
            return {
                error: true,
                data: {
                    error: profileData
                }
            }
        }

        return {
            error: false,
            data: {
                profile: profileData,
                repos: repoData
            }
        }
    }
}