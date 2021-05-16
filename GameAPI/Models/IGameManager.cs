using System;
using System.Collections.Generic;

namespace GameAPI.Models
{
    public interface IGameManager
    {
        /// <summary>
        /// Podle typu hry vrátí leaderboard s nejlepšími výsledky
        /// </summary>
        /// <param name="gameType">typ hry</param>
        /// <returns>seznam hráčů se skóre</returns>
        public List<LeaderboardScoreDTO> GetLeaderBoardByGameType(string gameType);

        /// <summary>
        /// Vrátí seznam aktivních zápasů
        /// </summary>
        /// <returns> seznam zápasů</returns>
        public List<MatchDTO> GetActiveMatches();

        /// <summary>
        /// Připojí hráče do aktivního zápasu
        /// </summary>
        /// <returns>WebSocket token</returns>
        public string JoinMatch();
    }
}
