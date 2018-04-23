using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Serialization.Json;
using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using static CloudFormationCustomResourceDemo.CfnResponse;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace CloudFormationCustomResourceDemo
{
    public class Function
    {
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public string FunctionHandler(JObject input, ILambdaContext context)
        {
            Console.WriteLine(JObject.FromObject(input).ToString(Newtonsoft.Json.Formatting.Indented));
            Console.WriteLine(context.LogStreamName);
            CfnResponse cfn = new CfnResponse();
            string result = "";

            //This can be the dataset you wish to return
            var Data = new ResponseData() { SomeName = "some" };

            if (input["RequestType"].ToString() == CfnResponse.RequestType_Create)
            {
                //Write resource provisioning code here
                result = cfn.Send(input, context, OpsStatus.Success, Data);
            }
            else if (input["RequestType"].ToString() == CfnResponse.RequestType_Update)
            {
                //Write resource updation code here
                result = cfn.Send(input, context, OpsStatus.Success, Data);
            }
            else if (input["RequestType"].ToString() == CfnResponse.RequestType_Delete)
            {
                //Write resource deletion code here
                result = cfn.Send(input, context, OpsStatus.Success, Data);
            }

            return result;
        }
    }

    public class ResponseData
    {
        public string SomeName { get; set; }
    }
}
