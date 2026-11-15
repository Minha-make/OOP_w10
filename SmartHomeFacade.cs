/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

using System;

namespace SmartHomeMini;

/// <summary>
/// Lop Facade cung cap giao dien muc cao don gian de thuc hien cac kich ban dieu khien nha thong minh.
/// </summary>
public sealed class SmartHomeFacade
{
    private readonly IDevice light;
    private readonly IDevice fan;
    private readonly ILockable door;

    /// <summary>
    /// Khoi tao Facade voi cac thiet bi thanh phan trong ngoi nha.
    /// </summary>
    /// <param name="light">Thiet bi den.</param>
    /// <param name="fan">Thiet bi quat.</param>
    /// <param name="door">Thiet bi cua ho tro khoa.</param>
    public SmartHomeFacade(IDevice light, IDevice fan, ILockable door)
    {
        this.light = light;
        this.fan = fan;
        this.door = door;
    }

    /// <summary>
    /// Kich ban khi roi nha di lam: tat den, tat quat, khoa cua.
    /// </summary>
    public void GoToWork()
    {
        this.light.TurnOff();
        this.fan.TurnOff();
        this.door.Lock();
    }

    /// <summary>
    /// Kich ban khi chuan bi di ngu: tat quat, khoa cua, bat den ngu theo muc sang cau hinh.
    /// </summary>
    public void GoToSleep()
    {
        this.fan.TurnOff();
        this.door.Lock();
        this.light.TurnOn();

        // Doc cau hinh muc sang ban dem tu Singleton
        int level = HomeConfiguration.Instance.NightLightLevel;
        Console.WriteLine($"Night light level: {level}%");
    }
}
