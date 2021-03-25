

using Atata;

namespace AtataDynamicFormTester
{
    using _ = ChatStartPage;

    [WaitForLoadingIndicator]
    class ChatStartPage : Page<_>
    {
        [ControlDefinition(ContainingClass = "input-group")]
        public ControlList<Input<string, _>, _> SurveyFields { get; private set; }

        public Button<Chatting, _> StartChat { get; private set; }

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
