using aspTask3DependencyInjection.Entities.Concretes;
using aspTask3DependencyInjection.Models;
using aspTask3DependencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace aspTask3DependencyInjection.Controllers
{
    public class FastFoodController : Controller
    {
        private readonly IFastFoodService _fastFoodService;

        public FastFoodController(IFastFoodService fastFoodService)
        {
            _fastFoodService = fastFoodService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fastFoods = await _fastFoodService.GetAllAsync();
            var homeIndexViewModel = new FastFoodIndexViewModel { FastFoods = fastFoods.ToList() };
            return View(homeIndexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _fastFoodService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currentFastFood = await _fastFoodService.GetByIdAsync(id);
            var newFastFood = new FastFood(currentFastFood.Id,currentFastFood.Name,currentFastFood.Description,currentFastFood.Discount,currentFastFood.Price,currentFastFood.ImagePath,currentFastFood.Ccal);
            var fastFoodEditViewModel = new FastFoodEditViewModel { FastFood = currentFastFood };
            return View(fastFoodEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(FastFoodEditViewModel vm)
        {
            if (ModelState.IsValid) {
                _fastFoodService.UpdateAsync(vm.FastFood);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Edit),vm);
        }

        [HttpGet]
        public  IActionResult Add()
        {
            var fastFoodAddViewModel = new FastFoodAddViewModel { NewFastFood = new FastFood() };
            return View(fastFoodAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FastFoodAddViewModel vm)
        {
            if (ModelState.IsValid) {
                await _fastFoodService.AddAsync(vm.NewFastFood);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Add),vm);
        }
    }
}
