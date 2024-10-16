namespace AmazonPayHttpClient;

public sealed class PrivateKeyProviderFromFile : IPrivateKeyProvider
{
	private readonly string _path;

	public PrivateKeyProviderFromFile(string oath)
	{
		_path = oath;
	}
	
	public char[]? Provide()
	{
		return File.ReadAllText(_path)?.ToCharArray();
	}
}