using System.ComponentModel.DataAnnotations.Schema;
using ISAProject.Configuration.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class Company: Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Address Address { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Equipment> Equipment { get; private set; }
        
        [NotMapped]
        public virtual ICollection<User> Admins { get; private set; }

        public Company() {}
        public Company(string name, string description, Address address, ICollection<User> users)
        {
            Validate(name, description);
            Name = name;
            Description = description;
            Address = address;
            Admins = users;
        }

        private static void Validate(string name, string description)
        {
            if (name == null || name.Equals("")) throw new ArgumentException("Exception! Empty name!");
            if (description == null || description.Equals("")) throw new ArgumentException("Exception! Empty description!");
        }
    }
}
