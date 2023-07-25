using System;
using System.Collections.Generic;


namespace VendorApp.Models
{
    // Namespace declaration: VendorApp.Models
    // Namespaces are used to organize classes and avoid naming conflicts.
    // Classes within this namespace will belong to the VendorApp.Models namespace.
    // The actual namespace hierarchy may include more parent namespaces, but they are not shown in this code snippet.
    
    public class Vendor
    {
        // Class declaration: Vendor
        // This class defines the blueprint for creating Vendor objects.

        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        // These are properties with automatic getters and setters.
        // They provide access to the private member variables Name, Description, and Id.
        // With "get" and "set" accessors omitted, C# automatically generates the default getter and setter for each property.

        private List<Order> _orders = new List<Order> { };
        // This is a private member variable of type List<Order>.
        // It is used to store a collection of Order objects related to this Vendor.
        // The List<Order> is initialized with an empty list using the empty constructor.

        private static List<Vendor> _instances = new List<Vendor> { };
        // This is a private static member variable of type List<Vendor>.
        // It is used to store a collection of all Vendor objects created so far.
        // The static keyword means this list is shared among all instances of the Vendor class.

        public Vendor(string name, string description)
        {
            // Constructor: Vendor(string name, string description)
            // This constructor is used to create a new Vendor object with the specified name and description.

            Name = name;
            Description = description;
            // The constructor sets the Name and Description properties with the values passed as arguments.

            Id = _instances.Count;
            // The Id property is set to the number of Vendor objects created so far (the count of _instances list).
            // This ensures each Vendor object will have a unique Id based on the order of creation.

            _instances.Add(this);
            // The current Vendor object (this) is added to the _instances list.
            // This allows the application to keep track of all Vendor objects created.
        }
     public static void ClearAll()
    {
      _instances.Clear();
    }
     public static List<Vendor> GetAll()
    {
      return _instances;
    } 
    public static Vendor Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public void AddOrder(Order order)
    {
      _orders.Add(order);
    }
     public List<Order> GetOrders()
    {
      return _orders;
    }
     public int GetOrderCount()
    {
      return _orders.Count;
    }
      public static Vendor GetVendorWithId(int id)
    {
      foreach (Vendor vendor in _instances)
      {
        if (vendor.Id == id)
        {
          return vendor;
        }
      }
      return null;
    }
        public Order GetOrderWithId(int id)
    {
      foreach (Order item in _orders)
      {
        if (item.Id == id)
        {
          return item;
        }
      }
      return null;
    }
    public static Vendor SearchVendor(string vendorSearch)
    {
      foreach (Vendor vendor in _instances)
      {
        if (vendor.Name == vendorSearch)
        {
          return vendor;
        }
      }
      return null;
    }
   
    
  }
}
