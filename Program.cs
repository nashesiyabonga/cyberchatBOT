using System;
using System.Media;
using System.Threading;
using System.Text;

class Program
{
    private static string userName = "";
    private static readonly Random random = new Random();

    static void Main(string[] args)
    {
        Console.Title = "Cybersecurity Awareness Chatbot";
        Console.Clear();
        DisplayAsciiArt();
        PlayWelcomeGreeting();
        GetUserName();
        RunChatLoop();
    }

    static void PlayWelcomeGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer( "AUDIO.wav");
            player.Play();
        }
        catch
        {
            TypeWriteEffect("Audio greeting is unavailable. Welcome to the Cybersecurity Awareness Bot!", ConsoleColor.Yellow);
        }

    }

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"
   _____        _       _         _     _             _      
  / ____|      | |     | |       | |   (_)           | |     
 | |     _ __  | | ___ | |_ ___  | |__  _ _ __   __ _| |__  
 | |    | '_ \ | |/ _ \| __/ _ \ | '_ \| | '_ \ / _` | '_ \ 
 | |____| |_) || | (_) | ||  __/ | | | | | | | | (_| | | | |
  \_____| .__/ |_|\___/ \__\___| |_| |_|_|_| |_|\__, |_| |_|
       __| |                                     __/ |        
      |_____|                                    |___/         
                                                     
");
        Console.ResetColor();

        DrawSectionHeader("CYBERSECURITY AWARENESS CHATBOT", ConsoleColor.DarkGreen);
        Thread.Sleep(800);
    }

    static void GetUserName()
    {
        TypeWriteEffect("\nBefore we start, what is your name? ", ConsoleColor.Red);
        userName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userName))
        {
            TypeWriteEffect("I didn't quite cath your name. Could you please repeat it again? ", ConsoleColor.Black);
            userName = Console.ReadLine();
        }

        DrawSectionHeader($"WELCOME, {userName.ToUpper()}!", ConsoleColor.Green);
        TypeWriteEffect("I'm your Cybersecurity Awareness chatbot Assistant.\n", ConsoleColor.Cyan);
        TypeWriteEffect("I can assist you with topics like:\n", ConsoleColor.White);
        TypeWriteEffect("• Password safety\n• Phishing detection\n• Safe browsing\n• General cybersecurity", ConsoleColor.Magenta);
        Console.WriteLine();
    }

    static void RunChatLoop()
    {
        string[] helpOptions = {
            
            "» How to recognize phishing emails",
            "» What's your goal/ purpose?",
            "» Safe browsing practices",
            "» How are you?",
            "» Type 'exit' to end our chat",
            "» How to create a strong password",
        };

        DrawSectionHeader("How can i assist you with today?", ConsoleColor.Yellow);
        Console.ForegroundColor = ConsoleColor.Blue;
        TypeWriteEffect("Here are some things that  you can ask me about :\n", 20);
        foreach (var option in helpOptions)
        {
            TypeWriteEffect(option + "\n", 30);
            Thread.Sleep(100);
        }
        Console.ResetColor();
        DrawDivider('═', ConsoleColor.DarkCyan);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n[{userName}] ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("» ");
            Console.ResetColor();

            string input = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeWriteEffect("sorry i did'nt quite hear that . Could you kindly please repeat that?\n", 20);
                Console.ResetColor();
                continue;
            }

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                DrawSectionHeader($"BYE BYE, {userName.ToUpper()}!", ConsoleColor.Blue);
                TypeWriteEffect("Remember to stay safe online!\n", ConsoleColor.Green);
                Thread.Sleep(1000);
                Environment.Exit(0);
            }

            string response = GetResponse(input);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[Bot] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("» ");
            TypeWriteEffect(response + "\n", 10);
            Console.ResetColor();
        }
    }

    static string GetResponse(string input)
    {
        input = input.ToLower();

        if (input.Contains("help") || input.Contains("what can i ask"))
        {
            return "I can assist you with topics like:\n- 🔒 Password security\n- 🚩 Identifying phishing scams\n- 🌐 Safe browsing practices\n- 🛡️ General cybersecurity advice\n- ℹ️ My purpose and role";
        }
        else if (input.Contains("purpose") || input.Contains("what do you do"))
        {
            return "I'm here to provide accurate information and help you stay secure online by raising awareness about cybersecurity.";
        }
        else if (input.Contains("password") || input.Contains("strong password"))
        {
            return "🔐 To create a strong password:\n- Make it at least 12 characters long\n- Use a mix of uppercase, lowercase, digits, and symbols\n- Avoid personal details\n- Use different passwords for different accounts\n- Consider a password manager for safety!";
        }
        else if (input.Contains("phishing") || input.Contains("incorrect email") || input.Contains("fake email"))
        {
            return "🚨 Phishing alert signs to watch for:\n1. Pressing or threatening language\n2. Asking for personal or sensitive data\n3. Suspicious sender or email addresses\n4. Poor grammar or typos\n5. Unsolicited attachments\n6. Deceptive links that don't match their destinations";
        }
        else if (input.Contains("browsing") || input.Contains("safe internet"))
        {
            return "🌍 To browse safely online:\n- Always check for HTTPS in the URL\n- Avoid downloading from unreliable sources\n- Keep your browser and plugins up-to-date\n- Use an ad-blocker\n- Avoid sensitive activities on public Wi-Fi\n- Enable two-factor authentication whenever possible";
        }
        else if (input.Contains("how are you"))
        {
            return "I'm functioning perfectly, thanks for asking! How about you? How's everything on your end?";
        }
        else
        {
            return "I'm not quite sure what you're asking. Try these:\n- 'How to create a strong password'\n- 'Phishing email signs'\n- 'How to browse safely'\nOr type 'help' to see what I can assist with.";
        }
    }


    #region UI Enhancement Methods
    static void TypeWriteEffect(string text, int delay = 30)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(random.Next(delay / 2, delay + 10));
        }
    }

    static void TypeWriteEffect(string text, ConsoleColor color, int delay = 30)
    {
        Console.ForegroundColor = color;
        TypeWriteEffect(text, delay);
        Console.ResetColor();
    }

    static void DrawSectionHeader(string text, ConsoleColor color)
    {
        Console.WriteLine();
        Console.ForegroundColor = color;
        Console.WriteLine($"╔{new string('═', text.Length + 2)}╗");
        Console.WriteLine($"║ {text} ║");
        Console.WriteLine($"╚{new string('═', text.Length + 2)}╝");
        Console.ResetColor();
        Thread.Sleep(300);
    }

    static void DrawDivider(char symbol, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(new string(symbol, Console.WindowWidth - 1));
        Console.ResetColor();
    }
    #endregion
}