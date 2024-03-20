using Amazon.S3;
using Amazon.S3.Transfer;

// Specify your AWS credentials
const string accessKey = "QRO6X1I8DJNDXQ9WQRIJ";
const string secretKey = "wVEpfPlFEin4LspgB0VKYjACJp8eFlqLSjAsRn6v";

// Specify the bucket name and the directory to upload
const string bucketName = "premcloudlon";
const string directoryPath = @"C:\SonyData";

// Create an S3 client object
var s3Client = new AmazonS3Client(accessKey, secretKey, new AmazonS3Config
{
    // Change the service URL to the Wasabi endpoint
    ServiceURL = "https://s3.eu-west-1.wasabisys.com"
});

// Create a TransferUtility object
var transferUtility = new TransferUtility(s3Client);

// Create a TransferUtilityUploadDirectoryRequest object
var request = new TransferUtilityUploadDirectoryRequest
{
    BucketName = bucketName,
    Directory = directoryPath,
    // Set the SearchOption to AllDirectories to upload recursively
    SearchOption = SearchOption.AllDirectories
};

// Upload the directory to the bucket
transferUtility.UploadDirectory(request);

