# Translation Pro

## Features

Provides translation services for websites

## Entities
- User: User of the platform 
- Application: User can have many applications 
- Language: Languages supported by the platform
- ApplicationLanguage: Languages supported by each application
- Phrase: Phrases belonging to each application that should be translated
- Translation: The translation of each phrase

## Components

- ASP.NET Core Identity
- IdentityServer4
- Serilog
- EFCore
- Sendgrid
- CsvHelper

## Startup

1. Right click solution and chose `Set Startup Projects...`
2. Choose option `Multiple Startup Projects`
4. In Visual Studio `Start` the application(s)

## Logging In

Admin user is setup automatically, the username is `admin@admin.com` and password is `ASDFasdf!`

## Postman Setup

Getting a token looks like this:

	POST /connect/token HTTP/1.1
	Host: localhost:44319
	Content-Type: application/x-www-form-urlencoded
	Content-Length: 112

	client_secret=secret&scope=openid%20api1&grant_type=password&username=admin&password=ASDFasdf!&client_id=postman

## Generate your own Google Cloud Translate API Key
You will need to generate your own translation key and store in environmet variable named `TranslationProGoogleApi`

1. Go to the Google Cloud Console: https://console.cloud.google.com/
2. Create a new project or select an existing one.
3. Enable the "Cloud Translation API" for your project.
4. Navigate to the "APIs & Services" > "Credentials" page.
5. Click the "Create credentials" button and select "API key."
6. Copy the API key provided.

## Creating Migrations

1. open `Package Manager Console`
2. setup startup project to `TranslationPro.Base` 
3. set default project to `TranslationPro.Base`
4. run `add-migration [Migration Name] -o "Common/Data/Migrations"`
5. double check to make sure the migration is correct


## Executing Migrations

1. open `Package Manager Console`
2. setup startup project to `TranslationPro.Base` 
3. set default project to `TranslationPro.Base`
4. run `update-database` to update your local database

## Basic Rules

1. Services don't reference other services (to avoid circular dependency)
2. Managers can reference as many services as neeeded, and can reference other managers
3. Repositories are generic but can be customized with extension methods
4. Entity classes shouldn't contain any logic unless it's part of a computed column
5. If entity class needs logic, write an extension method
6. Dtos types: ViewModels, Form, Info, etc
7. 2 types of Dto, Basic, Composite
8. Basic typically dtos don't have constructor, have mapping with automapper
9. Use inheritance with AutoMapper using .IncludeAllDerived() between mappings
10. Composite Dtos get hydrated from other basic dtos.
11. Service methods never return entities
12. Entities and Dtos can coordinate properties with interface (See IProvider)

## Collaboration Information

1. Please contact rodmjay@gmail.com if you would like to be added to the postman team
1. 

## Building SASS Files
You will need to install the Web Compiler 2022+ extension.  You can find it here
https://marketplace.visualstudio.com/items?itemName=Failwyn.WebCompiler64


