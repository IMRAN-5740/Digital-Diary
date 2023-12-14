using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Models.ViewModels.Administration.Committees;
using Digital.Diary.Models.ViewModels.Administration.Offices;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Administration.Committees;
using Digital.Diary.Services.Abstractions.Administration.Offices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Administration.Offices
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeEmployeeController : ControllerBase
    {
        private readonly IOfficeEmployeeService _service;
        private readonly IDesignationService _dService;
        private readonly IOfficeService _oService;

        public OfficeEmployeeController(
            IOfficeEmployeeService service,
            IDesignationService dService,
            IOfficeService oService)
        {
            _service = service;
            _dService = dService;
            _oService = oService;
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var entities = _service.GetAll();
            if (!entities.Any())
            {
                return BadRequest("No entity Found");
            }
            var entityListVMs = new List<OfficeEmployeeVm>();

            foreach (var entity in entities)
            {
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;
                var oName = _oService.GetFirstOrDefault(x => x.Id == entity.OfficeId).OfficeName;


                var entityVm = new OfficeEmployeeVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage = entity.ProfileImage,
                    DesignationId = entity.DesignationId,
                    OfficeId = entity.OfficeId,
                    DesignationName = dName,
                    OfficeName = oName

                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] OfficeEmployeeVm createModel)
        {
            if (ModelState.IsValid)
            {
                OfficeEmployee finalEntity = createModel.ToModel();
                finalEntity.Id = Guid.NewGuid();
                var result = _service.Create(finalEntity);
                if (result.IsSucced)
                {
                    ModelState.Clear();
                    return Ok(result);
                }
                if (result.ErrorMessages.Any())
                {
                    foreach (var error in result.ErrorMessages)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return Ok(result);

                }
            }

            return Ok(createModel);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, OfficeEmployeeVm editModel)
        {
            OfficeEmployee finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.Name = finalEntity.Name;
            existingEntity.Email = finalEntity.Email;
            existingEntity.ProfileImage = finalEntity.ProfileImage;
            existingEntity.PhoneNum = finalEntity.PhoneNum;
            existingEntity.OfficeId = finalEntity.OfficeId;
            existingEntity.DesignationId = finalEntity.DesignationId;

            var result = _service.Update(existingEntity);
            if (result.IsSucced)
            {
                ModelState.Clear();
                return Ok(result);
            }
            if (result.ErrorMessages.Any())
            {
                foreach (var error in result.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return Ok(finalEntity);
        }

        [HttpGet]
        [Route("Details/{id:Guid}")]
        public IActionResult Details(Guid id)
        {
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            var dName = _dService.GetFirstOrDefault(x => x.Id == existingEntity.DesignationId).DesignationName;
            var oName = _oService.GetFirstOrDefault(x => x.Id == existingEntity.OfficeId).OfficeName;

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new OfficeEmployeeVm()
            {
                Id = existingEntity.Id,
                Name = existingEntity.Name,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
                ProfileImage = existingEntity.ProfileImage,
                DesignationId = existingEntity.DesignationId,
                OfficeId = existingEntity.OfficeId,
                OfficeName = oName,
                DesignationName = dName,

            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, OfficeEmployeeVm deleteModel)
        {
            OfficeEmployee finalEntity = deleteModel.ToModel();

            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }

            var result = _service.Remove(existingEntity);
            if (result.IsSucced)
            {
                ModelState.Clear();
                return Ok(result);
            }
            if (result.ErrorMessages.Any())
            {
                foreach (var error in result.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return Ok();
        }
    }
}
