// base url for all requests
const baseUrl = 'https://localhost:44325/api/';

/**
 * GitHubSearch Api class to get information from the github API.
 */
export class GitHubSearch {

    constructor() {

    }

    /**
     * Gets all the users basic profile data and latest public repos
     * @param {string} userName The username you are searching for
     * @param {Number} repoCount The number of repo's to include in the search
     * @param {string} repoSort The way to sort the repo
     */
    async getUser(userName, repoCount, repoSort) {
        let isError = false;
        const profileResponse = await fetch(`${baseUrl}users/${userName}`);
        const repoResponse = await fetch(`${baseUrl}users/${userName}/repos?sort=created&direction=${repoSort}&perpage=${repoCount}`);

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
     * @param {Object} profileData The resposne data for the profile
     * @param {Object} repoData The response data for the repos
     */
    _createResponse(isError, profileData, repoData) {
        if(isError) {
            return {
                success: false,
                error: profileData.error
            } 
        }

        return {
            success: true,
            profile: profileData.result,
            repos: repoData.result
        }
    }
}