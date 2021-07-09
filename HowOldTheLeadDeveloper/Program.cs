using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowOldTheLeadDeveloper
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //Feladat: A fejlesztőink számának,
            //az aktív előfizetőink számának,
            //a rendszerünk fejlesztése során eddig felvett hibajegyek és fejlesztési igények számának és a
            //fejlesztési vezető életkorának szorzata 6932416653.
            //Hány éves a fejlesztési vezető?

            //Amit tudunk:
            //A fejlesztők száma: 6-10 /dreamjobs kiírás szerint/
            //Aktív előfizetők száma: a hirdetés alapján több, mint 1500, de 1714 a honlap szerint / https://www.minicrm.hu/mi-az-a-crm/ /
            //

            long multiplication = 6932416653; //a szorzat
            int numberOfDevelopers=0; //a fejlesztők száma
            int leadDevAge=0; //a vezető fejlesztő életkora
            int users = 0; //a felhasználók száma
            List<int> potencionalGoodNumbers = new List<int>(); //Lista a feltételezhetően helyes számoknak
            
            for (int i = 2; i < multiplication/17140; i++) //a feltételben elosztom a szorzatot a fejlesztők maximális számának és a felhasználók számának a szorzatával
            {
                if (multiplication % i == 0) 
                {
                    Console.WriteLine(i); // a maradék nélkül osztható számok kiíratása
                    potencionalGoodNumbers.Add(i); //a szám hozzáadása a listához

                    if (i >= 6 && i <= 10) numberOfDevelopers = i; //mivel a fejlesztők száma 6-10 közé kell, hogy essen, így feltételezhető, hogy csak egy ilyen szám létezik, 
                    if (i >= 27 && i <= 52) leadDevAge = i; //mivel a dolgozók életkora 27-52 közé kell, hogy essen (a hirderés alapján), így feltételezhető, hogy a megadott feltételek alapján csak egy megoldás lehetséges
                    if (i > 1500 && i < 2000) users = i; // felhasználók száma a hirdetés alapján 1500, a honlap alapján 1714, mivel a dreamjo.bs történeténél 2018-ban több, mint 1000, 2019-ben több, mint 1500 felasználó volt megadva, így ezek alapján feltételezhető, hogy kevesebb, mint 2000 felhasználó van jelenleg,
                }

            }

            long tickets = NumberOfTickets(multiplication,numberOfDevelopers,users,leadDevAge); //a hibajegyek és fejlesztési igények meghatázoása
            Check(potencionalGoodNumbers, tickets,multiplication,numberOfDevelopers,users,leadDevAge);//ellenőrzés

            Console.WriteLine("A prímtényezős számítás alapján:\n - a fejlesztők létszáma: {0} fő\n -az aktív felhasználók száma: {1}\n " +
                              "-az eddig felvett hibajegyek és fejlesztési igények száma: {2}\n -a vezető fejlesztő életkora: {3}",numberOfDevelopers,users,tickets,leadDevAge); //a feladat megoldásának a kiírása
            
            Console.ReadKey();
        }

        static long NumberOfTickets(long multiplication, int numberOfDevs, int users, int leadAge) //a hibajegyek és fejlesztési igények meghatázoása
        {
           return multiplication / numberOfDevs / leadAge / users;
        }
        static void Check(List<int> listOfNumbers, long tickets, long multiplication, int numberOfDevs, int users, int leadAge) //ellenőrzés, ha a prímtényezős lista tartalmazza a hibajegyek számát és ha a kiszámított változók értékeinek a szozata megegyezik a szorzattal, akkor a megoldás ebben az esetben helyes
        {
            if (listOfNumbers.Contains((int)tickets)) 
            {
                if (tickets * numberOfDevs * users * leadAge == multiplication) Console.WriteLine("Helyes a megoldás");
                else Console.WriteLine("A megoldás helytelen");
            }
            else Console.WriteLine("A megoldás helytelen");
        }
    }
}
