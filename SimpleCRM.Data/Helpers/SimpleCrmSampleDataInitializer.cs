using SimpleCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SimpleCRM.Data.Helpers
{
    public class SimpleCrmSampleDataInitializer : DropCreateDatabaseIfModelChanges<SimpleCrmDbContext>
    {
        public SimpleCrmSampleDataInitializer()
        {

        }

        protected override void Seed(SimpleCrmDbContext ctx)
        {
            ctx.Contacts.Add(new Contact
            {
                Name = new Name
                {
                    First = "John",
                    Last = "Smith",
                    Middle = "R",
                    Prefix = "Mr",
                    Suffix = "Jr"
                },
                HomePhone = "(303) 123-1234",
                MobilePhone = "(303) 123-1234",
                BusinessPhone = "(303) 123-1234",
                EmailAddress = "jsmith@gmail.com",
                HomeAddress = new Address
                {
                    Street1 = "123 Main St",
                    Street2 = "#300",
                    City = "Denver",
                    StateOrProvince = "CO",
                    Country = "US",
                    PostalCode = "80123-123",
                    County = "Jefferson"

                },
                Activities = new[]{
                    new Activity{
                         Subject="Activity 1",
                         Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In iaculis, dui ac sollicitudin fringilla, sapien augue malesuada leo, at venenatis est velit et nibh. Aliquam sit amet libero neque. Cras non magna lectus. Nunc scelerisque nisi at justo sollicitudin eleifend. Vivamus ut vestibulum nisi. Etiam sit amet sapien enim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque rhoncus nunc non nunc dictum facilisis. Vivamus vel libero et arcu pharetra molestie. Sed sagittis accumsan lorem. Duis porta pellentesque quam vel convallis. Donec ornare sodales tincidunt. Integer convallis vulputate faucibus. Phasellus eu fermentum tellus."                         
                    },
                    new Activity{
                         Subject="Activity 2",
                         Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In iaculis, dui ac sollicitudin fringilla, sapien augue malesuada leo, at venenatis est velit et nibh. Aliquam sit amet libero neque. Cras non magna lectus. Nunc scelerisque nisi at justo sollicitudin eleifend. Vivamus ut vestibulum nisi. Etiam sit amet sapien enim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque rhoncus nunc non nunc dictum facilisis. Vivamus vel libero et arcu pharetra molestie. Sed sagittis accumsan lorem. Duis porta pellentesque quam vel convallis. Donec ornare sodales tincidunt. Integer convallis vulputate faucibus. Phasellus eu fermentum tellus."                         
                    },
                    new Activity{
                         Subject="Activity 3",
                         Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In iaculis, dui ac sollicitudin fringilla, sapien augue malesuada leo, at venenatis est velit et nibh. Aliquam sit amet libero neque. Cras non magna lectus. Nunc scelerisque nisi at justo sollicitudin eleifend. Vivamus ut vestibulum nisi. Etiam sit amet sapien enim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque rhoncus nunc non nunc dictum facilisis. Vivamus vel libero et arcu pharetra molestie. Sed sagittis accumsan lorem. Duis porta pellentesque quam vel convallis. Donec ornare sodales tincidunt. Integer convallis vulputate faucibus. Phasellus eu fermentum tellus."                         
                    },
                }
            });

            ctx.Contacts.Add(new Contact
            {
                Name = new Name
                {
                    First = "Sally Jo",
                    Last = "Bob",
                    Middle = "R",
                    Prefix = "Ms",
                    Suffix = "III"
                },
                HomePhone = "(303) 123-1234",
                MobilePhone = "(303) 123-1234",
                EmailAddress = "sjbob@gmail.com",
                BusinessAddress = new Address
                {
                    Street1 = "123 Main St",
                    Street2 = "#300",
                    City = "Denver",
                    StateOrProvince = "CO",
                    Country = "US",
                    PostalCode = "80123-123",
                    County = "Jefferson"

                }
            });




            ctx.SaveChanges();
        }
    }
}
