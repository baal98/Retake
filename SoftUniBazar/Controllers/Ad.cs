using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Models;
using SoftUniBazar.Services;
using SoftUniBazar.Services.Interfaces;
using System.Security.Claims;

namespace SoftUniBazar.Controllers;

public class Ad : BaseController
{
    private readonly IAdService _adService;
    private readonly ICategoryService categoryService;

    public Ad(IAdService adService, ICategoryService categoryService)
    {
        _adService = adService;
        this.categoryService = categoryService;
    }

    public IActionResult All()
    {
        var ads = _adService.GetAllAds();
        ViewBag.Title = "Selected Ads for You";
        return View(ads);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var categories = this.categoryService.GetAllCategories();

        var viewModel = new AdAddEditViewModel
        {
            Categories = categories
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Add(AdAddEditViewModel model)
    {
        var userId = GetUserId();
        model.Categories = _adService.GetAllCategories();

        _adService.AddAd(model, userId);
        ViewBag.Title = "Selected Ads for You";
        return RedirectToAction("All");
    }

    [HttpPost]
    public IActionResult AddToCart(int id)
    {
        var userId = GetUserId();
        _adService.AddToCart(id, userId);
        return RedirectToAction("Cart");
    }

    public IActionResult Cart()
    {
        var userId = GetUserId();

        var cartItems = _adService.GetCartItems(userId);

        return View(cartItems);
    }


    [HttpPost]
    public IActionResult RemoveFromCart(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _adService.RemoveFromCart(id, userId);

        return RedirectToAction("Cart");
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        var model = _adService.GetAdForEdit(id);
        if (model == null)
        {
            return NotFound();
        }
        model.Categories = _adService.GetAllCategories();

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(AdAddEditViewModel model)
    {
        model.Categories = _adService.GetAllCategories();

        _adService.EditAd(model);

        return RedirectToAction("All");
    }
}