using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace _301225212HosseinTehrani_Ass4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
          
            var actualAddress1 = new Address
            {
                AddressID = 1,
                AddressLine1 = "555 east 2nd",
                AddressLine2 = "3333 west 1st",
                City = "Toronto",
                StateProvince = "ontario",
                CountryRegion = "Canada",
                PostalCode = "2v34df"

            };
            var Customer1Address = new CustomerAddress
            {
                AddressType = "House",
                ModifedDate = "March 2023",
                CustomerID = 29,
                AddressID = 1,
                Address = actualAddress1
            };


            var actualAddress2 = new Address
            {
                AddressID = 2,
                AddressLine1 = "555 east 2nd",
                AddressLine2 = "3333 west 1st",
                City = "Toronto",
                StateProvince = "ontario",
                CountryRegion = "Canada",
                PostalCode = "2v34df"

            };
            var Customer2Address = new CustomerAddress
            {
                AddressType = "House",
                ModifedDate = "March 2023",
                CustomerID = 29,
                AddressID = 2,
                Address = actualAddress2
            };



            var actualAddress3 = new Address
            {
                AddressID = 3,
                AddressLine1 = "555 east 2nd",
                AddressLine2 = "3333 west 1st",
                City = "Toronto",
                StateProvince = "ontario",
                CountryRegion = "Canada",
                PostalCode = "2v34df"

            };
            var Customer3Address = new CustomerAddress
            {
                AddressType = "House",
                ModifedDate = "March 2023",
                CustomerID = 29,
                AddressID = 3,
                Address = actualAddress3
            };



            var actualAddress4 = new Address
            {
                AddressID = 4,
                AddressLine1 = "555 east 2nd",
                AddressLine2 = "3333 west 1st",
                City = "Toronto",
                StateProvince = "ontario",
                CountryRegion = "US",
                PostalCode = "2v34df"

            };
            var Customer4Address = new CustomerAddress
            {
                AddressType = "House",
                ModifedDate = "March 2023",
                CustomerID = 29,
                AddressID = 4,
                Address = actualAddress4
            };





            var Customer1 = new Customer
            {

                CustomerID = 1,
                NameStyle = "bold",
                Title="Mr",
                FirstName="Amind",
                MiddleName="H",
                LastName="Tehrani",
                CompanyName="Centennial",
                SalesPerson="Bob",
                EmailAddress="Amin@cool.com",
                Phone="555555",
                Password="123",
                CustomerAddresses = new List<CustomerAddress> { Customer1Address }
               
               
            };
   
        

            var Customer2 = new Customer
            {
                CustomerID = 2,
        NameStyle = "bold",
                Title = "Mrs",
                FirstName = "Ameena",
                MiddleName = "H",
                LastName = "Tehrani",
                CompanyName = "Centennial",
                SalesPerson = "Bob",
                EmailAddress = "Amina@cool.com",
                Phone = "555555",
                Password = "1234",
                CustomerAddresses = new List<CustomerAddress> { Customer2Address }

            };
           

    
            var Customer3 = new Customer
            {
                CustomerID = 3,
                NameStyle = "bold",
                Title = "Mrs",
                FirstName = "Mike",
                MiddleName = "H",
                LastName = "Bob",
                CompanyName = "Bestbuy",
                SalesPerson = "Mary",
                EmailAddress = "Bob@cool.com",
                Phone = "555555",
                Password = "12345",
                CustomerAddresses = new List<CustomerAddress> { Customer3Address }
            };
       


           

            var Customer4 = new Customer
            {
                CustomerID = 4,
                NameStyle = "bold",
                Title = "Mr",
                FirstName = "Larry",
                MiddleName = "H",
                LastName = "Michael",
                CompanyName = "Centennial",
                SalesPerson = "Jim",
                EmailAddress = "Larry@cool.com",
                Phone = "555555",
                Password = "12345",
                CustomerAddresses = new List<CustomerAddress> { Customer4Address }
            };

           
            
            using (var db = new Assignment4DataModelContext())
            {
           

             
                Customer customer1 = db.Customers.FirstOrDefault(c => c.EmailAddress == "Amin@cool.com");
                Customer customer2 = db.Customers.FirstOrDefault(c => c.EmailAddress == "Amina@cool.com");
                Customer customer3 = db.Customers.FirstOrDefault(c => c.EmailAddress == "Bob@cool.com");
                Customer customer4 = db.Customers.FirstOrDefault(c => c.EmailAddress == "Larry@cool.com");

              //  var addresses = db.CustomerAddresses.ToList();

          //   db.CustomerAddresses.RemoveRange(addresses.ToList());


         //     var customers = db.Customers.ToList();
         //    db.Customers.RemoveRange(customers);

                //Remove all customers from the database
         

          
                if (customer1 == null && customer2 == null && customer3 == null) { 
                db.Customers.Add(Customer1);
                db.Customers.Add(Customer2);
                db.Customers.Add(Customer3);
                db.Customers.Add(Customer4);
                }
        
        
                db.SaveChanges();
                

            }

            using (var db = new Assignment4DataModelContext())
            {
                //MyGrid.ItemsSource = db.Customers.ToList();
                MyGrid.ItemsSource = db.Customers.Include(c => c.CustomerAddresses).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var firstNameColumn = MyGrid.Columns.FirstOrDefault(c => c.Header.ToString() == "FirstName");
            if (firstNameColumn != null)
            {
                MyGrid.Items.SortDescriptions.Clear();
                MyGrid.Items.SortDescriptions.Add(new SortDescription(firstNameColumn.SortMemberPath, ListSortDirection.Ascending));
                MyGrid.Items.Refresh();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string targetAddress = "Canada";

            using (var context = new Assignment4DataModelContext())
            {
                var customers = from ca in context.CustomerAddresses
                                where ca.Address.CountryRegion == targetAddress
                                select ca.Customer;

                MyGrid.ItemsSource = customers.ToList();
            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var companyNameColumn = MyGrid.Columns.FirstOrDefault(c => c.Header.ToString() == "CompanyName");
            if (companyNameColumn != null)
            {
                MyGrid.Items.SortDescriptions.Clear();
                MyGrid.Items.SortDescriptions.Add(new SortDescription(companyNameColumn.SortMemberPath, ListSortDirection.Ascending));
                MyGrid.Items.Refresh();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            using (var db = new Assignment4DataModelContext())
            {
                //MyGrid.ItemsSource = db.Customers.ToList();
                MyGrid.ItemsSource = db.Customers.Include(c => c.CustomerAddresses).ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int customerIdToFind = Convert.ToInt32(findtxt.Text);

       
            using (var db = new Assignment4DataModelContext())
            {
            
                var customerList = db.Customers.Where(c => c.CustomerID == customerIdToFind).ToList();
                //MyGrid.ItemsSource = db.Customers.ToList();
                MyGrid.ItemsSource = customerList;
            }
        }

        private void findtxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        
            using (var db = new Assignment4DataModelContext())
            {
               
               
                int customerIdToFind = Convert.ToInt32(findtxt.Text);
                var customer = db.Customers.Find(customerIdToFind);
                var customerAddressToDelete = db.CustomerAddresses.FirstOrDefault(ca => ca.CustomerID == customerIdToFind);
              
                if (customerAddressToDelete != null && customer != null)
                {
                    db.CustomerAddresses.Remove(customerAddressToDelete);

                    db.Customers.Remove(customer);

         
                }
               
                db.SaveChanges();
                MyGrid.ItemsSource = db.Customers.Include(c => c.CustomerAddresses).ToList();
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            using (var db = new Assignment4DataModelContext())
            {
                int customerIdToFind = Convert.ToInt32(findtxt.Text);
                
                var customer = db.Customers.Find(customerIdToFind);

                // Update the name property of the customer
                if(!string.IsNullOrEmpty(editnametxt.Text))
                { 
                customer.FirstName = editnametxt.Text;
                }
                if (!string.IsNullOrEmpty(editsalespersontxt.Text))
                {
                    customer.SalesPerson = editsalespersontxt.Text;
                }

                db.SaveChanges();
                MyGrid.ItemsSource = db.Customers.Include(c => c.CustomerAddresses).ToList();
            }
        }
    }
}
