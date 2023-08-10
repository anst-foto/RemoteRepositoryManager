/*
Copyright 2023 Starinin Andrey

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System.Text.Json.Serialization;

namespace RemoteRepositoryManager.Library.GitHub;

public class GitHubRepositoryOwner
{
    [JsonPropertyName("login")] public string? Login { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("node_id")] public string? NodeId { get; set; }

    [JsonPropertyName("avatar_url")] public string? AvatarUrl { get; set; }

    [JsonPropertyName("gravatar_id")] public string? GravatarId { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("html_url")] public string? HtmlUrl { get; set; }

    [JsonPropertyName("followers_url")] public string? FollowersUrl { get; set; }

    [JsonPropertyName("following_url")] public string? FollowingUrl { get; set; }

    [JsonPropertyName("gists_url")] public string? GistsUrl { get; set; }

    [JsonPropertyName("starred_url")] public string? StarredUrl { get; set; }

    [JsonPropertyName("subscriptions_url")]
    public string? SubscriptionsUrl { get; set; }

    [JsonPropertyName("organizations_url")]
    public string? OrganizationsUrl { get; set; }

    [JsonPropertyName("repos_url")] public string? ReposUrl { get; set; }

    [JsonPropertyName("events_url")] public string? EventsUrl { get; set; }

    [JsonPropertyName("received_events_url")]
    public string? ReceivedEventsUrl { get; set; }

    [JsonPropertyName("type")] public string? Type { get; set; }

    [JsonPropertyName("site_admin")] public bool SiteAdmin { get; set; }
}
