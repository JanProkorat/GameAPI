using System;
using System.Collections.Generic;

namespace GameAPI.Models
{
    public class LoginRequest
    {
        /// <summary>
        /// Správné je "admin"
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Správné je "admin"
        /// </summary>
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool LoggedIn { get; set; }
        public string AccessToken { get; set; }
    }

    public class LeaderboardScoreDTO
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }

    public class GetLeaderBoardRequest
    {
        /// <summary>
        /// Akční, RPG, MMO, Sportovní, Strategické nebo Závodní
        /// </summary>
        public string GameType { get; set; }
    }
    public class GetLeaderBoardResponse
    {
        public List<LeaderboardScoreDTO> Results { get; set; }
    }

    public class MatchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessToken { get; set; }
        public MatchState State { get; set; }
    }

    public class GetActiveMatchesResponse
    {
        public List<MatchDTO> Matches { get; set; }

    }

    public class JoinMatchResponse
    {
        public string WebSocketToken { get; set; }
    }

    public enum MatchState
    {
        neaktivni, aktivni
    }
}
