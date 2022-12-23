﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ContactPro.Data;
using ContactPro.Models;
using ContactPro.Enums;
using ContactPro.Services;
using ContactPro.Services.Interfaces;

namespace ContactPro.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager; //the underscore is a naming convention that helps identify a variable as being private.
        private readonly IImageService _imageService;
        private readonly IAddressBookService _addressBookService;

        public ContactsController(ApplicationDbContext context, 
                                  UserManager<AppUser> userManager,
                                  IImageService imageService,
                                  IAddressBookService addressBookService)//injection. Where we push information into the controller. it allows access to objects established anywhere inside the properties.
        {
            _context = context; // allows access to database.
            _userManager = userManager;
            _imageService = imageService;
            _addressBookService = addressBookService;
        }

        // GET: Contacts
        [Authorize]
        public IActionResult Index(int categoryId) //int categoryId links to the Contacts index.cshtml
        {
            var contacts = new List<Contact>();
            /*List<Contact> contacts = new List<Contact>();*/ //explicit decoration. Shortens syntax.
            string appUserId = _userManager.GetUserId(User);

            //return userId and its associated contacts and categories.
            AppUser appUser = _context.Users
                                      .Include(c => c.Contacts)
                                      .ThenInclude(c => c.Categories)
                                      .FirstOrDefault(u => u.Id == appUserId)!; // c represents AppUser class in this instance. u represents user. ! added at the end to avoid green null warning. Because a user will be logged in to see the values being pulled it is safe to ignore this warning.

            var categories = appUser.Categories;

            if(categoryId == 0) // This is for if "All Contacts" is selection. If zero "All Contacts". Else anything other than zero in the array.
            {
            contacts = appUser.Contacts.OrderBy(c => c.LastName)
                                       .ThenBy(c => c.FirstName)
                                       .ToList();
            } 
            else
            {
                contacts = appUser.Categories.FirstOrDefault(c => c.Id == categoryId)
                                   .Contacts
                                   .OrderBy(c => c.LastName)
                                   .ThenBy(c => c.FirstName)
                                   .ToList();
            }


            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", categoryId);

            return View(contacts);

        }

        [Authorize]
        public IActionResult SearchContacts(string searchString)
        {
            string appUserId = _userManager.GetUserId(User);
            var contacts = new List<Contact>();

            AppUser appUser = _context.Users
                                      .Include(c => c.Contacts)
                                      .ThenInclude(c => c.Categories)
                                      .FirstOrDefault(u => u.Id == appUserId);

            if(String.IsNullOrEmpty(searchString)) //if is default search. Else is with a search string in place.
            {
                contacts = appUser.Contacts
                                  .OrderBy(c => c.LastName)
                                  .ThenBy(c => c.FirstName)
                                  .ToList();
            }
            else
            {
                contacts = appUser.Contacts.Where(c => c.FullName!.ToLower().Contains(searchString.ToLower())) // convert both FullName and searchString to lower in order to make search easier for the user with more success.
                                  .OrderBy(c => c.LastName)
                                  .ThenBy(c => c.FirstName)
                                  .ToList();
            }
            ViewData["CategoryId"] = new SelectList(appUser.Categories, "Id", "Name", 0); //0 is present to select all values and not filter.

            return View(nameof(Index), contacts); //make sure that we are routing to Index view but with contacts result being inserted.
        }

        // GET: Contacts/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        [Authorize]
        public async Task<IActionResult> Create() //Needs to be written as a task because there is an async/await function being performed.
        {
            string appUserId = _userManager.GetUserId(User);
            ViewData["StatesList"] = new SelectList(Enum.GetValues(typeof(States)).Cast<States>().ToList());
            //Cast simply takes the result<States> and tells the States that they will be converted into a list. This is where our result/states will be stored.
            //A smarter explanation: The Cast<TResult>(IEnumerable) method enables the standard query operators to be invoked on non-generic collections by supplying the necessary type information. 
            ViewData["CategoryList"] = new MultiSelectList(await _addressBookService.GetUserCategoriesAsync(appUserId), "Id", "Name");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate,Address1,Address2,City,State,ZipCode,Email,PhoneNumber,ImageFile")] Contact contact, List<int> CategoryList) //Bind references all inputs by name. List<int> categoryList was added to ensure that categories could be read and saved. It could not be added to the bind traditionally because it is a multiselect list.
        {
            ModelState.Remove("AppUserId");
            if (ModelState.IsValid)
            {
                contact.AppUserId = _userManager.GetUserId(User);
                contact.Created = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc); //When is Now. UTC is universal time code.

                if (contact.BirthDate != null)
                {
                    contact.BirthDate = DateTime.SpecifyKind(contact.BirthDate.Value, DateTimeKind.Utc); //SpecifyKind... first is what we want to convert. the 2nd is the information we are using. We are using the DateTimeKind.Utc taken in when created to create a Birthdate Value. This is all shared through the contact itself as the DateTimeKind.Utc was previously passed through to it when created with the AppUserId behind the scenes.
                }

                if (contact.ImageFile != null)
                {
                    contact.ImageData = await _imageService.ConvertFileToByteArrayAsync(contact.ImageFile);
                    contact.ImageType = contact.ImageFile.ContentType; // looks at file and determines what type it is. Doc, Png, jpeg ect.
                    // with this final bit. we have saved images to the database.
                }

                _context.Add(contact);
                await _context.SaveChangesAsync();

                //loop over all of the selected categories.
                foreach (int categoryId in CategoryList)
                {
                    await _addressBookService.AddContactToCategoryAsync(categoryId, contact.Id); //called method from the service. Is a Task the same as a Function?
                }
                //save each category selected to the contact categories table.

                return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction(nameof(Index)); //Takes us back to the list page instead of keeping us on the edit page.
     
        }

        // GET: Contacts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", contact.AppUserId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDate,Address1,Address2,City,State,ZipCode,Email,PhoneNumber,ImageFile")] Contact contact) //This was edited to reflect what was being taken in from the form.
        {
            if (id != contact.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", contact.AppUserId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
          return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
