using MetaWeatherLibrary;

namespace MetaWeatherConsole
{
    public class Application : IApplication
    {
        private readonly IBusinessLogic _BusinessLogic;

        public Application(IBusinessLogic businessLogic)
        {
            _BusinessLogic = businessLogic;
        }

        public void Run()
        {
            _BusinessLogic.StartLogic();
        }
    }
}