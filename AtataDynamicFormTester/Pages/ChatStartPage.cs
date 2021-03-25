

using Atata;
using AtataDynamicFormTester.Controls;

namespace AtataDynamicFormTester
{
    using _ = ChatStartPage;

    [WaitForLoadingIndicator]
    class ChatStartPage : Page<_>
    {
        public ControlList<DynamicControl<_>, _> SurveyFields { get; private set; }

        public Button<Chatting, _> StartChat { get; private set; }

        /// <summary>
        /// set the whole survey up with random fields
        /// </summary>
        /// <returns></returns>
        public _ SetRandom()
        {
            foreach (var field in SurveyFields)
            {
                field.SetRandom();
            }

            return this;
        }
    }
}
