using Atata;

namespace AtataDynamicFormTester.Controls
{
    [ControlDefinition(ContainingClass = "input-group")]
    class DynamicControl<TOwner> : Control<TOwner> where TOwner : PageObject<TOwner>
    {
        [FindByClass("form-control")]
        public Input<string, TOwner> TextInput { get; set; }

        public void SetRandom()
        {
            TextInput.SetRandom();
        }
    }
}
