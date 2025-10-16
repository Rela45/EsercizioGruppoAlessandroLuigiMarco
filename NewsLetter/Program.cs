#region INTERFACES
public interface ISubscriber
{
    void Subscribe();
    void UnSub();
    void Notify();
}

public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}


#endregion

#region SINGLETON




#endregion


#region OBSERVER
public class Subscriber : IObserver
    {
        private string _nome;
        private List<IObserver> _observers = new List<IObserver>();

        public void NotificaCreazione(string nomeUtente)
        {
            foreach (var o in _observers)
            {
                o.NotificaCreazione(_nome);
            }
        }

        public void Subscribe(IObserver o)
        {
            _observers.Add(o);
        }
        public void UnSub(IObserver o)
        {
            _observers.Remove(o);
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