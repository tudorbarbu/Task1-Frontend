using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBancomat
{
    class Cont
    {
        int sold = 1000;
        int PIN = new int();

        public Cont(int PIN)
        {
            this.PIN = PIN;
        }

        public void VerificareSold()
        {
            Console.WriteLine("Soldul disponibil este: " + sold);
        }

        public void RetragereNumerar()
        {
            int operatie = 0;
            int suma;
            string buffer;
            int[] sume = new int[7] { 10, 20, 50, 100, 200, 300, 500 };

            Console.WriteLine("1. 10\t 5. 200");
            Console.WriteLine("2. 20\t 6. 300");
            Console.WriteLine("3. 50\t 7. 500");
            Console.WriteLine("4. 100\t 8. Alta suma");
            Console.WriteLine("Alegeti o suma:");
            buffer = Console.ReadLine();
            if (int.TryParse(buffer, out operatie) == false && operatie > 8)
                operatie = 0;
            Console.Clear();
            switch (operatie)
            {
                case 0:
                    Console.WriteLine("Operatie invalida");
                    break;
                case 8:
                    Console.WriteLine("Specficati suma dorita:");
                    buffer = Console.ReadLine();
                    if (int.TryParse(buffer, out suma) == false)
                        Console.WriteLine("Suma specificata e incorecta");
                    else
                        Extragere(suma);
                    break;
                default:
                    Extragere(sume[operatie - 1]);
                    break;
            }

        }

        public void IncarcareCont()
        {
            string buffer;
            int suma = 0;
            int introdus;
            do
            {
                Console.WriteLine("Introduceti o suma sau scrie-ti OK cand ati terminat:");
                buffer = Console.ReadLine();
                if (int.TryParse(buffer, out introdus) == false && buffer.ToUpper().Equals("OK") == false)
                    Console.WriteLine("Suma specificata e incorecta");
                else
                    suma += introdus;
                Console.Clear();
            }
            while (buffer.ToUpper().Equals("OK") == false);
            sold += suma;
        }

        public void Extragere(int suma)
        {
            if (sold > suma)
                sold -= suma;
            else
                Console.WriteLine("Sold indisponibil");
        }

        static void Main(string[] args)
        {
            int operatie;
            string buffer;
            Cont[] user = new Cont[4];
            user[1] = new Cont(4972);
            user[2] = new Cont(2364);
            user[3] = new Cont(3649);

            while (true)
            {
                Console.WriteLine("Alegeti un user(1-3):");
                int nrUser = 0;
                buffer = Console.ReadLine();
                Console.Clear();
                if (int.TryParse(buffer, out nrUser) == false || nrUser > 3)
                {
                    Console.WriteLine("Id invalid");
                    continue;
                }
                else
                {
                    int incercari = 3;
                    bool check = false;
                    int pin;
                    do
                    {
                        Console.WriteLine("Introduceti PIN-ul, mai aveti " + incercari + " incercari");
                        buffer = Console.ReadLine();
                        if (int.TryParse(buffer, out pin) == false || pin != user[nrUser].PIN)
                        {
                            Console.WriteLine("PIN-ul introdus este incorect");
                            incercari--;
                        }
                        else
                            check = true;
                    }
                    while (incercari > 0 && check == false);
                    Console.Clear();
                    if (incercari == 0)
                    {
                        Console.WriteLine("Logare esuata");
                        continue;
                    }
                        
                }
                       


                while (true)
                {
                    Console.WriteLine("Alegeti o operatie:");
                    Console.WriteLine("1. Verificare sold");
                    Console.WriteLine("2. Retragere numerar");
                    Console.WriteLine("3. incarcare cont");
                    buffer = Console.ReadLine();
                    if (int.TryParse(buffer, out operatie) == false)
                        operatie = 0;
                    Console.Clear();

                    switch (operatie)
                    {
                        case 1:
                            user[nrUser].VerificareSold();
                            break;
                        case 2:
                            user[nrUser].RetragereNumerar();
                            break;
                        case 3:
                            user[nrUser].IncarcareCont();
                            break;
                        default:
                            Console.WriteLine("Operatie invalida");
                            break;
                    }

                    Console.WriteLine("Doriti sa efectuati o alta operatie? (da/nu)");
                    string raspuns = Console.ReadLine();
                    Console.Clear();
                    if (raspuns.ToLower().Equals("da"))
                        continue;
                    else
                        break;
                }
                Console.WriteLine("Doriti sa alegeti un alt user? (da/nu)");
                string Raspuns = Console.ReadLine();
                Console.Clear();
                if (Raspuns.ToLower().Equals("da"))
                    continue;
                else
                    break;
            }
        }
    }
}
