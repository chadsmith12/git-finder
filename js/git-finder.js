// base url for all requests
const baseUrl = 'https://api.github.com/';

// Class to load the settings for git.
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

class GitHub {
    constructor() {
        this.settings = new Settings('settings/keys.json');
    }

    async getUser(userName) {
        let isError = false;
        const clientId = this.settings.clientId;
        const secretKey = this.settings.secretKey;
        const profileResponse = await fetch(`${baseUrl}users/${userName}?client_id=${clientId}&client_secret${secretKey}`);

        if(profileResponse.status !== 200) {
            isError = true;
        }
        const profileData = await profileResponse.json();
        
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
                    profile: profileData
                }
            }
        }

    }
}