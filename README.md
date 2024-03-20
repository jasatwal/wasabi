# Wasabi
A C# application that demonstrates failure to upload a directory to a Wasabi bucket using AWSSDK.S3 v3.7.305.28. The upload works when using AWSSDK.S3 v3.5.7.6 as instructed [here](https://knowledgebase.wasabi.com/hc/en-us/articles/360056305411-How-do-I-use-AWS-SDK-for-C-with-Wasabi).

## Running the app
- Install [.NET v8.0 or higher](https://dotnet.microsoft.com/en-us/download)
- Update the following constants in [`Program.cs`](./Program.cs)
    - `accessKey`
    - `secretKey`
    - `bucketName`
    - `directoryPath`
- Run the app by executing `dotnet run`

You will see the following exception:

```log
Unhandled exception. Amazon.S3.AmazonS3Exception: The request signature we calculated does not match the signature you provided. Check your key and signing method.
 ---> Amazon.Runtime.Internal.HttpErrorResponseException: Exception of type 'Amazon.Runtime.Internal.HttpErrorResponseException' was thrown.
   at Amazon.Runtime.HttpWebRequestMessage.ProcessHttpResponseMessage(HttpResponseMessage responseMessage)
   at Amazon.Runtime.HttpWebRequestMessage.GetResponseAsync(CancellationToken cancellationToken)
   at Amazon.Runtime.Internal.HttpHandler`1.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.RedirectHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.Unmarshaller.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.S3.Internal.AmazonS3ResponseHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.ErrorHandler.InvokeAsync[T](IExecutionContext executionContext)
   --- End of inner exception stack trace ---
   at Amazon.Runtime.Internal.HttpErrorResponseExceptionHandler.HandleExceptionStream(IRequestContext requestContext, IWebResponseData httpErrorResponse, HttpErrorResponseException exception, Stream responseStream)
   at Amazon.Runtime.Internal.HttpErrorResponseExceptionHandler.HandleExceptionAsync(IExecutionContext executionContext, HttpErrorResponseException exception)
   at Amazon.Runtime.Internal.ExceptionHandler`1.HandleAsync(IExecutionContext executionContext, Exception exception)
   at Amazon.Runtime.Internal.ErrorHandler.ProcessExceptionAsync(IExecutionContext executionContext, Exception exception)
   at Amazon.Runtime.Internal.ErrorHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.CallbackHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.Signer.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.S3.Internal.S3Express.S3ExpressPreSigner.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.EndpointDiscoveryHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.EndpointDiscoveryHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.CredentialsRetriever.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.RetryHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.RetryHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.CallbackHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.CallbackHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.S3.Internal.AmazonS3ExceptionHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.ErrorCallbackHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.Runtime.Internal.MetricsHandler.InvokeAsync[T](IExecutionContext executionContext)
   at Amazon.S3.Transfer.Internal.SimpleUploadCommand.ExecuteAsync(CancellationToken cancellationToken)
   at Amazon.S3.Transfer.Internal.BaseCommand.ExecuteCommandAsync(BaseCommand command, CancellationTokenSource internalCts, SemaphoreSlim throttler)
   at Amazon.S3.Transfer.Internal.BaseCommand.WhenAllOrFirstExceptionAsync(List`1 pendingTasks, CancellationToken cancellationToken)
   at Amazon.S3.Transfer.Internal.UploadDirectoryCommand.ExecuteAsync(CancellationToken cancellationToken)
   at Amazon.S3.Transfer.TransferUtility.UploadDirectory(TransferUtilityUploadDirectoryRequest request)
   at Program.<Main>$(String[] args) in D:\workspace\playground\wasabi\Program.cs:line 32
