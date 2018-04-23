# AWS CloudFormation .NET Lambda CustomResource Template

Use this .NET Core Lambda template to provision AWS resources that isn't natively supported by CloudFormation.

```C#
  CfnResponse cfn = new CfnResponse();
  string result = "";

  //Define a class of you choice and populate it with return values to the callback Url
  var Data = new ResponseData() { SomeParam1 = "someValue" };

  if (input["RequestType"].ToString() == CfnResponse.RequestType_Create)
  {
      //Write resource provisioning code here
      result = cfn.Send(input, context, OpsStatus.Success, Data);
      
      //Signal the call back function with the status "FAILED", if the resource provision errored out\failed
      //result = cfn.Send(input, context, OpsStatus.Fail, Data);
  }
  else if (input["RequestType"].ToString() == CfnResponse.RequestType_Update)
  {
      //Write resource updation code here
      result = cfn.Send(input, context, OpsStatus.Success, Data);
      
      //Signal the call back function with the status "FAILED", if the resource provision errored out\failed
      //result = cfn.Send(input, context, OpsStatus.Fail, Data);
  }
  else if (input["RequestType"].ToString() == CfnResponse.RequestType_Delete)
  {
      //Write resource deletion code here
      result = cfn.Send(input, context, OpsStatus.Success, Data);
      
      //Signal the call back function with the status "FAILED", if the resource provision errored out\failed
      //result = cfn.Send(input, context, OpsStatus.Fail, Data);
  }
```
