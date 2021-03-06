using Atata;
using Atata.WebDriverSetup;
using AtataDynamicFormTester.Structure;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AtataDynamicFormTester
{
    public class DynamicFormTest : IDisposable
    {
        private bool disposedValue;

        public DynamicFormTest(ITestOutputHelper output)
        {
            DriverSetup.AutoSetUp(BrowserNames.Chrome);

            AtataContext.Configure()
                .UseChrome()
                .AddLogConsumer(new XUnitLogConsumer(output))
                .WithMinLevel(LogLevel.Trace)
                .AddScreenshotFileSaving()
                .Build();

            ValueRandomizer.RegisterRandomizer<DateTime>((meta) =>
            {
                return DateTime.Now.AddDays(0 - Randomizer.GetInt(0, 10000));
            });
        }


        [Fact]
        public void FillPrechatSurvey()
        {
            Go.To<ChatStartPage>(url: "http://localhost/newchat/chat.aspx?domain=www.parkersoftware.com")
                .Report.Screenshot("Start Chat")
                .SetRandom()
                .Report.Screenshot("Filled Out")
                .StartChat.ClickAndGo()
                .Report.Screenshot("Chatting")
                .Wait(5)
                .CloseWindowButton.Click()
                .Report.Screenshot("Finished");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                AtataContext.Current?.CleanUp();
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~DynamicFormTest()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
