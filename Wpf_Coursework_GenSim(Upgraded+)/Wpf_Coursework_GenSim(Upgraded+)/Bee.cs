using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Collections;

namespace Wpf_Coursework_GenSim_Upgraded__
{
    class GeneticSimulator
    {
        public class Bee : BeePrototype
        {
            string name;
            public enum _Product { HoneyComb = 0, FrozenComb, WetComb, DryComb }
            _Product product;
            public enum _BeeType { Meadow = 0, Frost, Forest, Desert }
            _BeeType beeType;
            string effects;
            public struct _Conditions//доделать для идеальной работы(но ето не точно)
            {
                int temperature;
                int humidity;
                public enum _Flowers { Plains = 0, Swamp, Jungle, Desert };
                _Flowers flowers;
                public enum _Biom { Plains = 0, Swamp, Jungle, Desert };
                _Biom biom;

                public _Conditions(int temperature = 30, int humidity = 50, _Flowers flowers = _Flowers.Plains, _Biom biom = _Biom.Plains) : this()
                {
                    Temperature = temperature;
                    Humidity = humidity;
                    Flowers = flowers;
                    Biom = biom;
                }
                public int Temperature
                {
                    set
                    {
                        if (value >= -50 && value <= 100)
                            this.temperature = value;
                        else
                            this.temperature = 30;
                    }
                    get
                    {
                        return this.temperature;
                    }
                }
                public int Humidity
                {
                    set
                    {
                        if (value >= 0 && value <= 100)
                            this.humidity = value;
                        else
                            this.temperature = 50;
                    }
                    get
                    {
                        return this.humidity;
                    }
                }
                public _Flowers Flowers
                {
                    set
                    {
                        this.flowers = value;
                    }
                    get
                    {
                        return this.flowers;
                    }
                }
                public _Biom Biom
                {
                    set
                    {
                        this.biom = value;
                    }
                    get
                    {
                        return this.biom;
                    }
                }
            }
            _Conditions conditions;
            public struct _Gens//на доработке(дополнить).ДАНО ТОЛЬКО 1 ГЕН!(А вернее "общий" тип генов)
            {
                bool dominant;
                bool clone;
                public _Gens(bool dominant = false, bool clone = false/*clone держать в конце*/) : this() { Dominant = dominant; Clone = clone; }
                public bool Dominant
                {
                    set
                    {
                        this.dominant = value;
                    }
                    get
                    {
                        return this.dominant;
                    }
                }
                public bool Clone
                {
                    set
                    {
                        this.clone = value;
                    }
                    get
                    {
                        return this.clone;
                    }
                }
            }
            _Gens gens;
            Image image;

