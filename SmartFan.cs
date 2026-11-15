/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

using System;

namespace SmartHomeMini;

/// <summary>
/// Dai dien cho thiet bi quat thong minh trong he thong.
/// </summary>
public class SmartFan : IDevice
{
    private readonly string name;
    private bool isOn;

    /// <summary>
    /// Thuoc tinh chi-doc cho biet quat dang bat hay tat.
    /// </summary>
    public bool IsOn => this.isOn;

    /// <summary>
    /// Khoi tao quat thong minh voi ten goi cu the.
    /// </summary>
    /// <param name="name">Ten thiet bi quat.</param>
    public SmartFan(string name)
    {
        this.name = name;
        this.isOn = false;
    }

    /// <summary>
    /// Bat quat va in trang thai ra man hinh.
    /// </summary>
    public void TurnOn()
    {
        this.isOn = true;
        Console.WriteLine($"{this.name}: ON");
    }

    /// <summary>
    /// Tat quat va in trang thai ra man hinh.
    /// </summary>
    public void TurnOff()
    {
        this.isOn = false;
        Console.WriteLine($"{this.name}: OFF");
    }
}
