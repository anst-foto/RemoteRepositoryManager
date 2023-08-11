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

namespace RemoteRepositoryManager.Library;

public abstract class AbstractManager : IDisposable
{
    protected readonly string Token;
    protected readonly string User;

    protected readonly string BaseUrl;
    protected readonly HttpClient Client;

    protected AbstractManager(string token, string user, string baseUrl)
    {
        Token = token;
        User = user;
        BaseUrl = baseUrl;

        Client = new HttpClient();
    }

    public void Dispose()
    {
        Client.Dispose();
    }
}
