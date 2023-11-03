# Password Generator Bot

A simple Telegram bot built in C# using the .NET client for the Telegram Bot API. This bot allows users to generate strong and random passwords on-demand.

## Features
- Generate strong and random passwords.
- Create a robust, random password with a length of 25 characters, including a mix of uppercase letters, lowercase letters, special symbols, and numbers.
- Accessible through the Telegram messenger platform.

## Prerequisites
 - [C#](https://dotnet.microsoft.com/en-us/learn/csharp)
 - [A guide to .NET Telegram.Bot API](https://telegrambots.github.io/book/)

## How to Use the Bot

Find the bot on [Currency Exchange Bot](https://t.me/random_passgen_bot)


# Getting Started

## Installation

1. Clone this repository:
   ```sh
   git clone https://github.com/ideepakpg/password-generator-bot.git

2. Open the project in your favorite C# IDE (e.g., Visual Studio, Visual Studio Code).

3. Replace ```BOT_TOKEN``` in the [Program.cs](https://github.com/ideepakpg/password-generator-bot/blob/main/Program.cs) file with your Telegram Bot API token.

    Unsure about obtaining a bot token from Telegram? Follow these steps:

4. ## Creating Your Own Telegram Bot

- **To create your own Telegram bot, you can follow these steps:**
  
  - Open Telegram and search for "[BotFather](https://t.me/BotFather)"
  - Start a chat with [BotFather](https://t.me/BotFather).
  - Use the ```/newbot``` command to create a new bot.
  - Follow the instructions to choose a name and username for your bot.
  - BotFather will provide you with an API token. Copy and use this token in your code, replacing the placeholder where ```BOT_TOKEN``` is written.

5. Build and run the project
   ```sh
   dotnet build
   dotnet run

## Commands
- `/start`: Start using the Password Generator Bot.

- `/generate`: To genrate strong random password.

## Usage

1. Start a chat with your bot on Telegram.

2. Send the `/generate` command to trigger the password generation.

3. The bot will immediately create a strong, random password for you.
  
## Upcoming Updates
I am continuously working on improving the Password Generator Bot. Here are some of the features and updates you can expect in the near future:

- ***Bookmark Passwords***: I am currently working on a feature that will allow you to store and manage generated passwords, providing a convenient way to access them whenever you need.

## Acknowledgement
The Currency Exchange Bot was developed using [C#](https://dotnet.microsoft.com/en-us/learn/csharp) and the [Telegram Bot API in .NET](https://github.com/TelegramBots/Telegram.Bot).




