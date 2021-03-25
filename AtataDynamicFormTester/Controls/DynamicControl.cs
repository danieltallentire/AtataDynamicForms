using Atata;

namespace AtataDynamicFormTester.Controls
{
    [ControlDefinition(ContainingClass = "form-group")]
    class DynamicControl<TOwner> : Control<TOwner> where TOwner : PageObject<TOwner>
    {
        [FindByClass("form-control", Timeout = 0.01)]
        public Input<string, TOwner> Input { get; set; }

        // checkboxes aren't wrapped by a nice form-control wrapper, so have to use a different search method
        [FindById("fld", Timeout = 0.01)]
        [TermFindSettings(TargetAttributeType = typeof(FindByIdAttribute), Match = TermMatch.StartsWith)]
        public CheckBox<TOwner> Checkbox { get; set; }

        [FindByClass("form-control", Timeout = 0.01)]
        public DateInput<TOwner> DateInput { get; set; }

        // represents a select box
        [FindByClass("form-control", Timeout = 0.01)]
        public Select<TOwner> Select { get; set; }

        public void SetRandom()
        {
            if (Checkbox.Exists(new SearchOptions() { IsSafely = true }))
            {
                Checkbox.Set(true);
            }
            else if(Select.Exists(new SearchOptions() { IsSafely = true }))
            {
                Select.Set(Select.Options[Atata.Randomizer.GetInt(0, Select.Options.Count - 1)].Value);
            }
            else if (DateInput.Exists(new SearchOptions() { IsSafely = true}))
            {
                DateInput.SetRandom();
            }
            else if (Input.Exists(new SearchOptions() { IsSafely = true }))
            {
                switch (Input.Attributes.Type)
                {
                    case "text":
                        Input.SetRandom();
                        break;
                    case "email":
                        Input.Set(Atata.Randomizer.GetString("{0}@{0}.com"));
                        break;
                    default:
                        // ignore
                        break;

                }
            }           
        }
    }
}
