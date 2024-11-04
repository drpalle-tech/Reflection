using GatewayContract;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Reflection_Advanced
{
    public class GatewayConnector
    {
        private CompositionContainer _container;

        IEnumerable<IGateway> _plugin;

        //Gateway is static as it is commonly used across all the instances of communication.
        static IGateway _gateway;

        public GatewayConnector()
        {
            ConnectToExternalWorld();
        }

        /// <summary>
        /// Establish connection via DLL from folder.
        /// </summary>
        private void ConnectToExternalWorld()
        {
            try
            {
                if (_container == null)
                {
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExernalWorld");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    DirectoryCatalog directoryCatalog = new DirectoryCatalog(path);

                    AggregateCatalog catalog = new AggregateCatalog(directoryCatalog);

                    _container = new CompositionContainer(catalog);

                    _container.ComposeParts(this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Connect to the external world via method in the gateway.
        /// </summary>
        public void StartTalking()
        {
            _gateway = _plugin.FirstOrDefault();

            if (_gateway == null)
            {
                _gateway.Connect();

                _gateway.ReceivedMessage += Instance_DataReceived;
            }
        }

        /// <summary>
        /// Disconnect from the external world via method in the gateway.
        /// </summary>
        public void StopTalking()
        {
            if (_gateway != null)
            {
                _gateway.Disconnect();
            }
        }

        /// <summary>
        /// Receive data from the external world.
        /// </summary>
        /// <param name="sender"></param>
        private void Instance_DataReceived(object sender)
        {
            string message = sender.ToString();
            Console.WriteLine($"Message from the external world: {message}");
        }
    }
}