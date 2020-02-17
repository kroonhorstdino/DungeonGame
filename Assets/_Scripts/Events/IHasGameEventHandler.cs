namespace Raptor.Events
{
    public interface IHasGameEventHandler
    {
        GameEventHandler EventHandler { get; }
    }
}