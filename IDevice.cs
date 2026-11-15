/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

namespace SmartHomeMini;

/// <summary>
/// Giao dien dinh nghia cac thao tac co ban cho thiet bi trong nha thong minh.
/// </summary>
public interface IDevice
{
    /// <summary>
    /// Bat thiet bi.
    /// </summary>
    void TurnOn();

    /// <summary>
    /// Tat thiet bi.
    /// </summary>
    void TurnOff();
}
