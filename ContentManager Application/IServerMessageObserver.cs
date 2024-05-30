namespace ContentManager_Application
{
    public interface IServerMessageObserver
    {
        bool HandleMessage(string data);
    }
}
