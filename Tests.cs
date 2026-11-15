/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

using System;

namespace SmartHomeMini;

/// <summary>
/// Lop chua bo kiem thu console tu T1 den T5 cho ba Design Pattern.
/// </summary>
public static class Tests
{
    /// <summary>
    /// Chay toan bo cac ca kiem thu va in ket qua PASS/FAIL ra man hinh console.
    /// </summary>
    public static void RunAllTests()
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine("    BAT DAU CHAY KIEM THU     ");
        Console.WriteLine("==============================");

        Test1_DeviceFactoryCreation();
        Test2_DeviceFactoryUnsupportedType();
        Test3_SingletonIdentity();
        Test4_FacadeGoToWork();
        Test5_FacadeGoToSleep();

        Console.WriteLine("==============================\n");
    }

    /// <summary>
    /// T1: Kiem tra Factory tao dung kieu doi tuong, ho tro chu hoa va khoang trang.
    /// </summary>
    private static void Test1_DeviceFactoryCreation()
    {
        IDevice light = DeviceFactory.Create("LIGHT", "Den phong khach");
        IDevice fan = DeviceFactory.Create(" Fan ", "Quat ban");
        IDevice door = DeviceFactory.Create("door", "Cua chinh");

        bool pass = (light is SmartLight) && (fan is SmartFan) && (door is SmartDoor);
        PrintResult("T1", "Factory tao dung kieu doi tuong (chu hoa, khoang trang)", pass);
    }

    /// <summary>
    /// T2: Kiem tra Factory nem ArgumentException khi gap loai thiet bi chua ho tro.
    /// </summary>
    private static void Test2_DeviceFactoryUnsupportedType()
    {
        bool pass = false;
        try
        {
            DeviceFactory.Create("camera", "Camera an ninh");
        }
        catch (ArgumentException)
        {
            pass = true;
        }
        catch (Exception)
        {
            pass = false;
        }

        PrintResult("T2", "Tao thiet bi 'camera' nem ArgumentException", pass);
    }

    /// <summary>
    /// T3: Kiem tra hai lan lay HomeConfiguration.Instance cung tham chieu mot doi tuong.
    /// </summary>
    private static void Test3_SingletonIdentity()
    {
        HomeConfiguration c1 = HomeConfiguration.Instance;
        HomeConfiguration c2 = HomeConfiguration.Instance;

        bool pass = ReferenceEquals(c1, c2);
        PrintResult("T3", "Hai lan lay HomeConfiguration.Instance cung tham chieu mot doi tuong", pass);
    }

    /// <summary>
    /// T4: Kiem tra GoToWork() lam den tat, quat tat, cua khoa.
    /// </summary>
    private static void Test4_FacadeGoToWork()
    {
        SmartLight light = new SmartLight("Den test T4");
        SmartFan fan = new SmartFan("Quat test T4");
        SmartDoor door = new SmartDoor("Cua test T4");

        // Dat trang thai ban dau nguoc lai: den BAT, quat BAT, cua MO KHOA
        light.TurnOn();
        fan.TurnOn();
        door.Unlock();

        SmartHomeFacade facade = new SmartHomeFacade(light, fan, door);
        facade.GoToWork();

        // Kiem tra sau khi GoToWork(): den tat, quat tat, cua khoa
        bool pass = (!light.IsOn) && (!fan.IsOn) && door.IsLocked;
        PrintResult("T4", "GoToWork() lam den tat, quat tat, cua khoa", pass);
    }

    /// <summary>
    /// T5: Kiem tra GoToSleep() lam quat tat, cua khoa, den bat va hien thi muc sang.
    /// </summary>
    private static void Test5_FacadeGoToSleep()
    {
        SmartLight light = new SmartLight("Den test T5");
        SmartFan fan = new SmartFan("Quat test T5");
        SmartDoor door = new SmartDoor("Cua test T5");

        // Dat trang thai ban dau nguoc lai: den TAT, quat BAT, cua MO KHOA
        light.TurnOff();
        fan.TurnOn();
        door.Unlock();

        SmartHomeFacade facade = new SmartHomeFacade(light, fan, door);
        facade.GoToSleep();

        // Kiem tra sau khi GoToSleep(): quat tat, cua khoa, den bat
        bool pass = (!fan.IsOn) && door.IsLocked && light.IsOn;
        PrintResult("T5", "GoToSleep() lam quat tat, cua khoa, den bat", pass);
    }

    /// <summary>
    /// In ket qua kiem thu dinh dang PASS hoac FAIL.
    /// </summary>
    private static void PrintResult(string code, string description, bool pass)
    {
        string status = pass ? "[PASS]" : "[FAIL]";
        Console.WriteLine($"{status} {code}: {description}");
    }
}
