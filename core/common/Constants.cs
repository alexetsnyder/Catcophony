using Quasar.core.naming;

namespace Quasar.core.common
{
    public static partial class Constants
    {
        public static class Names
        {
            public static readonly FastName Self = new("Self");
            public static readonly FastName Position = new("Self.Postion");
            public static readonly FastName Item = new("Self.Item");
            public static readonly FastName ItemPos = new("Item.Postion");
            public static readonly FastName AgentWorkType = new("Self.WorkType");
            public static readonly FastName LocalPos = new("Work.LocalPos");
            public static readonly FastName CurrentWorkType = new("Work.SelectedWorkType");
            public static readonly FastName SelectedWork = new("Work.SelectedWork");
            public static readonly FastName SelectedPath = new("Work.SelectedPath");
        }
    }
}