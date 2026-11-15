/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

using System;

namespace SmartHomeMini;

/// <summary>
/// Dai dien cho thiet bi cua thong minh, co the dong/mo va khoa/mo khoa.
/// </summary>
public class SmartDoor : IDevice, ILockable
{
    private readonly string name;
    private bool isOpen;
    private bool isLocked;

    /// <summary>
    /// Thuoc tinh chi-doc cho biet cua dang mo hay dong.
    /// </summary>
    public bool IsOpen => this.isOpen;

    /// <summary>
    /// Thuoc tinh chi-doc tuong duong trang thai bat/tat cua thiet bi.
    /// </summary>
    public bool IsOn => this.isOpen;

    /// <summary>
    /// Thuoc tinh chi-doc cho biet cua dang bi khoa hay khong.
    /// </summary>
    public bool IsLocked => this.isLocked;

    /// <summary>
    /// Khoi tao cua thong minh voi ten goi cu the.
    /// </summary>
    /// <param name="name">Ten thiet bi cua.</param>
    public SmartDoor(string name)
    {
        this.name = name;
        this.isOpen = false;
        this.isLocked = false;
    }

    /// <summary>
    /// Mo cua (tuong ung TurnOn cua IDevice).
    /// </summary>
    public void TurnOn()
    {
        this.isOpen = true;
        Console.WriteLine($"{this.name}: OPEN");
    }

    /// <summary>
    /// Dong cua (tuong ung TurnOff cua IDevice).
    /// </summary>
    public void TurnOff()
    {
        this.isOpen = false;
        Console.WriteLine($"{this.name}: CLOSED");
    }

    /// <summary>
    /// Khoa cua an toan.
    /// </summary>
    public void Lock()
    {
        this.isLocked = true;
        Console.WriteLine($"{this.name}: LOCKED");
    }

    /// <summary>
    /// Mo khoa cua.
    /// </summary>
    public void Unlock()
    {
        this.isLocked = false;
        Console.WriteLine($"{this.name}: UNLOCKED");
    }
}
