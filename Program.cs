// See https://aka.ms/new-console-template for more information
using Ex._1_Laborator18_;
using Ex._1_Laborator18_.Models;

/*
 Exercitiul 1
• Un autovehicul este caracterizat de urmatoarele proprietati
• Id:int
• Nume
• Producator
• Un numar variabil de chei (de la una la oricate)
• O carte tehnica
• Cartea tehnica va avea urmatoarele:
• Id:int
• Capacitate cilindrica :int
• An de fabricatie :int
• Serie de sasiu: string

• Producatorul va avea
• Id:int
• Nume
• Adresa:string

• O cheie va avea urmatoarele caracteristici
• Id (int)
• Cod de acces : Guid unic.

• Creeati modelul, Adaugati DB, populati DB

• Scrieti urmatoarele metode
• Adaugare autovehicul
• Implica adaugarea carei entitati?
• Adaugare producator
• Adaugare cheie unui autovehicul
• Inlocuire carte tehnica
• Stergere autovehicul
• Stergere producator
• Stergere cheie

• Determinati relatiile necesare

• Determinati delete propagation-ul necesar pentru fiecare
relatie in parte
 */


ResetDb();

using var ctx = new AutoDbContext();

var renault =DataLayer.AddProducer("Renault", "France");
var dacia = DataLayer.AddProducer("Dacia", "Romania");
DataLayer.AddAutomobile("Logan", 5, 1490, 2020, "fsa4das0", 5);
DataLayer.AddKeyToAuto(2);
DataLayer.ReplaceTechnicalBoox(2, 200, "AAAAAAAAAAAA", 1256);
DataLayer.DeleteAuto(1);
DataLayer.DeleteProducer(1);
DataLayer.DeleteKey(5);
DataLayer.DeleteKey(2, 6);
DataLayer.DeleteFirstKey(2);



static void ResetDb()
{
    using var ctx = new AutoDbContext();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();

    var toyota = new Producer()
    {
        Name = "Toyota",
        Adresse = "Japan"
    };
    var corolla = new Automobile()
    {
        Name = "Corolla",
        Producer = toyota,
        Keys = new List<Key>()
        {
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            }
        },
        TechnicalBook = new TechnicalBook()
        {
            CylinderCapacity = 1490,
            VINnumber = "sad54as",
            YearOfProduction = 2020
        },

    };
    var prius = new Automobile()
    {
        Name = "Prius",
        Producer = toyota,
        Keys = new List<Key>()
        {
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            }
        },
        TechnicalBook = new TechnicalBook()
        {
            CylinderCapacity = 1800,
            VINnumber = "65sf4ad",
            YearOfProduction = 2022
        },

    };
    var yaris = new Automobile()
    {
        Name = "Yaris",
        Producer = toyota,
        Keys = new List<Key>()
        {
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            }
        },
        TechnicalBook = new TechnicalBook()
        {
            CylinderCapacity = 996,
            VINnumber = "5d4asda",
            YearOfProduction = 2019
        },

    };

    var volkswagen = new Producer()
    {
        Name = "Volkswagen",
        Adresse = "Germany"
    };

    var golf = new Automobile()
    {
        Name = "Golf",
        Producer = volkswagen,
        Keys = new List<Key>()
        {
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            }
        },
        TechnicalBook = new TechnicalBook()
        {
            CylinderCapacity = 1498,
            VINnumber = "asd4assada6546",
            YearOfProduction = 2005
        },
    };
    var passat = new Automobile()
    {
        Name = "Passat",
        Producer = volkswagen,
        Keys = new List<Key>()
        {
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            }
        },
        TechnicalBook = new TechnicalBook()
        {
            CylinderCapacity = 1968,
            VINnumber = "65as4das98d4",
            YearOfProduction = 2021
        },
    };
    var tt = new Automobile()
    {
        Name = "TT",
        Producer = volkswagen,
        Keys = new List<Key>()
        {
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            }
        },
        TechnicalBook = new TechnicalBook()
        {
            CylinderCapacity = 1998,
            VINnumber = "654644asdas6d4a",
            YearOfProduction = 2000
        },
    };

    var ford = new Producer()
    {
        Name = "Ford",
        Adresse = "USA"
    };
    var mustang = new Automobile()
    {
        Name = "Mustang",
        Producer = ford,
        Keys = new List<Key>()
        {
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            }
        },
        TechnicalBook = new TechnicalBook()
        {
            CylinderCapacity = 4951,
            VINnumber = "65s4fa4s6sdsc",
            YearOfProduction = 1981
        },
    };
    var focus = new Automobile()
    {
        Name = "Focus",
        Producer = ford,
        Keys = new List<Key>()
        {
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            },
            new Key ()
            {
                AccessCode=Guid.NewGuid()
            }
        },
        TechnicalBook = new TechnicalBook()
        {
            CylinderCapacity = 1498,
            VINnumber = "564fas5fd4asc",
            YearOfProduction = 2015
        },
    };


    ctx.Automobiles.Add(corolla);
    ctx.Automobiles.Add(focus);
    ctx.Automobiles.Add(prius);
    ctx.Automobiles.Add(yaris);
    ctx.Automobiles.Add(mustang);
    ctx.Automobiles.Add(golf);
    ctx.Automobiles.Add(passat);
    ctx.Automobiles.Add(tt);

    ctx.SaveChanges();
}