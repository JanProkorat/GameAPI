using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using GameAPI.Controllers;
using Microsoft.AspNetCore.SignalR;

namespace GameAPI.Models
{
    [WebSocketFilter]
    public class GameHub : Hub<IGameClient>
    {
        public async Task Fire()
        {
            throw new NotImplementedException();
        }

        public async Task<Vector3> Move(Vector3 location)
        {
            return location;
        }

        public Task GetPlayers()
        {
            throw new NotImplementedException();
        }
    }

    public interface IGameClient
    {
        Task Fire();
        Task Move(Vector3 location);
        Task GetPlayers();
    }
}
