
namespace Automacao.Command.Kiper.Core
{
    interface ICommandBase
    {
        string DateTimeNow { get; set; }
        public string Cmd { get; set; }
        public long Id { get; set; }
    }
}
