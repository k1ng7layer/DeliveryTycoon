using Ecs.UidGenerator;

namespace Game.Utils.Contract
{
    public readonly struct ChangeCouriersData
    {
        private readonly Uid _contractUid;
        private readonly int _couriersDelta;

        public ChangeCouriersData(Uid contractUid, int couriersDelta)
        {
            _contractUid = contractUid;
            _couriersDelta = couriersDelta;
        }
    }
}