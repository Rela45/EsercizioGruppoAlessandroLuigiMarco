#region INTERFACES
using System.Security.Cryptography.X509Certificates;

public interface ISubscriber
{
  void Subscribe(IObserver observer);
  void UnSub(IObserver observer);
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

public interface IStrategy
{
    string send();
}

#endregion

#region Classi Concrete Base

public class PromotionalContent : EmailDecorator
{
  public PromotionalContent(IEmail email) : base(email) { }
  public override string Header()
  {
    return "PromotionalContent";
  }

  public override string EmailBody()
  {
    return "PromotionalContent";
  }
  public override string Footer()
  {
    return "PromotionalContent";
  }
}

public class TechnicalContent : EmailDecorator
{
  public TechnicalContent(IEmail email) : base(email) { }
  public override string Header()
  {
    return "TechnicalContent";
  }
  public override string EmailBody()
  {
    return "TechnicalContent";
  }
  public override string Footer()
  {
    return "TechnicalContent";
  }
}

public class NewsContent : EmailDecorator
{
  public NewsContent(IEmail email) : base(email) { }
  public override string Header()
  {
    return "NewsContent";
  }
  public override string EmailBody()
  {
    return "NewsContent";
  }
  public override string Footer()
  {
    return "NewsContent";
  }
}
#endregion
#region SINGLETON

sealed class NewsLetterManager : ISubscriber
{
  private static NewsLetterManager _nlm;
  private List<IObserver> _observer = new List<IObserver>();
  private NewsLetterManager() { }

  public static NewsLetterManager Instance => _nlm = new NewsLetterManager();

  public void Notify(string messaggio)
  {
    foreach (var observer in _observer)
    {
      observer.NotificaCreazione(messaggio);
    }
  }

  public void Subscribe(IObserver observer)
  {
    _observer.Add(observer);
  }

  public void UnSub(IObserver observer)
  {
    _observer.Remove(observer);
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
public class EmailDelivery : IStrategy
{
    public string send()
    {
      return$"Email";
    }
}
public class SMSDelivery : IStrategy
{
    public string send()
    {
        return$"Sms";
        
    }
}

public class PushNotificationDelivery : IStrategy
{
  public string send()
  {
    return "NewsLetters inviate tramite Notifica";
  }

}

class DeliveryStrategy
{
    private IStrategy _strategy;

    public void SetMethodToSend(IStrategy strategy)
    {
        _strategy = strategy;
    }
    public void Execute()
    {
        if (_strategy == null)
        {
            Console.WriteLine("Nessu metodo di consegna newsletters selezionato!");
            return;
        }
      string? invio = _strategy.send();
      Console.WriteLine($"NewsLetters inviate tramite {invio}" );
    }
}

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
public class EmailDecorator : IEmail
{

  protected IEmail _email;
  public EmailDecorator(IEmail email)
  {
    _email = email;
  }

  public virtual string Header()
  {
    return _email.Header();
  }

  public virtual string EmailBody()
  {
    return _email.EmailBody();
  }

  public virtual string Footer()
  {
    return _email.Footer();
  }
}

#endregion
#region MAIN


class Program
{
  static void Main(string[] args)
  {
    NewsLetterManager manager = NewsLetterManager.Instance;

    IObserver subscriberPromo = new PromotionalContent();
    IObserver subscriberTech = new TechnicalContent();
    IObserver subscriberNews = new NewsContent();

    manager.Subscribe(subscriberPromo);
    manager.Subscribe(subscriberTech);
    manager.Subscribe(subscriberNews);

    bool continua = true;
    int scelta;
    while (continua)
    {
      Console.WriteLine($"------Menu newsletter------");
      Console.WriteLine("1. Invia newsletter");
      Console.WriteLine("2. Esci");
      scelta = int.Parse(Console.ReadLine());
      switch (scelta)
      {
        case 1:
          Console.WriteLine($"Inserisci nome, cognome e email dell'utente.");
          string? nome = Console.ReadLine();
          Console.WriteLine($"Nome inserito.");
          string? cognome = Console.ReadLine();
          Console.WriteLine($"Cognome inserito.");
          string? email = Console.ReadLine();
          Console.WriteLine($"Email inserita.");
          
          manager.Subscribe(utente);
          break;
      }
    }
  }
}

#endregion