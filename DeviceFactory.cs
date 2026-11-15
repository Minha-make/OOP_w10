/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

using System;

namespace SmartHomeMini;

/// <summary>
/// Lop xuong (Factory) chiu trach nhiem khoi tao cac doi tuong thiet bi cu the.
/// </summary>
public static class DeviceFactory
{
    /// <summary>
    /// Tao thiet bi tuong ung dua tren chuoi dinh danh loai thiet bi va ten.
    /// </summary>
    /// <param name="type">Loai thiet bi ("light", "fan", "door").</param>
    /// <param name="name">Ten thiet bi.</param>
    /// <returns>Doi tuong cai dat IDevice.</returns>
    /// <exception cref="ArgumentException">Nem ra khi loai thiet bi khong duoc ho tro.</exception>
    public static IDevice Create(string type, string name)
    {
        // Chuan hoa chuoi loai thiet bi de khong phan biet hoa thuong va khoang trang
        return type.Trim().ToLowerInvariant() switch
        {
            "light" => new SmartLight(name),
            "fan" => new SmartFan(name),
            "door" => new SmartDoor(name),
            _ => throw new ArgumentException($"Unsupported device type: {type}")
        };
    }
}
