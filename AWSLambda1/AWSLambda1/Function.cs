using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newtonsoft.json;
using Amazon.Lambda.Core;
using System.net.http;
using Alexa.NET.Request;
using Alexa.NET.Type;
using Alexa.NET.Response;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlexaTechnicalInterview
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return input?.ToUpper();
        }

        private static HttpClient httpClient;

        public Function()
        {
            httpClient = new HttpClient();
        }

        public async Task<SkillResponse> FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var requestType = input.GetRequestType();
            string outputText = "";

            if (requestType==typeof(LaunchRequest))
            {
                return BodyResponse("Welcome to the interview! Please say Technical or Behavioral to start the interview", false);
            }
        }

        private SkillResponse BodyResponse (string outputSpeech,
            bool shouldEndSession,
            string repromptText="Just say, Technical for a Technical Interview. To exit, say, exit.")
        {
            var response = new ResponseBody
            {
                shouldEndSession = shouldEndSession,
                outputSpeech = new PlainTextOutputSpeech { Text = outputSpeech }
            };


        }

    }
}