            public Bee(Image image = null, string name = "NoName", _Product product = _Product.HoneyComb, _BeeType beeType = _BeeType.Meadow,
                string effects = "None", _Conditions conditions = new _Conditions(), _Gens gens = new _Gens())
            {
                Name = name;
                Product = product;
                BeeType = beeType;
                Conditions = conditions;
                Gens = gens;
                Effects = effects;
                if (image == null)
                    image = Image.FromFile("bin/Debug/Images/Bees/CommonBee.png");
                else
                    Image = image;
            }
            public Bee(Bee source)//конструктор-копії
            {
                Name = source.Name;
                Product = source.Product;
                BeeType = source.BeeType;
                Conditions = source.Conditions;
                Gens = source.Gens;
                Effects = source.Effects;
            }
            public Bee(BeePrototype source)//конструктор-копії
            {
                Name = source.Name;
                Product = source.Product;
                BeeType = source.BeeType;
                Conditions = source.Conditions;
                Gens = source.Gens;
                Effects = source.Effects;
            }
            #region Properties
            public string Name//name of Bee
            {
                set
                {
                    this.name = value;
                }
                get
                {
                    return this.name;
                }
            }
            public _Product Product//what this bee can produce
            {
                set
                {//Доделать сет, на проверку входящих значений
                    this.product = value;
                }
                get
                {
                    return this.product;
                }
            }
            public _BeeType BeeType//from which bees it created
            {
                set
                {//Доделать сет, на проверку входящих значений
                    this.beeType = value;
                }
                get
                {
                    return this.beeType;
                }
            }
            public _Conditions Conditions//for life(temperature,humidity,flowers,biom)
            {
                set
                {//Доделать сет, на проверку входящих значений
                    this.conditions = value;
                }
                get
                {
                    return this.conditions;
                }
            }
            //public Producing Producing//When(and Where) product can created
            //{
            //    set
            //    {//Доделать сет, на проверку входящих значений
            //        this.Producing = value;
            //    }
            //    get
            //    {
            //        return this.Producing;
            //    }
            //}
            public _Gens Gens
            {
                set
                {// Доделать сет, на проверку входящих значений
                    this.gens = value;
                }
                get
                {
                    return this.gens;
                }
                ///public void DominantGens//gens that dominate on others
                ///public void RecessiveGens//recessive gen that can be dominated by others
            }
            public string Effects//effects that bees produce when gamer nearby
            {
                set
                {
                    this.effects = value;
                }
                get
                {
                    return this.effects;
                }
            }
            public Image Image//Image of bee
            {
                set
                {
                    if(value == null)
                        this.image = Image.FromFile("bin/Debug/Images/Bees/CommonBee.png");
                    else if (value.GetType() == image.GetType())
                        this.image = value;
                    else
                        this.image = Image.FromFile("bin/Debug/Images/Bees/CommonBee.png");
                }
                get
                {
                    return this.image;
                }
            }
            #endregion
            public BeePrototype _Clone()
            {
                Bee bee = new Bee(this);
                bee.gens.Clone = true;
                return bee;
            }
            public void ConcretePrototype(BeePrototype b)
            {
                Bee b_ = b as Bee;
                Product = b_.Product;
                BeeType = b_.beeType;
                Conditions = b_.Conditions;
                Gens = b_.Gens;
                Effects = b_.Effects;
                Image = b_.Image;
            }
        }
        public class BeesRegistry//prototypeRegistry
        {
            List<Bee> standartBees = new List<Bee>();//List of bees that can be
            public BeesRegistry() { }
            public void AddBee(Image image,string name, Bee._Product product, Bee._BeeType beeType, string effects, Bee._Conditions conditions, Bee._Gens gens)//Add 1 bee to the List
            {
                standartBees.Add(new Bee(image, name, product, beeType, effects, conditions, gens));
            }
            public void AddBee(Bee bee)//Add 1 bee to the List
            {
                standartBees.Add(bee);
            }
            public void AddBee(BeePrototype bee)//Add 1 bee to the List
            {
                standartBees.Add(new Bee(bee));
            }
            public void RemoveBee(Bee beeToRemove) { standartBees.Remove(beeToRemove); }
            public void RemoveBee(int index) { if (index >= 0 && index < standartBees.Count) standartBees.Remove(standartBees[index]); }
            public void RemoveBee(string name)
            {
                Bee searchResult = standartBees.Find(x => x.Name == name);
                if (searchResult != null)
                    standartBees.Remove(searchResult);
            }
            public Bee Find(string name) { return standartBees.Find(x => x.Name == name); }
            public Bee Find(int item)
            {

                if (item >= 0 && item < standartBees.Count)
                    return standartBees[item];
                else
                    return null;
            }
            public void Clear() { standartBees.Clear(); }
            public void Info(int item)//all information about bee// сделать перегрузку
            {
                //Here isn't coded an Image output.
                if (item >= 0 && item < standartBees.Count)
                {
                    Console.WriteLine("Name: " + standartBees[item].Name);
                    Console.WriteLine("Product: " + standartBees[item].Product);
                    Console.WriteLine("BeeType: " + standartBees[item].BeeType);
                    Console.WriteLine();
                }
            }
            public void Info(Bee bee)//all information about bee// сделать перегрузку
            {
                //Here isn't coded an Image output.
                Console.WriteLine("Name: " + bee.Name);
                Console.WriteLine("Product: " + bee.Product);
                Console.WriteLine("BeeType: " + bee.BeeType);
                Console.WriteLine();
            }
            public void ShowAll()
            {
                foreach (Bee element in standartBees)
                    Info(element);
            }
            //public void Info(string name)
            //{
            //    Console.WriteLine("Name: " + Find(name).Name);
            //    Console.WriteLine("Product: " + Find(name).Product);
            //    Console.WriteLine("BeeType: " + Find(name).BeeType);
            //    Console.WriteLine();
            //}
            public void ExtendedShowAll()
            {
                foreach (Bee element in standartBees)
                    ExtendedInfo(element);
            }
            public void ExtendedInfo(Bee elem)
            {
                //Here isn't coded an Image output.
                Console.WriteLine("Name: " + elem.Name);
                Console.WriteLine("Product: " + elem.Product);
                Console.WriteLine("BeeType: " + elem.BeeType);
                Console.WriteLine("Effects: " + elem.Effects);
                Console.WriteLine("Conditions");
                Console.WriteLine("Biom: " + elem.Conditions.Biom);
                Console.WriteLine("Flowers: " + elem.Conditions.Flowers);
                Console.WriteLine("Humidity: " + elem.Conditions.Humidity);
                Console.WriteLine("Temperature: " + elem.Conditions.Temperature);
                Console.WriteLine("Gens");
                Console.WriteLine("Dominant: " + elem.Gens.Dominant);
                Console.WriteLine("Clone: " + elem.Gens.Clone);
                Console.WriteLine();
            }
            public int LastIndex
            {
                get
                {
                    return standartBees.Count;
                }
            }
            public void StandartPack()//Adding bees to standart pack
            {
                AddBee(new Bee(null, "1", Bee._Product.HoneyComb, Bee._BeeType.Meadow, "No",
                    new Bee._Conditions(30, 50, Bee._Conditions._Flowers.Plains, Bee._Conditions._Biom.Plains),
                    new Bee._Gens(true)));
                AddBee(new Bee(null, "2", Bee._Product.DryComb, Bee._BeeType.Desert, "No",
                    new Bee._Conditions(55, 20, Bee._Conditions._Flowers.Desert, Bee._Conditions._Biom.Desert),
                    new Bee._Gens(true)));
                AddBee(new Bee(null, "3", Bee._Product.WetComb, Bee._BeeType.Forest, "Poisonous",
                    new Bee._Conditions(40, 85, Bee._Conditions._Flowers.Jungle, Bee._Conditions._Biom.Jungle),
                    new Bee._Gens(true)));
                AddBee(new Bee(null, "4", Bee._Product.FrozenComb, Bee._BeeType.Frost, "Icy",
                    new Bee._Conditions(0, 30, Bee._Conditions._Flowers.Swamp, Bee._Conditions._Biom.Swamp),
                    new Bee._Gens(true)));
            }
            public List<Bee> GetList()
            {
                return this.standartBees;
            }
        }
        public interface BeePrototype //prototype
        {
            BeePrototype _Clone();

