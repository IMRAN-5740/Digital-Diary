using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Models.ViewModels.Academic;
using Digital.Diary.Models.ViewModels.Administration.Associations;
using Digital.Diary.Services.Abstractions.Academic;
using Digital.Diary.Services.Abstractions.Administration.Associations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Administration.Associations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociationEmployeeController : ControllerBase
    {
        private readonly IAssociationEmployeeService _service;
        private readonly IDesignationService _dService; 
        private readonly IAssociationService _aService;

        public AssociationEmployeeController(
            IAssociationEmployeeService service, 
            IDesignationService dService,
            IAssociationService aService)
        {
            _service = service;
            _dService = dService;
            _aService = aService;
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
            var entityListVMs = new List<AssociationEmployeeVm>();

            foreach (var entity in entities)
            {
                var dName = _dService.GetFirstOrDefault(x => x.Id == entity.DesignationId).DesignationName;
                var aName = _aService.GetFirstOrDefault(x => x.Id == entity.AssociationId).AssociationName;


                var entityVm = new AssociationEmployeeVm()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                    ProfileImage=entity.ProfileImage,
                    DesignationId = entity.DesignationId,
                    AssociationId = entity.AssociationId,
                    DesignationName = dName,
                    AssociationName= aName,
                   
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] AssociationEmployeeVm createModel)
        {
            if (ModelState.IsValid)
            {
                AssociationEmployee finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, AssociationEmployeeVm editModel)
        {
            AssociationEmployee finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.Name = finalEntity.Name;
            existingEntity.Email= finalEntity.Email;
            existingEntity.ProfileImage = finalEntity.ProfileImage;
            existingEntity.PhoneNum= finalEntity.PhoneNum;
            existingEntity.AssociationId = finalEntity.AssociationId;
            existingEntity.DesignationId= finalEntity.DesignationId;

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
            var aName = _aService.GetFirstOrDefault(x => x.Id == existingEntity.AssociationId).AssociationName;

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new AssociationEmployeeVm()
            {
                Id = existingEntity.Id,
                Name = existingEntity.Name,
                Email= existingEntity.Email,
                PhoneNum= existingEntity.PhoneNum,
                ProfileImage= existingEntity.ProfileImage,
                DesignationId= existingEntity.DesignationId,
                AssociationId= existingEntity.AssociationId,
                AssociationName=aName,
                DesignationName=dName,
                
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, AssociationEmployeeVm deleteModel)
        {
            AssociationEmployee finalEntity = deleteModel.ToModel();

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