```

## HTTP request/response when using AWSSDK.S3 v3.7.305.28

### Request
```http
PUT https://premcloudlon.s3.eu-west-1.wasabisys.com/NetShareFull/07/Documents/15.%20SPE%20Windows%20Phone%208%20Enroll.pdf HTTP/1.1
Expect: 100-continue
User-Agent: aws-sdk-dotnet-coreclr/3.7.305.28 ua/2.0 os/windows#10.0.22631.0 md/ARCH#X64 lang/.NET_Core#8.0.2 md/aws-sdk-dotnet-core#3.7.302.12 api/S3#3.7.305.28 cfg/retry-mode#legacy md/ClientAsync  ft/s3-transfer md/SimpleUploadCommand
amz-sdk-invocation-id: bcb5f3bd-e54f-46b3-a8c0-d4364de33a4b
amz-sdk-request: attempt=1; max=5
Host: premcloudlon.s3.eu-west-1.wasabisys.com
X-Amz-Date: 20240320T113458Z
X-Amz-Decoded-Content-Length: 345920
X-Amz-Content-SHA256: STREAMING-AWS4-HMAC-SHA256-PAYLOAD
Authorization: AWS4-HMAC-SHA256 Credential=QRO6X1I8DJNDXQ9WQRIJ/20240320/eu-west-1/s3/aws4_request, SignedHeaders=content-length;content-type;host;user-agent;x-amz-content-sha256;x-amz-date;x-amz-decoded-content-length, Signature=6347d642af8e20c778fd9530c62344775c41fd0d6eff35b5e2076fc01fdee474
Content-Length: 346455
Content-Type: application/pdf
```
### Response
```http
HTTP/1.1 403 Forbidden
Connection: close
Content-Type: application/xml
Date: Wed, 20 Mar 2024 11:34:59 GMT
Server: WasabiS3/7.18.4828-2024-02-12-543e1ba234 (R304-U23)
x-amz-id-2: QfaIgC2Bp1pbF/+2RE4x9lRbWuywlPLzYOpXIQjXQ3pwY1bysQXoqdXegji+j8CEdrlHPfsE7Gs1
x-amz-request-id: A028DF145DA5409E:B
x-wasabi-cm-reference-id: 1710934498075 154.61.149.103 ConID:246585414/EngineConID:3084654/Core:57
Transfer-Encoding: chunked

