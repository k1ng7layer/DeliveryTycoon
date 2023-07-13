using Game.Utils;

namespace Db.EmployeeSettings
{
    public interface IEmployeeSettingsProvider
    {
        EmployeeSettings Get(ECourierType courierType);
    }
}