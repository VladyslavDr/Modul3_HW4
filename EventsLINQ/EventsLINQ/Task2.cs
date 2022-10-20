using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EventsLINQ
{
    public class Task2
    {
        private List<Contact> _contacts = new List<Contact>();
        private List<Contact> _contacts2 = new List<Contact>();

        public Task2()
        {
            _contacts.Add(new Contact() { Name = "911", Phone = "911", Group = Group.Emergency });
            _contacts.Add(new Contact() { Name = "Sister", Phone = "067452689", Group = Group.Family });
            _contacts.Add(new Contact() { Name = "Nina", Phone = "0665235698" });
            _contacts.Add(new Contact() { Name = "Oleg", Phone = "+380995788482", Email = "Oleg228@gmail.com", Group = Group.Friends });
            _contacts.Add(new Contact() { Name = "Bob", Phone = "0667888523", Email = "SuperBob@gmail.com", Group = Group.Friends });
            _contacts.Add(new Contact() { Name = "Tomas", Phone = "+380993664255", Email = "TomasWork@gmail.com", Group = Group.Colleagues });
            _contacts.Add(new Contact() { Name = "Mam", Phone = "0664963699", Group = Group.Family });

            _contacts2.Add(new Contact() { Name = "Dad", Phone = "+380994775233", Group = Group.Family });
            _contacts2.Add(new Contact() { Name = "Bro", Phone = "0998636623", Group = Group.Family });
            _contacts2.Add(new Contact() { Name = "Li", Phone = "06663999696", Email = "Li@mail.ru", Group = Group.Friends });
        }

        public void Run()
        {
            // Bob, 911, Mam
            var selectContact = _contacts.Where(w => w.Name.Length == 3);

            // Mam
            selectContact = _contacts.Where(w => w.Name.ToLower().StartsWith("m")).OrderBy(o => o);

            // Tomas, Oleg
            var selectContact2 = _contacts.Where(w => w.Phone.ToLower().Contains("+")).OrderByDescending(o => o.Name).Select(s => new { s.Name, s.Phone });

            // Siser
            var selectContact3 = _contacts.FirstOrDefault(f => f.Group == Group.Family);

            // Oleg, Bob, Tomas, Mam
            var selectContact4 = _contacts.SkipWhile(s => s.Email == null);

            // Dad, Bro, Sister, Mam
            var familyContact = _contacts2.Where(w => w.Group == Group.Family).Union(_contacts.Where(w => w.Group == Group.Family));

            // 3
            var countContact = familyContact.Count(c => c.Name.Length < 4);
        }
    }
}