fcc
<?xml version="1.0" encoding="UTF-8"?>
<Error><Code>SignatureDoesNotMatch</Code><Message>The request signature we calculated does not match the signature you provided. Check your key and signing method.</Message><AWSAccessKeyId>QRO6X1I8DJNDXQ9WQRIJ</AWSAccessKeyId><StringToSign>AWS4-HMAC-SHA256&#xA;20240320T113458Z&#xA;20240320/eu-west-1/s3/aws4_request&#xA;57ba07b19ae490d1821aa8844298a460c198ac7d762389e6c7696f7c3e9dd9f8</StringToSign><SignatureProvided>6347d642af8e20c778fd9530c62344775c41fd0d6eff35b5e2076fc01fdee474</SignatureProvided><StringToSignBytes>41 57 53 34 2d 48 4d 41 43 2d 53 48 41 32 35 36 a 32 30 32 34 30 33 32 30 54 31 31 33 34 35 38 5a a 32 30 32 34 30 33 32 30 2f 65 75 2d 77 65 73 74 2d 31 2f 73 33 2f 61 77 73 34 5f 72 65 71 75 65 73 74 a 35 37 62 61 30 37 62 31 39 61 65 34 39 30 64 31 38 32 31 61 61 38 38 34 34 32 39 38 61 34 36 30 63 31 39 38 61 63 37 64 37 36 32 33 38 39 65 36 63 37 36 39 36 66 37 63 33 65 39 64 64 39 66 38</StringToSignBytes><CanonicalRequest>PUT&#xA;/NetShareFull/07/Documents/15.%20SPE%20Windows%20Phone%208%20Enroll.pdf&#xA;&#xA;content-length:346455&#xA;content-type:application/pdf&#xA;host:premcloudlon.s3.eu-west-1.wasabisys.com&#xA;user-agent:aws-sdk-dotnet-coreclr/3.7.305.28 ua/2.0 os/windows#10.0.22631.0 md/ARCH#X64 lang/.NET_Core#8.0.2 md/aws-sdk-dotnet-core#3.7.302.12 api/S3#3.7.305.28 cfg/retry-mode#legacy md/ClientAsync  ft/s3-transfer md/SimpleUploadCommand&#xA;x-amz-content-sha256:STREAMING-AWS4-HMAC-SHA256-PAYLOAD&#xA;x-amz-date:20240320T113458Z&#xA;x-amz-decoded-content-length:345920&#xA;&#xA;content-length;content-type;host;user-agent;x-amz-content-sha256;x-amz-date;x-amz-decoded-content-length&#xA;STREAMING-AWS4-HMAC-SHA256-PAYLOAD</CanonicalRequest><CanonicalRequestBytes>50 55 54 a 2f 4e 65 74 53 68 61 72 65 46 75 6c 6c 2f 30 37 2f 44 6f 63 75 6d 65 6e 74 73 2f 31 35 2e 25 32 30 53 50 45 25 32 30 57 69 6e 64 6f 77 73 25 32 30 50 68 6f 6e 65 25 32 30 38 25 32 30 45 6e 72 6f 6c 6c 2e 70 64 66 a a 63 6f 6e 74 65 6e 74 2d 6c 65 6e 67 74 68 3a 33 34 36 34 35 35 a 63 6f 6e 74 65 6e 74 2d 74 79 70 65 3a 61 70 70 6c 69 63 61 74 69 6f 6e 2f 70 64 66 a 68 6f 73 74 3a 70 72 65 6d 63 6c 6f 75 64 6c 6f 6e 2e 73 33 2e 65 75 2d 77 65 73 74 2d 31 2e 77 61 73 61 62 69 73 79 73 2e 63 6f 6d a 75 73 65 72 2d 61 67 65 6e 74 3a 61 77 73 2d 73 64 6b 2d 64 6f 74 6e 65 74 2d 63 6f 72 65 63 6c 72 2f 33 2e 37 2e 33 30 35 2e 32 38 20 75 61 2f 32 2e 30 20 6f 73 2f 77 69 6e 64 6f 77 73 23 31 30 2e 30 2e 32 32 36 33 31 2e 30 20 6d 64 2f 41 52 43 48 23 58 36 34 20 6c 61 6e 67 2f 2e 4e 45 54 5f 43 6f 72 65 23 38 2e 30 2e 32 20 6d 64 2f 61 77 73 2d 73 64 6b 2d 64 6f 74 6e 65 74 2d 63 6f 72 65 23 33 2e 37 2e 33 30 32 2e 31 32 20 61 70 69 2f 53 33 23 33 2e 37 2e 33 30 35 2e 32 38 20 63 66 67 2f 72 65 74 72 79 2d 6d 6f 64 65 23 6c 65 67 61 63 79 20 6d 64 2f 43 6c 69 65 6e 74 41 73 79 6e 63 20 20 66 74 2f 73 33 2d 74 72 61 6e 73 66 65 72 20 6d 64 2f 53 69 6d 70 6c 65 55 70 6c 6f 61 64 43 6f 6d 6d 61 6e 64 a 78 2d 61 6d 7a 2d 63 6f 6e 74 65 6e 74 2d 73 68 61 32 35 36 3a 53 54 52 45 41 4d 49 4e 47 2d 41 57 53 34 2d 48 4d 41 43 2d 53 48 41 32 35 36 2d 50 41 59 4c 4f 41 44 a 78 2d 61 6d 7a 2d 64 61 74 65 3a 32 30 32 34 30 33 32 30 54 31 31 33 34 35 38 5a a 78 2d 61 6d 7a 2d 64 65 63 6f 64 65 64 2d 63 6f 6e 74 65 6e 74 2d 6c 65 6e 67 74 68 3a 33 34 35 39 32 30 a a 63 6f 6e 74 65 6e 74 2d 6c 65 6e 67 74 68 3b 63 6f 6e 74 65 6e 74 2d 74 79 70 65 3b 68 6f 73 74 3b 75 73 65 72 2d 61 67 65 6e 74 3b 78 2d 61 6d 7a 2d 63 6f 6e 74 65 6e 74 2d 73 68 61 32 35 36 3b 78 2d 61 6d 7a 2d 64 61 74 65 3b 78 2d 61 6d 7a 2d 64 65 63 6f 64 65 64 2d 63 6f 6e 74 65 6e 74 2d 6c 65 6e 67 74 68 a 53 54 52 45 41 4d 49 4e 47 2d 41 57 53 34 2d 48 4d 41 43 2d 53 48 41 32 35 36 2d 50 41 59 4c 4f 41 44</CanonicalRequestBytes><RequestId>A028DF145DA5409E:B</RequestId><HostId>QfaIgC2Bp1pbF/+2RE4x9lRbWuywlPLzYOpXIQjXQ3pwY1bysQXoqdXegji+j8CEdrlHPfsE7Gs1</HostId><CMReferenceId>MTcxMDkzNDQ5ODA3NSAxNTQuNjEuMTQ5LjEwMyBDb25JRDoyNDY1ODU0MTQvRW5naW5lQ29uSUQ6MzA4NDY1NC9Db3JlOjU3</CMReferenceId></Error>
0
```