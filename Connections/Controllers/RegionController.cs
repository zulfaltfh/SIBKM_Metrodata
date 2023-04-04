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
                _vRegion.Success("ditambahkan");
            }
            else
            {
                _vRegion.Failure("ditambahkan");
            }
        }

        // UPDATE
        public void Update(Region region)
        {
            var result = _regionRepository.Update(region);
            if (result > 0)
            {
                _vRegion.Success("diperbarui");
            }
            else
            {
                _vRegion.Failure("diperbarui");
            }
        }

        // DELETE
        public void Delete(int id)
        {
            var result = _regionRepository.Delete(id);
            if (result > 0)
            {
                _vRegion.Success("dihapus");
            }
            else
            {
                _vRegion.Failure("dihapus");
            }
        }
    }
}