            string Name { get; set; }//name of Bee;
            Bee._Product Product { get; set; }//what this bee can produce;
            Bee._BeeType BeeType { get; set; }//from which bees it created;
            Bee._Conditions Conditions { get; set; }//for life(temperature,humidity,flowers,biom);
            Bee._Gens Gens { get; set; }//Gens of Bee;
            string Effects { get; set; }//effects that bees produce when gamer nearby;
            Image Image { get; set; }//Image of Bee;
        }

        //All under this line is for C# realization of output in Console of Windows.

        //static void ShowMenu()
        //{
        //    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        //    Console.WriteLine("|  1 - Add Bee                   |");
        //    Console.WriteLine("|  2 - Remove Bee                |");
        //    Console.WriteLine("|  3 - Find Bee (with name)      |");
        //    Console.WriteLine("|  4 - Show all bees             |");
        //    Console.WriteLine("|  5 - Show all bees [extended]  |");
        //    Console.WriteLine("|  6 - Show concrete             |");
        //    Console.WriteLine("|  7 - Show concrete [extended]  |");
        //    Console.WriteLine("|  0 - Exit                      |");
        //    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        //}
        //#region Enter
        //static string EnterStr
        //{
        //    get
        //    {
        //        Console.WriteLine("Enter text:");
        //        return Console.ReadLine();
        //    }
        //}
        //static int EnterInt
        //{
        //    get
        //    {
        //        Console.WriteLine("Enter number:");
        //        int number = 0;
        //        Regex regex = new Regex(@"\d+");
        //        var match = regex.Match(Console.ReadLine());
        //        if (match.Success)
        //            number = int.Parse(match.Value);
        //        return number;
        //    }
        //}
        //static bool EnterBool
        //{
        //    get
        //    {
        //        Console.WriteLine("Enter bool(True or False?):");
        //        bool result = false;
        //        Regex regex = new Regex(@"True", RegexOptions.IgnoreCase);
        //        var match = regex.Match(Console.ReadLine());
        //        while (match.Success)
        //        {
        //            if (match.Value.ToLower() == "true")
        //                result = true;
        //            match = match.NextMatch();
        //        }
        //        return result;
        //    }
        //}
        //static Bee._Product EnterProd
        //{
        //    get
        //    {
        //        int result;
        //        do
        //        {
        //            Console.WriteLine("Product");
        //            Console.WriteLine("1 - HoneyComb");
        //            Console.WriteLine("2 - FrozenComb");
        //            Console.WriteLine("3 - WetComb");
        //            Console.WriteLine("4 - DryComb");
        //            string text = Console.ReadLine();
        //            if (text[0] >= 48 && text[0] <= 57 - 5/*"5"*/)
        //            {
        //                result = text[0] - 48;
        //                break;
        //            }
        //            else
        //                Console.WriteLine("Incorrect product");
        //        } while (true);
        //        return (Bee._Product)result - 1;
        //    }
        //}
        //static Bee._BeeType BeeType
        //{
        //    get
        //    {
        //        int result;
        //        do
        //        {
        //            Console.WriteLine("Type of bee");
        //            Console.WriteLine("1 - Meadow");
        //            Console.WriteLine("2 - Frost");
        //            Console.WriteLine("3 - Forest");
        //            Console.WriteLine("4 - Desert");
        //            string text = Console.ReadLine();
        //            if (text[0] >= 48 && text[0] <= 57 - 5/*"5"*/)
        //            {
        //                result = text[0] - 48;
        //                break;
        //            }
        //            else
        //                Console.WriteLine("Incorrect type");
        //        } while (true);
        //        return (Bee._BeeType)result - 1;
        //    }
        //}
        //static Bee._Conditions._Flowers Flowers
        //{
        //    get
        //    {
        //        int result;
        //        do
        //        {
        //            Console.WriteLine("Flowers");
        //            Console.WriteLine("1 - Plains");
        //            Console.WriteLine("2 - Swamp");
        //            Console.WriteLine("3 - Jungle");
        //            Console.WriteLine("4 - Desert");
        //            string text = Console.ReadLine();
        //            if (text[0] >= 48 && text[0] <= 57 - 5/*"5"*/)
        //            {
        //                result = text[0] - 48;
        //                break;
        //            }
        //            else
        //                Console.WriteLine("Incorrect flowers");
        //        } while (true);
        //        return (Bee._Conditions._Flowers)result - 1;
        //    }
        //}
        //static Bee._Conditions._Biom Biom
        //{
        //    get
        //    {
        //        int result;
        //        do
        //        {
        //            Console.WriteLine("Biom");
        //            Console.WriteLine("1 - Plains");
        //            Console.WriteLine("2 - Swamp");
        //            Console.WriteLine("3 - Jungle");
        //            Console.WriteLine("4 - Desert");
        //            string text = Console.ReadLine();
        //            if (text[0] >= 48 && text[0] <= 57 - 5/*"5"*/)
        //            {
        //                result = text[0] - 48;
        //                break;
        //            }
        //            else
        //                Console.WriteLine("Incorrect flowers");
        //        } while (true);
        //        return (Bee._Conditions._Biom)result - 1;
        //    }
        //}
        //static Bee._Conditions Conditions
        //{
        //    get
        //    {
        //        int temperature = 0;
        //        int humidity = 50;
        //        do { Console.WriteLine("Temperature"); temperature = EnterInt; } while (temperature < -50 || temperature > 100);
        //        do { Console.WriteLine("Humidity"); humidity = EnterInt; } while (humidity < 0 || humidity > 100);
        //        Bee._Conditions condition = new Bee._Conditions(temperature, humidity, Flowers, Biom);
        //        return condition;
        //    }
        //}
        //static Bee._Gens Gens
        //{
        //    get
        //    {
        //        Console.WriteLine("dominant");
        //        bool dominant = EnterBool;
        //        return new Bee._Gens(dominant);
        //    }
        //}
        //#endregion
        //static Bee BeeGetter
        //{
        //    get
        //    {
        //        Console.WriteLine("Enter name");
        //        string name = EnterStr;
        //        Console.WriteLine("Enter effect");
        //        string effect = EnterStr;
        //        return new Bee(name, EnterProd, BeeType, effect, Conditions, Gens);
        //    }
        //}
        //static int Item(BeesRegistry registry)
        //{
        //    int item;
        //    do
        //    {
        //        Console.WriteLine("Enter index of bee");
        //        item = EnterInt;
        //        if (item >= 0 && item < registry.LastIndex)
        //            break;
        //        else
        //            Console.WriteLine("Incorrect index");
        //    } while (true);
        //    return item;
        //}

