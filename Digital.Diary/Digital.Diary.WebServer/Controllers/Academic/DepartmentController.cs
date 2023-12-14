using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Models.ViewModels.Academic;
using Digital.Diary.Services.Abstractions.Academic;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Academic
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly IFacultyService _fService;

        public DepartmentController(IDepartmentService service, IFacultyService fService)
        {
            _service = service;
            _fService = fService;
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
            var entityListVMs = new List<DepartmentVm>();

            foreach (var entity in entities)
            {
                var fName = _fService.GetFirstOrDefault(x => x.Id == entity.FacultyId).FacultyName;

                var entityVm = new DepartmentVm()
                {
                    Id = entity.Id,
                    DeptName = entity.DeptName,
                    FacultyId = entity.FacultyId,
                    FacultyName = fName,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] DepartmentVm createModel)
        {
            if (ModelState.IsValid)
            {
                Department finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, DepartmentVm editModel)
        {
            Department finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.DeptName = finalEntity.DeptName;
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

            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new DepartmentVm()
            {
                Id = existingEntity.Id,
                DeptName = existingEntity.DeptName,
                FacultyId = existingEntity.FacultyId,
                FacultyName = fName,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, DepartmentVm deleteModel)
        {
            Department finalEntity = deleteModel.ToModel();

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