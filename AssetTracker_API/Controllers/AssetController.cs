using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using AssetTracker_API.ViewModel;
using AssetTracket_Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker_API.Controllers
{
    [Route("api/[controller]")]
   
    [ApiController]
    public class AssetController : ControllerBase
    {
        private AssetsTrackerContext _db;
        public AssetController(AssetsTrackerContext db) { _db = db; }
        
        [HttpGet("GetAllAssets")]
        public async Task<List<AssetsVM>> GetAllAssets()
        {
            var list = await _db.Asset.Include(x=>x.Category).ToListAsync();
            var listAssets = new List<AssetsVM>();
            foreach (var item in list)
            {
                AssetsVM model = new AssetsVM()
                {
                    AssetId = item.AssetId,
                    AssetName = item.AssetName,
                    CategoryId = item.CategoryId,
                    Category = item.Category.CategoryName,
                    Description = item.Description,                   
                    IsAvailable = item.IsAvailable,
                    AssetNmb = item.AssetNmb.Value
                };
                listAssets.Add(model);
            }
            return listAssets;
        }
        [HttpPost("AddAsset")]
        public ActionResult AddAsset([FromBody]List<Asset> listOfAssets)
        {
            foreach (var item in listOfAssets)
            {
                _db.Asset.Add(item);
            }
            
            _db.SaveChanges();

            return Ok();
        }
    }
}