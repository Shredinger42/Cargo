using System.ComponentModel;

namespace CargoWeb.DbModels
{
    public enum CargoStateDb
    {
        [Description("Новая")]
        New,
        [Description("Передано на выполнение")]
        Submitted,
        [Description("Выполнено")]
        Done,
        [Description("Отменена")]
        Canceled
    }
}
