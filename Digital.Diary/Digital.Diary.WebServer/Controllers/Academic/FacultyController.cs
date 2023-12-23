using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Models.ViewModels.Academic;
using Digital.Diary.Services.Abstractions.Academic;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Academic
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _service;
        private readonly IDepartmentService _deptService;

        public FacultyController(IFacultyService service, IDepartmentService deptService)
        {
            _service = service;
            _deptService = deptService;
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
            var entityListVMs = new List<FacultyVm>();

            foreach (var entity in entities)
            {
                var entityVm = new FacultyVm()
                {
                    Id = entity.Id,
                    FacultyName = entity.FacultyName,
                    ShortName = entity.ShortName,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetAllDeptByFacultyId(Guid id)
        {
            var entities = _deptService.GetAll().Where(data => data.FacultyId == id).OrderBy(data => data.Sequence);
            if (!entities.Any())
            {
                return BadRequest("No entity Found");
            }
            var deptListVm = new List<DepartmentVm>();

            foreach (var entity in entities)
            {
                var fact = _service.GetFirstOrDefault(data => data.Id == entity.FacultyId);
                var dept = new DepartmentVm()
                {
                    Id = entity.Id,
                    DeptName = entity.DeptName,
                    FacultyName = fact.FacultyName,
                    ShortName = fact.ShortName,
                };
                deptListVm.Add(dept);
            }
            return Ok(deptListVm);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] FacultyVm createModel)
        {
            if (ModelState.IsValid)
            {
                Faculty finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, FacultyVm editModel)
        {
            Faculty finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.FacultyName = finalEntity.FacultyName;

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
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new FacultyVm()
            {
                Id = existingEntity.Id,
                FacultyName = existingEntity.FacultyName
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, FacultyVm deleteModel)
        {
            Faculty finalEntity = deleteModel.ToModel();

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