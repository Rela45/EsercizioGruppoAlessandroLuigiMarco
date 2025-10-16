# EsercizioGruppoAlessandroLuigiMarco
Nuovo Esercizio di Gruppo Giovedi 16

Singleton – NewsletterManager

Classe NewsletterManager responsabile della gestione degli invii, Singleton, per garantire che esista una sola istanza centralizzata del manager.

Observer – Subscriber

Ogni utente (Subscriber) si registra al NewsletterManager per ricevere aggiornamenti. Quando una nuova newsletter viene pubblicata, il manager notifica automaticamente tutti gli iscritti.

Factory Method – ContentFactory

Il contenuto della newsletter:

PromotionalContent

TechnicalContent

NewsContent

Utilizziamo il Factory Method per creare oggetti di contenuto in base al tipo richiesto.

Decorator – NewsletterDecorator

Personalizziamo il formato della newsletter:

header

footer

sponsor/promo

Usiamo il Decorator per arricchire dinamicamente la newsletter base.

Strategy – DeliveryStrategy

Utilizziamo diversi metodi di consegna della newsletter:

EmailDelivery

SMSDelivery

PushNotificationDelivery

Permettiamo al sistema di cambiare dinamicamente il metodo di consegna.