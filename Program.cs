using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


var botClient = new TelegramBotClient("BOT_TOKEN");


using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
};


botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);


// Fetch information about the bot's identity using GetMeAsync() and display a message to start listening for messages from the bot's username.
var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();


async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{

    // Only process Message updates
    if (update.Message is not { } message)
        return;
    // Only process text messages
    if (message.Text is not { } messageText)
        return;


    long chatId = update.Message.Chat.Id; // Get the chat ID from the incoming message (dynamic chatId)


    //Display user entered command details in console
    if (messageText.StartsWith("/"))
    {
        // Get the current date and time (to show in console)
        DateTime currentTime = DateTime.Now;

        // Display the user's chat ID, date, and time in console
        Console.WriteLine($"User with Chat ID {message.Chat.Id}, Username: @{message.Chat.Username ?? "N/A"}, sent the command '{messageText}' at {currentTime.ToLocalTime()}.");

    }


    if (messageText.Equals("/generate", StringComparison.InvariantCultureIgnoreCase))
    {
        string randomPassword = GenerateRandomPassword(20);
        await botClient.SendTextMessageAsync(chatId, "Generated Password: " + randomPassword);
    }

    static string GenerateRandomPassword(int length)
    {
        const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890@#$&&-()=%\"*':/!?+,.£€¥¢~¿ []{}<>^¡`;÷|¦¬×§°";

        var random = new Random();
        var passwordChars = new char[length];

        for (int i = 0; i < length; i++)
        {
            passwordChars[i] = validChars[random.Next(0, validChars.Length)];
        }

        return new string(passwordChars);
    }

}


//Handles errors that occur during the polling process of the Telegram bot.
//Logs error messages to the console, providing detailed information about the exception.
Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}