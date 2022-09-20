using Ex._1_Laborator18_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ex._1_Laborator18_
{
    static class DataLayer
    {
        /*
         Scrieti urmatoarele metode
         • Adaugare autovehicul
               - Implica adaugarea carei entitati?
         */

        public static Automobile AddAutomobile(string name, int producerId, int cylinderCapacity, int yearOfProduction, string VINnumber, int numberOfKeys)
        {
            List<Key> keys = new List<Key>();
            for (int i = 0; i < numberOfKeys; i++)
            {
                keys.Add(AddKey());
            }

            var auto = new Automobile()
            {
                Name = name,
                ProducerId = producerId,
                Keys = keys,
                TechnicalBook = AddTechnicalBook(cylinderCapacity, yearOfProduction, VINnumber)
            };

            using var ctx = new AutoDbContext();
            ctx.Automobiles.Add(auto);
            ctx.SaveChanges();
            return auto;
        }
        
        private static Key AddKey()
        {
            Key key = new Key()
            {
                AccessCode = Guid.NewGuid()
            };

            return key;
        }
        private static TechnicalBook AddTechnicalBook(int cylinderCapacity, int yearOfProduction, string VINnumber)
        {
            TechnicalBook technicalBook = new TechnicalBook()
            {
                CylinderCapacity = cylinderCapacity,
                VINnumber = VINnumber,
                YearOfProduction = yearOfProduction
            };

            return technicalBook;
        }
        /*
         • Adaugare producator
         */
        public static Producer AddProducer(string name, string adresse)
        {
            var producer = new Producer()
            {
                Name = name,
                Adresse = adresse
            };

            using var ctx = new AutoDbContext();
            ctx.Producers.Add(producer);
            ctx.SaveChanges();
            return new Producer();
        }
        /*
         • Adaugare cheie unui autovehicul
         */
        public static Key AddKeyToAuto(int autoId)
        {
            using var ctx = new AutoDbContext();
            var auto = ctx.Automobiles.Include(k => k.Keys).FirstOrDefault(a => a.Id == autoId);

            if (auto == null)
            {
                throw new Exception("Auto not found!");
            }

            auto.Keys.Add(AddKey());
            ctx.SaveChanges();
            return new Key();
        }
        /*
         • Inlocuire carte tehnica
         */
        public static TechnicalBook ReplaceTechnicalBoox(int autoId, int cylinderCapacity, string VINnumber, int yearOfProduction)
        {
            using var ctx = new AutoDbContext();
            var auto = ctx.Automobiles.Include(t => t.TechnicalBook).FirstOrDefault(a => a.Id == autoId);

            if (auto == null)
            {
                throw new Exception("Auto not found!");
            }

            var technicalBook = auto.TechnicalBook = new TechnicalBook()
            {
                CylinderCapacity = cylinderCapacity,
                VINnumber = VINnumber,
                YearOfProduction = yearOfProduction
            };

            ctx.SaveChanges();
            return technicalBook;
        }
        /*
         • Stergere autovehicul
         */
        public static void DeleteAuto(int autoId)
        {
            using var ctx = new AutoDbContext();
            var auto = ctx.Automobiles.FirstOrDefault(a => a.Id == autoId);
            if (auto == null)
            {
                throw new Exception("Auto not found!");
            }
            ctx.Remove(auto);
            ctx.SaveChanges();
        }
        /*
         • Stergere producator
         */
        public static void DeleteProducer(int producerId)
        {
            using var ctx = new AutoDbContext();
            var producer = ctx.Producers.Include(a => a.Automobiles).FirstOrDefault(p => p.Id == producerId);
            if (producer == null)
            {
                throw new Exception("Producer not found!");
            }
            producer.Automobiles = null;
            ctx.Remove(producer);
            ctx.SaveChanges();
        }
        /*
         • Stergere cheie
         */
        /// <summary>
        /// Deletes key by Id of key.
        /// </summary>
        /// <param name="keyId"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteKey(int keyId)
        {
            using var ctx = new AutoDbContext();

            var allKeys = ctx.Automobiles.Include(k => k.Keys).Select(k => k.Keys).ToList();

            Key keyToRemove = null;

            foreach (var listOfKeys in allKeys)
            {
                foreach (var key in listOfKeys)
                {
                    if (key.Id == keyId)
                    {
                        keyToRemove = key;
                        break;
                    }
                }
            }

            if (keyToRemove == null)
            {
                throw new Exception("Key not found!");
            }

            ctx.Remove(keyToRemove);
            ctx.SaveChanges();
        }
        /// <summary>
        /// Deletes key by Id of ato and Id of key.
        /// </summary>
        /// <param name="autoId"></param>
        /// <param name="keyId"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteKey(int autoId, int keyId)
        {
            using var ctx = new AutoDbContext();

            var auto = ctx.Automobiles.Include(k => k.Keys).FirstOrDefault(a => a.Id == autoId);
            if (auto == null)
            {
                throw new Exception("Auto not found!");
            }

            var key = auto.Keys.FirstOrDefault(k => k.Id == keyId);
            if (key == null)
            {
                throw new Exception("Key not found!");
            }

            ctx.Remove(key);
            ctx.SaveChanges();
        }
        /// <summary>
        /// Deletes first key found from auto ID.
        /// </summary>
        /// <param name="autoId"></param>
        /// <exception cref="Exception"></exception>
        public static void DeleteFirstKey(int autoId)
        {
            using var ctx = new AutoDbContext();

            var auto = ctx.Automobiles.Include(k => k.Keys).FirstOrDefault(a => a.Id == autoId);
            if (auto == null)
            {
                throw new Exception("Auto not found!");
            }

            var key = auto.Keys.FirstOrDefault();
            if (key == null)
            {
                throw new Exception("Key not found!");
            }

            ctx.Remove(key);
            ctx.SaveChanges();
        }

    }
}
