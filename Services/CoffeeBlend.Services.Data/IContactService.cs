namespace CoffeeBlend.Services.Data
{
    using System.Threading.Tasks;

    using CoffeeBlend.Web.ViewModels.ContactViewModel;

    public interface IContactService
    {
        Task CreateAsync(ContactInputModel input);
    }
}
