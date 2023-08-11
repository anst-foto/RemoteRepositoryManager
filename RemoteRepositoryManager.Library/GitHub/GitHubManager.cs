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

public sealed class GitHubManager : AbstractManager, IManager
{
    private const string BASE_URL = "https://api.github.com";

    public GitHubManager(string token, string user) : base(token, user, BASE_URL)
    {
    }

    private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod httpMethod, string url)
    {
        using var request = new HttpRequestMessage(httpMethod, url);
        request.Headers.Add("User-Agent", User);
        request.Headers.Add("Accept", "application/vnd.github+json");
        request.Headers.Add("Authorization", $"Bearer {Token}");
        request.Headers.Add("X-GitHub-Api-Version", "2022-11-28");
        return await Client.SendAsync(request);
    }

    public async Task<IEnumerable<IRepository>?> GetAllRepositoriesAsync()
    {
        var url = $"{BaseUrl}/users/{User}/repos";
        using var response = await SendRequestAsync(HttpMethod.Get, url);
        if (response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<IEnumerable<GitHubRepository>>();
    }

    public async Task DeleteRepositoryAsync(string nameRepository)
    {
        var url = $"{BaseUrl}/repos/{User}/{nameRepository}";
        await SendRequestAsync(HttpMethod.Delete, url);
    }
}
