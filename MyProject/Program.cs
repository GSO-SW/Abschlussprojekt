using System;
using System.Linq;
using System.Threading;
using MyProject;
using NotizData;
using Figgle;
//ALOOOOOO_FERTIG

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            string textToAnimate = (FiggleFonts.Slant.Render("Notizen"));
            foreach (char c in textToAnimate)
            {
                if (c == '\n')
                {
                    Thread.Sleep(200);
                }
                Console.Write(c);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Einloggen");
            Console.WriteLine("2. Registrieren");
            Console.WriteLine("3. Beenden");

            Console.WriteLine("Wählen Sie eine Option:");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    return;
                default:
                    BlinkInvalidOption();
                    break;
            }
        }
    }

    static void Login()
    {
        using var context = new GSO_ABSCHLUSS();

        Console.WriteLine("Benutzername:");
        string username = Console.ReadLine();

        Console.WriteLine("Passwort:");
        string password = Console.ReadLine();

        var user = context.Logins.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user == null)
        {
            Console.WriteLine("Ungültige Anmeldeinformationen.");
            return;
        }

        Console.WriteLine($"Willkommen, {username}!");
        ShowMenu(context, username);
    }

    static void Register()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
            string textToAnimate = (FiggleFonts.Slant.Render("Registrieren"));
            foreach (char c in textToAnimate)
            {
                if (c == '\n')
                {
                    Thread.Sleep(200);
                }
                Console.Write(c);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--------------------");
        using var context = new GSO_ABSCHLUSS();

        Console.WriteLine("Benutzername:");
        string username = Console.ReadLine();

        Console.WriteLine("Passwort:");
        string password = Console.ReadLine();

        if (context.Logins.Any(u => u.Username == username))
        {
            Console.WriteLine("Benutzername bereits vergeben.");
            return;
        }

        var newUser = new Login { Username = username, Password = password };
        context.Logins.Add(newUser);
        context.SaveChanges();

        Console.WriteLine("Benutzer erfolgreich registriert.");
    }

    static void ShowMenu(GSO_ABSCHLUSS context, string username)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("1. Notizen anzeigen");
            Console.WriteLine("2. Neue Notiz erstellen");
            Console.WriteLine("3. Abmelden");

            Console.WriteLine("Wählen Sie eine Option:");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowUserNotes(context, username);
                    break;
                case "2":
                    CreateNote(context, username);
                    break;
                case "3":
                    return;
                default:
                    BlinkInvalidOption();
                    break;
            }
        }
    }

    static void ShowUserNotes(GSO_ABSCHLUSS context, string username)
    {
        var userNotes = context.Notes.Where(n => n.Username == username).ToList();
        if (userNotes.Any())
        {
            Console.Clear();
            Console.WriteLine($"Notizen für Benutzer '{username}':");
            foreach (var note in userNotes)
            {
                Console.WriteLine($"Titel: {note.Title}, Inhalt: {note.Content}");
            }
            Console.ReadKey();
        } 
        else
        {
            Console.WriteLine($"Keine Notizen gefunden für Benutzer '{username}'.");
        }
    }

    static void CreateNote(GSO_ABSCHLUSS context, string username)
    {
        
        Console.WriteLine("Titel der Notiz:");
        string title = Console.ReadLine();

        Console.WriteLine("Inhalt der Notiz:");
        string content = Console.ReadLine();

        var note = new Note { Username = username, Title = title, Content = content };
        context.Notes.Add(note);
        context.SaveChanges();
        Console.WriteLine($"Notiz mit Titel '{title}' erfolgreich erstellt für Benutzer '{username}'.");
    }

    static void BlinkInvalidOption()
    {
        // Speichert die ursprüngliche Farbe
        ConsoleColor originalColor = Console.ForegroundColor;

        // Die gewünschte Blinkdauer in Millisekunden
        int blinkDuration = 3000;

        // Zeit, wenn das Blinken beginnt
        DateTime startTime = DateTime.Now;

        // Solange die Blinkdauer nicht abgelaufen ist
        while ((DateTime.Now - startTime).TotalMilliseconds < blinkDuration)
        {
            Console.Clear();
            // Farbe auf Rot setzen
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine("Falsche Eingabe.");
            
            // Eine kurze Pause einlegen, um den Blinkeffekt zu erzeugen
            Thread.Sleep(500);
            Console.Clear();
            Console.ForegroundColor =ConsoleColor.Black;
            Console.WriteLine("Falsche Eingabe.");
            Thread.Sleep(500);
            

        Console.ForegroundColor = originalColor;
    }
}
}
