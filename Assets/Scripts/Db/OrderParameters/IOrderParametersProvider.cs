namespace Db.OrderParameters
{
    public interface IOrderParametersProvider
    {
        OrderParameters Get(int level);
    }
}