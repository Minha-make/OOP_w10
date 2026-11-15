/****************/
/* Ma sinh vien: 202418890
   Ho ten: Nguyen Minh Ha */
/****************/

namespace SmartHomeMini;

/// <summary>
/// Giao dien dinh nghia hanh vi khoa va mo khoa cho cac thiet bi ho tro an ninh.
/// </summary>
public interface ILockable
{
    /// <summary>
    /// Khoa thiet bi.
    /// </summary>
    void Lock();

    /// <summary>
    /// Mo khoa thiet bi.
    /// </summary>
    void Unlock();
}
