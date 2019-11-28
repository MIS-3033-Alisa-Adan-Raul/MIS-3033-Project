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
            if (requestType==typeof(IntentRequest))
            {
                return BodyResponse("Welcome to the interview!",true);
            }
            else
            {
                return BodyResponse("I dont know how to handle this intent. Please say something like Alexa, behavioral interview.", true);
            }

        }

        private SkillResponse BodyResponse (string outputSpeech,
            bool shouldEndSession,
            string repromptText="Just say, Behavioral to initiate a behavioral interview. To exit, say, exit.")
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech }
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