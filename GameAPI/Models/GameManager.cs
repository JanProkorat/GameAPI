using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace GameAPI.Models
{
    public class GameManager : IGameManager
    {

        public static readonly List<MatchDTO> matches = new List<MatchDTO>()
        {
            new MatchDTO{ Id = 1, Name = "Prvni", AccessToken = "access-token-prvni", State = MatchState.aktivni},
            new MatchDTO{ Id = 2, Name = "Druhy", AccessToken = "access-token-druhy", State = MatchState.neaktivni},
            new MatchDTO{ Id = 3, Name = "Treti", AccessToken = "access-token-treti", State = MatchState.aktivni },
            new MatchDTO{ Id = 4, Name = "Ctvrty", AccessToken = "access-token-ctvrty", State = MatchState.neaktivni},
            new MatchDTO{ Id = 5, Name = "Paty", AccessToken = "access-token-paty", State = MatchState.aktivni}
        };

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
            return matches.Where(x => x.State == MatchState.aktivni).ToList();
        }

        public string JoinMatch(int matchId)
        {
            var matchToJoin = matches.Find(x => x.Id == matchId);
            return matchToJoin.AccessToken;
        }
    }

 }
