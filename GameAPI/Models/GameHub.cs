using System;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GameAPI.Models
{
    public class GameHub : Hub<IGameClient>
    {
        public async Task CreateRoom()
        {
            var room = new Room("jmeno roomu");
            return room.GetAccessToken();
        }
        
        public async Task JoinRoom(string accessToken)
        {
            
        }
        
    }

    public interface IGameClient
    {
        Task Fire();
        Task Move(Vector3 location);
        Task GetPlayers();
    }
}
