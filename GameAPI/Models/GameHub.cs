using System;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GameAPI.Models
{
    public class GameHub : Hub<IGameClient>
    {
        
    }

    public interface IGameClient
    {
        Task Fire();
        Task Move(Vector3 location);
        Task GetPlayers();
    }
}
