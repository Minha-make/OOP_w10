/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

using System;
using System.Text;

namespace SmartHomeMini;

/// <summary>
/// Lop khoi dong chuong trinh, thuc hien kich ban demo va chay kiem thu tu dong.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // Thiet lap hien thi UTF-8 tren cua so console
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== CHUONG TRINH DIEU KHIEN NHA THONG MINH (SMART HOME MINI) ===");

        // 1. Khoi tao 3 thiet bi thong qua DeviceFactory
        IDevice light = DeviceFactory.Create("light", "Living room light");
        IDevice fan = DeviceFactory.Create("fan", "Living room fan");
        IDevice door = DeviceFactory.Create("door", "Main door");

        // 2. Khoi tao Facade voi cac thiet bi (ep kieu door sang SmartDoor de thoa man ILockable)
        var facade = new SmartHomeFacade(light, fan, (SmartDoor)door);

        // 3. Kich hoat kich ban GoToWork()
        Console.WriteLine("\n--- Kich hoat che do: Di lam (GoToWork) ---");
        facade.GoToWork();

        // 4. Kich hoat kich ban GoToSleep()
        Console.WriteLine("\n--- Kich hoat che do: Di ngu (GoToSleep) ---");
        facade.GoToSleep();

        // 5. Chay cac ca kiem thu tu dong T1 - T5
        Tests.RunAllTests();
    }
}
