using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetter.Marco
{
    public class UtenteFactory
    {
        public static Utente Crea(string nome, string cognome, string email)
        {
            return new Utente(nome, cognome, email);
        }
    }
}