        //static void Remove(BeesRegistry registry)
        //{
        //    Console.WriteLine("Remove");
        //    Console.WriteLine("0 - Exit");
        //    Console.WriteLine("1 - Show all bees");
        //    Console.WriteLine("2 - Delete with index");
        //    Console.WriteLine("3 - Delete with name");
        //    Console.WriteLine("4 - Delete concrete bee");
        //    Console.WriteLine("5 - Delete ALL");
        //    switch (Console.ReadLine()[0])
        //    {
        //        case '1':
        //            registry.ShowAll();
        //            break;
        //        case '2':
        //            registry.RemoveBee(EnterInt);
        //            break;
        //        case '3':
        //            registry.RemoveBee(EnterStr);
        //            break;
        //        case '4':
        //            registry.RemoveBee(BeeGetter);
        //            break;
        //        case '5':
        //            registry.Clear();
        //            break;
        //        case '0':
        //            break;
        //        default:
        //            Console.WriteLine("Incorrect input");
        //            break;
        //    }
        //}

        /*static void Main()
        {
            BeesRegistry registry = new BeesRegistry();
            bool exit = false;

            #region Added bees
            registry.AddBee(new Bee("1", Bee._Product.HoneyComb, Bee._BeeType.Meadow, "No",
                new Bee._Conditions(30, 50, Bee._Conditions._Flowers.Plains, Bee._Conditions._Biom.Plains),
                new Bee._Gens(true)));
            registry.AddBee(new Bee("2", Bee._Product.DryComb, Bee._BeeType.Desert, "No",
                new Bee._Conditions(55, 20, Bee._Conditions._Flowers.Desert, Bee._Conditions._Biom.Desert),
                new Bee._Gens(true)));
            registry.AddBee(new Bee("3", Bee._Product.WetComb, Bee._BeeType.Forest, "Poisonous",
                new Bee._Conditions(40, 85, Bee._Conditions._Flowers.Jungle, Bee._Conditions._Biom.Jungle),
                new Bee._Gens(true)));
            registry.AddBee(new Bee("4", Bee._Product.FrozenComb, Bee._BeeType.Frost, "Icy",
                new Bee._Conditions(0, 30, Bee._Conditions._Flowers.Swamp, Bee._Conditions._Biom.Swamp),
                new Bee._Gens(true)));
            registry.AddBee(registry.Find("1")._Clone());
            registry.AddBee(registry.Find("1")._Clone());
            registry.AddBee(registry.Find("1")._Clone());
            #endregion

            do
            {
                Console.Clear();
                ShowMenu();
                string text;
                while (true)
                {
                    text = Console.ReadLine();
                    if (text.Count() == 0) continue;
                    else break;
                }
                switch (text[0])
                {
                    case '1'://Add
                        registry.AddBee(BeeGetter);
                        break;
                    case '2'://Remove
                        Remove(registry);
                        break;
                    case '3'://Find
                        registry.ExtendedInfo(registry.Find(EnterStr));
                        break;
                    case '4'://Show all bees
                        registry.ShowAll();
                        break;
                    case '5'://Show all bees [extended]
                        registry.ExtendedShowAll();
                        break;
                    case '6'://Show concrete
                        registry.Info(registry.Find(Item(registry)));
                        break;
                    case '7'://Show concrete [extended]
                        registry.ExtendedInfo(registry.Find(Item(registry)));
                        break;
                    case '0'://Exit
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
                Console.ReadKey();
            } while (!exit);
        }*/
    }
}