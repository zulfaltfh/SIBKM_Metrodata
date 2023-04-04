using Connections.Models;
using Connections.Repositories.Interfaces;
using Connections.Views.CountryView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Controllers
{
    public class CountryController
    {
        private readonly ICountryRepository _CountryRepository; //membaca interface dari Country repository
        private readonly VCountry _vCountry; //membaca view Country

        public CountryController(ICountryRepository CountryRepository, VCountry vCountry)
        {
            _CountryRepository = CountryRepository;
            _vCountry = vCountry;
        }

        public void GetAll()
        {
            var Countries = _CountryRepository.GetAll();
            if (Countries == null)
            {
                _vCountry.DataNotFound();
            }
            _vCountry.GetAll(Countries);
        }

        // GET BY ID
        public void GetById(string id)
        {
            var Countries = _CountryRepository.GetById(id);
            if (Countries == null)
            {
                _vCountry.DataNotFound();
            }
            _vCountry.GetById(Countries);
        }

        // INSERT
        public void Insert(Country countries)
        {
            var result = _CountryRepository.Insert(countries);
            if (result > 0)
            {
                _vCountry.Success("ditambahkan");
            }
            else
            {
                _vCountry.Failure("ditambahkan");
            }
        }

        // UPDATE
        public void Update(Country countries)
        {
            var result = _CountryRepository.Update(countries);
            if (result > 0)
            {
                _vCountry.Success("diperbarui");
            }
            else
            {
                _vCountry.Failure("diperbarui");
            }
        }

        // DELETE
        public void Delete(string id)
        {
            var result = _CountryRepository.Delete(id);
            if (result > 0)
            {
                _vCountry.Success("dihapus");
            }
            else
            {
                _vCountry.Failure("dihapus");
            }
        }
    }
}
