namespace GitFinderApiServer.GitHubApi.Requests
{
    public class ListUsersReposRequests
    {
        public SortDirection Direction { get; set; }
        public RepoUserType Type { get; set; }
        public RepoSortColumn Sort { get; set; }
    }
}
