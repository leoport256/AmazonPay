
## Intro

AmazonPayLib is a package used for access Amazon Pay Onetime checkout V2
https://developer.amazon.com/docs/amazon-pay/intro.html through HttpClient

No additional dependencies is required.


## Basic usage

All interfaces typically is generic with two paramameters

IPublicKeyProvider interface retrieve your own public key.
You should inherit from it and realize.

IPrivateKeyProvider interface retrieve your own private key.
You should inherit from it and realize.

**Important:** If you use methods with query parameters like GetReports you should pass query parameters sorted alphabetically.

## Use with clear HttpClient

Install nuget package AmazonPayHttpClient

Make inheritance from IPrivateKeyProvider IPublicKeyProvider


### Use with serviceCollection
Just call AddAmazonPay-extension, and configure your HttpClient by  calling
ConfigureAmazonPayFor* methods

ConfigureAmazonPayForUnitedStates
ConfigureAmazonPayForEurope
ConfigureAmazonPayForJapan



Now you can create HttpClient to your code with HttpClientFactory

### HttpClient without HttpClientFactory
Just call
AmazonHttpClientFactory.CreateForUnitedStates,
AmazonHttpClientFactory.CreateForJapan,
AmazonHttpClientFactory.CreateForEurope
methods

## Payload signing

Ones initializing amazon pay on frontend you should send payload and sign to amazon.

Use ISignatureClient interface for it. It is added by AddHttpClient to ServiceCollection
or you can create it by call SignatureClientFactory.Create


## Typing contracts

nuget package AmazonPayHttpClient.Contracts contains classes that marked for use with System.Text.json

## Refit интерфейс
nuget package AmazonPayHttpClient.Refit contains interface for Refit.

Call AddAmazonPayRefitClientFor* extension or create it directly

AmazonPayClient.ForEurope,
AmazonPayClient.ForJapan,
AmazonPayClient.ForUnitedStates

## Newtosoft  serialization

nuget package  AmazonPayHttpClient.Refit.Newtonsoft contains interface for Refit that use Newtonsoft.Json.
nuget package AmazonPayHttpClient.Contracts.Newtonsoft contains class marked for use with Newtosoft.Json





