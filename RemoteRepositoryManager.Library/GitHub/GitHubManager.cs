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

using System.Net;
using System.Net.Http.Json;

namespace RemoteRepositoryManager.Library.GitHub;

public class GitHubManager
{
    private readonly string _token;
    private readonly string _user;

    private const string BaseUrl = "https://api.github.com";
    private readonly HttpClient _client;

    public GitHubManager(string token, string user)
    {
        _token = token;
        _user = user;

        _client = new HttpClient();
    }

    public async Task<IEnumerable<GitHubRepository>?> GetAllRepositoriesAsync()
    {
        var url = $"{BaseUrl}/users/{_user}/repos";
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("User-Agent", _user);
        request.Headers.Add("Accept", "application/vnd.github+json");
        request.Headers.Add("Authorization", $"Bearer {_token}");
        request.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
        using var response = await _client.SendAsync(request);
        if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<IEnumerable<GitHubRepository>>();
    }

    public async Task DeleteRepositoryAsync(string nameRepository)
    {
        var url = $"{BaseUrl}/repos/{_user}/{nameRepository}";
        using var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("User-Agent", _user);
        request.Headers.Add("Accept", "application/vnd.github+json");
        request.Headers.Add("Authorization", $"Bearer {_token}");
        request.Headers.Add("X-GitHub-Api-Version", "2022-11-28");

        await _client.SendAsync(request);
    }
}
