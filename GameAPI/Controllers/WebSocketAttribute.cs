using GameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace GameAPI.Controllers
{

    public class WebSocketFilterAttribute : TypeFilterAttribute
    {

        public WebSocketFilterAttribute() : base(typeof(WebSocketFilterAttribute))
        {
        }

        private class WebSocketFilter : IResultFilter
        {
            private readonly IGameManager _gameManager;
            private const string APIKEYNAME = "WebSocketKey";


            public WebSocketFilter(IGameManager gameManager)
            {
                _gameManager = gameManager;
            }

            public void OnResultExecuted(ResultExecutedContext context)
            {
            }

            public void OnResultExecuting(ResultExecutingContext context)
            {
                if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "Nebyl poskytnut websocket klíč"
                    };
                    return;
                }

                var matches = _gameManager.GetActiveMatches();
                if (matches.SingleOrDefault(x => x.AccessToken == extractedApiKey) == null)
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "Websocket klíč není validní, nenalezen aktivní zápas s daným access tokenem"
                    };
                    return;
                }
            }
        }
    }
}
