// See https://aka.ms/new-console-template for more information
using System;

namespace Account
{
    class program
    {
        public static void Main(string[] args)
        {
            AccountSystem am = new AccountSystem();
            am.currentState = AccountSystem.State.Start;

            Console.WriteLine("===========| Selamat datang |===========");

            while (am.currentState != AccountSystem.State.End)
            {
                Console.WriteLine("Pilih Menu:");
                Console.WriteLine("1. Registrasi");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. End");
                Console.WriteLine("Pilih: ");
                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        am.activeTrigger(AccountSystem.Trigger.RegistrasiBtn);
                        Console.WriteLine("\nHalaman Registrasi");
                        Console.WriteLine("Pilih tipe akun:");
                        Console.WriteLine("1. Pembeli");
                        Console.WriteLine("2. Penjual");
                        Console.WriteLine("3. Cancel");
                        Console.WriteLine("Pilih: ");
                        int regisSelect = Convert.ToInt32(Console.ReadLine());

                        switch (regisSelect)
                        {
                            case 1:
                                am.activeTrigger(AccountSystem.Trigger.pembeliSelect);
                                am.Register();
                                am.activeTrigger(AccountSystem.Trigger.Submit);
                                break;
                            case 2:
                                am.activeTrigger(AccountSystem.Trigger.penjualSelect);
                                am.Register();
                                am.activeTrigger(AccountSystem.Trigger.Submit);
                                break;
                            case 3:
                                am.activeTrigger(AccountSystem.Trigger.Cancel);
                                break;
                            default:
                                Console.WriteLine("Pilihan Invalid.");
                                break;
                        }
                        break;

                    case 2:
                        am.activeTrigger(AccountSystem.Trigger.RegistrasiBtn);
                        Console.WriteLine("\nHalaman Login");
                        Console.WriteLine("Pilih tipe akun:");
                        Console.WriteLine("1. Pembeli");
                        Console.WriteLine("2. Penjual");
                        Console.WriteLine("3. Cancel");
                        Console.WriteLine("Pilih: ");
                        int loginSelect = Convert.ToInt32(Console.ReadLine());

                        switch (loginSelect)
                        {
                            case 1:
                                am.activeTrigger(AccountSystem.Trigger.pembeliSelect);
                                am.Login();
                                am.activeTrigger(AccountSystem.Trigger.Submit);
                                am.MainScreen();
                                break;
                            case 2:
                                am.activeTrigger(AccountSystem.Trigger.penjualSelect);
                                am.Login();
                                am.activeTrigger(AccountSystem.Trigger.Submit);
                                am.MainScreen();
                                break;
                            case 3:
                                am.activeTrigger(AccountSystem.Trigger.Cancel);
                                break;
                            default:
                                Console.WriteLine("Pilihan Invalid.");
                                break;
                        }
                        break;

                    case 3:
                        am.activeTrigger(AccountSystem.Trigger.Cancel);
                        break;

                    default:
                        Console.WriteLine("Pilihan Invalid.");
                        break;
                }

            }

            Console.WriteLine("Program diberhentikan.");
        }
    }
}
