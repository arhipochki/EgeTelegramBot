using EgeBot;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

var botClient = new TelegramBotClient(Config.Token);

using var cts = new CancellationTokenSource();

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { } // receive all update types
};

Dictionary<long, ChatData> connectedUsers = new Dictionary<long, ChatData>();

botClient.StartReceiving(
    HandleUpdateAsync,
    HandleErrorAsync,
    receiverOptions,
    cancellationToken: cts.Token);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates
    if (update.Type != UpdateType.Message)
        return;
    // Only process text messages
    if (update.Message!.Type != MessageType.Text)
        return;

    var chatId = update.Message.Chat.Id;
    var messageText = update.Message.Text;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    char comp = messageText.Trim()[0];

    if (connectedUsers.ContainsKey(chatId))
    {
        Console.WriteLine($"Already here: {chatId}\n");
    }
    else
    {
        connectedUsers.Add(chatId, new ChatData(chatId));
    }

    if (comp == '/')
    {
        switch (messageText)
        {
            case "/start":
                connectedUsers[chatId].score = 0;
                connectedUsers[chatId].question = 1;
                connectedUsers[chatId].startTest = true;
                connectedUsers[chatId].oneQuestion = false;
                connectedUsers[chatId].stopwatch.Restart(); connectedUsers[chatId].qG.LoadQuestions();
                connectedUsers[chatId].questions = connectedUsers[chatId].qG.GetQuestions();
                connectedUsers[chatId].explanations.Clear();
                await SendQuestion(
                    chatId: chatId,
                    cancellationToken: cancellationToken
                );
                break;
            case "/stop":
                connectedUsers[chatId].startTest = false;
                
                await SendStatistics(
                    chatId: chatId,
                    cancellationToken: cancellationToken
                    );

                break;
            case "/help":
                var reply = "Command list: \n1) /start - start a test \n2) /stop - break a test\n3) /help - show this message";
                await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: reply,
                        cancellationToken: cancellationToken);
                break;
            case "/question":
                connectedUsers[chatId].oneQuestion = true;
                break;
            default:
                break;
        }
    }
    else
    {
        if (connectedUsers[chatId].question >= connectedUsers[chatId].qG.Count() && connectedUsers[chatId].startTest)
        {
            // Check if the last answer was right
            if (messageText == connectedUsers[chatId].questions[connectedUsers[chatId].question - 1].Answer)
                connectedUsers[chatId].score++;
            else
                connectedUsers[chatId].explanations.Add(connectedUsers[chatId].question - 1);

            connectedUsers[chatId].question = 1;
            connectedUsers[chatId].startTest = false;

            await SendStatistics(
                chatId: chatId,
                cancellationToken: cancellationToken
                );
        }
        else if (connectedUsers[chatId].startTest)
        {
            if (messageText == connectedUsers[chatId].questions[connectedUsers[chatId].question - 1].Answer)
                connectedUsers[chatId].score++;
            else
                connectedUsers[chatId].explanations.Add(connectedUsers[chatId].question - 1);

            await SendQuestion(
                chatId: chatId,
                cancellationToken: cancellationToken
            );
        }
        else if (connectedUsers[chatId].oneQuestion)
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "In dev",
                cancellationToken: cancellationToken
                );
            connectedUsers[chatId].oneQuestion = false;
        }
    }
}

async Task SendStatistics(long chatId, CancellationToken cancellationToken)
{
    connectedUsers[chatId].stopwatch.Stop();

    //connectedUsers[chatId].stats.LoadStatistics($"{chatId}");

    await botClient.SendChatActionAsync(chatId: chatId, chatAction: ChatAction.Typing, cancellationToken: cancellationToken);

    var result = $"Your score: {connectedUsers[chatId].score} / {connectedUsers[chatId].qG.Count() - 1}. Time: {connectedUsers[chatId].stopwatch.Elapsed.Hours}h {connectedUsers[chatId].stopwatch.Elapsed.Minutes}m {connectedUsers[chatId].stopwatch.Elapsed.Seconds}s ";

    await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: result,
        cancellationToken: cancellationToken
    );

    await botClient.SendChatActionAsync(chatId: chatId, chatAction: ChatAction.Typing, cancellationToken: cancellationToken);

    var expl = "Explanations:\n";

    if (connectedUsers[chatId].explanations.Count > 0)
    {
        foreach (int e in connectedUsers[chatId].explanations)
        {
            expl += $"{e}. {connectedUsers[chatId].questions[e].Explanation}\n";
        }
    }
    else
    {
        expl = "Well done, no explanation is needed!";
    }

    await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: expl,
        cancellationToken: cancellationToken
    );
}

async Task SendQuestion(long chatId, CancellationToken cancellationToken)
{
    IReplyMarkup replyMarkup = null;

    if (connectedUsers[chatId].questions[connectedUsers[chatId].question].Cards.Count() != 0)
        replyMarkup = GetButtons(connectedUsers[chatId].questions[connectedUsers[chatId].question].Cards);

    await botClient.SendChatActionAsync(chatId: chatId, chatAction: ChatAction.Typing, cancellationToken: cancellationToken);

    try
    {
        await botClient.SendPhotoAsync(
            chatId: chatId,
            photo: new InputOnlineFile(new FileStream(connectedUsers[chatId].questions[connectedUsers[chatId].question].FilePath, FileMode.Open, FileAccess.Read, FileShare.Read)),
            caption: connectedUsers[chatId].questions[connectedUsers[chatId].question].Question,
            cancellationToken: cancellationToken,
            replyMarkup: replyMarkup);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: connectedUsers[chatId].questions[connectedUsers[chatId].question].Question,
                cancellationToken: cancellationToken,
                replyMarkup: replyMarkup);
    }

    connectedUsers[chatId].question++;
}

static IReplyMarkup GetButtons(string[] buttons)
{
    List<List<KeyboardButton>> btns = new List<List<KeyboardButton>>();

    btns.Add(new List<KeyboardButton>());
    foreach (string button in buttons)
    {
        btns[0].Add(new KeyboardButton(button));
    }

    return new ReplyKeyboardMarkup(btns) { ResizeKeyboard = true, OneTimeKeyboard = true };
}

Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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