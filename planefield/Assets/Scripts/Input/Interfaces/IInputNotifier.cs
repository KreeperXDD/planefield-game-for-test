namespace Input.Interfaces
{
    public interface IInputNotifier
    {
        public void NotifyAction<TAction>(TAction action) where TAction : IInputAction;
    }
}