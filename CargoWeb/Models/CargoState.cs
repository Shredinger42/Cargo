using System.ComponentModel;

namespace CargoWeb.Models
{
    public enum CargoState
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
