using Atata;

namespace AtataDynamicFormTester.Controls
{
    [ControlDefinition(ContainingClass = "form-group")]
    class DynamicControl<TOwner> : Control<TOwner> where TOwner : PageObject<TOwner>
    {
        [FindByClass("form-control", Timeout = 0.25)]
        public Input<string, TOwner> Input { get; set; }

        [FindById("fld", Timeout = 0.25)]
        [TermFindSettings(TargetAttributeType = typeof(FindByIdAttribute), Match = TermMatch.StartsWith)]
        public CheckBox<TOwner> Checkbox { get; set; }

        [FindByClass("form-control", Timeout = 0.25)]
        public Select<TOwner> Select { get; set; }

        public void SetRandom()
        {
            if (Checkbox.Exists(new SearchOptions() { IsSafely = true }))
            {
                Checkbox.Set(true);
            }
            else if(Select.Exists(new SearchOptions() { IsSafely = true }))
            {
                Select.Set("Test 2");
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
                    case "date":
                        Input.Set("03/03/2021");
                        break;
                    case "checkbox":
                        //Checkbox.Set(true);
                        Input.Set("true");
                        break;
                    default:
                        // ignore
                        break;

                }
            }           
        }
    }
}
