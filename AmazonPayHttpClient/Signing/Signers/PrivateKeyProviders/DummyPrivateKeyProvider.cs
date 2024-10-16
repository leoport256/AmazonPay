using System.Security.Cryptography.X509Certificates;

namespace AmazonPayHttpClient;


internal sealed class DummyPrivateKeyProvider : IPrivateKeyProvider
{
	private const  string PrivateKey = 
		"-----BEGIN PRIVATE KEY-----\n" +
		"MIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCvdxH1zxE4Bfv4\n" +
		"8oLc7a0UCVCI7RNBAJ47dpuAEercB2WbvVu81ia5eIGJ1fOOSLso7EbgjUazKe/3\n" +
		"fgZrgG9GMv9fyvKX2Zo/TQvU8f2wiFIjQfQQhQqr/iscAMwGR1g2+TNqy1RbPump\n" +
		"lboCz94d4e+soYhQv6G6F/Zhzqw+0eTGoc6aLHIFxqCCL3OBNK3pCUH4007RBcAu\n" +
		"x5ACMSt9fRELLhKmIYWdP3ZBh1l2E+FOc8KHttzXkFBKOsY9VPX6w8x9OWsJVcdA\n" +
		"AO/tbCpUkrmrQEloVqhc3DMMywu3k/ni6iDbl6QomOHTkJed8zc7Qo5trLzRIEHK\n" +
		"8oF+s1cnAgMBAAECggEAFLJ8ZVzcAJpAGyDsC8hjYpoorEYev8ulXolClWxHolWj\n" +
		"CChhclhmb/lFem9Iz+9HWG/qemFfxhF701tDwZmARq0MT43eaMgLuEzLyP4UeSbT\n" +
		"XYJRmkM/O4N7LU3wwwrWXoGtrXq3hB3bLRxSuTMw1aCJh3j0XeYE2zEpaGcbDTu9\n" +
		"xh7t/oH8lUTU0nN4iQFahENnUi0qqi1WYYFnnDS1hIqtFZo/cWkRviY7d8SO+Zzy\n" +
		"ZbPFpYXFAVXscPl3duOitu6NfutZcetZMoVLhxgF9pXqAdIA8eP4EiP++y24HKA1\n" +
		"gi1EK7nRJcksxoJ19ojl53f1zoETzUVAt+m3bb7KyQKBgQDoHeKG9u5MP2qj/FB/\n" +
		"GyI6Crawz99S+ujKcGaSS+nqMkL9clKnkt8j8tYzh1exbIDquWKsga9WjLaouJQb\n" +
		"0i4proydKJ/QXZsdFJujl3CE+nJv+kS7O7bmHj8PuUJktq7WnA9bbW53or+HPRL7\n" +
		"1KLRwzYbWIzKgVuUeQJOst73/wKBgQDBhPFH0mZlg40tNcVsS2J1iXMu3sqHPdj9\n" +
		"AE1y9D5bKlYwAEQclghGb/rEQkYVi4Fx2aB/gOQXCX+8kU5uZr5uTAINpyERZdh3\n" +
		"AqFzdzI8LGGJ/nkFgoMddTPgRyzQMBc4fbfOY2pMxiYY4WPpaNHhW9axn1piqUci\n" +
		"3/kg2Uzg2QKBgHH8+xm8ehoHqp8NcZp6ALzwNfdungVqIpgHytddYGoadLtyQRT6\n" +
		"E4rb3kU/2djPqB+dGtAMf8bJI4qH2nQvK2xcw8EKCjGRRnNpg2U7IY6sTzaeeNJZ\n" +
		"6N/pSp62I9zBueq6iPAlNXKbAeOwInp5WdwZOaEEQ1/PVuH66x8qyESRAoGAdrus\n" +
		"llZ/QPWP3xdIxAMUq+zjYPSM6qGFyuUun8M/pwu4ycbAA5ICDcWS5GuNOJbZmxLd\n" +
		"qJ1aVNAdMYMtzgr3+BBmih3q6hPE1nAkwwV1KvpH9jTN6BWFgMNySr8gvbNj6+Mm\n" +
		"rVjN1cEVitpvRLxtWYnRljWhbTtTTBCDeCYbRzECgYB7tpwsdBGWr+fCRjIe8W+0\n" +
		"aIKQJL/HoItRstGoTPq63CFaz1x72gVDMf33GF+sarGVVC4zz1x7mU/s4gfkYLtY\n" +
		"QJqOSK6bdUXGjVAJtvXEWMpmWGh5z4mbr9CUmpziKSYIceYp3lrQ7CW1palRyeuj\n" +
		"tohaGPJEf4z2raMhjtTg/A==\n" +
		"-----END PRIVATE KEY-----";

	
	public char[]? Provide()
	{
		return PrivateKey.ToCharArray();
	}
}