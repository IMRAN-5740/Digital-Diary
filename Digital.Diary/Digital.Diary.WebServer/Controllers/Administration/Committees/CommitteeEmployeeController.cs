using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Models.ViewModels.Administration.Associations;
using Digital.Diary.Models.ViewModels.Administration.Committees;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Administration.Associations;
using Digital.Diary.Services.Abstractions.Administration.Committees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Administration.Committees
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommitteeEmployeeController : ControllerBase
    {
        private readonly ICommitteeEmployeeService _service;
        private readonly IDesignationService _dService;
        private readonly ICommitteeService _cService;

        public CommitteeEmployeeController(
            ICommitteeEmployeeService service,
            IDesignationService dService,
            ICommitteeService cService)
        {
            _service = service;
            _dService = dService;
            _cService = cService;
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
            var entityListVMs = new List<CommitteeEmployeeVm>();

            foreach (var entity in entities)
            {
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;
                var cName = _cService.GetFirstOrDefault(x => x.Id == entity.CommitteeId).CommitteeName;


                var entityVm = new CommitteeEmployeeVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage = entity.ProfileImage,
                    DesignationId = entity.DesignationId,
                    CommitteeId = entity.CommitteeId,
                    DesignationName = dName,
                    CommitteeName = cName,

                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CommitteeEmployeeVm createModel)
        {
            if (ModelState.IsValid)
            {
                CommitteeEmployee finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, CommitteeEmployeeVm editModel)
        {
            CommitteeEmployee finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.Name = finalEntity.Name;
            existingEntity.Email = finalEntity.Email;
            existingEntity.ProfileImage = finalEntity.ProfileImage;
            existingEntity.PhoneNum = finalEntity.PhoneNum;
            existingEntity.CommitteeId = finalEntity.CommitteeId;
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
            var cName = _cService.GetFirstOrDefault(x => x.Id == existingEntity.CommitteeId).CommitteeName;

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new CommitteeEmployeeVm()
            {
                Id = existingEntity.Id,
                Name = existingEntity.Name,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
                ProfileImage = existingEntity.ProfileImage,
                DesignationId = existingEntity.DesignationId,
                CommitteeId = existingEntity.CommitteeId,
                CommitteeName = cName,
                DesignationName = dName,

            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, CommitteeEmployeeVm deleteModel)
        {
            CommitteeEmployee finalEntity = deleteModel.ToModel();

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

