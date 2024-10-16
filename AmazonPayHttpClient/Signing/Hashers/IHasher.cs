namespace AmazonPayHttpClient;

public interface IHasher
{
	byte[] Hash(string content);
}