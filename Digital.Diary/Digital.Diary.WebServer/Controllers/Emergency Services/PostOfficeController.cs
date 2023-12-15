using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Models.ViewModels.Emergency_Services;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Emergency_Services;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Emergency_Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostOfficeController : ControllerBase
    {
        private readonly IPostOfficeService _service;
        private readonly IDesignationService _dService;

        public PostOfficeController(IPostOfficeService service, IDesignationService dService)
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
            var entityListVMs = new List<PostOfficeVm>();

            foreach (var entity in entities)
            {
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;

                var entityVm = new PostOfficeVm()
                {
                    Id = entity.Id,
                    PostOfficeName = entity.PostOfficeName,
                    PostCode = entity.PostCode,
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
        public IActionResult Create([FromBody] PostOfficeVm createModel)
        {
            if (ModelState.IsValid)
            {
                PostOffice finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, PostOfficeVm editModel)
        {
            PostOffice finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.PostOfficeName = finalEntity.PostOfficeName;
            existingEntity.PostCode = finalEntity.PostCode;
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
            var entity = new PostOfficeVm()
            {
                Id = existingEntity.Id,
                PostOfficeName = existingEntity.PostOfficeName,
                PostCode = existingEntity.PostCode,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
                DesignationId = existingEntity.DesignationId,
                DesignationName = dName,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, PostOfficeVm deleteModel)
        {
            PostOffice finalEntity = deleteModel.ToModel();

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