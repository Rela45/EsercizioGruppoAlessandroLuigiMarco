using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetter.Marco
{
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
}