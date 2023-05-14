using System.Security.Cryptography.X509Certificates;
using System.Text.Json;


public class ChatOtomatis
{
    public string stok_produk { get; set; }

    public string pembayaran { get; set; }

    public string pengiriman { get; set; }
    public ChatOtomatis() { }
    public ChatOtomatis(string stok, string kirim, string bayar)
    {
        this.stok_produk = stok;
        this.pengiriman = kirim;
        this.pembayaran = bayar;
    }

    public  void ReadJSON()
    {
        string json = File.ReadAllText("D:\\About Telkom University\\Semester 4\\Konstruksi Perangkat Lunak\\Tubes\\ChatOtomatis\\ChatOtomatis\\template_chat.json");
        ChatOtomatis chat = JsonSerializer.Deserialize<ChatOtomatis>(json);

        string ketik = Console.ReadLine();
        if(ketik == "stok_produk")
        {
            Console.WriteLine(chat.stok_produk);
        } else if (ketik == "pembayaran")
        {
            Console.WriteLine(chat.pembayaran);
        } else if(ketik == "pengiriman")
        {
            Console.WriteLine(chat.pengiriman);
        }
        
    }

}


public class Program
{
    public static void Main(string[] args)
    {
        ChatOtomatis chat = new ChatOtomatis();
        chat.ReadJSON();
    }
}