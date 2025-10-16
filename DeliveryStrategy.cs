#region Interfaccia Strategy 


public interface IStrategy
{
    void send();
}
#endregion

#region Classi che servono la strategia
public class EmailDelivery : IStrategy
{
    protected string send()
    {
        return "Mail";
    }
}
public class SMSDelivery : IStrategy
{
    protected string send()
    {
        return " SMS";
    }
}

public class PushNotificationDelivery : IStrategy
{
    protected string send()
    {
        System.Console.WriteLine("NewsLetters inviate tramite Notifica");
    }

}
#endregion

class DeliveryStrategy
{
    private readonly IStrategy? _stategy;

    public void SetMethodToSend(Strategy strategy)
    {
        _strategy = strategy;
    }
    public void Execute()
    {
        if (_stategy == null)
        {
            System.Console.WriteLine("Nessu metodo di consegna newsletters selezionato!");
            return;
        }
        string result = "NewsLetters inviate tramite " + _stategy.send();

        System.Console.WriteLine(result);
    }
}