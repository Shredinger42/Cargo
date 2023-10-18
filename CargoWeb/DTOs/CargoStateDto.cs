using System.ComponentModel;

namespace CargoWeb.DTOs
{
    public enum CargoStateDto
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
