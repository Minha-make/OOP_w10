/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

using System;

namespace SmartHomeMini;

/// <summary>
/// Quan ly cau hinh chung cua toan bo ngoi nha theo mau Singleton dam bao an toan luong.
/// </summary>
public sealed class HomeConfiguration
{
    // Khoi tao luoi (Lazy) va an toan luong cho the hien Singleton duy nhat
    private static readonly Lazy<HomeConfiguration> lazy =
        new(() => new HomeConfiguration());

    /// <summary>
    /// Diem truy cap toan cuc den the hien duy nhat cua cau hinh ngoi nha.
    /// </summary>
    public static HomeConfiguration Instance => lazy.Value;

    /// <summary>
    /// Ten cua ngoi nha thong minh.
    /// </summary>
    public string HomeName { get; set; } = "My Home";

    /// <summary>
    /// Muc do sang cua den ngu ban dem (phan tram).
    /// </summary>
    public int NightLightLevel { get; set; } = 30;

    /// <summary>
    /// Constructor private de ngan chan khoi tao doi tuong tu ben ngoai.
    /// </summary>
    private HomeConfiguration()
    {
    }
}
