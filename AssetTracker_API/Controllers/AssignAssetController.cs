using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetTracker_API.ViewModel;
using AssetTracket_Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AssetTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AssignAssetController : ControllerBase
    {
        private AssetsTrackerContext _db;
        public AssignAssetController(AssetsTrackerContext db) { _db = db; }
        [HttpGet("GetAssignedAsset")]
        public ActionResult<List<AssignedAssetsVM>> GetAssignedAsset()
        {
            var list = _db.AssignAsset.Include(x=>x.Asset).Include(x=>x.Employee).ToList();
            List<AssignedAssetsVM> model = new List<AssignedAssetsVM>();
            foreach (var item in list)
            {
                AssignedAssetsVM asset = new AssignedAssetsVM()
                {
                    AssetId = item.AssetId,
                    Asset = item.Asset.AssetName,
                    AssetNmb = item.Asset.AssetNmb.Value,
                    AssignAssetId = item.AssignAssetId,
                    DateFrom = item.DateFrom,
                    DateTo = item.DateTo,
                    EmployeeId = item.EmployeeId,
                    Employee = item.Employee.FirstName + " " + item.Employee.LastName
                };
                model.Add(asset);
            }
            return model;
        }
        [HttpGet("GetById")]
        public ActionResult GetById(int id)
        {
            AssignAsset asset = _db.AssignAsset.Include(x=>x.Employee).Include(x=>x.Asset).Where(x=>x.AssignAssetId==id).SingleOrDefault();
            return Ok(asset);
        }
        [HttpPost("AssignAssetToUser")]
        public ActionResult AssignAssetToUser([FromBody]AssignAsset asset)
        {
            try
            {
                _db.AssignAsset.Add(asset);
                _db.SaveChanges();
                Asset a = _db.Asset.Find(asset.AssetId);
                a.IsAvailable = false;
                _db.Asset.Update(a);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }


        }
        [HttpPut("UpdateAssignAsset")]
        public ActionResult UpdateAssignAsset([FromBody] AssignAsset asset)
        {
            AssignAsset asigned = _db.AssignAsset.Find(asset.AssignAssetId);
            asigned.DateTo = asset.DateTo;
            asigned.Comment = asset.Comment;
            _db.SaveChanges();
            Asset a = _db.Asset.Find(asset.AssetId);
            a.IsAvailable = true;            
            _db.SaveChanges();
            return Ok();
        }
    }
}