using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Alexa.NET.Request;
using Alexa.NET.Response;
using System.Net.Http;
using Alexa.NET.Request.Type;

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

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var requestType = input.GetRequestType();
            string outputText = "";

            if (requestType == typeof(LaunchRequest))
            {
                return BodyResponse("Welcome to the interview! Please say Technical or Behavioral to start the interview", false);
            }
            else if (input.GetRequestType() typeof(IntentRequest))
            {

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

            if(repromptText!= null)
            {
                response.Reprompt = new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = repromptText } };
            }
            var skillResonse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };
            return skillResonse;


        }

    }
}