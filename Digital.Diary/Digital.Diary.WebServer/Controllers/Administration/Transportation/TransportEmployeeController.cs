using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Models.ViewModels.Administration.Transportations;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Administration.Transportation;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Administration.Transportation
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportEmployeeController : ControllerBase
    {
        private readonly ITransportEmployeeService _service;
        private readonly IDesignationService _dService;
        private readonly ITransportService _tService;

        public TransportEmployeeController(
            ITransportEmployeeService service,
            IDesignationService dService,
            ITransportService tService)
        {
            _service = service;
            _dService = dService;
            _tService = tService;
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
            var entityListVMs = new List<TransportEmployeeVm>();

            foreach (var entity in entities)
            {
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;
                var tName = _tService.GetFirstOrDefault(x => x.Id == entity.TransportId).BusName;

                var entityVm = new TransportEmployeeVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage = entity.ProfileImage,
                    DesignationId = entity.DesignationId,
                    TransportId = entity.TransportId,
                    DesignationName = dName,
                    BusName = tName
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] TransportEmployeeVm createModel)
        {
            if (ModelState.IsValid)
            {
                TransportEmployee finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, TransportEmployeeVm editModel)
        {
            TransportEmployee finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.Name = finalEntity.Name;
            existingEntity.Email = finalEntity.Email;
            existingEntity.ProfileImage = finalEntity.ProfileImage;
            existingEntity.PhoneNum = finalEntity.PhoneNum;
            existingEntity.TransportId = finalEntity.TransportId;
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
            var tName = _tService.GetFirstOrDefault(x => x.Id == existingEntity.TransportId).BusName;

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new TransportEmployeeVm()
            {
                Id = existingEntity.Id,
                Name = existingEntity.Name,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
                ProfileImage = existingEntity.ProfileImage,
                DesignationId = existingEntity.DesignationId,
                TransportId = existingEntity.TransportId,
                BusName = tName,
                DesignationName = dName,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, TransportEmployeeVm deleteModel)
        {
            TransportEmployee finalEntity = deleteModel.ToModel();

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