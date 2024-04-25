using System;
using System.Linq;
using MyProject;
using NotizData;

class Program
{
    static void Main()
    {
        while (true)
        {
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
                    Console.WriteLine("Ungültige Option.");
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
                    Console.WriteLine("Ungültige Option.");
                    break;
            }
        }
    }

    static void ShowUserNotes(GSO_ABSCHLUSS context, string username)
    {
        var userNotes = context.Notes.Where(n => n.Username == username).ToList();
        if (userNotes.Any())
        {
            Console.WriteLine($"Notizen für Benutzer '{username}':");
            foreach (var note in userNotes)
            {
                Console.WriteLine($"Titel: {note.Title}, Inhalt: {note.Content}");
            }
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
}
