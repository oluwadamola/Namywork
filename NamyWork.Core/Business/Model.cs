using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamyWork.Core.Business
{
    public abstract class Model
    {
        public void Assign(object source)
        {
            if (source != null)
            {
                var destProperties = GetType().GetProperties();
                foreach (var sourceProperty in source.GetType().GetProperties())
                {
                    foreach (var desProperty in destProperties)
                    { 
                        if(desProperty.Name == sourceProperty.Name && desProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                        {
                            desProperty.SetValue(this, sourceProperty.GetValue(source, new object[] {}), new object[] {});
                            break;
                        }
                    }
                }
            }
        }

        public virtual Operation Validate() {
            return Operation.Create(() => {

                Validator.ValidateObject(this, new ValidationContext(this, serviceProvider: null, items: null));

            });
        }
        public virtual IEnumerable<ValidationResult> validate(ValidationContext validationContext) => new ValidationResult[0];

        //protected BasedModel()
        //{

            
        //}
    }
}
