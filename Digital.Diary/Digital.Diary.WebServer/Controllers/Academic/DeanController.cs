using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Models.ViewModels.Academic;
using Digital.Diary.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Academic
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeanController : ControllerBase
    {
        private IDeanService _service;
        private IFacultyService _fService;
        private IDesignationService _dService;


        public DeanController(IDeanService service,IFacultyService fService,IDesignationService dService)
        {
            _service = service;
            _fService = fService;
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
            var entityListVMs = new List<DeanVm>();

            foreach (var entity in entities)
            {
                var fName = _fService.GetFirstOrDefault(x => x.Id == entity.FacultyId).FacultyName;
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;

                var entityVm = new DeanVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage = entity.ProfileImage,
                    DeginationId=entity.DesignationId,
                    DesignationName=dName,
                    FacultyId = entity.FacultyId,
                    FacultyName = fName
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] DeanVm createModel)
        {
            if (ModelState.IsValid)
            {
                Dean finalEntity = createModel.ToModel();
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
                }
            }

            return Ok(createModel);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, DeanVm editModel)
        {
            Dean finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.Name = finalEntity.Name;
            existingEntity.Email = finalEntity.Email;
            existingEntity.PhoneNum = finalEntity.PhoneNum;
            existingEntity.ProfileImage = finalEntity.ProfileImage;
            existingEntity.DesignationId = finalEntity.DesignationId;
            existingEntity.FacultyId = finalEntity.FacultyId;
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
            var fName = _fService.GetFirstOrDefault(x => x.Id == existingEntity.FacultyId).FacultyName;
            var dName = _dService.GetFirstOrDefault(x => x.Id == existingEntity.DesignationId).DesignationName;
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new DeanVm()
            {
                Id = existingEntity.Id,
                Name = existingEntity.Name,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
                ProfileImage = existingEntity.ProfileImage,
                DeginationId= existingEntity.DesignationId,
                DesignationName=dName,
                FacultyId = existingEntity.FacultyId,
                FacultyName= fName,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, DeanVm deleteModel)
        {
            Dean finalEntity = deleteModel.ToModel();

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