using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Alexa.NET;
using ErgastApi.Client;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Formula1Alexa
{
    public class Function
    {
        ErgastClient _client = new ErgastClient();


        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<SkillResponse> FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            // check what type of a request it is like an IntentRequest or a LaunchRequest
            var requestType = input.GetRequestType();

            if (requestType == typeof(IntentRequest))
            {
                return await HandleIntentRequest(input.Request as IntentRequest);
            }
            else if (requestType == typeof(LaunchRequest))
            {
                // default launch path executed
                return null;
            }
            else if (requestType == typeof(AudioPlayerRequest))
            {
                // do some audio response stuff
                return null;
            } else
            {
                return null;
            }

        }

        private async Task<SkillResponse> HandleIntentRequest(IntentRequest intentRequest)
        {
            return await GetNextRaceIntent();
        }

        private async Task<SkillResponse> GetNextRaceIntent()
        {
            var request = new ErgastApi.Requests.RaceListRequest()
            {

            };

            var speech = new Alexa.NET.Response.SsmlOutputSpeech();
            speech.Ssml = "<speak>Formel 1 Ergebnisse</speak>";

            // create the response using the ResponseBuilder
            var finalResponse = ResponseBuilder.Tell(speech);
            return finalResponse;

        }
    }
}
