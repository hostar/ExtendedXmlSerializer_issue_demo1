using System;
using System.Collections.Generic;

namespace AnotherNamespace
{
    public class SampleModel
    {
        private string firstName = "default_first_name";
        public string FirstName 
        {
            get => firstName; 
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    firstName = value;
                }
            }
        }

        private string lastName = "default_last_name";
        public string LastName
        {
            get => lastName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lastName = value;
                }
            }
        }

        private List<SampleItem> listOfItems = null;
        public List<SampleItem> ListOfItems
        {
            get
            {
                if (listOfItems == null)
                {
                    listOfItems = new List<SampleItem> { 
                        new SampleItem 
                        { 
                            ItemName = "item1",
                            ItemValue = 1
                        },
                        new SampleItem
                        {
                            ItemName = "item2",
                            ItemValue = 2
                        }
                    };
                }
                return listOfItems;
            }

            set => listOfItems = value;
        }
    }

    public class SampleItem
    {
        public string ItemName { get; set; }
        public int ItemValue { get; set; }
    }
}
