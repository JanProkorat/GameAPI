using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGameManager _gameManager;

        public GameController(IConfiguration configuration, IGameManager gameManager)
        {
            _configuration = configuration;
            _gameManager = gameManager;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest resuest)
        {
            if(resuest.UserName == "admin" && resuest.Password == "admin")
            {
                return new LoginResponse {LoggedIn = true, AccessToken = _configuration.GetSection("ApiKey").Value };
            }
            return new LoginResponse { LoggedIn = false, AccessToken = null};
        }

        [HttpGet]
        [ApiKey]
        [Route("leaderboards/{GameType}")]
        public ActionResult<GetLeaderBoardResponse> GetLeaderBoardByGameType([FromRoute] GetLeaderBoardRequest request )
        {
            var result = _gameManager.GetLeaderBoardByGameType(request.GameType);
            return new GetLeaderBoardResponse { Results = result };
        }

        [HttpGet]
        [ApiKey]
        [Route("matches")]
        public ActionResult<GetActiveMatchesResponse> GetActiveMatches()
        {
            var matches = _gameManager.GetActiveMatches();
            return new GetActiveMatchesResponse { Matches = matches };
        }

        [HttpPost]
        [ApiKey]
        [Route("match/join")]
        public ActionResult<JoinMatchResponse> JoinMatch()
        {
            var result = _gameManager.JoinMatch();
            return new JoinMatchResponse { };
        } 
    }
}
