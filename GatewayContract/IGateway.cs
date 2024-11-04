namespace GatewayContract
{
    public delegate void Delegate(object sender);

    public interface IGateway
    {
        string Name { get; }

        void Connect();

        void Disconnect();

        event Delegate ReceivedMessage;
    }
}
