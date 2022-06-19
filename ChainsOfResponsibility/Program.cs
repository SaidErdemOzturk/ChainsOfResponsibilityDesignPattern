using System;
using System.Collections.Generic;

namespace ChainsOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Testler> testler = new List<Testler>();
            testler.Add(new KrediSkor());
            testler.Add(new OdemeGecikme());
            testler.Add(new KefilUygunlugu());
            testler.Add(new MaasYeterliligi());
            bool sonuc = true;
            testler[0].SonrakiTest = testler[1];
            testler[1].SonrakiTest = testler[2];
            testler[2].SonrakiTest = testler[3];
            Musteri m1 = new Musteri();
            m1.musteriNo = "M!";
            m1.krediSkoru = 1200;
            m1.odemeGecikmesi = 1;
            m1.maasYeterliliği = true;
            m1.kefilUygunlugu = true;

            testler[0].TestEt(m1);
            if (testler[testler.Count-1].control)
            {
                Console.WriteLine("kredi çekildi");
            }


        }
        abstract class Testler
        {
            public bool control;
            protected Testler _sonrakiTest;
            public Testler SonrakiTest
            {
                set
                {
                    _sonrakiTest = value;

                } 
            }
            public abstract void TestEt(Musteri musteri);
        }
        class KrediSkor : Testler
        {
            public override void TestEt(Musteri musteri)
            {
                if (musteri.krediSkoru<1500)
                {
                    control = false;
                    Console.WriteLine("krediskor ");
                }
                else
                {
                    control = true;
                    Console.WriteLine(control);

                    if (_sonrakiTest!=null)
                    {
                        
                        _sonrakiTest.TestEt(musteri);
                    }
                }
            } 
        }
        class OdemeGecikme : Testler
        {
            public override void TestEt(Musteri musteri)
            {
                if (musteri.odemeGecikmesi >3 )
                {
                    Console.WriteLine("odemegecikme ");

                    control = false;
                }
                else
                {
                    control = true;
                    Console.WriteLine(control);

                    if (_sonrakiTest != null)
                    {
                        _sonrakiTest.TestEt(musteri);
                    }
                }
            }
        }

        class KefilUygunlugu : Testler
        {
            public override void TestEt(Musteri musteri)
            {
                if (!musteri.kefilUygunlugu)
                {
                    Console.WriteLine("kefiluygunlugu ");

                    control = false;
                }
                else
                {

                    control = true;
                    Console.WriteLine(control);

                    if (_sonrakiTest != null)
                    {
                        _sonrakiTest.TestEt(musteri);
                    }
                }
            }
        }
        class MaasYeterliligi : Testler
        {
            public override void TestEt(Musteri musteri)
            {
                if (!musteri.maasYeterliliği)
                {
                    Console.WriteLine("maasyeterliliği ");

                    control = false;
                }
                else
                {
                    control = true;
                    Console.WriteLine(control);
                    if (_sonrakiTest != null)
                    {
                        _sonrakiTest.TestEt(musteri);
                    }
                }
            }
        }
        class Musteri
        {
            public string musteriNo { get; set; }
            public int krediSkoru { get; set; }
            public int odemeGecikmesi { get; set; }
            public bool kefilUygunlugu { get; set; }
            public bool maasYeterliliği { get; set; }
        }
    }
}
