using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace GameAPI.Models
{
    public class GameManager : IGameManager
    {
        public List<LeaderboardScoreDTO> GetLeaderBoardByGameType(string gameType)
        {
            switch (gameType)
            {
                case "Akční":
                    return GetScore();
                case "RPG":
                    return GetScore();
                case "MMO":
                    return GetScore();
                case "Sportovní":
                    return GetScore();
                case "Strategické":
                    return GetScore();
                case "Závodní":
                    return GetScore();
                default:
                    return new List<LeaderboardScoreDTO>();
            }
        }

        private List<LeaderboardScoreDTO> GetScore()
        {
            List<LeaderboardScoreDTO> result = new List<LeaderboardScoreDTO>();
            int score = 10;
            for (int i = 1; i < 11; i++)
            {
                result.Add(new LeaderboardScoreDTO { PlayerName = "Player"+i, Score = score});
                score--;
            }
            return result;
        }

        public List<MatchDTO> GetActiveMatches()
        {
            List<MatchDTO> result = new List<MatchDTO>();
            for (int i = 1; i < 6; i++)
            {
                result.Add(new MatchDTO { Id = new Random().Next(1, 50), Name = "Match" + i});
            }
            return result;
        }

        public string JoinMatch(int matchId)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);

            server.Start();
            TcpClient client = server.AcceptTcpClient();
            
            return "";
        }
    }

 }
