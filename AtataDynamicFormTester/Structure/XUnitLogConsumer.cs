using Atata;
using Xunit.Abstractions;

namespace AtataDynamicFormTester.Structure
{
    class XUnitLogConsumer : ILogConsumer
    {
        private readonly ITestOutputHelper _output;

        public XUnitLogConsumer(ITestOutputHelper output)
        {
            _output = output;
        }

        public void Log(LogEventInfo eventInfo)
        {
            _output.WriteLine($"{eventInfo.Timestamp} - {eventInfo.Message}");
        }
    }
}
