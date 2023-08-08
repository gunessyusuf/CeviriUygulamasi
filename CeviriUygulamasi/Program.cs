namespace CeviriUygulamasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> sozluk = new Dictionary<string, string>()
            {
                {"hello", "merhaba" },
                {"world", "dünya" },
            };

            Console.WriteLine("Çevrilecek metni giriniz: ");
            string metin = Console.ReadLine();

            Console.WriteLine("Hedef dil(İngilizce/Türkçe)");
            string hedefDil = Console.ReadLine();

            string ceviri = Cevir(metin, hedefDil, sozluk);

            Console.WriteLine("Çeviri: " + ceviri);


        }

        static string Cevir(string metin, string hedefDil, Dictionary<string, string> sozluk)
        {
            metin = metin.ToLower();

            string[] kelimeler = metin.Split(' ');

            string ceviri = "";

            foreach (string kelime in kelimeler)
            {
                string cevrilenKelime = "";
                if (hedefDil.ToLower() == "türkçe")
                {
                    if (sozluk.ContainsKey(kelime))
                    {
                        cevrilenKelime = sozluk[kelime];
                    }
                    else
                    {
                        // Sözlükte çevirisi bulunmayan kelimeleri aynen yazdırıyoruz.
                        cevrilenKelime = kelime;
                    }
                }
                else if (hedefDil.ToLower() == "ingilizce")
                {
                    if (sozluk.ContainsValue(kelime))
                    {
                        foreach (var item in sozluk)
                        {
                            if (item.Value == kelime)
                            {
                                cevrilenKelime = item.Key;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cevrilenKelime = kelime;
                    }
                }

                ceviri += cevrilenKelime + " ";
            }

            return ceviri.Trim();

        }
    }
}