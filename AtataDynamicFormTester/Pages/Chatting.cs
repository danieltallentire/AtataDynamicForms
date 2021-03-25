using Atata;

namespace AtataDynamicFormTester
{
    using _ = Chatting;

    class Chatting : Page<_>
    {

        [FindById("chatReply")]
        public TextArea<_> ChatReply { get; private set; }

        [FindById("exitbtn")]
        public Button<_> CloseWindowButton { get; private set; }

        [FindById("sendbtn")]
        public Button<_> SendButton { get; private set; }
    }
}
