#region INTERFACES
public interface ISubscriber
{
    void Subscribe();
    void UnSub();
    void Notify(string messaggio);
}

public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}

public interface IEmail
{
    string Header();

    string EmailBody();
    string Footer();
    
}

#endregion

#region Classi Concrete Base

#endregion
#region SINGLETON

sealed class  NewsLetterManager : ISubscriber
{
    private static NewsLetterManager _nlm;
    private List<IObserver> _observer = new List<IObserver>();
    private NewsLetterManager() { }

    public static NewsLetterManager Instance => _nlm = new NewsLetterManager();

    public void Notify(string messaggio)
    {
        foreach(var observer in _observer)
        {
            
        }
    }

    public void Subscribe()
    {
        throw new NotImplementedException();
    }

    public void UnSub()
    {
        throw new NotImplementedException();
    }
}


#endregion


#region OBSERVER
public class Subscriber : IObserver
{
    private string _nome;


    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"Utente Creato correttamente {nomeUtente}");
        
    }


}
#endregion


#region Strategy


#endregion



#region Factory
public class UtenteFactory
{
    public static Utente Crea(string nome, string cognome, string email)
    {
        return new Utente(nome, cognome, email);
    }
}

public class Utente
{
    private string _nome { get; set; }
    private string _cognome { get; set; }
    private string _email { get; set; }

    public string Nome
    {
        get { return _nome; }
        set
        {
            if (value != null)
            {
                _nome = value;
            }
        }
    }

    public string Cognome
    {
        get { return _cognome; }
        set
        {
            if (value != null)
            {
                _cognome = value;
            }
        }
    }

    public string Email
    {
        get { return _email; }
        set
        {
            if (value != null)
            {
                _email = value;
            }
        }
    }

    public Utente(string nome, string cognome, string email)
    {
        _nome = nome;
        _cognome = cognome;
        _email = email;
    }

    public override string ToString()
    {
        return $"Nome e cognome dell'utente: {Nome} {Cognome}\nEmail: {Email}";
    }
}
#endregion


#region Decorator


#endregion
#region MAIN


class Program
{
    static void Main(string[] args)
    {

    }
}


#endregion