using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Models.ViewModels.Emergency_Services;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Emergency_Services;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Emergency_Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceStationController : ControllerBase
    {
        private readonly IPoliceStationService _service;
        private readonly IDesignationService _dService;

        public PoliceStationController(IPoliceStationService service, IDesignationService dService)
        {
            _service = service;
            _dService = dService;
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
            var entityListVMs = new List<PoliceStationVm>();

            foreach (var entity in entities)
            {
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;
                var entityVm = new PoliceStationVm()
                {
                    Id = entity.Id,
                    StationName = entity.StationName,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    DesignationId = entity.DesignationId,
                    DesignationName = dName,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] PoliceStationVm createModel)
        {
            if (ModelState.IsValid)
            {
                PoliceStation finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, PoliceStationVm editModel)
        {
            PoliceStation finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.StationName = finalEntity.StationName;
            existingEntity.Email = finalEntity.Email;
            existingEntity.PhoneNum = finalEntity.PhoneNum;
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

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new PoliceStationVm()
            {
                Id = existingEntity.Id,
                StationName = existingEntity.StationName,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
                DesignationId = existingEntity.DesignationId,
                DesignationName = dName,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, PoliceStationVm deleteModel)
        {
            PoliceStation finalEntity = deleteModel.ToModel();

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