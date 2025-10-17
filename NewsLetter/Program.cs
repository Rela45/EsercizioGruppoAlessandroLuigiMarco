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

public interface IContent
{
  string Content();
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

public class PromotionalContent : IContent
{
  public string Content()
  {
    return "Contenuto Promo";
  }
}

public class TechnicalContent : IContent
{
  public string Content()
  {
    return "Contenuto Tech";
  }
}

public class NewsContent : IContent
{

  public string Content()
  {
    return "Contenuto News";
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
    return $"Email";
  }
}
public class SMSDelivery : IStrategy
{
  public string send()
  {
    return $"Sms";

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
    Console.WriteLine($"NewsLetters inviate tramite {invio}");
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


public class WithHeader : EmailDecorator
{
  public WithHeader(IEmail email) : base(email)
  {
  }

  public override string Header()
  {
    return base.Header() + "Con Header";
  }
}


public class WithBody : EmailDecorator
{
  public WithBody(IEmail email) : base(email)
  {
  }

  public override string EmailBody()
  {
    return base.EmailBody() + "Con Body";
  }
}

public class ConFooter : EmailDecorator
{
  public ConFooter(IEmail email) : base(email)
  {
  }

  public override string Footer()
  {
    return base.Footer() + "Con Footer";
  }
}
#endregion
#region MAIN


class Program
{
  static void Main(string[] args)
  {
    NewsLetterManager manager = NewsLetterManager.Instance;


    IObserver subscriber = new Subscriber();
    manager.Subscribe(subscriber);


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
          Console.WriteLine($"Inserisci Nome: ");
          string? nome = Console.ReadLine();
          Console.WriteLine($"Nome inserito.");
          Console.WriteLine($"Inserisci Cognome:");
          string? cognome = Console.ReadLine();
          Console.WriteLine($"Cognome inserito.");
          Console.WriteLine($"Inserisci Email:");
          string? email = Console.ReadLine();
          Console.WriteLine($"Email inserita.");

          // Crea utente con factory
          Utente nuovoUtente = UtenteFactory.Crea(nome, cognome, email);

          // Crea observer e iscrivilo
          IObserver nuovoSubscriber = new Subscriber();
          manager.Subscribe(nuovoSubscriber);
          manager.Notify(nuovoUtente.Nome);

          break;

        case 2:
          continua = false;
          break;
      }
    }
  }
}




#endregion