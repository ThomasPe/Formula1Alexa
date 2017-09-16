using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET;

namespace Formula1Alexa.Controllers
{
    [Produces("application/json")]
    [Route("api/Alexa")]
    public class AlexaController : Controller
    {
        [HttpPost]
        public dynamic Formula1Alexa(dynamic request)
        {
            return new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Nächstes Rennen"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "Formel 1",
                        content = "Hallo\nFormel 1"
                    },
                    shouldEndSession = true
                }
            };
        }

        //private async Task<SkillResponse> FunctionHandler(SkillRequest input, ILambdaContext context)
        //{
        //    var requestType = input.GetRequestType();

        //    if (requestType == typeof(IntentRequest))
        //    {
        //        return await HandleIntentRequest(input);
        //    }
        //    else if (requestType == typeof(Alexa.NET.Request.Type.LaunchRequest))
        //    {
        //        // default launch path executed
        //    }
        //    else if (requestType == typeof(AudioPlayerRequest))
        //    {
        //        // do some audio response stuff
        //    }
        //}

        private async Task<SkillResponse> HandleIntentRequest(SkillRequest input)
        {
            return await GetNextRace();
        }

        private async Task<SkillResponse> GetNextRace()
        {
            var speech = new SsmlOutputSpeech();
            speech.Ssml = "<speak>Today is <say-as interpret-as=\"date\">????0922</say-as>.<break strength=\"x-strong\"/>I hope you have a good day.</speak>";

            // create the response using the ResponseBuilder
            var finalResponse = ResponseBuilder.Tell(speech);
            return finalResponse;
        }

    }


}