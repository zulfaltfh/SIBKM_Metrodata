using Connections.Models;
using Connections.Repositories.Interfaces;
using Connections.Views.RegionView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Controller
{
    public class RegionController
    {
        //Isi dari sebuah class region yang ada di repository

        private readonly IRegionRepository _regionRepository; //membaca interface dari region repository
        private readonly VRegion _vRegion; //membaca view region

        public RegionController(IRegionRepository regionRepository, VRegion vRegion)
        {
            _regionRepository = regionRepository;
            _vRegion = vRegion;
        }

        public void GetAll()
        {
            var regions = _regionRepository.GetAll();
            if(regions == null)
            {
                _vRegion.DataNotFound();
            }
            _vRegion.GetAll(regions);
        }

        // GET BY ID
        public void GetById(int id)
        {
            var regions = _regionRepository.GetById(id);
            if (regions == null)
            {
                _vRegion.DataNotFound();
            }
            _vRegion.GetById(regions);
        }

        // INSERT
        public void Insert(Region region)
        {
            var result = _regionRepository.Insert(region);
            if (result > 0)
            {
                _vRegion.Success("inserted");
            }
            else
            {
                _vRegion.Failure("insert");
            }
        }

        // UPDATE
        public void Update(Region region)
        {

        }

        // DELETE
        public void Delete(int id)
        {

        }

        internal void GetById(Region region)
        {
            throw new NotImplementedException();
        }
    }
}
