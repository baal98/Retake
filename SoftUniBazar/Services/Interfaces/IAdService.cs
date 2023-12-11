using SoftUniBazar.Models;

namespace SoftUniBazar.Services.Interfaces;

public interface IAdService
{
    IEnumerable<AdViewModel> GetAllAds();
    void AddAd(AdAddEditViewModel model, string userId);
    void AddToCart(int adId, string userId);
    AdAddEditViewModel GetAdForEdit(int adId);
    List<CategoryDropdownViewModel> GetAllCategories();
    void EditAd(AdAddEditViewModel model);
    void RemoveFromCart(int adId, string userId);
    IEnumerable<AdViewModel> GetCartItems(string username);
}