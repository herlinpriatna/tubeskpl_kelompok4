using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TubesKPL
{
    public class ChatConfig
    {
        public string stok_produk { get; set; }
        public string pembayaran { get; set; }
        public string pengiriman { get; set; }

        public string konfirmasi(int angka)
        {
            string pesan = "";
            if(angka == 1)
            {
                pesan = stok_produk;
            } else if (angka == 2)
            {
                pesan = pembayaran;
            } else if(angka == 3)
            {
                pesan = pengiriman;
            }
            return pesan;
        }

        public ChatConfig() { }
        public ChatConfig(string stok_produk, string pembayaran, string pengiriman)
        {
            this.stok_produk = stok_produk;
            this.pembayaran = pembayaran;
            this.pengiriman = pengiriman;
        }
    }

    public class ChatBot
    {
        public ChatConfig chatConfig;
        string json = File.ReadAllText("D:\\About Telkom University\\Semester 4\\Konstruksi Perangkat Lunak\\Tubes\\ChatOtomatis\\ChatOtomatis\\template_chat.json");
           public ChatBot() 
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        public ChatConfig ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(fileLocation);
            chatConfig = JsonSerializer.Deserialize<ChatConfig>(configJsonData);
            return chatConfig;
        }

        public void SetDefault()
        {
           chatConfig = new ChatConfig("stok_produk", "pembayaran", "pengiriman");

        }

        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(chatConfig, options);
            File.WriteAllText(fileLocation, jsonString);
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            ChatBot bot = new ChatBot();
            ChatConfig config = new ChatConfig();

            Console.WriteLine("------ChatBot Otomatis------");
            Console.WriteLine("Apa yang ingin Anda tanyakan?");
            Console.WriteLine("1. Stok Produk");
            Console.WriteLine("2. Metode Pembayaran");
            Console.WriteLine("3. Metode Pengiriman");
            Console.WriteLine("Pilih salah satu : ");

            string angka = Console.ReadLine();
            int pilihAngka = Convert.ToInt32(angka);
           
            if (config.konfirmasi(pilihAngka) == config.stok_produk)
            {
               Console.WriteLine(bot.chatConfig.stok_produk);
            }
            else if (config.konfirmasi(pilihAngka) == config.pembayaran)
            {
                Console.WriteLine(bot.chatConfig.pembayaran);
            }
            else if (config.konfirmasi(pilihAngka) == config.pengiriman)
            {
                Console.WriteLine(bot.chatConfig.pengiriman);
            }
            

        }
    }
}
