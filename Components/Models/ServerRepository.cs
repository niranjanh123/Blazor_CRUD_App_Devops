using System.Collections;
using System.Collections.Generic;

namespace ToDoApp.Components.Models
{
    public static class ServerRepository
    {
        private static List<Server> servers = new List<Server>()
        {
            new Server {  ID = 1, Name = "Server1", Location = "Toronto" },
            new Server {  ID = 2, Name = "Server2", Location = "Toronto" },
            new Server {  ID = 3, Name = "Server3", Location = "Toronto" },
            new Server {  ID = 4, Name = "Server4", Location = "Toronto" },
            new Server {  ID = 5, Name = "Server5", Location = "Montreal" },
            new Server {  ID = 6, Name = "Server6", Location = "Montreal" },
            new Server {  ID = 7, Name = "Server7", Location = "Montreal" },
            new Server {  ID = 8, Name = "Server8", Location = "Ottawa" },
            new Server {  ID = 9, Name = "Server9", Location = "Ottawa" },
            new Server {  ID = 10, Name = "Server10", Location = "Calgary" },
            new Server {  ID = 11, Name = "Server11", Location = "Calgary" },
            new Server {  ID = 12, Name = "Server12", Location = "Halifax" },
            new Server {  ID = 13, Name = "Server13", Location = "Halifax" },
            new Server {  ID = 14, Name = "Server14", Location = "Halifax" },
            new Server {  ID = 15, Name = "Server15", Location = "Halifax" },
        };

        public static void AddServer(Server server)
        {
            var maxId = servers.Max(s => s.ID);
            server.ID = maxId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers() => servers;

        public static List<Server> GetServersByCity(string cityName)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return servers.Where(s => s.Location.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public static Server? GetServerById(int id)
        {
            var server = servers.FirstOrDefault(s => s.ID == id);
            if (server != null)
            {
                return new Server
                {
                    ID = server.ID,
                    Name = server.Name,
                    Location = server.Location,
                    status = server.status
                };
            }

            return null;
        }

            public static void UpdateServer(int serverId, Server server)
            {
                if (serverId != server.ID) return;

                var serverToUpdate = servers.FirstOrDefault(s => s.ID == serverId);
                if (serverToUpdate != null)
                {
                    serverToUpdate.status = server.status;
                    serverToUpdate.Name = server.Name;
                    serverToUpdate.Location = server.Location;
                }
            }

            public static void DeleteServer(int serverId)
            {
                var server = servers.FirstOrDefault(s => s.ID == serverId);
                if (server != null)
                {
                    servers.Remove(server);
                }
            }

        public static List<Server> SearchServers(string serverFilter)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
