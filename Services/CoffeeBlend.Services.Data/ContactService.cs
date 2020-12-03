namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Common.Repositories;
    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Web.ViewModels.ContactViewModel;

    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task CreateAsync(ContactInputModel input)
        {
            var contact = new Contact
            {
                FullName = input.FullName,
                Email = input.Email,
                Subject = input.Subject,
                Message = input.Message,
            };

            await this.contactRepository.AddAsync(contact);
            await this.contactRepository.SaveChangesAsync();
        }
    }
}
