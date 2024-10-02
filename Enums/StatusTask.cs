using System.ComponentModel;

namespace WebApi.Enums
{
    public enum StatusTask
    {
        [Description("To do")]
        Todo = 1,
        [Description("In Progressing")]
        Progressing = 2,
        [Description("Finished")]
        Ready = 3
    }
}