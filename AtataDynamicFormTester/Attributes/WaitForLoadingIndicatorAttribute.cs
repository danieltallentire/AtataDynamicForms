using Atata;

namespace AtataDynamicFormTester
{
    public class WaitForLoadingIndicatorAttribute : WaitForElementAttribute
    {
        public WaitForLoadingIndicatorAttribute(TriggerEvents on = TriggerEvents.Init)
            : base(WaitBy.Class, "overlay", Until.VisibleThenMissingOrHidden, on)
        {
            // On some pages with quick loading the indicator can even not appear.
            // For such case we can decrease the time of element presence and declare that timeout exception should not be thrown.
            // Meaning if within 2 seconds the element will not appear then OK, continue the execution.
            // Note that this settings can differ depending on specific indicator behavior.
            PresenceTimeout = 2; // Sets max waiting time in seconds for the presence of an element.
            ThrowOnPresenceFailure = false; // Do not throw exception if indicator is not found.

            AbsenceTimeout = 10; // Sets max waiting time in seconds for the absence of an element.
        }
    }
}
