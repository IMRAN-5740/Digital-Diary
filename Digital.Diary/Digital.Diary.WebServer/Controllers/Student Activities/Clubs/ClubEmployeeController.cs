using Digital.Diary.Models.EntityModels.Miscellaneous;
using Digital.Diary.Models.EntityModels.Student_Activities.Clubs;
using Digital.Diary.Models.ViewModels.Miscellaneous;
using Digital.Diary.Models.ViewModels.Student_Activities.Clubs;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Miscellaneous;
using Digital.Diary.Services.Abstractions.Student_Activities.Clubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Student_Activities.Clubs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubEmployeeController : ControllerBase
    {
        private readonly IClubEmployeeService _service;
        private readonly IDesignationService _dService;
        private readonly IClubService _cService;

        public ClubEmployeeController(
            IClubEmployeeService service,
            IDesignationService dService,
            IClubService cService)
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
            var entityListVMs = new List<ClubEmployeeVm>();

            foreach (var entity in entities)
            {
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;
                var cName = _cService.GetFirstOrDefault(x => x.Id == entity.ClubId).ClubName;

                var entityVm = new ClubEmployeeVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage = entity.ProfileImage,
                    DesignationId = entity.DesignationId,
                    ClubId = entity.ClubId,
                    DesignationName = dName,
                    ClubName = cName
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] ClubEmployeeVm createModel)
        {
            if (ModelState.IsValid)
            {
                ClubEmployee finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, ClubEmployeeVm editModel)
        {
            ClubEmployee finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.Name = finalEntity.Name;
            existingEntity.Email = finalEntity.Email;
            existingEntity.ProfileImage = finalEntity.ProfileImage;
            existingEntity.PhoneNum = finalEntity.PhoneNum;
            existingEntity.ClubId = finalEntity.ClubId;
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
            var bName = _cService.GetFirstOrDefault(x => x.Id == existingEntity.ClubId).ClubName;

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new ClubEmployeeVm()
            {
                Id = existingEntity.Id,
                Name = existingEntity.Name,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
                ProfileImage = existingEntity.ProfileImage,
                DesignationId = existingEntity.DesignationId,
                ClubId = existingEntity.ClubId,
                ClubName = bName,
                DesignationName = dName,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, ClubEmployeeVm deleteModel)
        {
            ClubEmployee finalEntity = deleteModel.ToModel();

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