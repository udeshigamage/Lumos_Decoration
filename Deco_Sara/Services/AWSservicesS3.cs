using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

public class AwsS3Service 
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public AwsS3Service(IConfiguration configuration)
    {
        _bucketName = configuration["AWS:BucketName"];
        _s3Client = new AmazonS3Client(configuration["AWS:AccessKey"], configuration["AWS:SecretKey"], Amazon.RegionEndpoint.GetBySystemName(configuration["AWS:Region"]));
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        var uploadRequest = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName,
            InputStream = fileStream,
            ContentType = "multipart/form-data"
        };

        var response = await _s3Client.PutObjectAsync(uploadRequest);

        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
        }

        return null;
    }
}
