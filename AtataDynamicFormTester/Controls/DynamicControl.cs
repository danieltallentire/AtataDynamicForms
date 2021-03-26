using Atata;

namespace AtataDynamicFormTester.Controls
{
    [ControlDefinition(ContainingClass = "form-group")]
    [FindFirst(TargetAllChildren = true)]
    class DynamicControl<TOwner> : Control<TOwner> where TOwner : PageObject<TOwner>
    {
        public TextInput<TOwner> TextInput { get; private set; }

        // checkboxes aren't wrapped by a nice form-control wrapper, so have to use a different search method
        [FindById(TermMatch.StartsWith, "fld")]
        public CheckBox<TOwner> Checkbox { get; private set; }

        public DateInput<TOwner> DateInput { get; private set; }

        public EmailInput<TOwner> EmailInput { get; private set; }

        public Select<TOwner> Select { get; private set; }

        public void SetRandom()
        {
            if (Checkbox.IsPresent)
            {
                Checkbox.Set(true);
            }
            else if (Select.IsPresent)
            {
                Select.Set(Select.Options[Randomizer.GetInt(0, Select.Options.Count - 1)].Value);
            }
            else if (TextInput.IsPresent)
            {
                TextInput.SetRandom();
            }
            else if (DateInput.IsPresent)
            {
                DateInput.SetRandom();
            }
            else if (EmailInput.IsPresent)
            {
                EmailInput.Set(Randomizer.GetString("{0}@{0}.com"));
            }
        }
    }
}
